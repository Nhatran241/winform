using DuLich.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DuLich.GUI.QuanLyPhanCong
{
    public partial class FromPhanCong : Form
    {
        private IChiTietPhanCongListener chiTietPhanCongListener;
        private PhanCong phanCongHienTai = new PhanCong();
        private List<NhanVien> danhSachNhanVien = new List<NhanVien>();
        private List<String> danhSachNhiemVu;
        private bool isEditing = false;
        public FromPhanCong(PhanCong phanCong, List<NhanVien> danhSachNhanVien, IChiTietPhanCongListener chiTietPhanCongListener)
        {
            InitializeComponent();
            phanCongHienTai.MaPhanCong = phanCong.MaPhanCong;
            phanCongHienTai.Doan = phanCong.Doan;
            phanCongHienTai.NhanVien = phanCong.NhanVien;
            phanCongHienTai.NhiemVu = phanCong.NhiemVu;
            danhSachNhiemVu = new List<string>();
            danhSachNhiemVu.Add("Hướng Dẫn Viên");
            danhSachNhiemVu.Add("Lái Xe");
            danhSachNhiemVu.Add("Trưởng Đoàn");
            this.chiTietPhanCongListener = chiTietPhanCongListener;
            this.danhSachNhanVien.AddRange(danhSachNhanVien);
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
            foreach(NhanVien nhanVien in danhSachNhanVien)
            {
                combobox_nhanvien.Items.Add(nhanVien);
            }
            combobox_nhanvien.SelectedItem = phanCongHienTai.NhanVien;
            foreach(String nv in danhSachNhiemVu)
            {
                cb_nhiemvu.Items.Add(nv);
            }
            cb_nhiemvu.SelectedItem = phanCongHienTai.NhiemVu;

        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (Validation(phanCongHienTai))
            {
                chiTietPhanCongListener.onChiTietPhanCong_LuuClick(phanCongHienTai.Doan, phanCongHienTai);
            }
            else
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
            void onChiTietPhanCong_LuuClick(Doan doanHienTai, PhanCong phanCong);
            void onChiTietPhanCong_HuyClick();
        }
        private bool Validation(PhanCong phanCong)
        {
            return true;
        }

        private void tb_maphancong_TextChanged(object sender, EventArgs e)
        {

        }

        private void cb_nhiemvu_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            phanCongHienTai.NhiemVu = danhSachNhiemVu.ToArray()[cb_nhiemvu.SelectedIndex];
        }

        private void combobox_nhanvien_SelectedIndexChanged(object sender, EventArgs e)
        {

            phanCongHienTai.NhanVien = danhSachNhanVien.ToArray()[combobox_nhanvien.SelectedIndex];
        }
    }
}
