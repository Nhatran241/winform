using System;

namespace DuLich.GUI.QuanLyChiPhi
{
    partial class ChiTietChiPhi
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
            this.tv_maphancong = new System.Windows.Forms.Label();
            this.tv_nhiemvu = new System.Windows.Forms.Label();
            this.tv_nhanvien = new System.Windows.Forms.Label();
            this.tb_maphancong = new System.Windows.Forms.TextBox();
            this.tb_nhiemvu = new System.Windows.Forms.TextBox();
            this.btn_luu = new System.Windows.Forms.Button();
            this.btn_huy = new System.Windows.Forms.Button();
            this.combobox_nhanvien = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tv_maphancong
            // 
            this.tv_maphancong.AutoSize = true;
            this.tv_maphancong.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_maphancong.Location = new System.Drawing.Point(17, 19);
            this.tv_maphancong.Name = "tv_maphancong";
            this.tv_maphancong.Size = new System.Drawing.Size(136, 24);
            this.tv_maphancong.TabIndex = 0;
            this.tv_maphancong.Text = "Mã Phân Công";
            // 
            // tv_nhiemvu
            // 
            this.tv_nhiemvu.AutoSize = true;
            this.tv_nhiemvu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_nhiemvu.Location = new System.Drawing.Point(17, 91);
            this.tv_nhiemvu.Name = "tv_nhiemvu";
            this.tv_nhiemvu.Size = new System.Drawing.Size(95, 24);
            this.tv_nhiemvu.TabIndex = 1;
            this.tv_nhiemvu.Text = "Nhiệm Vụ";
            // 
            // tv_nhanvien
            // 
            this.tv_nhanvien.AutoSize = true;
            this.tv_nhanvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_nhanvien.Location = new System.Drawing.Point(17, 172);
            this.tv_nhanvien.Name = "tv_nhanvien";
            this.tv_nhanvien.Size = new System.Drawing.Size(100, 24);
            this.tv_nhanvien.TabIndex = 2;
            this.tv_nhanvien.Text = "Nhân Viên";
            // 
            // tb_maphancong
            // 
            this.tb_maphancong.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_maphancong.Location = new System.Drawing.Point(191, 16);
            this.tb_maphancong.Name = "tb_maphancong";
            this.tb_maphancong.Size = new System.Drawing.Size(181, 29);
            this.tb_maphancong.TabIndex = 4;
            this.tb_maphancong.TextChanged += new System.EventHandler(this.tb_maphancong_TextChanged);
            // 
            // tb_nhiemvu
            // 
            this.tb_nhiemvu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_nhiemvu.Location = new System.Drawing.Point(191, 88);
            this.tb_nhiemvu.Name = "tb_nhiemvu";
            this.tb_nhiemvu.Size = new System.Drawing.Size(181, 29);
            this.tb_nhiemvu.TabIndex = 5;
            this.tb_nhiemvu.TextChanged += new System.EventHandler(this.tb_nhiemvu_TextChanged);
            // 
            // btn_luu
            // 
            this.btn_luu.Location = new System.Drawing.Point(408, 19);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(50, 40);
            this.btn_luu.TabIndex = 8;
            this.btn_luu.Text = "Luu";
            this.btn_luu.UseVisualStyleBackColor = true;
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // btn_huy
            // 
            this.btn_huy.Location = new System.Drawing.Point(408, 91);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(50, 40);
            this.btn_huy.TabIndex = 9;
            this.btn_huy.Text = "Huy";
            this.btn_huy.UseVisualStyleBackColor = true;
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // combobox_nhanvien
            // 
            this.combobox_nhanvien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_nhanvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combobox_nhanvien.FormattingEnabled = true;
            this.combobox_nhanvien.Location = new System.Drawing.Point(175, 169);
            this.combobox_nhanvien.Name = "combobox_nhanvien";
            this.combobox_nhanvien.Size = new System.Drawing.Size(218, 32);
            this.combobox_nhanvien.TabIndex = 13;
            this.combobox_nhanvien.SelectedIndexChanged += new System.EventHandler(this.comboxnhanvien_SelectedIndexChanged);

            // 
            // ChiTietPhanCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.combobox_nhanvien);
            this.Controls.Add(this.btn_huy);
            this.Controls.Add(this.btn_luu);
            this.Controls.Add(this.tb_nhiemvu);
            this.Controls.Add(this.tb_maphancong);
            this.Controls.Add(this.tv_nhanvien);
            this.Controls.Add(this.tv_nhiemvu);
            this.Controls.Add(this.tv_maphancong);
            this.Name = "ChiTietPhanCong";
            this.Size = new System.Drawing.Size(487, 315);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label tv_maphancong;
        private System.Windows.Forms.Label tv_nhiemvu;
        private System.Windows.Forms.Label tv_nhanvien;
        private System.Windows.Forms.TextBox tb_maphancong;
        private System.Windows.Forms.TextBox tb_nhiemvu;
        private System.Windows.Forms.Button btn_luu;
        private System.Windows.Forms.Button btn_huy;
        private System.Windows.Forms.ComboBox combobox_nhanvien;
    }
}
