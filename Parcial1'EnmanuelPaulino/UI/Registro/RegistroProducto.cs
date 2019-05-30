using Parcial1_EnmanuelPaulino.BLL;
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
            productos.ProductoId = 0;
            productos.Descripcion = DescripciontextBox.Text;
            productos.Existencia = 0;
            productos.Costo = 0;
            return productos;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Productos productos = new Productos();
            return (productos != null);
        }


        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Productos productos = new Productos();
            bool paso = false;
            if (!Validar())
                return;
            productos = LlenaClase();
            Limpiar();
            //determinar si es guardar o modificar
            if (IdnumericUpDown.Value == 0)
                paso = ProductosBLL.Guardar(productos);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un producto no exixtente");
                    return;
                }
                paso = ProductosBLL.Modifircar(productos);
            }
            //informar resultado
            if (paso)
                MessageBox.Show("Producto Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error al guardar prodcuto", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private bool Validar()
        {
            bool paso = true;
            MyErrorProvider.Clear();
            if (DescripciontextBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(DescripciontextBox, "Falta la descripcion del producto");
                DescripciontextBox.Focus();
                paso = false;
            }
            return paso;
        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {

        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int Id;
            Productos productos = new Productos();
            int.TryParse(IdnumericUpDown.Text, out Id);
            Limpiar();
            productos = ProductosBLL.Buscar(Id);
            if (productos != null)
            {
                MessageBox.Show("Producto encontrado");
                LlenaCampo(productos);
            }
            else
            {
                MessageBox.Show("Producton no encotnrado");
            }


        }

    }
}
