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
            AuthStatus status = RetrievedMessage(model);
            return status;
        }

        public AuthStatus RetrievedMessage(AuthModel model)
        {
            HashProcess req = new HashProcess();
            AuthStatus result = req.UsersHash(model);
            return result;
        }
    }
}
