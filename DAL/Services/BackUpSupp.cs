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
        public DataType IntegritySupp()
        {
            DataType data = new DataType();
            string path = @"..\..\..\..\DAL\PersonalData.txt";
            StreamReader reader = new StreamReader(path);
            string hash = reader.ReadLine();
            reader.Close();
            data.StringType = hash;
            return data;
        }

        public void ChangeDataDAL(DataType Data)
        {
            string path = @"..\..\..\..\DAL\PersonalData.txt";
            File.WriteAllBytes(path, Data.ByteArray);
        }
    }
}
