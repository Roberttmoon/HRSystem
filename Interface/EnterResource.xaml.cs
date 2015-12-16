using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
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
using DataAccess;

namespace Interface
{
    public partial class EnterResource : Window
    {
        public string name { get; set; }
        public string email { get; set; }

        public EnterResource()
        {
            InitializeComponent();
            Master.DataContext = this;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string password = PasswordInput.Password;
            if ((bool)assetRadio.IsChecked)
            {
                
                BillableAsset asset = new BillableAsset(name, email);
                asset.privilege = false;
                try {
                    ModelView.AddCredentialsToDatabase(asset, password);
                    ModelView.AddAssetToDatabase(asset);
                    EnterResource nextWindow = new EnterResource();
                    nextWindow.Show();
                    Close();
                }
                catch { MessageBox.Show("User already exists"); }
             
            } else if ((bool)clientRadio.IsChecked)
            {
                Client client = new Client(name, email, 0f);
                try {
                    ModelView.AddCredentialsToDatabase(client, password);
                    ModelView.AddClientToDatabase(client);
                    EnterResource nextWindow = new EnterResource();
                    nextWindow.Show();
                    Close(); }
                catch { MessageBox.Show("Client already exists"); }
            }else if ((bool)adminRadio.IsChecked) {
                BillableAsset asset = new BillableAsset(name, email);
                asset.privilege = true;
                try {
                    ModelView.AddCredentialsToDatabase(asset, password);
                    ModelView.AddAssetToDatabase(asset);
                    EnterResource nextWindow = new EnterResource();
                    nextWindow.Show();
                    Close();
                }catch { MessageBox.Show("User already exists"); }
            } else
            {
                MessageBox.Show("Please select a privilege level");
            }
       }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            AdminPannel admin = new AdminPannel();
            admin.Show();
            this.Close();
            
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            NameInput.Text = String.Empty;
            PasswordInput.Clear();
            EmailInput.Text = String.Empty;
         }
    }
}
