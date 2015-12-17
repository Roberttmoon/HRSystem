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
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        List<TaskTimeEntry.Task> tasks;
        public ReportWindow()
        {
            InitializeComponent();
            tasks = ModelView.GetAllTasks();
            DataContext = this;
            TaskList.ItemsSource = tasks;
        }

        private void TaskReport_Click(object sender, RoutedEventArgs e)
        {
            TaskTimeEntry.Task task = (TaskTimeEntry.Task)TaskList.SelectedItem;
            TaskReport taskReport = new TaskReport(task);
            taskReport.Show();
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            AdminPannel admin = new AdminPannel();
            admin.Show();
            Close();
        }
    }
}
