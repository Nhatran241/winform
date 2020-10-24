using DuLich.DAL;
using DuLich.Entity;
using DuLich.GUI.QuanLyChiPhi;
using DuLich.GUI.QuanLyDoan;
using DuLich.GUI.QuanLyKhach;
using DuLich.GUI.QuanLyNhanVien;
using DuLich.GUI.QuanLyTouris;
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
        private DuLichContext context = new DuLichContext();
        private UserControl userControl;
        private List<Khach> khaches = new List<Khach>();
        private List<Doan> danhSachDoan = new List<Doan>();
        private List<PhanCong> danhSachPhanCong = new List<PhanCong>();
        private List<NhanVien> danhSachNhanVien = new List<NhanVien>();
        private List<Tour> danhSachTour = new List<Tour>();
        private List<Loai> listLoais = new List<Loai>();
        private List<DiaDiem> danhSachDiaDiem = new List<DiaDiem>();
        private List<Gia> danhSachGia = new List<Gia>();
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
            danhSachDoan = context.Doans.ToList();
            listLoais = context.Loai.ToList();
            danhSachDiaDiem = context.DiaDiem.ToList();
            khaches = context.Khaches.ToList();
            danhSachPhanCong = context.PhanCongs.ToList();
            danhSachNhanVien = context.NhanViens.ToList();
            danhSachDoanKhach = context.DoanKhachs.ToList();
            danhSachChiPhi = context.ChiPhis.ToList();
            danhSachLoaiChiPhi = context.LoaiChiPhis.ToList();
            danhSachGia = context.Gia.ToList();
            /**
             * 3 lớp
             */
            danhSachTour = context.Touris.ToList();
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
            context.Touris.AddOrUpdate(tourisAfterUpdate);
            context.SaveChangesAsync().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                userControl = new ChiTietTouris(tourisAfterUpdate,
                    listLoais,
                    new List<Gia>(),
                    danhSachDiaDiem,
                    new List<DiaDiem>(), this, this);
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    panel_main_content.Controls.Clear();
                    panel_main_content.Controls.Add(userControl);
                });
            });
          
        }


        public void onThemGia(Gia gia, Tour touris)
        {
            context.Gia.AddOrUpdate(gia);
            context.SaveChangesAsync().ContinueWith(task =>
            {
                if (userControl is ChiTietTouris)
                {
                    LoadDataFromDataBase();
                    List<DiaDiem> danhSachDiaDiemCuaTor = new List<DiaDiem>();
                    foreach (ChiTietTour chiTietTour in context.ChiTietTour.OrderBy(c => c.ThuTu).Where(c => c.touris.Id == touris.Id).ToList())
                    {
                        DiaDiem diaDiem = danhSachDiaDiem.Where(c => c.MaDienDiem == chiTietTour.diaDiem.MaDienDiem).First();
                        if (!danhSachDiaDiemCuaTor.Contains(diaDiem))
                            danhSachDiaDiemCuaTor.Add(diaDiem);
                    }
                    List<Gia> danhSachGiaCuaTour = new List<Gia>();
                    danhSachGiaCuaTour.AddRange(danhSachGia.Where(c => c.touris.Id == touris.Id).ToList());
                    panel_main_content.Invoke((MethodInvoker)delegate
                    {
                        userControl = new ChiTietTouris(touris, listLoais, danhSachGiaCuaTour, danhSachDiaDiem,
                            danhSachDiaDiemCuaTor, this, this);
                        panel_main_content.Controls.Clear();
                        panel_main_content.Controls.Add(userControl);
                    });
                }
            });

        }

        public void onSuaGia(Gia gia, Tour touris)
        {
            context.Gia.AddOrUpdate(gia);
            context.SaveChangesAsync().ContinueWith(task =>
            {
                if (userControl is ChiTietTouris)
                {
                    LoadDataFromDataBase();
                    panel_main_content.Invoke((MethodInvoker)delegate
                    {
                        LoadDataFromDataBase();
                        List<DiaDiem> danhSachDiaDiemCuaTor = new List<DiaDiem>();
                        foreach (ChiTietTour chiTietTour in context.ChiTietTour.OrderBy(c => c.ThuTu).Where(c => c.touris.Id == touris.Id).ToList())
                        {
                            DiaDiem diaDiem = danhSachDiaDiem.Where(c => c.MaDienDiem == chiTietTour.diaDiem.MaDienDiem).First();
                            if (!danhSachDiaDiemCuaTor.Contains(diaDiem))
                                danhSachDiaDiemCuaTor.Add(diaDiem);
                        }
                        List<Gia> danhSachGiaCuaTour = new List<Gia>();
                        danhSachGiaCuaTour.AddRange(danhSachGia.Where(c => c.touris.Id == touris.Id).ToList());
                        panel_main_content.Invoke((MethodInvoker)delegate
                        {
                            userControl = new ChiTietTouris(touris, listLoais, danhSachGiaCuaTour, danhSachDiaDiem,
                                danhSachDiaDiemCuaTor, this, this);
                            panel_main_content.Controls.Clear();
                            panel_main_content.Controls.Add(userControl);
                        });
                    });
                }
            });

        }

        public void onXoaGia(Gia gia, Tour touris)
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
                        message += doan.Name + " ";
                    }
                    DialogResult innerDialogResukt = MessageBox.Show("Tour này đang được sử dụng ở các đoàn :" + message + " nên không thể xóa tour này");
                }
                else
                {
                    context.Gia.Remove(gia);
                    context.SaveChangesAsync().ContinueWith(task =>
                    {
                        if (userControl is ChiTietTouris)
                        {
                            LoadDataFromDataBase();
                            panel_main_content.Invoke((MethodInvoker)delegate
                            {
                                List<DiaDiem> danhSachDiaDiemCuaTor = new List<DiaDiem>();
                                foreach (ChiTietTour chiTietTour in context.ChiTietTour.OrderBy(c => c.ThuTu).Where(c => c.touris.Id == touris.Id).ToList())
                                {
                                    DiaDiem diaDiem = danhSachDiaDiem.Where(c => c.MaDienDiem == chiTietTour.diaDiem.MaDienDiem).First();
                                    if (!danhSachDiaDiemCuaTor.Contains(diaDiem))
                                        danhSachDiaDiemCuaTor.Add(diaDiem);
                                }
                                List<Gia> danhSachGiaCuaTour = new List<Gia>();
                                danhSachGiaCuaTour.AddRange(danhSachGia.Where(c => c.touris.Id == touris.Id).ToList());
                                panel_main_content.Invoke((MethodInvoker)delegate
                                {
                                    userControl = new ChiTietTouris(touris, listLoais, danhSachGiaCuaTour, danhSachDiaDiem,
                                        danhSachDiaDiemCuaTor, this, this);
                                    panel_main_content.Controls.Clear();
                                    panel_main_content.Controls.Add(userControl);
                                });
                            });
                        }
                    });
                }
            }

        }

        public void onHuyGia()
        {
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
                        message += doan.Name + " ";
                    }
                    DialogResult innerDialogResukt = MessageBox.Show("Tour này đang được sử dụng ở các đoàn :" + message + " nên không thể xóa tour này");
                }
                else
                {
                    context.Touris.Remove(currentTouris);
                    context.SaveChangesAsync().ContinueWith(task =>
                    {
                        LoadDataFromDataBase();
                        panel_main_content.Invoke((MethodInvoker)delegate
                        {
                            panel_main_content.Controls.Clear();
                            panel_main_content.Controls.Add(new DanhSachTour(danhSachTour, listLoais, this));
                        });
                    });
                }
            }
        }
        private void btn_quanlytour_Click(object sender, EventArgs e)
        {
            LoadDataFromDataBase();
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(new DanhSachTour(danhSachTour, listLoais, this));
        }


        public void onDanhSachTour_TourDoubleClick(Tour touris)
        {
            List<DiaDiem> danhSachDiaDiemCuaTor = new List<DiaDiem>();
            foreach(ChiTietTour chiTietTour in context.ChiTietTour.OrderBy(c=>c.ThuTu).Where(c=>c.touris.Id==touris.Id).ToList())
            {
                DiaDiem diaDiem = danhSachDiaDiem.Where(c => c.MaDienDiem == chiTietTour.diaDiem.MaDienDiem).First();
                if (!danhSachDiaDiemCuaTor.Contains(diaDiem))
                    danhSachDiaDiemCuaTor.Add(diaDiem);
            }
            List<Gia> danhSachGiaCuaTour = new List<Gia>();
            danhSachGiaCuaTour.AddRange(danhSachGia.Where(c => c.touris.Id == touris.Id).ToList());
            userControl = new ChiTietTouris(touris,
                listLoais,
                danhSachGiaCuaTour,
                danhSachDiaDiem,
                danhSachDiaDiemCuaTor, this, this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onDanhSachTour_ThemClick()
        {
            userControl = new ChiTietTouris(null, listLoais, new List<Gia>(), danhSachDiaDiem, new List<DiaDiem>(), this, this);
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
                        message += doan.Name + " ";
                    }
                    DialogResult innerDialogResukt = MessageBox.Show("Tour này đang được sử dụng ở các đoàn :"+message+" nên không thể xóa tour này");
                }
                else
                {
                    context.Touris.Remove(tour);
                    context.SaveChangesAsync().ContinueWith(task =>
                    {
                        LoadDataFromDataBase();
                        panel_main_content.Invoke((MethodInvoker)delegate
                        {
                            panel_main_content.Controls.Clear();
                            panel_main_content.Controls.Add(new DanhSachTour(danhSachTour, listLoais, this));
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
            if(tourHienTai.ChiTietTours!=null)
                context.ChiTietTour.RemoveRange(tourHienTai.ChiTietTours.ToList());
            for (int i = 0; i < danhSachDiaDiemTrongDoanUpdate.Count(); i++)
            {
                ChiTietTour chiTietTour = new ChiTietTour();
                chiTietTour.diaDiem = danhSachDiaDiemTrongDoanUpdate.ToArray()[i];
                chiTietTour.touris = tourHienTai;
                chiTietTour.ThuTu = i + 1;
                context.ChiTietTour.AddOrUpdate(chiTietTour);
            }
            context.SaveChangesAsync().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    List<DiaDiem> danhSachDiaDiemCuaTor = new List<DiaDiem>();
                    foreach (ChiTietTour chiTietTour in context.ChiTietTour.OrderBy(c => c.ThuTu).Where(c => c.touris.Id == tourHienTai.Id).ToList())
                    {
                        DiaDiem diaDiem = danhSachDiaDiem.Where(c => c.MaDienDiem == chiTietTour.diaDiem.MaDienDiem).First();
                        if (!danhSachDiaDiemCuaTor.Contains(diaDiem))
                            danhSachDiaDiemCuaTor.Add(diaDiem);
                    }

                    (userControl as ChiTietTouris).UpdateData(
                          danhSachGia.Where(c => c.TourisId == tourHienTai.Id).ToList(),
                          danhSachDiaDiemCuaTor);
                });
            });
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
            userControl = new DanhSachDoan(danhSachDoan, danhSachTour,danhSachNhanVien,khaches, this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }


        private void btn_taodoan_Click(object sender, EventArgs e)
        {
            userControl = new ChiTietDoan(new Doan(), danhSachTour, null,null, null, null, this, this, this,this);
            //userControl = new ChiTietTouris(null, listLoais, Enumerable.Empty<Gia>(), listDiaDiems, Enumerable.Empty<DiaDiem>().ToList(), this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onDanhSachDoan_DoanDoubleClick(Doan doan)
        {
            userControl = new ChiTietDoan(doan, danhSachTour,
                danhSachPhanCong.Where(c => c.Doan.Id == doan.Id).ToList(),
                danhSachChiPhi.Where(c => c.Doan.Id == doan.Id).ToList(),
                khaches,
                khaches.Where(b => context.DoanKhachs.Where(c => c.Khach.KhachId == b.KhachId && c.Doan.Id == doan.Id).Count() > 0).ToList(), this, this, this, this); ;
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
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
            context.Doans.AddOrUpdate(doanSauKhiCapNhat);
            context.SaveChangesAsync().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    userControl = new ChiTietDoan(
                        doanSauKhiCapNhat, 
                        danhSachTour,
                        danhSachPhanCong.Where(c=>c.Doan.Id == doanSauKhiCapNhat.Id).ToList(),
                        danhSachChiPhi.Where(c=>c.Doan.Id == doanSauKhiCapNhat.Id).ToList(),
                        khaches,
                        khaches.Where(b => context.DoanKhachs.Where(c => c.Khach.KhachId == b.KhachId && c.Doan.Id == doanSauKhiCapNhat.Id).Count() > 0).ToList(),this,this,this,this);

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
            context.ChiPhis.Remove(chiPhi);
            context.SaveChangesAsync().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    (userControl as ChiTietDoan).UpdateData(
                          danhSachPhanCong.Where(c => c.Doan.Id == doanHienTai.Id).ToList(),
                danhSachChiPhi.Where(c => c.Doan.Id == doanHienTai.Id).ToList(),
                khaches,
                khaches.Where(b => context.DoanKhachs.Where(c => c.Khach.KhachId == b.KhachId && c.Doan.Id == doanHienTai.Id).Count() > 0).ToList()); ;
                });
            });
        }

        public void onChiTietChiPhi_LuuClick(Doan doanHienTai,ChiPhi chiPhi)
        {
            context.ChiPhis.AddOrUpdate(chiPhi);
            context.SaveChangesAsync().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    (userControl as ChiTietDoan).UpdateData(
                          danhSachPhanCong.Where(c => c.Doan.Id == doanHienTai.Id).ToList(),
                danhSachChiPhi.Where(c => c.Doan.Id == doanHienTai.Id).ToList(),
                khaches,
                khaches.Where(b => context.DoanKhachs.Where(c => c.Khach.KhachId == b.KhachId && c.Doan.Id == doanHienTai.Id).Count() > 0).ToList());

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
            context.PhanCongs.Remove(phanCong);
            context.SaveChangesAsync().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    (userControl as ChiTietDoan).UpdateData(
                          danhSachPhanCong.Where(c => c.Doan.Id == doanHienTai.Id).ToList(),
                danhSachChiPhi.Where(c => c.Doan.Id == doanHienTai.Id).ToList(),
                khaches,
                khaches.Where(b => context.DoanKhachs.Where(c => c.Khach.KhachId == b.KhachId && c.Doan.Id == doanHienTai.Id).Count() > 0).ToList()); ;
                });
            });
        }

        public void onChiTietPhanCong_LuuClick(Doan doanHienTai,PhanCong phanCong)
        {
            context.PhanCongs.AddOrUpdate(phanCong);
            context.SaveChangesAsync().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    (userControl as ChiTietDoan).UpdateData(
                          danhSachPhanCong.Where(c => c.Doan.Id == doanHienTai.Id).ToList(),
                danhSachChiPhi.Where(c => c.Doan.Id == doanHienTai.Id).ToList(),
                khaches,
                khaches.Where(b => context.DoanKhachs.Where(c => c.Khach.KhachId == b.KhachId && c.Doan.Id == doanHienTai.Id).Count() > 0).ToList()); ;

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
                    (userControl as ChiTietDoan).UpdateData(
                          danhSachPhanCong.Where(c => c.Doan.Id == doanHienTai.Id).ToList(),
                danhSachChiPhi.Where(c => c.Doan.Id == doanHienTai.Id).ToList(),
                khaches,
                khaches.Where(b => context.DoanKhachs.Where(c => c.Khach.KhachId == b.KhachId && c.Doan.Id == doanHienTai.Id).Count() > 0).ToList()); ;
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
            context.DiaDiem.AddOrUpdate(diaDiem);
            context.SaveChangesAsync().ContinueWith(task =>
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