using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BLL.Services
{
    public class MainHash
    {
        public string GetHash(string compile)
        {
            MD5 AlgorithmMD5 = MD5.Create();
            byte[] getBytes = Encoding.ASCII.GetBytes(compile);
            byte[] hash = AlgorithmMD5.ComputeHash(getBytes);
            StringBuilder HashCode = new StringBuilder();
            foreach (var a in hash)
            {
                HashCode.Append(a.ToString("X2"));
            }
            string result = Convert.ToString(HashCode);
            return result;
        }
    }
}
