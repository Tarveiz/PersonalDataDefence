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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string log = LoginBox.Text;
            string pas = PasswordBox.Text;
            AuthModel model = Reques(log, pas);
            MessageBroker message = new MessageBroker();
            message.ReceivingMessage(model);
        }

        public AuthModel Reques(string A, string B)
        {
            AuthModel model = new AuthModel();
            model.Login = A;
            model.Password = B;
            return (model);
        }
    }
}
