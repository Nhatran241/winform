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
            Dictionary<int, String> keyValuePairsTemp = new Dictionary<int, string>();

            foreach(Touris tour in touris)
            {
                keyValuePairsTemp.Add(tour.Id, tour.Name);
            }
            if (keyValuePairsTemp.Count > 0)
            {
                comboBox1.DataSource = new BindingSource(keyValuePairsTemp, null);
                comboBox1.DisplayMember = "Value";
                comboBox1.ValueMember = "Key";

                // Get combobox selection (in handler)
                //  string value = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Value;
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
            chiTietDoanListener.onLuuClick(doan);
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {

        }
    }
}
