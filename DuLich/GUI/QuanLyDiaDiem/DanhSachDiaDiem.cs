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

namespace DuLich.View.QuanLyDiaDiem
{
    public partial class DanhSachDiaDiem : UserControl
    {
        private IDanhSachDiaDiemListener danhSachDiaDiemListener;
        private List<DiaDiem> danhSachDiaDiem;
        public DanhSachDiaDiem(List<DiaDiem> danhSachDiaDiem,IDanhSachDiaDiemListener danhSachDiaDiemListener)
        {
            InitializeComponent();
            this.danhSachDiaDiem = danhSachDiaDiem;
            this.danhSachDiaDiemListener = danhSachDiaDiemListener;
            initData();
        }

        private void initData()
        {
            dataGridViewDiaDiem.DataSource = danhSachDiaDiem;
        }


        public interface IDanhSachDiaDiemListener
        {
            void onDanhSachDiaDiem_ThemClick();
            void onDanhSachDiaDiem_XoaClick(DiaDiem diaDiem);
            void onDanhSachDiaDiem_SuaClick(DiaDiem diaDiem);
        }

        private void btn_them_diadiem_Click(object sender, EventArgs e)
        {
            danhSachDiaDiemListener.onDanhSachDiaDiem_ThemClick();
        }
        private void btn_xoa_diadiem_Click(object sender, EventArgs e)
        {
            if (dataGridViewDiaDiem.CurrentRow != null)
            {
                int position = dataGridViewDiaDiem.CurrentRow.Index;
                danhSachDiaDiemListener.onDanhSachDiaDiem_XoaClick(danhSachDiaDiem.ToArray()[position]);
            }
        }

        private void btn_sua_diadiem_Click(object sender, EventArgs e)
        {
            if (dataGridViewDiaDiem.CurrentRow != null)
            {
                int position = dataGridViewDiaDiem.CurrentRow.Index;
                danhSachDiaDiemListener.onDanhSachDiaDiem_SuaClick(danhSachDiaDiem.ToArray()[position]);
            }
        }

        private void dataGridViewDiaDiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
