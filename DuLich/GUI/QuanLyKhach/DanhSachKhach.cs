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

namespace DuLich.GUI.QuanLyKhach
{
    public partial class DanhSachKhach : UserControl
    {
        private IDanhSachKhachListener danhSachKhachCallBack;
        private IEnumerable<Khach> khaches;
        public DanhSachKhach(IEnumerable<Khach> khaches, IDanhSachKhachListener danhSachKhachCallBack)
        {
            InitializeComponent();
            this.danhSachKhachCallBack = danhSachKhachCallBack;
            this.khaches = khaches;
            InitData(khaches);
        }
        private void InitData(IEnumerable<Khach> khaches)
        {

            foreach (Khach khach in khaches)
            {
                listview_doan.Items.Add(new ListViewItem(new string[] { khach.Ten,khach.DiaChi, khach.SoDienThoai,khach.SoCmnd }));
            }
        }
        private void listview_doan_SelectedIndexChanged(object sender, EventArgs e)
        {
            int position = listview_doan.SelectedIndices.Count;
            if (position > 0)
            {
                btn_sua_doan.Visible = true;
                btn_xoa_doan.Visible = true;
            }
            else
            {
                btn_sua_doan.Visible = false;
                btn_xoa_doan.Visible = false;
            }
        }
        public interface IDanhSachKhachListener
        {
            void onDanhSachKhachThemClick();
            void onDanhSachKhachSuaClick(Khach doan);
            void onDanhSachKhachXoaClick(Khach doan);
        }

        private void btn_them_doan_Click(object sender, EventArgs e)
        {
            danhSachKhachCallBack.onDanhSachKhachThemClick();
        }

        private void btn_xoa_doan_Click(object sender, EventArgs e)
        {
            if (listview_doan.SelectedItems.Count > 0)
            {
                int position = listview_doan.SelectedItems[0].Index;
                danhSachKhachCallBack.onDanhSachKhachXoaClick(khaches.ToArray()[position]);
            }
            
        }

        private void btn_sua_doan_Click(object sender, EventArgs e)
        {
            if (listview_doan.SelectedItems.Count > 0)
            {
                int position = listview_doan.SelectedItems[0].Index;
                danhSachKhachCallBack.onDanhSachKhachSuaClick(khaches.ToArray()[position]);

            }

        }
    }
}
