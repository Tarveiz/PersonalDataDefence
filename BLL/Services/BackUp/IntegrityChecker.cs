using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Services.CoreAccess;
using DAL.Services;
using DAL.Enum;
using BLL.Enum;
using DAL.Models;

namespace BLL.Services.BackUp
{
    class IntegrityChecker
    {
        public IntegrityStatus MainChecker()
        {
            Core sup = new Core();
            DataType COREHash = sup.GetData(DataStatus.CORE_DATA_HASH);
            DataType dalHash = DALHAsh();
            if (COREHash != dalHash)
            {
                ProcessMethod backUpInitialize = new ProcessMethod();
                backUpInitialize.MainProcess(IntegrityStatus.INTEGRITY_IS_COMPROMISED);
                return IntegrityStatus.INTEGRITY_IS_COMPROMISED;
            }
            else
            {
                return IntegrityStatus.INTEGRITY_IS_INTACT;
            }
        }

        private DataType DALHAsh()
        {
            BackUpSupp getData = new BackUpSupp();
            string personalData = getData.IntegritySupp();
            MainHash getActualHash = new MainHash();
            string actualHash = getActualHash.GetHash(personalData);
            DataType data = new DataType();
            data.StringType = actualHash;
            return data;
        }
    }
}
