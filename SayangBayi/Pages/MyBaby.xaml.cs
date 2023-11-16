using SayangBayi.Classes;
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

namespace SayangBayi.Pages
{
    /// <summary>
    /// Interaction logic for MyBaby.xaml
    /// </summary>
    public partial class MyBaby : Page
    {
        public MyBaby()
        {
            InitializeComponent();
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Content = new HomePage();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            //check textbox if empty
            bool anyEmpty = false;
            foreach (var textBox in new[] { tbBabyName, tbAge, tbHeight, tbWeight, tbSleepTime })
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

            try
            {
                Baby baby = new Baby();
                // Populate the Baby object with textbox values
                baby.Username = tbBabyName.Text;
                baby.Age = int.Parse(tbAge.Text);
                baby.Height = double.Parse(tbHeight.Text); 
                baby.Weight = double.Parse(tbWeight.Text); 
                baby.SleepTime = double.Parse(tbSleepTime.Text); 

                baby.UpdateBaby();

                MessageBox.Show("Update successful");
                Window window = Window.GetWindow(this);
                window.Content = new Dashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Update failed: {ex.Message}");
            }
        }
    }
}
