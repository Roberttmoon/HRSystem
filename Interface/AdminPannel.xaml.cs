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

namespace Interface
{
    /// <summary>
    /// Interaction logic for AdminPannel.xaml
    /// </summary>
    public partial class AdminPannel : Window
    {
        private TaskTimeEntry.Task task;

        public AdminPannel()
        {
            InitializeComponent();
        }

        private void WorkOnProject_Click(object sender, RoutedEventArgs e)
        {
            TaskTime taskTime = new TaskTime(task);
            
        }
        private void AddATask_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddAProject_Click(object sender, RoutedEventArgs e)
        {
            ProjectTime projectTime = new ProjectTime();
            projectTime.Show();
            Close();
        }
        private void AddUsers_Click(object sender, RoutedEventArgs e)
        {
            EnterResource addUser = new EnterResource();
            addUser.Show();
            Close();
        }

        private void EditProject_Click(object sender, RoutedEventArgs e)
        {
            EditProject editProject = new EditProject();
            editProject.Show();
            Close();
        }
    }
}
