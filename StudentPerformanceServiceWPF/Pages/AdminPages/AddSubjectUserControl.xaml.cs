﻿using StudentPerformanceServiceCL.Models.Data;
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

namespace StudentPerformanceServiceWPF.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для AddSubjectUserControl.xaml
    /// </summary>
    public partial class AddSubjectUserControl : UserControl
    {
        public AddSubjectUserControl()
        {
            InitializeComponent();

            ElementManager.Instance.ChangeTitleText("Добавление новой дисциплины");
            LoadSpecialties();
        }

        private async void LoadSpecialties()
        {
            IEnumerable<Specialty> specialties = null;
            await Task.Run(() => 
            {
                var db = DAOFactory.GetDAOFactory();
                specialties = db.SpecialtyDAO.Specialties;
            });
            specialtiesComboBox.Items.Clear();
            foreach (var specialty in specialties)
            {
                specialtiesComboBox.Items.Add(specialty);
            }
            specialtiesComboBox.SelectedIndex = 0;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var name = nameTextBox.Text;
                var teacher = teacherFullNameTextBox.Text;
                var specialty = (Specialty)specialtiesComboBox.SelectedValue;
                var db = DAOFactory.GetDAOFactory();

                db.SubjectDAO.Add(new Subject()
                {
                    Name = name,
                    Teacher = teacher
                }, specialty);

                nameTextBox.Text = string.Empty;
                teacherFullNameTextBox.Text = string.Empty;

                msgLabel.Content = "Дисциплина успешно добавлена";
            }
            catch (Exception ex)
            {
                msgLabel.Content = ex.Message;
            }
        }
    }
}
