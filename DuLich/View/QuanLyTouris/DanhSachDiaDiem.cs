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
    public partial class DanhSachDiaDiem : UserControl
    {
        private List<DiaDiem> tatCaDiaDiem;
        private List<DiaDiem> diaDiemCuaTour;
        private List<DiaDiem> tempDiaDiemCuaTour;
        private IDanhSachDiaDiemCallBack CallBack;
        public DanhSachDiaDiem(List<DiaDiem> tatCaDiaDiem , List<DiaDiem> diaDiemCuaTour,IDanhSachDiaDiemCallBack callBack)
        {
            this.tatCaDiaDiem = tatCaDiaDiem;
            this.diaDiemCuaTour = diaDiemCuaTour;
            this.CallBack = callBack;
            tempDiaDiemCuaTour = new List<DiaDiem>();
            tempDiaDiemCuaTour.AddRange(diaDiemCuaTour);
            InitializeComponent();
            UpdateComponentState();
            initData(tatCaDiaDiem, diaDiemCuaTour);
        }

        public void UpdateComponentState()
        {
            btn_luu.Visible = false;
        }
         

        private void initData(List<DiaDiem> tatCaDiaDiem, List<DiaDiem> diaDiemCuaTour)
        {
            foreach (DiaDiem diaDiem in tatCaDiaDiem)
            {
                if (!diaDiemCuaTour.Contains(diaDiem)) {
                    listbox_chondiadiem.Items.Add(diaDiem);
                }
            }
            foreach (DiaDiem diaDiem in diaDiemCuaTour)
            {
                listbox_ketqua.Items.Add(diaDiem);
            }

        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (listbox_chondiadiem.SelectedItem == null)
                return;
            diaDiemCuaTour.Add((DiaDiem)listbox_chondiadiem.SelectedItem);
            listbox_ketqua.Items.Add((DiaDiem)listbox_chondiadiem.SelectedItem);
            listbox_chondiadiem.Items.Remove(listbox_chondiadiem.SelectedItem);
            tatCaDiaDiem.Remove((DiaDiem)listbox_chondiadiem.SelectedItem);
            CallBack.onCheckPreMatch(diaDiemCuaTour);
        }

 

        private void listbox_chondiadiem_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (listbox_ketqua.SelectedItem == null)
                return;

            listbox_chondiadiem.Items.Add(listbox_ketqua.SelectedItem);
            tatCaDiaDiem.Add((DiaDiem)listbox_ketqua.SelectedItem);
            diaDiemCuaTour.Remove((DiaDiem)listbox_ketqua.SelectedItem);
            listbox_ketqua.Items.Remove((DiaDiem)listbox_ketqua.SelectedItem);
            CallBack.onCheckPreMatch(diaDiemCuaTour);
        }

        public interface IDanhSachDiaDiemCallBack
        {
            void onCheckPreMatch(List<DiaDiem> diaDiemCuaTourNew);
            void onClickLuu();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            CallBack.onClickLuu();
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
