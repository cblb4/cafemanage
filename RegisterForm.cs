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

namespace CafeManagementSystem
{
    public partial class RegisterForm : Form
    {
        connection kon = new connection();
        SqlConnection con;
        SqlCommand cmd;
        //SqlDataReader rdr;

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void register_loginBtn_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Hide();
        }

        private void register_ShowPass_CheckedChanged(object sender, EventArgs e)
        {
            register_password.PasswordChar = register_ShowPass.Checked ? '\0' : '*';
            register_cPassword.PasswordChar = register_ShowPass.Checked ? '\0' : '*';
        }

        public bool emptyFields()
        {
            if (register_username.Text == "" || register_password.Text == "" || register_cPassword.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void register_btn_Click(object sender, EventArgs e)
        {
            con = kon.getConnect(); 

            if (emptyFields())
            {
                MessageBox.Show("All fields must be completed.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (con.State == ConnectionState.Closed)
                {
                    try
                    {
                        con.Open();

                        String selectUsername = "SELECT * FROM [Cafe].[dbo].[cafe] WHERE [Username] = @Username";
                        //String selectUsername = String.Format("SELECT * FROM [Cafe].[dbo].[cafe] WHERE [Username] = '{0}'", register_username.Text);

                        using (SqlCommand checkUsern = new SqlCommand(selectUsername, con))
                        {
                            checkUsern.Parameters.AddWithValue("@Username", register_username.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(checkUsern);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count > 0)
                            {
                                string Username = register_username.Text.Substring(0, 1).ToUpper() + register_username.Text.Substring(1);
                                MessageBox.Show(Username + " is already taken", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (register_password.Text != register_cPassword.Text)
                            {
                                MessageBox.Show("Passwords do not match", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (register_password.Text.Length < 8)
                            {
                                MessageBox.Show("Password must be at least 8 characters long", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string insertData = "INSERT INTO [Cafe].[dbo].[cafe] ([Username], [Password], [role], [date_reg], [status]) VALUES (@Username, @Password, @Role, @Date, @Status)";
                                //string insertData = String.Format("INSERT INTO [Cafe].[dbo].[cafe] ([Username], [Password], [date_reg]) VALUES ('{0}', '{1}', {2});", register_username.Text, register_password.Text, DateTime.Today);

                                using (SqlCommand insertCommand = new SqlCommand(insertData, con))
                                {
                                    insertCommand.Parameters.AddWithValue("@Username", register_username.Text.Trim());
                                    insertCommand.Parameters.AddWithValue("@Password", register_password.Text.Trim());
                                    insertCommand.Parameters.AddWithValue("@Role", "Cashier");
                                    insertCommand.Parameters.AddWithValue("@Date", DateTime.Now);
                                    insertCommand.Parameters.AddWithValue("@Status", "Approval");


                                    int rowsAffected = insertCommand.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("Registration Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Registration Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                    Form1 loginForm = new Form1();
                                    loginForm.Show();
                                    this.Hide();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
