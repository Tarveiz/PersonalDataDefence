using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DAL.Models;

namespace DAL.Services
{
    public class BackUpSupp
    {
        public string IntegritySupp()
        {
            string path = @"..\..\..\..\DAL\PersonalData.txt";
            StreamReader reader = new StreamReader(path);
            string hash = reader.ReadLine();
            reader.Close();
            return hash;
        }

        public void ChangeDataDAL(DataType Data)
        {
            string path = @"..\..\..\..\DAL\PersonalData.txt";
            StreamWriter writer = new StreamWriter(path);
            foreach (string str in Data.ListStringType)
            {
                writer.Write(str);
            }
            writer.Close();
        }
    }
}
