﻿using TaskTimeEntry;
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
    /// Interaction logic for EditProject.xaml
    /// </summary>
    public partial class EditProject : Window
    {
        List<Project> projects;
        List<BillableAsset> assets;

        public EditProject()
        {
            InitializeComponent();
            projects = ModelView.GetAllProjects();
            assets = ModelView.GetAllAssets();
            DataContext = this;
            ChooseProject.ItemsSource = projects;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            AdminPanel admin = new AdminPanel();
            admin.Show();
            Close();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            Project project = (Project)ChooseProject.SelectedItem;
            Client client = ModelView.GetClient(project.clientID);
            AddTask addTask = new AddTask(client, project);
            addTask.Show();
            Close();
        }

        private void AddResource_Click(object sender, RoutedEventArgs e)
        {
            AddResourceToProject addResource = new AddResourceToProject(assets, (Project)ChooseProject.SelectedItem);
            addResource.Show();
            Close();
        }
    }
}
