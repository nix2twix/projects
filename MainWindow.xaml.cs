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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MCApp
{
    public partial class MainWindow : Window
    {
        private SqlConnection sqlConnection = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseKey"].ConnectionString);
            
            sqlConnection.Open();
        }

        private void ButtonInsertNewService_Click(object sender, RoutedEventArgs e)
        {
            string name = serviceNameTextBox.Text;
            string minCount = minCountTextBox.Text;
            string maxCount = maxCountTextBox.Text;
            string measure = measureTextBox.Text;
            int idMC = int.Parse(idMCTextBox.Text);

            SqlCommand command = new SqlCommand("INSERT INTO Services (name, minCount, maxCount, measure, idMC)" 
                + $"VALUES (N'{name}', N'{minCount}', N'{maxCount}', N'{measure}', '{idMC}')", sqlConnection);

            MessageBox.Show(command.ExecuteNonQuery().ToString() + " lines has been executed successfully!");
        }

        private void DeleteServiceByID_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(serviceIDToDelTextBox.Text);

            SqlCommand command = new SqlCommand("DELETE FROM Services"
                + $"WHERE id={id}", sqlConnection);

            MessageBox.Show(command.ExecuteNonQuery().ToString() + " lines has been executed successfully!");
        }

        private void ChangeServiceID_Click(object sender, RoutedEventArgs e)
        {
            string name = serviceNameTextBox.Text;
            string minCount = minCountTextBox.Text;
            string maxCount = maxCountTextBox.Text;
            string measure = measureTextBox.Text;
            int idMC = int.Parse(idMCTextBox.Text);

            SqlCommand command = new SqlCommand("UPDATE Services"
                + $"SET (N'{name}', N'{minCount}', N'{maxCount}', N'{measure}', '{idMC}')", sqlConnection);

            MessageBox.Show(command.ExecuteNonQuery().ToString() + " lines has been executed successfully!");

        }
    }
}
