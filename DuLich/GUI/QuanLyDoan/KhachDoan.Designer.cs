namespace DuLich.GUI.QuanLyDoan
{
    partial class KhachDoan
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
            this.btn_luu = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_them = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.listbox_ketqua = new System.Windows.Forms.ListBox();
            this.listbox_chondiadiem = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btn_luu
            // 
            this.btn_luu.Location = new System.Drawing.Point(218, 221);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(50, 40);
            this.btn_luu.TabIndex = 6;
            this.btn_luu.Text = "Lưu";
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tat Ca Khach";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(325, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "Khach cua doan";
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(218, 73);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(50, 40);
            this.btn_them.TabIndex = 10;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(218, 144);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(50, 40);
            this.btn_xoa.TabIndex = 9;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // listbox_ketqua
            // 
            this.listbox_ketqua.FormattingEnabled = true;
            this.listbox_ketqua.Location = new System.Drawing.Point(285, 61);
            this.listbox_ketqua.Name = "listbox_ketqua";
            this.listbox_ketqua.Size = new System.Drawing.Size(200, 238);
            this.listbox_ketqua.TabIndex = 8;
            // 
            // listbox_chondiadiem
            // 
            this.listbox_chondiadiem.FormattingEnabled = true;
            this.listbox_chondiadiem.Location = new System.Drawing.Point(1, 61);
            this.listbox_chondiadiem.Name = "listbox_chondiadiem";
            this.listbox_chondiadiem.Size = new System.Drawing.Size(200, 238);
            this.listbox_chondiadiem.TabIndex = 7;
            // 
            // KhachDoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_luu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.listbox_ketqua);
            this.Controls.Add(this.listbox_chondiadiem);
            this.Name = "KhachDoan";
            this.Size = new System.Drawing.Size(487, 315);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_luu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.ListBox listbox_ketqua;
        private System.Windows.Forms.ListBox listbox_chondiadiem;
    }
}
