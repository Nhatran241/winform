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
        public virtual Khach Khach { get; set; }
        public virtual Doan Doan { get; set; }
      
    }
}
