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
    public partial class ChiTietDoan : UserControl
    {
        private IChiTietDoanListener chiTietDoanListener;
        private Doan doan;
        private List<Touris> touris;
        public ChiTietDoan(Doan doan, IChiTietDoanListener chiTietDoanListener, List<Touris> touris)
        {
            InitializeComponent();
            this.chiTietDoanListener = chiTietDoanListener;
            this.doan = doan;
            this.touris = touris;
            InitUI();
        }

        private void InitUI()

        {
            foreach (Touris tour in touris)
            {
                if (doan.Touris != null && tour.Id == doan.Touris.Id)
                    doan.Touris = tour;
                comboBox1.Items.Add(tour);
            }
            if (doan.Touris != null)
            {
                comboBox1.Text = doan.Touris.Name;
            }
            if (doan.ThoiGianBatDau.Year < 1500 && doan.ThoiGianKetThuc.Year < 1500)
            {
                datepicker_batdau.Value = DateTime.Today;
                datepicker_ketthuc.Value = DateTime.Today;
            }
            else
            {
                datepicker_batdau.Value = doan.ThoiGianBatDau;
                datepicker_ketthuc.Value = doan.ThoiGianKetThuc;
            }
        }

        private void tv_giatri_Click(object sender, EventArgs e)
        {

        }
        public interface IChiTietDoanListener
        {
            void onLuuClick(Doan doan);
            void onHuyClick();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            doan.ThoiGianBatDau = datepicker_batdau.Value.Date;
            doan.ThoiGianKetThuc = datepicker_ketthuc.Value.Date;
            chiTietDoanListener.onLuuClick(doan);
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            chiTietDoanListener.onHuyClick();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            doan.Touris = touris.ToArray()[comboBox1.SelectedIndex];
        }

        private void listview_doan_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
        }
    }
}
