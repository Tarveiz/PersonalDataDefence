using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Services.Encrypt
{
    public class MessageBroker
    {
        public UI_OutPut ReceivingMessage()
        {
            RetrievedMessage();
            return
        }

        public void RetrievedMessage()
        {
            Preprocessing message = new Preprocessing();
            message.MainProc();
        }
    }
}
