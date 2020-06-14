using Microsoft.Win32;
using StudentPerformanceServiceCL.Models.Data;
using StudentPerformanceServiceCL.Models.Entities;
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
    /// Логика взаимодействия для ReportOnSpecialtiesUserControl.xaml
    /// </summary>
    public partial class ReportOnSpecialtiesUserControl : UserControl
    {
        private IEnumerable<SpecialtyView> specialtyViews;
        public ReportOnSpecialtiesUserControl()
        {
            InitializeComponent();

            ElementManager.Instance.ChangeTitleText("Отчёт по специальностям");

            LoadData();
        }

        private async void LoadData()
        {
            await Task.Run(() =>
            {
                var db = DAOFactory.GetDAOFactory();
                specialtyViews = db.SpecialtyDAO.Specialties
                    .Select(s => new SpecialtyView()
                    {
                        Id = s.Id,
                        SpecialtyName = s.Name,
                        EasySubject = s.EasySubject != null ? s.EasySubject.Name : "Не определён",
                        HardSubject = s.HardSubject != null ? s.HardSubject.Name : "Не определён",
                        Specialty = s
                    });
            });
            dataGrid.Items.Clear();
            foreach (var specialty in specialtyViews)
            {
                dataGrid.Items.Add(specialty);
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



            foreach (var specialty in specialtyViews)
            {
                root.Add(new XElement("specialty",
                    new XElement("id", specialty.Id),
                    new XElement("name", specialty.SpecialtyName),
                    new XElement("easySubject", specialty.EasySubject),
                    new XElement("hardSubject", specialty.HardSubject)
                ));
            }

            xDoc.Add(root);
            xDoc.Save(path);
        }

        private class SpecialtyView
        {
            public int Id { get; set; }
            public string SpecialtyName { get; set; }
            public string EasySubject { get; set; }
            public string HardSubject { get; set; }
            public Specialty Specialty { get; set; }
        }
    }
}
