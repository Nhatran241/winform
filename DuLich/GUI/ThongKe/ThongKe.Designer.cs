using DuLich.BUS;
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label3 = new System.Windows.Forms.Label();
            this.chart_thongkedoanhthu = new System.Windows.Forms.DataVisualization.Charting.Chart();
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
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.datepicker_den_doanhthutour = new System.Windows.Forms.DateTimePicker();
            this.datepicker_tu_doanhthutour = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.datepicker_den_khachdoan = new System.Windows.Forms.DateTimePicker();
            this.datepicker_tu_khacdoan = new System.Windows.Forms.DateTimePicker();
            this.chart_soluongkhachvadoan = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label10 = new System.Windows.Forms.Label();
            this.tourisBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.giaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tourisBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart_thongkedoanhthu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_soluongkhachvadoan)).BeginInit();
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
            this.label3.Size = new System.Drawing.Size(355, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Thống Kê Doanh Thu / Chi Phí / Lợi Nhuân theo Tour";
            // 
            // chart_thongkedoanhthu
            // 
            chartArea5.AxisX.Title = "Tour";
            chartArea5.AxisY.Title = "Triệu (VNĐ)";
            chartArea5.AxisY2.Title = "Doanh Thu (Triệu VNĐ)";
            chartArea5.Name = "ChartArea1";
            this.chart_thongkedoanhthu.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chart_thongkedoanhthu.Legends.Add(legend5);
            this.chart_thongkedoanhthu.Location = new System.Drawing.Point(20, 473);
            this.chart_thongkedoanhthu.Name = "chart_thongkedoanhthu";
            series11.ChartArea = "ChartArea1";
            series11.Legend = "Legend1";
            series11.Name = "Doanh Thu";
            series12.ChartArea = "ChartArea1";
            series12.Legend = "Legend1";
            series12.Name = "Chi Phí";
            series13.ChartArea = "ChartArea1";
            series13.Legend = "Legend1";
            series13.Name = "Lợi Nhuận";
            this.chart_thongkedoanhthu.Series.Add(series11);
            this.chart_thongkedoanhthu.Series.Add(series12);
            this.chart_thongkedoanhthu.Series.Add(series13);
            this.chart_thongkedoanhthu.Size = new System.Drawing.Size(732, 413);
            this.chart_thongkedoanhthu.TabIndex = 3;
            this.chart_thongkedoanhthu.Text = "chart1";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(612, 607);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Đến";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(612, 561);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Từ";
            // 
            // datepicker_den_doanhthutour
            // 
            this.datepicker_den_doanhthutour.Location = new System.Drawing.Point(651, 601);
            this.datepicker_den_doanhthutour.Name = "datepicker_den_doanhthutour";
            this.datepicker_den_doanhthutour.Size = new System.Drawing.Size(87, 20);
            this.datepicker_den_doanhthutour.TabIndex = 16;
            this.datepicker_den_doanhthutour.ValueChanged += new System.EventHandler(this.datepicker_den_doanhthutour_ValueChanged);
            // 
            // datepicker_tu_doanhthutour
            // 
            this.datepicker_tu_doanhthutour.Location = new System.Drawing.Point(651, 555);
            this.datepicker_tu_doanhthutour.Name = "datepicker_tu_doanhthutour";
            this.datepicker_tu_doanhthutour.Size = new System.Drawing.Size(87, 20);
            this.datepicker_tu_doanhthutour.TabIndex = 15;
            this.datepicker_tu_doanhthutour.ValueChanged += new System.EventHandler(this.datepicker_tu_doanhthutour_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(618, 1090);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Đến";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(625, 1043);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Từ";
            // 
            // datepicker_den_khachdoan
            // 
            this.datepicker_den_khachdoan.Location = new System.Drawing.Point(651, 1083);
            this.datepicker_den_khachdoan.Name = "datepicker_den_khachdoan";
            this.datepicker_den_khachdoan.Size = new System.Drawing.Size(87, 20);
            this.datepicker_den_khachdoan.TabIndex = 22;
            this.datepicker_den_khachdoan.ValueChanged += new System.EventHandler(this.datepicker_den_khachdoan_ValueChanged);
            // 
            // datepicker_tu_khacdoan
            // 
            this.datepicker_tu_khacdoan.Location = new System.Drawing.Point(651, 1037);
            this.datepicker_tu_khacdoan.Name = "datepicker_tu_khacdoan";
            this.datepicker_tu_khacdoan.Size = new System.Drawing.Size(87, 20);
            this.datepicker_tu_khacdoan.TabIndex = 21;
            this.datepicker_tu_khacdoan.ValueChanged += new System.EventHandler(this.datepicker_tu_khacdoan_ValueChanged);
            // 
            // chart_soluongkhachvadoan
            // 
            chartArea6.AxisX.Title = "Tour";
            chartArea6.AxisY.Title = "Số lượng";
            chartArea6.AxisY2.Title = "Doanh Thu (Triệu VNĐ)";
            chartArea6.Name = "ChartArea1";
            this.chart_soluongkhachvadoan.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chart_soluongkhachvadoan.Legends.Add(legend6);
            this.chart_soluongkhachvadoan.Location = new System.Drawing.Point(20, 955);
            this.chart_soluongkhachvadoan.Name = "chart_soluongkhachvadoan";
            series14.ChartArea = "ChartArea1";
            series14.Legend = "Legend1";
            series14.Name = "Khách";
            series15.ChartArea = "ChartArea1";
            series15.Legend = "Legend1";
            series15.Name = "Đoàn";
            this.chart_soluongkhachvadoan.Series.Add(series14);
            this.chart_soluongkhachvadoan.Series.Add(series15);
            this.chart_soluongkhachvadoan.Size = new System.Drawing.Size(732, 413);
            this.chart_soluongkhachvadoan.TabIndex = 20;
            this.chart_soluongkhachvadoan.Text = "chart1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(17, 921);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(490, 18);
            this.label10.TabIndex = 19;
            this.label10.Text = "Thống Kê Số Lượng Khách Tham Quan Tour và Số Đoàn Khai Thác Tour";
            // 
            // tourisBindingSource1
            // 
            this.tourisBindingSource1.DataSource = typeof(Tour);
            // 
            // giaBindingSource
            // 
            this.giaBindingSource.DataSource = typeof(Gia);
            // 
            // tourisBindingSource
            // 
            this.tourisBindingSource.DataSource = typeof(Tour);
            // 
            // ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.datepicker_den_khachdoan);
            this.Controls.Add(this.datepicker_tu_khacdoan);
            this.Controls.Add(this.chart_soluongkhachvadoan);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.datepicker_den_doanhthutour);
            this.Controls.Add(this.datepicker_tu_doanhthutour);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listview_solanditour);
            this.Controls.Add(this.chart_thongkedoanhthu);
            this.Controls.Add(this.label3);
            this.Name = "ThongKe";
            this.Size = new System.Drawing.Size(767, 1500);
            this.Load += new System.EventHandler(this.ThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart_thongkedoanhthu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_soluongkhachvadoan)).EndInit();
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
        private Label label6;
        private Label label7;
        private DateTimePicker datepicker_den_doanhthutour;
        private DateTimePicker datepicker_tu_doanhthutour;
        private Label label8;
        private Label label9;
        private DateTimePicker datepicker_den_khachdoan;
        private DateTimePicker datepicker_tu_khacdoan;
        private Chart chart_soluongkhachvadoan;
        private Label label10;
    }
}
