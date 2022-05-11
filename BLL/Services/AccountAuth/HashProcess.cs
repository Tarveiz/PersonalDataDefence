﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using BLL.Models;

namespace BLL.Services.AccountAuth
{
    public class HashProcess
    {
        public void UsersHash(AuthModel model)
        {
            string compile = model.Login + model.Password;
            MD5 AlgorithmMD5 = MD5.Create();

            byte[] getBytes = Encoding.ASCII.GetBytes(compile);
            byte[] hash = AlgorithmMD5.ComputeHash(getBytes);

            StringBuilder HashCode = new StringBuilder();
            foreach (var a in hash)
            {
                HashCode.Append(a.ToString("X2"));
            }

            HashCheck req = new HashCheck();
            req.UserHash(Convert.ToString(HashCode));
        }
    }
}