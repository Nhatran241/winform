using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DuLich.BUS;

namespace DuLich.View.QuanLyTouris
{
    public partial class ThongKeTheoTour : UserControl
    {
        private Tour tour;
        List<String> nam = new List<String>();
        public ThongKeTheoTour(Tour tour)
        {
            InitializeComponent();
            this.tour = tour;
            InitData();
        }
        private void InitData()
        {
            nam.Add("Bất Kỳ");
            if (tour.Doans != null)
            {
                foreach (Doan doan in tour.Doans.ToList())
                {
                    if (!nam.Contains(doan.ThoiGianBatDau.Year.ToString()))
                    {
                        nam.Add(doan.ThoiGianBatDau.Year.ToString());
                    }
                }
            }
            cb_nam.Items.Clear();
            foreach (String str in nam)
            {
                cb_nam.Items.Add(str);
            }
            cb_nam.SelectedIndex = 0;
        }


     
        private void cb_nam_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<DataPoint> danhThu = new List<DataPoint>();
            List<DataPoint> chiPhi = new List<DataPoint>();
            List<DataPoint> loiNhuan = new List<DataPoint>();
            danhThu.Clear();
            danhThu.Add(new DataPoint(1D, 0D));
            danhThu.Add(new DataPoint(2D, 0D));
            danhThu.Add(new DataPoint(3D, 0D));
            danhThu.Add(new DataPoint(4D, 0D));
            danhThu.Add(new DataPoint(5D, 0D));
            danhThu.Add(new DataPoint(6D, 0D));
            danhThu.Add(new DataPoint(7D, 0D));
            danhThu.Add(new DataPoint(8D, 0D));
            danhThu.Add(new DataPoint(9D, 0D));
            danhThu.Add(new DataPoint(10D, 0D));
            danhThu.Add(new DataPoint(11D, 0D));
            danhThu.Add(new DataPoint(12D, 0D));


            chiPhi.Clear();
            chiPhi.Add(new DataPoint(1D, 0D));
            chiPhi.Add(new DataPoint(2D, 0D));
            chiPhi.Add(new DataPoint(3D, 0D));
            chiPhi.Add(new DataPoint(4D, 0D));
            chiPhi.Add(new DataPoint(5D, 0D));
            chiPhi.Add(new DataPoint(6D, 0D));
            chiPhi.Add(new DataPoint(7D, 0D));
            chiPhi.Add(new DataPoint(8D, 0D));
            chiPhi.Add(new DataPoint(9D, 0D));
            chiPhi.Add(new DataPoint(10D, 0D));
            chiPhi.Add(new DataPoint(11D, 0D));
            chiPhi.Add(new DataPoint(12D, 0D));


            loiNhuan.Clear();
            loiNhuan.Add(new DataPoint(1D, 0D));
            loiNhuan.Add(new DataPoint(2D, 0D));
            loiNhuan.Add(new DataPoint(3D, 0D));
            loiNhuan.Add(new DataPoint(4D, 0D));
            loiNhuan.Add(new DataPoint(5D, 0D));
            loiNhuan.Add(new DataPoint(6D, 0D));
            loiNhuan.Add(new DataPoint(7D, 0D));
            loiNhuan.Add(new DataPoint(8D, 0D));
            loiNhuan.Add(new DataPoint(9D, 0D));
            loiNhuan.Add(new DataPoint(10D, 0D));
            loiNhuan.Add(new DataPoint(11D, 0D));
            loiNhuan.Add(new DataPoint(12D, 0D));
            if (tour.Doans != null)
            {
                foreach (Doan doan in tour.Doans.ToList())
                {
                    if (nam[cb_nam.SelectedIndex].Equals("Bất Kỳ") || doan.ThoiGianBatDau.Year == int.Parse(nam[cb_nam.SelectedIndex]))
                    {
                        danhThu[doan.ThoiGianBatDau.Month - 1].YValues[0] += (doan.GiaApDung.GiaTri / 1) * 1D;
                        chiPhi[doan.ThoiGianBatDau.Month - 1].YValues[0] += (doan.TongChiPhiDoan() / 1) * 1D;
                        loiNhuan[doan.ThoiGianBatDau.Month - 1].YValues[0] = danhThu[doan.ThoiGianBatDau.Month - 1].YValues[0] - chiPhi[doan.ThoiGianBatDau.Month - 1].YValues[0];
                    }

                }
              
            }
            chart1.Series[0].Points.Clear();
            foreach (DataPoint dataPoint in danhThu)
            {
                chart1.Series[0].Points.Add(dataPoint);
            }

            chart1.Series[1].Points.Clear();
            foreach (DataPoint dataPoint in chiPhi)
            {
                chart1.Series[1].Points.Add(dataPoint);
            }

            chart1.Series[2].Points.Clear();
            foreach (DataPoint dataPoint in loiNhuan)
            {
                chart1.Series[2].Points.Add(dataPoint);
            }
            chart1.Update();

            tv_tongdoan.Text = tour.GetListDoanOfTour().Count().ToString();
            tv_tongkhach.Text = tour.GetListKhachOfTour().Count().ToString();
        }
    }
}
