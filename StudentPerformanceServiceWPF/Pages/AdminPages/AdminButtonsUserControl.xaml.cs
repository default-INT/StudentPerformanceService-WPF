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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentPerformanceServiceWPF.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для AdminButtonsUserControl.xaml
    /// </summary>
    public partial class AdminButtonsUserControl : UserControl
    {
        private readonly ElementManager elementManager;
        public AdminButtonsUserControl()
        {
            InitializeComponent();

            elementManager = ElementManager.Instance;
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            elementManager.SetContent(new AddUserUserControl());
        }

        private void SessionAddButton_Click(object sender, RoutedEventArgs e)
        {
            elementManager.SetContent(new AddSessionUserControl());
        }
    }
}
