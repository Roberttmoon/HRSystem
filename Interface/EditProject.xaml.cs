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
        Company company;
        List<Project> projects;
        public EditProject()
        {
            InitializeComponent();
            company = new Company();
            projects = company.GetAllProjects();
            DataContext = this;
            ChooseProject.ItemsSource = projects;
        }

    }
}
