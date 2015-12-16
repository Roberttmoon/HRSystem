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

namespace Interface
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void EmployeeLogin_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void ClientLogin_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void HRLogin_Click(object sender, RoutedEventArgs e)
        {
            EnterResource enterResource = new EnterResource();
            enterResource.Show();
            this.Close();
        }

        private void ManagerLogin_Click(object sender, RoutedEventArgs e)
        {
            ProjectTime projectTime = new ProjectTime();
            projectTime.Show();
            this.Close();
        }
    }
}
