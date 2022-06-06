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
using BLL.Enum.UI_Status;
using BLL.Services;

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
            //help.SetNewCoreDataWithForce("Иванов Иван Иванович, 22.05.1000; Галя Петровна Хреновна, 11.01.2002; Василий Васильевич Васильев, 10.02.2000");
            //help.SetDALPersonalDataWithForce();




            BLL.Services.BackUp.MessageBroker integrityMessage = new BLL.Services.BackUp.MessageBroker();
            string integrityResult = "";
            integrityResult = integrityMessage.ReceivingMessage();
            if (integrityResult != "")
            {
                MessageBox.Show(integrityResult);
            }

            List<string> requestResult = new List<string>();
            BLL.Services.Encrypt.MessageBroker encryptMessage = new BLL.Services.Encrypt.MessageBroker();
            requestResult = encryptMessage.ReceivingMessage(UI_Status.OUTPUT_INFORMATION);
            foreach (string K in requestResult)
            {
                ListForm.Items.Add(K);
            }


        }

        public void Change(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Работает вот так");
        }
    }
}
