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
            ChooseClient.DataContext = clients;
        }

        private void PTaddButton_Click(object sender, RoutedEventArgs e)
        {
            project.billableHoursSigned = Int32.Parse(PTbillableHoursTextBox.Text);
            project.AddComment(DateTime.Now, PTcommentTextbox.Text);
        }
    }
}
