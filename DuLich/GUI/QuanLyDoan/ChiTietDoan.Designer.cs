using System;
using System.Windows.Forms;

namespace DuLich.View
{
    partial class ChiTietDoan : UserControl
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
            this.textbox_id = new System.Windows.Forms.TextBox();
            this.combobox_loai = new System.Windows.Forms.ComboBox();
            this.doan_id = new System.Windows.Forms.Label();
            this.doan_name = new System.Windows.Forms.Label();
            this.textbox_name = new System.Windows.Forms.TextBox();
            this.tour_loai = new System.Windows.Forms.Label();
            this.tab_chitiet = new System.Windows.Forms.TabControl();
            this.tab_phancong = new System.Windows.Forms.TabPage();
            this.tab_khach = new System.Windows.Forms.TabPage();
            this.btn_chinhsua = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.datepicker_ketthuc = new System.Windows.Forms.DateTimePicker();
            this.datepicker_batdau = new System.Windows.Forms.DateTimePicker();
            this.tv_ngayketthuc = new System.Windows.Forms.Label();
            this.tv_ngaybatdau = new System.Windows.Forms.Label();
            this.tv_tourkogia = new System.Windows.Forms.Label();
            this.tv_doanhthuuoctinh = new System.Windows.Forms.Label();
            this.tab_chiphi = new System.Windows.Forms.TabPage();
            this.tab_chitiet.SuspendLayout();
            this.SuspendLayout();
            // 
            // textbox_id
            // 
            this.textbox_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_id.Location = new System.Drawing.Point(125, 7);
            this.textbox_id.Name = "textbox_id";
            this.textbox_id.Size = new System.Drawing.Size(218, 29);
            this.textbox_id.TabIndex = 13;
            // 
            // combobox_loai
            // 
            this.combobox_loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_loai.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combobox_loai.FormattingEnabled = true;
            this.combobox_loai.Location = new System.Drawing.Point(125, 118);
            this.combobox_loai.Name = "combobox_loai";
            this.combobox_loai.Size = new System.Drawing.Size(218, 32);
            this.combobox_loai.TabIndex = 12;
            this.combobox_loai.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // doan_id
            // 
            this.doan_id.AutoSize = true;
            this.doan_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doan_id.Location = new System.Drawing.Point(10, 10);
            this.doan_id.Name = "doan_id";
            this.doan_id.Size = new System.Drawing.Size(93, 24);
            this.doan_id.TabIndex = 9;
            this.doan_id.Text = "Mã Đoàn";
            // 
            // doan_name
            // 
            this.doan_name.AutoSize = true;
            this.doan_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doan_name.Location = new System.Drawing.Point(10, 62);
            this.doan_name.Name = "doan_name";
            this.doan_name.Size = new System.Drawing.Size(102, 24);
            this.doan_name.TabIndex = 18;
            this.doan_name.Text = "Tên Đoàn";
            // 
            // textbox_name
            // 
            this.textbox_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_name.Location = new System.Drawing.Point(125, 57);
            this.textbox_name.Name = "textbox_name";
            this.textbox_name.Size = new System.Drawing.Size(218, 29);
            this.textbox_name.TabIndex = 19;
            this.textbox_name.TextChanged += new System.EventHandler(this.textbox_name_TextChanged);
            // 
            // tour_loai
            // 
            this.tour_loai.AutoSize = true;
            this.tour_loai.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tour_loai.Location = new System.Drawing.Point(10, 115);
            this.tour_loai.Name = "tour_loai";
            this.tour_loai.Size = new System.Drawing.Size(54, 24);
            this.tour_loai.TabIndex = 20;
            this.tour_loai.Text = "Tour";
            // 
            // tab_chitiet
            // 
            this.tab_chitiet.Controls.Add(this.tab_phancong);
            this.tab_chitiet.Controls.Add(this.tab_khach);
            this.tab_chitiet.Controls.Add(this.tab_chiphi);
            this.tab_chitiet.Location = new System.Drawing.Point(14, 250);
            this.tab_chitiet.Name = "tab_chitiet";
            this.tab_chitiet.SelectedIndex = 0;
            this.tab_chitiet.Size = new System.Drawing.Size(495, 259);
            this.tab_chitiet.TabIndex = 21;
            this.tab_chitiet.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControl1_Selected);
            // 
            // tab_phancong
            // 
            this.tab_phancong.BackColor = System.Drawing.Color.White;
            this.tab_phancong.Location = new System.Drawing.Point(4, 22);
            this.tab_phancong.Name = "tab_phancong";
            this.tab_phancong.Padding = new System.Windows.Forms.Padding(3);
            this.tab_phancong.Size = new System.Drawing.Size(487, 233);
            this.tab_phancong.TabIndex = 0;
            this.tab_phancong.Text = "Phân Công";
            // 
            // tab_khach
            // 
            this.tab_khach.Location = new System.Drawing.Point(4, 22);
            this.tab_khach.Name = "tab_khach";
            this.tab_khach.Padding = new System.Windows.Forms.Padding(3);
            this.tab_khach.Size = new System.Drawing.Size(487, 233);
            this.tab_khach.TabIndex = 1;
            this.tab_khach.Text = "Khách";
            this.tab_khach.UseVisualStyleBackColor = true;
            // 
            // btn_chinhsua
            // 
            this.btn_chinhsua.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_chinhsua.Location = new System.Drawing.Point(370, 10);
            this.btn_chinhsua.Name = "btn_chinhsua";
            this.btn_chinhsua.Size = new System.Drawing.Size(118, 47);
            this.btn_chinhsua.TabIndex = 22;
            this.btn_chinhsua.Text = "Chỉnh Sửa";
            this.btn_chinhsua.UseVisualStyleBackColor = true;
            this.btn_chinhsua.Click += new System.EventHandler(this.btn_chinhsua_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xoa.Location = new System.Drawing.Point(370, 92);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(118, 47);
            this.btn_xoa.TabIndex = 23;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // datepicker_ketthuc
            // 
            this.datepicker_ketthuc.Location = new System.Drawing.Point(149, 209);
            this.datepicker_ketthuc.Name = "datepicker_ketthuc";
            this.datepicker_ketthuc.Size = new System.Drawing.Size(181, 20);
            this.datepicker_ketthuc.TabIndex = 27;
            // 
            // datepicker_batdau
            // 
            this.datepicker_batdau.Location = new System.Drawing.Point(149, 171);
            this.datepicker_batdau.Name = "datepicker_batdau";
            this.datepicker_batdau.Size = new System.Drawing.Size(181, 20);
            this.datepicker_batdau.TabIndex = 26;
            this.datepicker_batdau.ValueChanged += new System.EventHandler(this.datepicker_batdau_ValueChanged);
            // 
            // tv_ngayketthuc
            // 
            this.tv_ngayketthuc.AutoSize = true;
            this.tv_ngayketthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_ngayketthuc.Location = new System.Drawing.Point(3, 209);
            this.tv_ngayketthuc.Name = "tv_ngayketthuc";
            this.tv_ngayketthuc.Size = new System.Drawing.Size(135, 24);
            this.tv_ngayketthuc.TabIndex = 25;
            this.tv_ngayketthuc.Text = "Ngày Kết Thúc";
            // 
            // tv_ngaybatdau
            // 
            this.tv_ngaybatdau.AutoSize = true;
            this.tv_ngaybatdau.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_ngaybatdau.Location = new System.Drawing.Point(10, 169);
            this.tv_ngaybatdau.Name = "tv_ngaybatdau";
            this.tv_ngaybatdau.Size = new System.Drawing.Size(124, 24);
            this.tv_ngaybatdau.TabIndex = 24;
            this.tv_ngaybatdau.Text = "Ngay Bat Dau";
            // 
            // tv_tourkogia
            // 
            this.tv_tourkogia.AutoSize = true;
            this.tv_tourkogia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_tourkogia.Location = new System.Drawing.Point(10, 185);
            this.tv_tourkogia.Name = "tv_tourkogia";
            this.tv_tourkogia.Size = new System.Drawing.Size(491, 24);
            this.tv_tourkogia.TabIndex = 28;
            this.tv_tourkogia.Text = "Tour này chưa có giá vui lòng thêm giá trước khi tạo đoàn";
            this.tv_tourkogia.Visible = false;
            // 
            // tv_doanhthuuoctinh
            // 
            this.tv_doanhthuuoctinh.AutoSize = true;
            this.tv_doanhthuuoctinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_doanhthuuoctinh.Location = new System.Drawing.Point(268, 232);
            this.tv_doanhthuuoctinh.Name = "tv_doanhthuuoctinh";
            this.tv_doanhthuuoctinh.Size = new System.Drawing.Size(187, 24);
            this.tv_doanhthuuoctinh.TabIndex = 29;
            this.tv_doanhthuuoctinh.Text = "Doanh Thu Ước Tính";
            // 
            // tab_chiphi
            // 
            this.tab_chiphi.Location = new System.Drawing.Point(4, 22);
            this.tab_chiphi.Name = "tab_chiphi";
            this.tab_chiphi.Size = new System.Drawing.Size(487, 233);
            this.tab_chiphi.TabIndex = 2;
            this.tab_chiphi.Text = "Chi Phí";
            this.tab_chiphi.UseVisualStyleBackColor = true;
            // 
            // ChiTietDoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tv_doanhthuuoctinh);
            this.Controls.Add(this.tv_tourkogia);
            this.Controls.Add(this.datepicker_ketthuc);
            this.Controls.Add(this.datepicker_batdau);
            this.Controls.Add(this.tv_ngayketthuc);
            this.Controls.Add(this.tv_ngaybatdau);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_chinhsua);
            this.Controls.Add(this.tab_chitiet);
            this.Controls.Add(this.tour_loai);
            this.Controls.Add(this.textbox_name);
            this.Controls.Add(this.doan_name);
            this.Controls.Add(this.textbox_id);
            this.Controls.Add(this.combobox_loai);
            this.Controls.Add(this.doan_id);
            this.Name = "ChiTietDoan";
            this.Size = new System.Drawing.Size(512, 512);
            this.tab_chitiet.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.TextBox textbox_id;
        private System.Windows.Forms.ComboBox combobox_loai;
        private System.Windows.Forms.Label doan_id;
        private System.Windows.Forms.Label doan_name;
        private System.Windows.Forms.TextBox textbox_name;
        private System.Windows.Forms.Label tour_loai;
        private System.Windows.Forms.TabControl tab_chitiet;
        private System.Windows.Forms.TabPage tab_phancong;
        private System.Windows.Forms.TabPage tab_khach;
        private System.Windows.Forms.Button btn_chinhsua;
        private System.Windows.Forms.Button btn_xoa;
        private DateTimePicker datepicker_ketthuc;
        private DateTimePicker datepicker_batdau;
        private Label tv_ngayketthuc;
        private Label tv_ngaybatdau;
        private Label tv_tourkogia;
        private Label tv_doanhthuuoctinh;
        private TabPage tab_chiphi;
    }
}
