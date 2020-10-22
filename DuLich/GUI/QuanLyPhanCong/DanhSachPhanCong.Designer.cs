﻿using System;
using System.Windows.Forms;

namespace DuLich.View.QuanLyPhanCong
{
    partial class DanhSachPhanCong : UserControl
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
            this.listview_phancong = new System.Windows.Forms.ListView();
            this.maphancong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nhanvien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.congviec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_them_phancong = new System.Windows.Forms.Button();
            this.btn_xoa_phancong = new System.Windows.Forms.Button();
            this.btn_sua_phancong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listview_phancong
            // 
            this.listview_phancong.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.maphancong,
            this.nhanvien,
            this.congviec});
            this.listview_phancong.FullRowSelect = true;
            this.listview_phancong.HideSelection = false;
            this.listview_phancong.Location = new System.Drawing.Point(0, 33);
            this.listview_phancong.Name = "listview_phancong";
            this.listview_phancong.Size = new System.Drawing.Size(789, 371);
            this.listview_phancong.TabIndex = 0;
            this.listview_phancong.UseCompatibleStateImageBehavior = false;
            this.listview_phancong.View = System.Windows.Forms.View.Details;
            this.listview_phancong.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // maphancong
            // 
            this.maphancong.Text = "Ma Phan Cong";
            this.maphancong.Width = 187;
            // 
            // nhanvien
            // 
            this.nhanvien.Text = "Nhan Vien";
            this.nhanvien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nhanvien.Width = 150;
            // 
            // congviec
            // 
            this.congviec.Text = "Cong Viec";
            this.congviec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.congviec.Width = 150;
            // 
            // btn_them_phancong
            // 
            this.btn_them_phancong.Location = new System.Drawing.Point(3, 4);
            this.btn_them_phancong.Name = "btn_them_phancong";
            this.btn_them_phancong.Size = new System.Drawing.Size(75, 23);
            this.btn_them_phancong.TabIndex = 1;
            this.btn_them_phancong.Text = "Them";
            this.btn_them_phancong.UseVisualStyleBackColor = true;
            this.btn_them_phancong.Click += new System.EventHandler(this.btn_them_phancong_Click);
            // 
            // btn_xoa_phancong
            // 
            this.btn_xoa_phancong.Location = new System.Drawing.Point(409, 4);
            this.btn_xoa_phancong.Name = "btn_xoa_phancong";
            this.btn_xoa_phancong.Size = new System.Drawing.Size(75, 23);
            this.btn_xoa_phancong.TabIndex = 2;
            this.btn_xoa_phancong.Text = "Xoa";
            this.btn_xoa_phancong.UseVisualStyleBackColor = true;
            this.btn_xoa_phancong.Visible = false;
            this.btn_xoa_phancong.Click += new System.EventHandler(this.btn_xoa_phancong_Click);
            // 
            // btn_sua_phancong
            // 
            this.btn_sua_phancong.Location = new System.Drawing.Point(198, 4);
            this.btn_sua_phancong.Name = "btn_sua_phancong";
            this.btn_sua_phancong.Size = new System.Drawing.Size(75, 23);
            this.btn_sua_phancong.TabIndex = 3;
            this.btn_sua_phancong.Text = "Sua";
            this.btn_sua_phancong.UseVisualStyleBackColor = true;
            this.btn_sua_phancong.Visible = false;
            this.btn_sua_phancong.Click += new System.EventHandler(this.btn_sua_phancong_Click);
            // 
            // DanhSachPhanCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_sua_phancong);
            this.Controls.Add(this.btn_xoa_phancong);
            this.Controls.Add(this.btn_them_phancong);
            this.Controls.Add(this.listview_phancong);
            this.Name = "DanhSachPhanCong";
            this.Size = new System.Drawing.Size(792, 404);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listview_phancong;
        private ColumnHeader maphancong;
        private ColumnHeader nhanvien;
        private ColumnHeader congviec;
        private Button btn_them_phancong;
        private Button btn_xoa_phancong;
        private Button btn_sua_phancong;
    }
}
