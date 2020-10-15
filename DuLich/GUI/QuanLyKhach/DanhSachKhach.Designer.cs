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
            this.btn_them_doan = new System.Windows.Forms.Button();
            this.listview_doan = new System.Windows.Forms.ListView();
            this.Ten = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DiaChi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SoDienThoai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_xoa_doan = new System.Windows.Forms.Button();
            this.btn_sua_doan = new System.Windows.Forms.Button();
            this.scmnd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btn_them_doan
            // 
            this.btn_them_doan.Location = new System.Drawing.Point(3, 2);
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
            this.Ten,
            this.DiaChi,
            this.SoDienThoai,
            this.scmnd});
            this.listview_doan.FullRowSelect = true;
            this.listview_doan.HideSelection = false;
            this.listview_doan.Location = new System.Drawing.Point(0, 31);
            this.listview_doan.Name = "listview_doan";
            this.listview_doan.Size = new System.Drawing.Size(487, 282);
            this.listview_doan.TabIndex = 8;
            this.listview_doan.UseCompatibleStateImageBehavior = false;
            this.listview_doan.View = System.Windows.Forms.View.Details;
            this.listview_doan.SelectedIndexChanged += new System.EventHandler(this.listview_doan_SelectedIndexChanged);
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
            // btn_xoa_doan
            // 
            this.btn_xoa_doan.Location = new System.Drawing.Point(354, 3);
            this.btn_xoa_doan.Name = "btn_xoa_doan";
            this.btn_xoa_doan.Size = new System.Drawing.Size(75, 23);
            this.btn_xoa_doan.TabIndex = 11;
            this.btn_xoa_doan.Text = "Xoa";
            this.btn_xoa_doan.UseVisualStyleBackColor = true;
            this.btn_xoa_doan.Click += new System.EventHandler(this.btn_xoa_doan_Click);
            // 
            // btn_sua_doan
            // 
            this.btn_sua_doan.Location = new System.Drawing.Point(175, 3);
            this.btn_sua_doan.Name = "btn_sua_doan";
            this.btn_sua_doan.Size = new System.Drawing.Size(75, 23);
            this.btn_sua_doan.TabIndex = 10;
            this.btn_sua_doan.Text = "Sua";
            this.btn_sua_doan.UseVisualStyleBackColor = true;
            this.btn_sua_doan.Click += new System.EventHandler(this.btn_sua_doan_Click);
            // 
            // scmnd
            // 
            this.scmnd.Text = "So CMND";
            this.scmnd.Width = 104;
            // 
            // DanhSachKhach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_them_doan);
            this.Controls.Add(this.listview_doan);
            this.Controls.Add(this.btn_xoa_doan);
            this.Controls.Add(this.btn_sua_doan);
            this.Name = "DanhSachKhach";
            this.Size = new System.Drawing.Size(487, 315);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_them_doan;
        private System.Windows.Forms.ListView listview_doan;
        private System.Windows.Forms.ColumnHeader Ten;
        private System.Windows.Forms.ColumnHeader DiaChi;
        private System.Windows.Forms.ColumnHeader SoDienThoai;
        private System.Windows.Forms.Button btn_xoa_doan;
        private System.Windows.Forms.Button btn_sua_doan;
        private System.Windows.Forms.ColumnHeader scmnd;
    }
}
