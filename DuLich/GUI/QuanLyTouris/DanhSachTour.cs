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
using System.Collections;

namespace DuLich.GUI.QuanLyTouris
{

    public partial class DanhSachTour : UserControl,SearchTour.ISearchListener
    {
        private IDanhSachTourListener danhSachTourListener;
        private IEnumerable<Touris> danhSachTour;
        public DanhSachTour()
        {
            InitializeComponent();
        }
        public DanhSachTour(IEnumerable<Touris> tourisList, List<Loai> loaisList, IDanhSachTourListener danhSachTourListener)
        {
            InitializeComponent();
            this.danhSachTourListener = danhSachTourListener;
            this.danhSachTour = tourisList;
            InitData(tourisList, loaisList);
        }

        private void InitData(IEnumerable<Touris> tourisList, List<Loai> loaisList)
        {
            search1.SetData(loaisList, this);
            dataGridViewTour.DataSource = tourisList;
        }

     
        public interface IDanhSachTourListener
        {
            void onTourSelected(Touris touris);
        }

        private void TourSelected(object sender, DataGridViewCellEventArgs e)
        {
            int position = dataGridViewTour.CurrentCell.RowIndex;
            danhSachTourListener.onTourSelected(danhSachTour.ToList()[position]);
        }

        public void onSearch(Loai loai, string ten)
        {
            if(!ten.Equals(""))
            {
                if (loai.Id == -1) {
                    dataGridViewTour.DataSource = danhSachTour.Where(c => c.Name.Contains(ten)).ToList();
                }else
                {
                    dataGridViewTour.DataSource = danhSachTour.Where(c => c.Name.Contains(ten) && c.Loai.Id == loai.Id).ToList();
                }
            }
            else
            {
                if (loai.Id != -1)
                {
                    dataGridViewTour.DataSource = danhSachTour.Where(c => c.Loai.Id == loai.Id).ToList();
                }
            }
           
        }

    }
}
