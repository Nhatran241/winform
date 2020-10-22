﻿using BUS;
using DAL;
using DuLich.BUS;
using DuLich.Entity;
using DuLich.GUI.QuanLyChiPhi;
using DuLich.GUI.QuanLyKhach;
using DuLich.GUI.QuanLyNhanVien;
using DuLich.GUI.QuanLyTouris;
using DuLich.Model.Entity;
using DuLich.View;
using DuLich.View.QuanLyDiaDiem;
using DuLich.View.QuanLyDoan;
using DuLich.View.QuanLyPhanCong;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuLich
{
    public partial class ManHinhChinh : Form
       
    {
        private DuLichContext context = new DuLichContext();
        private UserControl userControl;
        private List<Khach> khaches = new List<Khach>();
        private List<Doan> doans = new List<Doan>();
        private List<PhanCong> danhSachPhanCong = new List<PhanCong>();
        private List<NhanVien> danhSachNhanVien = new List<NhanVien>();
        private List<Touris> listTouris = new List<Touris>();
        private List<Loai> listLoais = new List<Loai>();
        private List<DiaDiem> listDiaDiems = new List<DiaDiem>();
        private List<Gia> danhSachGia = new List<Gia>();
        private List<ChiTietTour> listChiTietTour = new List<ChiTietTour>();
        private List<DiaDiem> diaDiemCuaTour = new List<DiaDiem>();
        private List<DoanKhach> danhSachDoanKhach = new List<DoanKhach>();
        private List<ChiPhi> danhSachChiPhi = new List<ChiPhi>();
        private List<LoaiChiPhi> danhSachLoaiChiPhi = new List<LoaiChiPhi>();

        public ManHinhChinh()
        {
            InitializeComponent();
            OnManHinhChinhLoad();
        }
     
        private void OnManHinhChinhLoad()
        {
            LoadDataFromDataBase();
            panel_main_content.Controls.Add(new DanhSachTour(context.Touris.ToList(), listLoais, this));
        }

        private void LoadDataFromDataBase()
        {
            doans = context.Doans.ToList();
            listTouris = context.Touris.ToList();
            listLoais = context.Loai.ToList();
            listDiaDiems = context.DiaDiem.ToList();
            khaches = context.Khaches.ToList();
            danhSachPhanCong = context.PhanCongs.ToList();
            danhSachNhanVien = context.NhanViens.ToList();
            danhSachDoanKhach = context.DoanKhachs.ToList();
            danhSachChiPhi = context.ChiPhis.ToList();
            danhSachLoaiChiPhi = context.LoaiChiPhis.ToList();
        }

    }

}
/**
 * Quản Lý Tour
 */
namespace DuLich
{
    public partial class ManHinhChinh : DanhSachTour.IDanhSachTourListener, ChiTietTouris.OnChiTietTourListener
    {

        public void onChiTietTourCapNhatClick(Touris tourisAfterUpdate, List<DiaDiem> diaDiemCuaTour)
        {
            if (diaDiemCuaTour.Count() != 0)
            {
                for (int i = 0; i < diaDiemCuaTour.Count(); i++)
                {
                    ChiTietTour chiTietTour = new ChiTietTour();
                    if (listChiTietTour.Count() > 0)
                    {
                        ChiTietTour tempChiTiet = listChiTietTour.First();
                        if (tempChiTiet != null)
                        {
                            chiTietTour.MaChiTietTour = tempChiTiet.MaChiTietTour;
                            listChiTietTour.RemoveAt(0);
                        }
                    }
                    chiTietTour.diaDiem = diaDiemCuaTour.ToArray()[i];
                    chiTietTour.touris = tourisAfterUpdate;
                    chiTietTour.ThuTu = i + 1;
                    context.ChiTietTour.AddOrUpdate(chiTietTour);
                }
                context.ChiTietTour.RemoveRange(listChiTietTour);
            }
            context.Touris.AddOrUpdate(tourisAfterUpdate);
        }

        private void LoadDataOfTourisFromDataBase(Touris touris)
        {
            if (touris.Gias != null)
            {
                danhSachGia = touris.Gias.ToList();
                foreach (Gia gia in danhSachGia)
                {
                    Console.WriteLine(gia.MaGia);
                }
            }
            else danhSachGia = new List<Gia>();
            //IEnumerable<ChiTietTour> chiTietTours = duLichContext.ChiTietTour.Where(c => c.MaTour == touris.Id).OrderBy(d => d.ThuTu).ToList();
            IEnumerable<ChiTietTour> chiTietTours = touris.ChiTietTours;
            listChiTietTour = new List<ChiTietTour>();
            diaDiemCuaTour = new List<DiaDiem>();
            if (chiTietTours != null)
            {
                foreach (ChiTietTour ch in chiTietTours)
                {
                    diaDiemCuaTour.Add(ch.diaDiem);
                }
                listChiTietTour.AddRange(chiTietTours.ToList());
            }

        }

        public void onThemGia(Gia gia, Touris touris)
        {
            context.Gia.AddOrUpdate(gia);
            context.SaveChangesAsync().ContinueWith(task =>
            {
                if (userControl is ChiTietTouris)
                {
                    LoadDataOfTourisFromDataBase(touris);
                    panel_main_content.Invoke((MethodInvoker)delegate
                    {
                        userControl = new ChiTietTouris(touris, listLoais, danhSachGia, listDiaDiems, diaDiemCuaTour, this);
                        panel_main_content.Controls.Clear();
                        panel_main_content.Controls.Add(userControl);
                    });
                }
            });

        }

        public void onSuaGia(Gia gia, Touris touris)
        {
            context.Gia.AddOrUpdate(gia);
            context.SaveChangesAsync().ContinueWith(task =>
            {
                if (userControl is ChiTietTouris)
                {
                    LoadDataOfTourisFromDataBase(touris);
                    panel_main_content.Invoke((MethodInvoker)delegate
                    {
                        userControl = new ChiTietTouris(touris, listLoais, danhSachGia, listDiaDiems, diaDiemCuaTour, this);
                        panel_main_content.Controls.Clear();
                        panel_main_content.Controls.Add(userControl);
                    });
                }
            });

        }

        public void onXoaGia(Gia gia, Touris touris)
        {
            context.Gia.Remove(gia);
            context.SaveChangesAsync().ContinueWith(task =>
            {
                if (userControl is ChiTietTouris)
                {
                    LoadDataOfTourisFromDataBase(touris);
                    panel_main_content.Invoke((MethodInvoker)delegate
                    {
                        userControl = new ChiTietTouris(touris, listLoais, danhSachGia, listDiaDiems, diaDiemCuaTour, this);
                        panel_main_content.Controls.Clear();
                        panel_main_content.Controls.Add(userControl);
                    });
                }
            });

        }

        public void onHuyGia()
        {
        }

        public void onCapNhatDiaDiem(Touris touris, List<DiaDiem> newDiaDiemCuaTour)
        {
            //if (newDiaDiemCuaTour.Count() != 0)
            //     {
            //   if (diaDiemCuaTour.Count > 0)
            // {
            //   for (int i = 0; i < diaDiemCuaTour.Count(); i++)

            //     Console.WriteLine("dia diem " + diaDiemCuaTour.ToArray()[i].TenDiaDiem);
            //   ChiTietTour chiTietTour = new ChiTietTour();
            // if (listChiTietTour.Count() > 0)
            /**
             * {
                ChiTietTour tempChiTiet = listChiTietTour.First();
                if (tempChiTiet != null)
                {
                    chiTietTour.MaChiTietTour = tempChiTiet.MaChiTietTour;
                    listChiTietTour.RemoveAt(0);
                }
            }
            chiTietTour.diaDiem = diaDiemCuaTour.ToArray()[i];
            chiTietTour.touris = touris;
            chiTietTour.ThuTu = i + 1;
            duLichContext.ChiTietTour.AddOrUpdate(chiTietTour);
        }
    }
  //  else
    //{
      //  for (int i = 0; i < newDiaDiemCuaTour.Count(); i++)
        //{
          //  ChiTietTour chiTietTour = new ChiTietTour();
            //chiTietTour.diaDiem = newDiaDiemCuaTour.ToArray()[i];
            //chiTietTour.touris = touris;
            //chiTietTour.ThuTu = i + 1;
            //duLichContext.ChiTietTour.AddOrUpdate(chiTietTour);
       // }
   // }

//            }
foreach (ChiTietTour chiTiet in listChiTietTour) {

    Console.WriteLine(chiTiet.diaDiem.TenDiaDiem);
}
            */
            context.ChiTietTour.RemoveRange(listChiTietTour);
            for (int i = 0; i < newDiaDiemCuaTour.Count(); i++)
            {
                ChiTietTour chiTietTour = new ChiTietTour();
                chiTietTour.diaDiem = newDiaDiemCuaTour.ToArray()[i];
                chiTietTour.touris = touris;
                chiTietTour.ThuTu = i + 1;
                context.ChiTietTour.AddOrUpdate(chiTietTour);
            }
            context.SaveChangesAsync().ContinueWith(task =>
            {
                LoadDataOfTourisFromDataBase(touris);
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    userControl = new ChiTietTouris(touris, listLoais, danhSachGia, listDiaDiems, diaDiemCuaTour, this);
                    panel_main_content.Controls.Clear();
                    panel_main_content.Controls.Add(userControl);
                });
            });

        }

        public void onChiTietTourXoaTourClick(Touris currentTouris)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa Touris với mã là :" + currentTouris.Id, "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                context.Touris.Remove(currentTouris);
                context.SaveChangesAsync().ContinueWith(task =>
                {
                    LoadDataFromDataBase();
                    panel_main_content.Invoke((MethodInvoker)delegate
                    {
                        panel_main_content.Controls.Clear();
                        panel_main_content.Controls.Add(new DanhSachTour(listTouris, listLoais, this));
                    });
                });
            }
        }
        private void btn_quanlytour_Click(object sender, EventArgs e)
        {
            LoadDataFromDataBase();
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(new DanhSachTour(listTouris, listLoais, this));
        }

        private void btn_taotour_Click(object sender, EventArgs e)
        {
            userControl = new ChiTietTouris(null, listLoais, Enumerable.Empty<Gia>(), listDiaDiems, Enumerable.Empty<DiaDiem>().ToList(), this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onTourSelected(Touris touris)
        {
            LoadDataOfTourisFromDataBase(touris);
            userControl = new ChiTietTouris(touris, listLoais, danhSachGia, listDiaDiems.ToList(), diaDiemCuaTour, this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }
    }

}
/**
 * Quản Lý Đoàn
 */
namespace DuLich
{
    public partial class ManHinhChinh : DanhSachDoan.IDanhSachDoanListener,
        ChiTietKhach.IChiTietKhachListener, ChiTietDoan.IChiTietDoanListener, DanhSachPhanCong.IDanhSachPhanCongListener,
        ChiTietPhanCong.IChiTietPhanCongListener, SelectKhach.ISelectKhachListener,DanhSachChiPhi.IDanhSachChiPhiListener,ChiTietChiPhi.IChiTietChiPhiListener
    {
        private void button1_Click(object sender, EventArgs e)
        {
            LoadDataFromDataBase();
            userControl = new DanhSachDoan(doans, listTouris, this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }


        private void btn_taodoan_Click(object sender, EventArgs e)
        {
            userControl = new ChiTietDoan(new Doan(), listTouris, danhSachPhanCong,danhSachChiPhi, null, null, this, this, this,this);
            //userControl = new ChiTietTouris(null, listLoais, Enumerable.Empty<Gia>(), listDiaDiems, Enumerable.Empty<DiaDiem>().ToList(), this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onChiTietDoanClick_CapNhat(Doan doanSauKhiCapNhat)
        {
            context.Doans.AddOrUpdate(doanSauKhiCapNhat);
            context.SaveChangesAsync().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    userControl = new ChiTietDoan(doans.LastOrDefault(), listTouris, danhSachPhanCong, danhSachChiPhi, null, null, this, this, this,this);
                    //userControl = new ChiTietTouris(null, listLoais, Enumerable.Empty<Gia>(), listDiaDiems, Enumerable.Empty<DiaDiem>().ToList(), this);
                    panel_main_content.Controls.Clear();
                    panel_main_content.Controls.Add(userControl);
                });
            });
        }

        public void onChiTietDoanClick_Xoa(Doan doanCanXoa)
        {
            /**
             * Chỗ này nên hỏi trước khi xóa
             */
            context.Doans.Remove(doanCanXoa);
            context.SaveChangesAsync().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    userControl = new DanhSachKhach(khaches, this);
                    panel_main_content.Controls.Clear();
                    panel_main_content.Controls.Add(userControl);
                });
            });
        }

        public void onDanhSachDoan_DoanSelectedIndex(int position)
        {
            Doan selectedDoan = doans.ToArray()[position];
            userControl = new ChiTietDoan(selectedDoan, listTouris,
                danhSachPhanCong.Where(c => c.Doan.Id == selectedDoan.Id).ToList(),
                danhSachChiPhi.Where(c => c.Doan.Id == selectedDoan.Id).ToList(),
                khaches,
                khaches.Where(b => context.DoanKhachs.Where(c => c.Khach.KhachId == b.KhachId && c.Doan.Id == selectedDoan.Id).Count() > 0).ToList(), this, this, this, this); ;
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onDanhSachPhanCongThemClick(Doan doanHienTai)
        {
            PhanCong phanCong = new PhanCong();
            phanCong.Doan = doanHienTai;
            userControl = new ChiTietPhanCong(phanCong, danhSachNhanVien, this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onDanhSachPhanCongSuaClick(PhanCong phanCong)
        {
            userControl = new ChiTietPhanCong(phanCong, danhSachNhanVien, this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onDanhSachPhanCongXoaClick(PhanCong phanCong)
        {
            context.PhanCongs.Remove(phanCong);
            context.SaveChangesAsync().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    userControl = new DanhSachDoan(doans, listTouris, this);
                    panel_main_content.Controls.Clear();
                    panel_main_content.Controls.Add(userControl);
                });
            });
        }

        public void onLuuClick(PhanCong phanCong)
        {
            context.PhanCongs.AddOrUpdate(phanCong);
            context.SaveChangesAsync().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    userControl = new DanhSachDoan(doans, listTouris, this);
                    panel_main_content.Controls.Clear();
                    panel_main_content.Controls.Add(userControl);
                });
            });
        }

        public void onHuyClick()
        {
            userControl = new DanhSachDoan(doans, listTouris, this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onSelectKhach_LuuClick(Doan doanHienTai, List<Khach> danhSachKhachTrongDoanUpdate)
        {
            context.DoanKhachs.RemoveRange(context.DoanKhachs.Where(c => c.Doan.Id == doanHienTai.Id).ToList());
            foreach (Khach khach in danhSachKhachTrongDoanUpdate)
            {
                DoanKhach doanKhach = new DoanKhach();
                doanKhach.Doan = doanHienTai;
                doanKhach.Khach = khach;
                context.DoanKhachs.Add(doanKhach);
            }
            context.SaveChangesAsync().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    userControl = new DanhSachDoan(doans, listTouris, this);
                    panel_main_content.Controls.Clear();
                    panel_main_content.Controls.Add(userControl);
                });
            });
        }

        public void onDanhSachChiPhi_ThemClick(Doan doanHienTai)
        {
            ChiPhi chiPhi = new ChiPhi();
            chiPhi.Doan = doanHienTai;
            userControl = new ChiTietChiPhi(chiPhi, danhSachLoaiChiPhi, this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onDanhSachChiPhi_SuaClick(ChiPhi chiPhi)
        {
            userControl = new ChiTietChiPhi(chiPhi, danhSachLoaiChiPhi, this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onDanhSachChiPhi_XoaClick(ChiPhi chiPhi)
        {
            context.ChiPhis.Remove(chiPhi);
            context.SaveChangesAsync().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    userControl = new DanhSachDoan(doans, listTouris, this);
                    panel_main_content.Controls.Clear();
                    panel_main_content.Controls.Add(userControl);
                });
            });
        }

        public void onLuuClick(ChiPhi chiPhi)
        {
            context.ChiPhis.AddOrUpdate(chiPhi);
            context.SaveChangesAsync().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    userControl = new DanhSachDoan(doans, listTouris, this);
                    panel_main_content.Controls.Clear();
                    panel_main_content.Controls.Add(userControl);
                });
            });
        }
    }
}

/**
 * Quản Lý Địa Điểm
 */
namespace DuLich
{
    public partial class ManHinhChinh : QuanLyDiaDiem.IQuanLyDiaDiem, ChiTietDiaDiem.IChiTietDiaDiemListener
    {

        private void btn_quanlydiadiem_Click(object sender, EventArgs e)
        {
            userControl = new QuanLyDiaDiem(listDiaDiems, this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onThemDiaDiem()
        {
            userControl = new ChiTietDiaDiem(new DiaDiem(), this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onXoaDiaDiem(DiaDiem diaDiem)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa Địa điểm với mã là :" + diaDiem.MaDienDiem, "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                String message = "";
                List<ChiTietTour> chiTietToursTrungDiaDiem = context.ChiTietTour.Where(c => c.diaDiem.MaDienDiem == diaDiem.MaDienDiem).ToList();
                if (chiTietToursTrungDiaDiem.Count > 0)
                {
                    foreach (ChiTietTour chiTietTour in chiTietToursTrungDiaDiem)
                    {
                        message += chiTietTour.touris.Name + " ";
                    }
                    DialogResult innerDialogResukt = MessageBox.Show("Địa điểm " + diaDiem.TenDiaDiem + " đang được dùng ở " + message + " vui lòng xóa những Tour trên trước");
                }
                else
                {
                    context.DiaDiem.Remove(diaDiem);
                    context.SaveChangesAsync().ContinueWith(task =>
                    {
                        LoadDataFromDataBase();
                        panel_main_content.Invoke((MethodInvoker)delegate
                        {
                            userControl = new QuanLyDiaDiem(listDiaDiems, this);
                            panel_main_content.Controls.Clear();
                            panel_main_content.Controls.Add(userControl);
                        });
                    });
                }

            }
        }

        public void onSuaDiaDiem(DiaDiem diaDiem)
        {
            userControl = new ChiTietDiaDiem(diaDiem, this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onLuuDiaDiem(DiaDiem diaDiem)
        {
            context.DiaDiem.AddOrUpdate(diaDiem);
            context.SaveChangesAsync().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    userControl = new QuanLyDiaDiem(listDiaDiems, this);
                    panel_main_content.Controls.Clear();
                    panel_main_content.Controls.Add(userControl);
                });
            });
        }

        public void onHuyDiaDiemClick()
        {
            LoadDataFromDataBase();
            userControl = new QuanLyDiaDiem(listDiaDiems, this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }
    }
}
/**
 *  Quản Lý Khách
 */
namespace DuLich
{
    public partial class ManHinhChinh : DanhSachKhach.IDanhSachKhachListener
    {
        private void button2_Click(object sender, EventArgs e)
        {
            LoadDataFromDataBase();
            userControl = new DanhSachKhach(khaches, this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onDanhSachKhachThemClick()
        {
            Khach khach = new Khach();
            userControl = new ChiTietKhach(khach, this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onDanhSachKhachSuaClick(Khach doan)
        {
            userControl = new ChiTietKhach(doan, this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onDanhSachKhachXoaClick(Khach doan)
        {
            context.Khaches.Remove(doan);
            context.SaveChangesAsync().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    userControl = new DanhSachKhach(khaches, this);
                    panel_main_content.Controls.Clear();
                    panel_main_content.Controls.Add(userControl);
                });
            });
        }

        public void onLuuKhachClick(Khach khach)
        {
            context.Khaches.AddOrUpdate(khach);
            context.SaveChangesAsync().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    userControl = new DanhSachKhach(khaches, this);
                    panel_main_content.Controls.Clear();
                    panel_main_content.Controls.Add(userControl);
                });
            });
        }

        public void onHuyKhachClick()
        {
            LoadDataFromDataBase();
            userControl = new DanhSachKhach(khaches, this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

    }
}
/**
 * Quản Lý Nhân Viên 
 */
namespace DuLich
{
    public partial class ManHinhChinh : DanhSachNhanVien.IDanhSachNhanVienListener,ChiTietNhanVien.IChiTietNhanVienListener{
    private void btn_quanlynhanvien_Click(object sender, EventArgs e)
    {
        LoadDataFromDataBase();
        userControl = new DanhSachNhanVien(danhSachNhanVien, this);
        panel_main_content.Controls.Clear();
        panel_main_content.Controls.Add(userControl);
    }
    public void onDanhSachNhanVien_SuaClick(NhanVien nhanVien)
    {
        userControl = new ChiTietNhanVien(nhanVien, this);
        panel_main_content.Controls.Clear();
        panel_main_content.Controls.Add(userControl);
    }

    public void onDanhSachNhanVien_ThemClick()
    {
       NhanVien nhanVien = new NhanVien();
       userControl = new ChiTietNhanVien(nhanVien, this);
       panel_main_content.Controls.Clear();
       panel_main_content.Controls.Add(userControl);
    }

    public void onDanhSachNhanVien_XoaClick(NhanVien nhanVien)
    {
            context.NhanViens.Remove(nhanVien);
            context.SaveChangesAsync().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    userControl = new DanhSachNhanVien(danhSachNhanVien, this);
                    panel_main_content.Controls.Clear();
                    panel_main_content.Controls.Add(userControl);
                });
            });
        }
    public void onChiTietNhanVien_LuuClick(NhanVien nhanVien)
    {
            context.NhanViens.AddOrUpdate(nhanVien);
            context.SaveChangesAsync().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    userControl = new DanhSachNhanVien(danhSachNhanVien, this);
                    panel_main_content.Controls.Clear();
                    panel_main_content.Controls.Add(userControl);
                });
            });
        }

    public void onChiTietNhanVien_HuyClick()
        {
            LoadDataFromDataBase();
            userControl = new DanhSachNhanVien(danhSachNhanVien, this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }
    }
}