using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DuLich.GUI.ThongKe
{
    partial class ThongKe : UserControl
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
            this.label3 = new System.Windows.Forms.Label();
            this.chart_thongkedoanhthu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cb_nam = new System.Windows.Forms.ComboBox();
            this.listview_solanditour = new System.Windows.Forms.ListView();
            this.ma_nhanvien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ten_nhanvien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.solan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tourisBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.giaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tourisBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart_thongkedoanhthu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tourisBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.giaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tourisBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 439);
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
            this.chart_thongkedoanhthu.Location = new System.Drawing.Point(20, 473);
            this.chart_thongkedoanhthu.Name = "chart_thongkedoanhthu";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Doanh Số";
            this.chart_thongkedoanhthu.Series.Add(series1);
            this.chart_thongkedoanhthu.Size = new System.Drawing.Size(732, 400);
            this.chart_thongkedoanhthu.TabIndex = 3;
            this.chart_thongkedoanhthu.Text = "chart1";
            // 
            // cb_nam
            // 
            this.cb_nam.FormattingEnabled = true;
            this.cb_nam.Location = new System.Drawing.Point(631, 440);
            this.cb_nam.Name = "cb_nam";
            this.cb_nam.Size = new System.Drawing.Size(121, 21);
            this.cb_nam.TabIndex = 7;
            this.cb_nam.SelectedIndexChanged += new System.EventHandler(this.cb_nam_SelectedIndexChanged);
            // 
            // listview_solanditour
            // 
            this.listview_solanditour.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ma_nhanvien,
            this.ten_nhanvien,
            this.solan});
            this.listview_solanditour.HideSelection = false;
            this.listview_solanditour.Location = new System.Drawing.Point(20, 101);
            this.listview_solanditour.Name = "listview_solanditour";
            this.listview_solanditour.Size = new System.Drawing.Size(458, 302);
            this.listview_solanditour.TabIndex = 8;
            this.listview_solanditour.UseCompatibleStateImageBehavior = false;
            this.listview_solanditour.View = System.Windows.Forms.View.Details;
            // 
            // ma_nhanvien
            // 
            this.ma_nhanvien.Text = "Mã Nhân Viên";
            this.ma_nhanvien.Width = 150;
            // 
            // ten_nhanvien
            // 
            this.ten_nhanvien.Text = "Tên Nhân Viên";
            this.ten_nhanvien.Width = 150;
            // 
            // solan
            // 
            this.solan.Text = "Số Lần Đi Tour";
            this.solan.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "Thống Kê Số Lần Đi Tour Của Nhân Viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(318, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 29);
            this.label2.TabIndex = 10;
            this.label2.Text = "Thống Kê";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(552, 113);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 11;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(552, 156);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 12;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(493, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Từ ngày";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(493, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Đến ngày";
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
            // ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listview_solanditour);
            this.Controls.Add(this.cb_nam);
            this.Controls.Add(this.chart_thongkedoanhthu);
            this.Controls.Add(this.label3);
            this.Name = "ThongKe";
            this.Size = new System.Drawing.Size(767, 1000);
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
        private Label label3;
        private Series series1; 
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_thongkedoanhthu;
        private BindingSource tourisBindingSource1;
        private ComboBox cb_nam;
        private ListView listview_solanditour;
        private ColumnHeader ma_nhanvien;
        private ColumnHeader ten_nhanvien;
        private ColumnHeader solan;
        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label4;
        private Label label5;
    }
}
