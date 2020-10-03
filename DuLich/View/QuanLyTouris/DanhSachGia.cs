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
using DuLich.Model.Entity;

namespace DuLich.View.QuanLyTouris
{
    public partial class DanhSachGia : UserControl
    {
        private IDanhSachGiaListener danhSachGiaCallBack;
        private IEnumerable<Gia> gias;
        public DanhSachGia(IEnumerable<Gia> gias, IDanhSachGiaListener danhSachGiaCallBack)
        {
            InitializeComponent();
            this.danhSachGiaCallBack = danhSachGiaCallBack;
            this.gias = gias;
            InitData(gias);
        }
        private void InitData(IEnumerable<Gia> gias)
        {

            var info = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
            foreach (Gia gia in gias)
            {
                listview_gia.Items.Add(new ListViewItem(new string[] { String.Format(info, "{0:c}", gia.GiaTri), gia.ThoiGianBatDau.ToString(),gia.ThoiGianKetThuc.ToString()}));
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int position = listview_gia.SelectedIndices.Count;
            if (position > 0)
            {
                btn_sua_gia.Visible = true;
                btn_xoa_gia.Visible = true;
            }else
            {
                btn_sua_gia.Visible = false;
                btn_xoa_gia.Visible = false;
            }

        }

        private void btn_them_gia_Click(object sender, EventArgs e)
        {
            danhSachGiaCallBack.onDanhSachGiaThemClick();
        }
     

        private void btn_sua_gia_Click(object sender, EventArgs e)
        {

            int position = listview_gia.SelectedItems[0].Index;
            danhSachGiaCallBack.onDanhSachGiaSuaClick(gias.ToArray()[position]);
        }

        private void btn_xoa_gia_Click(object sender, EventArgs e)
        {
            if (listview_gia.SelectedItems.Count > 0)
            {
                int position = listview_gia.SelectedItems[0].Index;
                danhSachGiaCallBack.onDanhSachGiaXoaClick(gias.ToArray()[position]);
            }
        }
        public interface IDanhSachGiaListener
        {
            void onDanhSachGiaThemClick();
            void onDanhSachGiaSuaClick(Gia gia);
            void onDanhSachGiaXoaClick(Gia gia);
        }
    }
}
