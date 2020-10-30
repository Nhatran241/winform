﻿using DuLich.DAL;
using DuLich.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuLich.Model.Entity
{
    public class PhanCong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaPhanCong { get; set; }
        public Doan Doan { get; set; }
        public NhanVien NhanVien { get; set; }
        public String NhiemVu { get; set; }
        public void AddOrUpdate()
        {
            PhanCongDal.GetInstance().AddOrUpdate(this);
        }
        public void Delete()
        {
            PhanCongDal.GetInstance().Delete(this);
        }
    }
}
