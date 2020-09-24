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
            this.button1 = new System.Windows.Forms.Button();
            this.panel_main_content = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Quản Lý Tour";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnQuanLyTourisClick);
            // 
            // panel_main_content
            // 
            this.panel_main_content.Location = new System.Drawing.Point(182, 37);
            this.panel_main_content.Name = "panel_main_content";
            this.panel_main_content.Size = new System.Drawing.Size(590, 512);
            this.panel_main_content.TabIndex = 3;
            this.panel_main_content.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // QuanLyTouris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panel_main_content);
            this.Controls.Add(this.button1);
            this.Name = "QuanLyTouris";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.OnManHinhChinhLoad);
            this.ResumeLayout(false);

        }

        private ScreenState ScreenState = ScreenState.NOTDETECTED;
        UserControl userControl;
        DuLichContext duLichContext = new DuLichContext();
        private IEnumerable<Touris> listTouris;
        private IEnumerable<Loai> listLoais;
        private IEnumerable<DiaDiem> danhSachDiaDiem;

        private void OnManHinhChinhLoad(object sender, EventArgs e)
        {
            listTouris = duLichContext.Touris.ToList();
            listLoais = duLichContext.Loai.ToList();
            danhSachDiaDiem = duLichContext.DiaDiem.ToList();
            if (userControl == null)
                userControl = new DanhSachTouris(listTouris,listLoais, this);
            panel_main_content.Controls.Add(userControl);
            ScreenState = ScreenState.DANHSACHTOURIS;
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
            danhSachGia =duLichContext.Gia.Where(c => c.TourisId == selectedTouris.Id).ToList();
            IEnumerable<ChiTietTour> chiTietTours = duLichContext.ChiTietTour.Where(c => c.MaTour == selectedTouris.Id).OrderBy(d=>d.ThuTu).ToList();
            diaDiemCuaTour = new List<DiaDiem>();
            foreach (ChiTietTour ch in chiTietTours)
            {
                diaDiemCuaTour.AddRange(danhSachDiaDiem.Where(c => c.MaDienDiem == ch.MaDiaDiem).ToList());
            }
            //diaDiemCuaTour = danhSachDiaDiem.Where(c => chiTietTours.Select(d => d.MaDiaDiem).ToList().Contains(c.MaDienDiem)).ToList();
         
            listChiTietTour = new List<ChiTietTour>();
            listChiTietTour.AddRange(chiTietTours.ToList());
            userControl = new ChiTietTouris(selectedTouris, listLoais,danhSachGia,danhSachDiaDiem.ToList(),diaDiemCuaTour, this);
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
       
            for(int i=0;i<diaDiemCuaTour.Count();i++)
            {
                ChiTietTour chiTietTour = new ChiTietTour();
                if (listChiTietTour.Count() > 0)
                {
                    ChiTietTour tempChiTiet = listChiTietTour.First();
                    if(tempChiTiet != null)
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
            duLichContext.Touris.AddOrUpdate(tourisAfterUpdate);
            duLichContext.ChiTietTour.RemoveRange(listChiTietTour);
            duLichContext.SaveChangesAsync();
        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel_main_content;

    }
}

