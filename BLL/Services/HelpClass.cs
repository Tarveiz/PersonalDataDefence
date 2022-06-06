﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Enum;
using DAL.Models;
using DAL.Services.CoreAccess;
using DAL.Services.DALAccess;
using BLL.Services.Encrypt;
using BLL.Models;

namespace BLL.Services
{
    public class HelpClass
    {
        public void SetCoreHashWithForce()
        {
            Core core = new Core();
            DataType data = new DataType();
            DataType data2 = new DataType();
            data = core.GetData(DataStatus.CORE_DATA);
            MainHash hash = new MainHash();
            data2.StringType = hash.GetHash(data);
            core.SetData(data2, DataStatus.CORE_DATA_HASH);
        }

        public void SetNewCoreDataWithForce(string coredata)
        {
            AlgorithmInitialization alg = new AlgorithmInitialization();
            EncryptModel model = new EncryptModel();
            model.UnEncryptedString = coredata;
            DataType data = new DataType();
            data.ByteArray = alg.Encrypt(model);
            Core core = new Core();
            core.SetData(data, DataStatus.CORE_DATA);
        }

        public void SetDALPersonalDataWithForce()
        {
            Access dal = new Access();
            DataType data = new DataType();
            Core core = new Core();
            data = core.GetData(DataStatus.CORE_DATA);
            dal.SetData(data, DataStatus.SET_DATA_TO_DAL);
        }
    }
}
