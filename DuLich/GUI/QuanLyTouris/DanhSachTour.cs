using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DuLich.BUS;

namespace DuLich.GUI.QuanLyTouris
{

    public partial class DanhSachTour : UserControl,SearchTour.ISearchListener
    {
        private IDanhSachTourListener danhSachTourListener;
        private IEnumerable<Tour> danhSachTour;
        public DanhSachTour()
        {
            InitializeComponent();
        }
        public DanhSachTour(IEnumerable<Tour> tourisList, List<Loai> loaisList, IDanhSachTourListener danhSachTourListener)
        {
            InitializeComponent();
            this.danhSachTourListener = danhSachTourListener;
            this.danhSachTour = tourisList;
            InitData(tourisList, loaisList);
        }

        private void InitData(IEnumerable<Tour> tourisList, List<Loai> loaisList)
        {
            search1.SetData(loaisList, this);
            dataGridViewTour.DataSource = tourisList;
        }

     
        public interface IDanhSachTourListener
        {
            void onDanhSachTour_TourDoubleClick(Tour touris);
            void onDanhSachTour_ThemClick();
            void onDanhSachTour_XoaClick(Tour tour);
        }

        private void TourSelected(object sender, DataGridViewCellEventArgs e)
        {
            int position = dataGridViewTour.CurrentCell.RowIndex;
            danhSachTourListener.onDanhSachTour_TourDoubleClick(danhSachTour.ToList()[position]);
        }

        public void onSearch(Loai loai, string ten)
        {
            if(!ten.Equals(""))
            {
                if (loai.Id == -1) {
                    dataGridViewTour.DataSource = danhSachTour.Where(c => c.Name.ToLower().Contains(ten)).ToList();
                }else
                {
                    dataGridViewTour.DataSource = danhSachTour.Where(c => c.Name.ToLower().Contains(ten) && c.Loai.Id == loai.Id).ToList();
                }
            }
            else
            {
                if (loai.Id != -1)
                {
                    dataGridViewTour.DataSource = danhSachTour.Where(c => c.Loai.Id == loai.Id).ToList();
                }else dataGridViewTour.DataSource = danhSachTour.ToList();
            }
           
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            danhSachTourListener.onDanhSachTour_ThemClick();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            int position = dataGridViewTour.CurrentCell.RowIndex;
            danhSachTourListener.onDanhSachTour_XoaClick(danhSachTour.ToList()[position]);
        }
    }
}
