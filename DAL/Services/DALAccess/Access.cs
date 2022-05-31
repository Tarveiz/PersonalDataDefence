using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DAL.Models;

namespace DAL.Services
{
    public class Access
    {
        public DataType IntegritySupp()
        {
            DataType data = new DataType();
            //string path = Directory.GetCurrentDirectory() + @"..\..\..\..\DAL\Services\DALAccess\PersonalData.txt";
            string path = @"..\..\..\..\DAL\Services\DALAccess\PersonalData.txt";
            StreamReader reader = new StreamReader(path);
            string hash = reader.ReadLine();
            reader.Close();
            data.StringType = hash;
            return data;
        }

        public void ChangeDataDAL(DataType Data)
        {
            //string path = Directory.GetCurrentDirectory() + @"\Services\DALAccess\PersonalData.txt";
            string path = @"..\..\..\..\DAL\Services\DALAccess\PersonalData.txt";
            File.WriteAllBytes(path, Data.ByteArray);
        }

        public void GetData()
        {
            
        }
    }
}
