using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DuLich.View.QuanLyTouris
{
    partial class ThongKeTheoTour : UserControl
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chart_thongkedoanhthu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tv_tongdoan = new System.Windows.Forms.Label();
            this.tv_tongkhach = new System.Windows.Forms.Label();
            this.cb_nam = new System.Windows.Forms.ComboBox();
            this.tourisBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.giaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tourisBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart_thongkedoanhthu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tourisBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.giaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tourisBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tổng Số Đoàn Tham Quan :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tổng Số Khách Tham Quan :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Thống Kê Doanh Thu Theo Tháng";
            // 
            // chart_thongkedoanhthu
            // 
            chartArea1.AxisX.Title = "Tháng";
            chartArea1.AxisY.Title = "Doanh Thu ( Triệu VNĐ )";
            chartArea1.AxisY2.Title = "Doanh Thu (Triệu VNĐ)";
            chartArea1.Name = "ChartArea1";
            this.chart_thongkedoanhthu.ChartAreas.Add(chartArea1);
            this.chart_thongkedoanhthu.Location = new System.Drawing.Point(20, 158);
            this.chart_thongkedoanhthu.Name = "chart_thongkedoanhthu";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Doanh Số";
            this.chart_thongkedoanhthu.Series.Add(series1);
            this.chart_thongkedoanhthu.Size = new System.Drawing.Size(725, 400);
            this.chart_thongkedoanhthu.TabIndex = 3;
            this.chart_thongkedoanhthu.Text = "chart1";
            // 
            // tv_tongdoan
            // 
            this.tv_tongdoan.AutoSize = true;
            this.tv_tongdoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_tongdoan.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tv_tongdoan.Location = new System.Drawing.Point(233, 21);
            this.tv_tongdoan.Name = "tv_tongdoan";
            this.tv_tongdoan.Size = new System.Drawing.Size(16, 18);
            this.tv_tongdoan.TabIndex = 5;
            this.tv_tongdoan.Text = "0";
            // 
            // tv_tongkhach
            // 
            this.tv_tongkhach.AutoSize = true;
            this.tv_tongkhach.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_tongkhach.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tv_tongkhach.Location = new System.Drawing.Point(233, 55);
            this.tv_tongkhach.Name = "tv_tongkhach";
            this.tv_tongkhach.Size = new System.Drawing.Size(16, 18);
            this.tv_tongkhach.TabIndex = 6;
            this.tv_tongkhach.Text = "0";
            // 
            // cb_nam
            // 
            this.cb_nam.FormattingEnabled = true;
            this.cb_nam.Location = new System.Drawing.Point(624, 124);
            this.cb_nam.Name = "cb_nam";
            this.cb_nam.Size = new System.Drawing.Size(121, 21);
            this.cb_nam.TabIndex = 7;
            this.cb_nam.SelectedIndexChanged += new System.EventHandler(this.cb_nam_SelectedIndexChanged);
            // 
            // tourisBindingSource1
            // 
            this.tourisBindingSource1.DataSource = typeof(DuLich.Entity.Tour);
            // 
            // giaBindingSource
            // 
            this.giaBindingSource.DataSource = typeof(DuLich.Model.Entity.Gia);
            // 
            // tourisBindingSource
            // 
            this.tourisBindingSource.DataSource = typeof(DuLich.Entity.Tour);
            // 
            // ThongKeTheoTour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cb_nam);
            this.Controls.Add(this.tv_tongkhach);
            this.Controls.Add(this.tv_tongdoan);
            this.Controls.Add(this.chart_thongkedoanhthu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ThongKeTheoTour";
            this.Size = new System.Drawing.Size(760, 650);
            ((System.ComponentModel.ISupportInitialize)(this.chart_thongkedoanhthu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tourisBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.giaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tourisBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private BindingSource tourisBindingSource;
        private BindingSource giaBindingSource;
        private Label label1;
        private Label label2;
        private Label label3;
        private Series series1; 
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_thongkedoanhthu;
        private BindingSource tourisBindingSource1;
        private Label tv_tongdoan;
        private Label tv_tongkhach;
        private ComboBox cb_nam;
    }
}
