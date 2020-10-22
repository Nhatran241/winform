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
using DuLich.View.QuanLyTouris;
using DuLich.Model.Entity;
using DuLich.View.QuanLyPhanCong;
using DuLich.View.QuanLyDoan;
using DuLich.GUI.QuanLyChiPhi;

namespace DuLich.View
{
    public partial class ChiTietDoan : UserControl
    {
        private IChiTietDoanListener chiTietDoanListener;
        private DanhSachPhanCong.IDanhSachPhanCongListener danhSachPhanCongListener;
        private DanhSachChiPhi.IDanhSachChiPhiListener danhSachChiPhiListener;
        private SelectKhach.ISelectKhachListener selectKhachListener;
        private UserControl chiTietUserControl;
        private bool isEditing = false;

        private Doan doanHienTai;
        private IEnumerable<Touris> danhSachTour;
        private List<PhanCong> danhSachPhanCong;
        private List<Khach> danhSachTatCaKhach;
        private List<Khach> danhSachKhachTrongDoan;
        private List<ChiPhi> danhSachChiPhi;

        public ChiTietDoan(Doan doan, IEnumerable<Touris> listTour, List<PhanCong> phanCongs,List<ChiPhi> danhSachChiPhi, List<Khach> tatcakhach, List<Khach> khachtrongdoan,IChiTietDoanListener chiTietDoanListener,DanhSachPhanCong.IDanhSachPhanCongListener danhSachPhanCongListener,SelectKhach.ISelectKhachListener selectKhachListener,DanhSachChiPhi.IDanhSachChiPhiListener danhSachChiPhiListener)
        {
            InitializeComponent();
            this.doanHienTai = doan;
            this.chiTietDoanListener = chiTietDoanListener;
            this.danhSachPhanCongListener = danhSachPhanCongListener;
            this.selectKhachListener = selectKhachListener;
            this.danhSachChiPhiListener = danhSachChiPhiListener;
            this.danhSachChiPhi = danhSachChiPhi;
            this.danhSachTour = listTour;
            this.danhSachPhanCong = phanCongs;
            this.danhSachTatCaKhach = tatcakhach;
            this.danhSachKhachTrongDoan = khachtrongdoan;
            if (doan.Id == 0)
                CreateNewRecord();
            UpdateComponentState();
            InitData();
        }

        public void UpdateComponentState()
        {
            if (doanHienTai.Id == 0)
            {
                tab_chitiet.Visible = false;
            }
            else tab_chitiet.Visible = true;
            if (isEditing)
            {
                EnableComponent();
                btn_chinhsua.Text = "Lưu";
               
            }
            else
            {
                DisableComponent();
                btn_chinhsua.Text = "Chỉnh Sửa";
            }
       
        }

        public void CreateNewRecord()
        {
            this.doanHienTai = new Doan();
            doanHienTai.Touris = danhSachTour.First();
            textbox_id.Visible = false;
            doan_id.Visible = false;
            btn_xoa.Visible = false;
            isEditing = true;
            UpdateComponentState();
        }
        private void DisableComponent()
        {
            textbox_id.Visible = true;
            doan_id.Visible = true;
            btn_xoa.Visible = true;
            textbox_id.Enabled = false;
            textbox_name.Enabled = false;
            combobox_loai.Enabled = false;
        }
        private void EnableComponent()
        {
            btn_xoa.Visible = false;
            textbox_id.Enabled = false;
            textbox_name.Enabled = true;
            combobox_loai.Enabled = true;
        }

      
         
        private void InitData()
        {
          
            InitUI(doanHienTai);
            LoadDanhSachPhanCong(danhSachPhanCong);
        }

        public void LoadDanhSachPhanCong(List<PhanCong> phanCongs)
        {
            tab_phancong.Controls.Clear();
            tab_phancong.Controls.Add(new DanhSachPhanCong(doanHienTai,phanCongs,danhSachPhanCongListener));
        }
        public void LoadDanhSachKhach(List<Khach> danhSachTatCaKhach,List<Khach> danhSachKhachTrongDoan)
        {
            tab_khach.Controls.Clear();
            tab_khach.Controls.Add(new SelectKhach(doanHienTai,danhSachTatCaKhach,danhSachKhachTrongDoan,selectKhachListener));
        }
        private void LoadDanhSachChiPhi(List<ChiPhi> danhSachChiPhi)
        {
            tab_chiphi.Controls.Clear();
            tab_chiphi.Controls.Add(new DanhSachChiPhi(doanHienTai,danhSachChiPhi,danhSachChiPhiListener));
        }

        public void InitUI(Doan doan)
        {
            textbox_id.Text = doan.Id.ToString();
            textbox_name.Text = doan.Name;
            foreach (Touris tour in danhSachTour)
            {
                combobox_loai.Items.Add(tour);
            }
            combobox_loai.Text = doanHienTai.Touris.Name;
            if (doanHienTai.ThoiGianBatDau.Year < 1500 && doanHienTai.ThoiGianKetThuc.Year < 1500)
            {
                datepicker_batdau.Value = DateTime.Today;
                datepicker_ketthuc.Value = DateTime.Today;
            }
            else
            {
                datepicker_batdau.Value = doanHienTai.ThoiGianBatDau;
                datepicker_ketthuc.Value = doanHienTai.ThoiGianKetThuc;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            doanHienTai.Touris = danhSachTour.ToArray()[combobox_loai.SelectedIndex];
            List<Gia> giaCuaTour = doanHienTai.Touris.Gias.ToList();
            if (giaCuaTour.Count() == 0)
            {
                tv_tourkogia.Visible = true;
                datepicker_batdau.Visible = false;
                datepicker_ketthuc.Visible = false;
                tv_ngaybatdau.Visible = false;
                tv_ngayketthuc.Visible = false;
                btn_chinhsua.Visible = false;
            }
            else {
                tv_tourkogia.Visible = false;
                btn_chinhsua.Visible = true;
                datepicker_batdau.Visible = true;
                datepicker_ketthuc.Visible = true;
                tv_ngaybatdau.Visible = true;
                tv_ngayketthuc.Visible = true;
                DateTime minTime = giaCuaTour.First().ThoiGianBatDau;
                DateTime maxTime = giaCuaTour.First().ThoiGianKetThuc;
                foreach(Gia gia in giaCuaTour)
                {
                    if (gia.ThoiGianBatDau <= minTime)
                        minTime = gia.ThoiGianBatDau;
                    if (gia.ThoiGianKetThuc >= maxTime)
                        maxTime = gia.ThoiGianKetThuc;
                }
                datepicker_batdau.MinDate = minTime;
                datepicker_batdau.MaxDate = maxTime;
                datepicker_ketthuc.MinDate = minTime;
                datepicker_ketthuc.MaxDate = maxTime;
            }
           

        }
        private void TabControl1_Selected(Object sender, TabControlEventArgs e)
        {
            if (e.TabPage.Name=="tab_phancong") {
                LoadDanhSachPhanCong(danhSachPhanCong);
            }
            else if(e.TabPage.Name == "tab_khach")
            {
                LoadDanhSachKhach(danhSachTatCaKhach,danhSachKhachTrongDoan);
            }else
            {
                LoadDanhSachChiPhi(danhSachChiPhi);
            }
        }

      

        public interface IChiTietDoanListener
        {
            void onChiTietDoanClick_CapNhat(Doan doanSauKhiCapNhat);
            void onChiTietDoanClick_Xoa(Doan doanCanXoa);
        }

        
     

        private void btn_chinhsua_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {

                if (Validation(doanHienTai))
                {

                    chiTietDoanListener.onChiTietDoanClick_CapNhat(doanHienTai);
                }
                else
                {
                    MessageBox.Show("Tên hoặc loại tour không được bỏ trống");
                    return;
                }
            }
            isEditing = !isEditing;
            UpdateComponentState();
        }

        private void textbox_name_TextChanged(object sender, EventArgs e)
        {
            doanHienTai.Name = textbox_name.Text.Trim();
        }

        private bool Validation(Doan doanSauKhiCapNhat)
        {
            if (doanSauKhiCapNhat.Name == "" || doanSauKhiCapNhat.Touris == null)
                return false;
            return true;
        }

        /*
        public void onDanhSachGiaThemClick()
        {
            Gia gia = new Gia();
            gia.touris = currentTouris;
            chiTietUserControl = new ChiTietGia(gia,this);
            tab_phancong.Controls.Clear();
            tab_phancong.Controls.Add(chiTietUserControl);
        }
        */
        /*
        public void onDanhSachGiaSuaClick(Gia gia)
        {
            chiTietUserControl = new ChiTietGia(gia,this);
            tab_phancong.Controls.Clear();
            tab_phancong.Controls.Add(chiTietUserControl);
        }

        public void onDanhSachGiaXoaClick(Gia gia)
        {
            onChiTietClickListener.onXoaGia(gia, currentTouris);
        }

        public void onLuuClick(Gia gia)
        {
            Console.WriteLine("" + gia.MaGia + "/" + gia.GiaTri + ":" + gia.ThoiGianBatDau + "-" + gia.ThoiGianKetThuc);
            if (gia.MaGia == 0)
            {
                onChiTietClickListener.onThemGia(gia,currentTouris);
            }
            else onChiTietClickListener.onSuaGia(gia, currentTouris);
        }

        public void onHuyClick()
        {
            LoadDanhSachGia();
        }

        public void onClickLuu(List<DiaDiem> diaDiemCuaTourNew)
        {
           
        }
        */



        private void btn_xoa_Click(object sender, EventArgs e)
        {
            chiTietDoanListener.onChiTietDoanClick_Xoa(doanHienTai);
        }


        private void datepicker_batdau_ValueChanged(object sender, EventArgs e)
        {

            doanHienTai.ThoiGianBatDau = datepicker_batdau.Value;
            if (doanHienTai.ThoiGianBatDau > doanHienTai.ThoiGianKetThuc)
            {
                doanHienTai.ThoiGianKetThuc = doanHienTai.ThoiGianBatDau;
                datepicker_ketthuc.Value = doanHienTai.ThoiGianBatDau;
            }

            if (doanHienTai.ThoiGianBatDau.Year < 1500)
                doanHienTai.ThoiGianBatDau = DateTime.Today;
            TinhToanDoanhThu();
        }

        private void TinhToanDoanhThu()
        {
            /**
             * Ước tính doanh thu = chi phí tour - tổng chi phí phát sinh [Chi Phí Đoàn]
             */
            Gia giaApDung = doanHienTai.Touris.Gias.First();
            foreach (Gia gia in doanHienTai.Touris.Gias)
            {
                if (doanHienTai.ThoiGianBatDau >= gia.ThoiGianBatDau && doanHienTai.ThoiGianKetThuc <= gia.ThoiGianKetThuc)
                {
                    giaApDung = gia;
                    break;
                }
            }
            tv_doanhthuuoctinh.Text = giaApDung.GiaTri.ToString();

        }

        private void datepicker_ketthuc_ValueChanged(object sender, EventArgs e)
        {
            doanHienTai.ThoiGianKetThuc = datepicker_ketthuc.Value;
            if (doanHienTai.ThoiGianKetThuc < doanHienTai.ThoiGianBatDau)
            {
                doanHienTai.ThoiGianKetThuc = doanHienTai.ThoiGianBatDau;
                datepicker_ketthuc.Value = doanHienTai.ThoiGianBatDau;
            }

            if (doanHienTai.ThoiGianKetThuc.Year < 1500)
                doanHienTai.ThoiGianKetThuc = DateTime.Today;
            TinhToanDoanhThu();
        }
    }
}
