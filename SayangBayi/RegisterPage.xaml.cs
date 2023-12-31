﻿using Npgsql;
using SayangBayi.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace SayangBayi
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
            conn = new NpgsqlConnection(connstring);
        }

        private NpgsqlConnection conn;
        string connstring = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        public static NpgsqlCommand cmd;
        private string sql = null;

        private bool EmailCheck(string email)
        {
            try
            {
                conn.Open();
                sql = $"SELECT * FROM users WHERE email='{email}'";
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

        private void BtnLoginHere_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new LoginPage();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            //check textbox if empty
            bool anyEmpty = false;
            foreach (var textBox in new[] { emailTBox, usernameTBox, nameTBox, passwordTBox})
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    anyEmpty = true;
                    break; // Break the loop if any textbox is found empty
                }
            }

            if (anyEmpty)
            {
                MessageBox.Show("Please Fill Each Field");
                return;
            }

            if (EmailCheck(emailTBox.Text))
            {
                MessageBox.Show("email already used");
                return;
            }
            User user1 = new User(emailTBox.Text, usernameTBox.Text, nameTBox.Text, passwordTBox.Text);
            try
            {
                user1.Register();
                MessageBox.Show("Registration successful");
                Window window = Window.GetWindow(this);
                window.Content = new LoginPage();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Registration failed: {ex.Message}");
            }
            

            
        }
    }
}