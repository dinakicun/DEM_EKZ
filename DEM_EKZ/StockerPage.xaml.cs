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
    /// Логика взаимодействия для StockerPage.xaml
    /// </summary>
    public partial class StockerPage : Window
    {
        public StockerPage()
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

        private void Fabrics_Click(object sender, RoutedEventArgs e)
        {
            FabricsList fabricsList = new FabricsList();
            fabricsList.Show();
            this.Close();

        }

        private void Furniture_Click(object sender, RoutedEventArgs e)
        {
            FurnitureList furnitureList = new FurnitureList();
            furnitureList.Show();
            this.Close();
        }

        private void Stocktaking_Click(object sender, RoutedEventArgs e)
        {
            Stocktaking stock = new Stocktaking();
            stock.Show();
            this.Close();
        }
    }
}
