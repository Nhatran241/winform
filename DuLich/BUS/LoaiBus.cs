using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BUS
{
    public class LoaiTourBus
    {

        private int ma;
        public int MaLoai
        {
            get { return ma; }
            set { ma = value; }
        }

        private string ten;
        public string TenLoai
        {
            get { return ten; }
            set { ten = value; }
        }

        public LoaiTourBus(int _ma, string _ten)
        {
            MaLoai = _ma;
            TenLoai = _ten;
        }
    }
}
