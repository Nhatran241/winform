using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DuLich.Entity;
using DuLich.Model.Entity;
using System.Windows.Forms.DataVisualization.Charting;

namespace DuLich.GUI.ThongKe
{
    public partial class ThongKe : UserControl
    {
        private List<NhanVien> danhSachNhanVien;
        private List<Tour> danhSachTour;
        private List<Doan> danhSachDoan;
        private List<Khach> danhSachKhach;
        List<String> nam = new List<String>();
        public ThongKe(List<NhanVien> danhSachNhanVien,List<Tour> danhSachTour,List<Doan> danhSachDoan,List<Khach> danhSachKhach)
        {
            InitializeComponent();
            this.danhSachNhanVien = danhSachNhanVien;
            this.danhSachTour = danhSachTour;
            this.danhSachDoan = danhSachDoan;
            this.danhSachKhach = danhSachKhach;
            InitData();
        }

        private void InitThongKeTour()
        {
            List<DataPoint> danhThu = new List<DataPoint>();
            List<DataPoint> chiPhi = new List<DataPoint>();
            List<DataPoint> loiNhuan = new List<DataPoint>();
            /**
             * Doanh thu
             */
            foreach(Tour tour in danhSachTour)
            {
                DataPoint danhThuPoint = new DataPoint();
                danhThuPoint.AxisLabel = tour.Name;
                danhThuPoint.YValues[0] = tour.TongDoanhThuTourByTime(datepicker_tu_doanhthutour.Value, datepicker_den_doanhthutour.Value);
                danhThu.Add(danhThuPoint);

               
                /**
                 * Chi phí
                 */
                DataPoint chiPhiPoint = new DataPoint();
                chiPhiPoint.AxisLabel = tour.Name; 
                foreach (Doan doan in tour.GetListDoanOfTourByTime(datepicker_tu_doanhthutour.Value, datepicker_den_doanhthutour.Value))
                {
                    if(doan.ChiPhis != null)
                    {
                        chiPhiPoint.YValues[0]+=doan.TongChiPhiDoan();
                    }
                }
                chiPhi.Add(chiPhiPoint);

                DataPoint loaiNhuanPoint = new DataPoint();
                loaiNhuanPoint.AxisLabel = tour.Name;
                loaiNhuanPoint.YValues[0] = danhThuPoint.YValues[0] - chiPhiPoint.YValues[0];
                loiNhuan.Add(loaiNhuanPoint);


            }
            chart_thongkedoanhthu.Series[0].Points.Clear();
            foreach (DataPoint dataPoint in danhThu)
            {
                chart_thongkedoanhthu.Series[0].Points.Add(dataPoint);
                chart_thongkedoanhthu.Update();
            }
            /**
             * Chi Phí
             */
            chart_thongkedoanhthu.Series[1].Points.Clear();
            foreach (DataPoint dataPoint in chiPhi)
            {
                chart_thongkedoanhthu.Series[1].Points.Add(dataPoint);
                chart_thongkedoanhthu.Update();
            }
            /**
             * Lợi nhuận
             */
            chart_thongkedoanhthu.Series[2].Points.Clear();
            foreach (DataPoint dataPoint in loiNhuan)
            {
                chart_thongkedoanhthu.Series[2].Points.Add(dataPoint);
                chart_thongkedoanhthu.Update();
            }
        }
        private void InitThongKeTour_SoLuongKhachDoan()
        {
            List<DataPoint> khach = new List<DataPoint>();
            List<DataPoint> doan = new List<DataPoint>();

            /**
             * Đoàn
             */
            foreach (Tour tour in danhSachTour)
            {
                DataPoint doanPoint = new DataPoint();
                doanPoint.AxisLabel = tour.Name;
                doanPoint.YValues[0] = tour.GetListDoanOfTourByTime(datepicker_tu_khacdoan.Value, datepicker_den_khachdoan.Value).Count();
                doan.Add(doanPoint);

                /**
                 * Khách
                 */
               
                DataPoint khachPoint = new DataPoint();
                khachPoint.AxisLabel = tour.Name;
                khachPoint.YValues[0] = tour.GetListKhachOfTourByTime(datepicker_tu_khacdoan.Value, datepicker_den_khachdoan.Value).Count();
                khach.Add(khachPoint);
            }
            /**
             * Khách
             */
            chart_soluongkhachvadoan.Series[0].Points.Clear();
            foreach (DataPoint dataPoint in khach)
            {
                chart_soluongkhachvadoan.Series[0].Points.Add(dataPoint);
                chart_soluongkhachvadoan.Update();
            }
            /**
             * Đoàn
             */
            chart_soluongkhachvadoan.Series[1].Points.Clear();
            foreach (DataPoint dataPoint in doan)
            {
                chart_soluongkhachvadoan.Series[1].Points.Add(dataPoint);
                chart_soluongkhachvadoan.Update();
            }
      
        }

        private void InitThongKeNhanVienDiTour()
        {
            listview_solanditour.Items.Clear();
            foreach (NhanVien nhanVien in danhSachNhanVien)
            {
                ListViewItem listViewItem1 = new ListViewItem(new string[] {
                nhanVien.MaNhanVien.ToString(),
                nhanVien.TenNhanVien,
                nhanVien.GetListDoanPhanCongByTime(dateTimePicker1.Value,dateTimePicker2.Value).Count().ToString()});
                listview_solanditour.Items.Add(listViewItem1);
            }
        }

        private void InitData()
        {
            nam.Add("Bất Kỳ");
            if(danhSachDoan.Count > 0)
            {
                DateTime min = danhSachDoan.First().ThoiGianBatDau;
                DateTime max = danhSachDoan.First().ThoiGianKetThuc;
                foreach (Doan doan in danhSachDoan)
                {
                    if (doan.ThoiGianBatDau < min)
                        min = doan.ThoiGianBatDau;
                    if (doan.ThoiGianKetThuc > max)
                        max = doan.ThoiGianKetThuc;
                }
                dateTimePicker1.MinDate = min;
                dateTimePicker1.MaxDate = max;
                dateTimePicker2.MinDate = min;
                dateTimePicker2.MaxDate = max;

                datepicker_tu_doanhthutour.MinDate = min;
                datepicker_tu_doanhthutour.MaxDate = max;
                datepicker_den_doanhthutour.MinDate = min;
                datepicker_den_doanhthutour.MaxDate = max;

                datepicker_tu_khacdoan.MinDate = min;
                datepicker_tu_khacdoan.MaxDate = max;
                datepicker_den_khachdoan.MinDate = min;
                datepicker_den_khachdoan.MaxDate = max;


                dateTimePicker1.Value = min;
                dateTimePicker2.Value = max;
                datepicker_tu_doanhthutour.Value = min;
                datepicker_den_doanhthutour.Value = max;
                datepicker_tu_khacdoan.Value = min;
                datepicker_den_khachdoan.Value = max;

            }
    
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
                dateTimePicker2.Value = dateTimePicker1.Value;
            InitThongKeNhanVienDiTour();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value < dateTimePicker1.Value)
                dateTimePicker1.Value = dateTimePicker2.Value;
            InitThongKeNhanVienDiTour();
        }
        private void datepicker_tu_doanhthutour_ValueChanged(object sender, EventArgs e)
        {
            if (datepicker_tu_doanhthutour.Value > datepicker_den_doanhthutour.Value)
                datepicker_den_doanhthutour.Value = datepicker_tu_doanhthutour.Value;
            InitThongKeTour();
        }
        private void datepicker_den_doanhthutour_ValueChanged(object sender, EventArgs e)
        {
            if (datepicker_den_doanhthutour.Value < datepicker_tu_doanhthutour.Value)
                datepicker_tu_doanhthutour.Value = datepicker_den_doanhthutour.Value;
            InitThongKeTour();
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {

        }

        private void datepicker_tu_khacdoan_ValueChanged(object sender, EventArgs e)
        {
            if (datepicker_tu_khacdoan.Value > datepicker_den_khachdoan.Value)
                datepicker_den_khachdoan.Value = datepicker_tu_khacdoan.Value;
            InitThongKeTour_SoLuongKhachDoan();
        }

        private void datepicker_den_khachdoan_ValueChanged(object sender, EventArgs e)
        {
            if (datepicker_den_khachdoan.Value < datepicker_tu_khacdoan.Value)
                datepicker_tu_doanhthutour.Value = datepicker_den_khachdoan.Value;
            InitThongKeTour_SoLuongKhachDoan();
        }
    }
}
