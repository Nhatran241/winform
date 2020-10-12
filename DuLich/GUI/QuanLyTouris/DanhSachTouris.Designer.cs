using System;

namespace DuLich.View.QuanLyTouris
{
    partial class DanhSachTouris
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
            this.list_touris = new System.Windows.Forms.ListView();
            this.ma_tour = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ten_tour = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.loai_tou = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // list_touris
            // 
            this.list_touris.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ma_tour,
            this.ten_tour,
            this.loai_tou});
            this.list_touris.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_touris.FullRowSelect = true;
            this.list_touris.GridLines = true;
            this.list_touris.HideSelection = false;
            this.list_touris.Location = new System.Drawing.Point(0, 0);
            this.list_touris.Name = "list_touris";
            this.list_touris.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.list_touris.Size = new System.Drawing.Size(512, 512);
            this.list_touris.TabIndex = 0;
            this.list_touris.TileSize = new System.Drawing.Size(10, 20);
            this.list_touris.UseCompatibleStateImageBehavior = false;
            this.list_touris.View = System.Windows.Forms.View.Details;
            this.list_touris.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // ma_tour
            // 
            this.ma_tour.Text = "Mã Tour";
            this.ma_tour.Width = 85;
            // 
            // ten_tour
            // 
            this.ten_tour.Text = "Tên Tour";
            this.ten_tour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ten_tour.Width = 240;
            // 
            // loai_tou
            // 
            this.loai_tou.Text = "Loại Tour";
            this.loai_tou.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.loai_tou.Width = 182;
            // 
            // DanhSachTouris
            // 
            this.Controls.Add(this.list_touris);
            this.Name = "DanhSachTouris";
            this.Size = new System.Drawing.Size(512, 512);
            this.ResumeLayout(false);

        }

        private void OnTourisSelected(object sender, EventArgs e)
        {
        }

        #endregion
        private System.Windows.Forms.BindingSource tourisBindingSource;
        private System.Windows.Forms.ListView list_touris;
        private System.Windows.Forms.ColumnHeader ma_tour;
        private System.Windows.Forms.ColumnHeader ten_tour;
        private System.Windows.Forms.ColumnHeader loai_tour;
        private System.Windows.Forms.ColumnHeader loai_tou;
    }
}
