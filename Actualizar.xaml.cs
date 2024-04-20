using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace Lab05
{
    /// <summary>
    /// Lógica de interacción para Actualizar.xaml
    /// </summary>
    public partial class Actualizar : Window
    {
        public Actualizar()
        {
            InitializeComponent();
        }

        string connectionString = "Data Source=LAB1504-01\\SQLEXPRESS;Initial Catalog=Neptuno;User Id = user01;Password=12345678";
        private void btn1Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("PA_ActualizarCliente", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", tb_idCLiente.Text);
                    command.Parameters.AddWithValue("@nombrecompania", tb_NombreCompania.Text);
                    command.Parameters.AddWithValue("@nombrecontacto", tb_NombreContacto.Text);
                    command.Parameters.AddWithValue("@cargocontacto", tb_CargoContacto.Text);
                    command.Parameters.AddWithValue("@direccion", tb_Direccion.Text);
                    command.Parameters.AddWithValue("@ciudad", tb_Ciudad.Text);
                    command.Parameters.AddWithValue("@region", tb_Region.Text);
                    command.Parameters.AddWithValue("@codpostal", tb_CodPostal.Text);
                    command.Parameters.AddWithValue("@pais", tb_Pais.Text);
                    command.Parameters.AddWithValue("@telefono", tb_Telefono.Text);
                    command.Parameters.AddWithValue("@fax", tb_Fax.Text);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
