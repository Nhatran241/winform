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
using System.Net.Sockets;

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
        private IEnumerable<Tour> danhSachTour;
        private List<PhanCong> danhSachPhanCong;
        private List<Khach> danhSachTatCaKhach;
        private List<Khach> danhSachKhachTrongDoan;
        private List<ChiPhi> danhSachChiPhi;

        public ChiTietDoan(Doan doan, IEnumerable<Tour> listTour, List<PhanCong> phanCongs,List<ChiPhi> danhSachChiPhi, List<Khach> tatcakhach, List<Khach> khachtrongdoan,IChiTietDoanListener chiTietDoanListener,DanhSachPhanCong.IDanhSachPhanCongListener danhSachPhanCongListener,SelectKhach.ISelectKhachListener selectKhachListener,DanhSachChiPhi.IDanhSachChiPhiListener danhSachChiPhiListener)
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
                tab_chitiet.Enabled = false;
            }
            else tab_chitiet.Enabled = true;
            if (isEditing)
            {
                EnableComponent();
                btn_chinhsua.Image = Properties.Resources.diskette;

            }
            else
            {
                DisableComponent();
                btn_chinhsua.Image = Properties.Resources.edit__1_;
            }
       
        }

        public void CreateNewRecord()
        {
            this.doanHienTai = new Doan();
            if(doanHienTai.Touris != null)
                doanHienTai.Touris = danhSachTour.First();
            textbox_id.Enabled = false;
            btn_xoa.Visible = false;
            isEditing = true;
            UpdateComponentState();
        }
        private void DisableComponent()
        {
           // textbox_id.Visible = true;
            //doan_id.Visible = true;
            btn_xoa.Visible = true;
            textbox_id.Enabled = false;
            textbox_name.Enabled = false;
            combobox_loai.Enabled = false;
            cb_giatour.Enabled = false;
            datepicker_batdau.Enabled = false;
            datepicker_ketthuc.Enabled = false;
        }
        private void EnableComponent()
        {
            btn_xoa.Visible = false;
            //textbox_id.Enabled = false;
            textbox_name.Enabled = true;
            combobox_loai.Enabled = true;
            cb_giatour.Enabled = true;
            datepicker_batdau.Enabled = true;
            datepicker_ketthuc.Enabled = true;
        }


        public void UpdateData(List<PhanCong> phanCongs, List<ChiPhi> danhSachChiPhi, List<Khach> tatcakhach, List<Khach> khachtrongdoan)
        {
            this.danhSachChiPhi = danhSachChiPhi;
            this.danhSachPhanCong = phanCongs;
            this.danhSachTatCaKhach = tatcakhach;
            this.danhSachKhachTrongDoan = khachtrongdoan;
            InitData();
        }
        private void InitData()
        {
          
            InitUI(doanHienTai);
            if (tab_chitiet.SelectedTab.Name.Equals("tab_phancong"))
            {
                if(danhSachPhanCong != null)
                    LoadDanhSachPhanCong(danhSachPhanCong);
            }else if (tab_chitiet.SelectedTab.Name.Equals("tab_khach"))
            {
                if (danhSachKhachTrongDoan != null)
                    LoadDanhSachKhach(danhSachTatCaKhach, danhSachKhachTrongDoan);
            }
            else
            {
                if (danhSachChiPhi != null)
                    LoadDanhSachChiPhi(danhSachChiPhi);
            }
            
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
            if (doan.Id != 0)
            {
                textbox_id.Text = doan.Id.ToString();
                datepicker_batdau.Value = doanHienTai.ThoiGianBatDau;
                datepicker_ketthuc.Value = doanHienTai.ThoiGianKetThuc;
                datepicker_batdau.MinDate = doanHienTai.GiaApDung.ThoiGianBatDau;
                datepicker_ketthuc.MinDate = doanHienTai.GiaApDung.ThoiGianKetThuc;
            }
            else
            {
                textbox_id.Text = "Mã tự động";
            }
            textbox_name.Text = doan.Name;
            if(combobox_loai.Items.Count ==0) {
                foreach (Tour tour in danhSachTour)
                {
                    combobox_loai.Items.Add(tour);
                }
            }
           
            if(doanHienTai.Touris != null)
                combobox_loai.Text = doanHienTai.Touris.Name;
            if (doanHienTai.Touris!= null && doanHienTai.Touris.Gias != null)
            {
                if(cb_giatour.Items.Count ==0)
                {
                    foreach (Gia gia in doanHienTai.Touris.Gias)
                    {
                        cb_giatour.Items.Add(gia);
                    }
                }
                cb_giatour.SelectedItem = doanHienTai.GiaApDung;
            }
            UpDateLoiNhuan();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isEditing)
                return;
            doanHienTai.Touris = danhSachTour.ToArray()[combobox_loai.SelectedIndex];
            cb_giatour.DataSource = doanHienTai.Touris.Gias.ToList();
        }
        private void cb_giatour_SelectedIndexChanged(object sender, EventArgs e)
        {
            doanHienTai.GiaApDung = doanHienTai.Touris.Gias.ToArray()[cb_giatour.SelectedIndex];
            UpdateMinMaxDatepicker();
        }

        private void UpdateMinMaxDatepicker()
        {
            DateTimePicker temp = new DateTimePicker();
            datepicker_batdau.MinDate = temp.MinDate;
            datepicker_batdau.MaxDate = temp.MaxDate;
            datepicker_ketthuc.MinDate = temp.MinDate;
            datepicker_batdau.MaxDate = doanHienTai.GiaApDung.ThoiGianKetThuc;
            datepicker_batdau.MinDate = doanHienTai.GiaApDung.ThoiGianBatDau;
            datepicker_ketthuc.MinDate = doanHienTai.GiaApDung.ThoiGianBatDau;
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
            UpDateLoiNhuan();

        }

        private void UpDateLoiNhuan()
        {
            if (doanHienTai.GiaApDung != null)
            {
                if (doanHienTai.ChiPhis != null)
                {
                    tb_loinhuan.Text = (doanHienTai.GiaApDung.GiaTri - doanHienTai.ChiPhis.Sum(c => c.giaTri)).ToString();
                }
                else tb_loinhuan.Text = doanHienTai.GiaApDung.GiaTri.ToString();
            }
            else tb_loinhuan.Text = "0";
        }

        /**
private void TinhGiaTour()
{
   long giaTam = doanHienTai.GiaTour;
   if(doanHienTai.Touris.Gias != null)
   {
       foreach (Gia gia in doanHienTai.Touris.Gias)
       {
           if(doanHienTai.ThoiGianBatDau>=gia.ThoiGianBatDau&&doanHienTai.ThoiGianBatDau <= gia.ThoiGianKetThuc)
           {
               tb_giatour.Text = gia.GiaTri.ToString();
               doanHienTai.GiaTour = long.Parse(gia.GiaTri.ToString());
               long tongChiPhi = danhSachChiPhi.Sum(c => c.giaTri);
               tb_loinhuan.Text = (doanHienTai.GiaTour - tongChiPhi).ToString();
               return;
           }
       }

       doanHienTai.GiaTour = giaTam;
       tb_loinhuan.Text = (doanHienTai.GiaTour - danhSachChiPhi.Sum(c => c.giaTri)).ToString();
   }
  
}
*/


        private void datepicker_ketthuc_ValueChanged_1(object sender, EventArgs e)
        {
            doanHienTai.ThoiGianKetThuc = datepicker_ketthuc.Value;
            if (doanHienTai.ThoiGianKetThuc < doanHienTai.ThoiGianBatDau)
            {
                doanHienTai.ThoiGianKetThuc = doanHienTai.ThoiGianBatDau;
                datepicker_ketthuc.Value = doanHienTai.ThoiGianBatDau;
            }
        }

     
    }
}
