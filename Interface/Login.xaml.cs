using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskTimeEntry;
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
    public partial class Login : Window
    {
        public string email { get; set; }
        public string password { get; set; }

        public Login()
        {
            InitializeComponent();
            Master.DataContext = this;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Add Message Box for "Are you sure?"
            this.Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (ModelView.CheckCredentials(email, password))
            {
                BillableAsset asset = ModelView.GetAsset(email);
                Application.Current.Resources["asset"] = asset;
                ChooseTask nextWindow = new ChooseTask();
                nextWindow.Show();
                this.Close();
            } else
            {
                // Show Incorrect Login Info Window
            }
        }
    }
}
