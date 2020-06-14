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

namespace StudentPerformanceServiceWPF.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для AddSessionUserControl.xaml
    /// </summary>
    public partial class AddSessionUserControl : UserControl
    {
        public AddSessionUserControl()
        {
            InitializeComponent();
            ElementManager.Instance.ChangeTitleText("Назначение сессии");
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var year = int.Parse(yearTextBox.Text);
                var season = summerRadioButton.IsChecked.Value;

                var db = DAOFactory.GetDAOFactory();

                db.SessionDAO.Add(new Session()
                {
                    Year = year,
                    Season = season
                });

                yearTextBox.Text = string.Empty;
                msgLabel.Content = "Сессия успешно добавлена";
            }
            catch (Exception ex)
            {
                msgLabel.Content = ex.Message;
            }
        }
    }
}
