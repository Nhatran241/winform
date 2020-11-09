using System;
using System.Windows.Forms;
using DuLich.BUS;

namespace DuLich.GUI.QuanLyDiaDiem
{
    public partial class ChiTietDiaDiem : Form
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
            if (diaDiem.MaDienDiem == 0)
            {
                tb_madiadiem.Text = "Mã tự động";
            }
            else
            {
                tb_madiadiem.Text = diaDiem.MaDienDiem.ToString();
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
                MessageBox.Show("Tên địa điểm không được để trống hoặc không được trùng");
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
            if (diaDiem.TenDiaDiem == null || diaDiem.TenDiaDiem.Equals(""))
                return false;
            if (diaDiem.GetDiaDiemByName(diaDiem.TenDiaDiem) != null)
                return false;
            return true;
        }

    
        private void tb_TenDiaDiem_TextChanged(object sender, EventArgs e)
        {
            diaDiem.TenDiaDiem = tb_tendiadiem.Text.Trim();
        }

    }
}
