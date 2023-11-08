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
using Excel = Microsoft.Office.Interop.Excel;

namespace DEM_EKZ
{
    /// <summary>
    /// Логика взаимодействия для FurnituraReport.xaml
    /// </summary>
    public partial class FurnituraReport : Window
    {
        public FurnituraReport()
        {
            InitializeComponent();
            SFabricaEntities db = new SFabricaEntities();
            furnitureGrid.ItemsSource = db.Furnitura.ToList();
        }



        private void Report_Click(object sender, RoutedEventArgs e)
        {
            var app = new Excel.Application();
            app.SheetsInNewWorkbook = 1;
            Excel.Workbook workbook = app.Workbooks.Add(Type.Missing);
            Excel.Worksheet ws = app.Worksheets.Item[1];
            ws.Name = "Фурнитура";
            ws.Cells[1][1] = "Артикул";
            ws.Cells[1][1].Font.Bold = true;
            ws.Cells[2][1] = "Название";
            ws.Cells[2][1].Font.Bold = true;
            ws.Cells[3][1] = "Ширина";
            ws.Cells[3][1].Font.Bold = true;

            int rowIndex = 2;

           
                foreach (var item in furnitureGrid.Items)
                {
                    ws.Cells[1][rowIndex] = ((Furnitura)item).Articul;
                    ws.Cells[2][rowIndex] = ((Furnitura)item).Naimenovanie;
                    ws.Cells[3][rowIndex] = ((Furnitura)item).Shirina;
                    rowIndex++;
                }
           
            Excel.Range rangeBorders = ws.Range[ws.Cells[1][1], ws.Cells[3][rowIndex]];
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle =
            Excel.XlLineStyle.xlContinuous;
           app.Visible = true;
        }
        
        

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            DirectorPage director = new DirectorPage();
            director.Show();
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
