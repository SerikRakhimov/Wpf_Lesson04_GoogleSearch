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

namespace GoogleSearch
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            main.WindowState = System.Windows.WindowState.Maximized;
            webBrowser.Navigate("https://www.google.com/");
        }

        private void TabItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var items = tabControl.Items;

            WebBrowser webBrowser = new WebBrowser();
            webBrowser.Navigate("https://www.google.com/");

            items.RemoveAt(items.Count - 1);

            items.Add(new TabItem
            {
                Header = new TextBlock { Text = "Google" },
                Content = webBrowser
            });

            TabItem item = new TabItem
            {
                Header = new TextBlock { Text = "+" }
            };
            item.PreviewMouseLeftButtonDown += TabItem_PreviewMouseLeftButtonDown;
            items.Add(item);

            tabControl.SelectedIndex = items.Count - 2;

        }
    }
}
