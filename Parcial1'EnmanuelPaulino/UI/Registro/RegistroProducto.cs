using Parcial1_EnmanuelPaulino.BLL;
using Parcial1_EnmanuelPaulino.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
            List<Inventarios> inventario = TotalInventariosBLL.GetList(x=>true);
            if(inventario.Count==0)
            {
                Inventarios inventarios = new Inventarios();
                inventarios.TotalInventario = 0;
                TotalInventariosBLL.Guardar(inventarios);
            }
        }

        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            DescripciontextBox.Text = string.Empty;
            ExistencianumericUpDown.Value = 0;
            CostonumericUpDown.Value = 0;
            ValorInventarionumericUpDown.Value = 0;
            MyErrorProvider.Clear();

        }

        private void LlenaCampo(Productos productos)
        {
            IdnumericUpDown.Value = productos.ProductoId;
            DescripciontextBox.Text = productos.Descripcion;
            ExistencianumericUpDown.Value = productos.Existencia;
            CostonumericUpDown.Value = productos.Costo;
            ValorInventarionumericUpDown.Value = productos.ValorInventario;
        }

        private Productos LlenaClase()
        {
            Productos productos = new Productos();

            productos.ProductoId = Convert.ToInt32(IdnumericUpDown.Value);
            productos.Descripcion = DescripciontextBox.Text;
            productos.Existencia = Convert.ToDecimal(ExistencianumericUpDown.Value);
            productos.Costo = Convert.ToDecimal(CostonumericUpDown.Value);
            productos.ValorInventario = Convert.ToDecimal(ValorInventarionumericUpDown.Value);
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
           
            productos = LlenaClase();
            if (Validar(2))
            {
                MessageBox.Show("Llenar todos los campos marcados");
                return;
            }
            if (ExistencianumericUpDown.Value <=0 || CostonumericUpDown.Value <=0)
            {
                MessageBox.Show("Debe ser mayor a 0");
                return;
            }

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

       /* private bool Validar()
        {
            bool paso = true;
            MyErrorProvider.Clear();
            if (DescripciontextBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(DescripciontextBox, "Falta la descripcion del producto");
                DescripciontextBox.Focus();
                paso = false;
            }
            //if(IdnumericUpDown.Value == null){
             MyErrorProvider.SetError(IdnumericUpDown, "favor
            }
            return paso;
        }*/
        public bool Validar(int error)
        {
            bool paso = false;

            if (error == 1 && IdnumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(IdnumericUpDown, "Llenar ID");
                paso = true;
            }
            if (error == 2 && string.IsNullOrEmpty(DescripciontextBox.Text))
            {
                MyErrorProvider.SetError(DescripciontextBox, "Favor LLenar");
                paso = true;
            }
            if (error == 3 && string.IsNullOrEmpty(CostonumericUpDown.Text))
            {
                MyErrorProvider.SetError(CostonumericUpDown, "Favor LLenar");
                paso = true;
            }
            if (error == 4 && ExistencianumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(ExistencianumericUpDown, "Favor Llenar");
                paso = true;
            }
            

            return paso;
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (Validar(1))
            {
                MessageBox.Show("El TipoID esta vacio", "Llene Campo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //MyErrorProvider.Clear();
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
            if (Validar(1))
            {
                MessageBox.Show("El TipoID esta vacio", "Llene Campo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
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
        private void Calcular()
        {
            decimal existencia = Convert.ToDecimal(ExistencianumericUpDown.Value);
            decimal costo = Convert.ToDecimal(CostonumericUpDown.Value);
            decimal Resultado = existencia * costo;
            ValorInventarionumericUpDown.Value = Resultado;
        }
        private void ExistencianumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Calcular();
        }

        private void CostonumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Calcular();
        }
    }
}
