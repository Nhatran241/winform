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

namespace DuLich.GUI.QuanLyDoan
{
    public partial class KhachDoan : UserControl
    {
        private List<Khach> tatCaDiaDiem;
        private List<Khach> diaDiemCuaTour;
        private List<Khach> tempDiaDiemCuaTour;
        private Khach khach;
        private IDanhSachDoanListener CallBack;
        public KhachDoan(List<Khach> tatCaDiaDiem, List<Khach> diaDiemCuaTour, IDanhSachDoanListener listener,Khach  khach)
        {
            this.tatCaDiaDiem = tatCaDiaDiem;
            this.diaDiemCuaTour = diaDiemCuaTour;
            this.CallBack = listener;
            this.khach = khach;
            tempDiaDiemCuaTour = new List<Khach>();
            tempDiaDiemCuaTour.AddRange(diaDiemCuaTour);
            InitializeComponent();
            UpdateComponentState();
            initData(tatCaDiaDiem, diaDiemCuaTour);
        }
        public void UpdateComponentState()
        {
            btn_luu.Visible = false;
        }

        public interface IDanhSachDoanListener
        {
            void onDanhSachKhachLuuClick(List<Khach> diaDiemCuaTour,Doan doan);
        }
        private void initData(List<Khach> tatCaDiaDiem, List<Khach> diaDiemCuaTour)
        {
            foreach (Khach diaDiem in tatCaDiaDiem)
            {
                if (!diaDiemCuaTour.Contains(diaDiem))
                {
                    listbox_chondiadiem.Items.Add(diaDiem);
                }
            }
            foreach (Khach diaDiem in diaDiemCuaTour)
            {
                listbox_ketqua.Items.Add(diaDiem);
            }

        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (listbox_chondiadiem.SelectedItem == null)
                return;
            diaDiemCuaTour.Add((Khach)listbox_chondiadiem.SelectedItem);
            listbox_ketqua.Items.Add((Khach)listbox_chondiadiem.SelectedItem);
            listbox_chondiadiem.Items.Remove(listbox_chondiadiem.SelectedItem);
            tatCaDiaDiem.Remove((Khach)listbox_chondiadiem.SelectedItem);
          
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (listbox_ketqua.SelectedItem == null)
                return;

            listbox_chondiadiem.Items.Add(listbox_ketqua.SelectedItem);
            tatCaDiaDiem.Add((Khach)listbox_ketqua.SelectedItem);
            diaDiemCuaTour.Remove((Khach)listbox_ketqua.SelectedItem);
            listbox_ketqua.Items.Remove((Khach)listbox_ketqua.SelectedItem);
          
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            CallBack.onDanhSachKhachLuuClick(diaDiemCuaTour,);
        }

    }
}
