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
        public string ReceivingMessage()
        {
            IntegrityStatus statusResult = RetrievedMessage();
            string returnStatus = "";
            if(statusResult == IntegrityStatus.INTEGRITY_IS_BROKEN_BUT_HAS_BEEN_RESTORED)
            {
                returnStatus = "Целостность нарушена, но была восстановлена";
                return returnStatus;
            }
            if (statusResult == IntegrityStatus.INTEGRITY_IS_INTACT)
            {
                returnStatus = "Целостность информации не нарушена";
                return returnStatus;
            }
            returnStatus = "Неизвестная ошибка. Пожалуйста, обратитесь к специалисту.";
            return returnStatus;
        }

        public IntegrityStatus RetrievedMessage()
        {
            IntegrityChecker check = new IntegrityChecker();
            IntegrityStatus statusResult =  check.MainChecker();
            return statusResult;
        }
    }
}
