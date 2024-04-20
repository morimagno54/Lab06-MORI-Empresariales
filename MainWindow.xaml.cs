using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Actualizar actualizar = new Actualizar();

        Listado listado = new Listado();

        Eliminar eliminar = new Eliminar();

        string connectionString = "Data Source=LAB1504-01\\SQLEXPRESS;Initial Catalog=Neptuno;User Id = user01;Password=12345678";

        private void btn1Click(object sender, RoutedEventArgs e)
        {
                listado.Show();

            List<Cliente> clientes = new List<Cliente>();
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("EXEC PA_ListarClientes", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string idCliente = reader.GetString("idCliente");
                    string NombreCompania = reader.GetString("NombreCompañia");
                    string Ciudad = reader.GetString("Ciudad");
                    string Pais = reader.GetString("Pais");
                    clientes.Add(new Cliente { idCliente = idCliente, NombreCompania = NombreCompania, Ciudad = Ciudad, Pais = Pais });
                }

                listado.dataGrid1.ItemsSource = clientes;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn2Click(object sender, RoutedEventArgs e)
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString)) 
            { 
                connection.Open();

                using (SqlCommand command = new SqlCommand("PA_InsertarCliente", connection))
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

        private void btn3Click(object sender, RoutedEventArgs e)
        {
            actualizar.Show();
        }

        private void btn4Click(object sender, RoutedEventArgs e)
        {
            eliminar.Show();
        }
    }
}