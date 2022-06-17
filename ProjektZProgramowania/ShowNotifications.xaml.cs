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
    /// Logika interakcji dla klasy ShowNotifications.xaml
    /// </summary>
    public partial class ShowNotifications : Window
    {
        long userId;
        public ShowNotifications(long? id)
        {
            try
            {
                userId = (long)id;
            }
            catch (Exception ex)
            {
                throw new NullReferenceException();
            }
            InitializeComponent();
        }
        public ShowNotifications()
        {
            InitializeComponent();
        }
    }
}
