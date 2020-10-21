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

namespace DuLich.GUI.QuanLyChiPhi
{
    public partial class DanhSachChiPhi : UserControl
    {
        private IDanhSachChiPhiListener danhSachChiPhiListener;
        private List<ChiPhi> danhSachChiPhi;
        public DanhSachChiPhi(List<ChiPhi> danhSachChiPhi, IDanhSachChiPhiListener danhSachChiPhiListener)
        {
            InitializeComponent();
            this.danhSachChiPhi = danhSachChiPhi;
            this.danhSachChiPhiListener = danhSachChiPhiListener;
            InitData(danhSachChiPhi);
        }
        private void InitData(List<ChiPhi> danhSachChiPhi)
        {

            foreach (ChiPhi chiPhi in danhSachChiPhi)
            {
                listview_doan.Items.Add(new ListViewItem(new string[] { chiPhi.LoaiChiPhi.name,chiPhi.giaTri.ToString(),chiPhi.ghiChu }));
            }
        }
        private void listview_doan_SelectedIndexChanged(object sender, EventArgs e)
        {
            int position = listview_doan.SelectedIndices.Count;
            if (position > 0)
            {
                btn_sua_doan.Visible = true;
                btn_xoa_doan.Visible = true;
            }
            else
            {
                btn_sua_doan.Visible = false;
                btn_xoa_doan.Visible = false;
            }
        }
        public interface IDanhSachChiPhiListener
        {
            void onDanhSachChiPhi_ThemClick();
            void onDanhSachChiPhi_SuaClick(ChiPhi chiPhi);
            void onDanhSachChiPhi_XoaClick(ChiPhi chiPhi);
        }

        private void btn_them_doan_Click(object sender, EventArgs e)
        {
            danhSachChiPhiListener.onDanhSachChiPhi_ThemClick();
        }

        private void btn_xoa_doan_Click(object sender, EventArgs e)
        {
            if (listview_doan.SelectedItems.Count > 0)
            {
                int position = listview_doan.SelectedItems[0].Index;
                danhSachChiPhiListener.onDanhSachChiPhi_XoaClick(danhSachChiPhi.ToArray()[position]);
            }
            
        }

        private void btn_sua_doan_Click(object sender, EventArgs e)
        {
            if (listview_doan.SelectedItems.Count > 0)
            {
                int position = listview_doan.SelectedItems[0].Index;
                danhSachChiPhiListener.onDanhSachChiPhi_XoaClick(danhSachChiPhi.ToArray()[position]);
            }

        }
    }
}
