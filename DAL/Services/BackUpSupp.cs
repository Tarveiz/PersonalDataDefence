using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DAL.Services
{
    public class BackUpSupp
    {
        public string IntegritySupp()
        {
            string path = @"..\..\..\..\DAL\PersonalData.txt";
            StreamReader reader = new StreamReader(path);
            string hash = reader.ReadLine();
            return hash;
        }
    }
}
