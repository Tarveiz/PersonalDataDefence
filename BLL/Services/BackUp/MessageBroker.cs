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
        public void ReceivingMessage()
        {
            RetrievedMessage();
        }

        public IntegrityStatus RetrievedMessage()
        {
            IntegrityChecker check = new IntegrityChecker();
            check.MainChecker();

            return IntegrityStatus.INTEGRITY_IS_COMPROMISED;
        }
    }
}
