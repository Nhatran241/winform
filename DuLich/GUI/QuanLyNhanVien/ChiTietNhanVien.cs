using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DuLich.BUS;
using System.Text.RegularExpressions;

namespace DuLich.GUI.QuanLyNhanVien
{
    public partial class ChiTietNhanVien : UserControl
    {
        private IChiTietNhanVienListener chiTietNhanVienListener;
        private NhanVien nhanVien = new NhanVien();
        private bool isEditing = false;
        public ChiTietNhanVien(NhanVien nhanVien, IChiTietNhanVienListener chiTietNhanVienListener)
        {
            InitializeComponent();
            this.chiTietNhanVienListener = chiTietNhanVienListener;
            this.nhanVien.MaNhanVien = nhanVien.MaNhanVien;
            this.nhanVien.TenNhanVien = nhanVien.TenNhanVien;
            this.nhanVien.GioiTinh = nhanVien.GioiTinh;
            this.nhanVien.DiaChi = nhanVien.DiaChi;
            this.nhanVien.NgaySinh = nhanVien.NgaySinh;
            this.nhanVien.PhanCongs = nhanVien.PhanCongs;
            this.nhanVien.SoCmnd = nhanVien.SoCmnd;
            this.nhanVien.SoDienThoai = nhanVien.SoDienThoai;
            InitUI();
        }

        public interface IChiTietNhanVienListener
        {
            void onChiTietNhanVien_LuuClick(NhanVien nhanVien);
            void onChiTietNhanVien_HuyClick();
        }
        private void InitUI()
        {
            List<string> gioitinh = new List<string> { "Nam", "Nữ", "Khác" };
            foreach (string s in gioitinh)
            {
                cb_gioitinh.Items.Add(s);
            }
            if (nhanVien.MaNhanVien != 0)
            {
                tb_name.Text = nhanVien.TenNhanVien.ToString();
                tb_sdt.Text = nhanVien.SoDienThoai.ToString();
                tb_diaChi.Text = nhanVien.DiaChi.ToString();
                tb_cmnd.Text = nhanVien.SoCmnd.ToString();
                datepicker_ngaysinh.Value = nhanVien.NgaySinh;
                cb_gioitinh.SelectedItem = nhanVien.GioiTinh;
            }else
            {
                cb_gioitinh.SelectedItem = gioitinh.First();
            }
            

            datepicker_ngaysinh.MaxDate = DateTime.Today.AddDays(-(18 * 365));
        }

        private void tb_name_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_name.Text))
            {
                nhanVien.TenNhanVien = tb_name.Text.Trim();
            }
            
           
        }

        private void tb_diaChi_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_diaChi.Text))
            {
                nhanVien.DiaChi = tb_diaChi.Text.Trim();
            }
        }

        private void tb_sdt_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_sdt.Text))
            {
                nhanVien.SoDienThoai = tb_sdt.Text.Trim();
            }
        }

        private void tb_cmnd_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(tb_cmnd.Text))
            {
                nhanVien.SoCmnd = tb_cmnd.Text.Trim();
            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nhanVien.TenNhanVien))
            {
                MessageBox.Show("Tên nhân viên không được để trống");
            }else
             if (string.IsNullOrEmpty(nhanVien.DiaChi))
            {
                MessageBox.Show("Địa chỉ nhân viên không được để trống");
            }
            else
            if (string.IsNullOrEmpty(nhanVien.SoDienThoai))
            {
                MessageBox.Show("Số điện thoại không được để trống");
            }else if (IsPhoneNumber(nhanVien.SoDienThoai))
            {
                MessageBox.Show("Số điện thoại không hợp lệ");
            }else
            if (string.IsNullOrEmpty(nhanVien.SoCmnd))
            {
                MessageBox.Show("Số chứng minh nhân dân không được để trống");
            }else if (IsCmndNumber(nhanVien.SoCmnd))
            {
                MessageBox.Show("Số chứng minh nhân dân không hợp lệ");
            }
            chiTietNhanVienListener.onChiTietNhanVien_LuuClick(nhanVien);
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
            chiTietNhanVienListener.onChiTietNhanVien_HuyClick();
        }

        private void datepicker_ngaysinh_ValueChanged(object sender, EventArgs e)
        {
            nhanVien.NgaySinh = datepicker_ngaysinh.Value;
        }

        private void cb_gioitinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            nhanVien.GioiTinh = (string)cb_gioitinh.SelectedItem;
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
