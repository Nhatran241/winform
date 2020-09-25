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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Thêm Tour");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Quản Lý Tour", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.panel_main_content = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
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
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(24, 37);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "btn_themtour";
            treeNode1.Text = "Thêm Tour";
            treeNode2.Name = "btn_quanlytour";
            treeNode2.Text = "Quản Lý Tour";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.treeView1.Size = new System.Drawing.Size(142, 463);
            this.treeView1.TabIndex = 4;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // QuanLyTouris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 548);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.panel_main_content);
            this.Name = "QuanLyTouris";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.OnManHinhChinhLoad);
            this.ResumeLayout(false);

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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Name == "btn_quanlytour")
            {
                LoadDataFromDataBase();
                userControl = new DanhSachTouris(listTouris, listLoais, this);
                panel_main_content.Controls.Clear();
                panel_main_content.Controls.Add(userControl);
                ScreenState = ScreenState.DANHSACHTOURIS;
            }
            else
            {
                userControl = new ChiTietTouris(null, listLoais, Enumerable.Empty<Gia>(), listDiaDiems.ToList(), Enumerable.Empty<DiaDiem>().ToList(), this);
                panel_main_content.Controls.Clear();
                panel_main_content.Controls.Add(userControl);
                ScreenState = ScreenState.CHITIETTOURIS;
            }
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

        public void onThemGia(Gia gia)
        {
        }

        public void onSuaGia(Gia gia)
        {
        }

        public void onXoaGia(Gia gia)
        {
        }

        public void onHuyGia()
        {
        }

        private TreeView treeView1;
    }
}

