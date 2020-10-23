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

namespace DuLich.GUI.QuanLyDoan
{
    public partial class DanhSachDoan : UserControl,SearchDoan.ISearchDoanListener
    {
        private IDanhSachDoanListener danhSachDoanListener;
        private List<Doan> danhSachDoan;
        private List<Tour> danhSachTour;
        private List<NhanVien> danhSachNhanVien;
        private List<Khach> danhSachKhach;

        public DanhSachDoan(List<Doan> doans, List<Tour> tours,List<NhanVien> nhanViens,List<Khach> khaches,IDanhSachDoanListener danhSachDoanListener)
        {
            InitializeComponent();
            danhSachDoan = doans;
            danhSachKhach = khaches;
            danhSachNhanVien = nhanViens;
            danhSachTour = tours;
            this.danhSachDoanListener = danhSachDoanListener;
            InitData();
        }
     

        private void OnDoanDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int position = dataGridViewDoan.CurrentCell.RowIndex;
            danhSachDoanListener.onDanhSachDoan_DoanDoubleClick(danhSachDoan.ToList()[position]);
        }


        private void InitData()
        {
            dataGridViewDoan.DataSource = danhSachDoan.ToList();
            DateTime min = danhSachDoan.First().ThoiGianBatDau;
            DateTime max = danhSachDoan.First().ThoiGianKetThuc;
            foreach(Doan doan in danhSachDoan)
            {
                if (doan.ThoiGianBatDau < min)
                    min = doan.ThoiGianBatDau;
                if (doan.ThoiGianKetThuc > max)
                    max = doan.ThoiGianKetThuc;
            }
            searchDoan1.SetData(danhSachTour,danhSachNhanVien,danhSachKhach,max,min, this);
        }

        public void onSearchDoan(Tour tour, string ten, NhanVien nhanVien, Khach khach, DateTime min, DateTime max)
        {
            if (!ten.Equals(""))
            {
                if (tour.Id == -1)
                {
                    if(nhanVien.MaNhanVien == -1)
                    {
                        if(khach.KhachId == -1)
                        {
                            dataGridViewDoan.DataSource = danhSachDoan.Where(c => c.Name.ToLower().Contains(ten)&&c.ThoiGianBatDau>= min && c.ThoiGianKetThuc <=max).ToList();
                        }
                        else
                        {
                            dataGridViewDoan.DataSource = danhSachDoan.Where(c => c.Name.ToLower().Contains(ten)
                            &&(c.DoanKhachs!=null &&c.DoanKhachs.Where(d=>d.Khach.KhachId == khach.KhachId).Any())
                            && c.ThoiGianBatDau >= min && c.ThoiGianKetThuc <= max).ToList();
                        }
                    }
                    else
                    {

                        if (khach.KhachId == -1)
                        {
                            dataGridViewDoan.DataSource = danhSachDoan.Where(c => c.Name.ToLower().Contains(ten)
                            && (c.PhanCongs!=null &&c.PhanCongs.Where(d => d.NhanVien.MaNhanVien == nhanVien.MaNhanVien).Any())
                            && c.ThoiGianBatDau >= min && c.ThoiGianKetThuc <= max).ToList();
                        }
                        else
                        {
                            dataGridViewDoan.DataSource = danhSachDoan.Where(c => c.Name.ToLower().Contains(ten)
                            && (c.PhanCongs!=null&&c.PhanCongs.Where(d => d.NhanVien.MaNhanVien == nhanVien.MaNhanVien).Any())
                            && (c.DoanKhachs!= null&&c.DoanKhachs.Where(d => d.Khach.KhachId == khach.KhachId).Any())
                            && c.ThoiGianBatDau >= min && c.ThoiGianKetThuc <= max).ToList();
                        }
                    }
                }
                else
                {
                    if (nhanVien.MaNhanVien == -1)
                    {
                        if (khach.KhachId == -1)
                        {
                            dataGridViewDoan.DataSource = danhSachDoan.Where(c => c.Name.ToLower().Contains(ten)
                            && c.Touris.Id == tour.Id
                            && c.ThoiGianBatDau >= min && c.ThoiGianKetThuc <= max).ToList();
                        }
                        else
                        {
                            dataGridViewDoan.DataSource = danhSachDoan.Where(c => c.Name.ToLower().Contains(ten)
                            && c.Touris.Id == tour.Id
                            && (c.DoanKhachs!=null&&c.DoanKhachs.Where(d => d.Khach.KhachId == khach.KhachId).Any())
                            && c.ThoiGianBatDau >= min && c.ThoiGianKetThuc <= max).ToList();
                        }
                    }
                    else
                    {

                        if (khach.KhachId == -1)
                        {
                            dataGridViewDoan.DataSource = danhSachDoan.Where(c => c.Name.ToLower().Contains(ten)
                            && c.Touris.Id == tour.Id
                            && (c.PhanCongs!=null&&c.PhanCongs.Where(d => d.NhanVien.MaNhanVien == nhanVien.MaNhanVien).Any())
                            && c.ThoiGianBatDau >= min && c.ThoiGianKetThuc <= max).ToList();
                        }
                        else
                        {
                            dataGridViewDoan.DataSource = danhSachDoan.Where(c => c.Name.ToLower().Contains(ten)
                            && c.Touris.Id == tour.Id
                            && (c.PhanCongs!=null&&c.PhanCongs.Where(d => d.NhanVien.MaNhanVien == nhanVien.MaNhanVien).Any())
                            && (c.DoanKhachs!=null&&c.DoanKhachs.Where(d => d.Khach.KhachId == khach.KhachId).Any())
                            && c.ThoiGianBatDau >= min && c.ThoiGianKetThuc <= max).ToList();
                        }
                    }
                }
            }
            else
            {
                if (tour.Id == -1)
                {
                    if (nhanVien.MaNhanVien == -1)
                    {
                        if (khach.KhachId == -1)
                        {
                            dataGridViewDoan.DataSource = danhSachDoan.Where(c =>c.ThoiGianBatDau >= min && c.ThoiGianKetThuc <= max).ToList();
                        }
                        else
                        {
                            dataGridViewDoan.DataSource = danhSachDoan.Where(c => 
                            (c.DoanKhachs!=null&&c.DoanKhachs.Where(d => d.Khach.KhachId == khach.KhachId).Any())
                            && c.ThoiGianBatDau >= min && c.ThoiGianKetThuc <= max).ToList();
                        }
                    }
                    else
                    {

                        if (khach.KhachId == -1)
                        {
                            dataGridViewDoan.DataSource = danhSachDoan.Where(c =>
                            (c.PhanCongs!=null&&c.PhanCongs.Where(d => d.NhanVien.MaNhanVien == nhanVien.MaNhanVien).Any())
                            && c.ThoiGianBatDau >= min && c.ThoiGianKetThuc <= max).ToList();
                        }
                        else
                        {
                            dataGridViewDoan.DataSource = danhSachDoan.Where(c => 
                            (c.PhanCongs!=null&&c.PhanCongs.Where(d => d.NhanVien.MaNhanVien == nhanVien.MaNhanVien).Any())
                            && (c.DoanKhachs!=null&&c.DoanKhachs.Where(d => d.Khach.KhachId == khach.KhachId).Any())
                            && c.ThoiGianBatDau >= min && c.ThoiGianKetThuc <= max).ToList();
                        }
                    }
                }
                else
                {
                    if (nhanVien.MaNhanVien == -1)
                    {
                        if (khach.KhachId == -1)
                        {
                            dataGridViewDoan.DataSource = danhSachDoan.Where(c => 
                            c.Touris.Id == tour.Id
                            && c.ThoiGianBatDau >= min && c.ThoiGianKetThuc <= max).ToList();
                        }
                        else
                        {
                            dataGridViewDoan.DataSource = danhSachDoan.Where(c => 
                            c.Touris.Id == tour.Id
                            && (c.DoanKhachs!= null &&c.DoanKhachs.Where(d => d.Khach.KhachId == khach.KhachId).Any())
                            && c.ThoiGianBatDau >= min && c.ThoiGianKetThuc <= max).ToList();
                        }
                    }
                    else
                    {

                        if (khach.KhachId == -1)
                        {
                            dataGridViewDoan.DataSource = danhSachDoan.Where(c => 
                            c.Touris.Id == tour.Id
                            && (c.PhanCongs!=null&&c.PhanCongs.Where(d => d.NhanVien.MaNhanVien == nhanVien.MaNhanVien).Any())
                            && c.ThoiGianBatDau >= min && c.ThoiGianKetThuc <= max).ToList();
                        }
                        else
                        {
                            dataGridViewDoan.DataSource = danhSachDoan.Where(c => 
                            c.Touris.Id == tour.Id
                            && (c.PhanCongs!=null&&c.PhanCongs.Where(d => d.NhanVien.MaNhanVien == nhanVien.MaNhanVien).Any())
                            && (c.DoanKhachs!=null&&c.DoanKhachs.Where(d => d.Khach.KhachId == khach.KhachId).Any())
                            && c.ThoiGianBatDau >= min && c.ThoiGianKetThuc <= max).ToList();
                        }
                    }
                }
            }
        }

        public interface IDanhSachDoanListener
        {
            void onDanhSachDoan_DoanDoubleClick(Doan doan);
        }
    }
}
