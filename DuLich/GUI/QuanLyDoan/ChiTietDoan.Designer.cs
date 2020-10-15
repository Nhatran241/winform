namespace DuLich.GUI.QuanLyDoan
{
    partial class ChiTietDoan
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
            this.btn_huy = new System.Windows.Forms.Button();
            this.btn_luu = new System.Windows.Forms.Button();
            this.datepicker_ketthuc = new System.Windows.Forms.DateTimePicker();
            this.datepicker_batdau = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tv_ngaybatdau = new System.Windows.Forms.Label();
            this.tv_tour = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_huy
            // 
            this.btn_huy.Location = new System.Drawing.Point(414, 83);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(50, 40);
            this.btn_huy.TabIndex = 16;
            this.btn_huy.Text = "Huy";
            this.btn_huy.UseVisualStyleBackColor = true;
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // btn_luu
            // 
            this.btn_luu.Location = new System.Drawing.Point(414, 11);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(50, 40);
            this.btn_luu.TabIndex = 15;
            this.btn_luu.Text = "Luu";
            this.btn_luu.UseVisualStyleBackColor = true;
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // datepicker_ketthuc
            // 
            this.datepicker_ketthuc.Location = new System.Drawing.Point(198, 173);
            this.datepicker_ketthuc.Name = "datepicker_ketthuc";
            this.datepicker_ketthuc.Size = new System.Drawing.Size(181, 20);
            this.datepicker_ketthuc.TabIndex = 14;
            // 
            // datepicker_batdau
            // 
            this.datepicker_batdau.Location = new System.Drawing.Point(198, 91);
            this.datepicker_batdau.Name = "datepicker_batdau";
            this.datepicker_batdau.Size = new System.Drawing.Size(181, 20);
            this.datepicker_batdau.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "Ngay Bat Dau";
            // 
            // tv_ngaybatdau
            // 
            this.tv_ngaybatdau.AutoSize = true;
            this.tv_ngaybatdau.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_ngaybatdau.Location = new System.Drawing.Point(24, 87);
            this.tv_ngaybatdau.Name = "tv_ngaybatdau";
            this.tv_ngaybatdau.Size = new System.Drawing.Size(124, 24);
            this.tv_ngaybatdau.TabIndex = 11;
            this.tv_ngaybatdau.Text = "Ngay Bat Dau";
            // 
            // tv_tour
            // 
            this.tv_tour.AutoSize = true;
            this.tv_tour.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_tour.Location = new System.Drawing.Point(23, 27);
            this.tv_tour.Name = "tv_tour";
            this.tv_tour.Size = new System.Drawing.Size(50, 24);
            this.tv_tour.TabIndex = 10;
            this.tv_tour.Text = "Tour";
            this.tv_tour.Click += new System.EventHandler(this.tv_giatri_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(198, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(181, 21);
            this.comboBox1.TabIndex = 17;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ChiTietDoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btn_huy);
            this.Controls.Add(this.btn_luu);
            this.Controls.Add(this.datepicker_ketthuc);
            this.Controls.Add(this.datepicker_batdau);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tv_ngaybatdau);
            this.Controls.Add(this.tv_tour);
            this.Name = "ChiTietDoan";
            this.Size = new System.Drawing.Size(487, 282);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_huy;
        private System.Windows.Forms.Button btn_luu;
        private System.Windows.Forms.DateTimePicker datepicker_ketthuc;
        private System.Windows.Forms.DateTimePicker datepicker_batdau;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label tv_ngaybatdau;
        private System.Windows.Forms.Label tv_tour;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
