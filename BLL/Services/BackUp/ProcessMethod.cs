using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Enum;
using DAL.Enum;
using DAL.Services.CoreAccess;
using DAL.Services;
using DAL.Models;
using DAL.Services.DALAccess;

namespace BLL.Services.BackUp
{
    public class ProcessMethod
    {
        public void MainProcess(IntegrityStatus status)
        {
            if (status == IntegrityStatus.INTEGRITY_IS_COMPROMISED)
            {
                Core getData = new Core();
                DataType coreDATA = getData.GetData(DataStatus.CORE_DATA);
                Access POST = new Access();
                POST.SetData(coreDATA, DataStatus.SET_DATA_TO_DAL);
            }
        }
    }
}
