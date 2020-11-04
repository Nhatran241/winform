using DuLich.DAL;
using DuLich.Entity;
using DuLich.GUI.QuanLyChiPhi;
using DuLich.GUI.QuanLyDoan;
using DuLich.GUI.QuanLyKhach;
using DuLich.GUI.QuanLyNhanVien;
using DuLich.GUI.QuanLyTouris;
using DuLich.GUI.ThongKe;
using DuLich.Model.Entity;
using DuLich.View;
using DuLich.View.QuanLyDiaDiem;
using DuLich.View.QuanLyDoan;
using DuLich.View.QuanLyPhanCong;
using DuLich.View.QuanLyTouris;
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
        private UserControl userControl;
        private List<Khach> danhSachKhac = new List<Khach>();
        private List<Doan> danhSachDoan = new List<Doan>();
        private List<PhanCong> danhSachPhanCong = new List<PhanCong>();
        private List<NhanVien> danhSachNhanVien = new List<NhanVien>();
        private List<Tour> danhSachTour = new List<Tour>();
        private List<Loai> danhSachLoai = new List<Loai>();
        private List<DiaDiem> danhSachDiaDiem = new List<DiaDiem>();
        private List<Gia> danhSachGia = new List<Gia>();
        private List<DoanKhach> danhSachDoanKhach = new List<DoanKhach>();
        private List<ChiPhi> danhSachChiPhi = new List<ChiPhi>();
        private List<LoaiChiPhi> danhSachLoaiChiPhi = new List<LoaiChiPhi>();
        /**
         * 3 Lớp
         */
        private TourDal tourDal = TourDal.GetTourDal();
        private KhachDal khachDal = KhachDal.GetInstance();
        private NhanVienDal nhanVienDal = NhanVienDal.GetInstance();
        private ChiPhiDal chiPhiDal = ChiPhiDal.GetInstance();
        private GiaDal giaDal = GiaDal.GetInstance();
        private DoanDal doanDal = DoanDal.GetInstance();
        private LoaiDal loaiDal = LoaiDal.GetInstance();
        private PhanCongDal phanCongDal = PhanCongDal.GetInstance();
        private DoanKhachDal doanKhachDal = DoanKhachDal.GetInstance();
        private DiaDiemDal diaDiemDal = DiaDiemDal.GetInstance();
        private LoaiChiPhiDal loaiChiPhiDal = LoaiChiPhiDal.GetInstance();
        private ChiTietTourDal chiTietTourDal = ChiTietTourDal.GetInstance();



        public ManHinhChinh()
        {
            InitializeComponent();
            OnManHinhChinhLoad();
        }
     
        private void OnManHinhChinhLoad()
        {
            LoadDataFromDataBase();
            panel_main_content.Controls.Add(new DanhSachTour(danhSachTour, danhSachLoai, this));
        }

        private void LoadDataFromDataBase()
        {
            /**
             * 3 lớp
             */
            danhSachTour = tourDal.GetAll();
            danhSachKhac = khachDal.GetAll();
            danhSachNhanVien = nhanVienDal.GetAll();
            danhSachGia = giaDal.GetAll();
            danhSachChiPhi = chiPhiDal.GetAll();
            danhSachDoan = doanDal.GetAll();
            danhSachLoai = loaiDal.GetAll();
            danhSachDiaDiem = diaDiemDal.GetAll();
            danhSachPhanCong = phanCongDal.GetAll();
            danhSachDoanKhach = doanKhachDal.GetAll();
            danhSachLoaiChiPhi = loaiChiPhiDal.GetAll();
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
            tourisAfterUpdate.AddOrUpdate();
            tourDal.Save().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                userControl = new ChiTietTouris(tourisAfterUpdate,
                    danhSachLoai,
                    new List<Gia>(),
                    danhSachDiaDiem,
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
                LoadDataFromDataBase();
                List<Doan> doanDangKhaiThac = danhSachDoan.Where(c => c.Touris.Id == currentTouris.Id).ToList();
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
                    currentTouris.Delete();
                    tourDal.Save().ContinueWith(task =>
                    {
                        LoadDataFromDataBase();
                        panel_main_content.Invoke((MethodInvoker)delegate
                        {
                            panel_main_content.Controls.Clear();
                            panel_main_content.Controls.Add(new DanhSachTour(danhSachTour, danhSachLoai, this));
                        });
                    });
                }
            }
        }
        private void btn_quanlytour_Click(object sender, EventArgs e)
        {
            LoadDataFromDataBase();
            panel_main_content.Controls.Clear();
            panel_main_content.SuspendLayout();
            panel_main_content.Controls.Add(new DanhSachTour(danhSachTour, danhSachLoai, this));
            panel_main_content.ResumeLayout();
        }


        public void onDanhSachTour_TourDoubleClick(Tour touris)
        {
            List<DiaDiem> danhSachDiaDiemCuaTor = new List<DiaDiem>();
            foreach(ChiTietTour chiTietTour in chiTietTourDal.GetAll().OrderBy(c=>c.ThuTu).Where(c=>c.touris.Id==touris.Id).ToList())
            {
                DiaDiem diaDiem = danhSachDiaDiem.Where(c => c.MaDienDiem == chiTietTour.diaDiem.MaDienDiem).First();
                if (!danhSachDiaDiemCuaTor.Contains(diaDiem))
                    danhSachDiaDiemCuaTor.Add(diaDiem);
            }
            List<Gia> danhSachGiaCuaTour = new List<Gia>();
            danhSachGiaCuaTour.AddRange(danhSachGia.Where(c => c.touris.Id == touris.Id).ToList());
            userControl = new ChiTietTouris(touris,
                danhSachLoai,
                danhSachGiaCuaTour,
                danhSachDiaDiem,
                danhSachDiaDiemCuaTor, this, this,this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onDanhSachTour_ThemClick()
        {
            userControl = new ChiTietTouris(null, danhSachLoai, new List<Gia>(), danhSachDiaDiem, new List<DiaDiem>(), this, this,this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onDanhSachTour_XoaClick(Tour tour)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa Touris với mã là :" + tour.Id, "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                LoadDataFromDataBase();
                List<Doan> doanDangKhaiThac = danhSachDoan.Where(c => c.Touris.Id == tour.Id).ToList();
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
                    tour.Delete();
                    tourDal.Save().ContinueWith(task =>
                    {
                        LoadDataFromDataBase();
                        panel_main_content.Invoke((MethodInvoker)delegate
                        {
                            panel_main_content.Controls.Clear();
                            panel_main_content.Controls.Add(new DanhSachTour(danhSachTour, danhSachLoai, this));
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
            if (tourHienTai.ChiTietTours != null)
                chiTietTourDal.DeleteRange(tourHienTai.ChiTietTours.ToList());
            for (int i = 0; i < danhSachDiaDiemTrongDoanUpdate.Count(); i++)
            {
                ChiTietTour chiTietTour = new ChiTietTour();
                chiTietTour.diaDiem = danhSachDiaDiemTrongDoanUpdate.ToArray()[i];
                chiTietTour.touris = tourHienTai;
                chiTietTour.ThuTu = i + 1;
                chiTietTour.AddOrUpdate();
            }
            chiTietTourDal.Save().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    List<DiaDiem> danhSachDiaDiemCuaTor = new List<DiaDiem>();
                    foreach (ChiTietTour chiTietTour in chiTietTourDal.GetAll().OrderBy(c => c.ThuTu).Where(c => c.touris.Id == tourHienTai.Id).ToList())
                    {
                        DiaDiem diaDiem = danhSachDiaDiem.Where(c => c.MaDienDiem == chiTietTour.diaDiem.MaDienDiem).First();
                        if (!danhSachDiaDiemCuaTor.Contains(diaDiem))
                            danhSachDiaDiemCuaTor.Add(diaDiem);
                    }

                    (userControl as ChiTietTouris).UpdateData(
                          danhSachGia.Where(c => c.touris.Id == tourHienTai.Id).ToList(),
                          danhSachDiaDiemCuaTor);
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
                LoadDataFromDataBase();
                List<Doan> doanDangKhaiThac = danhSachDoan.Where(c => c.GiaApDung.MaGia == gia.MaGia).ToList();
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
                    gia.Delete();
                    giaDal.Save().ContinueWith(task =>
                    {
                        if (userControl is ChiTietTouris)
                        {
                            LoadDataFromDataBase();
                            panel_main_content.Invoke((MethodInvoker)delegate
                            {
                                List<DiaDiem> danhSachDiaDiemCuaTor = new List<DiaDiem>();
                                foreach (ChiTietTour chiTietTour in chiTietTourDal.GetAll().OrderBy(c => c.ThuTu).Where(c => c.touris.Id == tourHienTai.Id).ToList())
                                {
                                    DiaDiem diaDiem = danhSachDiaDiem.Where(c => c.MaDienDiem == chiTietTour.diaDiem.MaDienDiem).First();
                                    if (!danhSachDiaDiemCuaTor.Contains(diaDiem))
                                        danhSachDiaDiemCuaTor.Add(diaDiem);
                                }
                                List<Gia> danhSachGiaCuaTour = new List<Gia>();
                                danhSachGiaCuaTour.AddRange(danhSachGia.Where(c => c.touris.Id == tourHienTai.Id).ToList());
                                panel_main_content.Invoke((MethodInvoker)delegate
                                {
                                    (userControl as ChiTietTouris).UpdateData(danhSachGiaCuaTour, danhSachDiaDiemCuaTor);
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
            gia.AddOrUpdate();
            giaDal.Save().ContinueWith(task =>
            {
                if (userControl is ChiTietTouris)
                {
                    LoadDataFromDataBase();
                    List<DiaDiem> danhSachDiaDiemCuaTor = new List<DiaDiem>();
                    foreach (ChiTietTour chiTietTour in ChiTietTourDal.GetInstance().GetAll().OrderBy(c => c.ThuTu).Where(c => c.touris.Id == gia.touris.Id).ToList())
                    {
                        DiaDiem diaDiem = danhSachDiaDiem.Where(c => c.MaDienDiem == chiTietTour.diaDiem.MaDienDiem).First();
                        if (!danhSachDiaDiemCuaTor.Contains(diaDiem))
                            danhSachDiaDiemCuaTor.Add(diaDiem);
                    }
                    List<Gia> danhSachGiaCuaTour = new List<Gia>();
                    danhSachGiaCuaTour.AddRange(danhSachGia.Where(c => c.touris.Id == gia.touris.Id).ToList());
                    panel_main_content.Invoke((MethodInvoker)delegate
                    {
                        (userControl as ChiTietTouris).UpdateData(danhSachGiaCuaTour,danhSachDiaDiemCuaTor);
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
            LoadDataFromDataBase();
            userControl = new DanhSachDoan(danhSachDoan, danhSachTour,danhSachNhanVien,danhSachKhac, this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }



        public void onDanhSachDoan_DoanDoubleClick(Doan doan)
        {
            List<Tour> listTourHasPrice = TourDal.GetTourDal().GetListTourHasPrice();
            userControl = new ChiTietDoan(doan,listTourHasPrice,
                danhSachPhanCong.Where(c => c.Doan.Id == doan.Id).ToList(),
                danhSachChiPhi.Where(c => c.Doan.Id == doan.Id).ToList(),
                danhSachKhac,
                danhSachKhac.Where(b => doanKhachDal.GetAll().Where(c => c.Khach.KhachId == b.KhachId && c.Doan.Id == doan.Id).Count() > 0).ToList(), this, this, this, this); ;
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onDanhSachDoan_ThemClick()
        {
            List<Tour> listTourHasPrice = TourDal.GetTourDal().GetListTourHasPrice();
            userControl = new ChiTietDoan(new Doan(), listTourHasPrice, null, null, null, null, this, this, this, this);
            //userControl = new ChiTietTouris(null, listLoais, Enumerable.Empty<Gia>(), listDiaDiems, Enumerable.Empty<DiaDiem>().ToList(), this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onDanhSachDoan_XoaClick(Doan doan)
        {
            doan.Delete();
            doanDal.Save().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    userControl = new DanhSachKhach(danhSachKhac, this);
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
            doanSauKhiCapNhat.AddOrUpdate();
            doanDal.Save().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    List<Tour> listTourHasPrice = TourDal.GetTourDal().GetListTourHasPrice();
                    userControl = new ChiTietDoan(
                        doanSauKhiCapNhat,
                        listTourHasPrice,
                        danhSachPhanCong.Where(c=>c.Doan.Id == doanSauKhiCapNhat.Id).ToList(),
                        danhSachChiPhi.Where(c=>c.Doan.Id == doanSauKhiCapNhat.Id).ToList(),
                        danhSachKhac,
                        danhSachKhac.Where(b => doanKhachDal.GetAll().Where(c => c.Khach.KhachId == b.KhachId && c.Doan.Id == doanSauKhiCapNhat.Id).Count() > 0).ToList(),this,this,this,this);

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
            doanCanXoa.Delete();
            doanDal.Save().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    userControl = new DanhSachKhach(danhSachKhac, this);
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
        public void onDanhSachChiPhi_ThemClick(Doan doanHienTai)
        {
            ChiPhi chiPhi = new ChiPhi();
            chiPhi.Doan = doanHienTai;
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(new ChiTietChiPhi(chiPhi, danhSachLoaiChiPhi, this));
        }

        public void onDanhSachChiPhi_SuaClick(ChiPhi chiPhi)
        {
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(new ChiTietChiPhi(chiPhi, danhSachLoaiChiPhi, this));
        }

        public void onDanhSachChiPhi_XoaClick(Doan doanHienTai,ChiPhi chiPhi)
        {
            chiPhi.Delete();
            chiPhiDal.Save().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    (userControl as ChiTietDoan).UpdateData(
                          danhSachPhanCong.Where(c => c.Doan.Id == doanHienTai.Id).ToList(),
                danhSachChiPhi.Where(c => c.Doan.Id == doanHienTai.Id).ToList(),
                danhSachKhac,
                danhSachKhac.Where(b => doanKhachDal.GetAll().Where(c => c.Khach.KhachId == b.KhachId && c.Doan.Id == doanHienTai.Id).Count() > 0).ToList()); ;
                });
            });
        }

        public void onChiTietChiPhi_LuuClick(Doan doanHienTai,ChiPhi chiPhi)
        {
            chiPhi.AddOrUpdate();
            chiPhiDal.Save().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    (userControl as ChiTietDoan).UpdateData(
                          danhSachPhanCong.Where(c => c.Doan.Id == doanHienTai.Id).ToList(),
                danhSachChiPhi.Where(c => c.Doan.Id == doanHienTai.Id).ToList(),
                danhSachKhac,
                danhSachKhac.Where(b => doanKhachDal.GetAll().Where(c => c.Khach.KhachId == b.KhachId && c.Doan.Id == doanHienTai.Id).Count() > 0).ToList());

                    panel_main_content.Controls.Clear();
                    panel_main_content.Controls.Add(userControl);
                });

            });
        }
        public void onChiTietChiPhi_HuyClick()
        {
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

    }
}
/**
 * Quản Lý Đoàn - Phân Công
 */
namespace DuLich
{
    public partial class ManHinhChinh : DanhSachPhanCong.IDanhSachPhanCongListener,
        ChiTietPhanCong.IChiTietPhanCongListener
    {
        public void onDanhSachPhanCongThemClick(Doan doanHienTai)
        {
            PhanCong phanCong = new PhanCong();
            phanCong.Doan = doanHienTai;
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(new ChiTietPhanCong(phanCong, danhSachNhanVien, this));
        }

        public void onDanhSachPhanCongSuaClick(PhanCong phanCong)
        {
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(new ChiTietPhanCong(phanCong, danhSachNhanVien, this));
        }

        public void onDanhSachPhanCongXoaClick(Doan doanHienTai,PhanCong phanCong)
        {
            phanCong.Delete();
            phanCongDal.Save().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    (userControl as ChiTietDoan).UpdateData(
                          danhSachPhanCong.Where(c => c.Doan.Id == doanHienTai.Id).ToList(),
                danhSachChiPhi.Where(c => c.Doan.Id == doanHienTai.Id).ToList(),
                danhSachKhac,
                danhSachKhac.Where(b => doanKhachDal.GetAll().Where(c => c.Khach.KhachId == b.KhachId && c.Doan.Id == doanHienTai.Id).Count() > 0).ToList()); ;
                });
            });
        }

        public void onChiTietPhanCong_LuuClick(Doan doanHienTai,PhanCong phanCong)
        {
            phanCong.AddOrUpdate();
            phanCongDal.Save().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    (userControl as ChiTietDoan).UpdateData(
                          danhSachPhanCong.Where(c => c.Doan.Id == doanHienTai.Id).ToList(),
                danhSachChiPhi.Where(c => c.Doan.Id == doanHienTai.Id).ToList(),
                danhSachKhac,
                danhSachKhac.Where(b => doanKhachDal.GetAll().Where(c => c.Khach.KhachId == b.KhachId && c.Doan.Id == doanHienTai.Id).Count() > 0).ToList()); ;

                    panel_main_content.Controls.Clear();
                    panel_main_content.Controls.Add(userControl);

                });
            });
        }
        public void onChiTietPhanCong_HuyClick()
        {
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
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
            doanKhachDal.RemoveRange(doanKhachDal.GetAll().Where(c => c.Doan.Id == doanHienTai.Id).ToList());
            foreach (Khach khach in danhSachKhachTrongDoanUpdate)
            {
                DoanKhach doanKhach = new DoanKhach();
                doanKhach.Doan = doanHienTai;
                doanKhach.Khach = khach;
                doanKhach.AddOrUpdate();
            }
            doanKhachDal.Save().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    (userControl as ChiTietDoan).UpdateData(
                          danhSachPhanCong.Where(c => c.Doan.Id == doanHienTai.Id).ToList(),
                danhSachChiPhi.Where(c => c.Doan.Id == doanHienTai.Id).ToList(),
                danhSachKhac,
                danhSachKhac.Where(b => doanKhachDal.GetAll().Where(c => c.Khach.KhachId == b.KhachId && c.Doan.Id == doanHienTai.Id).Count() > 0).ToList()); ;
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
            userControl = new DanhSachDiaDiem(danhSachDiaDiem, this);
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
                List<ChiTietTour> chiTietToursTrungDiaDiem = chiTietTourDal.GetAll().Where(c => c.diaDiem.MaDienDiem == diaDiem.MaDienDiem).ToList();
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
                    diaDiem.Delete();
                    diaDiemDal.Save().ContinueWith(task =>
                    {
                        LoadDataFromDataBase();
                        panel_main_content.Invoke((MethodInvoker)delegate
                        {
                            userControl = new DanhSachDiaDiem(danhSachDiaDiem, this);
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
            diaDiem.AddOrUpdate();
            diaDiemDal.Save().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    userControl = new DanhSachDiaDiem(danhSachDiaDiem, this);
                    panel_main_content.Controls.Clear();
                    panel_main_content.Controls.Add(userControl);
                });
            });
        }

        public void onHuyDiaDiemClick()
        {
            LoadDataFromDataBase();
            userControl = new DanhSachDiaDiem(danhSachDiaDiem, this);
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
            LoadDataFromDataBase();
            userControl = new DanhSachKhach(danhSachKhac, this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onLuuKhachClick(Khach khach)
        {
            khach.AddOrUpdate();
            khachDal.Save().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    userControl = new DanhSachKhach(danhSachKhac, this);
                    panel_main_content.Controls.Clear();
                    panel_main_content.Controls.Add(userControl);
                });
            });
        }

        public void onHuyKhachClick()
        {
            LoadDataFromDataBase();
            userControl = new DanhSachKhach(danhSachKhac, this);
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
            khach.Delete();
            khachDal.Save().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    userControl = new DanhSachKhach(danhSachKhac, this);
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
            nhanVien.Delete();
            nhanVienDal.Save().ContinueWith(task =>
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
            nhanVien.AddOrUpdate();
            nhanVienDal.Save().ContinueWith(task =>
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

/**
 * Thống Kê 
 */
namespace DuLich
{
    public partial class ManHinhChinh
    {
        private void btn_thongke_Click(object sender, EventArgs e)
        {

            LoadDataFromDataBase();
            userControl = new ThongKe(danhSachNhanVien,danhSachPhanCong,danhSachTour,danhSachDoan,danhSachKhac);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }
    }
}