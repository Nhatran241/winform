using System;
using System.Windows.Forms;

namespace DuLich.GUI.QuanLyDoan
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
            this.components = new System.ComponentModel.Container();
            this.dataGridViewDoan = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thoiGianBatDauDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thoiGianKetThucDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchDoan1 = new DuLich.GUI.QuanLyDoan.SearchDoan();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doanBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDoan
            // 
            this.dataGridViewDoan.AllowUserToAddRows = false;
            this.dataGridViewDoan.AllowUserToDeleteRows = false;
            this.dataGridViewDoan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDoan.AutoGenerateColumns = false;
            this.dataGridViewDoan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDoan.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewDoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDoan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.thoiGianBatDauDataGridViewTextBoxColumn,
            this.thoiGianKetThucDataGridViewTextBoxColumn});
            this.dataGridViewDoan.DataSource = this.doanBindingSource;
            this.dataGridViewDoan.Location = new System.Drawing.Point(0, 83);
            this.dataGridViewDoan.MultiSelect = false;
            this.dataGridViewDoan.Name = "dataGridViewDoan";
            this.dataGridViewDoan.ReadOnly = true;
            this.dataGridViewDoan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDoan.Size = new System.Drawing.Size(800, 517);
            this.dataGridViewDoan.TabIndex = 1;
            this.dataGridViewDoan.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnDoanDoubleClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
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
            // doanBindingSource
            // 
            this.doanBindingSource.DataSource = typeof(DuLich.Entity.Doan);
            // 
            // searchDoan1
            // 
            this.searchDoan1.Location = new System.Drawing.Point(0, 0);
            this.searchDoan1.Name = "searchDoan1";
            this.searchDoan1.Size = new System.Drawing.Size(800, 80);
            this.searchDoan1.TabIndex = 2;
            // 
            // DanhSachDoan
            // 
            this.Controls.Add(this.searchDoan1);
            this.Controls.Add(this.dataGridViewDoan);
            this.Name = "DanhSachDoan";
            this.Size = new System.Drawing.Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doanBindingSource)).EndInit();
            this.ResumeLayout(false);

        }




        #endregion
        private System.Windows.Forms.BindingSource tourisBindingSource;
        private System.Windows.Forms.ColumnHeader loai_tour;
        private System.Windows.Forms.DataGridView dataGridViewDoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn thoiGianBatDauDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn thoiGianKetThucDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource doanBindingSource;
        private SearchDoan searchDoan1;
    }
}
