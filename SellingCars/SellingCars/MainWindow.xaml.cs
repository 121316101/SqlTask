using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
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

namespace SellingCars
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

        private void UpdateStuff()
        {
            string conStringTest = "Server=DESKTOP-78M1CE8\\SQLEXPRESS; Database=SqlWorkingDB;Trusted_Connection=Yes;";

            string SqlQuery = @"INSERT INTO CarSellers VALUES ('Kelly', 'Reno', 4500)
                                INSERT INTO CarSellers VALUES ('Kelly', 'Volvo', 5555)
                                INSERT INTO CarSellers VALUES ('Kelly', 'Opel', 10000)
                                INSERT INTO CarSellers VALUES ('Kelly', 'Mazda', 9090)
                                BEGIN TRANSACTION MiddlePoint
                                INSERT INTO CarSellers VALUES ('Kelly', 'Reno', 4500)
                                INSERT INTO CarSellers VALUES ('Kelly', 'Volvo', 5555)
                                INSERT INTO CarSellers VALUES ('Kelly', 'Opel', 10000)
                                INSERT INTO CarSellers VALUES ('Kelly', 'Mazda', 9090)
                                BEGIN TRANSACTION LastPoint
                                INSERT INTO CarSellers VALUES ('Kelly', 'Reno', 4500)
                                INSERT INTO CarSellers VALUES ('Kelly', 'Volvo', 5555)
                                INSERT INTO CarSellers VALUES ('Kelly', 'Opel', 10000)
                                INSERT INTO CarSellers VALUES ('Kelly', 'Mazda', 9090)";

            SqlConnection sqlConnection = new SqlConnection(conStringTest);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = SqlQuery;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            UpdateStuff();
            MessageBox.Show("Data Base updated!");
        }
    }
} 