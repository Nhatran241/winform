using System.Windows.Forms;

namespace DuLich.View.QuanLyDoan
{
    partial class SelectKhach : UserControl
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
            this.listbox_tatcakhach = new System.Windows.Forms.ListBox();
            this.listbox_khachtrongdoan = new System.Windows.Forms.ListBox();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.tv_khachtrongdoan = new System.Windows.Forms.Label();
            this.tv_tatcakhach = new System.Windows.Forms.Label();
            this.btn_luu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listbox_tatcakhach
            // 
            this.listbox_tatcakhach.FormattingEnabled = true;
            this.listbox_tatcakhach.Location = new System.Drawing.Point(0, 77);
            this.listbox_tatcakhach.Name = "listbox_tatcakhach";
            this.listbox_tatcakhach.Size = new System.Drawing.Size(200, 238);
            this.listbox_tatcakhach.TabIndex = 0;
            this.listbox_tatcakhach.SelectedIndexChanged += new System.EventHandler(this.listbox_chondiadiem_SelectedIndexChanged);
            // 
            // listbox_khachtrongdoan
            // 
            this.listbox_khachtrongdoan.FormattingEnabled = true;
            this.listbox_khachtrongdoan.Location = new System.Drawing.Point(284, 77);
            this.listbox_khachtrongdoan.Name = "listbox_khachtrongdoan";
            this.listbox_khachtrongdoan.Size = new System.Drawing.Size(200, 238);
            this.listbox_khachtrongdoan.TabIndex = 1;
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(217, 135);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(50, 40);
            this.btn_xoa.TabIndex = 2;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(217, 89);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(50, 40);
            this.btn_them.TabIndex = 3;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // tv_khachtrongdoan
            // 
            this.tv_khachtrongdoan.AutoSize = true;
            this.tv_khachtrongdoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_khachtrongdoan.Location = new System.Drawing.Point(324, 31);
            this.tv_khachtrongdoan.Name = "tv_khachtrongdoan";
            this.tv_khachtrongdoan.Size = new System.Drawing.Size(170, 24);
            this.tv_khachtrongdoan.TabIndex = 4;
            this.tv_khachtrongdoan.Text = "Khách Trong Đoàn";
            // 
            // tv_tatcakhach
            // 
            this.tv_tatcakhach.AutoSize = true;
            this.tv_tatcakhach.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_tatcakhach.Location = new System.Drawing.Point(22, 31);
            this.tv_tatcakhach.Name = "tv_tatcakhach";
            this.tv_tatcakhach.Size = new System.Drawing.Size(123, 24);
            this.tv_tatcakhach.TabIndex = 5;
            this.tv_tatcakhach.Text = "Tất Cả Khách";
            // 
            // btn_luu
            // 
            this.btn_luu.Location = new System.Drawing.Point(217, 181);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(50, 40);
            this.btn_luu.TabIndex = 0;
            this.btn_luu.Text = "Lưu";
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // SelectKhach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_luu);
            this.Controls.Add(this.tv_tatcakhach);
            this.Controls.Add(this.tv_khachtrongdoan);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.listbox_khachtrongdoan);
            this.Controls.Add(this.listbox_tatcakhach);
            this.Name = "SelectKhach";
            this.Size = new System.Drawing.Size(487, 315);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox listbox_tatcakhach;
        private ListBox listbox_khachtrongdoan;
        private Button btn_xoa;
        private Button btn_them;
        private Label tv_khachtrongdoan;
        private Label tv_tatcakhach;
        private Button btn_luu;
    }
}
