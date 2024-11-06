    namespace CafeManagementSystem
{
    partial class AdminAddProducts
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.adminAddProducts_status = new System.Windows.Forms.ComboBox();
            this.adminAddProducts_type = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.adminAddProducts_updatebtn = new System.Windows.Forms.Button();
            this.adminAddProducts_addbtn = new System.Windows.Forms.Button();
            this.adminAddProducts_price = new System.Windows.Forms.TextBox();
            this.adminAddProducts_clearbtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.adminAddProducts_deletebtn = new System.Windows.Forms.Button();
            this.adminAddProducts_stock = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.adminAddProducts_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.adminAddProducts_id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(33, 332);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(947, 312);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Information about product:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(169)))), ((int)(((byte)(127)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(235)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Location = new System.Drawing.Point(35, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(889, 235);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.adminAddProducts_status);
            this.panel1.Controls.Add(this.adminAddProducts_type);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.adminAddProducts_updatebtn);
            this.panel1.Controls.Add(this.adminAddProducts_addbtn);
            this.panel1.Controls.Add(this.adminAddProducts_price);
            this.panel1.Controls.Add(this.adminAddProducts_clearbtn);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.adminAddProducts_deletebtn);
            this.panel1.Controls.Add(this.adminAddProducts_stock);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.adminAddProducts_name);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.adminAddProducts_id);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(33, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(947, 283);
            this.panel1.TabIndex = 2;
            // 
            // adminAddProducts_status
            // 
            this.adminAddProducts_status.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminAddProducts_status.FormattingEnabled = true;
            this.adminAddProducts_status.Items.AddRange(new object[] {
            "Available",
            "Unavailable"});
            this.adminAddProducts_status.Location = new System.Drawing.Point(685, 159);
            this.adminAddProducts_status.Name = "adminAddProducts_status";
            this.adminAddProducts_status.Size = new System.Drawing.Size(239, 26);
            this.adminAddProducts_status.TabIndex = 25;
            // 
            // adminAddProducts_type
            // 
            this.adminAddProducts_type.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.adminAddProducts_type.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminAddProducts_type.FormattingEnabled = true;
            this.adminAddProducts_type.Items.AddRange(new object[] {
            "Iced Coffee drinks",
            "Hot Drinks",
            "Limited Flavors"});
            this.adminAddProducts_type.Location = new System.Drawing.Point(189, 159);
            this.adminAddProducts_type.Name = "adminAddProducts_type";
            this.adminAddProducts_type.Size = new System.Drawing.Size(233, 26);
            this.adminAddProducts_type.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(534, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 22);
            this.label7.TabIndex = 22;
            this.label7.Text = "Status              :";
            // 
            // adminAddProducts_updatebtn
            // 
            this.adminAddProducts_updatebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(169)))), ((int)(((byte)(127)))));
            this.adminAddProducts_updatebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adminAddProducts_updatebtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminAddProducts_updatebtn.Location = new System.Drawing.Point(664, 218);
            this.adminAddProducts_updatebtn.Name = "adminAddProducts_updatebtn";
            this.adminAddProducts_updatebtn.Size = new System.Drawing.Size(152, 38);
            this.adminAddProducts_updatebtn.TabIndex = 17;
            this.adminAddProducts_updatebtn.Text = "UPDATE";
            this.adminAddProducts_updatebtn.UseVisualStyleBackColor = false;
            this.adminAddProducts_updatebtn.Click += new System.EventHandler(this.adminAddProducts_updatebtn_Click);
            // 
            // adminAddProducts_addbtn
            // 
            this.adminAddProducts_addbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(169)))), ((int)(((byte)(127)))));
            this.adminAddProducts_addbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adminAddProducts_addbtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminAddProducts_addbtn.Location = new System.Drawing.Point(189, 218);
            this.adminAddProducts_addbtn.Name = "adminAddProducts_addbtn";
            this.adminAddProducts_addbtn.Size = new System.Drawing.Size(129, 38);
            this.adminAddProducts_addbtn.TabIndex = 16;
            this.adminAddProducts_addbtn.Text = "ADD";
            this.adminAddProducts_addbtn.UseVisualStyleBackColor = false;
            this.adminAddProducts_addbtn.Click += new System.EventHandler(this.adminAddProducts_addbtn_Click);
            // 
            // adminAddProducts_price
            // 
            this.adminAddProducts_price.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminAddProducts_price.Location = new System.Drawing.Point(687, 105);
            this.adminAddProducts_price.Name = "adminAddProducts_price";
            this.adminAddProducts_price.Size = new System.Drawing.Size(239, 29);
            this.adminAddProducts_price.TabIndex = 21;
            this.adminAddProducts_price.TextChanged += new System.EventHandler(this.adminAddProducts_price_TextChanged);
            // 
            // adminAddProducts_clearbtn
            // 
            this.adminAddProducts_clearbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(169)))), ((int)(((byte)(127)))));
            this.adminAddProducts_clearbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adminAddProducts_clearbtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminAddProducts_clearbtn.Location = new System.Drawing.Point(500, 218);
            this.adminAddProducts_clearbtn.Name = "adminAddProducts_clearbtn";
            this.adminAddProducts_clearbtn.Size = new System.Drawing.Size(141, 39);
            this.adminAddProducts_clearbtn.TabIndex = 19;
            this.adminAddProducts_clearbtn.Text = "CLEAR";
            this.adminAddProducts_clearbtn.UseVisualStyleBackColor = false;
            this.adminAddProducts_clearbtn.Click += new System.EventHandler(this.adminAddProducts_clearbtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(534, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 22);
            this.label6.TabIndex = 20;
            this.label6.Text = "Price                 :";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // adminAddProducts_deletebtn
            // 
            this.adminAddProducts_deletebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(169)))), ((int)(((byte)(127)))));
            this.adminAddProducts_deletebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adminAddProducts_deletebtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminAddProducts_deletebtn.Location = new System.Drawing.Point(342, 218);
            this.adminAddProducts_deletebtn.Name = "adminAddProducts_deletebtn";
            this.adminAddProducts_deletebtn.Size = new System.Drawing.Size(137, 38);
            this.adminAddProducts_deletebtn.TabIndex = 18;
            this.adminAddProducts_deletebtn.Text = "DELETE";
            this.adminAddProducts_deletebtn.UseVisualStyleBackColor = false;
            this.adminAddProducts_deletebtn.Click += new System.EventHandler(this.adminAddProducts_deletebtn_Click);
            // 
            // adminAddProducts_stock
            // 
            this.adminAddProducts_stock.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminAddProducts_stock.Location = new System.Drawing.Point(686, 38);
            this.adminAddProducts_stock.Name = "adminAddProducts_stock";
            this.adminAddProducts_stock.Size = new System.Drawing.Size(239, 29);
            this.adminAddProducts_stock.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(534, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 22);
            this.label5.TabIndex = 10;
            this.label5.Text = "Stock                :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 22);
            this.label4.TabIndex = 8;
            this.label4.Text = "Type                  :";
            // 
            // adminAddProducts_name
            // 
            this.adminAddProducts_name.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminAddProducts_name.Location = new System.Drawing.Point(183, 98);
            this.adminAddProducts_name.Name = "adminAddProducts_name";
            this.adminAddProducts_name.Size = new System.Drawing.Size(239, 29);
            this.adminAddProducts_name.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "Product Name :";
            // 
            // adminAddProducts_id
            // 
            this.adminAddProducts_id.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminAddProducts_id.Location = new System.Drawing.Point(183, 38);
            this.adminAddProducts_id.Name = "adminAddProducts_id";
            this.adminAddProducts_id.Size = new System.Drawing.Size(239, 29);
            this.adminAddProducts_id.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Product ID       :";
            // 
            // AdminAddProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(169)))), ((int)(((byte)(127)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "AdminAddProducts";
            this.Size = new System.Drawing.Size(1023, 681);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox adminAddProducts_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox adminAddProducts_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox adminAddProducts_stock;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button adminAddProducts_clearbtn;
        private System.Windows.Forms.Button adminAddProducts_deletebtn;
        private System.Windows.Forms.Button adminAddProducts_updatebtn;
        private System.Windows.Forms.Button adminAddProducts_addbtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox adminAddProducts_price;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox adminAddProducts_type;
        private System.Windows.Forms.ComboBox adminAddProducts_status;
    }
}
