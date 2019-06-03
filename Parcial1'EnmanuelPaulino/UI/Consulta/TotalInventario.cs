using Parcial1_EnmanuelPaulino.BLL;
using Parcial1_EnmanuelPaulino.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial1_EnmanuelPaulino.UI.Consulta
{
    public partial class TotalInventario : Form
    {
        public TotalInventario()
        {
            InitializeComponent();
        }
       
        private void TotalInventario_Load(object sender, EventArgs e)
        {
            var TotalInventario = TotalInventariosBLL.Buscar(1);
            if (TotalInventario == null)
                TotalTextBox.Text = string.Empty;
            else
                TotalTextBox.Text = TotalInventario.TotalInventario.ToString();
        }

        
    }
}
