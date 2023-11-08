using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для ClientOrders.xaml
    /// </summary>
    public partial class ClientOrders : Window
    {
        private SFabricaEntities db;
        public ClientOrders()
        {
            InitializeComponent();
            LoadOrdersFromDatabase();
            db = new SFabricaEntities();
        }
        private void LoadOrdersFromDatabase()
        {
            using (SFabricaEntities dbContext = new SFabricaEntities())
            {
                var orders = dbContext.Zakaz.Where(x => x.IdZakazchika == UserManager.Instance.UserID)
                    .Include(z => z.ZakazniyeIzdeliya)
                    .Select(z => new
                    {
                        Nomer = z.Nomer,
                        DATA = z.DATA,
                        STATUS = z.STATUS,
                        Stoimost = z.Stoimost
                    })
                    .ToList();

                OrderList.ItemsSource = orders;
            }

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            UserManager.Instance.ClearUserID();
            MainWindow authorization = new MainWindow();
            authorization.Show();
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ClientPage clientPage = new ClientPage();
            clientPage.Show();
            this.Close();
        }

        private void OrderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrderList.SelectedItem != null)
            {

                var selectedOrder = (dynamic)OrderList.SelectedItem;

                int orderNumber = selectedOrder.Nomer;
                string orderStatus = selectedOrder.STATUS;

                var order = db.Zakaz.Where(x => x.Nomer == orderNumber).First();

                if (order.STATUS == "Новый")
                {
                    DeclineButton.IsEnabled = true;
                    DeclineButton.Click += (s, args) =>
                    {
                        order.STATUS = "Отклонен";
                        DeclineButton.IsEnabled = false;
                        db.SaveChanges();
                        LoadOrdersFromDatabase();
                    };
                    db.SaveChanges();
                    LoadOrdersFromDatabase();

                }
                else if (order.STATUS == "К оплате")
                {
                    PayButton.IsEnabled = true;

                    PayButton.Click += (s, args) =>
                    {
                        order.STATUS = "Оплачен";
                        PayButton.IsEnabled = false;
                        db.SaveChanges();
                        LoadOrdersFromDatabase();
                    };

                }

            }
        }
    

        private void DeclineButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PayButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
