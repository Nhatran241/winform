﻿using DuLich.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DuLich.GUI.QuanLyChiPhi
{
    public partial class ChiTietChiPhi : UserControl
    {
        private IChiTietChiPhiListener chiTietChiPhiListener;
        private ChiPhi chiPhiHienTai;
        private List<LoaiChiPhi> danhSachLoaiChiPhi;
        private bool isEditing = false;
        public ChiTietChiPhi(ChiPhi chiPhi,List<LoaiChiPhi> danhSachLoaiChiPhi, IChiTietChiPhiListener chiTietChiPhiListener)
        {
            InitializeComponent();
            this.chiTietChiPhiListener = chiTietChiPhiListener;
            this.chiPhiHienTai = chiPhi;
            this.danhSachLoaiChiPhi = danhSachLoaiChiPhi;
            if(chiPhi.id == 0)
            {
                CreateNewRecord();
            }
            InitUI();
        }
        public void CreateNewRecord()
        {
            chiPhiHienTai.LoaiChiPhi = danhSachLoaiChiPhi.First();
            chiPhiHienTai.ghiChu = "";
            chiPhiHienTai.giaTri = 0;
        }

        private void InitUI()
        {
            if (chiPhiHienTai.id == 0)
            {
                tb_machiphi.Text = "Mã tự động";
            } else
            {
                tb_machiphi.Text = chiPhiHienTai.id.ToString();
            } 
            tb_chiphi.Text = chiPhiHienTai.giaTri.ToString();
            combobox_loaichiphi.DataSource = danhSachLoaiChiPhi;
        combobox_loaichiphi.Text = chiPhiHienTai.LoaiChiPhi.name;
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (Validation(chiPhiHienTai))
            {
                chiTietChiPhiListener.onChiTietChiPhi_LuuClick(chiPhiHienTai.Doan,chiPhiHienTai);
            }else
            {
                MessageBox.Show("Giá trị không được bỏ trống");
            }
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            chiTietChiPhiListener.onChiTietChiPhi_HuyClick();
        }
        public interface IChiTietChiPhiListener
        {
            void onChiTietChiPhi_LuuClick(Doan doanHienTai,ChiPhi chiPhi);
            void onChiTietChiPhi_HuyClick();
        }
        private bool Validation(ChiPhi chiPhi)
        {
            return true;
        }

        private void tb_maphancong_TextChanged(object sender, EventArgs e)
        {

        }
        private void comboxloaichiphi_SelectedIndexChanged(object sender, EventArgs e)
        {
            chiPhiHienTai.LoaiChiPhi = danhSachLoaiChiPhi.ToArray()[combobox_loaichiphi.SelectedIndex];
        }


        private void tb_giatri_TextChanged(object sender, EventArgs e)
        {
            chiPhiHienTai.giaTri = long.Parse(tb_chiphi.Text.Trim());
        }

        private void tv_maphancong_Click(object sender, EventArgs e)
        {

        }

        private void tb_ghichu_TextChanged(object sender, EventArgs e)
        {
            chiPhiHienTai.ghiChu = tb_ghichu.Text;
        }
    }
}
