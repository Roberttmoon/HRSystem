using System;
using System.Collections.Generic;
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

namespace Interface
{
    /// <summary>
    /// Interaction logic for EnterResource.xaml
    /// </summary>
    public partial class EnterResource : Window
    {
        public EnterResource()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            BillableAsset newAsset = new BillableAsset();
            newAsset = newAsset.CreateAsset(this.Name.Text, this.EMail.Text);

        }
    }
}
