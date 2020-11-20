using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DuLich.BUS
{
    public partial class Tour
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Name { get; set; }
        public virtual Loai Loai { get; set; }
        public virtual ICollection<Gia> Gias { get; set; }
        public virtual ICollection<Doan> Doans { get; set; }
        public virtual ICollection<ChiTietTour> ChiTietTours { get; set; }
        public override string ToString()
        {
            return Name;
        }

       
    }
}
