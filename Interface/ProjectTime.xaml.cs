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
        public string clientName { get; private set; }
        public string projectName { get; private set; }
        public int billableHours { get; private set; }
        public string comment { get; private set; }

        public ProjectTime()
        {
            InitializeComponent();
        }

        private void PTaddButton_Click(object sender, RoutedEventArgs e)
        {
            Project newProj = new Project();
            newProj.projectName = PTprojectNameTextBox.Text;
            int numOfBillHours = Int32.Parse(PTbillableHoursTextBox.Text);
            newProj.billableHoursSigned = numOfBillHours;
            comment = PTcommentTextbox.Text;
        }

        //private void PTbillableHoursTextBox_TextChanged(object sender, TextCompositionEventArgs e)
        //{
        //    {
        //        Regex regex = new Regex("[^0-9]+");
        //        e.Handled = regex.IsMatch(e.Text);
        //    }
        //}
    }
}
