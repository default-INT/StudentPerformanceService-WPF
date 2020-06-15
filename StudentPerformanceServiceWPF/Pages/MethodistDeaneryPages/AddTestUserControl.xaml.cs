using StudentPerformanceServiceCL.Models.Data;
using StudentPerformanceServiceCL.Models.Entities;
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
    /// Логика взаимодействия для AddTestUserControl.xaml
    /// </summary>
    public partial class AddTestUserControl : UserControl
    {
        private Subject selectetSubject;
        public AddTestUserControl()
        {
            InitializeComponent();

            ElementManager.Instance.ChangeTitleText("Добавление испытания");

            LoadSubject();
            LoadSession();

            subjectComboBox.SelectionChanged += (s, e) =>
            {
                var comboBox = (ComboBox)s;
                selectetSubject = (Subject)comboBox.SelectedItem;
                LoadGroups();
            };
        }

        private async void LoadSubject()
        {
            IEnumerable<Subject> subjects = null;
            await Task.Run(() =>
            {
                var db = DAOFactory.GetDAOFactory();
                subjects = db.SubjectDAO.Subjects;
            });
            subjectComboBox.Items.Clear();
            foreach (var subject in subjects)
            {
                subjectComboBox.Items.Add(subject);
            }
        }

        private async void LoadGroups()
        {
            IEnumerable<Group> groups = null;
            await Task.Run(() => groups = selectetSubject.Groups);
            groupComboBox.Items.Clear();
            foreach (var group in groups)
            {
                groupComboBox.Items.Add(group);
            }
        }

        private async void LoadSession()
        {
            IEnumerable<Session> sessions = null;
            await Task.Run(() =>
            {
                var db = DAOFactory.GetDAOFactory();
                sessions = db.SessionDAO.Sessions;
            });
            sessionComboBox.Items.Clear();
            foreach (var session in sessions)
            {
                sessionComboBox.Items.Add(session);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedDate = datePicker.SelectedDate.Value;
                var group = (Group)groupComboBox.SelectedItem;
                var session = (Session)sessionComboBox.SelectedItem;
                var semester = group.Semester;

                var db = DAOFactory.GetDAOFactory();

                switch (testTypeComboBox.SelectedIndex)
                {
                    case 0:
                        db.TestDAO.Add(new OffsetTest()
                        {
                            Date = selectedDate,
                            SubjectId = selectetSubject.Id,
                            GroupId = group.Id,
                            Semester = semester,
                            SessionId = session.Id
                        });
                        break;
                    case 1:
                        db.TestDAO.Add(new ExamTest()
                        {
                            Date = selectedDate,
                            SubjectId = selectetSubject.Id,
                            GroupId = group.Id,
                            Semester = semester,
                            SessionId = session.Id
                        });
                        break;
                    case 2:
                        db.TestDAO.Add(new CourseworkTest()
                        {
                            Date = selectedDate,
                            SubjectId = selectetSubject.Id,
                            GroupId = group.Id,
                            Semester = semester,
                            SessionId = session.Id
                        });
                        break;
                    default:
                        throw new Exception("Тип испытания не определён");
                }

                msgLabel.Content = "Испытание успешно добавлено";

            }
            catch (Exception ex)
            {
                msgLabel.Content = ex.Message;
            }
        }
    }
}
