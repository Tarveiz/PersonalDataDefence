using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Services.CoreAccess;
using System.IO;
using BLL.Enum;
using BLL.Models;
using DAL.Enum;
using DAL.Models;

namespace BLL.Services.AccountAuth
{
    public class HashCheck
    {

        public AuthStatus Checker(AuthModel model)
        {
            HashProcess UIhash = new HashProcess();
            DataType data = new DataType();
            Core hashCore = new Core();
            List<string> resultHashCore = new List<string>();
            //List<string> List = new List<string>();
            string UserHash = UIhash.UsersHash(model);
            string word = "";

            data = hashCore.GetData(DataStatus.USERS_HASH);

            if (data.StringType == null)
            {
                return AuthStatus.NO_HASH_DATA_IN_CORE;
            }

            //Проверка листа с хешами из CORE`а
            //foreach (string line in List)
            //{
            //    foreach (char i in line)
            //    {
            //        if (i == ';')
            //        {
            //            resultHashCore.Add(word);
            //            word = "";
            //        }
            //        else
            //        {
            //            word += i;
            //        }
            //    }
            //}


            foreach (char i in data.StringType)
            {
                if (i == ';')
                {
                    resultHashCore.Add(word);
                    word = "";
                }
                else
                {
                    word += i;
                }
            }



            foreach (string str in resultHashCore)
            {
                if (UserHash == str)
                {
                    return AuthStatus.authorized;
                }
            }
            return AuthStatus.notAuthorized;
        }
    }
}
