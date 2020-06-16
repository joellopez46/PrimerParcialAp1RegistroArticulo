using RegistroArticulos.BLL;
using RegistroArticulos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace rArticulos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ArticuloIdTextBox.Text = "0";
           
        }
        private void Limpiar()
        {
            ArticuloIdTextBox.Text = "0";
            DescripcionTextBox.Text = string.Empty;
            ExistenciaTextBox.Text = string.Empty;
            CostoTextBox.Text = string.Empty;
            ValorinventarioTextBox.Text = string.Empty;

        }
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private Articulos LlenaClase()
        {
            Articulos articulo = new Articulos();

            articulo.ArticuloId = Convert.ToInt32(ArticuloIdTextBox.Text);
            articulo.Descripcion = DescripcionTextBox.Text;
            articulo.Existencia = Convert.ToInt32(ExistenciaTextBox.Text);
            articulo.Costo = Convert.ToInt32(CostoTextBox.Text);
            articulo.Valorinventario = Convert.ToInt32(articulo.Existencia * articulo.Costo);

            return articulo;
        }
        private void LlenaCampo(Articulos Producto)
        {
            ArticuloIdTextBox.Text = Convert.ToString(Producto.ArticuloId);
            DescripcionTextBox.Text = Producto.Descripcion;
            ExistenciaTextBox.Text = Convert.ToString(Producto.Existencia);
            CostoTextBox.Text = Convert.ToString(Producto.Costo);
            ValorinventarioTextBox.Text = Convert.ToString(Producto.Valorinventario);
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Articulos articulo = new Articulos();
            int.TryParse(ArticuloIdTextBox.Text, out id);

            Limpiar();

            articulo = ArticuloBLL.Buscar(id);

            if (articulo != null)
            {
                MessageBox.Show("Encontrado");
                LlenaCampo(articulo);
            }
            else
                MessageBox.Show("Articiulo no encontrado ....");

        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(DescripcionTextBox.Text))
            {
                MessageBox.Show("El campo Descripcion no puede estar vacio");
                ArticuloIdTextBox.Focus();
                paso = false;
            }
            if (DescripcionTextBox.Text == string.Empty)
            {
                MessageBox.Show("La Descripcion  no puede estar vacio");
                ArticuloIdTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(ExistenciaTextBox.Text))
            {
                MessageBox.Show("La existencia no puede estar vacia");
                ExistenciaTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CostoTextBox.Text))
            {
                MessageBox.Show("el costo no puede estar vacio");
                CostoTextBox.Focus();
                paso = false;
            }



            return paso;
        }

        private bool ExisteEnLaBaseDeDAto()
        {
            Articulos articulos = ArticuloBLL.Buscar(Convert.ToInt32(ArticuloIdTextBox.Text));
            return (articulos != null);

        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Articulos articulos = new Articulos();
            bool paso = false;

            if (!Validar())
                return;

            articulos = LlenaClase();
            if (ArticuloIdTextBox.Text == "0")
                paso = ArticuloBLL.Guardar(articulos);
            else
            {

                if (!ExisteEnLaBaseDeDAto())
                {
                    MessageBox.Show("No fue posible Guardar!!", " Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                paso = ArticuloBLL.Modificar(articulos);
            }


            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
                MessageBox.Show("Guardado", "Exito", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(ArticuloIdTextBox.Text, out id);

            Limpiar();
            if (ArticuloBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No se Puede Eliminar un articulo que no existe");

        }

        private void ExistenciaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ExistenciaTextBox.Text) && !string.IsNullOrWhiteSpace(CostoTextBox.Text))
            {
                int Num1;
                decimal Num2;

                Num1 = Convert.ToInt32(ExistenciaTextBox.Text);
                Num2 = Convert.ToDecimal(CostoTextBox.Text);

                ValorinventarioTextBox.Text = Convert.ToString(Num1 * Num2);
            }
        }

        private void CostoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ExistenciaTextBox.Text) && !string.IsNullOrWhiteSpace(CostoTextBox.Text))
            {
                int Num1;
                decimal Num2;

                Num1 = Convert.ToInt32(ExistenciaTextBox.Text);
                Num2 = Convert.ToDecimal(CostoTextBox.Text);

                ValorinventarioTextBox.Text = Convert.ToString(Num1 * Num2);
            }
        }

        private void ValorinventarioTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ExistenciaTextBox.Text) && !string.IsNullOrWhiteSpace(CostoTextBox.Text))
            {
                int Num1;
                decimal Num2;

                Num1 = Convert.ToInt32(ExistenciaTextBox.Text);
                Num2 = Convert.ToDecimal(CostoTextBox.Text);

                ValorinventarioTextBox.Text = Convert.ToString(Num1 * Num2);
            }
        }
    }
}
