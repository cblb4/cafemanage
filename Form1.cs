using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CafeManagementSystem
{
    public partial class Form1 : Form
    {
        connection kon = new connection();
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader rdr;

        public Form1()
        {
            InitializeComponent();
            con = kon.getConnect();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_registerbtn_Click(object sender, EventArgs e)
        {
            RegisterForm regForm = new RegisterForm();
            regForm.Show();
            this.Hide();
        }

        private void login_showPass_CheckedChanged(object sender, EventArgs e)
        {
            login_password.PasswordChar = login_showPass.Checked ? '\0' : '*';
        }

        public bool emptyFields()
        {
            if (login_username.Text == "" || login_password.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("All fields are required to be filled.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();

                    String selectAccount = "SELECT COUNT (*) FROM [Cafe].[dbo].[cafe] WHERE [Username] = @Username AND [Password] = @Password AND [status] = @Status";
                    using (SqlCommand cmd = new SqlCommand(selectAccount, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", login_username.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", login_password.Text.Trim());
                        cmd.Parameters.AddWithValue("@Status", "Active");

                        int rowCount = (int)cmd.ExecuteScalar();

                        if (rowCount > 0)
                        {
                            string selectRole = "SELECT [role] FROM [Cafe].[dbo].[cafe] WHERE [Username] = @usern AND [Password] = @pass";

                            using (SqlCommand getRole = new SqlCommand(selectRole, con))
                            {
                                getRole.Parameters.AddWithValue("@usern", login_username.Text.Trim());
                                getRole.Parameters.AddWithValue("@pass", login_password.Text.Trim());

                                string userRole = getRole.ExecuteScalar() as string;

                                MessageBox.Show("Login successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                if (userRole == "Admin")
                                {
                                    AdminMainForm adminForm = new AdminMainForm();
                                    adminForm.Show();
                                    this.Hide();
                                }
                                else if (userRole == "Cashier")
                                {
                                    CashierMainForm cashierForm = new CashierMainForm();
                                    cashierForm.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Incorrect Username/Password or you don't have Admin's approval", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
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
