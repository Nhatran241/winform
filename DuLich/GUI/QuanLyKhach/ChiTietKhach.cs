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
using System.Text.RegularExpressions;

namespace DuLich.GUI.QuanLyKhach
{
    public partial class ChiTietKhach : UserControl
    {
        private IChiTietKhachListener chiTietKhachListener;
        private Khach khach = new Khach();
        private bool isEditing = false;
        public ChiTietKhach(Khach khach,IChiTietKhachListener chiTietKhachListener)
        {
            InitializeComponent();
            this.chiTietKhachListener = chiTietKhachListener;
            this.khach.KhachId = khach.KhachId;
            this.khach.GioiTinh = khach.GioiTinh;
            this.khach.DoanKhachs = khach.DoanKhachs;
            this.khach.DiaChi = khach.DiaChi;
            this.khach.NgaySinh = khach.NgaySinh;
            this.khach.SoCmnd = khach.SoCmnd;
            this.khach.SoDienThoai = khach.SoDienThoai;
            this.khach.Ten = khach.Ten;

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
            foreach (string s in gioitinh)
            {
                cb_gioitinh.Items.Add(s);
            }
            if (khach.KhachId != 0)
            {
                tb_name.Text = khach.Ten.ToString();
                tb_sdt.Text = khach.SoDienThoai.ToString();
                tb_diaChi.Text = khach.DiaChi.ToString();
                tb_cmnd.Text = khach.SoCmnd.ToString();
                datepicker_ngaysinh.Value = khach.NgaySinh;
                cb_gioitinh.SelectedItem = khach.GioiTinh;
            }
            else
            {
                cb_gioitinh.SelectedItem = gioitinh.First();
            }
            datepicker_ngaysinh.MaxDate = DateTime.Today.AddDays(-(18 * 365));
        }

        private void tb_name_TextChanged(object sender, EventArgs e)
        {
                khach.Ten = tb_name.Text.Trim();
        }

        private void tb_diaChi_TextChanged(object sender, EventArgs e)
        {
                khach.DiaChi = tb_diaChi.Text.Trim();
        }

        private void tb_sdt_TextChanged(object sender, EventArgs e)
        {
                khach.SoDienThoai = tb_sdt.Text.Trim();
        }

        private void tb_cmnd_TextChanged(object sender, EventArgs e)
        {
                khach.SoCmnd = tb_cmnd.Text.Trim();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(khach.Ten))
            {
                MessageBox.Show("Tên khách không được để trống");
            }
            else
             if (string.IsNullOrEmpty(khach.DiaChi))
            {
                MessageBox.Show("Địa chỉ khách không được để trống");
            }
            else
            if (string.IsNullOrEmpty(khach.SoDienThoai))
            {
                MessageBox.Show("Số điện thoại không được để trống");
            }
            else if (IsPhoneNumber(khach.SoDienThoai))
            {
                MessageBox.Show("Số điện thoại không hợp lệ");
            }
            else
           if (string.IsNullOrEmpty(khach.SoCmnd))
            {
                MessageBox.Show("Số chứng minh nhân dân không được để trống");
            }
            else if (IsCmndNumber(khach.SoCmnd))
            {
                MessageBox.Show("Số chứng minh nhân dân không hợp lệ");
            }else
            chiTietKhachListener.onLuuKhachClick(khach);
        }
        public bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^(\+[0-9]{9})$").Success;
        }
        public bool IsCmndNumber(string number)
        {
            return Regex.Match(number, @"^(\+[0-9])$").Success;
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

        private void tb_sdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tb_cmnd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
