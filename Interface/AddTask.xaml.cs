using TaskTimeEntry;
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

namespace Interface
{
    /// <summary>
    /// Interaction logic for AddTask.xaml
    /// </summary>
    public partial class AddTask : Window
    {
        TaskTimeEntry.Task newTask;
        Client client;
        Project project;

        public AddTask(Client client, Project project)
        {
            InitializeComponent();
            this.client = client;
            this.project = project;
            newTask = new TaskTimeEntry.Task(project.clientID, project._id);
            TaskNameInput.DataContext = newTask;
            ProjectName.DataContext = project;
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            newTask.timeRemaining = float.Parse(WorkHoursInput.Text);
            newTask.AddComment(CommentsInput.Text);
            ModelView.UpdateProject(client, project, newTask);
            MainMenu menu = new MainMenu();
            menu.Show();
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            EditProject editProject = new EditProject();
            editProject.Show();
            Close();
        }
    }
}
