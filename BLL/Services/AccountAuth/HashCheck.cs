using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Services.CoreAccess;
using System.IO;

namespace BLL.Services.AccountAuth
{
    public class HashCheck
    {
        public void UserHash(string hash)
        {
            //Checker(hash);
        }

        public void DataHash()
        {
            List<string> resultHash = new List<string>();
            Core hashCore = new Core();
            resultHash = hashCore.Hash();
            Checker(resultHash);
        }

        public void Checker(string UserHash, List<string> DataHash)
        {

        }
    }
}
