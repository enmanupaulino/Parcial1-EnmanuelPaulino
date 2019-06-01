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
            MyErrorProvider.Clear();
            
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

            productos.ProductoId = Convert.ToInt32(IdnumericUpDown.Value);
            productos.Descripcion = DescripciontextBox.Text;
            productos.Existencia = Convert.ToDecimal(ExistencianumericUpDown.Value);

            productos.Costo = Convert.ToDecimal(CostonumericUpDown.Value);
            return productos;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Productos productos = ProductosBLL.Buscar((int)IdnumericUpDown.Value);
            return (productos != null);
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Productos productos = new Productos();
            bool paso = false;
            if (!Validar())
                return;
            productos = LlenaClase();

            //determinar si es guardar o modificar
            if (IdnumericUpDown.Value == 0)
            {
                paso = ProductosBLL.Guardar(productos);
               
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un producto no exixtente");
                    return;
                }
                paso = ProductosBLL.Modificar(productos);
            }
            //informar resultado
            if (paso)
            {
                MessageBox.Show("Producto Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
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

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            MyErrorProvider.Clear();
            int Id;
            int.TryParse(IdnumericUpDown.Text, out Id);
            Limpiar();
            if (ProductosBLL.Eliminar(Id))
                MessageBox.Show("Producto Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MyErrorProvider.SetError(IdnumericUpDown, "Nose pudo elimiar el producto");
           
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int Id;
            Productos productos = new Productos();
            int.TryParse(IdnumericUpDown.Text, out Id);
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

        private void NuevoButton_Click_1(object sender, EventArgs e)
        {
            Limpiar();

        }
    }
}
