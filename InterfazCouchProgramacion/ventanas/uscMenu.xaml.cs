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

namespace InterfazCouchProgramacion.ventanas
{
    /// <summary>
    /// Lógica de interacción para uscMenu.xaml
    /// </summary>
    public partial class uscMenu : UserControl
    {
        Grid main;
        public uscMenu(Grid gridmain)
        {
            InitializeComponent();
            main = gridmain;
        }

        private void btnCategoria_Click(object sender, RoutedEventArgs e)
        {
            main.Children.Clear();
            UserControl usc = new ventanas.uscRegistroCategoria(main);
            main.Children.Add(usc);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            main.Children.Clear();
            UserControl usc = new ventanas.uscRegistroIntegrante(main);
            main.Children.Add(usc);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            main.Children.Clear();
            UserControl usc = new ventanas.uscRegistroEquipos(main);
            main.Children.Add(usc);
        }

        private void btnEquipos_Click(object sender, RoutedEventArgs e)
        {
            main.Children.Clear();
            UserControl usc = new ventanas.uscLista(main);
            main.Children.Add(usc);
        }
    }
}
