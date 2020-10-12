using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DuLich.Entity;

namespace DuLich.View.QuanLyTouris
{
    public partial class TaoDoan : UserControl
    {
        private DuLichContext context;
        public TaoDoan(DuLichContext _context)
        {

            this.context = _context;
            List<Touris> touris = context.Touris.ToList();
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void datepicker_batdau_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
