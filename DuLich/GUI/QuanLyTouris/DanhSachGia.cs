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
            dataGridViewGia.DataSource = gias;
        }


        private void GiaClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void GiaDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int position = dataGridViewGia.CurrentCell.RowIndex;
            danhSachGiaCallBack.onDanhSachGiaSuaClick(gias.ToList()[position]);
        }

        private void btn_them_gia_Click(object sender, EventArgs e)
        {
            danhSachGiaCallBack.onDanhSachGiaThemClick();
        }
     

        private void btn_sua_gia_Click(object sender, EventArgs e)
        {
            if(dataGridViewGia.CurrentCell != null)
            {
                int position = dataGridViewGia.CurrentCell.RowIndex;
                danhSachGiaCallBack.onDanhSachGiaSuaClick(gias.ToArray()[position]);
            }
        }

        private void btn_xoa_gia_Click(object sender, EventArgs e)
        {
            if (dataGridViewGia.CurrentCell != null)
            {
                int position = dataGridViewGia.CurrentCell.RowIndex;
                danhSachGiaCallBack.onDanhSachGiaXoaClick(gias.ToArray()[position]);
            }
        }
        public interface IDanhSachGiaListener
        {
            void onDanhSachGiaThemClick();
            void onDanhSachGiaSuaClick(Gia gia);
            void onDanhSachGiaXoaClick(Gia gia);
        }

    }
}
