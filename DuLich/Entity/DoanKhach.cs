using DuLich.DAL;
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
    public class DoanKhach
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaDoanKhach { get; set; }
        public Khach Khach { get; set; }
        public Doan Doan { get; set; }
        public void AddOrUpdate()
        {
            DoanKhachDal.GetInstance().AddOrUpdate(this);
        }
        public void Delete()
        {
            DoanKhachDal.GetInstance().Delete(this);
        }
    }
}
