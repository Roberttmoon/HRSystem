using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Interaction logic for EnterResource.xaml
    /// </summary>
    public partial class EnterResource : Window
    {
        public string name { get; private set; }
        public string email { get; private set; }
        private string password;

        public EnterResource()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            name = NameInput.Text;
            email = EmailInput.Text;
            password = PasswordInput.Password;
            BillableAsset asset = new BillableAsset(name, email);
            Dictionary<string, string> credentials = Serializer<string>.CreateDictionary(email, password);

        }
    }
}
