using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DuLich.Model.Entity;
using DuLich.Entity;

namespace DuLich.GUI.QuanLyDoan
{
    public partial class SearchDoan :UserControl
    {
        private List<Tour> danhSachTour = new List<Tour>();
        private List<NhanVien> danhSachNhanVien = new List<NhanVien>();
        private List<Khach> danhSachKhach = new List<Khach>();
        private Tour filterTour = new Tour();
        private NhanVien filterNhanVien = new NhanVien();
        private Khach filterKhach = new Khach();
        private String filterTen = "";
        private DateTime minDate = new DateTime();
        private DateTime maxDate = new DateTime();
        private ISearchDoanListener searchDoanListener;

        public SearchDoan()
        {
            InitializeComponent();
        }
        public void SetData(List<Tour> danhSachTour,List<NhanVien> danhSachNhanVien,List<Khach> danhSachKhach,DateTime maxDate,DateTime minDate,ISearchDoanListener searchDoanListener)
        {
            this.danhSachTour.AddRange(danhSachTour);
            this.danhSachKhach.AddRange(danhSachKhach);
            this.danhSachNhanVien.AddRange(danhSachNhanVien);
            this.maxDate = maxDate;
            this.minDate = minDate;
            this.searchDoanListener = searchDoanListener;
            filterTour.Id = -1;
            filterTour.Name = "Bất kỳ";
            filterKhach.KhachId = -1;
            filterKhach.Ten = "Bất kỳ";
            filterNhanVien.MaNhanVien = -1;
            filterNhanVien.TenNhanVien = "Bất kỳ";
            this.danhSachTour.Insert(0,filterTour);
            this.danhSachKhach.Insert(0,filterKhach);
            this.danhSachNhanVien.Insert(0,filterNhanVien);
            InitData();
        }

        private void InitData()
        {
            cb_tour.DataSource = danhSachTour;
            cb_khach.DataSource = danhSachKhach;
            cb_nhanvien.DataSource = danhSachNhanVien;
            datepickbatdau.MinDate = minDate;
            datepickbatdau.MaxDate = maxDate;
            datepickketthuc.MaxDate = maxDate;
            datepickketthuc.MinDate = minDate;
            datepickbatdau.Value = minDate;
            datepickketthuc.Value = maxDate;
        }

        private void cb_search_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterTour = danhSachTour[cb_tour.SelectedIndex];
            searchDoanListener.onSearchDoan(filterTour, filterTen, filterNhanVien, filterKhach, minDate, maxDate);
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            filterTen = tb_search.Text.Trim().ToLower();
            if(searchDoanListener != null)
                searchDoanListener.onSearchDoan(filterTour, filterTen, filterNhanVien, filterKhach, minDate, maxDate);
        }

        public interface ISearchDoanListener
        {
            void onSearchDoan(Tour tour, string ten,NhanVien nhanVien,Khach khach,DateTime min,DateTime max);
        }


        private void cb_khach_SelectedIndexChanged(object sender, EventArgs e)
        {

            filterKhach = danhSachKhach[cb_khach.SelectedIndex];
            searchDoanListener.onSearchDoan(filterTour, filterTen, filterNhanVien, filterKhach, minDate, maxDate);
        }

        private void cb_nhanvien_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterNhanVien = danhSachNhanVien[cb_nhanvien.SelectedIndex];
            searchDoanListener.onSearchDoan(filterTour,filterTen, filterNhanVien, filterKhach,minDate,maxDate);
        }

        private void datepickbatdau_ValueChanged(object sender, EventArgs e)
        {
            minDate = datepickbatdau.Value;
            if (minDate >= maxDate)
                datepickketthuc.Value = minDate;
            searchDoanListener.onSearchDoan(filterTour, filterTen, filterNhanVien, filterKhach, minDate, maxDate);
        }

        private void datepickketthuc_ValueChanged(object sender, EventArgs e)
        {
            maxDate = datepickketthuc.Value;
            if (maxDate < minDate)
                datepickbatdau.Value = maxDate;
            searchDoanListener.onSearchDoan(filterTour, filterTen, filterNhanVien, filterKhach, minDate, maxDate);
        }
    }
}
