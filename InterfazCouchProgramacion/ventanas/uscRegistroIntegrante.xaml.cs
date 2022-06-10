using DAOProgra.Implementacion;
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
using DAOProgra.Modelo;
namespace InterfazCouchProgramacion.ventanas
{
    /// <summary>
    /// Lógica de interacción para uscRegistroIntegrante.xaml
    /// </summary>
    public partial class uscRegistroIntegrante : UserControl
    {
        Grid gridMain;
        public uscRegistroIntegrante(Grid Main)
        {
            InitializeComponent();
            gridMain = Main;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Controladores.controladorEstudiante.Insert(new Estudiante(txtnombre.Text, txtPrimerApellido.Text, txtSegundoApellido.Text, txtHabilidades.Text, cmbNivel.Text));
            }
            catch (Exception)
            {

                throw;
            }
            MessageBox.Show("Estudiante Registrado");
            Volver();

        }

        private void cmbNivel_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in Controladores.Niveles)
            {
                cmbNivel.Items.Add(item);
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            Volver();
        }

        void Volver()
        {
            gridMain.Children.Clear();
            UserControl usc = new ventanas.uscMenu(gridMain);
            gridMain.Children.Add(usc);
        }
    }
}
