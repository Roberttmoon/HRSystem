﻿using System;
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
    /// Interaction logic for ThankyouPopup.xaml
    /// </summary>
    public partial class ThankyouPopup : Window
    {
        public ThankyouPopup()
        {
            InitializeComponent();
        }

        private void ThankYouButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
