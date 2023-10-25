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
            Window window = Window.GetWindow(this);
            window.Content = new HomePage();
        }
    }
}
