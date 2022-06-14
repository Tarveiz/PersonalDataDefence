using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services.Encrypt;
using BLL.Models.UI_Model;

namespace BLL.Services.Rewrite
{
    public class Rewrite
    {
        public void Proccess(List<string> usersList)
        {
            SecondBackUp.InnerStop();
            string unEncryptedCoreData = "";
            string str = "";
            foreach (string K in usersList)
            {
                str = K;
                str += ";";
                unEncryptedCoreData += str;
            }
            MessageBroker needToEncrypt = new MessageBroker();
            UI_Model model = new UI_Model();
            model.StringType = unEncryptedCoreData;
            model.State = Enum.UI_Status.UI_Status.REWRITE_INFORMATION;
            needToEncrypt.ReceivingMessage(model);
            SecondBackUp.InnerStart();
        }
    }
}
