﻿using Npgsql;
using SayangBayi.Classes;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SayangBayi.Pages
{
    /// <summary>
    /// Interaction logic for Meal.xaml
    /// </summary>
    public partial class Meal : Page
    {
        public Meal()
        {
            InitializeComponent();
            populateDataGrid();
        }

        private void populateDataGrid()
        {
            DbConnection connection = new DbConnection();



            try
            {
                connection.OpenConnection();

                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM meal", connection.GetConnection()))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();

                        // Load the reader into the DataTable
                        dataTable.Load(reader);

                        // Assuming DGArticle is the name of your DataGrid
                        DGMeal.ItemsSource = dataTable.DefaultView;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.CloseConnection();
            }
        }
    }
}
