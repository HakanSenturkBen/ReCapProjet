using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Businness.Concrete;
using DataAccess.Concrete.EntityFrameWork;

namespace WindowsForm
{
    public partial class RentACar : Form
    {
        public RentACar()
        {
            InitializeComponent();
        }

        private void RentACar_Load(object sender, EventArgs e)
        {
            RentalsManager rManager = new RentalsManager(new EFRentalsDal());
            var result = rManager.GetRentalDetails();
            if (result.Success) dataGridView1.DataSource = result.Data; 

        }
    }
}
