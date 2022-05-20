using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Services.CoreAccess;
using System.IO;
using BLL.Enum;
using BLL.Models;

namespace BLL.Services.AccountAuth
{
    public class HashCheck
    {

        public AuthStatus Checker(AuthModel model)
        {
            HashProcess UIhash = new HashProcess();
            string UserHash = UIhash.UsersHash(model);
            List<string> resultHashCore = new List<string>();
            Core hashCore = new Core();
            resultHashCore = hashCore.Hash();
            foreach (string str in resultHashCore)
            {
                if (str == "NO_HASH_DATA_IN_CORE")
                {
                    return AuthStatus.NO_HASH_DATA_IN_CORE;
                }
                if (UserHash == str)
                {
                    return AuthStatus.authorized;
                }
            }
            return AuthStatus.notAuthorized;
        }
    }
}
