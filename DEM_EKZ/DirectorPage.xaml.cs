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

namespace DEM_EKZ
{
    /// <summary>
    /// Логика взаимодействия для DirectorPage.xaml
    /// </summary>
    public partial class DirectorPage : Window
    {
        public DirectorPage()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            UserManager.Instance.ClearUserID();
            MainWindow authorization = new MainWindow();
            authorization.Show();
            this.Close();
        }

        private void GoodListButton_Click(object sender, RoutedEventArgs e)
        {
            GoodsList goodsList = new GoodsList();
            goodsList.Show();
            this.Close();
        }

        private void FurnituraReportButton_Click(object sender, RoutedEventArgs e)
        {
            FurnituraReport furnituraReport = new FurnituraReport();
            furnituraReport.Show();
            this.Close();
        }

       
        private void TkaniReportButton_Click(object sender, RoutedEventArgs e)
        {
            FabricsReport fabricsReport = new FabricsReport();
            fabricsReport.Show();
            this.Close();
        }
    }
}
