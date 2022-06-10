﻿using DAOProgra.Implementacion;
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

namespace InterfazCouchProgramacion
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BaseImpl baseImpl = new BaseImpl();
        public MainWindow()
        {
            InitializeComponent();
            Config.pathFotoEquipo = baseImpl.SelectPath();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gridMain.Children.Clear();
            UserControl usc = new ventanas.uscMenu(gridMain);
            gridMain.Children.Add(usc);
        }
    }
}
