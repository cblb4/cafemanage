using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CafeManagementSystem
{
    public partial class AdminAddUsers : UserControl
    {
        connection kon = new connection();
        SqlConnection con;

        public AdminAddUsers()
        {
            InitializeComponent();
            con = kon.getConnect();
            displayAddUsersData();
        }

        public void displayAddUsersData()
        {
            AdminAddUsersdata udata = new AdminAddUsersdata();
            List<AdminAddUsersdata> ldata = udata.usersListData();

            dataGridView1.DataSource = ldata;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        public bool emptyFields()
        {
            if (adminAddUsers_username.Text == "" || adminAddUsers_password.Text == ""
                || adminAddUsers_role.Text == "" || adminAddUsers_status.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void adminAddUsers_addbtn_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("All fields are required to be filled", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();

                    string selectusern = "SELECT * FROM [Cafe].[dbo].[cafe] WHERE [Username] = @usern";

                    using (SqlCommand checkusern = new SqlCommand(selectusern, con))
                    {
                        checkusern.Parameters.AddWithValue("@usern", adminAddUsers_username.Text.Trim());
                        SqlDataAdapter adapter = new SqlDataAdapter(checkusern);
                        DataTable tble = new DataTable();
                        adapter.Fill(tble);

                        if (tble.Rows.Count >= 1)
                        {
                            string usern = adminAddUsers_username.Text.Substring(0, 1).ToUpper() + adminAddUsers_username.Text.Substring(1);
                            MessageBox.Show(usern + " is already taken.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string insertData = "INSERT INTO [Cafe].[dbo].[cafe] ([Username],[Password],[role],[status],[date_reg]) " +
                                                "VALUES (@usern, @pass, @role, @status, @date)";
                            DateTime today = DateTime.Today;

                            using (SqlCommand cmd = new SqlCommand(insertData, con))
                            {
                                cmd.Parameters.AddWithValue("@usern", adminAddUsers_username.Text.Trim());
                                cmd.Parameters.AddWithValue("@pass", adminAddUsers_password.Text.Trim());
                                cmd.Parameters.AddWithValue("@role", adminAddUsers_role.Text.Trim());
                                cmd.Parameters.AddWithValue("@status", adminAddUsers_status.Text.Trim());
                                cmd.Parameters.AddWithValue("@date", today);

                                cmd.ExecuteNonQuery();

                                clearFields();

                                MessageBox.Show("Added Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                displayAddUsersData();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void adminAddUsers_updatebtn_Click(object sender, EventArgs e)
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

                    string updData = "UPDATE [Cafe].[dbo].[cafe] SET [Username] = @usern, [Password] = @pass, [role] = @role, [status] = @status WHERE [id] = @id";

                    using (SqlCommand cmd = new SqlCommand(updData, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@usern", adminAddUsers_username.Text.Trim());
                        cmd.Parameters.AddWithValue("@pass", adminAddUsers_password.Text.Trim());
                        cmd.Parameters.AddWithValue("@role", adminAddUsers_role.Text.Trim());
                        cmd.Parameters.AddWithValue("@status", adminAddUsers_status.Text.Trim());

                        cmd.ExecuteNonQuery();
                        clearFields();

                        MessageBox.Show("Updated Sucessfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        displayAddUsersData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private int id = 0;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            id = Convert.ToInt32(row.Cells[0].Value);
            adminAddUsers_username.Text = row.Cells[1].Value.ToString();
            adminAddUsers_password.Text = row.Cells[2].Value.ToString();
            adminAddUsers_role.Text = row.Cells[3].Value.ToString();
            adminAddUsers_status.Text = row.Cells[4].Value.ToString();
        }

        public void clearFields()
        {
            adminAddUsers_username.Text = "";
            adminAddUsers_password.Text = "";
            adminAddUsers_role.SelectedIndex = -1;
            adminAddUsers_status.SelectedIndex = -1;
        }

        private void adminAddUsers_clearbtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void adminAddUsers_deletebtn_Click(object sender, EventArgs e)
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

                    string delData = "DELETE FROM [Cafe].[dbo].[cafe] WHERE [id] = @id";

                    using (SqlCommand cmd = new SqlCommand(delData, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();
                        clearFields();

                        MessageBox.Show("Deleted Sucessfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        displayAddUsersData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
