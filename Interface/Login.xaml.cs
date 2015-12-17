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
using System.Security;

namespace Interface
{
    public partial class Login : Window
    {
        public string email { get; set; }
        //public string password;

        public Login()
        {
            InitializeComponent();
            Master.DataContext = this;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
                Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string password = PasswordInput.Password;
                if (ModelView.CheckCredentials(email, password))
                {
                    try
                    {
                        BillableAsset asset = ModelView.GetAsset(email);
                        Application.Current.Resources["asset"] = asset;
                        if (asset.privilege == false) {
                            ChooseTask chooseTask = new ChooseTask();
                            chooseTask.Show();
                            Close();
                        }
                        else if (asset.privilege) {
                            AdminPannel admin = new AdminPannel();
                            admin.Show();
                            Close();
                        }
                    }catch{
                        Client client = ModelView.GetClient(email);
                        ThankyouPopup popup = new ThankyouPopup();
                        popup.ShowDialog();
                    }
                }
            }
            catch
            {
                LoginPopUp popup = new LoginPopUp();
                popup.ShowDialog();
                EmailInput.Text = String.Empty;
                PasswordInput.Clear();
                
            }
        }
    }
}
