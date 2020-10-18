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

namespace DuLich.View.QuanLyDoan
{
    public partial class SelectKhach : UserControl
    {
        private List<Khach> danhSachTatCaKhach;
        private List<Khach> danhSachKhachTrongDoan;
        private List<Khach> danhSachKhachTrongDoanTam;
        private ISelectKhachListener selectKhachListener;
        private Doan doanHienTai;
        public SelectKhach(Doan doanHienTai,List<Khach> danhSachTatCaKhach , List<Khach> danhSachKhachTrongDoan, ISelectKhachListener selectKhachListener)
        {
            InitializeComponent();
            UpdateComponentState();
            this.danhSachTatCaKhach = danhSachTatCaKhach;
            this.danhSachKhachTrongDoan = danhSachKhachTrongDoan;
            this.selectKhachListener = selectKhachListener;
            this.doanHienTai = doanHienTai;
            danhSachKhachTrongDoanTam = new List<Khach>();
            if (danhSachKhachTrongDoan != null)
            {
                danhSachKhachTrongDoanTam.AddRange(danhSachKhachTrongDoan);
            }
            initData(danhSachTatCaKhach, danhSachKhachTrongDoan);
        }

        public void UpdateComponentState()
        {
            btn_luu.Visible = false;
        }
         

        private void initData(List<Khach> danhSachTatCaKhach, List<Khach> danhSachKhachTrongDoan)
        {
            if(danhSachTatCaKhach != null && danhSachKhachTrongDoan!=null)
            {
                foreach (Khach khach in danhSachTatCaKhach)
                {
                    if (!danhSachKhachTrongDoan.Contains(khach))
                    {
                        listbox_tatcakhach.Items.Add(khach);
                    }
                }
            }
            if (danhSachTatCaKhach != null)
            {
                foreach (Khach khack in danhSachKhachTrongDoan)
                {
                    listbox_khachtrongdoan.Items.Add(khack);
                }
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (listbox_tatcakhach.SelectedItem == null)
                return;
            danhSachKhachTrongDoan.Add((Khach)listbox_tatcakhach.SelectedItem);
            listbox_khachtrongdoan.Items.Add((Khach)listbox_tatcakhach.SelectedItem);
            listbox_tatcakhach.Items.Remove(listbox_tatcakhach.SelectedItem);
            danhSachTatCaKhach.Remove((Khach)listbox_tatcakhach.SelectedItem);
            checkSuThayDoi();
        }

        private void checkSuThayDoi()
        {
            if (danhSachKhachTrongDoan.Count == danhSachKhachTrongDoanTam.Count)
            {
                foreach (Khach khach in danhSachKhachTrongDoan) {
                    if (!danhSachKhachTrongDoanTam.Contains(khach)) {
                        ShowLuuButton();
                        return;
                    }
                }
            }
            else {
                ShowLuuButton();
            }
        }

        private void listbox_chondiadiem_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (listbox_khachtrongdoan.SelectedItem == null)
                return;

            listbox_tatcakhach.Items.Add(listbox_khachtrongdoan.SelectedItem);
            danhSachTatCaKhach.Add((Khach)listbox_khachtrongdoan.SelectedItem);
            danhSachKhachTrongDoan.Remove((Khach)listbox_khachtrongdoan.SelectedItem);
            listbox_khachtrongdoan.Items.Remove((Khach)listbox_khachtrongdoan.SelectedItem);
            checkSuThayDoi();
        }

        public interface ISelectKhachListener
        {
            void onSelectKhach_LuuClick(Doan doanHienTai,List<Khach> danhSachKhachTrongDoanUpdate);
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            selectKhachListener.onSelectKhach_LuuClick(doanHienTai,danhSachKhachTrongDoan);
        }

        internal void ShowLuuButton()
        {
            btn_luu.Visible = true;
        }

        internal void HideLuuButton()
        {
            btn_luu.Visible = false;
        }
    }
}
