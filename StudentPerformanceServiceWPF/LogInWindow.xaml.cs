using StudentPerformanceServiceCL.Models.Data;
using StudentPerformanceServiceCL.Models.Entities.Accounts;
using StudentPerformanceServiceCL.Services;
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

namespace StudentPerformanceServiceWPF
{
    /// <summary>
    /// Логика взаимодействия для LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        public LogInWindow()
        {
            InitializeComponent();
        }

        private async void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                msgLable.Content = "Идёт получение данных...";
                var login = loginTextBox.Text;
                var password = passwordTextBox.Password;
                Account user = null;

                await Task.Run(() => 
                {
                    var db = DAOFactory.GetDAOFactory();

                    user = db.AccountDAO.LogIn(login, password);
                });

                if (user == null) throw new Exception("Неверный логин или пароль");
                var userService = UserService.Instance;
                userService.Account = user;

                loginTextBox.Text = string.Empty;
                passwordTextBox.Password = string.Empty;

                msgLable.Content = "Добро пожаловать, " + user.FullName;
                Close();
            }
            catch (Exception ex)
            {
                msgLable.Content = ex.Message;
            }
        }
    }
}
