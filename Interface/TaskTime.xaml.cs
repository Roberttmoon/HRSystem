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
using TaskTimeEntry;
using System.Text.RegularExpressions;

namespace Interface
{
    /// <summary>
    /// Interaction logic for TaskTime.xaml
    /// </summary>
    public partial class TaskTime : Window
    {
        public TaskTime()
        {
            InitializeComponent();
        }

        public int Save_Click(object sender, RoutedEventArgs e)
        {
            int hoursLogged = int.Parse(LogBox.Text);
            throw new NotImplementedException();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Close();
        }
    }
}
