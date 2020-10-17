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

namespace DuLich.View.QuanLyDoan
{
    public partial class DanhSachDoan : UserControl
    {
        private IDanhSachDoanListener danhSachDoanListener;
        private List<Doan> danhSachDoan;
        public DanhSachDoan(List<Doan> doans, List<Touris> tours,IDanhSachDoanListener danhSachDoanListener)
        {
            InitializeComponent();
            danhSachDoan = doans;
            this.danhSachDoanListener = danhSachDoanListener;
            InitData(danhSachDoan, tours);
        }

        private void InitData(IEnumerable<Doan> doans,IEnumerable<Touris> tour)
        {
          foreach(Doan doan in doans)
            {
                list_doan.Items.Add(new ListViewItem(new string[] { doan.Id.ToString(), doan.Name , tour.First(c =>c.Id == doan.Touris.Id).Name}));
            } 
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int position = list_doan.SelectedItems[0].Index;
            danhSachDoanListener.onDanhSachDoan_DoanSelectedIndex(position);
        }
        public interface IDanhSachDoanListener
        {
            void onDanhSachDoan_DoanSelectedIndex(int position);
        }
    }
}
