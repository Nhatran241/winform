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
            tb_magia.Text = gia.MaGia.ToString();
            if (gia.MaGia == 0)
            {
                tb_magia.Visible = false;
                tv_magia.Visible = false;
            }
            tb_giatri.Text = gia.GiaTri.ToString();
            datepicker_batdau.Value = DateTime.Today;
            datepicker_ketthuc.Value = DateTime.Today.AddDays(1);
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (Validation(gia))
            {
                chiTietGiaListener.onLuuClick(gia);
            }else
            {
                MessageBox.Show("Giá trị không được bỏ trống");
            }
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            chiTietGiaListener.onHuyClick();
        }
        public interface IChiTietGiaListener
        {
            void onLuuClick(Gia gia);
            void onHuyClick();
        }
        private bool Validation(Gia gia)
        {
            if (gia.GiaTri == 0)
                return false;
            return true;
        }


    }
}
