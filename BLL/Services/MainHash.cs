using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using DAL.Models;

namespace BLL.Services
{
    public class MainHash
    {
        public string GetHash(DataType needToBeHashed)
        {
            SHA256 HashAlgorithm = SHA256.Create();
            StringBuilder HashCode = new StringBuilder();

            byte[] hash;
            string result;

            if (needToBeHashed.StringType != null)
            {
                byte[] getBytes = Encoding.ASCII.GetBytes(needToBeHashed.StringType);
                hash = HashAlgorithm.ComputeHash(getBytes);
                foreach (var a in hash)
                {
                    HashCode.Append(a.ToString("X2"));
                }
                result = Convert.ToString(HashCode);
                return result;
            }
            hash = HashAlgorithm.ComputeHash(needToBeHashed.ByteArray);
            foreach (var a in hash)
            {
                HashCode.Append(a.ToString("X2"));
            }
            result = Convert.ToString(HashCode);
            return result;
        }
    }
}
