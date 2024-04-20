using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Lab05
{
    /// <summary>
    /// Lógica de interacción para Listado.xaml
    /// </summary>
    public partial class Listado : Window
    {
        public Listado()
        {
            InitializeComponent();
        }

        private void btnActualizar_click(object sender, RoutedEventArgs e)
        {
            dataGrid1.ItemsSource = null;
        }

        void b1SendData(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Focused");
        }
    }
}
