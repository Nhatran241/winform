using System.Windows.Forms;

namespace DuLich.View.QuanLyTouris
{
    partial class DanhSachDiaDiem : UserControl
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
            this.listbox_chondiadiem = new System.Windows.Forms.ListBox();
            this.listbox_ketqua = new System.Windows.Forms.ListBox();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_luu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listbox_chondiadiem
            // 
            this.listbox_chondiadiem.FormattingEnabled = true;
            this.listbox_chondiadiem.Location = new System.Drawing.Point(0, 77);
            this.listbox_chondiadiem.Name = "listbox_chondiadiem";
            this.listbox_chondiadiem.Size = new System.Drawing.Size(200, 238);
            this.listbox_chondiadiem.TabIndex = 0;
            this.listbox_chondiadiem.SelectedIndexChanged += new System.EventHandler(this.listbox_chondiadiem_SelectedIndexChanged);
            // 
            // listbox_ketqua
            // 
            this.listbox_ketqua.FormattingEnabled = true;
            this.listbox_ketqua.Location = new System.Drawing.Point(284, 77);
            this.listbox_ketqua.Name = "listbox_ketqua";
            this.listbox_ketqua.Size = new System.Drawing.Size(200, 238);
            this.listbox_ketqua.TabIndex = 1;
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(217, 160);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(324, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Dia Diem Den";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tat Ca Dia Diem";
            // 
            // btn_luu
            // 
            this.btn_luu.Location = new System.Drawing.Point(217, 237);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(50, 40);
            this.btn_luu.TabIndex = 0;
            this.btn_luu.Text = "Lưu";
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // DanhSachDiaDiem
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
            this.Name = "DanhSachDiaDiem";
            this.Size = new System.Drawing.Size(487, 315);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox listbox_chondiadiem;
        private ListBox listbox_ketqua;
        private Button btn_xoa;
        private Button btn_them;
        private Label label1;
        private Label label2;
        private Button btn_luu;
    }
}
