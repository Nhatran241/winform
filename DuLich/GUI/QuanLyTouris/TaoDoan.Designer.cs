namespace DuLich.View.QuanLyTouris
{
    partial class TaoDoan
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
            this.datepicker_ketthuc = new System.Windows.Forms.DateTimePicker();
            this.datepicker_batdau = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tv_ngaybatdau = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // datepicker_ketthuc
            // 
            this.datepicker_ketthuc.Location = new System.Drawing.Point(226, 192);
            this.datepicker_ketthuc.Name = "datepicker_ketthuc";
            this.datepicker_ketthuc.Size = new System.Drawing.Size(181, 20);
            this.datepicker_ketthuc.TabIndex = 11;
            // 
            // datepicker_batdau
            // 
            this.datepicker_batdau.Location = new System.Drawing.Point(226, 110);
            this.datepicker_batdau.Name = "datepicker_batdau";
            this.datepicker_batdau.Size = new System.Drawing.Size(181, 20);
            this.datepicker_batdau.TabIndex = 10;
            this.datepicker_batdau.ValueChanged += new System.EventHandler(this.datepicker_batdau_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ngay Bat Dau";
            // 
            // tv_ngaybatdau
            // 
            this.tv_ngaybatdau.AutoSize = true;
            this.tv_ngaybatdau.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_ngaybatdau.Location = new System.Drawing.Point(52, 106);
            this.tv_ngaybatdau.Name = "tv_ngaybatdau";
            this.tv_ngaybatdau.Size = new System.Drawing.Size(124, 24);
            this.tv_ngaybatdau.TabIndex = 8;
            this.tv_ngaybatdau.Text = "Ngay Bat Dau";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tour";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(226, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(181, 21);
            this.comboBox1.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(100, 252);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Lưu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(282, 252);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Hủy";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // TaoDoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.datepicker_ketthuc);
            this.Controls.Add(this.datepicker_batdau);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tv_ngaybatdau);
            this.Name = "TaoDoan";
            this.Size = new System.Drawing.Size(487, 315);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datepicker_ketthuc;
        private System.Windows.Forms.DateTimePicker datepicker_batdau;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label tv_ngaybatdau;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
