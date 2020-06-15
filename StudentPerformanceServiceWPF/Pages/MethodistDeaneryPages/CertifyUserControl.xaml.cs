using StudentPerformanceServiceCL.Models.Data;
using StudentPerformanceServiceCL.Models.Entities.Accounts;
using StudentPerformanceServiceCL.Models.Entities.Tests;
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
    /// Логика взаимодействия для CertifyUserControl.xaml
    /// </summary>
    public partial class CertifyUserControl : UserControl
    {
        private Test selectedTest;
        public CertifyUserControl()
        {
            InitializeComponent();

            ElementManager.Instance.ChangeTitleText("Добавление аттестации студенту");

            LoadTest();
            testComboBox.SelectionChanged += (s, e) =>
            {
                var comboBox = (ComboBox)s;
                selectedTest = (Test)comboBox.SelectedItem;
                LoadStudents();
            };
        }

        private async void LoadTest()
        {
            IEnumerable<Test> tests = null;
            await Task.Run(() =>
            {
                var db = DAOFactory.GetDAOFactory();
                tests = db.TestDAO.Tests;
            });
            testComboBox.Items.Clear();
            foreach (var test in tests)
            {
                testComboBox.Items.Add(test);
            }
        }

        private async void LoadStudents()
        {
            IEnumerable<Student> students = null;
            await Task.Run(() => students = selectedTest.Group.Students
                .Where(s => s.TestResults.FirstOrDefault(t => t.TestId == selectedTest.Id) == null));
            await Task.Run(() =>
            {
                var db = DAOFactory.GetDAOFactory();
                var retakeStudents = db.TestDAO.TestResults
                    .Where(t => t.Retake)
                    .Select(t => t.Student);

                students = students.Concat(retakeStudents);
            });
            studentComboBox.Items.Clear();
            foreach (var student in students)
            {
                studentComboBox.Items.Add(student);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var student = (Student)studentComboBox.SelectedItem;
                var selectedDate = datePicker.SelectedDate.Value;
                var mark = int.Parse((string)((ComboBoxItem)markComboBox.SelectedItem).Content);

                var db = DAOFactory.GetDAOFactory();

                db.TestDAO.Add(new TestResult()
                {
                    TestId = selectedTest.Id,
                    StudentId = student.Id,
                    CompletionDate = selectedDate,
                    Mark = mark
                });

                msgLabel.Content = "Студент " + student.FullName + " успешно аттестован";
            }
            catch (Exception ex)
            {
                msgLabel.Content = ex.Message;
            }
        }
    }
}
