using DuLich.Entity;
using DuLich.Model.Entity;
using DuLich.View;
using DuLich.View.QuanLyTouris;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows.Forms;

namespace DuLich
{
    partial class ManHinhChinh
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
            this.panel_main_content = new System.Windows.Forms.Panel();
            this.btn_quanlytour = new System.Windows.Forms.Button();
            this.btn_taotour = new System.Windows.Forms.Button();
            this.tv_quanlytour = new System.Windows.Forms.Label();
            this.btn_quanlydiadiem = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_taodoan = new System.Windows.Forms.Button();
            this.btn_quanlynhanvien = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel_main_content
            // 
            this.panel_main_content.BackColor = System.Drawing.SystemColors.Control;
            this.panel_main_content.Location = new System.Drawing.Point(196, 37);
            this.panel_main_content.Name = "panel_main_content";
            this.panel_main_content.Size = new System.Drawing.Size(800, 600);
            this.panel_main_content.TabIndex = 3;
            // 
            // btn_quanlytour
            // 
            this.btn_quanlytour.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_quanlytour.Location = new System.Drawing.Point(11, 37);
            this.btn_quanlytour.Name = "btn_quanlytour";
            this.btn_quanlytour.Size = new System.Drawing.Size(165, 32);
            this.btn_quanlytour.TabIndex = 5;
            this.btn_quanlytour.Text = "Danh Sách Tour";
            this.btn_quanlytour.UseVisualStyleBackColor = true;
            this.btn_quanlytour.Click += new System.EventHandler(this.btn_quanlytour_Click);
            // 
            // btn_taotour
            // 
            this.btn_taotour.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_taotour.Location = new System.Drawing.Point(12, 75);
            this.btn_taotour.Name = "btn_taotour";
            this.btn_taotour.Size = new System.Drawing.Size(164, 33);
            this.btn_taotour.TabIndex = 6;
            this.btn_taotour.Text = "Tạo Tour";
            this.btn_taotour.UseVisualStyleBackColor = true;
            this.btn_taotour.Click += new System.EventHandler(this.btn_taotour_Click);
            // 
            // tv_quanlytour
            // 
            this.tv_quanlytour.AutoSize = true;
            this.tv_quanlytour.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_quanlytour.Location = new System.Drawing.Point(6, 5);
            this.tv_quanlytour.Name = "tv_quanlytour";
            this.tv_quanlytour.Size = new System.Drawing.Size(170, 29);
            this.tv_quanlytour.TabIndex = 0;
            this.tv_quanlytour.Text = "Quản Lý Tour";
            // 
            // btn_quanlydiadiem
            // 
            this.btn_quanlydiadiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_quanlydiadiem.Location = new System.Drawing.Point(11, 171);
            this.btn_quanlydiadiem.Name = "btn_quanlydiadiem";
            this.btn_quanlydiadiem.Size = new System.Drawing.Size(165, 32);
            this.btn_quanlydiadiem.TabIndex = 7;
            this.btn_quanlydiadiem.Text = "Quản lý địa điểm";
            this.btn_quanlydiadiem.UseVisualStyleBackColor = true;
            this.btn_quanlydiadiem.Click += new System.EventHandler(this.btn_quanlydiadiem_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 239);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 32);
            this.button1.TabIndex = 8;
            this.button1.Text = "Danh sách đoàn";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(10, 336);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(165, 32);
            this.button2.TabIndex = 9;
            this.button2.Text = "Danh sách khách";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_taodoan
            // 
            this.btn_taodoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_taodoan.Location = new System.Drawing.Point(12, 277);
            this.btn_taodoan.Name = "btn_taodoan";
            this.btn_taodoan.Size = new System.Drawing.Size(164, 33);
            this.btn_taodoan.TabIndex = 10;
            this.btn_taodoan.Text = "Tạo Đoàn";
            this.btn_taodoan.UseVisualStyleBackColor = true;
            this.btn_taodoan.Click += new System.EventHandler(this.btn_taodoan_Click);
            // 
            // btn_quanlynhanvien
            // 
            this.btn_quanlynhanvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_quanlynhanvien.Location = new System.Drawing.Point(10, 374);
            this.btn_quanlynhanvien.Name = "btn_quanlynhanvien";
            this.btn_quanlynhanvien.Size = new System.Drawing.Size(165, 32);
            this.btn_quanlynhanvien.TabIndex = 11;
            this.btn_quanlynhanvien.Text = "Quản Lý Nhân Viên";
            this.btn_quanlynhanvien.UseVisualStyleBackColor = true;
            this.btn_quanlynhanvien.Click += new System.EventHandler(this.btn_quanlynhanvien_Click);
            // 
            // ManHinhChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 641);
            this.Controls.Add(this.btn_quanlynhanvien);
            this.Controls.Add(this.btn_taodoan);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_quanlydiadiem);
            this.Controls.Add(this.tv_quanlytour);
            this.Controls.Add(this.btn_taotour);
            this.Controls.Add(this.btn_quanlytour);
            this.Controls.Add(this.panel_main_content);
            this.Name = "ManHinhChinh";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        #endregion
        private System.Windows.Forms.Panel panel_main_content;
        private Button btn_quanlytour;
        private Button btn_taotour;
        private Label tv_quanlytour;
        private Button btn_quanlydiadiem;
        private Button button1;
        private Button button2;
        private Button btn_taodoan;
        private Button btn_quanlynhanvien;
    }
}

