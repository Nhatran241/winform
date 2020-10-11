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
    public partial class QuanLyDiaDiem : UserControl
    {
        private IQuanLyDiaDiem quanLyDiaDiem;
        private IEnumerable<DiaDiem> DiaDiems;
        public QuanLyDiaDiem(IEnumerable<DiaDiem> diaDiems,IQuanLyDiaDiem quanLyDiaDiem)
        {
            InitializeComponent();
            initData(diaDiems);
            this.DiaDiems = diaDiems;
            this.quanLyDiaDiem = quanLyDiaDiem;
        }

        private void initData(IEnumerable<DiaDiem> diaDiems)
        {
            foreach (DiaDiem diaDiem in diaDiems)
            {
                list_diadiem.Items.Add(new ListViewItem(new string[] { diaDiem.MaDienDiem.ToString(), diaDiem.TenDiaDiem}));
            }
        }

        private void ListDiaDiem_OnDiaDiemSelect(object sender, EventArgs e)
        {
            int position = list_diadiem.SelectedIndices.Count;
            if (position > 0)
            {
                btn_sua_diadiem.Visible = true;
                btn_xoa_diadiem.Visible = true;
            }
            else
            {
                btn_sua_diadiem.Visible = false;
                btn_xoa_diadiem.Visible = false;
            }
        }


        public interface IQuanLyDiaDiem
        {
            void onThemDiaDiem();
            void onXoaDiaDiem(DiaDiem diaDiem);
            void onSuaDiaDiem(DiaDiem diaDiem);
        }

        private void btn_them_diadiem_Click(object sender, EventArgs e)
        {
            quanLyDiaDiem.onThemDiaDiem();
        }
        private void btn_xoa_diadiem_Click(object sender, EventArgs e)
        {
            if (list_diadiem.SelectedItems.Count > 0)
            {
                int position = list_diadiem.SelectedItems[0].Index;
                quanLyDiaDiem.onXoaDiaDiem(DiaDiems.ToArray()[position]);
            }
        }

        private void btn_sua_diadiem_Click(object sender, EventArgs e)
        {
            if (list_diadiem.SelectedItems.Count > 0)
            {
                int position = list_diadiem.SelectedItems[0].Index;
                quanLyDiaDiem.onSuaDiaDiem(DiaDiems.ToArray()[position]);
            }
        }
    }
}
