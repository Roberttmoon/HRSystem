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
    /// Interaction logic for AddResourceToProject.xaml
    /// </summary>
    public partial class AddResourceToProject : Window
    {
        List<BillableAsset> resources;
        Project project;

        public AddResourceToProject(List<BillableAsset> resources, Project project)
        {
            InitializeComponent();
            this.project = project;
            this.resources = resources;
            DataContext = this;
            ProjectName.DataContext = project;
            ChooseResource.ItemsSource = resources;
        }

        private void AddResource_Click(object sender, RoutedEventArgs e)
        {
            BillableAsset resourceToAdd = (BillableAsset)ChooseResource.SelectedItem;
            ModelView.UpdateProjectWithAsset(project, resourceToAdd);
            MessageBox.Show("Success. Resource added to project.");
            EditProject editProject = new EditProject();
            editProject.Show();
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
