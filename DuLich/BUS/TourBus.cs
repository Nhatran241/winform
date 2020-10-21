using DAL;
using System;
using System.Collections.Generic;
namespace BUS
{
    public class TourBus
    {
        private int maTour;
        public int MaTour
        {
            get { return maTour; }
            set { maTour = value; }
        }
        private string tenTour;
        public string TenTour
        {
            get { return tenTour; }
            set { tenTour = value; }
        }
        private LoaiTourBus loai;
        public LoaiTourBus LoaiTour
        {
            get { return loai; }
            set { loai = value; }
        }

        public TourBus(int _maTour, string _tenTour,LoaiTourBus _loaiTourBus)
        {
            MaTour = _maTour;
            TenTour = _tenTour;
        }

        public TourBus()
        {
        }

        internal void Update()
        {
            DalTour.Update(this);
        }
    }
}
