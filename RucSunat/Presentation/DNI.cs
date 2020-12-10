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
    public partial class DNI : Form
    {
        public DNI()
        {
            InitializeComponent();
          
        }

        private void btnRuc_Click(object sender, EventArgs e)
        {
            var otherForm = new Sunat();
            otherForm.Show();
            
        }

        private void DNI_Load(object sender, EventArgs e)
        {
                
        }

        private void DNI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Seguro que deseas salir?",
                                   "Salida",
                                   MessageBoxButtons.OKCancel,
                                   MessageBoxIcon.Information) == DialogResult.OK)
                    Environment.Exit(1);
            }
            else
                e.Cancel = true;
        }
    }
}
