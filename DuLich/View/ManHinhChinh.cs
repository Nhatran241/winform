using DuLich.Entity;
using DuLich.Model.Entity;
using DuLich.View;
using DuLich.View.QuanLyTouris;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuLich
{
    public partial class QuanLyTouris : Form,DanhSachTouris.OnItemClickListener, ChiTietTouris.OnChiTietClickListener
    {
        private UserControl userControl;
        private DuLichContext duLichContext = new DuLichContext();
        private IEnumerable<Touris> listTouris;
        private IEnumerable<Loai> listLoais;
        private IEnumerable<DiaDiem> listDiaDiems;
        private IEnumerable<Gia> danhSachGia;
        private List<ChiTietTour> listChiTietTour;
        private List<DiaDiem> diaDiemCuaTour;


        public QuanLyTouris()
        {
            InitializeComponent();
            OnManHinhChinhLoad();
        }

     
        private void OnManHinhChinhLoad()
        {
            LoadDataFromDataBase();
            if (userControl == null)
                userControl = new DanhSachTouris(listTouris, listLoais, this);
            panel_main_content.Controls.Add(userControl);
        }

        private void LoadDataFromDataBase()
        {
            listTouris = duLichContext.Touris.ToList();
            listLoais = duLichContext.Loai.ToList();
            listDiaDiems = duLichContext.DiaDiem.ToList();
        }

        private void OnQuanLyTourisClick(object sender, EventArgs e)
        {
            userControl = new DanhSachTouris(listTouris, listLoais, this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onItemClicked(int position)
        {
            Touris selectedTouris = listTouris.ToArray()[position];
            LoadDataOfTourisFromDataBase(selectedTouris);
            userControl = new ChiTietTouris(selectedTouris, listLoais, danhSachGia, listDiaDiems.ToList(), diaDiemCuaTour, this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);

        }

        public void onTabGiaClick()
        {
        }

        public void onTabDiaDiemClick()
        {
        }


        public void onXoaClick()
        {
        }


        public void onCapNhatClick(Touris tourisAfterUpdate, List<DiaDiem> diaDiemCuaTour)
        {
            if (diaDiemCuaTour.Count() != 0)
            {
                for (int i = 0; i < diaDiemCuaTour.Count(); i++)
                {
                    ChiTietTour chiTietTour = new ChiTietTour();
                    if (listChiTietTour.Count() > 0)
                    {
                        ChiTietTour tempChiTiet = listChiTietTour.First();
                        if (tempChiTiet != null)
                        {
                            chiTietTour.MaChiTietTour = tempChiTiet.MaChiTietTour;
                            listChiTietTour.RemoveAt(0);
                        }
                    }
                    chiTietTour.MaDiaDiem = diaDiemCuaTour.ToArray()[i].MaDienDiem;
                    chiTietTour.MaTour = tourisAfterUpdate.Id;
                    chiTietTour.ThuTu = i + 1;
                    duLichContext.ChiTietTour.AddOrUpdate(chiTietTour);
                }
                duLichContext.ChiTietTour.RemoveRange(listChiTietTour);
            }
            duLichContext.Touris.AddOrUpdate(tourisAfterUpdate);
            duLichContext.SaveChangesAsync().Wait();
            if (userControl is ChiTietTouris)
            {
                LoadDataOfTourisFromDataBase(tourisAfterUpdate);
                (userControl as ChiTietTouris).InitUI(tourisAfterUpdate);
            }
            //.ContinueWith(task =>
            //{
            //  if (userControl is ChiTietTouris)
            //{
            //  tourisAfterUpdate = duLichContext.Touris.ToList().Last();
            //(userControl as ChiTietTouris).InitUI(tourisAfterUpdate);
            //}
            // });


        }

        private void LoadDataOfTourisFromDataBase(Touris touris)
        {
            danhSachGia = duLichContext.Gia.Where(c => c.TourisId == touris.Id).ToList();
            IEnumerable<ChiTietTour> chiTietTours = duLichContext.ChiTietTour.Where(c => c.MaTour == touris.Id).OrderBy(d => d.ThuTu).ToList();
            diaDiemCuaTour = new List<DiaDiem>();
            foreach (ChiTietTour ch in chiTietTours)
            {
                diaDiemCuaTour.AddRange(listDiaDiems.Where(c => c.MaDienDiem == ch.MaDiaDiem).ToList());
            }
            listChiTietTour = new List<ChiTietTour>();
            listChiTietTour.AddRange(chiTietTours.ToList());
        }

        public void onThemGia(Gia gia, Touris touris)
        {
            duLichContext.Gia.AddOrUpdate(gia);
            duLichContext.SaveChangesAsync().Wait();
            if (userControl is ChiTietTouris)
            {
                LoadDataOfTourisFromDataBase(touris);
                userControl = new ChiTietTouris(touris, listLoais, danhSachGia, listDiaDiems.ToList(), diaDiemCuaTour, this);
                panel_main_content.Controls.Clear();
                panel_main_content.Controls.Add(userControl);
            }
        }

        public void onSuaGia(Gia gia, Touris touris)
        {
            duLichContext.Gia.AddOrUpdate(gia);
            duLichContext.SaveChangesAsync().Wait();
            if (userControl is ChiTietTouris)
            {
                LoadDataOfTourisFromDataBase(touris);
                userControl = new ChiTietTouris(touris, listLoais, danhSachGia, listDiaDiems.ToList(), diaDiemCuaTour, this);
                panel_main_content.Controls.Clear();
                panel_main_content.Controls.Add(userControl);
            }
        }

        public void onXoaGia(Gia gia, Touris touris)
        {
            duLichContext.Gia.Remove(gia);
            duLichContext.SaveChangesAsync().Wait();
            if (userControl is ChiTietTouris)
            {
                LoadDataOfTourisFromDataBase(touris);
                userControl = new ChiTietTouris(touris, listLoais, danhSachGia, listDiaDiems.ToList(), diaDiemCuaTour, this);
                panel_main_content.Controls.Clear();
                panel_main_content.Controls.Add(userControl);
            }
        }

        public void onHuyGia()
        {
        }

        public void onCapNhatDiaDiem(Touris touris, List<DiaDiem> newDiaDiemCuaTour)
        {
            if (newDiaDiemCuaTour.Count() != 0)
            {
                if (diaDiemCuaTour.Count > 0)
                {
                    for (int i = 0; i < diaDiemCuaTour.Count(); i++)
                    {
                        ChiTietTour chiTietTour = new ChiTietTour();
                        if (listChiTietTour.Count() > 0)
                        {
                            ChiTietTour tempChiTiet = listChiTietTour.First();
                            if (tempChiTiet != null)
                            {
                                chiTietTour.MaChiTietTour = tempChiTiet.MaChiTietTour;
                                listChiTietTour.RemoveAt(0);
                            }
                        }
                        chiTietTour.MaDiaDiem = diaDiemCuaTour.ToArray()[i].MaDienDiem;
                        chiTietTour.MaTour = touris.Id;
                        chiTietTour.ThuTu = i + 1;
                        duLichContext.ChiTietTour.AddOrUpdate(chiTietTour);
                    }
                }
                else
                {
                    for (int i = 0; i < newDiaDiemCuaTour.Count(); i++)
                    {
                        ChiTietTour chiTietTour = new ChiTietTour();
                        chiTietTour.MaDiaDiem = newDiaDiemCuaTour.ToArray()[i].MaDienDiem;
                        chiTietTour.MaTour = touris.Id;
                        chiTietTour.ThuTu = i + 1;
                        duLichContext.ChiTietTour.AddOrUpdate(chiTietTour);
                    }
                }

            }
            duLichContext.ChiTietTour.RemoveRange(listChiTietTour);
            duLichContext.SaveChangesAsync().Wait();
            if (userControl is ChiTietTouris)
            {
                LoadDataOfTourisFromDataBase(touris);
                userControl = new ChiTietTouris(touris, listLoais, danhSachGia, listDiaDiems.ToList(), diaDiemCuaTour, this);
                panel_main_content.Controls.Clear();
                panel_main_content.Controls.Add(userControl);
            }
        }

        public void onXoaClick(Touris currentTouris)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa Touris với mã là :" + currentTouris.Id, "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                duLichContext.Touris.Remove(currentTouris);
                duLichContext.SaveChangesAsync().Wait();
                LoadDataFromDataBase();
                userControl = new DanhSachTouris(listTouris, listLoais, this);
                panel_main_content.Controls.Clear();
                panel_main_content.Controls.Add(userControl);
            }
        }
        private void btn_quanlytour_Click(object sender, EventArgs e)
        {
            LoadDataFromDataBase();
            userControl = new DanhSachTouris(listTouris, listLoais, this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        private void btn_taotour_Click(object sender, EventArgs e)
        {
            userControl = new ChiTietTouris(null, listLoais, Enumerable.Empty<Gia>(), listDiaDiems.ToList(), Enumerable.Empty<DiaDiem>().ToList(), this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

    }
}
