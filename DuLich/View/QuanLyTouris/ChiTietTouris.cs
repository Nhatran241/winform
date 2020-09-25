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
    public partial class ChiTietTouris : UserControl,DanhSachDiaDiem.IDanhSachDiaDiemCallBack,DanhSachGia.IDanhSachGiaCallBack,ChiTietGia.IChiTietGiaListener
    {
        private OnChiTietClickListener onChiTietClickListener;
        private UserControl chiTietUserControl;
        private QuanLyTourisState quanLyTourisState = QuanLyTourisState.DANHSACHGIA;
        private bool isEditing = false;
        public ChiTietTouris(Touris touris,IEnumerable<Loai> loais, IEnumerable<Gia> gias, List<DiaDiem> tatCaDiaDiem, List<DiaDiem> diaDiemCuaTour, OnChiTietClickListener onChiTietClickListener)
        {
            InitializeComponent();
            this.onChiTietClickListener = onChiTietClickListener;
            currentTouris = touris;
            this.Loais = loais;
            this.gias = gias;
            this.tatCaDiaDiem = tatCaDiaDiem;
            this.diaDiemCuaTour = diaDiemCuaTour;
            if (currentTouris == null)
            {
                CreateNewRecord();
            }
            UpdateComponentState();
            InitData();
        }
 
        public void UpdateComponentState()
        {
            if (currentTouris.Id == 0)
            {
                tab_chitiet.Visible = false;
            }
            else tab_chitiet.Visible = true;
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

        public void CreateNewRecord()
        {
            currentTouris = new Touris();
            currentLoai = Loais.First();
            textbox_id.Visible = false;
            textbox_name.Text = "";
            isEditing = true;
            UpdateComponentState();
        }
        private void DisableComponent()
        {
            textbox_id.Visible = true;
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
        private void InitData()
        {
          
            InitUI(currentTouris);
            LoadDanhSachGia();
        }

        public void InitUI(Touris touris)
        {
            textbox_id.Text = touris.Id.ToString();
            textbox_name.Text = touris.Name;
            foreach (Loai loai in Loais)
            {
                if (loai.Id == currentTouris.LoaiId)
                    currentLoai = loai;
                combobox_loai.Items.Add(loai);
            }
            combobox_loai.Text = currentLoai.TenLoai;
        }

        private void LoadDanhSachGia()
        {

            chiTietUserControl = new DanhSachGia(gias,this);
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
            void onThemGia(Gia gia);
            void onSuaGia(Gia gia);
            void onXoaGia(Gia gia);
            void onHuyGia();
        }

        
     

        private void btn_chinhsua_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {

                if (Validation(currentTouris))
                {
                    onChiTietClickListener.onCapNhatClick(currentTouris, diaDiemCuaTour);
                }
                else
                {
                    MessageBox.Show("Tên hoặc loại tour không được bỏ trống");
                    return;
                }
            }
            isEditing = !isEditing;
            UpdateComponentState();
        }

        public void updateDiaDiemCuaTour(List<DiaDiem> diaDiemCuaTourNew)
        {
            this.diaDiemCuaTour = diaDiemCuaTourNew;
        }

        private void textbox_name_TextChanged(object sender, EventArgs e)
        {
            currentTouris.Name = textbox_name.Text.Trim();
        }

        private bool Validation(Touris tourisAfterUpdate)
        {
            Console.WriteLine(tourisAfterUpdate.Name + "/" + tourisAfterUpdate.LoaiId);
            if (tourisAfterUpdate.Name == "" || tourisAfterUpdate.LoaiId == 0)
                return false;
            return true;
        }

        public void OnClickThemGia()
        {
            chiTietUserControl = new ChiTietGia(new Gia(),this);
            tab_gia.Controls.Clear();
            tab_gia.Controls.Add(chiTietUserControl);
        }

        public void OnClickSuaGia(Gia gia)
        {
            chiTietUserControl = new ChiTietGia(gia,this);
            tab_gia.Controls.Clear();
            tab_gia.Controls.Add(chiTietUserControl);
        }

        public void OnClickXoaGia(Gia gia)
        {
            onChiTietClickListener.onXoaGia(gia);
        }

        public void onLuuClick(Gia gia)
        {
            if (gia.MaGia == 0)
            {
                onChiTietClickListener.onThemGia(gia);
            }
            else onChiTietClickListener.onSuaGia(gia);
        }

        public void onHuyClick()
        {
            LoadDanhSachGia();
        }
    }
}
