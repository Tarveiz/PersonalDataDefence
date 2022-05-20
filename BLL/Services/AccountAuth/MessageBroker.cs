using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Enum;
using BLL.Models;

namespace BLL.Services.AccountAuth
{
    public class MessageBroker
    {
        public AuthStatus ReceivingMessage(AuthModel model)
        {
            //Для работы с внешней частью
            AuthStatus status = RetrievedMessage(model);
            return status;
        }

        public AuthStatus RetrievedMessage(AuthModel model)
        {
            //Для работы с внутренней частью
            HashCheck req = new HashCheck();
            AuthStatus result = req.Checker(model);
            return result;
        }
    }
}
