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

namespace DuLich.View
{
    public partial class ChiTietDoan : UserControl
    {
        private IChiTietDoanListener chiTietDoanListener;
        private DanhSachPhanCong.IDanhSachPhanCongListener danhSachPhanCongListener;
        private SelectKhach.ISelectKhachListener selectKhachListener;
        private UserControl chiTietUserControl;
        private bool isEditing = false;

        private Doan doanHienTai;
        private IEnumerable<Touris> danhSachTour;
        private List<PhanCong> danhSachPhanCong;
        private List<Khach> danhSachTatCaKhach;
        private List<Khach> danhSachKhachTrongDoan;

        public ChiTietDoan(Doan doan, IEnumerable<Touris> listTour, List<PhanCong> phanCongs, List<Khach> tatcakhach, List<Khach> khachtrongdoan,IChiTietDoanListener chiTietDoanListener,DanhSachPhanCong.IDanhSachPhanCongListener danhSachPhanCongListener,SelectKhach.ISelectKhachListener selectKhachListener)
        {
            InitializeComponent();
            this.doanHienTai = doan;
            this.chiTietDoanListener = chiTietDoanListener;
            this.danhSachPhanCongListener = danhSachPhanCongListener;
            this.selectKhachListener = selectKhachListener;
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
        }
        private void TabControl1_Selected(Object sender, TabControlEventArgs e)
        {
            if (e.TabPage.Name=="tab_phancong") {
                LoadDanhSachPhanCong(danhSachPhanCong);
            }
            else
            {
                LoadDanhSachKhach(danhSachTatCaKhach,danhSachKhachTrongDoan);

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
        }
    }
}
