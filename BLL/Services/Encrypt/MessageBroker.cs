﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Encrypt
{
    public class MessageBroker
    {
        public void ReceivingMessage()
        {
            RetrievedMessage();
        }

        public void RetrievedMessage()
        {
            Preprocessing message = new Preprocessing();
            message.MainProc();
        }
    }
}
