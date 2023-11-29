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
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        public Dashboard()
        {
            InitializeComponent();
            ShowBaby();
        }

        public void ShowBaby()
        {
            User user = UserContext.LoggedInUser;
            Baby baby = new Baby();
            try
            {
                baby.GetBaby(user);
                lblName.Content = baby.Username.ToString();
                lblAge.Content = baby.Age.ToString();
                lblHeight.Content = baby.Height.ToString();
                lblWeight.Content = baby.Weight.ToString();
                lblSleepTime.Content = baby.SleepTime.ToString();
            }
            catch (Exception ex)
            {

            }
        } 
    }
}
