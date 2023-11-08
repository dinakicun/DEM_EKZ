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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Window
    {
        public ClientPage()
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

        private void ToMakeOrderButton_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            order.Show();
            this.Close();
        }

        private void MyOrdersButton_Click(object sender, RoutedEventArgs e)
        {
            ClientOrders orders = new ClientOrders();
            orders.Show(); 
            this.Close();    
        }
    }
}
