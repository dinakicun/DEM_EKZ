using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для GoodsInformation.xaml
    /// </summary>
    public partial class GoodsInformation : Window
    {
        public SFabricaEntities _db = new SFabricaEntities();
        private Izdeliya _izdeliya;
        public GoodsInformation(SFabricaEntities db, object o)
        {
            InitializeComponent();
            _izdeliya = (o as Button).DataContext as Izdeliya;
            _db = db;
            name.Text = _izdeliya.Naimenovanie;
            Shirina.Text = _izdeliya.Shirina.ToString();
            Dlina.Text = _izdeliya.Dlina.ToString();
            Articul.Text = _izdeliya.Articul.ToString();
            var art = _izdeliya.Articul;
            var tkaniIzdel = _db.TkaniIzdeliya.Where(x => x.IdIzdeliya == art).FirstOrDefault();
            if (tkaniIzdel != null)
            {
                var tkani = _db.Tkani.Where(x => x.Articul == tkaniIzdel.IdTkani).FirstOrDefault();
           
                Tkani.Text = tkani.Nazvanie.ToString();
            }
            var firnitureIzdel = _db.FurnituraIzdeliya.Where(x => x.IdIzdeliya == art).FirstOrDefault();
            if (firnitureIzdel != null)
            {
                var furniture = _db.Furnitura.Where(x => x.Articul == firnitureIzdel.IdFurnitura).FirstOrDefault();
            
                Furniture.Text = furniture.Naimenovanie.ToString();
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
            GoodsList goodsList = new GoodsList();
            goodsList.Show();
            this.Close();
        }
    }
}
