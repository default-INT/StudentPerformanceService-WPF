using StudentPerformanceServiceCL.Models.Data;
using StudentPerformanceServiceCL.Models.Entities;
using StudentPerformanceServiceCL.Models.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Group = StudentPerformanceServiceCL.Models.Entities.Group;

namespace StudentPerformanceServiceWPF.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для AddUserUserControl.xaml
    /// </summary>
    public partial class AddUserUserControl : UserControl
    {          
        private const string PatternLogin = "[A-z0-9]{4,12}";
        private const string PatternPassword = "[A-z0-9]{4,12}";
        private const string PatternFullName = "[А-я\\s]{4,20}";

        public AddUserUserControl()
        {
            InitializeComponent();

            ElementManager.Instance.ChangeTitleText("Добавление пользователя");

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!ValidationData()) throw new Exception("Введённые данные имеют неверный формат!");
                var login = loginTextBox.Text;
                var password = passwordTextBox.Password == passwordRetryTextBox.Password ? passwordTextBox.Password
                    : throw new Exception("Пароли не совпадают!");
                var fullName = fullNameTextBox.Text;

                var db = DAOFactory.GetDAOFactory();
                switch (roleComboBox.SelectedIndex)
                {
                    case 0:
                        var faculty = (Faculty)facultyGroupComboBox.SelectedItem;
                        db.AccountDAO.Add(new MethodistDeanery()
                        {
                            Login = login,
                            Password = password,
                            FullName = fullName,
                            FacultyId = faculty.Id
                        });
                        break;
                    case 1:
                        var group = (Group)facultyGroupComboBox.SelectedItem;
                        db.AccountDAO.Add(new Student()
                        {
                            Login = login,
                            Password = password,
                            FullName = fullName,
                            GroupId = group.Id
                        });
                        break;
                    default:
                        throw new Exception("Выбран несуществующий тип аккаунта!");
                }
                loginTextBox.Text = string.Empty;
                passwordTextBox.Password = string.Empty;
                passwordRetryTextBox.Password = string.Empty;
                fullNameTextBox.Text = string.Empty;

                msgLabel.Content = "Пользователь успешно добавлен в систему";
            }
            catch (Exception ex)
            {
                msgLabel.Content = ex.Message;
            }
        }

        private bool ValidationData() => Regex.IsMatch(loginTextBox.Text, PatternLogin)
            && Regex.IsMatch(passwordTextBox.Password, PatternPassword)
            && Regex.IsMatch(fullNameTextBox.Text, PatternFullName);

        private async void RoleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ComboBox comboBox = (ComboBox)sender;
                IEnumerable<Entity> entities = null;
                switch (comboBox.SelectedIndex)
                {
                    case 0:
                        await Task.Run(() =>
                        {
                            var db = DAOFactory.GetDAOFactory();
                            entities = db.FacultyDAO.Faculties;
                        });
                        break;
                    case 1:
                        await Task.Run(() =>
                        {
                            var db = DAOFactory.GetDAOFactory();
                            entities = db.GroupDAO.Groups;
                        });
                        break;
                    default:
                        throw new Exception("Не удалось загрузить данные....");
                }

                facultyGroupComboBox.Items.Clear();
                foreach (var entity in entities)
                {
                    facultyGroupComboBox.Items.Add(entity);
                }
            }
            catch (Exception ex)
            {
                msgLabel.Content = ex.Message;
            }
        }
    }
}
