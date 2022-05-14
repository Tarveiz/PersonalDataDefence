using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Services.CoreAccess;
using System.IO;
using BLL.Enum;

namespace BLL.Services.AccountAuth
{
    public class HashCheck
    {

        public AuthStatus Checker(string UIhash)
        {
            List<string> resultHash = new List<string>();
            Core hashCore = new Core();
            resultHash = hashCore.Hash();
            foreach (string str in resultHash)
            {
                if (str == "NO_HASH_DATA_IN_CORE")
                {
                    return AuthStatus.NO_HASH_DATA_IN_CORE;
                }
                if (UIhash == str)
                {
                    return AuthStatus.authorized;
                }
            }
            return AuthStatus.notAuthorized;
        }
    }
}
