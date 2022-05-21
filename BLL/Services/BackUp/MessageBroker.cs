using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Enum;

namespace BLL.Services.BackUp
{
    public class MessageBroker
    {
        public IntegrityStatus ReceivingMessage()
        {
            IntegrityStatus statusResult = RetrievedMessage();
            return statusResult;
        }

        public IntegrityStatus RetrievedMessage()
        {
            IntegrityChecker check = new IntegrityChecker();
            IntegrityStatus statusResult =  check.MainChecker();
            return statusResult;
        }
    }
}
