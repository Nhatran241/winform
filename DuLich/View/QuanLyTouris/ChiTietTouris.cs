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
using DuLich.View.QuanLyTouris;
using DuLich.Common;
using DuLich.Model.Entity;

namespace DuLich.View
{
    public partial class ChiTietTouris : UserControl,DanhSachDiaDiem.IDanhSachDiaDiemCallBack
    {
        private OnChiTietClickListener onChiTietClickListener;
        private UserControl chiTietUserControl;
        private QuanLyTourisState quanLyTourisState = QuanLyTourisState.DANHSACHGIA;
        private bool isEditing = false;
        public ChiTietTouris(Touris touris,IEnumerable<Loai> loais, IEnumerable<Gia> gias, List<DiaDiem> tatCaDiaDiem, List<DiaDiem> diaDiemCuaTour, OnChiTietClickListener onChiTietClickListener)
        {
            this.onChiTietClickListener = onChiTietClickListener;
            Console.WriteLine(touris.Id + "/" + touris.Name);
            InitializeComponent();
            UpdateComponentState();
            InitData(touris,loais,gias,tatCaDiaDiem,diaDiemCuaTour);
        }
        public void UpdateComponentState()
        {
            if (isEditing)
            {
                EnableComponent();
                btn_chinhsua.Text = "Lưu";
               
            }
            else
            {
                DisableComponent();
                btn_chinhsua.Text = "Chỉnh Sửa";
               
            }
            if (chiTietUserControl is DanhSachDiaDiem)
            {
                (chiTietUserControl as DanhSachDiaDiem).UpdateComponentState(isEditing);
            }
        }

        private void ClearDataInComponent()
        {
            textbox_id.Visible = false;
            textbox_name.Text = "";
        }
        private void DisableComponent()
        {
            textbox_id.Enabled = false;
            textbox_name.Enabled = false;
            combobox_loai.Enabled = false;
        }
        private void EnableComponent()
        {
            textbox_id.Enabled = false;
            textbox_name.Enabled = true;
            combobox_loai.Enabled = true;
        }

        private Touris currentTouris;
        private Loai currentLoai;
        private IEnumerable<Loai> Loais;
        private IEnumerable<Gia> gias;
        private List<DiaDiem> tatCaDiaDiem;
        private List<DiaDiem> diaDiemCuaTour;
        private void InitData(Touris touris,IEnumerable<Loai> loais, IEnumerable<Gia> gias,List<DiaDiem> tatCaDiaDiem, List<DiaDiem> diaDiemCuaTour)
        {
            this.currentTouris = touris;
            this.Loais = loais;
            this.gias = gias;
            this.tatCaDiaDiem = tatCaDiaDiem;
            this.diaDiemCuaTour = diaDiemCuaTour;
            textbox_id.Text = touris.Id.ToString();
            textbox_name.Text = touris.Name;
            foreach(Loai loai in loais) {
                if (loai.Id == currentTouris.LoaiId)
                    currentLoai = loai;
                combobox_loai.Items.Add(loai);
            }
            combobox_loai.Text = currentLoai.TenLoai;
            LoadDanhSachGia();
        }

        private void LoadDanhSachGia()
        {

            chiTietUserControl = new DanhSachGia(gias);
            tab_gia.Controls.Clear();
            tab_gia.Controls.Add(chiTietUserControl);
            quanLyTourisState = QuanLyTourisState.DANHSACHGIA;
        }

        private void LoadDanhSachDiaDiem()
        {

            chiTietUserControl = new DanhSachDiaDiem(tatCaDiaDiem,diaDiemCuaTour,this);
            (chiTietUserControl as DanhSachDiaDiem).UpdateComponentState(isEditing);
            tab_diadiem.Controls.Clear();
            tab_diadiem.Controls.Add(chiTietUserControl);
            quanLyTourisState = QuanLyTourisState.DANHSACHDIADIEM;
        }

        private void QuanLyTour_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentTouris.LoaiId = Loais.ToArray()[combobox_loai.SelectedIndex].Id;
        }
        private void TabControl1_Selected(Object sender, TabControlEventArgs e)
        {
            if (e.TabPage.Name=="tab_gia") {
                LoadDanhSachGia();
            }
            else
            {
                LoadDanhSachDiaDiem();
            }
        }
        public interface OnChiTietClickListener
        {
            void onTabGiaClick();
            void onTabDiaDiemClick();
            void onCapNhatClick(Touris tourisAfterUpdate,List<DiaDiem> diaDiemCuaTour);
            void onXoaClick();
        }

        
     

        private void btn_chinhsua_Click(object sender, EventArgs e)
        {
            if(isEditing)
                onChiTietClickListener.onCapNhatClick(currentTouris, diaDiemCuaTour);
            isEditing = !isEditing;
            UpdateComponentState();
        }

        public void updateDiaDiemCuaTour(List<DiaDiem> diaDiemCuaTourNew)
        {
            this.diaDiemCuaTour = diaDiemCuaTourNew;
        }
    }
}
