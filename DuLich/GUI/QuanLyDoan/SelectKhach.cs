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
        private List<Khach> danhSachTatCaKhach = new List<Khach>();
        private List<Khach> danhSachKhachTrongDoan = new List<Khach>();
        private List<Khach> danhSachKhachTrongDoanTam = new List<Khach>();
        private ISelectKhachListener selectKhachListener;
        private Doan doanHienTai;
        public SelectKhach(Doan doanHienTai,List<Khach> danhSachTatCaKhach , List<Khach> danhSachKhachTrongDoan, ISelectKhachListener selectKhachListener)
        {
            InitializeComponent();
            UpdateComponentState();
            this.danhSachTatCaKhach.AddRange(danhSachTatCaKhach);
            this.danhSachKhachTrongDoan.AddRange(danhSachKhachTrongDoan);
            this.danhSachKhachTrongDoanTam.AddRange(danhSachKhachTrongDoan);
            this.selectKhachListener = selectKhachListener;
            this.doanHienTai = doanHienTai;
            initData();
        }

        public void UpdateComponentState()
        {
            btn_luu.Visible = false;
        }
         

        private void initData()
        {
            listbox_khachtrongdoan.DataSource = danhSachKhachTrongDoan;
            listbox_tatcakhach.DataSource = danhSachTatCaKhach;
            if (danhSachTatCaKhach != null && danhSachKhachTrongDoan!=null)
            {
                danhSachTatCaKhach.RemoveAll(c=>danhSachKhachTrongDoan.Contains(c));
            }
            listbox_khachtrongdoan.DataSource = null;
            listbox_khachtrongdoan.DataSource = danhSachKhachTrongDoan;

            listbox_tatcakhach.DataSource = null;
            listbox_tatcakhach.DataSource = danhSachTatCaKhach;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (listbox_tatcakhach.SelectedItem == null)
                return;
            danhSachKhachTrongDoan.Add((Khach)listbox_tatcakhach.SelectedItem);
            danhSachTatCaKhach.Remove((Khach)listbox_tatcakhach.SelectedItem);

            listbox_khachtrongdoan.DataSource = null;
            listbox_khachtrongdoan.DataSource = danhSachKhachTrongDoan;
            listbox_khachtrongdoan.SelectedIndex = listbox_khachtrongdoan.Items.Count - 1;

            listbox_tatcakhach.DataSource = null;
            listbox_tatcakhach.DataSource = danhSachTatCaKhach;
            listbox_tatcakhach.SelectedIndex = listbox_tatcakhach.Items.Count - 1;
            checkSuThayDoi();
        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            if (listbox_khachtrongdoan.SelectedItem == null)
                return;
            int position = listbox_khachtrongdoan.SelectedIndex;
            if (position != 0) {
                Khach temp = (Khach)listbox_khachtrongdoan.SelectedItem;
                danhSachKhachTrongDoan.RemoveAt(position);
                danhSachKhachTrongDoan.Insert(position - 1, temp);
                listbox_khachtrongdoan.SelectedIndex = position - 1;

                listbox_khachtrongdoan.DataSource = null;
                listbox_khachtrongdoan.DataSource = danhSachKhachTrongDoan;

                listbox_tatcakhach.DataSource = null;
                listbox_tatcakhach.DataSource = danhSachTatCaKhach;
                checkSuThayDoi();
            }
        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            if (listbox_khachtrongdoan.SelectedItem == null)
                return;
            int position = listbox_khachtrongdoan.SelectedIndex;
            if (position != danhSachKhachTrongDoan.Count-1)
            {
                Khach temp = (Khach)listbox_khachtrongdoan.SelectedItem;
                danhSachKhachTrongDoan.RemoveAt(position);
                danhSachKhachTrongDoan.Insert(position + 1, temp);
                listbox_khachtrongdoan.SelectedIndex = position + 1;

                listbox_khachtrongdoan.DataSource = null;
                listbox_khachtrongdoan.DataSource = danhSachKhachTrongDoan;

                listbox_tatcakhach.DataSource = null;
                listbox_tatcakhach.DataSource = danhSachTatCaKhach;
                checkSuThayDoi();
            }
        }

        private void checkSuThayDoi()
        {
            if (danhSachKhachTrongDoan.Count == danhSachKhachTrongDoanTam.Count)
            {
                foreach(Khach khach in danhSachKhachTrongDoan)
                {
                    if (!danhSachKhachTrongDoanTam.Contains(khach))
                    {
                        ShowLuuButton();
                        return;
                    }
                    HideLuuButton();
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

            danhSachTatCaKhach.Add((Khach)listbox_khachtrongdoan.SelectedItem);
            danhSachKhachTrongDoan.Remove((Khach)listbox_khachtrongdoan.SelectedItem);

            listbox_khachtrongdoan.DataSource = null;
            listbox_khachtrongdoan.DataSource = danhSachKhachTrongDoan;
            listbox_khachtrongdoan.SelectedIndex = listbox_khachtrongdoan.Items.Count - 1;

            listbox_tatcakhach.DataSource = null;
            listbox_tatcakhach.DataSource = danhSachTatCaKhach;
            listbox_tatcakhach.SelectedIndex = listbox_tatcakhach.Items.Count - 1;
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
