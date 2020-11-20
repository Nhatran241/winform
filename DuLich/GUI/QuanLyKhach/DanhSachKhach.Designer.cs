﻿using DuLich.BUS;

namespace DuLich.GUI.QuanLyKhach
{
    partial class DanhSachKhach
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
            this.components = new System.ComponentModel.Container();
            this.btn_them_doan = new System.Windows.Forms.Button();
            this.btn_xoa_doan = new System.Windows.Forms.Button();
            this.btn_sua_doan = new System.Windows.Forms.Button();
            this.dataGridviewKhach = new System.Windows.Forms.DataGridView();
            this.khachBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchKhach1 = new DuLich.GUI.QuanLyKhach.SearchKhach();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.khachBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridviewKhach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.khachBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.khachBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_them_doan
            // 
            this.btn_them_doan.Font = new System.Drawing.Font("Arial Narrow", 15F);
            this.btn_them_doan.Location = new System.Drawing.Point(27, 90);
            this.btn_them_doan.Name = "btn_them_doan";
            this.btn_them_doan.Size = new System.Drawing.Size(84, 33);
            this.btn_them_doan.TabIndex = 9;
            this.btn_them_doan.Text = "Thêm";
            this.btn_them_doan.UseVisualStyleBackColor = true;
            this.btn_them_doan.Click += new System.EventHandler(this.btn_them_khach_Click);
            // 
            // btn_xoa_doan
            // 
            this.btn_xoa_doan.Font = new System.Drawing.Font("Arial Narrow", 15F);
            this.btn_xoa_doan.Location = new System.Drawing.Point(693, 90);
            this.btn_xoa_doan.Name = "btn_xoa_doan";
            this.btn_xoa_doan.Size = new System.Drawing.Size(84, 33);
            this.btn_xoa_doan.TabIndex = 11;
            this.btn_xoa_doan.Text = "Xóa";
            this.btn_xoa_doan.UseVisualStyleBackColor = true;
            this.btn_xoa_doan.Click += new System.EventHandler(this.btn_xoa_khach_Click);
            // 
            // btn_sua_doan
            // 
            this.btn_sua_doan.Font = new System.Drawing.Font("Arial Narrow", 15F);
            this.btn_sua_doan.Location = new System.Drawing.Point(358, 90);
            this.btn_sua_doan.Name = "btn_sua_doan";
            this.btn_sua_doan.Size = new System.Drawing.Size(84, 33);
            this.btn_sua_doan.TabIndex = 10;
            this.btn_sua_doan.Text = "Sửa";
            this.btn_sua_doan.UseVisualStyleBackColor = true;
            this.btn_sua_doan.Click += new System.EventHandler(this.btn_sua_khach_Click);
            // 
            // dataGridviewKhach
            // 
            this.dataGridviewKhach.AllowUserToAddRows = false;
            this.dataGridviewKhach.AllowUserToDeleteRows = false;
            this.dataGridviewKhach.AllowUserToOrderColumns = true;
            this.dataGridviewKhach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridviewKhach.AutoGenerateColumns = false;
            this.dataGridviewKhach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridviewKhach.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridviewKhach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridviewKhach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.dataGridviewKhach.DataSource = this.khachBindingSource1;
            this.dataGridviewKhach.Location = new System.Drawing.Point(0, 129);
            this.dataGridviewKhach.MultiSelect = false;
            this.dataGridviewKhach.Name = "dataGridviewKhach";
            this.dataGridviewKhach.ReadOnly = true;
            this.dataGridviewKhach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridviewKhach.Size = new System.Drawing.Size(800, 468);
            this.dataGridviewKhach.TabIndex = 16;
            // 
            // searchKhach1
            // 
            this.searchKhach1.Location = new System.Drawing.Point(0, 0);
            this.searchKhach1.Name = "searchKhach1";
            this.searchKhach1.Size = new System.Drawing.Size(800, 90);
            this.searchKhach1.TabIndex = 17;
            this.searchKhach1.Load += new System.EventHandler(this.searchKhach1_Load);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "KhachId";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã khách";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Ten";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên khách";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "DiaChi";
            this.dataGridViewTextBoxColumn3.HeaderText = "Địa chỉ";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "SoDienThoai";
            this.dataGridViewTextBoxColumn4.HeaderText = "Số điện thoại";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "SoCmnd";
            this.dataGridViewTextBoxColumn5.HeaderText = "Số chứng minh";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "NgaySinh";
            this.dataGridViewTextBoxColumn6.HeaderText = "Ngày sinh";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "GioiTinh";
            this.dataGridViewTextBoxColumn7.HeaderText = "Giới tính";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // khachBindingSource1
            // 
            this.khachBindingSource1.DataSource = typeof(DuLich.BUS.Khach);
            // 
            // DanhSachKhach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.searchKhach1);
            this.Controls.Add(this.dataGridviewKhach);
            this.Controls.Add(this.btn_them_doan);
            this.Controls.Add(this.btn_xoa_doan);
            this.Controls.Add(this.btn_sua_doan);
            this.Name = "DanhSachKhach";
            this.Size = new System.Drawing.Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridviewKhach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.khachBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.khachBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_them_doan;
        private System.Windows.Forms.Button btn_xoa_doan;
        private System.Windows.Forms.Button btn_sua_doan;
        private System.Windows.Forms.DataGridView dataGridviewKhach;
        private System.Windows.Forms.BindingSource khachBindingSource;
        private System.Windows.Forms.BindingSource khachBindingSource1;
        private SearchKhach searchKhach1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    }
}
