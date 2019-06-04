using Parcial1_EnmanuelPaulino.BLL;
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
    public partial class Ubicacione : Form
    {
        public Ubicacione()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            DescripciontextBox.Text = string.Empty;
           

        }

        private void LlenaCampo(Entidades.Ubicaciones ubicaciones)
        {
            IdnumericUpDown.Value = ubicaciones.UbicacionId;
            DescripciontextBox.Text = ubicaciones.Descripcion;
            
        }

        private Entidades.Ubicaciones LlenaClase()
        {
            Entidades.Ubicaciones ubicaciones = new Entidades.Ubicaciones();

            ubicaciones.UbicacionId = Convert.ToInt32(IdnumericUpDown.Value);
            ubicaciones.Descripcion = DescripciontextBox.Text;
            return ubicaciones;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Entidades.Ubicaciones ubicaciones = UbicacionesBLL.Buscar((int)IdnumericUpDown.Value);
            return (ubicaciones != null);
        }
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Entidades.Ubicaciones ubicaciones = new Entidades.Ubicaciones();

            bool paso = false;

            ubicaciones = LlenaClase();
            if (Validar(2))
            {
                MessageBox.Show("Llenar todos los campos marcados");
                return;
            }
           

            //determinar si es guardar o modificar
            if (IdnumericUpDown.Value == 0)

            {
                paso = UbicacionesBLL.Guardar(ubicaciones);


            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un producto no exixtente");
                    return;
                }
                paso = UbicacionesBLL.Modificar(ubicaciones);
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
            if (UbicacionesBLL.Eliminar(Id))
                MessageBox.Show("Producto Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MyErrorProvider.SetError(IdnumericUpDown, "Nose pudo elimiar el producto");

        }
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int Id;
            Entidades.Ubicaciones ubicaciones = new Entidades.Ubicaciones();
            if (Validar(1))
            {
                MessageBox.Show("El TipoID esta vacio", "Llene Campo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int.TryParse(IdnumericUpDown.Text, out Id);
            ubicaciones = UbicacionesBLL.Buscar(Id);
            if (ubicaciones != null)
            {
                MessageBox.Show("Producto encontrado");
                LlenaCampo(ubicaciones);
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
            


            return paso;
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click_1(object sender, EventArgs e)
        {
            Entidades.Ubicaciones ubicaciones = new Entidades.Ubicaciones();

            bool paso = false;

            ubicaciones = LlenaClase();
            if (Validar(2))
            {
                MessageBox.Show("Llenar todos los campos marcados");
                return;
            }


            //determinar si es guardar o modificar
            if (IdnumericUpDown.Value == 0)

            {
                paso = UbicacionesBLL.Guardar(ubicaciones);


            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un producto no exixtente");
                    return;
                }
                paso = UbicacionesBLL.Modificar(ubicaciones);
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

        private void EliminarButton_Click_1(object sender, EventArgs e)
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
            if (UbicacionesBLL.Eliminar(Id))
                MessageBox.Show("Producto Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MyErrorProvider.SetError(IdnumericUpDown, "Nose pudo elimiar el producto");
        }

        private void BuscarButton_Click_1(object sender, EventArgs e)
        {
            int Id;
            Entidades.Ubicaciones ubicaciones = new Entidades.Ubicaciones();
            if (Validar(1))
            {
                MessageBox.Show("El TipoID esta vacio", "Llene Campo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int.TryParse(IdnumericUpDown.Text, out Id);
            ubicaciones = UbicacionesBLL.Buscar(Id);
            if (ubicaciones != null)
            {
                MessageBox.Show("Producto encontrado");
                LlenaCampo(ubicaciones);
            }
            else
            {
                MessageBox.Show("Producton no encotnrado");
            }
        }
    }
}
