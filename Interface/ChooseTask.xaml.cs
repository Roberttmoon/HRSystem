using DataAccess;
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
    public partial class ChooseTask : Window
    {
        public BillableAsset resource { get; private set; }

        public ChooseTask()
        {
            InitializeComponent();
            resource = (BillableAsset)Application.Current.FindResource("BillableAsset");
            Master.DataContext = resource;
            ChooseProjectBox.ItemsSource = resource.projects;                           
        }
           
        private void ChooseProjectBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Project project = (Project)ChooseProjectBox.SelectedItem;
            ChooseTaskBox.ItemsSource = project.tasks;
        }
    }
}
