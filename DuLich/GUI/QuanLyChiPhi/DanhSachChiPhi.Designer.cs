namespace DuLich.GUI.QuanLyChiPhi
{
    partial class DanhSachChiPhi
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
            this.btn_them_doan = new System.Windows.Forms.Button();
            this.listview_doan = new System.Windows.Forms.ListView();
            this.tv_tenchiphi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tv_loaichiphi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tv_gia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tv_ghichu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_xoa_doan = new System.Windows.Forms.Button();
            this.btn_sua_doan = new System.Windows.Forms.Button();
            this.combobox_nhanvien = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_them_doan
            // 
            this.btn_them_doan.Location = new System.Drawing.Point(507, 13);
            this.btn_them_doan.Name = "btn_them_doan";
            this.btn_them_doan.Size = new System.Drawing.Size(75, 23);
            this.btn_them_doan.TabIndex = 9;
            this.btn_them_doan.Text = "Them";
            this.btn_them_doan.UseVisualStyleBackColor = true;
            this.btn_them_doan.Click += new System.EventHandler(this.btn_them_doan_Click);
            // 
            // listview_doan
            // 
            this.listview_doan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.tv_tenchiphi,
            this.tv_loaichiphi,
            this.tv_gia,
            this.tv_ghichu});
            this.listview_doan.FullRowSelect = true;
            this.listview_doan.HideSelection = false;
            this.listview_doan.Location = new System.Drawing.Point(3, 98);
            this.listview_doan.Name = "listview_doan";
            this.listview_doan.Size = new System.Drawing.Size(579, 282);
            this.listview_doan.TabIndex = 8;
            this.listview_doan.UseCompatibleStateImageBehavior = false;
            this.listview_doan.View = System.Windows.Forms.View.Details;
            this.listview_doan.SelectedIndexChanged += new System.EventHandler(this.listview_doan_SelectedIndexChanged);
            // 
            // tv_tenchiphi
            // 
            this.tv_tenchiphi.Text = "Tên Chi Phí";
            this.tv_tenchiphi.Width = 118;
            // 
            // tv_loaichiphi
            // 
            this.tv_loaichiphi.Text = "Loại";
            this.tv_loaichiphi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tv_loaichiphi.Width = 142;
            // 
            // tv_gia
            // 
            this.tv_gia.Text = "Giá";
            this.tv_gia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tv_gia.Width = 138;
            // 
            // tv_ghichu
            // 
            this.tv_ghichu.Text = "Ghi Chú";
            this.tv_ghichu.Width = 104;
            // 
            // btn_xoa_doan
            // 
            this.btn_xoa_doan.Location = new System.Drawing.Point(507, 71);
            this.btn_xoa_doan.Name = "btn_xoa_doan";
            this.btn_xoa_doan.Size = new System.Drawing.Size(75, 23);
            this.btn_xoa_doan.TabIndex = 11;
            this.btn_xoa_doan.Text = "Xoa";
            this.btn_xoa_doan.UseVisualStyleBackColor = true;
            this.btn_xoa_doan.Click += new System.EventHandler(this.btn_xoa_doan_Click);
            // 
            // btn_sua_doan
            // 
            this.btn_sua_doan.Location = new System.Drawing.Point(507, 42);
            this.btn_sua_doan.Name = "btn_sua_doan";
            this.btn_sua_doan.Size = new System.Drawing.Size(75, 23);
            this.btn_sua_doan.TabIndex = 10;
            this.btn_sua_doan.Text = "Sua";
            this.btn_sua_doan.UseVisualStyleBackColor = true;
            this.btn_sua_doan.Click += new System.EventHandler(this.btn_sua_doan_Click);
            // 
            // combobox_nhanvien
            // 
            this.combobox_nhanvien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_nhanvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combobox_nhanvien.FormattingEnabled = true;
            this.combobox_nhanvien.Location = new System.Drawing.Point(165, 60);
            this.combobox_nhanvien.Name = "combobox_nhanvien";
            this.combobox_nhanvien.Size = new System.Drawing.Size(218, 32);
            this.combobox_nhanvien.TabIndex = 14;
            // 
            // DanhSachChiPhi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.combobox_nhanvien);
            this.Controls.Add(this.btn_them_doan);
            this.Controls.Add(this.listview_doan);
            this.Controls.Add(this.btn_xoa_doan);
            this.Controls.Add(this.btn_sua_doan);
            this.Name = "DanhSachChiPhi";
            this.Size = new System.Drawing.Size(585, 383);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_them_doan;
        private System.Windows.Forms.ListView listview_doan;
        private System.Windows.Forms.ColumnHeader tv_tenchiphi;
        private System.Windows.Forms.ColumnHeader tv_loaichiphi;
        private System.Windows.Forms.ColumnHeader tv_gia;
        private System.Windows.Forms.Button btn_xoa_doan;
        private System.Windows.Forms.Button btn_sua_doan;
        private System.Windows.Forms.ColumnHeader tv_ghichu;
        private System.Windows.Forms.ComboBox combobox_nhanvien;
    }
}
