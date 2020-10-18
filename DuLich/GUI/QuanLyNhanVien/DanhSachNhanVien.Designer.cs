namespace DuLich.GUI.QuanLyNhanVien
{
    partial class DanhSachNhanVien
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
            this.btn_them_nhanvien = new System.Windows.Forms.Button();
            this.listview_nhanvien = new System.Windows.Forms.ListView();
            this.Ten = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DiaChi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SoDienThoai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.scmnd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_xoa_nhanvien = new System.Windows.Forms.Button();
            this.btn_sua_nhanvien = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_them_nhanvien
            // 
            this.btn_them_nhanvien.Location = new System.Drawing.Point(3, 2);
            this.btn_them_nhanvien.Name = "btn_them_nhanvien";
            this.btn_them_nhanvien.Size = new System.Drawing.Size(75, 23);
            this.btn_them_nhanvien.TabIndex = 9;
            this.btn_them_nhanvien.Text = "Thêm";
            this.btn_them_nhanvien.UseVisualStyleBackColor = true;
            this.btn_them_nhanvien.Click += new System.EventHandler(this.btn_them_nhanvien_Click);
            // 
            // listview_nhanvien
            // 
            this.listview_nhanvien.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Ten,
            this.DiaChi,
            this.SoDienThoai,
            this.scmnd});
            this.listview_nhanvien.FullRowSelect = true;
            this.listview_nhanvien.HideSelection = false;
            this.listview_nhanvien.Location = new System.Drawing.Point(0, 31);
            this.listview_nhanvien.Name = "listview_nhanvien";
            this.listview_nhanvien.Size = new System.Drawing.Size(487, 282);
            this.listview_nhanvien.TabIndex = 8;
            this.listview_nhanvien.UseCompatibleStateImageBehavior = false;
            this.listview_nhanvien.View = System.Windows.Forms.View.Details;
            this.listview_nhanvien.SelectedIndexChanged += new System.EventHandler(this.listview_nhanvien_SelectedIndexChanged);
            // 
            // Ten
            // 
            this.Ten.Text = "Ten";
            this.Ten.Width = 118;
            // 
            // DiaChi
            // 
            this.DiaChi.Text = "Dia chi";
            this.DiaChi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DiaChi.Width = 142;
            // 
            // SoDienThoai
            // 
            this.SoDienThoai.Text = "So dien thoai";
            this.SoDienThoai.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SoDienThoai.Width = 138;
            // 
            // scmnd
            // 
            this.scmnd.Text = "So CMND";
            this.scmnd.Width = 104;
            // 
            // btn_xoa_nhanvien
            // 
            this.btn_xoa_nhanvien.Location = new System.Drawing.Point(354, 3);
            this.btn_xoa_nhanvien.Name = "btn_xoa_nhanvien";
            this.btn_xoa_nhanvien.Size = new System.Drawing.Size(75, 23);
            this.btn_xoa_nhanvien.TabIndex = 11;
            this.btn_xoa_nhanvien.Text = "Xóa";
            this.btn_xoa_nhanvien.UseVisualStyleBackColor = true;
            this.btn_xoa_nhanvien.Click += new System.EventHandler(this.btn_xoa_nhanvien_Click);
            // 
            // btn_sua_nhanvien
            // 
            this.btn_sua_nhanvien.Location = new System.Drawing.Point(175, 3);
            this.btn_sua_nhanvien.Name = "btn_sua_nhanvien";
            this.btn_sua_nhanvien.Size = new System.Drawing.Size(75, 23);
            this.btn_sua_nhanvien.TabIndex = 10;
            this.btn_sua_nhanvien.Text = "Sửa";
            this.btn_sua_nhanvien.UseVisualStyleBackColor = true;
            this.btn_sua_nhanvien.Click += new System.EventHandler(this.btn_sua_nhanvien_Click);
            // 
            // DanhSachNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_them_nhanvien);
            this.Controls.Add(this.listview_nhanvien);
            this.Controls.Add(this.btn_xoa_nhanvien);
            this.Controls.Add(this.btn_sua_nhanvien);
            this.Name = "DanhSachNhanVien";
            this.Size = new System.Drawing.Size(487, 315);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_them_nhanvien;
        private System.Windows.Forms.ListView listview_nhanvien;
        private System.Windows.Forms.ColumnHeader Ten;
        private System.Windows.Forms.ColumnHeader DiaChi;
        private System.Windows.Forms.ColumnHeader SoDienThoai;
        private System.Windows.Forms.Button btn_xoa_nhanvien;
        private System.Windows.Forms.Button btn_sua_nhanvien;
        private System.Windows.Forms.ColumnHeader scmnd;
    }
}
