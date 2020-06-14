using Microsoft.Win32;
using StudentPerformanceServiceCL.Models.Data;
using StudentPerformanceServiceCL.Models.Entities;
using StudentPerformanceServiceCL.Services;
using StudentPerformanceServiceCL.Services.ViewModels;
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
using System.Xml.Linq;

namespace StudentPerformanceServiceWPF.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для ReportStudentPerformanceUserControl.xaml
    /// </summary>
    public partial class ReportStudentPerformanceUserControl : UserControl
    {
        private readonly StudentFilterService studentFilter;
        private Session selectSession;
        private string selectFaculty;
        private string selectSepcialty;

        public ReportStudentPerformanceUserControl()
        {
            InitializeComponent();


            studentFilter = new StudentFilterService();

            StartupLoad();

            ElementManager.Instance.ChangeTitleText("Отчёт по успеваемости студентов");

            facultyComboBox.SelectionChanged += (s, e) =>
            {
                var comboBox = (ComboBox)s;
                selectFaculty = comboBox.SelectedIndex == 0 ? null : ((Faculty)comboBox.SelectedItem).Name;
                LoadStudents();
            };
            specialtyComboBox.SelectionChanged += (s, e) =>
            {
                var comboBox = (ComboBox)s;
                selectSepcialty = comboBox.SelectedIndex == 0 ? null : ((Specialty)comboBox.SelectedItem).Name;
                LoadStudents();
            };
            sessionComboBox.SelectionChanged += (s, e) =>
            {
                var comboBox = (ComboBox)s;
                selectSession = comboBox.SelectedIndex == 0 ? null : ((Session)comboBox.SelectedItem);
                LoadStudents();
            };
        }

        private void StartupLoad()
        {
            LoadSpecialties();
            LoadFaculies();
            LoadSessions();
            LoadStudents();
        }

        private void LoadSpecialties()
        {
            var db = DAOFactory.GetDAOFactory();
            IEnumerable<Specialty> specialties = db.SpecialtyDAO.Specialties;
            specialtyComboBox.Items.Clear();
            specialtyComboBox.Items.Add("(Все специальности)");
            foreach (var specialty in specialties)
            {
                specialtyComboBox.Items.Add(specialty);
            }
        }

        private void LoadFaculies()
        {
            var db = DAOFactory.GetDAOFactory();
            IEnumerable<Faculty> faculties = db.FacultyDAO.Faculties;
            facultyComboBox.Items.Clear();
            facultyComboBox.Items.Add("(Все факультеты)");
            foreach (var faculty in faculties)
            {
                facultyComboBox.Items.Add(faculty);
            }
        }

        private void LoadSessions()
        {
            var db = DAOFactory.GetDAOFactory();
            IEnumerable<Session> sessions = db.SessionDAO.Sessions;
            sessionComboBox.Items.Clear();
            sessionComboBox.Items.Add("(Все сессии)");
            foreach (var session in sessions)
            {
                sessionComboBox.Items.Add(session);
            }
        }

        private async void LoadStudents()
        {
            await Task.Run(() => studentFilter.GetStudents(selectFaculty, selectSepcialty, session: selectSession));

            dataGrid.Items.Clear();

            foreach (var student in studentFilter.StudentViews)
            {
                dataGrid.Items.Add(student);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML файл(*.xml)|*.xml|Все файлы(*.*)|*.*";
            try
            {
                saveFileDialog.ShowDialog();

                string filename = saveFileDialog.FileName;
                SaveToXML(filename);
                MessageBox.Show("Файл успешно сохранён.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось сохранить файл. " + ex.Message);
            }
        }

        private void SaveToXML(string path)
        {
            XDocument xDoc = new XDocument();
            XElement root = new XElement("reports");



            foreach (var student in studentFilter.StudentViews)
            {
                root.Add(new XElement("student",
                    new XElement("id", student.Id),
                    new XElement("fullName", student.StudentFullName),
                    new XElement("faculty", student.FacultyName),
                    new XElement("group", student.GroupName),
                    new XElement("course", student.Course),
                    new XElement("avgMark", student.AvgMark)
                ));
            }

            xDoc.Add(root);
            xDoc.Save(path);
        }
    }
}
