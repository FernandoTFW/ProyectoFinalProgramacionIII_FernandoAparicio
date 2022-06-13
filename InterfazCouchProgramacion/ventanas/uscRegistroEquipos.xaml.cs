using DAOProgra.Implementacion;
using DAOProgra.Modelo;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    /// Lógica de interacción para uscRegistroEquipos.xaml
    /// </summary>
    public partial class uscRegistroEquipos : UserControl
    {
        Grid gridMain;
        DataTable Estudiantes;
        List<Estudiante> listaEstudiantes=new List<Estudiante>();
        string pathFoto="";
        EquipoImpl equipoImpl;
        List<int> ListaAgregados = new List<int>();
        List<int> ListaId = new List<int>();
        public uscRegistroEquipos(Grid main)
        {
            InitializeComponent();
            gridMain = main;
            
        }

        private void txbBusqueda_TextChanged(object sender, TextChangedEventArgs e)
        {
            Busqueda(txbBusqueda.Text);
        }

        private void cmbCategoria_Loaded(object sender, RoutedEventArgs e)
        {
            cmbCategoria.ItemsSource = null;
            cmbCategoria.SelectedValuePath = "id";
            cmbCategoria.DisplayMemberPath = "nombre";
            cmbCategoria.ItemsSource = Controladores.controladorCategoria.SelectIdName().DefaultView;
            
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            
            DataRowView d = (DataRowView)dgvEstudiantes.SelectedItem;
            short id = short.Parse(d.Row.ItemArray[0].ToString());
            Estudiante est = Controladores.controladorEstudiante.Get(id);
            est.Id = id;
            if (ListaId.Contains(id))
            {

            }
            else
            {
                listaEstudiantes.Add(est);
                ListaId.Add(id);
            }
            dgvEquipo.ItemsSource = null;
            dgvEquipo.ItemsSource = listaEstudiantes;
            ocultarDatos();
        }

        private void btnSugerir_Click(object sender, RoutedEventArgs e)
        {
            listaEstudiantes.Clear();
            ListaAgregados.Clear();
            Random r = new Random();
            int tamano = int.Parse(txtTamano.Text);
            if (Estudiantes.Rows.Count < tamano)
            {
                MessageBox.Show("Estudiantes con habilidades indicadas insuficientes para ese tamaño");
            }
            else
            {
                for (int i = 0; i < tamano; i++)
                {
                    agregarEstudiantes(tamano,r);
                }
            }
            dgvEquipo.ItemsSource = null;
            dgvEquipo.ItemsSource = listaEstudiantes;
            ocultarDatos();

        }

        private void txtTamano_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txtTamano.Text == "")
            {
                btnSugerir.IsEnabled = false;
            }
            else
            {
                btnSugerir.IsEnabled = true;
            }
        }

        private void btnLogo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == true)
            {
                pathFoto = ofd.FileName;
                imgLogo.Source = new BitmapImage(new Uri(pathFoto));
            }
        }

        void agregarEstudiantes(int tamano,Random r)
        {
            int selected = r.Next(tamano);
            if (ListaAgregados.Contains(selected))
            {
                agregarEstudiantes(tamano, r);
            }
            else
            {
                DataRowView d = (DataRowView)dgvEstudiantes.Items[selected];
                short id = short.Parse(d.Row.ItemArray[0].ToString());
                Estudiante est = Controladores.controladorEstudiante.Get(id);
                est.Id = id;
                listaEstudiantes.Add(est);
                ListaId.Add(id);
                ListaAgregados.Add(selected);
            }
        }
        void ocultarDatos()
        {
            dgvEquipo.Columns[0].Visibility = Visibility.Collapsed;
            dgvEquipo.Columns[6].Visibility = Visibility.Collapsed;
            dgvEquipo.Columns[7].Visibility = Visibility.Collapsed;
            dgvEquipo.Columns[8].Visibility = Visibility.Collapsed;
            dgvEquipo.Columns[9].Visibility = Visibility.Collapsed;
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            equipoImpl = new EquipoImpl();
            foreach (Estudiante item in listaEstudiantes)
            {
                item.IdEquipo = short.Parse(equipoImpl.LastIndex("Equipo"));
            }
            Equipo eq = new Equipo(txbNombre.Text, short.Parse(cmbCategoria.SelectedValue.ToString()), listaEstudiantes);
            try
            {
                if (txbNombre.Text != "")
                {
                    File.Copy(pathFoto, Config.pathFotoEquipo + equipoImpl.LastIndex("Equipo") + ".jpg");
                    equipoImpl.Insert(eq);
                    MessageBox.Show("Equipo Registrado Con Exito");
                    volver();
                }
                else
                    MessageBox.Show("Llene el espacio de el nombre");
                
                
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        void volver()
        {
            gridMain.Children.Clear();
            UserControl usc = new ventanas.uscMenu(gridMain);
            gridMain.Children.Add(usc);
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            volver();
        }

        private void dgvEstudiantes_Loaded(object sender, RoutedEventArgs e)
        {
            Busqueda("");
        }

        void Busqueda(string cadena)
        {
            Estudiantes = Controladores.controladorEstudiante.SelectEstudianteHabilidad(cadena);
            dgvEstudiantes.ItemsSource = Estudiantes.DefaultView;
            dgvEstudiantes.Columns[1].Visibility = Visibility.Collapsed;
        }
    }
}
