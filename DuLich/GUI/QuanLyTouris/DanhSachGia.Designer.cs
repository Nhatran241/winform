using System;
using System.Windows.Forms;

namespace DuLich.View.QuanLyTouris
{
    partial class DanhSachGia : UserControl
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
            this.btn_them_gia = new System.Windows.Forms.Button();
            this.btn_xoa_gia = new System.Windows.Forms.Button();
            this.btn_sua_gia = new System.Windows.Forms.Button();
            this.dataGridViewTour = new System.Windows.Forms.DataGridView();
            this.maGiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giaTriDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thoiGianBatDauDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thoiGianKetThucDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tourisBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.giaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tourisBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_them_gia
            // 
            this.btn_them_gia.Location = new System.Drawing.Point(17, 4);
            this.btn_them_gia.Name = "btn_them_gia";
            this.btn_them_gia.Size = new System.Drawing.Size(75, 23);
            this.btn_them_gia.TabIndex = 1;
            this.btn_them_gia.Text = "Them";
            this.btn_them_gia.UseVisualStyleBackColor = true;
            this.btn_them_gia.Click += new System.EventHandler(this.btn_them_gia_Click);
            // 
            // btn_xoa_gia
            // 
            this.btn_xoa_gia.Location = new System.Drawing.Point(689, 4);
            this.btn_xoa_gia.Name = "btn_xoa_gia";
            this.btn_xoa_gia.Size = new System.Drawing.Size(75, 23);
            this.btn_xoa_gia.TabIndex = 2;
            this.btn_xoa_gia.Text = "Xoa";
            this.btn_xoa_gia.UseVisualStyleBackColor = true;
            this.btn_xoa_gia.Visible = false;
            this.btn_xoa_gia.Click += new System.EventHandler(this.btn_xoa_gia_Click);
            // 
            // btn_sua_gia
            // 
            this.btn_sua_gia.Location = new System.Drawing.Point(138, 4);
            this.btn_sua_gia.Name = "btn_sua_gia";
            this.btn_sua_gia.Size = new System.Drawing.Size(75, 23);
            this.btn_sua_gia.TabIndex = 3;
            this.btn_sua_gia.Text = "Sua";
            this.btn_sua_gia.UseVisualStyleBackColor = true;
            this.btn_sua_gia.Visible = false;
            this.btn_sua_gia.Click += new System.EventHandler(this.btn_sua_gia_Click);
            // 
            // dataGridViewTour
            // 
            this.dataGridViewTour.AllowUserToAddRows = false;
            this.dataGridViewTour.AllowUserToDeleteRows = false;
            this.dataGridViewTour.AutoGenerateColumns = false;
            this.dataGridViewTour.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTour.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewTour.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTour.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maGiaDataGridViewTextBoxColumn,
            this.giaTriDataGridViewTextBoxColumn,
            this.thoiGianBatDauDataGridViewTextBoxColumn,
            this.thoiGianKetThucDataGridViewTextBoxColumn});
            this.dataGridViewTour.DataSource = this.giaBindingSource;
            this.dataGridViewTour.Location = new System.Drawing.Point(0, 33);
            this.dataGridViewTour.MultiSelect = false;
            this.dataGridViewTour.Name = "dataGridViewTour";
            this.dataGridViewTour.ReadOnly = true;
            this.dataGridViewTour.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTour.Size = new System.Drawing.Size(767, 378);
            this.dataGridViewTour.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GiaDoubleClick);
            this.dataGridViewTour.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GiaClick);
            // 
            // maGiaDataGridViewTextBoxColumn
            // 
            this.maGiaDataGridViewTextBoxColumn.DataPropertyName = "MaGia";
            this.maGiaDataGridViewTextBoxColumn.HeaderText = "MaGia";
            this.maGiaDataGridViewTextBoxColumn.Name = "maGiaDataGridViewTextBoxColumn";
            this.maGiaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // giaTriDataGridViewTextBoxColumn
            // 
            this.giaTriDataGridViewTextBoxColumn.DataPropertyName = "GiaTri";
            this.giaTriDataGridViewTextBoxColumn.HeaderText = "GiaTri";
            this.giaTriDataGridViewTextBoxColumn.Name = "giaTriDataGridViewTextBoxColumn";
            this.giaTriDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // thoiGianBatDauDataGridViewTextBoxColumn
            // 
            this.thoiGianBatDauDataGridViewTextBoxColumn.DataPropertyName = "ThoiGianBatDau";
            this.thoiGianBatDauDataGridViewTextBoxColumn.HeaderText = "ThoiGianBatDau";
            this.thoiGianBatDauDataGridViewTextBoxColumn.Name = "thoiGianBatDauDataGridViewTextBoxColumn";
            this.thoiGianBatDauDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // thoiGianKetThucDataGridViewTextBoxColumn
            // 
            this.thoiGianKetThucDataGridViewTextBoxColumn.DataPropertyName = "ThoiGianKetThuc";
            this.thoiGianKetThucDataGridViewTextBoxColumn.HeaderText = "ThoiGianKetThuc";
            this.thoiGianKetThucDataGridViewTextBoxColumn.Name = "thoiGianKetThucDataGridViewTextBoxColumn";
            this.thoiGianKetThucDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // giaBindingSource
            // 
            this.giaBindingSource.DataSource = typeof(DuLich.Model.Entity.Gia);
            // 
            // tourisBindingSource
            // 
            this.tourisBindingSource.DataSource = typeof(DuLich.Entity.Tour);
            // 
            // DanhSachGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewTour);
            this.Controls.Add(this.btn_sua_gia);
            this.Controls.Add(this.btn_xoa_gia);
            this.Controls.Add(this.btn_them_gia);
            this.Name = "DanhSachGia";
            this.Size = new System.Drawing.Size(767, 414);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.giaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tourisBindingSource)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion
        private Button btn_them_gia;
        private Button btn_xoa_gia;
        private Button btn_sua_gia;
        private DataGridView dataGridViewTour;
        private BindingSource tourisBindingSource;
        private DataGridViewTextBoxColumn maGiaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn giaTriDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn thoiGianBatDauDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn thoiGianKetThucDataGridViewTextBoxColumn;
        private BindingSource giaBindingSource;
    }
}
