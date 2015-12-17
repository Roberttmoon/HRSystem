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
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public List<Client> clients = ModelView.GetAllClients();
        public Project project = new Project();
        public Report report = new Report();
        public ReportWindow()
        {
            InitializeComponent();
           
    }
    }
}
