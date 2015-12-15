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
namespace Interface
{
    /// <summary>
    /// Interaction logic for ProjectTime.xaml
    /// </summary>
    public partial class ProjectTime : Window
    {
        public string clientName { get; private set; }
        public string projectName { get; private set; }
        public string billableHours { get; private set; }
        public string comment { get; private set; }

        public ProjectTime()
        {
            InitializeComponent();
        }

        private void PTaddButton_Click(object sender, RoutedEventArgs e)
        {
            Project newProj = new Project();
            MongoAccessLayer mongo = new MongoAccessLayer("Main", "Credential");
            newProj.clientName = PTclientNameTextBox.Text;
            projectName = PTprojectNameTextBox.Text;
            billableHours = PTbillableHoursTextBox.Text;
            comment = PTcommentTextbox.Text;
            ProjectTime input = Serializer<Project>.SerializeToJson(clientName, projectName, billableHours, comment);
            string json = Serializer<string, string>>.SerializeToJson(input);
            mongo.AddDocument(json);
            ProjectTime nextWindow = new ProjectTime();
            nextWindow.Show();
            this.Close();
        }
    }
}
