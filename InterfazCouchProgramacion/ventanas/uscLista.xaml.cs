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
    /// Lógica de interacción para uscLista.xaml
    /// </summary>
    public partial class uscLista : UserControl
    {
        Grid Main;
        public uscLista(Grid main)
        {
            InitializeComponent();
            Main = main;
        }

        private void btnLider_Click(object sender, RoutedEventArgs e)
        {
            
            DataRowView d = (DataRowView)dgvEquipos.SelectedItem;
            short id = short.Parse(d.Row.ItemArray[0].ToString());
            Equipo eq = Controladores.controladorEquipo.get(id);

            DataRowView drv = (DataRowView)dgvIntegrantes.SelectedItem;
            short idLider = short.Parse(drv.Row.ItemArray[0].ToString());

            eq.Lider = idLider;

            try
            {
                Controladores.controladorEquipo.UpdateLider(eq);
                MessageBox.Show("Se Ha designado El lider del equipo: " + eq.Nombre);
            }
            catch (Exception)
            {

                throw;
            }
            refreshEquipos();

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            refreshEquipos();
        }

        void refreshEquipos()
        {
            dgvEquipos.ItemsSource = Controladores.controladorEquipo.Select().DefaultView;
            dgvEquipos.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void dgvEquipos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvEquipos.SelectedItem != null)
            {
                DataRowView d = (DataRowView)dgvEquipos.SelectedItem;
                short id = short.Parse(d.Row.ItemArray[0].ToString());
                Equipo eq = Controladores.controladorEquipo.get(id);
                txtNombre.Text = "Nombre del Equipo: " + eq.Nombre;
                txtCategoria.Text = "Categoría: " + eq.NombreCategoria;
                dgvIntegrantes.ItemsSource = Controladores.controladorEstudiante.SelectEstudianteHabilidad(id).DefaultView;
                dgvIntegrantes.Columns[1].Visibility = Visibility.Collapsed;

            }
            
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            Main.Children.Clear();
            UserControl usc = new ventanas.uscMenu(Main);
            Main.Children.Add(usc);
        }
    }
}
