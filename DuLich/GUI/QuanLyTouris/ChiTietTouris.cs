﻿using System;
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
    public partial class ChiTietTouris : UserControl,DanhSachGia.IDanhSachGiaListener,ChiTietGia.IChiTietGiaListener
    {
        private OnChiTietTourListener onChiTietClickListener;
        private DanhSachChonDiaDiem.IDanhSachChonDiaDiemListener danhSachChonDiaDiemListener;
        private UserControl chiTietUserControl;
        private bool isEditing = false;

        private Tour currentTouris;
        private Loai currentLoai;
        private List<Loai> danhSachLoai;
        private List<Gia> danhSachGia;
        private List<DiaDiem> danhSachTatCaDiaDiem;
        private List<DiaDiem> danhSachDiaDiemCuaTor;
        public ChiTietTouris(Tour touris,List<Loai> loais, List<Gia> gias, List<DiaDiem> tatCaDiaDiem, List<DiaDiem> diaDiemCuaTour, OnChiTietTourListener onChiTietClickListener,DanhSachChonDiaDiem.IDanhSachChonDiaDiemListener danhSachChonDiaDiemListener)
        {
            InitializeComponent();
            this.onChiTietClickListener = onChiTietClickListener;
            this.danhSachChonDiaDiemListener = danhSachChonDiaDiemListener;
            currentTouris = touris;
            this.danhSachLoai = loais;
            this.danhSachGia = gias;
            this.danhSachTatCaDiaDiem = tatCaDiaDiem;
            this.danhSachDiaDiemCuaTor = diaDiemCuaTour;
            foreach(DiaDiem diaDiem in diaDiemCuaTour)
            {
                Console.WriteLine(diaDiem.TenDiaDiem);
            }
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
            currentTouris = new Tour();
            currentLoai = danhSachLoai.First();
            textbox_id.Visible = false;
            tour_id.Visible = false;
            btn_xoa.Visible = false;
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
        }
        private void EnableComponent()
        {
            btn_xoa.Visible = false;
            textbox_id.Enabled = false;
            textbox_name.Enabled = true;
            combobox_loai.Enabled = true;
        }

        
         
        private void InitData()
        {
            InitUI(currentTouris);
            if (tab_chitiet.SelectedTab.Name.Equals("tab_gia"))
            {
                if (danhSachGia != null)
                    LoadDanhSachGia();
            }
            else if (tab_chitiet.SelectedTab.Name.Equals("tab_diadiem"))
            {
                if (danhSachDiaDiemCuaTor != null)
                    LoadDanhSachDiaDiem();
            }
            else
            {
                LoadThongKeTheoTour();
            }
        }
        public void UpdateData(List<Gia> danhSachGia, List<DiaDiem> danhSachDiaDiemCuaTour)
        {
            this.danhSachGia = danhSachGia;
            this.danhSachDiaDiemCuaTor = danhSachDiaDiemCuaTour;
            InitData();
        }
        public void InitUI(Tour touris)
        {
            textbox_id.Text = touris.Id.ToString();
            textbox_name.Text = touris.Name;
            foreach (Loai loai in danhSachLoai)
            {
                if (currentTouris.Loai!=null &&loai.Id == currentTouris.Loai.Id)
                    currentLoai = loai;
                combobox_loai.Items.Add(loai);
            }
            combobox_loai.Text = currentLoai.TenLoai;
        }

        public void LoadDanhSachGia()
        {
            tab_gia.Controls.Clear();
            tab_gia.Controls.Add(new DanhSachGia(danhSachGia, this));
        }

        public void LoadDanhSachDiaDiem()
        {

            //chiTietUserControl = new DanhSachDiaDiem(tatCaDiaDiem,diaDiemCuaTour,this);
            tab_diadiem.Controls.Clear();
            tab_diadiem.Controls.Add(new DanhSachChonDiaDiem(currentTouris, danhSachTatCaDiaDiem, danhSachDiaDiemCuaTor, danhSachChonDiaDiemListener));
        }
        private void LoadThongKeTheoTour()
        {
            tab_thongke.Controls.Clear();
            tab_thongke.Controls.Add(new ThongKeTheoTour(currentTouris));
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentTouris.Loai = danhSachLoai.ToArray()[combobox_loai.SelectedIndex];
        }
        private void TabControl1_Selected(Object sender, TabControlEventArgs e)
        {
            if (e.TabPage.Name=="tab_gia") {
                LoadDanhSachGia();
            }
            else if(e.TabPage.Name=="tab_diadiem")
            {
                LoadDanhSachDiaDiem();
            }else
            {
                LoadThongKeTheoTour();
            }
        }

       

        public interface OnChiTietTourListener
        {
            void onChiTietTourCapNhatClick(Tour tourisAfterUpdate);
            void onChiTietTourXoaTourClick(Tour currentTouris);
            void onThemGia(Gia gia,Tour touris);
            void onSuaGia(Gia gia,Tour touris);
            void onXoaGia(Gia gia,Tour touris);
            void onHuyGia();
        }

        
     

        private void btn_chinhsua_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {

                if (Validation(currentTouris))
                {
                    onChiTietClickListener.onChiTietTourCapNhatClick(currentTouris);
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


        private void textbox_name_TextChanged(object sender, EventArgs e)
        {
            currentTouris.Name = textbox_name.Text.Trim();
        }

        private bool Validation(Tour tourisAfterUpdate)
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

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            onChiTietClickListener.onChiTietTourXoaTourClick(currentTouris);
        }

    }
}
