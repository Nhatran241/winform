﻿using System;
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
            DateTime min = tour.GetListDoanOfTour().First().ThoiGianBatDau;
            DateTime max = tour.GetListDoanOfTour().First().ThoiGianKetThuc;
            foreach (Doan doan in tour.GetListDoanOfTour())
            {
                if (doan.ThoiGianBatDau < min)
                    min = doan.ThoiGianBatDau;
                if (doan.ThoiGianKetThuc > max)
                    max = doan.ThoiGianKetThuc;
            }
            datepicker_tu_doanhthutour.MinDate = min;
            datepicker_tu_doanhthutour.MaxDate = max;
            datepicker_den_doanhthutour.MinDate = min;
            datepicker_den_doanhthutour.MaxDate = max;

            datepicker_tu_doanhthutour.Value = min;
            datepicker_den_doanhthutour.Value = max;
        }



        private void InitThongKeTour()
        {
            double tongdanhthu = 0;
            double tongchiphi = 0;
            double tongloinhuan = 0;
            int tongkhach = 0;
            listview_thongketheodoan.Items.Clear();
            int count = 0;
            foreach(Doan doan in tour.GetListDoanOfTourByTime(datepicker_tu_doanhthutour.Value,datepicker_den_doanhthutour.Value))
            {
                count++;
                double danhthu = doan.GiaApDung.GiaTri * doan.GetListKhach().Count();
                tongdanhthu += danhthu;
                double chiphi = doan.TongChiPhiDoan();
                tongchiphi += chiphi;
                double loinhuan = danhthu - chiphi;
                tongloinhuan += loinhuan;
                int khach = doan.GetListKhach().Count();
                tongkhach += khach;
                ListViewItem listViewItem1 = new ListViewItem(new string[] {
            doan.Name,
            danhthu+" $"
            ,
            chiphi+" $"
            ,loinhuan+ "$",
                khach+""}, -1);
                listview_thongketheodoan.Items.Add(listViewItem1);
            }
            ListViewItem tong = new ListViewItem(new string[] {
            "Tổng cộng :"+count+ "đoàn",
            tongdanhthu+" $"
            ,
            tongchiphi+" $"
            ,
                tongloinhuan+ "$",
            tongkhach+""}, -1);
            listview_thongketheodoan.Items.Add(tong);
        }
        private void label4_Click(object sender, EventArgs e)
        {

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
    }
}
