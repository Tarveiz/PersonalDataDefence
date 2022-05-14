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
                if (UIhash == str)
                {
                    return AuthStatus.authorized;
                }
                else
                {
                    return AuthStatus.notAuthorized;
                }
            }
        }
    }
}
