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

namespace DuLich.GUI.QuanLyDoan
{
    public partial class DanhSachDoan : UserControl
    {
        private IDanhSachDoanListener danhSachDoanCallBack;
        private IEnumerable<Doan> doans;
        public DanhSachDoan(IEnumerable<Doan> doans, IDanhSachDoanListener danhSachDoanCallBack)
        {
            InitializeComponent();
            this.danhSachDoanCallBack = danhSachDoanCallBack;
            this.doans = doans;
            InitData(doans);
        }

        private void InitData(IEnumerable<Doan> doans)
        {

            foreach (Doan doan in doans)
            {
                listview_doan.Items.Add(new ListViewItem(new string[] { doan.Touris.Name, doan.ThoiGianBatDau.ToString(), doan.ThoiGianKetThuc.ToString() }));
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
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

       
        
        public interface IDanhSachDoanListener
        {
            void onDanhSachDoanThemClick();
            void onDanhSachDoanSuaClick(Doan doan);
            void onDanhSachDoanXoaClick(Doan doan);
        }

        private void btn_them_doan_Click_1(object sender, EventArgs e)
        {
            danhSachDoanCallBack.onDanhSachDoanThemClick();
        }

        private void btn_sua_doan_Click_1(object sender, EventArgs e)
        {
            int position = listview_doan.SelectedItems[0].Index;
            danhSachDoanCallBack.onDanhSachDoanSuaClick(doans.ToArray()[position]);
        }

        private void btn_xoa_doan_Click_1(object sender, EventArgs e)
        {
            if (listview_doan.SelectedItems.Count > 0)
            {
                int position = listview_doan.SelectedItems[0].Index;
                danhSachDoanCallBack.onDanhSachDoanXoaClick(doans.ToArray()[position]);
            }
        }

        private void btn_sua_doan_Click(object sender, EventArgs e)
        {
            if (listview_doan.SelectedItems.Count > 0)
            {
                int position = listview_doan.SelectedItems[0].Index;
                danhSachDoanCallBack.onDanhSachDoanSuaClick(doans.ToArray()[position]);
            }
                
        }

        private void btn_xoa_doan_Click(object sender, EventArgs e)
        {
            if (listview_doan.SelectedItems.Count > 0)
            {
                int position = listview_doan.SelectedItems[0].Index;
                danhSachDoanCallBack.onDanhSachDoanXoaClick(doans.ToArray()[position]);
            }
        }
    }
}
