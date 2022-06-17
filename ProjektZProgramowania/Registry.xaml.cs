using Microsoft.AspNetCore.Identity;
using ProjektZProgramowania.Data;
using ProjektZProgramowania.Enities;
using ProjektZProgramowania.Services;
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
using System.Windows.Shapes;

namespace ProjektZProgramowania
{
    /// <summary>
    /// Logika interakcji dla klasy Registry.xaml
    /// </summary>
    public partial class Registry : Window
    {
        //private readonly UserManager<ApplicationUser> _userManager;
        public Registry()    //UserManager<ApplicationUser> userManager
        {
          //  _userManager = userManager;
            InitializeComponent();
        }

        private void BackToLogInClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow(); //_userManager
            mainWindow.Show();
            this.Close();
        }



        private void RegistryButton_Click(object sender, RoutedEventArgs e)
        {
            if (registryFirstName.Text.Length == 0 || registryLastName.Text.Length == 0 || registryEmail.Text.Length == 0 || registryAddress.Text.Length == 0)
            {
                string messageBoxText = "Introduced incorrect data.";
                string caption = "Warning";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
            else
            {
                IDataService<User> userService = new GenericDataService<User>(new ApplicationDbContextFactory());
                User user = new User() { firstName = registryFirstName.Text, lastName = registryLastName.Text, email = registryEmail.Text, address = registryAddress.Text, password = registryPassword.Text};
                userService.Create(user).Wait();
                
                string messageBoxText = "Welcome.";
                string caption = "Welcome";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
        }

    }
}
