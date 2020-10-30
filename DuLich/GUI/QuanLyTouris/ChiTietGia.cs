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

namespace DuLich.View.QuanLyTouris
{
    public partial class ChiTietGia : UserControl
    {
        private IChiTietGiaListener chiTietGiaListener;
        private Gia gia;
        private bool isEditing = false;
        public ChiTietGia(Gia gia,IChiTietGiaListener chiTietGiaListener)
        {
            InitializeComponent();
            this.chiTietGiaListener = chiTietGiaListener;
            this.gia = gia;
            InitUI();
        }

        private void InitUI()
        {
            if (gia.MaGia == 0)
            {
                tb_magia.Text = "Mã tự động";
            } else {
                tb_magia.Text = gia.MaGia.ToString();
            } 
            tb_giatri.Text = gia.GiaTri.ToString();
            if(gia.ThoiGianBatDau.Year < 1500 && gia.ThoiGianKetThuc.Year < 1500)
            {
                datepicker_batdau.Value = DateTime.Today;
                datepicker_ketthuc.Value = DateTime.Today;
            }else
            {
                datepicker_batdau.Value = gia.ThoiGianBatDau;
                datepicker_ketthuc.Value = gia.ThoiGianKetThuc;
            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (Validation(gia))
            {
                chiTietGiaListener.onChiTietGia_LuuClick(gia);
            }else
            {
                MessageBox.Show("Giá trị không được bỏ trống");
            }
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            chiTietGiaListener.onChiTietGia_HuyClick();
        }
        public interface IChiTietGiaListener
        {
            void onChiTietGia_LuuClick(Gia gia);
            void onChiTietGia_HuyClick();
        }
        private bool Validation(Gia gia)
        {
            if (gia.GiaTri == 0)
                return false;
            return true;
        }

        private void datepicker_batdau_ValueChanged(object sender, EventArgs e)
        {
            
            gia.ThoiGianBatDau = datepicker_batdau.Value;
            if (gia.ThoiGianBatDau > gia.ThoiGianKetThuc)
            {
                gia.ThoiGianKetThuc = gia.ThoiGianBatDau;
                datepicker_ketthuc.Value = gia.ThoiGianBatDau;
            }

            if (gia.ThoiGianBatDau.Year < 1500)
                gia.ThoiGianBatDau = DateTime.Today;
        }

        private void datepicker_ketthuc_ValueChanged(object sender, EventArgs e)
        {
            gia.ThoiGianKetThuc = datepicker_ketthuc.Value;
            if (gia.ThoiGianKetThuc < gia.ThoiGianBatDau)
            {
                gia.ThoiGianKetThuc = gia.ThoiGianBatDau;
                datepicker_ketthuc.Value = gia.ThoiGianBatDau;
            }

            if (gia.ThoiGianKetThuc.Year < 1500)
                gia.ThoiGianKetThuc = DateTime.Today;
        }

        private void tb_giatri_TextChanged(object sender, EventArgs e)
        {

            if (IsNumeric(tb_giatri.Text.Trim()))
            {
                gia.GiaTri = Convert.ToInt32(tb_giatri.Text.Trim());
            }
        }
        public bool IsNumeric(object Expression)    
        {
            double retNum;

            bool isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        private void tv_ngaybatdau_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
