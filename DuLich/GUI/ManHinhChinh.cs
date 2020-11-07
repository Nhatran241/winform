using DuLich.BUS;
using DuLich.DAL;
using DuLich.GUI.QuanLyChiPhi;
using DuLich.GUI.QuanLyDiaDiem;
using DuLich.GUI.QuanLyDoan;
using DuLich.GUI.QuanLyKhach;
using DuLich.GUI.QuanLyNhanVien;
using DuLich.GUI.QuanLyPhanCong;
using DuLich.GUI.QuanLyTouris;
using DuLich.GUI.ThongKe;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DuLich
{
    public partial class ManHinhChinh : Form
       
    {
        private UserControl userControl;
        public ManHinhChinh()
        {
            InitializeComponent();
            OnManHinhChinhLoad();
        }
     
        private void OnManHinhChinhLoad()
        {
            panel_main_content.Controls.Add(new DanhSachTour(TourDal.GetAll(), LoaiDal.GetAll(), this));
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

        public void onChiTietTourCapNhatClick(Tour tourisAfterUpdate)
        {
            tourisAfterUpdate.AddOrUpdate().ContinueWith(task =>
            {
                userControl = new ChiTietTouris(tourisAfterUpdate,
                    LoaiDal.GetAll(),
                    new List<Gia>(),
                    DiaDiemDal.GetAll(),
                    new List<DiaDiem>(), this, this,this);
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    panel_main_content.Controls.Clear();
                    panel_main_content.Controls.Add(userControl);
                });
            });
          
        }


        public void onChiTietTourXoaTourClick(Tour currentTouris)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa Touris với mã là :" + currentTouris.Id, "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                List<Doan> doanDangKhaiThac = currentTouris.GetListDoanOfTour();
                if (doanDangKhaiThac.Count > 0)
                {
                    String message = "";
                    foreach (Doan doan in doanDangKhaiThac)
                    {
                        message += doan.Name + " /n";
                    }
                    DialogResult innerDialogResukt = MessageBox.Show("Tour này đang được sử dụng ở các đoàn : /n" + message + " nên không thể xóa tour này");
                }
                else
                {
                    currentTouris.Delete().ContinueWith(task =>
                    {
                        panel_main_content.Invoke((MethodInvoker)delegate
                        {
                            panel_main_content.Controls.Clear();
                            panel_main_content.Controls.Add(new DanhSachTour(TourDal.GetAll(), LoaiDal.GetAll(), this));
                        });
                    });
                }
            }
        }
        private void btn_quanlytour_Click(object sender, EventArgs e)
        {
            panel_main_content.Controls.Clear();
            panel_main_content.SuspendLayout();
            panel_main_content.Controls.Add(new DanhSachTour(TourDal.GetAll(), LoaiDal.GetAll(), this));
            panel_main_content.ResumeLayout();
        }


        public void onDanhSachTour_TourDoubleClick(Tour touris)
        {
          
            userControl = new ChiTietTouris(touris,
                LoaiDal.GetAll(),
                touris.GetListGiaOfTour(),
                DiaDiemDal.GetAll(),
                touris.GetListDiaDiemOfTour(), this, this,this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onDanhSachTour_ThemClick()
        {
            userControl = new ChiTietTouris(null, LoaiDal.GetAll(), new List<Gia>(), DiaDiemDal.GetAll(), new List<DiaDiem>(), this, this,this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onDanhSachTour_XoaClick(Tour tour)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa Touris với mã là :" + tour.Id, "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                List<Doan> doanDangKhaiThac = tour.GetListDoanOfTour();
                if(doanDangKhaiThac.Count > 0)
                {
                    String message = "";
                    foreach (Doan doan in doanDangKhaiThac)
                    {
                        message += doan.Name + " \n";
                    }
                    DialogResult innerDialogResukt = MessageBox.Show("Tour này đang được sử dụng ở các đoàn : \n "+message+" nên không thể xóa tour này");
                }
                else
                {
                    tour.Delete().ContinueWith(task =>
                    {
                        panel_main_content.Invoke((MethodInvoker)delegate
                        {
                            panel_main_content.Controls.Clear();
                            panel_main_content.Controls.Add(new DanhSachTour(TourDal.GetAll(), LoaiDal.GetAll(), this));
                        });
                    });
                }
            }
        }
    }

}

/**
 * Quản Lý Tour - Danh Sách Chọn Địa ĐIểm
 */
namespace DuLich
{
    public partial class ManHinhChinh : DanhSachChonDiaDiem.IDanhSachChonDiaDiemListener
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

        public void onDanhSachChonDiaDiem_LuuClick(Tour tourHienTai, List<DiaDiem> danhSachDiaDiemTrongDoanUpdate)
        {
            tourHienTai.DeleteAllChiTietTour();
            tourHienTai.UpdateListDiaDiemTour(danhSachDiaDiemTrongDoanUpdate).ContinueWith(task =>
            {
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    (userControl as ChiTietTouris).UpdateData(
                          tourHienTai.GetListGiaOfTour(),
                          tourHienTai.GetListDiaDiemOfTour());
                });
            });
        }
    }

}
/**
 * Quản Lý Tour - Danh Sach Gia
 */
namespace DuLich
{
    public partial class ManHinhChinh : DanhSachGia.IDanhSachGiaListener, ChiTietGia.IChiTietGiaListener
    {

        public void onDanhSachGiaThemClick(Tour tourHienTai)
        {
            panel_main_content.Controls.Clear();
            Gia gia = new Gia();
            gia.touris = tourHienTai;
            panel_main_content.Controls.Add(new ChiTietGia(gia, this));
        }

        public void onDanhSachGiaSuaClick(Gia gia)
        {
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(new ChiTietGia(gia, this));
        }

        public void onDanhSachGiaXoaClick(Tour tourHienTai,Gia gia)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa Giá với mã là :" + gia.MaGia, "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                List<Doan> doanDangKhaiThac = tourHienTai.GetListDoanOfTour();
                if (doanDangKhaiThac.Count > 0)
                {
                    String message = "";
                    foreach (Doan doan in doanDangKhaiThac)
                    {
                        message += doan.Name + " \n";
                    }
                    DialogResult innerDialogResukt = MessageBox.Show("Giá này đang được áp dụng ở các đoàn : \n" + message + " nên không thể xóa được giá này");
                }
                else
                {
                    gia.Delete().ContinueWith(task =>
                    {
                        if (userControl is ChiTietTouris)
                        {
                            panel_main_content.Invoke((MethodInvoker)delegate
                            {
                                panel_main_content.Invoke((MethodInvoker)delegate
                                {
                                    (userControl as ChiTietTouris).UpdateData(tourHienTai.GetListGiaOfTour(), tourHienTai.GetListDiaDiemOfTour());
                                    panel_main_content.Controls.Clear();
                                    panel_main_content.Controls.Add(userControl);
                                });
                            });
                        }
                    });
                }
            }

        }

        public void onChiTietGia_LuuClick(Gia gia)
        {
            gia.AddOrUpdate().ContinueWith(task =>
            {
                if (userControl is ChiTietTouris)
                {
                    panel_main_content.Invoke((MethodInvoker)delegate
                    {
                        (userControl as ChiTietTouris).UpdateData(gia.touris.GetListGiaOfTour(),gia.touris.GetListDiaDiemOfTour());
                        panel_main_content.Controls.Clear();
                        panel_main_content.Controls.Add(userControl);
                    });
                }
            });
        }

        public void onChiTietGia_HuyClick()
        {
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
    public partial class ManHinhChinh : DanhSachDoan.IDanhSachDoanListener
    {
        private void button1_Click(object sender, EventArgs e)
        {
            userControl = new DanhSachDoan(DoanDal.GetAll(), TourDal.GetAll(),NhanVienDal.GetAll(),KhachDal.GetAll(), this);
            panel_main_content.SuspendLayout();
            panel_main_content.Controls.Clear();
            panel_main_content.ResumeLayout();
            panel_main_content.Controls.Add(userControl);
        }



        public void onDanhSachDoan_DoanDoubleClick(Doan doan)
        {
            List<Tour> listTourHasPrice = TourDal.GetListTourHasPrice();
            userControl = new ChiTietDoan(doan,listTourHasPrice,
                doan.GetListPhanCong(),
                doan.GetListChiPhi(),
                KhachDal.GetAll(),
                doan.GetListKhach(), this, this, this, this); ;
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onDanhSachDoan_ThemClick()
        {
            userControl = new ChiTietDoan(new Doan(), TourDal.GetListTourHasPrice(), null, null, null, null, this, this, this, this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onDanhSachDoan_XoaClick(Doan doan)
        {
            doan.Delete().ContinueWith(task =>
            {
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    userControl = new DanhSachKhach(KhachDal.GetAll(), this);
                    panel_main_content.Controls.Clear();
                    panel_main_content.Controls.Add(userControl);
                });
            });
        }
    }
}

/**
 * Quản Lý Đoàn - Chi Tiết Đoàn -Thêm- Cập Nhật - Xóa
 */

namespace DuLich
{
    public partial class ManHinhChinh : ChiTietDoan.IChiTietDoanListener
    {
        public void onChiTietDoanClick_CapNhat(Doan doanSauKhiCapNhat)
        {
            doanSauKhiCapNhat.AddOrUpdate().ContinueWith(task =>
            {
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    userControl = new ChiTietDoan(
                        doanSauKhiCapNhat,
                        TourDal.GetListTourHasPrice(),
                        doanSauKhiCapNhat.GetListPhanCong(),
                        doanSauKhiCapNhat.GetListChiPhi(),
                        KhachDal.GetAll(),
                        doanSauKhiCapNhat.GetListKhach(),this,this,this,this);
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
            doanCanXoa.Delete().ContinueWith(task =>
            {
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    userControl = new DanhSachDoan(DoanDal.GetAll(),TourDal.GetAll(),NhanVienDal.GetAll(),KhachDal.GetAll(), this);
                    panel_main_content.Controls.Clear();
                    panel_main_content.Controls.Add(userControl);
                });
            });
        }


    

    }
}

/**
 * Quản Lý Đoàn - Chi Phí
 */
namespace DuLich
{
    public partial class ManHinhChinh : DanhSachChiPhi.IDanhSachChiPhiListener, ChiTietChiPhi.IChiTietChiPhiListener
    {
        ChiTietChiPhi formChiPhi;
        public void onDanhSachChiPhi_ThemClick(Doan doanHienTai)
        {
            ChiPhi chiPhi = new ChiPhi();
            chiPhi.Doan = doanHienTai;
            formChiPhi = new ChiTietChiPhi(chiPhi, LoaiChiPhiDal.GetAll(), this);
            formChiPhi.ShowDialog();
        }

        public void onDanhSachChiPhi_SuaClick(ChiPhi chiPhi)
        {
            formChiPhi = new ChiTietChiPhi(chiPhi, LoaiChiPhiDal.GetAll(), this);
            formChiPhi.ShowDialog();
        }

        public void onDanhSachChiPhi_XoaClick(Doan doanHienTai,ChiPhi chiPhi)
        {
            doanHienTai.DeleteChiPhi(chiPhi).ContinueWith(task =>
            {
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    (userControl as ChiTietDoan).UpdateData(
                          doanHienTai.GetListPhanCong(),
                          doanHienTai.GetListChiPhi(),
                          KhachDal.GetAll(),
                          doanHienTai.GetListKhach()); ;
                });
            });
        }

        public void onChiTietChiPhi_LuuClick(Doan doanHienTai,ChiPhi chiPhi)
        {
            doanHienTai.AddOrUpdateChiPhi(chiPhi).ContinueWith(task =>
            {
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    formChiPhi.Close();
                    (userControl as ChiTietDoan).UpdateData(
                          doanHienTai.GetListPhanCong(),
                          doanHienTai.GetListChiPhi(),
                          KhachDal.GetAll(),
                          doanHienTai.GetListKhach());
                    panel_main_content.Controls.Clear();
                    panel_main_content.Controls.Add(userControl);
                });

            });
        }
        public void onChiTietChiPhi_HuyClick()
        {
            formChiPhi.Close();
        }

    }
}
/**
 * Quản Lý Đoàn - Phân Công
 */
namespace DuLich
{
    public partial class ManHinhChinh : DanhSachPhanCong.IDanhSachPhanCongListener,
        FromPhanCong.IChiTietPhanCongListener
    {
        FromPhanCong form;
        public void onDanhSachPhanCongThemClick(Doan doanHienTai)
        {
            PhanCong phanCong = new PhanCong();
            phanCong.Doan = doanHienTai;
            form = new FromPhanCong(phanCong,NhanVienDal.GetAll(),this);
            form.ShowDialog();
        }

        public void onDanhSachPhanCongSuaClick(PhanCong phanCong)
        {
            form = new FromPhanCong(phanCong, NhanVienDal.GetAll(), this);
            form.ShowDialog();
        }

        public void onDanhSachPhanCongXoaClick(Doan doanHienTai,PhanCong phanCong)
        {
            doanHienTai.DeletePhanCong(phanCong).ContinueWith(task =>
            {
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    (userControl as ChiTietDoan).UpdateData(
                          doanHienTai.GetListPhanCong(),
                          doanHienTai.GetListChiPhi(),
                          KhachDal.GetAll(),
                          doanHienTai.GetListKhach());
                });
            });
        }

        public void onChiTietPhanCong_LuuClick(Doan doanHienTai,PhanCong phanCong)
        {
            doanHienTai.AddOrUpdatePhanCong(phanCong).ContinueWith(task =>
            {
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    form.Close();
                    (userControl as ChiTietDoan).UpdateData(
                         doanHienTai.GetListPhanCong(),
                         doanHienTai.GetListChiPhi(),
                         KhachDal.GetAll(),
                         doanHienTai.GetListKhach());
                    panel_main_content.Controls.Clear();
                    panel_main_content.Controls.Add(userControl);

                });
            });
        }
        public void onChiTietPhanCong_HuyClick()
        {
            form.Close();
        }

    }
}
/**
 * Quản Lý Đoàn - Khách
 */

namespace DuLich
{
    public partial class ManHinhChinh :  SelectKhach.ISelectKhachListener
    {
        public void onSelectKhach_LuuClick(Doan doanHienTai, List<Khach> danhSachKhachTrongDoanUpdate)
        {
            doanHienTai.DeleteAllKhach();
            doanHienTai.UpdateListDoanKhach(danhSachKhachTrongDoanUpdate).ContinueWith(task =>
            {
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    (userControl as ChiTietDoan).UpdateData(
                        doanHienTai.GetListPhanCong(),
                        doanHienTai.GetListChiPhi(),
                        KhachDal.GetAll(),
                        doanHienTai.GetListKhach());
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
    public partial class ManHinhChinh : DanhSachDiaDiem.IDanhSachDiaDiemListener, ChiTietDiaDiem.IChiTietDiaDiemListener
    {

        private void btn_quanlydiadiem_Click(object sender, EventArgs e)
        {
            userControl = new DanhSachDiaDiem(DiaDiemDal.GetAll(), this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onDanhSachDiaDiem_ThemClick()
        {
            userControl = new ChiTietDiaDiem(new DiaDiem(), this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onDanhSachDiaDiem_XoaClick(DiaDiem diaDiem)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa Địa điểm với mã là :" + diaDiem.MaDienDiem, "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                String message = "";
                List<Tour> listTour = diaDiem.GetListTour();
                if (listTour.Count> 0)
                {
                    foreach (Tour tour in listTour)
                    {
                        message += tour.Name + " \n";
                    }
                    DialogResult innerDialogResukt = MessageBox.Show("Địa điểm " + diaDiem.TenDiaDiem + " đang được dùng ở các tour \n" + message + " vui lòng xóa những Tour trên trước");
                }
                else
                {
                    diaDiem.Delete().ContinueWith(task =>
                    {
                        panel_main_content.Invoke((MethodInvoker)delegate
                        {
                            userControl = new DanhSachDiaDiem(DiaDiemDal.GetAll(), this);
                            panel_main_content.Controls.Clear();
                            panel_main_content.Controls.Add(userControl);
                        });
                    });
                }

            }
        }

        public void onDanhSachDiaDiem_SuaClick(DiaDiem diaDiem)
        {
            userControl = new ChiTietDiaDiem(diaDiem, this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onLuuDiaDiem(DiaDiem diaDiem)
        {
            diaDiem.AddOrUpdate().ContinueWith(task =>
            {
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    userControl = new DanhSachDiaDiem(DiaDiemDal.GetAll(), this);
                    panel_main_content.Controls.Clear();
                    panel_main_content.Controls.Add(userControl);
                });
            });
        }

        public void onHuyDiaDiemClick()
        {
            userControl = new DanhSachDiaDiem(DiaDiemDal.GetAll(), this);
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
    public partial class ManHinhChinh : DanhSachKhach.IDanhSachKhachListener,ChiTietKhach.IChiTietKhachListener
    {
        private void button2_Click(object sender, EventArgs e)
        {
            userControl = new DanhSachKhach(KhachDal.GetAll(), this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onLuuKhachClick(Khach khach)
        {
            khach.AddOrUpdate().ContinueWith(task =>
            {
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    userControl = new DanhSachKhach(KhachDal.GetAll(), this);
                    panel_main_content.Controls.Clear();
                    panel_main_content.Controls.Add(userControl);
                });
            });
        }

        public void onHuyKhachClick()
        {
            userControl = new DanhSachKhach(KhachDal.GetAll(), this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onDanhSachKhach_ThemClick() {
            Khach khach = new Khach();
            userControl = new ChiTietKhach(khach, this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onDanhSachKhach_SuaClick(Khach khach)
        {
            userControl = new ChiTietKhach(khach, this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onDanhSachKhach_XoaClick(Khach khach)
        {
            khach.Delete().ContinueWith(task =>
            {
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    userControl = new DanhSachKhach(KhachDal.GetAll(), this);
                    panel_main_content.Controls.Clear();
                    panel_main_content.Controls.Add(userControl);
                });
            });
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
        userControl = new DanhSachNhanVien(NhanVienDal.GetAll(), this);
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
            nhanVien.Delete().ContinueWith(task =>
            {
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    userControl = new DanhSachNhanVien(NhanVienDal.GetAll(), this);
                    panel_main_content.Controls.Clear();
                    panel_main_content.Controls.Add(userControl);
                });
            });
        }
    public void onChiTietNhanVien_LuuClick(NhanVien nhanVien)
    {
            nhanVien.AddOrUpdate().ContinueWith(task =>
            {
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    userControl = new DanhSachNhanVien(NhanVienDal.GetAll(), this);
                    panel_main_content.Controls.Clear();
                    panel_main_content.Controls.Add(userControl);
                });
            });
        }

    public void onChiTietNhanVien_HuyClick()
        {
            userControl = new DanhSachNhanVien(NhanVienDal.GetAll(), this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }
    }
}

/**
 * Thống Kê 
 */
namespace DuLich
{
    public partial class ManHinhChinh
    {
        private void btn_thongke_Click(object sender, EventArgs e)
        {

            userControl = new ThongKe(NhanVienDal.GetAll(),TourDal.GetAll(),DoanDal.GetAll(),KhachDal.GetAll());
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }
    }
}