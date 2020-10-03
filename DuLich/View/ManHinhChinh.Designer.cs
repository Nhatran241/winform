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
            this.SuspendLayout();
            // 
            // panel_main_content
            // 
            this.panel_main_content.Location = new System.Drawing.Point(182, 37);
            this.panel_main_content.Name = "panel_main_content";
            this.panel_main_content.Size = new System.Drawing.Size(512, 512);
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
            // QuanLyTouris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 548);
            this.Controls.Add(this.tv_quanlytour);
            this.Controls.Add(this.btn_taotour);
            this.Controls.Add(this.btn_quanlytour);
            this.Controls.Add(this.panel_main_content);
            this.Name = "QuanLyTouris";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        #endregion
        private System.Windows.Forms.Panel panel_main_content;
        private Button btn_quanlytour;
        private Button btn_taotour;
        private Label tv_quanlytour;



    }
}

