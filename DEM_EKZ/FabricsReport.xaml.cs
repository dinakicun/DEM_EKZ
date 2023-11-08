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
    /// Логика взаимодействия для FabricsReport.xaml
    /// </summary>
    public partial class FabricsReport : Window
    {
        public FabricsReport()
        {
            InitializeComponent();
            InitializeComponent();
            SFabricaEntities db = new SFabricaEntities();
            fabricsGrid.ItemsSource = db.Tkani.ToList();
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
            DirectorPage director = new DirectorPage();
            director.Show();
            this.Close();
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            var app = new Excel.Application();
            app.SheetsInNewWorkbook = 1;
            Excel.Workbook workbook = app.Workbooks.Add(Type.Missing);
            Excel.Worksheet ws = app.Worksheets.Item[1];
            ws.Name = "Ткани";
            ws.Cells[1][1] = "Артикул";
            ws.Cells[1][1].Font.Bold = true;
            ws.Cells[2][1] = "Название";
            ws.Cells[2][1].Font.Bold = true;
            ws.Cells[3][1] = "Ширина";
            ws.Cells[3][1].Font.Bold = true;
            ws.Cells[4][1] = "Длина";
            ws.Cells[4][1].Font.Bold = true;
            ws.Cells[5][1] = "Цена";
            ws.Cells[5][1].Font.Bold = true;
            int rowIndex = 2;


            foreach (var item in fabricsGrid.Items)
            {
                ws.Cells[1][rowIndex] = ((Tkani)item).Articul;
                ws.Cells[2][rowIndex] = ((Tkani)item).Nazvanie;
                ws.Cells[3][rowIndex] = ((Tkani)item).Shirina;
                ws.Cells[4][rowIndex] = ((Tkani)item).Dlina;
                ws.Cells[5][rowIndex] = ((Tkani)item).Price;
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
    }
}
