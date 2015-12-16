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
using DataAccess;
using System.Text.RegularExpressions;


namespace Interface 
{
    /// <summary>
    /// Interaction logic for ProjectTime.xaml
    /// </summary>
    public partial class ProjectTime : Window
    {
        public List<Client> clients = ModelView.GetAllClients();
        public Project project = new Project();

        public ProjectTime()
        {
            InitializeComponent();
            DataContext = project;
            ChooseClient.DataContext = this;
            ChooseClient.ItemsSource = clients;
        }

        private void PTaddButton_Click(object sender, RoutedEventArgs e)
        {
            project.billableHoursSigned = Int32.Parse(PTbillableHoursTextBox.Text);
            project.AddComment(PTcommentTextbox.Text);
            Client client = (Client)ChooseClient.SelectedItem;
            project.clientID = client._id;
            client.AddProject(project);
            ModelView.ReplaceClient(client);
            MessageBox.Show("Success. Project added to client.");
        }

        private void PTclearButton_Click(object sender, RoutedEventArgs e)
        {
            PTprojectNameTextBox.Text = String.Empty;
            PTprojectNameTextBox.Text = String.Empty;
            PTbillableHoursTextBox.Text = String.Empty;
        }
    }
}
