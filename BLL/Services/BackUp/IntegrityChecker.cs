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
            bool check = false;
            for (int i = 0; i<=1; i++)
            {
                DataType COREHash = sup.GetData(DataStatus.CORE_DATA_HASH);
                DataType dalHash = DALHAsh();
                if (COREHash.StringType != dalHash.StringType)
                {
                    ProcessMethod backUpInitialize = new ProcessMethod();
                    backUpInitialize.MainProcess(IntegrityStatus.INTEGRITY_IS_COMPROMISED);
                    i--; check = true;
                }
                else
                {
                    if (check == true)
                    {
                        return IntegrityStatus.INTEGRITY_IS_BROKEN_BUT_HAS_BEEN_RESTORED;
                    }
                    return IntegrityStatus.INTEGRITY_IS_INTACT;
                }
            }
            
            return IntegrityStatus.UNKNOWN_ERROR;
        }

        private DataType DALHAsh()
        {
            DataType data = new DataType();
            Access getData = new Access();
            data = getData.IntegritySupp();
            MainHash getActualHash = new MainHash();
            data.StringType = getActualHash.GetHash(data);
            return data;
        }
    }
}
