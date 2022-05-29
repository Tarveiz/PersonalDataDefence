using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using BLL.Models;
using DAL.Models;

namespace BLL.Services.AccountAuth
{
    public class HashProcess
    {
        public string UsersHash(AuthModel model)
        {
            string compile = model.Login + model.Password;
            MainHash getHash = new MainHash();
            DataType modelForGetHash = new DataType();
            modelForGetHash.StringType = compile;
            string result = getHash.GetHash(modelForGetHash);
            return result;
        }
    }
}
