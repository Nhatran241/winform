using DuLich.Entity;
using DuLich.Model.Entity;
using DuLich.View;
using DuLich.View.QuanLyTouris;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows.Forms;

namespace DuLich
{
    partial class QuanLyTouris : DanhSachTouris.OnItemClickListener,ChiTietTouris.OnChiTietClickListener
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_main_content = new System.Windows.Forms.Panel();
            this.btn_quanlytour = new System.Windows.Forms.Button();
            this.btn_taotour = new System.Windows.Forms.Button();
            this.tv_quanlytour = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel_main_content
            // 
            this.panel_main_content.Location = new System.Drawing.Point(182, 37);
            this.panel_main_content.Name = "panel_main_content";
            this.panel_main_content.Size = new System.Drawing.Size(512, 512);
            this.panel_main_content.TabIndex = 3;
            this.panel_main_content.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btn_quanlytour
            // 
            this.btn_quanlytour.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_quanlytour.Location = new System.Drawing.Point(11, 37);
            this.btn_quanlytour.Name = "btn_quanlytour";
            this.btn_quanlytour.Size = new System.Drawing.Size(165, 32);
            this.btn_quanlytour.TabIndex = 5;
            this.btn_quanlytour.Text = "Danh Sách Tour";
            this.btn_quanlytour.UseVisualStyleBackColor = true;
            this.btn_quanlytour.Click += new System.EventHandler(this.btn_quanlytour_Click);
            // 
            // btn_taotour
            // 
            this.btn_taotour.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_taotour.Location = new System.Drawing.Point(12, 75);
            this.btn_taotour.Name = "btn_taotour";
            this.btn_taotour.Size = new System.Drawing.Size(164, 33);
            this.btn_taotour.TabIndex = 6;
            this.btn_taotour.Text = "Tạo Tour";
            this.btn_taotour.UseVisualStyleBackColor = true;
            this.btn_taotour.Click += new System.EventHandler(this.btn_taotour_Click);
            // 
            // tv_quanlytour
            // 
            this.tv_quanlytour.AutoSize = true;
            this.tv_quanlytour.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_quanlytour.Location = new System.Drawing.Point(6, 5);
            this.tv_quanlytour.Name = "tv_quanlytour";
            this.tv_quanlytour.Size = new System.Drawing.Size(170, 29);
            this.tv_quanlytour.TabIndex = 0;
            this.tv_quanlytour.Text = "Quản Lý Tour";
            // 
            // QuanLyTouris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 548);
            this.Controls.Add(this.tv_quanlytour);
            this.Controls.Add(this.btn_taotour);
            this.Controls.Add(this.btn_quanlytour);
            this.Controls.Add(this.panel_main_content);
            this.Name = "QuanLyTouris";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.OnManHinhChinhLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        #endregion
        private System.Windows.Forms.Panel panel_main_content;



        private ScreenState ScreenState = ScreenState.NOTDETECTED;
        UserControl userControl;
        DuLichContext duLichContext = new DuLichContext();
        private IEnumerable<Touris> listTouris;
        private IEnumerable<Loai> listLoais;
        private IEnumerable<DiaDiem> listDiaDiems;

        private void OnManHinhChinhLoad(object sender, EventArgs e)
        {
            LoadDataFromDataBase();
            if (userControl == null)
                userControl = new DanhSachTouris(listTouris, listLoais, this);
            panel_main_content.Controls.Add(userControl);
            ScreenState = ScreenState.DANHSACHTOURIS;
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
            ScreenState = ScreenState.DANHSACHTOURIS;
        }

     
        private IEnumerable<Gia> danhSachGia;
        private List<ChiTietTour> listChiTietTour;
        private List<DiaDiem> diaDiemCuaTour;

        public void onItemClicked(int position)
        {
            Touris selectedTouris = listTouris.ToArray()[position];
            LoadDataOfTourisFromDataBase(selectedTouris);
            userControl = new ChiTietTouris(selectedTouris, listLoais, danhSachGia, listDiaDiems.ToList(), diaDiemCuaTour, this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
            ScreenState = ScreenState.CHITIETTOURIS;

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

        private Button btn_quanlytour;
        private Button btn_taotour;
        private Label tv_quanlytour;

        public void onCapNhatClick(Touris tourisAfterUpdate, List<DiaDiem> diaDiemCuaTour)
        {
            if(diaDiemCuaTour.Count()!=0)
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

        public void onThemGia(Gia gia,Touris touris)
        {
            duLichContext.Gia.AddOrUpdate(gia);
            duLichContext.SaveChangesAsync().Wait();
            if (userControl is ChiTietTouris)
            {
                LoadDataOfTourisFromDataBase(touris);
                userControl = new ChiTietTouris(touris, listLoais, danhSachGia, listDiaDiems.ToList(), diaDiemCuaTour, this);
                panel_main_content.Controls.Clear();
                panel_main_content.Controls.Add(userControl);
                ScreenState = ScreenState.CHITIETTOURIS;
            }
        }

        public void onSuaGia(Gia gia,Touris touris)
        {
            duLichContext.Gia.AddOrUpdate(gia);
            duLichContext.SaveChangesAsync().Wait();
              if (userControl is ChiTietTouris)
            {
                LoadDataOfTourisFromDataBase(touris);
                userControl = new ChiTietTouris(touris, listLoais, danhSachGia, listDiaDiems.ToList(), diaDiemCuaTour, this);
                panel_main_content.Controls.Clear();
                panel_main_content.Controls.Add(userControl);
                ScreenState = ScreenState.CHITIETTOURIS;
            }
        }

        public void onXoaGia(Gia gia,Touris touris)
        {
            duLichContext.Gia.Remove(gia);
            duLichContext.SaveChangesAsync().Wait();
            if (userControl is ChiTietTouris)
            {
                LoadDataOfTourisFromDataBase(touris);
                userControl = new ChiTietTouris(touris, listLoais, danhSachGia, listDiaDiems.ToList(), diaDiemCuaTour, this);
                panel_main_content.Controls.Clear();
                panel_main_content.Controls.Add(userControl);
                ScreenState = ScreenState.CHITIETTOURIS;
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
                ScreenState = ScreenState.CHITIETTOURIS;
            }
        }

        public void onXoaClick(Touris currentTouris)
        {
           DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa Touris với mã là :" + currentTouris.Id, "", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                duLichContext.Touris.Remove(currentTouris);
                duLichContext.SaveChangesAsync().Wait();
                LoadDataFromDataBase();
                userControl = new DanhSachTouris(listTouris, listLoais, this);
                panel_main_content.Controls.Clear();
                panel_main_content.Controls.Add(userControl);
                ScreenState = ScreenState.DANHSACHTOURIS;
            }
        }
        private void btn_quanlytour_Click(object sender, EventArgs e)
        {
            LoadDataFromDataBase();
            userControl = new DanhSachTouris(listTouris, listLoais, this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
            ScreenState = ScreenState.DANHSACHTOURIS;
        }

        private void btn_taotour_Click(object sender, EventArgs e)
        {
            userControl = new ChiTietTouris(null, listLoais, Enumerable.Empty<Gia>(), listDiaDiems.ToList(), Enumerable.Empty<DiaDiem>().ToList(), this);
            panel_main_content.Controls.Clear();
            panel_main_content.Controls.Add(userControl);
            ScreenState = ScreenState.CHITIETTOURIS;
        }
       
    }
}

