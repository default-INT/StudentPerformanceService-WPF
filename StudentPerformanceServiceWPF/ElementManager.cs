using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StudentPerformanceServiceWPF
{
    internal class ElementManager
    {
        private Grid _mainGrid;
        private Grid _buttonMenu;
        private Label _titleLable;

        private ElementManager(Grid mainGrid, Grid buttonMenu, Label titleLable)
        {
            _mainGrid = mainGrid;
            _buttonMenu = buttonMenu;
            _titleLable = titleLable;
        }
        
        public static ElementManager SetInstance(Grid mainGrid, Grid buttonMenu, Label titleLable)
        {
            Instance = new ElementManager(mainGrid, buttonMenu, titleLable);
            return Instance;
        }

        public static ElementManager Instance { get; private set; }


        public void SetContent(UserControl userControl)
        {
            _mainGrid.Children.Clear();
            _mainGrid.Children.Add(userControl);
        }

        public void SetButtonMenu(UserControl userControl)
        {
            _buttonMenu.Children.Clear();
            _buttonMenu.Children.Add(userControl);
        }

        public void ChangeTitleText(string titleText)
        {
            _titleLable.Content = titleText;
        }
    }
}
