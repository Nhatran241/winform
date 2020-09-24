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
            this.SuspendLayout();
            // 
            // listview_gia
            // 
            this.listview_gia.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.giatri,
            this.ngaybatdau,
            this.ngayketthuc});
            this.listview_gia.HideSelection = false;
            this.listview_gia.Location = new System.Drawing.Point(0, 0);
            this.listview_gia.Name = "listview_gia";
            this.listview_gia.Size = new System.Drawing.Size(487, 315);
            this.listview_gia.TabIndex = 0;
            this.listview_gia.UseCompatibleStateImageBehavior = false;
            this.listview_gia.View = System.Windows.Forms.View.Details;
            this.listview_gia.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // giatri
            // 
            this.giatri.Text = "Gia Tri";
            this.ngaybatdau.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // DanhSachGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
    }
}
