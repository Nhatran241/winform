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

namespace DuLich.View.QuanLyTouris
{
    public partial class ThongKeTheoTour : UserControl
    {
        private Tour tour;
        List<DataPoint> dataPoints = new List<DataPoint>();
        List<DoanKhach> doanKhaches = new List<DoanKhach>();
        List<String> nam = new List<String>();
        public ThongKeTheoTour(Tour tour)
        {
            InitializeComponent();
            this.tour = tour;
            InitData();
        }
        private void InitData()
        {
            tv_tongdoan.Text = tour.Doans.Count.ToString();
            nam.Add("Bất Kỳ");
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
            foreach (Doan doan in tour.Doans)
            {
                if(doan.DoanKhachs != null)
                    doanKhaches.Union(doan.DoanKhachs);
                if (!nam.Contains(doan.ThoiGianBatDau.Year+""))
                {
                    nam.Add(doan.ThoiGianBatDau.Year+"");
                }
                dataPoints[doan.ThoiGianBatDau.Month - 1].YValues[0] += (doan.GiaTour / 1000000) * 1D;
            }
            tv_tongkhach.Text = doanKhaches.Count.ToString();
            foreach(DataPoint dataPoint in dataPoints)
            {
                chart_thongkedoanhthu.Series[0].Points.Add(dataPoint);
            }
            cb_nam.DataSource = nam;
        }


        private void cb_nam_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            foreach (Doan doan in tour.Doans)
            {
                if (nam[cb_nam.SelectedIndex].Equals("Bất Kỳ")||doan.ThoiGianBatDau.Year == int.Parse(nam[cb_nam.SelectedIndex]))
                    dataPoints[doan.ThoiGianBatDau.Month - 1].YValues[0] += (doan.GiaTour / 1000000) * 1D;
            }
            chart_thongkedoanhthu.Series[0].Points.Clear();
            foreach (DataPoint dataPoint in dataPoints)
            {
                chart_thongkedoanhthu.Series[0].Points.Add(dataPoint);
                chart_thongkedoanhthu.Update();
            }
        }
    }
}
