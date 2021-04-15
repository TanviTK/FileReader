using Repository.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class FileReaderRepo
    {
        public SQLKit SqlKit { get; set; }
        public FileReaderRepo()
        {
            SqlKit = new SQLKit();
        }
        #region FileTable
        public List<FileTableInfo> GetAllUnprocessedFiles()
        {
            return SqlKit.GetDataFromStoreProcedure( "GetUnprocessedFiles");
        }

        public string UpdateFileTableData(int fileId)
        {
            return SqlKit.UpdateFileTable("UpdateFileTable", fileId);
        }
        #endregion 

        #region Mappings
        public List<Mappings> GetMappingData(int settingId)
        {
            return SqlKit.GetMappingDataForSettingId("GetMapForSettingId", settingId);
        }
        #endregion

        #region Output
        public string InsertOutputData(List<Output> outputData)
        {
            return SqlKit.InsertDataIntoOutputTable("InsertDataIntoOutputTable", outputData);
        }
        #endregion
    }
}
