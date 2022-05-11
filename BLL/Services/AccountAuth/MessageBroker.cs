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
        public void ReceivingMessage(AuthModel model)
        {
            RetrievedMessage(model);
        }

        public AuthStatus RetrievedMessage(AuthModel model)
        {
            HashProcess req = new HashProcess();
            req.UsersHash(model);
        }
    }
}
