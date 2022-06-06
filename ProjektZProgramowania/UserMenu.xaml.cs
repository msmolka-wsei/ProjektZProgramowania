﻿using System;
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
    /// Logika interakcji dla klasy UserMenu.xaml
    /// </summary>
    public partial class UserMenu : Window
    {
        public UserMenu()
        {
            InitializeComponent();
        }

        private void CreateNotification_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            this.Close();
        }
    }
}
