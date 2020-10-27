using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DuLich.Entity;
using DuLich.Model.Entity;
using System.Windows.Forms.DataVisualization.Charting;

namespace DuLich.GUI.ThongKe
{
    public partial class ThongKe : UserControl
    {
        private Tour tour;
        private List<NhanVien> danhSachNhanVien;
        private List<PhanCong> danhSachPhanCong;
        private List<Tour> danhSachTour;
        private List<Doan> danhSachDoan;
        private List<Khach> danhSachKhach;
        List<DoanKhach> doanKhaches = new List<DoanKhach>();
        List<String> nam = new List<String>();
        public ThongKe(List<NhanVien> danhSachNhanVien,List<PhanCong> danhSachPhanCong,List<Tour> danhSachTour,List<Doan> danhSachDoan,List<Khach> danhSachKhach)
        {
            InitializeComponent();
            this.danhSachNhanVien = danhSachNhanVien;
            this.danhSachPhanCong = danhSachPhanCong;
            this.danhSachTour = danhSachTour;
            this.danhSachDoan = danhSachDoan;
            this.danhSachKhach = danhSachKhach;
            InitData();
            InitThongKeNhanVienDiTour();
            InitThongKeTour();
            InitThongKeTour_SoLuongKhachDoan();
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
                danhThuPoint.YValues[0] = danhSachDoan.Where(c => c.Touris.Id == tour.Id&&c.ThoiGianBatDau>=datepicker_tu_doanhthutour.Value && c.ThoiGianKetThuc <= datepicker_den_doanhthutour.Value).Sum(c => c.GiaApDung.GiaTri);
                danhThu.Add(danhThuPoint);

               
                /**
                 * Chi phí
                 */
                DataPoint chiPhiPoint = new DataPoint();
                chiPhiPoint.AxisLabel = tour.Name; 
                List<Doan> doanCuaTour = danhSachDoan.Where(c => c.Touris.Id == tour.Id
                   && c.ThoiGianBatDau >= datepicker_tu_doanhthutour.Value
                   && c.ThoiGianKetThuc <= datepicker_den_doanhthutour.Value).ToList();
                foreach (Doan doan in doanCuaTour)
                {
                    if(doan.ChiPhis != null)
                    {
                        chiPhiPoint.YValues[0]+=doan.ChiPhis.Sum(c => c.giaTri);
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
                doanPoint.YValues[0]=danhSachDoan.Count(c => c.Touris.Id == tour.Id&&c.ThoiGianBatDau>=datepicker_tu_khacdoan.Value&&c.ThoiGianKetThuc<=datepicker_den_khachdoan.Value);
                doan.Add(doanPoint);

                /**
                 * Khách
                 */
                List<Khach> khachTrongTour = new List<Khach>();
                if(tour.Doans != null)
                {
                    foreach (Doan doan1 in tour.Doans.Where(c=>c.ThoiGianBatDau >= datepicker_tu_khacdoan.Value && c.ThoiGianKetThuc <= datepicker_den_khachdoan.Value).ToList())
                    {
                        if(doan1.DoanKhachs!=null)
                            khachTrongTour.AddRange(danhSachKhach.Where(c => doan1.DoanKhachs.Select(d => d.Khach.KhachId).ToList().Contains(c.KhachId)).ToList());
                    }
                }
                DataPoint khachPoint = new DataPoint();
                khachPoint.AxisLabel = tour.Name;
                khachPoint.YValues[0] = khachTrongTour.Distinct().ToList().Count();
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
                danhSachPhanCong.Count(c=>c.NhanVien.MaNhanVien == nhanVien.MaNhanVien &&c.Doan.ThoiGianBatDau>=dateTimePicker1.Value && c.Doan.ThoiGianKetThuc<= dateTimePicker2.Value).ToString()});
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
