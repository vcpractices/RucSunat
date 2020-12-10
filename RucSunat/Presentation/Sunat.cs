using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RucSunat.Presentation
{
    public partial class Sunat : Form
    {
        public Sunat()
        {
            InitializeComponent();
        }

        private void btnDni_Click(object sender, EventArgs e)
        {
            var myForm = new DNI();
            myForm.Show();
        }
    }   
}
