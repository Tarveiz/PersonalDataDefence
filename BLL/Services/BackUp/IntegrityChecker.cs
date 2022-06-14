using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Services.CoreAccess;
using DAL.Enum;
using BLL.Enum;
using DAL.Models;
using DAL.Services.DALAccess;

namespace BLL.Services.BackUp
{
    class IntegrityChecker
    {
        public IntegrityStatus MainChecker()
        {
            Core sup = new Core();
            MainHash makeHash = new MainHash();
            bool check = false;
            for (int i = 0; i<=1; i++)
            {
                DataType COREData = sup.GetData(DataStatus.CORE_DATA);
                DataType COREHash = new DataType();
                COREHash.StringType = makeHash.GetHash(COREData);
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
            data = getData.GetData(DataStatus.GET_DATA_FROM_DAL);
            MainHash getActualHash = new MainHash();
            data.StringType = getActualHash.GetHash(data);
            return data;
        }
    }
}
