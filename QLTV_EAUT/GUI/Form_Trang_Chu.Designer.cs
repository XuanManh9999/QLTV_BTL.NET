﻿namespace GUI
{
    partial class Form_Trang_Chu
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnXemSach = new Guna.UI2.WinForms.Guna2Button();
            this.btnThemSachMuon = new Guna.UI2.WinForms.Guna2Button();
            this.btnDangXuat = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.btnDangXuat);
            this.guna2GroupBox1.Controls.Add(this.btnThemSachMuon);
            this.guna2GroupBox1.Controls.Add(this.btnXemSach);
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(23, 31);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(277, 505);
            this.guna2GroupBox1.TabIndex = 0;
            this.guna2GroupBox1.Text = "Các Chức Năng";
            // 
            // btnXemSach
            // 
            this.btnXemSach.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXemSach.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXemSach.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXemSach.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXemSach.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXemSach.ForeColor = System.Drawing.Color.White;
            this.btnXemSach.Location = new System.Drawing.Point(3, 55);
            this.btnXemSach.Name = "btnXemSach";
            this.btnXemSach.Size = new System.Drawing.Size(274, 61);
            this.btnXemSach.TabIndex = 0;
            this.btnXemSach.Text = "Xem Sách";
            this.btnXemSach.Click += new System.EventHandler(this.btnXemSach_Click);
            // 
            // btnThemSachMuon
            // 
            this.btnThemSachMuon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThemSachMuon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThemSachMuon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThemSachMuon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThemSachMuon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThemSachMuon.ForeColor = System.Drawing.Color.White;
            this.btnThemSachMuon.Location = new System.Drawing.Point(3, 131);
            this.btnThemSachMuon.Name = "btnThemSachMuon";
            this.btnThemSachMuon.Size = new System.Drawing.Size(274, 63);
            this.btnThemSachMuon.TabIndex = 1;
            this.btnThemSachMuon.Text = "Xem Sách Đã Mượn";
            this.btnThemSachMuon.Click += new System.EventHandler(this.btnThemSachMuon_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDangXuat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDangXuat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDangXuat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDangXuat.ForeColor = System.Drawing.Color.White;
            this.btnDangXuat.Location = new System.Drawing.Point(3, 211);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(274, 63);
            this.btnDangXuat.TabIndex = 3;
            this.btnDangXuat.Text = "Đăng Xuất";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(306, 31);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(725, 505);
            this.guna2PictureBox1.TabIndex = 1;
            this.guna2PictureBox1.TabStop = false;
            // 
            // Form_Trang_Chu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 562);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.guna2GroupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_Trang_Chu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Trang_Chu";
            this.Load += new System.EventHandler(this.Form_Trang_Chu_Load);
            this.guna2GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Button btnDangXuat;
        private Guna.UI2.WinForms.Guna2Button btnThemSachMuon;
        private Guna.UI2.WinForms.Guna2Button btnXemSach;
    }
}