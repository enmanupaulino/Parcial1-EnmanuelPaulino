using Parcial1_EnmanuelPaulino.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial1_EnmanuelPaulino.UI.Registro
{
    public partial class RegistroProducto : Form
    {
        public RegistroProducto()
        {
            InitializeComponent();
        }

       private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            DescripciontextBox.Text = string.Empty;
            ExistencianumericUpDown.Value = 0;
            CostonumericUpDown.Value = 0;
            
        }
        private void LlenaCampo(Productos productos)
        {
            IdnumericUpDown.Value = productos.ProductoId;
            DescripciontextBox.Text = productos.Descripcion;
            ExistencianumericUpDown.Value = productos.Existencia;
            CostonumericUpDown.Value = productos.Costo;
        }
         private  Productos LlenaClase()
        {
            Productos productos = new Productos();
            productos.ProductoId = Convert.ToInt32(IdnumericUpDown);
            productos.Descripcion = DescripciontextBox.Text;
            productos.Existencia = Convert.ToInt32(ExistencianumericUpDown);
            productos.Costo = Convert.ToInt32(CostonumericUpDown);
            return productos;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {


        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {

        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {

        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {

        }
    }
}
