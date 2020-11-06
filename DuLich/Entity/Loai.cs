using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DuLich.BUS
{
    public class Loai
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String TenLoai { get; set; }

        public virtual ICollection<Tour> Touris { get; set; }
        public override string ToString()
        {
            return TenLoai;
        }

    }
}
