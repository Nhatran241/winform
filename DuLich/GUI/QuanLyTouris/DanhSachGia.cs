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
        private IDanhSachGiaListener danhSachGiaCallBack;
        private IEnumerable<Gia> gias;
        public DanhSachGia(IEnumerable<Gia> gias, IDanhSachGiaListener danhSachGiaCallBack)
        {
            InitializeComponent();
            this.danhSachGiaCallBack = danhSachGiaCallBack;
            this.gias = gias;
            InitData(gias);
        }
        private void InitData(IEnumerable<Gia> gias)
        {
            dataGridViewTour.DataSource = gias;
        }


        private void GiaClick(object sender, DataGridViewCellEventArgs e)
        {
            int position = dataGridViewTour.CurrentCell.RowIndex;
            if (position > 0)
            {
                btn_sua_gia.Visible = true;
                btn_xoa_gia.Visible = true;
            }
            else
            {
                btn_sua_gia.Visible = false;
                btn_xoa_gia.Visible = false;
            }
        }

        private void GiaDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int position = dataGridViewTour.CurrentCell.RowIndex;
            danhSachGiaCallBack.onDanhSachGiaSuaClick(gias.ToList()[position]);
        }

        private void btn_them_gia_Click(object sender, EventArgs e)
        {
            danhSachGiaCallBack.onDanhSachGiaThemClick();
        }
     

        private void btn_sua_gia_Click(object sender, EventArgs e)
        {

            int position = 0;
            danhSachGiaCallBack.onDanhSachGiaSuaClick(gias.ToArray()[position]);
        }

        private void btn_xoa_gia_Click(object sender, EventArgs e)
        {
            int position = 0;
                danhSachGiaCallBack.onDanhSachGiaXoaClick(gias.ToArray()[position]);
        }
        public interface IDanhSachGiaListener
        {
            void onDanhSachGiaThemClick();
            void onDanhSachGiaSuaClick(Gia gia);
            void onDanhSachGiaXoaClick(Gia gia);
        }

    }
}
