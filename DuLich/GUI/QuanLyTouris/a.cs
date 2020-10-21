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
    public partial class DanhSachTouris : UserControl
    {
        private OnItemClickListener onItemClickListener;
        public DanhSachTouris()
        {
            InitializeComponent();
        }
        public DanhSachTouris(IEnumerable<Touris> tourisList, IEnumerable<Loai> loaisList,OnItemClickListener onItemClickListener)
        {
            InitializeComponent();
            this.onItemClickListener = onItemClickListener;
           // InitData(tourisList, loaisList);
        }

        private void InitData(IEnumerable<Touris> tourisList,IEnumerable<Loai> loaisList)
        {
            dataGridView1.DataSource = tourisList;
            //(dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Field = '{0}'", textBoxFilter.Text);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

           // int position = list_touris.SelectedItems[0].Index;
            //onItemClickListener.onItemClicked(position);
        }
        public interface OnItemClickListener
        {
            void onItemClicked(int position);
        }

    }
}
