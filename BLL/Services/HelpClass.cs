using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Enum;
using DAL.Models;
using DAL.Services.CoreAccess;

namespace BLL.Services
{
    public class HelpClass
    {
        public void SetCoreHashWithForce()
        {
            Core core = new Core();
            DataType data = new DataType();
            DataType data2 = new DataType();
            data = core.GetData(DataStatus.CORE_DATA);
            MainHash hash = new MainHash();
            data2.StringType = hash.GetHash(data);
            core.SetData(data2, DataStatus.CORE_DATA_HASH);
        }
    }
}
