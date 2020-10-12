using System;

namespace DuLich.View.QuanLyDiaDiem
{
    partial class QuanLyDiaDiem
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
            this.list_diadiem = new System.Windows.Forms.ListView();
            this.ma_diadiem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ten_diadiem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_sua_diadiem = new System.Windows.Forms.Button();
            this.btn_xoa_diadiem = new System.Windows.Forms.Button();
            this.btn_them_diadiem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // list_diadiem
            // 
            this.list_diadiem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ma_diadiem,
            this.ten_diadiem});
            this.list_diadiem.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_diadiem.FullRowSelect = true;
            this.list_diadiem.GridLines = true;
            this.list_diadiem.HideSelection = false;
            this.list_diadiem.Location = new System.Drawing.Point(0, 38);
            this.list_diadiem.Name = "list_diadiem";
            this.list_diadiem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.list_diadiem.Size = new System.Drawing.Size(509, 474);
            this.list_diadiem.TabIndex = 0;
            this.list_diadiem.TileSize = new System.Drawing.Size(10, 20);
            this.list_diadiem.UseCompatibleStateImageBehavior = false;
            this.list_diadiem.View = System.Windows.Forms.View.Details;
            this.list_diadiem.SelectedIndexChanged += new System.EventHandler(this.ListDiaDiem_OnDiaDiemSelect);
            // 
            // ma_diadiem
            // 
            this.ma_diadiem.Text = "Mã Địa Điểm";
            this.ma_diadiem.Width = 85;
            // 
            // ten_diadiem
            // 
            this.ten_diadiem.Text = "Tên Địa Điểm";
            this.ten_diadiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ten_diadiem.Width = 240;
            // 
            // btn_sua_diadiem
            // 
            this.btn_sua_diadiem.Location = new System.Drawing.Point(209, 9);
            this.btn_sua_diadiem.Name = "btn_sua_diadiem";
            this.btn_sua_diadiem.Size = new System.Drawing.Size(75, 23);
            this.btn_sua_diadiem.TabIndex = 6;
            this.btn_sua_diadiem.Text = "Sua";
            this.btn_sua_diadiem.UseVisualStyleBackColor = true;
            this.btn_sua_diadiem.Visible = false;
            this.btn_sua_diadiem.Click += new System.EventHandler(this.btn_sua_diadiem_Click);
            // 
            // btn_xoa_diadiem
            // 
            this.btn_xoa_diadiem.Location = new System.Drawing.Point(420, 9);
            this.btn_xoa_diadiem.Name = "btn_xoa_diadiem";
            this.btn_xoa_diadiem.Size = new System.Drawing.Size(75, 23);
            this.btn_xoa_diadiem.TabIndex = 5;
            this.btn_xoa_diadiem.Text = "Xoa";
            this.btn_xoa_diadiem.UseVisualStyleBackColor = true;
            this.btn_xoa_diadiem.Visible = false;
            this.btn_xoa_diadiem.Click += new System.EventHandler(this.btn_xoa_diadiem_Click);
            // 
            // btn_them_diadiem
            // 
            this.btn_them_diadiem.Location = new System.Drawing.Point(14, 9);
            this.btn_them_diadiem.Name = "btn_them_diadiem";
            this.btn_them_diadiem.Size = new System.Drawing.Size(75, 23);
            this.btn_them_diadiem.TabIndex = 4;
            this.btn_them_diadiem.Text = "Them";
            this.btn_them_diadiem.UseVisualStyleBackColor = true;
            this.btn_them_diadiem.Click += new System.EventHandler(this.btn_them_diadiem_Click);
            // 
            // QuanLyDiaDiem
            // 
            this.Controls.Add(this.btn_sua_diadiem);
            this.Controls.Add(this.btn_xoa_diadiem);
            this.Controls.Add(this.btn_them_diadiem);
            this.Controls.Add(this.list_diadiem);
            this.Name = "QuanLyDiaDiem";
            this.Size = new System.Drawing.Size(512, 512);
            this.ResumeLayout(false);

        }


        #endregion
        private System.Windows.Forms.ListView list_diadiem;
        private System.Windows.Forms.ColumnHeader ma_diadiem;
        private System.Windows.Forms.ColumnHeader ten_diadiem;
        private System.Windows.Forms.Button btn_sua_diadiem;
        private System.Windows.Forms.Button btn_xoa_diadiem;
        private System.Windows.Forms.Button btn_them_diadiem;
    }
}
