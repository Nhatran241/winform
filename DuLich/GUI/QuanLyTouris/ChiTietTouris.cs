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
using DuLich.Model.Entity;

namespace DuLich.View
{
    public partial class ChiTietTouris : UserControl,DanhSachDiaDiem.IDanhSachDiaDiemListener,DanhSachGia.IDanhSachGiaListener,ChiTietGia.IChiTietGiaListener
    {
        private OnChiTietTourListener onChiTietClickListener;
        private UserControl chiTietUserControl;
        private QuanLyTourisState quanLyTourisState = QuanLyTourisState.DANHSACHGIA;
        private bool isEditing = false;
        public ChiTietTouris(Touris touris,IEnumerable<Loai> loais, IEnumerable<Gia> gias, List<DiaDiem> tatCaDiaDiem, List<DiaDiem> diaDiemCuaTour, OnChiTietTourListener onChiTietClickListener)
        {
            InitializeComponent();
            this.onChiTietClickListener = onChiTietClickListener;
            currentTouris = touris;
            this.Loais = loais;
            this.gias = gias;
            this.tatCaDiaDiem = tatCaDiaDiem;
            this.diaDiemCuaTour = diaDiemCuaTour;
            tempDiaDiemCuaTour = new List<DiaDiem>();
            tempDiaDiemCuaTour.AddRange(diaDiemCuaTour);
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
       
        }

        public void CreateNewRecord()
        {
            currentTouris = new Touris();
            currentLoai = Loais.First();
            textbox_id.Visible = false;
            tour_id.Visible = false;
            btn_xoa.Visible = false;
            tv_title.Visible = true;
            textbox_name.Text = "";
            isEditing = true;
            UpdateComponentState();
        }
        private void DisableComponent()
        {
            textbox_id.Visible = true;
            tour_id.Visible = true;
            btn_xoa.Visible = true;
            textbox_id.Enabled = false;
            textbox_name.Enabled = false;
            combobox_loai.Enabled = false;
            tv_title.Visible = false;
        }
        private void EnableComponent()
        {
            btn_xoa.Visible = false;
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
        private List<DiaDiem> tempDiaDiemCuaTour;
        
         
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
                if (currentTouris.Loai!=null &&loai.Id == currentTouris.Loai.Id)
                    currentLoai = loai;
                combobox_loai.Items.Add(loai);
            }
            combobox_loai.Text = currentLoai.TenLoai;
        }

        public void LoadDanhSachGia()
        {

            chiTietUserControl = new DanhSachGia(gias,this);
            tab_gia.Controls.Clear();
            tab_gia.Controls.Add(chiTietUserControl);
            quanLyTourisState = QuanLyTourisState.DANHSACHGIA;
        }

        public void LoadDanhSachDiaDiem()
        {

            chiTietUserControl = new DanhSachDiaDiem(tatCaDiaDiem,diaDiemCuaTour,this);
            tab_diadiem.Controls.Clear();
            tab_diadiem.Controls.Add(chiTietUserControl);
            quanLyTourisState = QuanLyTourisState.DANHSACHDIADIEM;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentTouris.Loai = Loais.ToArray()[combobox_loai.SelectedIndex];
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
        public interface OnChiTietTourListener
        {
            void onChiTietTourCapNhatClick(Touris tourisAfterUpdate,List<DiaDiem> diaDiemCuaTour);
            void onChiTietTourXoaTourClick(Touris currentTouris);
            void onThemGia(Gia gia,Touris touris);
            void onSuaGia(Gia gia,Touris touris);
            void onXoaGia(Gia gia,Touris touris);
            void onCapNhatDiaDiem(Touris touris,List<DiaDiem> newDiaDiemCuaTour);
            void onHuyGia();
        }

        
     

        private void btn_chinhsua_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {

                if (Validation(currentTouris))
                {
                    onChiTietClickListener.onChiTietTourCapNhatClick(currentTouris, diaDiemCuaTour);
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
            Console.WriteLine(tourisAfterUpdate.Name + "/" + tourisAfterUpdate.Loai.Id);
            if (tourisAfterUpdate.Name == "" || tourisAfterUpdate.Loai.Id == 0)
                return false;
            return true;
        }

        public void onDanhSachGiaThemClick()
        {
            Gia gia = new Gia();
            gia.touris = currentTouris;
            chiTietUserControl = new ChiTietGia(gia,this);
            tab_gia.Controls.Clear();
            tab_gia.Controls.Add(chiTietUserControl);
        }

        public void onDanhSachGiaSuaClick(Gia gia)
        {
            chiTietUserControl = new ChiTietGia(gia,this);
            tab_gia.Controls.Clear();
            tab_gia.Controls.Add(chiTietUserControl);
        }

        public void onDanhSachGiaXoaClick(Gia gia)
        {
            onChiTietClickListener.onXoaGia(gia, currentTouris);
        }

        public void onLuuClick(Gia gia)
        {
            Console.WriteLine("" + gia.MaGia + "/" + gia.GiaTri + ":" + gia.ThoiGianBatDau + "-" + gia.ThoiGianKetThuc);
            if (gia.MaGia == 0)
            {
                onChiTietClickListener.onThemGia(gia,currentTouris);
            }
            else onChiTietClickListener.onSuaGia(gia, currentTouris);
        }

        public void onHuyClick()
        {
            LoadDanhSachGia();
        }

        public void onClickLuu(List<DiaDiem> diaDiemCuaTourNew)
        {
           
        }

        public void checkSuThayDoiDiaDiem(List<DiaDiem> diaDiemCuaTourNew)
        {
            this.diaDiemCuaTour = diaDiemCuaTourNew;
            Console.WriteLine(diaDiemCuaTourNew.Count);
            if (diaDiemCuaTour.Count() == tempDiaDiemCuaTour.Count())
            {
                for (int i = 0; i < diaDiemCuaTour.ToArray().Length; i++)
                {
                    if (diaDiemCuaTour.ToArray()[i] != tempDiaDiemCuaTour.ToArray()[i])
                    {
                        if(chiTietUserControl is DanhSachDiaDiem)
                        {
                            (chiTietUserControl as DanhSachDiaDiem).ShowLuuButton();
                            return;
                        }
                    }
                }
                (chiTietUserControl as DanhSachDiaDiem).HideLuuButton();
            }
            else (chiTietUserControl as DanhSachDiaDiem).ShowLuuButton();
        }

        public void onDanhSachDiaDiemLuuClick()
        {
            onChiTietClickListener.onCapNhatDiaDiem(currentTouris, diaDiemCuaTour);
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            onChiTietClickListener.onChiTietTourXoaTourClick(currentTouris);
        }
    }
}
