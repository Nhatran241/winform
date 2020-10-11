using DuLich.Entity;
using DuLich.Model.Entity;
using DuLich.View;
using DuLich.View.QuanLyDiaDiem;
using DuLich.View.QuanLyTouris;
using System;
using System.Collections;
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
    public partial class ManHinhChinh : Form,DanhSachTouris.OnItemClickListener, ChiTietTouris.OnChiTietTourListener,QuanLyDiaDiem.IQuanLyDiaDiem,ChiTietDiaDiem.IChiTietDiaDiemListener
    {
        private UserControl userControl;
        private DuLichContext duLichContext = new DuLichContext();
        private List<Touris> listTouris = new List<Touris>();
        private List<Loai> listLoais = new List<Loai>();
        private List<DiaDiem> listDiaDiems = new List<DiaDiem>();
        private List<Gia> danhSachGia = new List<Gia>();
        private List<ChiTietTour> listChiTietTour = new List<ChiTietTour>();
        private List<DiaDiem> diaDiemCuaTour = new List<DiaDiem>();


        public ManHinhChinh()
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
            foreach(Touris touris in listTouris)
            {
                Console.WriteLine(touris.Gias);
            }
            listLoais = duLichContext.Loai.ToList();
            listDiaDiems = duLichContext.DiaDiem.ToList();
        }

        public void onItemClicked(int position)
        {
            Touris selectedTouris = listTouris.ToArray()[position];
            LoadDataOfTourisFromDataBase(selectedTouris);
            userControl = new ChiTietTouris(selectedTouris, listLoais, danhSachGia, listDiaDiems.ToList(), diaDiemCuaTour, this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);

        }

        public void onChiTietTourCapNhatClick(Touris tourisAfterUpdate, List<DiaDiem> diaDiemCuaTour)
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
                    chiTietTour.diaDiem = diaDiemCuaTour.ToArray()[i];
                    chiTietTour.touris = tourisAfterUpdate;
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
            if (touris.Gias != null)
            {
                danhSachGia = touris.Gias.ToList();
                foreach (Gia gia in danhSachGia)
                {
                    Console.WriteLine(gia.MaGia);
                }
            }
            else danhSachGia = new List<Gia>();
            //IEnumerable<ChiTietTour> chiTietTours = duLichContext.ChiTietTour.Where(c => c.MaTour == touris.Id).OrderBy(d => d.ThuTu).ToList();
            IEnumerable<ChiTietTour> chiTietTours = touris.ChiTietTours;
            listChiTietTour = new List<ChiTietTour>();
            diaDiemCuaTour = new List<DiaDiem>();
            if (chiTietTours != null)
            {
                foreach (ChiTietTour ch in chiTietTours)
                {
                    diaDiemCuaTour.Add(ch.diaDiem);
                }
                listChiTietTour.AddRange(chiTietTours.ToList());
            }
            
        }

        public void onThemGia(Gia gia, Touris touris)
        {
            duLichContext.Gia.AddOrUpdate(gia);
            duLichContext.SaveChangesAsync().Wait();
            if (userControl is ChiTietTouris)
            {
                LoadDataOfTourisFromDataBase(touris);
                userControl = new ChiTietTouris(touris, listLoais, danhSachGia, listDiaDiems, diaDiemCuaTour, this);
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
                userControl = new ChiTietTouris(touris, listLoais, danhSachGia, listDiaDiems, diaDiemCuaTour, this);
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
                userControl = new ChiTietTouris(touris, listLoais, danhSachGia, listDiaDiems, diaDiemCuaTour, this);
                panel_main_content.Controls.Clear();
                panel_main_content.Controls.Add(userControl);
            }
        }

        public void onHuyGia()
        {
        }

        public void onCapNhatDiaDiem(Touris touris, List<DiaDiem> newDiaDiemCuaTour)
        {
            //if (newDiaDiemCuaTour.Count() != 0)
       //     {
             //   if (diaDiemCuaTour.Count > 0)
               // {
                 //   for (int i = 0; i < diaDiemCuaTour.Count(); i++)

                   //     Console.WriteLine("dia diem " + diaDiemCuaTour.ToArray()[i].TenDiaDiem);
                     //   ChiTietTour chiTietTour = new ChiTietTour();
                       // if (listChiTietTour.Count() > 0)
                        /**
                         * {
                            ChiTietTour tempChiTiet = listChiTietTour.First();
                            if (tempChiTiet != null)
                            {
                                chiTietTour.MaChiTietTour = tempChiTiet.MaChiTietTour;
                                listChiTietTour.RemoveAt(0);
                            }
                        }
                        chiTietTour.diaDiem = diaDiemCuaTour.ToArray()[i];
                        chiTietTour.touris = touris;
                        chiTietTour.ThuTu = i + 1;
                        duLichContext.ChiTietTour.AddOrUpdate(chiTietTour);
                    }
                }
              //  else
                //{
                  //  for (int i = 0; i < newDiaDiemCuaTour.Count(); i++)
                    //{
                      //  ChiTietTour chiTietTour = new ChiTietTour();
                        //chiTietTour.diaDiem = newDiaDiemCuaTour.ToArray()[i];
                        //chiTietTour.touris = touris;
                        //chiTietTour.ThuTu = i + 1;
                        //duLichContext.ChiTietTour.AddOrUpdate(chiTietTour);
                   // }
               // }

//            }
            foreach (ChiTietTour chiTiet in listChiTietTour) {

                Console.WriteLine(chiTiet.diaDiem.TenDiaDiem);
            }
                        */
            duLichContext.ChiTietTour.RemoveRange(listChiTietTour);
            for (int i = 0; i < newDiaDiemCuaTour.Count(); i++)
                {
                  ChiTietTour chiTietTour = new ChiTietTour();
                    chiTietTour.diaDiem = newDiaDiemCuaTour.ToArray()[i];
                    chiTietTour.touris = touris;
                    chiTietTour.ThuTu = i + 1;
                    duLichContext.ChiTietTour.AddOrUpdate(chiTietTour);
                }
            duLichContext.SaveChangesAsync().ContinueWith(task =>
            {
                LoadDataOfTourisFromDataBase(touris);
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    userControl = new ChiTietTouris(touris, listLoais, danhSachGia, listDiaDiems, diaDiemCuaTour, this);
                    panel_main_content.Controls.Clear();
                    panel_main_content.Controls.Add(userControl);
                });
            });
          
        }

        public void onChiTietTourXoaTourClick(Touris currentTouris)
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
            userControl = new ChiTietTouris(null, listLoais, Enumerable.Empty<Gia>(), listDiaDiems, Enumerable.Empty<DiaDiem>().ToList(), this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        private void btn_quanlydiadiem_Click(object sender, EventArgs e)
        {
            userControl = new QuanLyDiaDiem(listDiaDiems,this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onThemDiaDiem()
        {
            userControl = new ChiTietDiaDiem(new DiaDiem(), this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onXoaDiaDiem(DiaDiem diaDiem)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa Địa điểm với mã là :" + diaDiem.MaDienDiem, "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                String message = "";
                List<ChiTietTour> chiTietToursTrungDiaDiem = duLichContext.ChiTietTour.Where(c => c.diaDiem.MaDienDiem == diaDiem.MaDienDiem).ToList();
                if (chiTietToursTrungDiaDiem.Count > 0) {
                    foreach (ChiTietTour chiTietTour in chiTietToursTrungDiaDiem) {
                        message += chiTietTour.touris.Name + " ";
                    }
                    DialogResult innerDialogResukt = MessageBox.Show("Địa điểm " + diaDiem.TenDiaDiem + " đang được dùng ở " + message + " vui lòng xóa những Tour trên trước");
                }
                else
                {
                    duLichContext.DiaDiem.Remove(diaDiem);
                    duLichContext.SaveChangesAsync().ContinueWith(task =>
                    {
                        LoadDataFromDataBase();
                        panel_main_content.Invoke((MethodInvoker)delegate
                        {
                            userControl = new QuanLyDiaDiem(listDiaDiems, this);
                            panel_main_content.Controls.Clear();
                            panel_main_content.Controls.Add(userControl);
                        });
                    });
                }
                
            }
        }

        public void onSuaDiaDiem(DiaDiem diaDiem)
        {
            userControl = new ChiTietDiaDiem(diaDiem, this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }

        public void onLuuDiaDiem(DiaDiem diaDiem)
        {
            duLichContext.DiaDiem.AddOrUpdate(diaDiem);
            duLichContext.SaveChangesAsync().ContinueWith(task =>
            {
                LoadDataFromDataBase();
                panel_main_content.Invoke((MethodInvoker)delegate
                {
                    userControl = new QuanLyDiaDiem(listDiaDiems, this);
                    panel_main_content.Controls.Clear();
                    panel_main_content.Controls.Add(userControl);
                });
            });
        }

        public void onHuyDiaDiemClick()
        {
            LoadDataFromDataBase();
            userControl = new QuanLyDiaDiem(listDiaDiems, this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
        }
    }
}
