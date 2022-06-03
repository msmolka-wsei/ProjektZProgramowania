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
            IDataService<User> userService = new GenericDataService<User>(new ApplicationDbContextFactory());
            User user = new User() { firstName = registryFirstName.Text, lastName = registryLastName.Text, email = registryEmail.Text, address = registryAddress.Text };
            userService.Create(user).Wait();

           // ApplicationUser applicationUser = new ApplicationUser { Email = registryEmail.Text, UserName = registryEmail.Text, UserId = user.id};

            //_userManager.CreateAsync(applicationUser, registryPassword.Text);
        }

    }
}
