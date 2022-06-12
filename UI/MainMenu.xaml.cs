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
using BLL.Enum.UI_Status;
using BLL.Services;
using BLL.Models.UI_Model;

namespace UI
{
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        public async void OutPut(object sender, RoutedEventArgs e)
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
            string text = "";
            foreach (string K in requestResult)
            {
                string str = K;
                text += str + "\n";
            }
            ListForm.Text = text;



            Action<string> message = error =>
            {
                MessageBox.Show(error);
                Environment.Exit(0);
            };


            await Task.Run(() =>
            {
                SecondBackUp.MainProccess(text, message);
            });


        }

        public void ChangeItem(object sender, RoutedEventArgs e)
        {
            List<string> usersList = new List<string>();
            string word = "";
            foreach (char i in ListForm.Text)
            {
                
                if (i == '\n')
                {
                    usersList.Add(word);
                    word = "";
                }else
                {
                    word += i;
                }
            }
            Rewrite message = new Rewrite();
            message.Proccess(usersList);
        }
    }
}
