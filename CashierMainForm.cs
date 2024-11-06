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
    public partial class CashierMainForm : Form
    {
        public CashierMainForm()
        {
            InitializeComponent();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to log out?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();

                this.Hide();
            }
        }

        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            adminDashboardForm2.Visible = true;
            cashierOrder1.Visible = false;
            adminAddProducts1.Visible = false;
        }

        private void menu_btn_Click(object sender, EventArgs e)
        {
            adminDashboardForm2.Visible = false;
            cashierOrder1.Visible = true;
            adminAddProducts1.Visible = false;
        }

        private void order_btn_Click(object sender, EventArgs e)
        {
            adminDashboardForm2.Visible = false;
            cashierOrder1.Visible = false;
            adminAddProducts1.Visible = true;
        }
    }
}
