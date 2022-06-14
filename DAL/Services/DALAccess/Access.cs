using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DAL.Models;
using DAL.Enum.ErrorType;
using DAL.Enum;

namespace DAL.Services.DALAccess
{
    public class Access
    {
        public DataType GetData(DataStatus state)
        {
            DataType data = new DataType();
            switch (state)
            {
                case DataStatus.GET_DATA_FROM_DAL:
                    //string path = Directory.GetCurrentDirectory() + @"..\..\..\..\DAL\Services\DALAccess\PersonalData.txt";
                    string path = @"..\..\..\..\DAL\Services\DALAccess\PersonalData.txt";
                    data.ByteArray = File.ReadAllBytes(path);
                    return data;
            }
            data.Error = ErrorType.DATA_TYPE_ERROR;
            return data;
        }
        public void SetData(DataType data, DataStatus state)
        {
            switch (state)
            {
                case DataStatus.SET_DATA_TO_DAL:
                    //string path = Directory.GetCurrentDirectory() + @"\Services\DALAccess\PersonalData.txt";
                    string path = @"..\..\..\..\DAL\Services\DALAccess\PersonalData.txt";
                    File.WriteAllBytes(path, data.ByteArray);
                    break;
            }
        }
    }
}
