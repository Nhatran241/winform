using System;

namespace DuLich.View.QuanLyDoan
{
    partial class DanhSachDoan
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
            this.list_doan = new System.Windows.Forms.ListView();
            this.ma_doan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ten_doan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ngay_bd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ngay_kt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // list_doan
            // 
            this.list_doan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ma_doan,
            this.ten_doan,
            this.ngay_bd,
            this.ngay_kt});
            this.list_doan.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_doan.FullRowSelect = true;
            this.list_doan.GridLines = true;
            this.list_doan.HideSelection = false;
            this.list_doan.Location = new System.Drawing.Point(0, 0);
            this.list_doan.Name = "list_doan";
            this.list_doan.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.list_doan.Size = new System.Drawing.Size(512, 512);
            this.list_doan.TabIndex = 0;
            this.list_doan.TileSize = new System.Drawing.Size(10, 20);
            this.list_doan.UseCompatibleStateImageBehavior = false;
            this.list_doan.View = System.Windows.Forms.View.Details;
            this.list_doan.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // ma_doan
            // 
            this.ma_doan.Text = "Mã";
            this.ma_doan.Width = 50;
            // 
            // ten_doan
            // 
            this.ten_doan.Text = "Tên Đoàn";
            this.ten_doan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ten_doan.Width = 180;
            // 
            // ngay_bd
            // 
            this.ngay_bd.Text = "Ngày Bắt Đầu";
            this.ngay_bd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ngay_bd.Width = 160;
            // 
            // ngay_kt
            // 
            this.ngay_kt.Text = "Ngày Kết Thúc";
            this.ngay_kt.Width = 120;
            // 
            // DanhSachDoan
            // 
            this.Controls.Add(this.list_doan);
            this.Name = "DanhSachDoan";
            this.Size = new System.Drawing.Size(512, 512);
            this.ResumeLayout(false);

        }

        private void OnTourisSelected(object sender, EventArgs e)
        {
        }

        #endregion
        private System.Windows.Forms.BindingSource tourisBindingSource;
        private System.Windows.Forms.ListView list_doan;
        private System.Windows.Forms.ColumnHeader ma_doan;
        private System.Windows.Forms.ColumnHeader ten_doan;
        private System.Windows.Forms.ColumnHeader loai_tour;
        private System.Windows.Forms.ColumnHeader ngay_bd;
        private System.Windows.Forms.ColumnHeader ngay_kt;
    }
}
