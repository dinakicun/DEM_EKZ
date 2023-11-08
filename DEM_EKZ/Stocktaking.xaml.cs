using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using Word = Microsoft.Office.Interop.Word;

namespace DEM_EKZ
{
    /// <summary>
    /// Логика взаимодействия для Stocktaking.xaml
    /// </summary>
    public partial class Stocktaking : Window
    {
        private SFabricaEntities _db;
        public Stocktaking()
        {
            InitializeComponent();
            _db = new SFabricaEntities();
        }

        private void Material_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Material.SelectedIndex == 0)
            {
                MaterialsArticul.Items.Clear();
                MaterialsArticul.IsEnabled = true;
                List<Furnitura> furniture = new List<Furnitura>();
                using (SFabricaEntities db = new SFabricaEntities())
                {
                    furniture = db.Furnitura.ToList();
                }

                foreach (var items in furniture)
                {
                    MaterialsArticul.Items.Add(items.Articul);
                }
                
            }
            else
            {
                MaterialsArticul.Items.Clear();
                MaterialsArticul.IsEnabled = true;
                List<Tkani> tkani = new List<Tkani>();
                using (SFabricaEntities db = new SFabricaEntities())
                {
                    tkani = db.Tkani.ToList();
                }

                foreach (var items in tkani)
                {
                    MaterialsArticul.Items.Add(items.Articul);
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            StockerPage stocker = new StockerPage();
            stocker.Show();
            this.Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            UserManager.Instance.ClearUserID();
            MainWindow authorization = new MainWindow();
            authorization.Show();
            this.Close();
        }

        private void OrderListButton_Click(object sender, RoutedEventArgs e)
        {
      if (Material.SelectedIndex == 0 && MaterialsArticul.SelectedIndex >= 0 && !string.IsNullOrEmpty(CountTextBox.Text))
    {
                string selectedArticul = MaterialsArticul.SelectedItem.ToString();
                int quantity;
                SkladFurnituri selected = _db.SkladFurnituri.FirstOrDefault(f => f.IdFurnituri == selectedArticul);
                if (selected != null) 
                {
                    float difference = Math.Abs((float)(Convert.ToInt32(selected.Kolichestvo) - Convert.ToInt32(CountTextBox.Text)) / Convert.ToInt32(CountTextBox.Text));
                    if (difference <= 0.20)
                    {
                        if (int.TryParse(CountTextBox.Text, out quantity))
                        {

                            selected.Kolichestvo = CountTextBox.Text;
                            _db.SaveChanges();
                            MessageBox.Show("Запись успешно обновлена");
                            CountTextBox.Text = "";
                            MaterialsArticul.Items.Clear();
                            Material.SelectedItem = null;
                        }
                        else
                        {
                            MessageBox.Show("Пожалуйста, введите корректное значение количества.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Расхождение более 20%!!");
                        Difference.Text = difference.ToString();
                        var app = new Word.Application();
                        Word.Document document = app.Documents.Add();

                        Word.Paragraph paragraph = document.Paragraphs.Add();
                        Word.Range range = paragraph.Range;
                        range.Font.Size = 16;
                        range.Font.Bold = 1;
                        range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        range.Text = "Неверная инвентаризация за " + DateTime.Today;
                        range.InsertParagraphAfter();

                        Word.Paragraph materialInfoParagraph = document.Paragraphs.Add();
                        Word.Range materialInfoRange = materialInfoParagraph.Range;
                        materialInfoRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                        materialInfoRange.Font.Size = 14;
                        materialInfoRange.Text = $"Артикул: {selected.IdFurnituri}\nНомер на складе: {selected.Id}\n" +
                            $"Реальные данные: {CountTextBox.Text}\nУчетные данные: {selected.Kolichestvo}";
                        app.Visible = true;
                        document.SaveAs2(@"C:\Users\krolc\Документы");

                    }
                }
                else
                {
                    if (int.TryParse(CountTextBox.Text, out quantity))
                    {
                        using (SFabricaEntities db = new SFabricaEntities())
                        {

                            Furnitura selectedFurnitura = db.Furnitura.FirstOrDefault(f => f.Articul == selectedArticul);

                            if (selectedFurnitura != null)
                            {

                                SkladFurnituri skladFurnitura = new SkladFurnituri
                                {
                                    IdFurnituri = selectedFurnitura.Articul,
                                    Kolichestvo = CountTextBox.Text
                                };

                                db.SkladFurnituri.Add(skladFurnitura);
                                db.SaveChanges();
                                CountTextBox.Text = "";
                                MaterialsArticul.Items.Clear();
                                Material.SelectedItem = null;
                                MessageBox.Show("Данные успешно добавлены");
                            }
                            else
                            {
                                MessageBox.Show("Фурнитура с выбранным артикулом не найдена.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пожалуйста, введите корректное значение количества.");
                    }
                }
                    
    }
           else if (Material.SelectedIndex == 1 && MaterialsArticul.SelectedIndex >= 0 && !string.IsNullOrEmpty(CountTextBox.Text))
            {
                string selectedArticul = MaterialsArticul.SelectedItem.ToString();
                int quantity;
                SkladTkani selected = _db.SkladTkani.FirstOrDefault(f => f.IdTkani == selectedArticul);
                if (selected != null)
                {
                    float difference = Math.Abs((float)(Convert.ToInt32(selected.Kolichestvo) - Convert.ToInt32(CountTextBox.Text)) / Convert.ToInt32(CountTextBox.Text));
                    if (difference <= 0.2)
                    {
                        if (int.TryParse(CountTextBox.Text, out quantity))
                        {

                            selected.Kolichestvo = CountTextBox.Text;
                            _db.SaveChanges();
                            MessageBox.Show("Запись успешно обновлена");
                            CountTextBox.Text = "";
                            MaterialsArticul.Items.Clear();
                            Material.SelectedItem = null;
                        }
                        else
                        {
                            MessageBox.Show("Пожалуйста, введите корректное значение количества.");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Расхождение более 20%!!");
                        Difference.Text = difference.ToString();
                        var app = new Word.Application();
                        Word.Document document = app.Documents.Add();

                        Word.Paragraph paragraph = document.Paragraphs.Add();
                        Word.Range range = paragraph.Range;
                        range.Font.Size = 16;
                        range.Font.Bold = 1;
                        range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        range.Text = "Неверная инвентаризация за " + DateTime.Today;
                        range.InsertParagraphAfter();

                        Word.Paragraph materialInfoParagraph = document.Paragraphs.Add();
                        Word.Range materialInfoRange = materialInfoParagraph.Range;
                        materialInfoRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                        materialInfoRange.Font.Size = 14;
                        materialInfoRange.Text = $"Артикул: {selected.IdTkani}\nНомер на складе: {selected.Id}\n" +
                            $"Реальные данные: {CountTextBox.Text}\nУчетные данные: {selected.Kolichestvo}";
                        app.Visible = true;
                        document.SaveAs2(@"C:\Users\krolc\Документы");
                    }
                    
                }
                else
                {
                    if (int.TryParse(CountTextBox.Text, out quantity))
                    {
                        using (SFabricaEntities db = new SFabricaEntities())
                        {

                            Tkani selectedFabrics= db.Tkani.FirstOrDefault(f => f.Articul == selectedArticul);

                            if (selectedFabrics != null)
                            {
                                SkladTkani skladFabrics = new SkladTkani
                                {
                                    IdTkani = selectedFabrics.Articul,
                                    Kolichestvo = CountTextBox.Text
                                };

                                db.SkladTkani.Add(skladFabrics);
                                db.SaveChanges();
                                CountTextBox.Text = "";
                                MaterialsArticul.Items.Clear();
                                Material.SelectedItem = null;
                                MessageBox.Show("Данные успешно добавлены");
                            }
                            else
                            {
                                MessageBox.Show("Фурнитура с выбранным артикулом не найдена.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пожалуйста, введите корректное значение количества.");
                    }
                }

            }
            else
                    {
                        MessageBox.Show("Пожалуйста, выберите артикул и введите количество.");
                    }
        }

        private void MaterialsArticul_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CountTextBox.IsEnabled = true;
        }
    }
}
