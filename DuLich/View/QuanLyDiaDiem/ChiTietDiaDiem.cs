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

namespace DuLich.View.QuanLyDiaDiem
{
    public partial class ChiTietDiaDiem : UserControl
    {
        private IChiTietDiaDiemListener chiTietDiaDiemListener;
        private DiaDiem diaDiem = new DiaDiem();
        private bool isEditing = false;
        public ChiTietDiaDiem(DiaDiem diaDiem, IChiTietDiaDiemListener chiTietDiaDiemListener)
        {
            InitializeComponent();
            this.chiTietDiaDiemListener = chiTietDiaDiemListener;
            this.diaDiem.MaDienDiem = diaDiem.MaDienDiem;
            this.diaDiem.TenDiaDiem = diaDiem.TenDiaDiem;
            InitUI();
        }

        private void InitUI()
        {
            tb_madiadiem.Text = diaDiem.MaDienDiem.ToString();
            if (diaDiem.MaDienDiem == 0)
            {
                tb_madiadiem.Visible = false;
                tv_madiadiem.Visible = false;
            }
            else
            {
                tb_madiadiem.Visible = true;
                tv_madiadiem.Visible = true;
                tb_madiadiem.Enabled = false;
                tb_tendiadiem.Text = diaDiem.TenDiaDiem.ToString();
            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (Validation(diaDiem))
            {
                chiTietDiaDiemListener.onLuuDiaDiem(diaDiem);
            }
            else
            {
                MessageBox.Show("Địa điểm không hợp lệ hoặc đã tồn tại");
            }
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            chiTietDiaDiemListener.onHuyDiaDiemClick();
        }
        public interface IChiTietDiaDiemListener
        {
            void onLuuDiaDiem(DiaDiem diaDiem);
            void onHuyDiaDiemClick();
        }
        private bool Validation(DiaDiem diaDiem)
        {
            return true;
        }

    
        private void tb_TenDiaDiem_TextChanged(object sender, EventArgs e)
        {
            diaDiem.TenDiaDiem = tb_tendiadiem.Text.Trim();
        }

    }
}
