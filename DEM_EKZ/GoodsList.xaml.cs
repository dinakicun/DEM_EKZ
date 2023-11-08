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
    /// Логика взаимодействия для GoodsList.xaml
    /// </summary>
    public partial class GoodsList : Window
    {
        public SFabricaEntities db = new SFabricaEntities();
        public GoodsList()
        {
            InitializeComponent();
            
            fabricsGrid.ItemsSource = db.Izdeliya.ToList();
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
          SFabricaEntities sFabricaEntities = new SFabricaEntities();
          var userRole = sFabricaEntities.AppUser.Where(u => u.Id == UserManager.Instance.UserID).Select(u => u.Role).FirstOrDefault();
          if (userRole == 2) 
            {
                ManagerPage managerPage = new ManagerPage();
                managerPage.Show();
                this.Close();
            }
          else if (userRole == 4) 
            {
                DirectorPage directorPage = new DirectorPage();
                directorPage.Show();
                this.Close();
            }
        }

        private void InformationButton_Click(object sender, RoutedEventArgs e)
        {
            GoodsInformation goodsInformation = new GoodsInformation(db, sender);
            goodsInformation.Show();
            this.Close();
        }

    
    }
}
