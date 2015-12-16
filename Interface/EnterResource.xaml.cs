﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
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

namespace Interface
{
    public partial class EnterResource : Window
    {
        public string name { get; private set; }
        public string email { get; private set; }

        public EnterResource()
        {
            InitializeComponent();
            Master.DataContext = this;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string password = PasswordInput.Password;
            BillableAsset asset = new BillableAsset(name, email);
            ModelView.AddCredentialsToDatabase(asset, password);
            ModelView.AddAssetToDatabase(asset);
        }
    }
}
