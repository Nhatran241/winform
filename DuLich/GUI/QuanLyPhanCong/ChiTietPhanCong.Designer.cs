namespace DuLich.GUI.QuanLyPhanCong
{
    partial class ChiTietPhanCong
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cb_nhiemvu = new System.Windows.Forms.ComboBox();
            this.combobox_nhanvien = new System.Windows.Forms.ComboBox();
            this.btn_huy = new System.Windows.Forms.Button();
            this.btn_luu = new System.Windows.Forms.Button();
            this.tb_maphancong = new System.Windows.Forms.TextBox();
            this.tv_nhanvien = new System.Windows.Forms.Label();
            this.tv_nhiemvu = new System.Windows.Forms.Label();
            this.tv_maphancong = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cb_nhiemvu
            // 
            this.cb_nhiemvu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_nhiemvu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_nhiemvu.FormattingEnabled = true;
            this.cb_nhiemvu.Location = new System.Drawing.Point(172, 89);
            this.cb_nhiemvu.Name = "cb_nhiemvu";
            this.cb_nhiemvu.Size = new System.Drawing.Size(218, 32);
            this.cb_nhiemvu.TabIndex = 22;
            this.cb_nhiemvu.SelectedIndexChanged += new System.EventHandler(this.cb_nhiemvu_SelectedIndexChanged_1);
            // 
            // combobox_nhanvien
            // 
            this.combobox_nhanvien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_nhanvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combobox_nhanvien.FormattingEnabled = true;
            this.combobox_nhanvien.Location = new System.Drawing.Point(172, 167);
            this.combobox_nhanvien.Name = "combobox_nhanvien";
            this.combobox_nhanvien.Size = new System.Drawing.Size(218, 32);
            this.combobox_nhanvien.TabIndex = 21;
            this.combobox_nhanvien.SelectedIndexChanged += new System.EventHandler(this.combobox_nhanvien_SelectedIndexChanged);
            // 
            // btn_huy
            // 
            this.btn_huy.Location = new System.Drawing.Point(405, 89);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(50, 40);
            this.btn_huy.TabIndex = 20;
            this.btn_huy.Text = "Huy";
            this.btn_huy.UseVisualStyleBackColor = true;
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // btn_luu
            // 
            this.btn_luu.Image = global::DuLich.Properties.Resources.diskette;
            this.btn_luu.Location = new System.Drawing.Point(405, 6);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(50, 50);
            this.btn_luu.TabIndex = 19;
            this.btn_luu.UseVisualStyleBackColor = true;
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // tb_maphancong
            // 
            this.tb_maphancong.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_maphancong.Location = new System.Drawing.Point(188, 14);
            this.tb_maphancong.Name = "tb_maphancong";
            this.tb_maphancong.Size = new System.Drawing.Size(181, 29);
            this.tb_maphancong.TabIndex = 18;
            // 
            // tv_nhanvien
            // 
            this.tv_nhanvien.AutoSize = true;
            this.tv_nhanvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_nhanvien.Location = new System.Drawing.Point(14, 170);
            this.tv_nhanvien.Name = "tv_nhanvien";
            this.tv_nhanvien.Size = new System.Drawing.Size(100, 24);
            this.tv_nhanvien.TabIndex = 17;
            this.tv_nhanvien.Text = "Nhân Viên";
            // 
            // tv_nhiemvu
            // 
            this.tv_nhiemvu.AutoSize = true;
            this.tv_nhiemvu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_nhiemvu.Location = new System.Drawing.Point(14, 89);
            this.tv_nhiemvu.Name = "tv_nhiemvu";
            this.tv_nhiemvu.Size = new System.Drawing.Size(95, 24);
            this.tv_nhiemvu.TabIndex = 16;
            this.tv_nhiemvu.Text = "Nhiệm Vụ";
            // 
            // tv_maphancong
            // 
            this.tv_maphancong.AutoSize = true;
            this.tv_maphancong.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_maphancong.Location = new System.Drawing.Point(14, 17);
            this.tv_maphancong.Name = "tv_maphancong";
            this.tv_maphancong.Size = new System.Drawing.Size(136, 24);
            this.tv_maphancong.TabIndex = 15;
            this.tv_maphancong.Text = "Mã Phân Công";
            // 
            // FromPhanCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 226);
            this.Controls.Add(this.cb_nhiemvu);
            this.Controls.Add(this.combobox_nhanvien);
            this.Controls.Add(this.btn_huy);
            this.Controls.Add(this.btn_luu);
            this.Controls.Add(this.tb_maphancong);
            this.Controls.Add(this.tv_nhanvien);
            this.Controls.Add(this.tv_nhiemvu);
            this.Controls.Add(this.tv_maphancong);
            this.Name = "FromPhanCong";
            this.Text = "PhanCong";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_nhiemvu;
        private System.Windows.Forms.ComboBox combobox_nhanvien;
        private System.Windows.Forms.Button btn_huy;
        private System.Windows.Forms.Button btn_luu;
        private System.Windows.Forms.TextBox tb_maphancong;
        private System.Windows.Forms.Label tv_nhanvien;
        private System.Windows.Forms.Label tv_nhiemvu;
        private System.Windows.Forms.Label tv_maphancong;
    }
}