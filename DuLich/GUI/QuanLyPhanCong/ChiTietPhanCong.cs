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

namespace DuLich.View.QuanLyPhanCong
{
    public partial class ChiTietPhanCong : UserControl
    {
        private IChiTietPhanCongListener chiTietPhanCongListener;
        private PhanCong PhanCong;
        private bool isEditing = false;
        public ChiTietPhanCong(PhanCong phanCong,IChiTietPhanCongListener chiTietPhanCongListener)
        {
            InitializeComponent();
            this.chiTietPhanCongListener = chiTietPhanCongListener;
            this.PhanCong = phanCong;
            InitUI();
        }

        private void InitUI()
        {
            tb_maphancong.Text = PhanCong.MaPhanCong.ToString();
            if (PhanCong.MaPhanCong == 0)
            {
                tb_maphancong.Visible = false;
                tv_maphancong.Visible = false;
            } else {
                tb_maphancong.Visible = false;
                tv_maphancong.Visible = false;
                tb_maphancong.Enabled = false;
            } 
            tb_nhiemvu.Text = PhanCong.NhiemVu.ToString();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (Validation(PhanCong))
            {
                chiTietPhanCongListener.onLuuClick(PhanCong);
            }else
            {
                MessageBox.Show("Giá trị không được bỏ trống");
            }
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            chiTietPhanCongListener.onHuyClick();
        }
        public interface IChiTietPhanCongListener
        {
            void onLuuClick(PhanCong phanCong);
            void onHuyClick();
        }
        private bool Validation(PhanCong phanCong)
        {
            return true;
        }

        private void tb_maphancong_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_nhiemvu_TextChanged(object sender, EventArgs e)
        {
            PhanCong.NhiemVu = tb_nhiemvu.Text.Trim();
        }
    }
}
