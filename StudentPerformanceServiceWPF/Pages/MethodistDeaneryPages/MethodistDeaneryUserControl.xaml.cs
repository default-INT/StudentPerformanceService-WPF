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

namespace StudentPerformanceServiceWPF.Pages.MethodistDeaneryPages
{
    /// <summary>
    /// Логика взаимодействия для MethodistDeaneryUserControl.xaml
    /// </summary>
    public partial class MethodistDeaneryUserControl : UserControl
    {
        private readonly ElementManager elementManager;
        public MethodistDeaneryUserControl()
        {
            InitializeComponent();

            elementManager = ElementManager.Instance;

            addTestButton.Click += (s, e) => elementManager.SetContent(new AddTestUserControl());
            certifyStudentButton.Click += (s, e) => elementManager.SetContent(new CertifyUserControl());
        }
    }
}
