using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
//using System.IO;

namespace CafeManagementSystem
{
    public partial class AdminAddProducts : UserControl
    {
        connection kon = new connection();
        SqlConnection con;

        public AdminAddProducts()
        {
            InitializeComponent();
            con = kon.getConnect();
            displayData();
        }

        public bool emptyfields()
        {
            if (adminAddProducts_id.Text == "" || adminAddProducts_name.Text == ""
                     || adminAddProducts_type.SelectedIndex == -1 || adminAddProducts_stock.Text == ""
                     || adminAddProducts_price.Text == "" || adminAddProducts_status.SelectedIndex == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void adminAddProducts_addbtn_Click(object sender, EventArgs e)
        {
            if (emptyfields())
            {
                MessageBox.Show("All fields are required to be filled.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    string selectProdID = "SELECT * FROM [Cafe].[dbo].[products] WHERE [prod_id] = @prodID";

                    using (SqlCommand selectPID = new SqlCommand(selectProdID, con))
                    {
                        selectPID.Parameters.AddWithValue("@prodID", adminAddProducts_id.Text.Trim());

                        SqlDataAdapter adapter = new SqlDataAdapter(selectPID);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count >= 1)
                        {
                            MessageBox.Show("Product ID: " + adminAddProducts_id.Text.Trim() + " is already taken", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string insertData = "INSERT INTO [Cafe].[dbo].[products] ([prod_id], [prod_name], [prod_type], [prod_stock], [prod_price], [prod_status], [date_insert]) " +
                                                "VALUES(@prodID, @prodName, @prodType, @prodStock, @prodPrice, @prodStatus, @dateInsert)";

                            DateTime today = DateTime.Today;
                            //string path = Path.Combine(@"C:\Users\carlo\Documents\CARLOS BLANCO\2nd yr - 1st term\OOP (LAB)\CafeManagementSystem\Product_Directory\");
                            using (SqlCommand cmd = new SqlCommand(insertData, con))
                            {
                                cmd.Parameters.AddWithValue("@prodID", adminAddProducts_id.Text.Trim());
                                cmd.Parameters.AddWithValue("@prodName", adminAddProducts_name.Text.Trim());
                                cmd.Parameters.AddWithValue("@prodType", adminAddProducts_type.Text.Trim());
                                cmd.Parameters.AddWithValue("@prodStock", adminAddProducts_stock.Text.Trim());
                                cmd.Parameters.AddWithValue("@prodPrice", adminAddProducts_price.Text.Trim());
                                cmd.Parameters.AddWithValue("@prodStatus", adminAddProducts_status.Text.Trim());
                                cmd.Parameters.AddWithValue("@dateInsert", today);


                                clearFields();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Added successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                displayData();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void adminAddProducts_price_TextChanged(object sender, EventArgs e)
        {

        }
        public void clearFields()
        {
            adminAddProducts_id.Text = "";
            adminAddProducts_name.Text = "Name";
            adminAddProducts_type.SelectedIndex = -1;
            adminAddProducts_stock.Text = "";
            adminAddProducts_price.Text = "";
            adminAddProducts_status.SelectedIndex = -1;

        }

        private void adminAddProducts_clearbtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }
        public void displayData()
        {
            adminAddProductsData productsData = new adminAddProductsData();
            List<adminAddProductsData> listData = productsData.productsListData();

            dataGridView1.DataSource = listData;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                adminAddProducts_id.Text = row.Cells[1].Value.ToString();
                adminAddProducts_name.Text = row.Cells[2].Value.ToString();
                adminAddProducts_type.Text = row.Cells[3].Value.ToString();
                adminAddProducts_stock.Text = row.Cells[4].Value.ToString();
                adminAddProducts_price.Text = row.Cells[5].Value.ToString();
                adminAddProducts_status.Text = row.Cells[6].Value.ToString();

            }
        }

        private void adminAddProducts_updatebtn_Click(object sender, EventArgs e)
        {
            if (emptyfields())
            {
                MessageBox.Show("All fields are requried to be filled", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();

                    string updateData = "UPDATE [Cafe].[dbo].[products] SET [prod_name] = @prodName" +
                        ", [prod_type] = @prodType, [prod_stock] = @prodStock, [prod_price] = @prodPrice, [prod_status] = @prodStatus" +
                        ", [date_update] = @dateUpdate WHERE [prod_id] = @prodID";
                    DateTime today = DateTime.Today;

                    using (SqlCommand updateD = new SqlCommand(updateData, con))
                    {
                        updateD.Parameters.AddWithValue("@prodName", adminAddProducts_name.Text.Trim());
                        updateD.Parameters.AddWithValue("@prodType", adminAddProducts_type.Text.Trim());
                        updateD.Parameters.AddWithValue("@prodStock", adminAddProducts_stock.Text.Trim());
                        updateD.Parameters.AddWithValue("@prodPrice", adminAddProducts_price.Text.Trim());
                        updateD.Parameters.AddWithValue("@prodStatus", adminAddProducts_status.Text.Trim());
                        updateD.Parameters.AddWithValue("@dateUpdate", today);
                        updateD.Parameters.AddWithValue("@prodID", adminAddProducts_id.Text.Trim());

                        updateD.ExecuteNonQuery();
                        clearFields();

                        MessageBox.Show("Updated successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        displayData();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection failed: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void adminAddProducts_deletebtn_Click(object sender, EventArgs e)
        {
            if (emptyfields())
            {
                MessageBox.Show("All fields are requried to be filled", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();

                    string updateData = "UPDATE [Cafe].[dbo].[products] SET [date_delete] = @dateDelete WHERE [prod_id] = @prodID";
                    DateTime today = DateTime.Today;

                    using (SqlCommand updateD = new SqlCommand(updateData, con))
                    {

                        updateD.Parameters.AddWithValue("@dateDelete", today);
                        updateD.Parameters.AddWithValue("@prodID", adminAddProducts_id.Text.Trim());

                        updateD.ExecuteNonQuery();
                        clearFields();

                        MessageBox.Show("Removed successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        displayData();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection failed: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
