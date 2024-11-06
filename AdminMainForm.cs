using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagementSystem
{
    public partial class AdminMainForm : Form
    {
        public AdminMainForm()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to log out?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(check == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();

                this.Hide();
            }
            //Application.Exit();
        }

        private void adminAddUsers1_Load(object sender, EventArgs e)
        {
            //DO NOT PUT HERE

        }

        private void button1_Click(object sender, EventArgs e)
        {
            adminDashboardForm1.Visible = true;
            adminAddUsers1.Visible = true;
            adminAddProducts1.Visible = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            adminDashboardForm1.Visible = false;
            adminAddUsers1.Visible = true;
            adminAddProducts1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            adminDashboardForm1.Visible = false;
            adminAddUsers1.Visible = false;
            adminAddProducts1.Visible = true;
        }
    }
}
