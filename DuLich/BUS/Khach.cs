﻿using DuLich.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace DuLich.BUS
{
    public partial class Khach
    {
        public Task AddOrUpdate()
        {
            return KhachDal.AddOrUpdate(this);
        }
        public Task Delete()
        {
            return KhachDal.Delete(this);
        }
    }
}