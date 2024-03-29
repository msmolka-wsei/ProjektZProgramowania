﻿using Microsoft.AspNetCore.Identity;
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

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            string emailTemp = email.Text;
            string passwordTemp = password.Text;

            IDataService<User> userService = new GenericDataService<User>(new ApplicationDbContextFactory());
            User user = userService.Get(emailTemp);
            
            if (user == null)
            {
                string messageBoxText = "There is no such user.";
                string caption = "Warning";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
            else
            {
                if (user.password == passwordTemp)
                {
                    this.Hide();
                    UserMenu userMenu = new UserMenu(user.id);
                    userMenu.Show();
                    this.Close();
                }
                else
                {
                    string messageBoxText = "Wrong password.";
                    string caption = "Warning";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxResult result;
                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                }
            }


        }

        private void password_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
