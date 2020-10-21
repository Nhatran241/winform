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
using DuLich.Entity;

namespace DuLich.GUI.QuanLyChiPhi
{
    public partial class ChiTietChiPhi : UserControl
    {
        private IChiTietPhanCongListener chiTietPhanCongListener;
        private PhanCong phanCongHienTai;
        private List<NhanVien> danhSachNhanVien;
        private bool isEditing = false;
        public ChiTietChiPhi(PhanCong phanCong,List<NhanVien> danhSachNhanVien,IChiTietPhanCongListener chiTietPhanCongListener)
        {
            InitializeComponent();
            this.chiTietPhanCongListener = chiTietPhanCongListener;
            this.phanCongHienTai = phanCong;
            this.danhSachNhanVien = danhSachNhanVien;
            if(phanCongHienTai.MaPhanCong == 0)
            {
                CreateNewRecord();
            }
            InitUI();
        }
        public void CreateNewRecord()
        {
            phanCongHienTai.NhanVien = danhSachNhanVien.First();
            phanCongHienTai.NhiemVu = "";
        }

        private void InitUI()
        {
            tb_maphancong.Text = phanCongHienTai.MaPhanCong.ToString();
            if (phanCongHienTai.MaPhanCong == 0)
            {
                tb_maphancong.Visible = false;
                tv_maphancong.Visible = false;
            } else {
                tb_maphancong.Visible = false;
                tv_maphancong.Visible = false;
                tb_maphancong.Enabled = false;
            } 
            tb_nhiemvu.Text = phanCongHienTai.NhiemVu.ToString();
            foreach (NhanVien nhanVien in danhSachNhanVien)
            {
                combobox_nhanvien.Items.Add(nhanVien);
            }

            combobox_nhanvien.Text = phanCongHienTai.NhanVien.TenNhanVien;
          
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (Validation(phanCongHienTai))
            {
                chiTietPhanCongListener.onLuuClick(phanCongHienTai);
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
        private void comboxnhanvien_SelectedIndexChanged(object sender, EventArgs e)
        {
            phanCongHienTai.NhanVien = danhSachNhanVien.ToArray()[combobox_nhanvien.SelectedIndex];
        }


        private void tb_nhiemvu_TextChanged(object sender, EventArgs e)
        {
            phanCongHienTai.NhiemVu = tb_nhiemvu.Text.Trim();
        }
    }
}
