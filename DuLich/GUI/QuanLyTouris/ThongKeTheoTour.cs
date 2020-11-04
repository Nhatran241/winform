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
                foreach (Doan doan in tour.Doans.ToList())
                {
                    if (nam[cb_nam.SelectedIndex].Equals("Bất Kỳ") || doan.ThoiGianBatDau.Year == int.Parse(nam[cb_nam.SelectedIndex]))
                        dataPoints[doan.ThoiGianBatDau.Month - 1].YValues[0] += (doan.GiaApDung.GiaTri / 1) * 1D;
                }
              
            }
            chart_thongkedoanhthu.Series[0].Points.Clear();
            foreach (DataPoint dataPoint in dataPoints)
            {
                chart_thongkedoanhthu.Series[0].Points.Add(dataPoint);
                chart_thongkedoanhthu.Update();
            }
            tv_tongdoan.Text = tour.GetListDoanOfTour().Count().ToString();
            tv_tongkhach.Text = tour.GetListKhachOfTour().Count().ToString();
        }
    }
}
