using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DuLich.BUS;

namespace DuLich.GUI.QuanLyPhanCong
{
    public partial class ChiTietPhanCong : UserControl
    {
        private IChiTietPhanCongListener chiTietPhanCongListener;
        private PhanCong phanCongHienTai;
        private List<NhanVien> danhSachNhanVien;
        private List<String> danhSachNhiemVu;
        private bool isEditing = false;
        public ChiTietPhanCong(PhanCong phanCong,List<NhanVien> danhSachNhanVien,IChiTietPhanCongListener chiTietPhanCongListener)
        {
            InitializeComponent();
            this.chiTietPhanCongListener = chiTietPhanCongListener;
            this.phanCongHienTai = phanCong;
            this.danhSachNhanVien = danhSachNhanVien;
            danhSachNhiemVu = new List<string>();
            danhSachNhiemVu.Add("Hướng Dẫn Viên");
            danhSachNhiemVu.Add("Lái Xe");
            danhSachNhiemVu.Add("Trưởng Đoàn");
            if (phanCongHienTai.MaPhanCong == 0)
            {
                CreateNewRecord();
            }
            InitUI();
        }
        public void CreateNewRecord()
        {
            phanCongHienTai.NhanVien = danhSachNhanVien.First();
            phanCongHienTai.NhiemVu = danhSachNhiemVu.First();
        }

        private void InitUI()
        {
            if (phanCongHienTai.MaPhanCong != 0)
            {
                tb_maphancong.Text = phanCongHienTai.MaPhanCong.ToString();
            }
            else tb_maphancong.Text = "Mã tự động";
            tb_maphancong.Enabled = false;
            combobox_nhanvien.DataSource = danhSachNhanVien;
            combobox_nhanvien.Text = phanCongHienTai.NhanVien.TenNhanVien;

            cb_nhiemvu.DataSource = danhSachNhiemVu;
            cb_nhiemvu.Text = phanCongHienTai.NhiemVu;
          
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (Validation(phanCongHienTai))
            {
                chiTietPhanCongListener.onChiTietPhanCong_LuuClick(phanCongHienTai.Doan,phanCongHienTai);
            }else
            {
                MessageBox.Show("Giá trị không được bỏ trống");
            }
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            chiTietPhanCongListener.onChiTietPhanCong_HuyClick();
        }
        public interface IChiTietPhanCongListener
        {
            void onChiTietPhanCong_LuuClick(Doan doanHienTai,PhanCong phanCong);
            void onChiTietPhanCong_HuyClick();
        }
        private bool Validation(PhanCong phanCong)
        {
            return true;
        }

        private void tb_maphancong_TextChanged(object sender, EventArgs e)
        {

        }
        private void comboxnhanvien_SelectedIndexChanged(object sender, EventArgs e)
        {
            phanCongHienTai.NhanVien = danhSachNhanVien.ToArray()[combobox_nhanvien.SelectedIndex];
        }

        private void cb_nhiemvu_SelectedIndexChanged(object sender, EventArgs e)
        {
            phanCongHienTai.NhiemVu = danhSachNhiemVu.ToArray()[cb_nhiemvu.SelectedIndex];
        }
    }
}
