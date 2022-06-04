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
using BLL.Services.BackUp;
using BLL.Services.Encrypt;

namespace UI
{
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        public void OutPut(object sender, RoutedEventArgs e)
        {
            //HelpClass help = new HelpClass();
            //help.SetCoreHashWithForce();


            BLL.Services.BackUp.MessageBroker integrityMessage = new BLL.Services.BackUp.MessageBroker();
            string integrityResult = "";
            integrityResult = integrityMessage.ReceivingMessage();
            if (integrityResult != "")
            {
                MessageBox.Show(integrityResult);
            }

            BLL.Services.Encrypt.MessageBroker encryptMessage = new BLL.Services.Encrypt.MessageBroker();
            encryptMessage.ReceivingMessage();
        }

        public void Change(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Работает вот так");
        }
    }
}
