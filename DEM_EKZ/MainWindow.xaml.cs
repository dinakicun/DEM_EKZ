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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DEM_EKZ
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool loginTextCleared = false;
        private bool passwordTextCleared = false;
        public MainWindow()
        {
            InitializeComponent();
            Color rgbAuthorizationGridColor = Color.FromRgb(181, 213, 202);
            Brush AuthorizationGridBrush = new SolidColorBrush(rgbAuthorizationGridColor);
            AuthorizationGrid.Background = AuthorizationGridBrush;
            Color rgbAuthorizationButtonColor = Color.FromRgb(224, 169, 175);
            Brush AuthorizationButtonBrush = new SolidColorBrush(rgbAuthorizationButtonColor);
            AuthorizationButton.Background = AuthorizationButtonBrush;
        }

        private void GoToRegistration_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
            loginTextCleared = false;
            passwordTextCleared = false;
        }

        private void LoginTextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            if (LoginTextBlock.Text == "Логин" && !loginTextCleared)
            {
                LoginTextBlock.Text = "";
                loginTextCleared = true;
            }
        }

        private void PasswordTextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordTextBlock.Text == "Пароль" && !passwordTextCleared)
            {
                PasswordTextBlock.Text = "";
                passwordTextCleared = true;
            }
        }

        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            using (SFabricaEntities db = new SFabricaEntities())
            {
                var matchingUser = db.AppUser.FirstOrDefault(u => u.Login == LoginTextBlock.Text && u.Password == PasswordTextBlock.Text);
                if (matchingUser != null)
                {
                    UserManager.Instance.UserID = matchingUser.Id;
                    if (matchingUser.Role == 1)
                    {
                        MessageBox.Show("Авторизация пользователем прошла успешно!");
                        ClientPage client = new ClientPage();
                        client.Show();
                        this.Close();
                    }
                    else if (matchingUser.Role == 2)
                    {
                        MessageBox.Show("Авторизация менеджером прошла успешно!");
                        ManagerPage manager = new ManagerPage();
                        manager.Show();
                        this.Close();
                    }
                    else if (matchingUser.Role == 3)
                    {
                        MessageBox.Show("Авторизация кладовщиком прошла успешно!");
                        StockerPage manager = new StockerPage();
                        manager.Show();
                        this.Close();
                    }
                    else if (matchingUser.Role == 4)
                    {
                        MessageBox.Show("Авторизация дирекцией прошла успешно!");
                        DirectorPage director = new DirectorPage();
                        director.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь с таким логином и паролем не найден. Пожалуйста, проверьте правильность введенных данных.");
                }
            }
        }
    }
}