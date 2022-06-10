using DAOProgra.Implementacion;
using DAOProgra.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace InterfazCouchProgramacion.ventanas
{
    /// <summary>
    /// Lógica de interacción para uscRegistroCategoria.xaml
    /// </summary>
    public partial class uscRegistroCategoria : UserControl
    {
        List<Categoria> listasCategorias = new List<Categoria>();
        Grid main;
        public uscRegistroCategoria(Grid gridmain)
        {
            InitializeComponent();
            main = gridmain;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            main.Children.Clear();
            UserControl usc = new ventanas.uscMenu(main);
            main.Children.Add(usc);
        }

        private void btnRegistro_Click(object sender, RoutedEventArgs e)
        {
            string nombreCategoria = txbNombre.Text;
            string nivel = cmbNivel.Text;
            Categoria categoria = new Categoria(nombreCategoria, nivel);
            try
            {
                Controladores.controladorCategoria.Insert(categoria);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Actualizar();
                txbNombre.Text = "";
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Actualizar();
        }

        void Actualizar()
        {
            try
            {
                listasCategorias = new List<Categoria>();
                DataTable dt = Controladores.controladorCategoria.Select();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    listasCategorias.Add(new Categoria(short.Parse(dt.Rows[i][0].ToString()), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString(),byte.Parse(dt.Rows[i][3].ToString()),DateTime.Parse(dt.Rows[i][4].ToString()),DateTime.Parse(dt.Rows[i][4].ToString())));
                }
                dgCategorias.ItemsSource = null;
                dgCategorias.ItemsSource = listasCategorias;
                dgCategorias.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cmbNivel_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in Controladores.Niveles)
            {
                cmbNivel.Items.Add(item);
            }
        }
    }
}
