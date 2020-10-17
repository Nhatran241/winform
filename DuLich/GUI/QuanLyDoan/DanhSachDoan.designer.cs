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
            this.btn_them_doan = new System.Windows.Forms.Button();
            this.listview_doan = new System.Windows.Forms.ListView();
            this.giatri = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ngaybatdau = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ngayketthuc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_sua_doan = new System.Windows.Forms.Button();
            this.btn_xoa_doan = new System.Windows.Forms.Button();
            this.themKhach = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_them_doan
            // 
            this.btn_them_doan.Location = new System.Drawing.Point(3, 2);
            this.btn_them_doan.Name = "btn_them_doan";
            this.btn_them_doan.Size = new System.Drawing.Size(75, 23);
            this.btn_them_doan.TabIndex = 5;
            this.btn_them_doan.Text = "Them";
            this.btn_them_doan.UseVisualStyleBackColor = true;
            this.btn_them_doan.Click += new System.EventHandler(this.btn_them_doan_Click_1);
            // 
            // listview_doan
            // 
            this.listview_doan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.giatri,
            this.ngaybatdau,
            this.ngayketthuc});
            this.listview_doan.FullRowSelect = true;
            this.listview_doan.HideSelection = false;
            this.listview_doan.Location = new System.Drawing.Point(0, 31);
            this.listview_doan.Name = "listview_doan";
            this.listview_doan.Size = new System.Drawing.Size(487, 282);
            this.listview_doan.TabIndex = 4;
            this.listview_doan.UseCompatibleStateImageBehavior = false;
            this.listview_doan.View = System.Windows.Forms.View.Details;
            this.listview_doan.SelectedIndexChanged += new System.EventHandler(this.listview_doan_SelectedIndexChanged);
            // 
            // giatri
            // 
            this.giatri.Text = "Ten Doan";
            this.giatri.Width = 187;
            // 
            // ngaybatdau
            // 
            this.ngaybatdau.Text = "Ngay Bat Dau";
            this.ngaybatdau.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ngaybatdau.Width = 150;
            // 
            // ngayketthuc
            // 
            this.ngayketthuc.Text = "Ngay Ket Thuc";
            this.ngayketthuc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ngayketthuc.Width = 150;
            // 
            // btn_sua_doan
            // 
            this.btn_sua_doan.Location = new System.Drawing.Point(135, 3);
            this.btn_sua_doan.Name = "btn_sua_doan";
            this.btn_sua_doan.Size = new System.Drawing.Size(75, 23);
            this.btn_sua_doan.TabIndex = 6;
            this.btn_sua_doan.Text = "Sua";
            this.btn_sua_doan.UseVisualStyleBackColor = true;
            this.btn_sua_doan.Click += new System.EventHandler(this.btn_sua_doan_Click);
            // 
            // btn_xoa_doan
            // 
            this.btn_xoa_doan.Location = new System.Drawing.Point(384, 3);
            this.btn_xoa_doan.Name = "btn_xoa_doan";
            this.btn_xoa_doan.Size = new System.Drawing.Size(75, 23);
            this.btn_xoa_doan.TabIndex = 7;
            this.btn_xoa_doan.Text = "Xoa";
            this.btn_xoa_doan.UseVisualStyleBackColor = true;
            this.btn_xoa_doan.Click += new System.EventHandler(this.btn_xoa_doan_Click);
            // 
            // themKhach
            // 
            this.themKhach.Location = new System.Drawing.Point(248, 3);
            this.themKhach.Name = "themKhach";
            this.themKhach.Size = new System.Drawing.Size(102, 23);
            this.themKhach.TabIndex = 8;
            this.themKhach.Text = "Them Khach";
            this.themKhach.UseVisualStyleBackColor = true;
            this.themKhach.Click += new System.EventHandler(this.themKhach_Click);
            // 
            // DanhSachDoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.themKhach);
            this.Controls.Add(this.btn_xoa_doan);
            this.Controls.Add(this.btn_sua_doan);
            this.Controls.Add(this.btn_them_doan);
            this.Controls.Add(this.listview_doan);
            this.Name = "DanhSachDoan";
            this.Size = new System.Drawing.Size(487, 315);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_them_doan;
        private System.Windows.Forms.ListView listview_doan;
        private System.Windows.Forms.ColumnHeader giatri;
        private System.Windows.Forms.ColumnHeader ngaybatdau;
        private System.Windows.Forms.ColumnHeader ngayketthuc;
        private System.Windows.Forms.Button btn_sua_doan;
        private System.Windows.Forms.Button btn_xoa_doan;
        private System.Windows.Forms.Button themKhach;
    }
}
