﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DuLich.Entity;
using DuLich.Model.Entity;

namespace DuLich.GUI.QuanLyNhanVien
{
    public partial class ChiTietNhanVien : UserControl
    {
        private IChiTietNhanVienListener chiTietNhanVienListener;
        private NhanVien nhanVien;
        private bool isEditing = false;
        public ChiTietNhanVien(NhanVien nhanVien, IChiTietNhanVienListener chiTietNhanVienListener)
        {
            InitializeComponent();
            this.chiTietNhanVienListener = chiTietNhanVienListener;
            this.nhanVien = nhanVien;
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
            if (nhanVien.MaNhanVien != 0)
            {
                tb_name.Text = nhanVien.TenNhanVien.ToString();
                tb_sdt.Text = nhanVien.SoDienThoai.ToString();
                tb_diaChi.Text = nhanVien.DiaChi.ToString();
                tb_cmnd.Text = nhanVien.SoCmnd.ToString();
                datepicker_ngaysinh.Value = nhanVien.NgaySinh;
                cb_gioitinh.Text = nhanVien.GioiTinh;
            }
            foreach(string s in gioitinh)
            {
                cb_gioitinh.Items.Add(s);
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
          chiTietNhanVienListener.onChiTietNhanVien_LuuClick(nhanVien);
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
    }
}