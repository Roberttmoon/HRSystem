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
using System.Text.RegularExpressions;

namespace Interface
{
    /// <summary>
    /// Interaction logic for TaskTime.xaml
    /// </summary>
    public partial class TaskTime : Window
    {       
        public TaskTimeEntry.Task task;

        public TaskTime(TaskTimeEntry.Task task)
        {
            InitializeComponent();
            this.task = task;
            DataContext = task;

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            task.AddComment(CommentBox.Text);            
            float hoursLogged = float.Parse(LogBox.Text);
            task.AddHours(hoursLogged);

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            ChooseTask chooseTask = new ChooseTask();
            chooseTask.Show();
            this.Close();
        }

        private void TaskBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TaskBox.Text = task.taskName;
        }
    }
}
