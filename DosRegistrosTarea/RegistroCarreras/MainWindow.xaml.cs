using System.Windows;
using RegistroCarreras.Entidades;
using RegistroCarreras.BLL;
using RegistroCarreras.DAL;
using System;
using System.Windows.Navigation;



namespace RegistroCarreras
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Carreras carreras = new Carreras();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = carreras;
            var listado = CarrerasBLL.GetList(l => true);
            LibrosDataGrid.ItemsSource = listado;
            
            
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = this.carreras;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (string.IsNullOrWhiteSpace(carreras.CarrerasId.ToString()))
            {
                esValido = false;
                BuscarTextBox.Focus();
                MessageBox.Show("Debe indicar el ID!", "Validación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (string.IsNullOrWhiteSpace(carreras.Nombre))
            {
                esValido = false;
                NombreTextBox.Focus();
                MessageBox.Show("Debe indicar el Nombre!", "Validación", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return esValido;
        }
    
           

       public  void Limpiar()
        {
            this.carreras = new Carreras();
            this.DataContext = carreras;
            this.BuscarTextBox.Clear();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;
            if (!Validar())
                return;

             paso = CarrerasBLL.Guardar(carreras);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {

        Limpiar();


         }
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (CarrerasBLL.Eliminar(carreras.CarrerasId))
            {
                Limpiar();
                MessageBox.Show("Carrera eliminada con éxito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No se pudo eliminar la Carrera", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var encontrado = CarrerasBLL.Buscar(this.carreras.CarrerasId);

            if (encontrado != null)
            {
                this.carreras = encontrado;
                Cargar();

            }
            else
            {
                Limpiar();
                MessageBox.Show("No se encontro la carrera!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        }
            
    }

