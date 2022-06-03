using Microsoft.AspNetCore.Identity;
using ProjektZProgramowania.Enities;
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

namespace ProjektZProgramowania
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       // private readonly UserManager<ApplicationUser> _userManager;
        public MainWindow() //UserManager<ApplicationUser> userManager
        {
           // _userManager = userManager;
            InitializeComponent();
        }

        public void email_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public void RegisterClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Registry registry = new Registry(); //_userManager
            registry.Show();
            
            this.Close();
        }
    }
}
