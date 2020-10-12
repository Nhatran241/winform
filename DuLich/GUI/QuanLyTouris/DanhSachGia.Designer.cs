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
            this.listview_gia = new System.Windows.Forms.ListView();
            this.giatri = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ngaybatdau = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ngayketthuc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_them_gia = new System.Windows.Forms.Button();
            this.btn_xoa_gia = new System.Windows.Forms.Button();
            this.btn_sua_gia = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listview_gia
            // 
            this.listview_gia.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.giatri,
            this.ngaybatdau,
            this.ngayketthuc});
            this.listview_gia.HideSelection = false;
            this.listview_gia.Location = new System.Drawing.Point(0, 33);
            this.listview_gia.Name = "listview_gia";
            this.listview_gia.Size = new System.Drawing.Size(487, 282);
            this.listview_gia.TabIndex = 0;
            this.listview_gia.FullRowSelect = true;
            this.listview_gia.UseCompatibleStateImageBehavior = false;
            this.listview_gia.View = System.Windows.Forms.View.Details;
            this.listview_gia.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // giatri
            // 
            this.giatri.Text = "Gia Tri";
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
            // btn_them_gia
            // 
            this.btn_them_gia.Location = new System.Drawing.Point(3, 4);
            this.btn_them_gia.Name = "btn_them_gia";
            this.btn_them_gia.Size = new System.Drawing.Size(75, 23);
            this.btn_them_gia.TabIndex = 1;
            this.btn_them_gia.Text = "Them";
            this.btn_them_gia.UseVisualStyleBackColor = true;
            this.btn_them_gia.Click += new System.EventHandler(this.btn_them_gia_Click);
            // 
            // btn_xoa_gia
            // 
            this.btn_xoa_gia.Location = new System.Drawing.Point(409, 4);
            this.btn_xoa_gia.Name = "btn_xoa_gia";
            this.btn_xoa_gia.Size = new System.Drawing.Size(75, 23);
            this.btn_xoa_gia.TabIndex = 2;
            this.btn_xoa_gia.Text = "Xoa";
            this.btn_xoa_gia.Visible = false;
            this.btn_xoa_gia.UseVisualStyleBackColor = true;
            this.btn_xoa_gia.Click += new System.EventHandler(this.btn_xoa_gia_Click);
            // 
            // btn_sua_gia
            // 
            this.btn_sua_gia.Location = new System.Drawing.Point(198, 4);
            this.btn_sua_gia.Name = "btn_sua_gia";
            this.btn_sua_gia.Size = new System.Drawing.Size(75, 23);
            this.btn_sua_gia.TabIndex = 3;
            this.btn_sua_gia.Text = "Sua";
            this.btn_sua_gia.Visible = false;
            this.btn_sua_gia.UseVisualStyleBackColor = true;
            this.btn_sua_gia.Click += new System.EventHandler(this.btn_sua_gia_Click);
            // 
            // DanhSachGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_sua_gia);
            this.Controls.Add(this.btn_xoa_gia);
            this.Controls.Add(this.btn_them_gia);
            this.Controls.Add(this.listview_gia);
            this.Name = "DanhSachGia";
            this.Size = new System.Drawing.Size(487, 315);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listview_gia;
        private ColumnHeader giatri;
        private ColumnHeader ngaybatdau;
        private ColumnHeader ngayketthuc;
        private Button btn_them_gia;
        private Button btn_xoa_gia;
        private Button btn_sua_gia;
    }
}
