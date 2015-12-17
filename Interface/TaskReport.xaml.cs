using TaskTimeEntry;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for TaskReport.xaml
    /// </summary>
    public partial class TaskReport : Window
    {
        public TaskReport(TaskTimeEntry.Task task)
        {
            Report<object> report = ModelView.CreateTaskReport(task);
            TaskStrings ts = new TaskStrings(task);
            DataContext = ts;
            InitializeComponent();
            TaskLog.DataContext = report;
            foreach (object item in report)
            {
                if (item.GetType() == typeof(Dictionary<string, float>))
                {
                    TaskLog.ItemsSource = (Dictionary<string, float>)item;
                }
            }
        }
    }
}
