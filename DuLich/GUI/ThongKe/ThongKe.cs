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
        List<DataPoint> dataPoints = new List<DataPoint>();
        List<DoanKhach> doanKhaches = new List<DoanKhach>();
        List<String> nam = new List<String>();
        public ThongKe(List<NhanVien> danhSachNhanVien,List<PhanCong> danhSachPhanCong,List<Tour> danhSachTour,List<Doan> danhSachDoan)
        {
            InitializeComponent();
            this.danhSachNhanVien = danhSachNhanVien;
            this.danhSachPhanCong = danhSachPhanCong;
            this.danhSachTour = danhSachTour;
            this.danhSachDoan = danhSachDoan;
            InitData();
            InitThongKeNhanVienDiTour();
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
            cb_nam.DataSource = nam;
            DateTime min = danhSachDoan.First().ThoiGianBatDau;
            DateTime max = danhSachDoan.First().ThoiGianKetThuc;
            foreach(Doan doan in danhSachDoan)
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
            dateTimePicker1.Value = min;
            dateTimePicker2.Value = max;

        }


        private void cb_nam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tour == null)
                return;
            dataPoints.Clear();
            dataPoints.Add(new DataPoint(1D, 0D));
            dataPoints.Add(new DataPoint(2D, 0D));
            dataPoints.Add(new DataPoint(3D, 0D));
            dataPoints.Add(new DataPoint(4D, 0D));
            dataPoints.Add(new DataPoint(5D, 0D));
            dataPoints.Add(new DataPoint(6D, 0D));
            dataPoints.Add(new DataPoint(7D, 0D));
            dataPoints.Add(new DataPoint(8D, 0D));
            dataPoints.Add(new DataPoint(9D, 0D));
            dataPoints.Add(new DataPoint(10D, 0D));
            dataPoints.Add(new DataPoint(11D, 0D));
            dataPoints.Add(new DataPoint(12D, 0D));
            if(tour.Doans != null)
            {
                foreach (Doan doan in tour.Doans)
                {
                    if (nam[cb_nam.SelectedIndex].Equals("Bất Kỳ") || doan.ThoiGianBatDau.Year == int.Parse(nam[cb_nam.SelectedIndex]))
                        dataPoints[doan.ThoiGianBatDau.Month - 1].YValues[0] += (doan.GiaApDung.GiaTri / 1000000) * 1D;
                }
            }
            chart_thongkedoanhthu.Series[0].Points.Clear();
            foreach (DataPoint dataPoint in dataPoints)
            {
                chart_thongkedoanhthu.Series[0].Points.Add(dataPoint);
                chart_thongkedoanhthu.Update();
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
    }
}
