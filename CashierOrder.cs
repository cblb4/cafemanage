using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace CafeManagementSystem
{
    public partial class CashierOrder : UserControl
    {
        connection kon = new connection();
        SqlConnection con;

        public CashierOrder()
        {
            InitializeComponent();
            displayAvailableProducts();
        }

        public void displayAvailableProducts()
        {
            CashierOrderFormProductData allprds = new CashierOrderFormProductData();
            List<CashierOrderFormProductData> listdat = allprds.availProductsData();
            cashierOrderForm_menuTable.DataSource = listdat;
        }
        private void RefreshOrdersGrid()
        {
            cashierOrderForm_orderTable.DataSource = null;
            cashierOrderForm_orderTable.DataSource = orders; 
        }

        private List<Order> orders = new List<Order>();

        private void cashierOrderForm_addbtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cashierOrderForm_prodName.Text) &&
        !string.IsNullOrEmpty(cashierOrderForm_price.Text) &&
        cashierOrderForm_quantity.Value > 0)
            {
                Order order = new Order
                {
                    ProductID = cashierOrderForm_productID.SelectedItem.ToString(),
                    ProductName = cashierOrderForm_prodName.Text,
                    Quantity = (int)cashierOrderForm_quantity.Value, 
                    Price = decimal.Parse(cashierOrderForm_price.Text)
                };

                orders.Add(order);
                RefreshOrdersGrid();
                UpdateTotalPriceLabel();

            }
            else
            {
                MessageBox.Show("Please select a product and enter a valid quantity.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cashierOrderForm_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            cashierOrderForm_productID.SelectedIndex = -1;
            cashierOrderForm_productID.Items.Clear();
            cashierOrderForm_prodName.Text = "";
            cashierOrderForm_price.Text = "";

            string selectedValue = cashierOrderForm_type.SelectedItem as string;

            if (selectedValue != null)
            {
                try
                {
                    using (SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-MV98GJ7M;Initial Catalog=Cafe;Integrated Security=True;Encrypt=False"))
                    {
                        connect.Open();
                        string selectData = $"SELECT * FROM [Cafe].[dbo].[products] WHERE [prod_type] = '{selectedValue}' AND [prod_status] = @status AND [date_delete] IS NULL";

                        using (SqlCommand cmd = new SqlCommand(selectData, connect))
                        {
                            cmd.Parameters.AddWithValue("@status", "Available");

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string value = reader["prod_id"].ToString();

                                    cashierOrderForm_productID.Items.Add(value);
                                }
                            }
                        }
                    }
                }
                catch (Exception exx)
                {
                    MessageBox.Show("Error: " + exx.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cashierOrderForm_productID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cashierOrderForm_productID.SelectedItem as string;

            if (selectedValue != null)
            {
                try
                {
                    using (SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-MV98GJ7M;Initial Catalog=Cafe;Integrated Security=True;Encrypt=False"))
                    {
                        connect.Open();
                        string selectData = $"SELECT * FROM [Cafe].[dbo].[products] WHERE [prod_id] = '{selectedValue}' AND [prod_status] = @status AND [date_delete] IS NULL";

                        using (SqlCommand cmd = new SqlCommand(selectData, connect))
                        {
                            cmd.Parameters.AddWithValue("@status", "Available");

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string prodName = reader["prod_name"].ToString();
                                    string prodPrice = reader["prod_price"].ToString();

                                    cashierOrderForm_prodName.Text = prodName;
                                    cashierOrderForm_price.Text = prodPrice;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cashierOrderForm_amount_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(cashierOrderForm_amount.Text, out decimal cashAmount))
            {
                decimal totalPrice = CalculateTotalPrice();
                decimal change = cashAmount - totalPrice;

                if (change >= 0)
                {
                    cashierOrderForm_change.Text = change.ToString("F2");
                }
                else
                {
                    cashierOrderForm_change.Text = "Insufficient cash";
                }
            }
            else
            {
                cashierOrderForm_change.Text = "Invalid input";
            }
        }
        private decimal CalculateTotalPrice()
        {
            return orders.Sum(order => order.Total);
        }

        private void UpdateTotalPriceLabel()
        {
            decimal totalPrice = CalculateTotalPrice();
            cashierOrderForm_orderPrice.Text = totalPrice.ToString("F2"); 
        }

        private void cashierOrderForm_paybtn_Click(object sender, EventArgs e)
        {
            if (orders.Count == 0)
            {
                MessageBox.Show("No orders to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-MV98GJ7M;Initial Catalog=Cafe;Integrated Security=True;Encrypt=False"))
                {
                    connect.Open();

                    using (SqlTransaction transaction = connect.BeginTransaction())
                    {
                        try
                        {
                            foreach (var order in orders)
                            {
                                string insertOrder = "INSERT INTO [Cafe].[dbo].[Users] (ProductID, ProductName, Quantity, Price, TotalPrice) " +
                                                     "VALUES (@ProductID, @ProductName, @Quantity, @Price, @TotalPrice)";

                                using (SqlCommand cmd = new SqlCommand(insertOrder, connect, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@ProductID", order.ProductID);
                                    cmd.Parameters.AddWithValue("@ProductName", order.ProductName);
                                    cmd.Parameters.AddWithValue("@Quantity", order.Quantity);
                                    cmd.Parameters.AddWithValue("@Price", order.Price);
                                    cmd.Parameters.AddWithValue("@TotalPrice", order.Total);

                                    cmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();

                            MessageBox.Show("Order has been successfully saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            orders.Clear();
                            RefreshOrdersGrid();
                            UpdateTotalPriceLabel();
                            cashierOrderForm_amount.Text = "";
                            cashierOrderForm_change.Text = "";
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error saving order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cashierOrderForm_clearbtn_Click(object sender, EventArgs e)
        {
            orders.Clear();
            RefreshOrdersGrid();
            UpdateTotalPriceLabel();

            MessageBox.Show("All orders have been cleared.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cashierOrderForm_removebtn_Click(object sender, EventArgs e)
        {
            if (cashierOrderForm_orderTable.SelectedRows.Count > 0)
            {
                int selectedIndex = cashierOrderForm_orderTable.SelectedRows[0].Index;

                if (selectedIndex >= 0 && selectedIndex < orders.Count)
                {
                    orders.RemoveAt(selectedIndex);
                    RefreshOrdersGrid();
                    UpdateTotalPriceLabel();

                    MessageBox.Show("The selected order has been removed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select an order to remove.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private int rowIndex = 0;

        private void cashierOrderForm_receiptbtn_Click(object sender, EventArgs e)
        {
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printDocument1.BeginPrint += new PrintEventHandler(printDocument1_BeginPrint);

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            rowIndex = 0;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float y = e.MarginBounds.Top;
            int headerMargin = 10;
            int tableMargin = 20;
            int count = 0;

            Font font = new Font("Arial", 12);
            Font bold = new Font("Arial", 12, FontStyle.Bold);
            Font headerFont = new Font("Arial", 16, FontStyle.Bold);
            Font labelFont = new Font("Arial", 14, FontStyle.Bold);
            StringFormat alignCenter = new StringFormat { Alignment = StringAlignment.Center };

            // Calculate the total width available for the table
            int totalWidth = e.MarginBounds.Width;
            // Number of columns
            int columnCount = 5;  // As you have 5 columns
                                  // Calculate the width for each column
            int colWidth = totalWidth / columnCount;

            string headerText = "DON MACCHIATOS";
            y += count * headerFont.GetHeight(e.Graphics) + headerMargin;
            e.Graphics.DrawString(headerText, headerFont, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width / 2), y, alignCenter);
            y += tableMargin;

            string[] headers = { "Product ID", "Product Name", "Quantity", "Price", "Total" };

            // Loop through headers to draw each one with proper alignment
            for (int i = 0; i < headers.Length; i++)
            {
                e.Graphics.DrawString(headers[i], bold, Brushes.Black, e.MarginBounds.Left + i * colWidth, y, alignCenter);
            }
            y += tableMargin;

            while (rowIndex < cashierOrderForm_orderTable.Rows.Count)
            {
                DataGridViewRow row = cashierOrderForm_orderTable.Rows[rowIndex];

                for (int i = 0; i < cashierOrderForm_orderTable.Columns.Count; i++)
                {
                    string cellValue = row.Cells[i].Value != null ? row.Cells[i].Value.ToString() : string.Empty;
                    e.Graphics.DrawString(cellValue, font, Brushes.Black, e.MarginBounds.Left + i * colWidth, y);
                }

                rowIndex++;
                y += font.GetHeight(e.Graphics) + tableMargin;

                // If the next row would go off the page, trigger a new page
                if (y + font.GetHeight(e.Graphics) > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }


            decimal totalPrice = CalculateTotalPrice();
            string totalsText = $"Total Price: \t${totalPrice:F2}\nAmount Paid: \t${cashierOrderForm_amount.Text}\nChange: \t${cashierOrderForm_change.Text}";
            y = e.MarginBounds.Bottom - labelFont.GetHeight(e.Graphics) * 3;
            e.Graphics.DrawString(totalsText, labelFont, Brushes.Black, e.MarginBounds.Left, y);

            string footerText = DateTime.Now.ToString();
            y = e.MarginBounds.Bottom - labelFont.GetHeight(e.Graphics);
            e.Graphics.DrawString(footerText, labelFont, Brushes.Black, e.MarginBounds.Right - e.Graphics.MeasureString(footerText, labelFont).Width, y);

            e.HasMorePages = false; 
        }
    }
}
