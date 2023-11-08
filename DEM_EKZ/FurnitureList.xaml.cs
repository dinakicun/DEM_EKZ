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
    /// Логика взаимодействия для FurnitureList.xaml
    /// </summary>
    public partial class FurnitureList : Window
    {
        public FurnitureList()
        {
            InitializeComponent();
            SFabricaEntities db = new SFabricaEntities();
            furnitureGrid.ItemsSource = db.Furnitura.ToList();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
         
            StockerPage stockerPage = new StockerPage();
            stockerPage.Show();
            this.Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            UserManager.Instance.ClearUserID();
            MainWindow authorization = new MainWindow();
            authorization.Show();
            this.Close();
        }
    }
}
