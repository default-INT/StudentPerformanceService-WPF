using StudentPerformanceServiceCL.Models.Entities.Accounts;
using StudentPerformanceServiceCL.Services;
using StudentPerformanceServiceWPF.Pages.AdminPages;
using StudentPerformanceServiceWPF.Pages.MethodistDeaneryPages;
using StudentPerformanceServiceWPF.Pages.StudentPages;
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

namespace StudentPerformanceServiceWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ElementManager elementManager;
        private readonly UserService userService;
        public MainWindow()
        {
            InitializeComponent();

            userService = UserService.Instance;
            elementManager = ElementManager.Instance;

            (new LogInWindow()).ShowDialog();

            elementManager = ElementManager.SetInstance(mainContent, menuButtonContent, titleLabel);

            SetButtonMenu();
        }

        private void SetButtonMenu()
        {
            try
            {
                var authUser = userService.Account;
                statusMenuItem.Header = authUser.Status;
                fullNameMenuItem.Header = authUser.FullName;
                elementManager.SetContent(new UserControl());

                if (authUser is Admin)
                {
                    elementManager.SetButtonMenu(new AdminButtonsUserControl());
                }
                else if (authUser is MethodistDeanery)
                {
                    elementManager.SetButtonMenu(new MethodistDeaneryUserControl());
                }
                else if (authUser is Student)
                {
                    elementManager.SetButtonMenu(new StudentUserControl());
                }
                else throw new Exception("User undefined");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            userService.LogOut();
            Hide();
            (new LogInWindow()).ShowDialog();
            Show();
            SetButtonMenu();
        }
    }
}
