using Parcial1_EnmanuelPaulino.UI.Registro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial1_EnmanuelPaulino
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void InventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroProducto f = new RegistroProducto();
            f.Show();
        }
    }
}
