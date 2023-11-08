using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для OrderListManager.xaml
    /// </summary>
    public partial class OrderListManager : Window
    {
        private SFabricaEntities db;
        public OrderListManager()
        {
            InitializeComponent();
            LoadOrdersFromDatabase();
            db = new SFabricaEntities();

        }
        private void LoadOrdersFromDatabase()
        {
            using (SFabricaEntities dbContext = new SFabricaEntities())
            {
                var orders = dbContext.Zakaz.Where(x => x.IdManagera == UserManager.Instance.UserID || x.IdManagera == null)
                    .Include(z => z.ZakazniyeIzdeliya)
                    .Select(z => new
                    {
                        Nomer = z.Nomer,
                        DATA = z.DATA,
                        STATUS = z.STATUS,
                        IdZakazchika = z.IdZakazchika,
                        IdManagera = z.IdManagera,
                        Count = z.ZakazniyeIzdeliya
        .Where(zi => zi.IdZakaza == z.Nomer).Count()
            })
                    .ToList();

                OrderList.ItemsSource = orders;
            }

        }
        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeclineButton_Click(object sender, RoutedEventArgs e)
        {

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
            ManagerPage manager = new ManagerPage();
            manager.Show();
            this.Close();
        }

        private void OrderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrderList.SelectedItem != null)
            {
                
                    var selectedOrder = (dynamic)OrderList.SelectedItem;

                    int orderNumber = selectedOrder.Nomer;
                    string orderStatus = selectedOrder.STATUS;
                    var orderManager = selectedOrder.IdManagera;

                    var order = db.Zakaz.Where(x => x.Nomer == orderNumber).First();

                    if (order.STATUS == "Новый")
                    {
                        order.STATUS = "Обработка";
                        if (orderManager == 0 || orderManager == null)
                        {
                            order.IdManagera = UserManager.Instance.UserID;
                        }
                        db.SaveChanges();
                        LoadOrdersFromDatabase();

                }
                    else if (order.STATUS == "Обработка")
                    {
                        AcceptButton.IsEnabled = true;
                        DeclineButton.IsEnabled = true;

                            AcceptButton.Click += (s, args) =>
                            {
                                order.STATUS = "К оплате";
                                AcceptButton.IsEnabled = false;
                                DeclineButton.IsEnabled = false;
                                db.SaveChanges();
                                LoadOrdersFromDatabase();
                            };

                            DeclineButton.Click += (s, args) =>
                            {
                                order.STATUS = "Отклонен";
                                AcceptButton.IsEnabled = false;
                                DeclineButton.IsEnabled = false;
                                db.SaveChanges();
                                LoadOrdersFromDatabase();
                            };
                    }
                    
                }
            }
        }
    }

