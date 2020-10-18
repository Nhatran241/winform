using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DuLich.Entity;

namespace DuLich.GUI.QuanLyNhanVien
{
    public partial class DanhSachNhanVien : UserControl
    {
        private IDanhSachNhanVienListener danhSachNhanVienListener;
        private List<NhanVien> danhSachNhanVien;
        public DanhSachNhanVien(List<NhanVien> danhSachNhanVien, IDanhSachNhanVienListener danhSachNhanVienListener)
        {
            InitializeComponent();
            this.danhSachNhanVienListener = danhSachNhanVienListener;
            this.danhSachNhanVien = danhSachNhanVien;
            InitData(danhSachNhanVien);
        }
        private void InitData(List<NhanVien> danhSachNhanVienListener)
        {
            foreach (NhanVien nhanVien in danhSachNhanVien)
            {
                listview_nhanvien.Items.Add(new ListViewItem(new string[] { nhanVien.TenNhanVien,nhanVien.DiaChi, nhanVien.SoDienThoai,nhanVien.SoCmnd }));
            }
        }
        private void listview_nhanvien_SelectedIndexChanged(object sender, EventArgs e)
        {
            int position = listview_nhanvien.SelectedIndices.Count;
            if (position > 0)
            {
                btn_sua_nhanvien.Visible = true;
                btn_xoa_nhanvien.Visible = true;
            }
            else
            {
                btn_sua_nhanvien.Visible = false;
                btn_xoa_nhanvien.Visible = false;
            }
        }
        public interface IDanhSachNhanVienListener
        {
            void onDanhSachNhanVien_ThemClick();
            void onDanhSachNhanVien_SuaClick(NhanVien nhanVien);
            void onDanhSachNhanVien_XoaClick(NhanVien nhanVien);
        }

        private void btn_them_nhanvien_Click(object sender, EventArgs e)
        {
            danhSachNhanVienListener.onDanhSachNhanVien_ThemClick();
        }

        private void btn_xoa_nhanvien_Click(object sender, EventArgs e)
        {
            if (listview_nhanvien.SelectedItems.Count > 0)
            {
                int position = listview_nhanvien.SelectedItems[0].Index;
                danhSachNhanVienListener.onDanhSachNhanVien_XoaClick(danhSachNhanVien.ToArray()[position]);
            }
            
        }

        private void btn_sua_nhanvien_Click(object sender, EventArgs e)
        {
            if (listview_nhanvien.SelectedItems.Count > 0)
            {
                int position = listview_nhanvien.SelectedItems[0].Index;
                danhSachNhanVienListener.onDanhSachNhanVien_SuaClick(danhSachNhanVien.ToArray()[position]);

            }

        }
    }
}
