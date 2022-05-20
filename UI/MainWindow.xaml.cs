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
using BLL.Models;
using BLL.Services.AccountAuth;
using BLL.Enum;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text;
            string password = PasswordBox.Text;
            AuthModel model = Reques(login, password);
            MessageBroker message = new MessageBroker();
            AuthStatus answer = message.ReceivingMessage(model);
            ExceptionHandler(answer);
        }

        private void ExceptionHandler(AuthStatus answer)
        {
            switch (answer)
            {
                case AuthStatus.notAuthorized:
                    MessageBox.Show("Введены некорректные данные аутентификации.");
                    LoginBox.Text = "";
                    PasswordBox.Text = "";
                    break;
                case AuthStatus.authorized:
                    MainMenu menu = new MainMenu();
                    menu.Show();
                    this.Close();
                    break;
                case AuthStatus.NO_HASH_DATA_IN_CORE:
                    MessageBox.Show("Критическая ошибка. В базе слоя CORE не найдены данные. Пожалуйста, обратитесь к специалисту.");
                    LoginBox.Text = "";
                    PasswordBox.Text = "";
                    break;
            }
        }


        public AuthModel Reques(string login, string password)
        {
            AuthModel model = new AuthModel();
            model.Login = login;
            model.Password = password;
            return (model);
        }
    }
}
