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
using Npgsql;
using System.Data;

namespace SayangBayi
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            conn = new NpgsqlConnection(connstring);
        }

        private NpgsqlConnection conn;
        string connstring = "Host=localhost;Port=5432;Username=postgres;Password=gajah;Database=sayangbayi";
        public static NpgsqlCommand cmd;
        private string sql = null;

        private bool Verify(string username, string password)
        {
            try 
            {
                conn.Open();
                sql = $"SELECT * FROM users WHERE username='{username}' AND user_pass='{password}'";
                cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader rd = cmd.ExecuteReader();

                bool found = false;
                found = rd.HasRows;

                rd.Close();
                conn.Close();

                return found;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
                return false;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new RegisterPage();
        }

        private void BtnRegHere_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new RegisterPage();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTBox.Text;
            string password = passwordTBox.Text;
            if (Verify(username, password))
            {
                Window window = Window.GetWindow(this);
                window.Content = new HomePage();
            }
            else { MessageBox.Show("Incorrect Username or Password"); }

            //klo mau skip login funct
            //Window window = Window.GetWindow(this);
            //window.Content = new HomePage();
        }

    }
}