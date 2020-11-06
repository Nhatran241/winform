using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DuLich.BUS;

namespace DuLich.GUI.QuanLyKhach
{
    public partial class ChiTietKhach : UserControl
    {
        private IChiTietKhachListener chiTietKhachListener;
        private Khach khach;
        private bool isEditing = false;
        public ChiTietKhach(Khach khach,IChiTietKhachListener chiTietKhachListener)
        {
            InitializeComponent();
            this.chiTietKhachListener = chiTietKhachListener;
            this.khach = khach;
            InitUI();
        }

        public interface IChiTietKhachListener
        {
            void onLuuKhachClick(Khach khach);
            void onHuyKhachClick();
        }
        private void InitUI()
        {
            List<string> gioitinh = new List<string> { "Nam", "Nữ", "Khác" };
            if (khach.KhachId != 0)
            {
                tb_name.Text = khach.Ten.ToString();
                tb_sdt.Text = khach.SoDienThoai.ToString();
                tb_diaChi.Text = khach.DiaChi.ToString();
                tb_cmnd.Text = khach.SoCmnd.ToString();
                datepicker_ngaysinh.Value = khach.NgaySinh;
                cb_gioitinh.Text = khach.GioiTinh;
            }
            foreach (string s in gioitinh)
            {
                cb_gioitinh.Items.Add(s);
            }
            datepicker_ngaysinh.MaxDate = DateTime.Today.AddDays(-(18 * 365));
        }

        private void tb_name_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_name.Text))
            {
                khach.Ten = tb_name.Text.Trim();
            }
            
           
        }

        private void tb_diaChi_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_diaChi.Text))
            {
                khach.DiaChi = tb_diaChi.Text.Trim();
            }
        }

        private void tb_sdt_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_sdt.Text))
            {
                khach.SoDienThoai = tb_sdt.Text.Trim();
            }
        }

        private void tb_cmnd_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(tb_cmnd.Text))
            {
                khach.SoCmnd = tb_cmnd.Text.Trim();
            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
          chiTietKhachListener.onLuuKhachClick(khach);
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            chiTietKhachListener.onHuyKhachClick();
        }

        private void datepicker_ngaysinh_ValueChanged(object sender, EventArgs e)
        {
            khach.NgaySinh = datepicker_ngaysinh.Value;
        }

        private void cb_gioitinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            khach.GioiTinh = (string)cb_gioitinh.SelectedItem;
        }
    }
}
