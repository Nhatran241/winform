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
        private IDanhSachGiaCallBack danhSachGiaCallBack;
        private IEnumerable<Gia> gias;
        public DanhSachGia(IEnumerable<Gia> gias, IDanhSachGiaCallBack danhSachGiaCallBack)
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

        }

        private void btn_them_gia_Click(object sender, EventArgs e)
        {
            danhSachGiaCallBack.OnClickThemGia();
        }
     

        private void btn_sua_gia_Click(object sender, EventArgs e)
        {

            int position = listview_gia.SelectedItems[0].Index;
            danhSachGiaCallBack.OnClickSuaGia(gias.ToArray()[position]);
        }

        private void btn_xoa_gia_Click(object sender, EventArgs e)
        {
            int position = listview_gia.SelectedItems[0].Index;
            danhSachGiaCallBack.OnClickXoaGia(gias.ToArray()[position]);
        }
        public interface IDanhSachGiaCallBack
        {
            void OnClickThemGia();
            void OnClickSuaGia(Gia gia);
            void OnClickXoaGia(Gia gia);
        }
    }
}
