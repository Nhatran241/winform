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
    public class ChiPhi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public Doan Doan { get; set; }
        public LoaiChiPhi LoaiChiPhi { get; set; }
        public long giaTri { get; set; }
        public string ghiChu { get; set; }
        public void AddOrUpdate()
        {
            ChiPhiDal.GetInstance().AddOrUpdate(this);
        }
        public void Delete()
        {
            ChiPhiDal.GetInstance().Delete(this);
        }
    }
}
