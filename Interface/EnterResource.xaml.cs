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
            MongoAccessLayer mongo = new MongoAccessLayer("Main", "Credential");
            email = EmailInput.Text;
            password = PasswordInput.Password;
            Dictionary<string, string> input = Serializer<string>.CreateDictionary(email, password);
            string json = Serializer<Dictionary<string, string>>.SerializeToJson(input);
            Trace.WriteLine(json);
            mongo.AddDocument(json);
            // ModelView.AddCredentialsToFile(email, password);
            EnterResource nextWindow = new EnterResource();
            nextWindow.Show();
            this.Close();
        }
    }
}
