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
        public DanhSachGia(IEnumerable<Gia> gias)
        {
            InitializeComponent();
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
    }
}
