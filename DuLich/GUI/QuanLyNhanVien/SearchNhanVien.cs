using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DuLich.Model.Entity;

namespace DuLich.GUI.QuanLyNhanVien
{
    public partial class SearchNhanVien : UserControl
    {
        private String filterTen = "";
        private DateTime minDate = new DateTime();
        private DateTime maxDate = new DateTime();
        private ISearchNhanVienListener searchNhanVienListener;

        public SearchNhanVien()
        {
            InitializeComponent();
        }
        public void SetData(ISearchNhanVienListener searchNhanVienListener,DateTime min,DateTime max)
        {
            this.searchNhanVienListener = searchNhanVienListener;
            this.minDate = min;
            this.maxDate = max;
            InitData();
        }

        private void InitData()
        {

            datepicker_batdau.MinDate = minDate;
            datepicker_batdau.MaxDate = maxDate;
            datepicker_ketthuc.MaxDate = maxDate;
            datepicker_ketthuc.MinDate = minDate;
            datepicker_batdau.Value = minDate;
            datepicker_ketthuc.Value = maxDate;
        }


        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            filterTen = tb_search.Text.Trim().ToLower();
            if(searchNhanVienListener != null)
                searchNhanVienListener.onSearchNhanVien(filterTen,minDate,maxDate);
        }

        public interface ISearchNhanVienListener
        {
            void onSearchNhanVien(string ten,DateTime min,DateTime max);
        }



        private void datepicker_batdau_ValueChanged(object sender, EventArgs e)
        {

            minDate = datepicker_batdau.Value;
            if (minDate >= maxDate)
                datepicker_ketthuc.Value = minDate;
            searchNhanVienListener.onSearchNhanVien(filterTen, minDate, maxDate);
        }

        private void datepicker_ketthuc_ValueChanged(object sender, EventArgs e)
        {

            maxDate = datepicker_ketthuc.Value;
            if (maxDate < minDate)
                datepicker_batdau.Value = maxDate;
            searchNhanVienListener.onSearchNhanVien(filterTen, minDate, maxDate);
        }
    }
}
