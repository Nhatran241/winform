﻿namespace DuLich.GUI.QuanLyDoan
{
    partial class SearchDoan
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
            this.cb_tour = new System.Windows.Forms.ComboBox();
            this.tb_search = new System.Windows.Forms.TextBox();
            this.tv_combo = new System.Windows.Forms.Label();
            this.tv_searchbox = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.datepickbatdau = new System.Windows.Forms.DateTimePicker();
            this.datepickketthuc = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_khach = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_nhanvien = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cb_tour
            // 
            this.cb_tour.FormattingEnabled = true;
            this.cb_tour.Location = new System.Drawing.Point(38, 17);
            this.cb_tour.Name = "cb_tour";
            this.cb_tour.Size = new System.Drawing.Size(113, 21);
            this.cb_tour.TabIndex = 0;
            this.cb_tour.SelectedIndexChanged += new System.EventHandler(this.cb_search_SelectedIndexChanged);
            // 
            // tb_search
            // 
            this.tb_search.Location = new System.Drawing.Point(218, 18);
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(173, 20);
            this.tb_search.TabIndex = 1;
            this.tb_search.TextChanged += new System.EventHandler(this.tb_search_TextChanged);
            // 
            // tv_combo
            // 
            this.tv_combo.AutoSize = true;
            this.tv_combo.Location = new System.Drawing.Point(3, 20);
            this.tv_combo.Name = "tv_combo";
            this.tv_combo.Size = new System.Drawing.Size(29, 13);
            this.tv_combo.TabIndex = 2;
            this.tv_combo.Text = "Tour";
            // 
            // tv_searchbox
            // 
            this.tv_searchbox.AutoSize = true;
            this.tv_searchbox.Location = new System.Drawing.Point(157, 21);
            this.tv_searchbox.Name = "tv_searchbox";
            this.tv_searchbox.Size = new System.Drawing.Size(55, 13);
            this.tv_searchbox.TabIndex = 3;
            this.tv_searchbox.Text = "Tên Đoàn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ngày Bắt Đầu";
            // 
            // datepickbatdau
            // 
            this.datepickbatdau.Location = new System.Drawing.Point(115, 51);
            this.datepickbatdau.Name = "datepickbatdau";
            this.datepickbatdau.Size = new System.Drawing.Size(200, 20);
            this.datepickbatdau.TabIndex = 5;
            this.datepickbatdau.ValueChanged += new System.EventHandler(this.datepickbatdau_ValueChanged);
            // 
            // datepickketthuc
            // 
            this.datepickketthuc.Location = new System.Drawing.Point(443, 51);
            this.datepickketthuc.Name = "datepickketthuc";
            this.datepickketthuc.Size = new System.Drawing.Size(200, 20);
            this.datepickketthuc.TabIndex = 7;
            this.datepickketthuc.ValueChanged += new System.EventHandler(this.datepickketthuc_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(345, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ngày Kết Thúc";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(410, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Có Khách";
            // 
            // cb_khach
            // 
            this.cb_khach.FormattingEnabled = true;
            this.cb_khach.Location = new System.Drawing.Point(470, 17);
            this.cb_khach.Name = "cb_khach";
            this.cb_khach.Size = new System.Drawing.Size(117, 21);
            this.cb_khach.TabIndex = 8;
            this.cb_khach.SelectedIndexChanged += new System.EventHandler(this.cb_khach_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(607, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Có Nhân Viên";
            // 
            // cb_nhanvien
            // 
            this.cb_nhanvien.FormattingEnabled = true;
            this.cb_nhanvien.Location = new System.Drawing.Point(689, 17);
            this.cb_nhanvien.Name = "cb_nhanvien";
            this.cb_nhanvien.Size = new System.Drawing.Size(117, 21);
            this.cb_nhanvien.TabIndex = 10;
            this.cb_nhanvien.SelectedIndexChanged += new System.EventHandler(this.cb_nhanvien_SelectedIndexChanged);
            // 
            // SearchDoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_nhanvien);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_khach);
            this.Controls.Add(this.datepickketthuc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.datepickbatdau);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tv_searchbox);
            this.Controls.Add(this.tv_combo);
            this.Controls.Add(this.tb_search);
            this.Controls.Add(this.cb_tour);
            this.Name = "SearchDoan";
            this.Size = new System.Drawing.Size(809, 90);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_tour;
        private System.Windows.Forms.TextBox tb_search;
        private System.Windows.Forms.Label tv_combo;
        private System.Windows.Forms.Label tv_searchbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datepickbatdau;
        private System.Windows.Forms.DateTimePicker datepickketthuc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_khach;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_nhanvien;
    }
}