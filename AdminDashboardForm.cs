using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CafeManagementSystem
{
    public partial class AdminDashboardForm : UserControl
    {
        connection kon = new connection();

        public AdminDashboardForm()
        {
            InitializeComponent();
            displayTotalCashier();
            displayTodaysIncome();
            displayTotalIncome();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // Handle click event if needed
        }

        public void displayTotalCashier()
        {
            string query = "SELECT COUNT(*) FROM [Cafe].[dbo].[cafe] WHERE [role] = 'Cashier'";

            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-MV98GJ7M;Initial Catalog=Cafe;Integrated Security=True;Encrypt=False"))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    var result = cmd.ExecuteScalar();

                    int numberOfCashiers = Convert.ToInt32(result);
                    dashboard_cashier.Text = numberOfCashiers.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void displayTodaysIncome()
        {
            using (SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-MV98GJ7M;Initial Catalog=Cafe;Integrated Security=True;Encrypt=False"))
            {
                string selectData = "SELECT SUM(TotalPrice) FROM [Cafe].[dbo].[Users] WHERE CAST(OrderDate AS DATE) = @date";

                try
                {
                    connect.Open();

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        DateTime today = DateTime.Today;
                        cmd.Parameters.AddWithValue("@date", today); 

                        object result = cmd.ExecuteScalar(); 

                        decimal todaysIncome = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                        dashboard_todayIncome.Text = todaysIncome.ToString("C2"); // Format as currency
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void displayTotalIncome()
        {
            string query = "SELECT SUM(TotalPrice) FROM [Cafe].[dbo].[Users]";

            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-MV98GJ7M;Initial Catalog=Cafe;Integrated Security=True;Encrypt=False"))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    var result = cmd.ExecuteScalar();

                    decimal totalIncome = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    dashboard_totalIncome.Text = totalIncome.ToString("C2"); // Format as currency
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
