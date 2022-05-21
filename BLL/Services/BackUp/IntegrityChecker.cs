using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Services.CoreAccess;
using DAL.Services;
using DAL.Enum;
using BLL.Enum;

namespace BLL.Services.BackUp
{
    class IntegrityChecker
    {
        public IntegrityStatus MainChecker()
        {
            Core sup = new Core();
            string COREHash = sup.GetData(DataStatus.CORE_DATA_HASH);
            string dalHash = DALHAsh();
            if (COREHash != dalHash)
            {
                return IntegrityStatus.INTEGRITY_IS_COMPROMISED;
            }
            else
            {
                return IntegrityStatus.INTEGRITY_IS_INTACT;
            }
        }

        private string DALHAsh()
        {
            BackUpSupp getData = new BackUpSupp();
            string personalData = getData.IntegritySupp();
            MainHash getActualHash = new MainHash();
            string actualHash = getActualHash.GetHash(personalData);
            return actualHash;
        }
    }
}
