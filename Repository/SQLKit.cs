using Repository.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SQLKit
    {
        public string Server { get; set; }
        public string DataBase { get; set; }
        public SQLKit()
        {
            Server = "DESKTOP-4MJJDLT";
            DataBase = "Hemanth_All_Test";
        }
        public string GetConnectionString()
        {
            string ConnString = "";
            try
            {
                SqlConnectionStringBuilder csBuilder = new SqlConnectionStringBuilder();
                if (!String.IsNullOrWhiteSpace(DataBase))
                {
                    csBuilder.InitialCatalog = DataBase;
                }
                csBuilder.DataSource = Server;
                csBuilder.PersistSecurityInfo = false;
                csBuilder.IntegratedSecurity = true;
                ConnString = csBuilder.ConnectionString;
            }
            catch (Exception ex)
            {
                ConnString = "";
            }
            return ConnString;
        }
      
        public  List<FileTableInfo> GetDataFromStoreProcedure(string procedureName)
        {
            string ConnectionStr = this.GetConnectionString();
           
            SqlConnection connection = new SqlConnection(ConnectionStr);

            SqlCommand command = new SqlCommand(procedureName, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<FileTableInfo> fileTableList = new List<FileTableInfo>();
            FileTableInfo fileTableInfo = null;

            while (reader.Read())
            {
                fileTableInfo = new FileTableInfo();
                fileTableInfo.FileId = Convert.ToInt32(reader["FileId"].ToString());
                fileTableInfo.ReceviedDate = Convert.ToDateTime(reader["ReceviedDate"]);
                fileTableInfo.FileLocation = reader["FileLocation"].ToString();
                fileTableInfo.IsProcessed = Convert.ToBoolean(reader["IsProcessed"]);
                fileTableInfo.SettingId = Convert.ToInt32(reader["SettingId"].ToString());
                fileTableList.Add(fileTableInfo);
            }

           return fileTableList;
        }

        public List<Mappings> GetMappingDataForSettingId(string procedureName, int settingId)
        {
            string ConnectionStr = this.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                using (SqlCommand command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@id", SqlDbType.Int).Value = settingId;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    List<Mappings> mappingList = new List<Mappings>();
                    Mappings mappingInfo = null;

                    while (reader.Read())
                    {
                        mappingInfo = new Mappings();
                        mappingInfo.MappingId = Convert.ToInt32(reader["MappingId"].ToString());
                        mappingInfo.MapType = reader["MapType"].ToString();
                        mappingInfo.MapName = reader["MapName"].ToString();
                        mappingInfo.ExecutionType = reader["ExecutionType"].ToString();
                        mappingInfo.SettingId = Convert.ToInt32(reader["SettingId"].ToString());
                        mappingList.Add(mappingInfo);
                    }

                    return mappingList;
                }
            }
        }
        public string  InsertDataIntoOutputTable(string procedureName, List<Output> outputDataList)
        {
            try
            {
                string ConnectionStr = this.GetConnectionString();
                using (SqlConnection connection = new SqlConnection(ConnectionStr))
                {
                    foreach (Output outputData in outputDataList)
                    {
                        using (SqlCommand command = new SqlCommand(procedureName, connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@dataType", outputData.DataType);
                            command.Parameters.AddWithValue("@outVal", outputData.Value);
                            command.Parameters.AddWithValue("@fileId", outputData.FileId);
                            connection.Open();
                            int result = command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                }
                return "Successfully added the data to outputtable";
            }
            catch (Exception ex)
            {
                return $"Error : {ex.Message}";
            }            
        }

        public string UpdateFileTable( string procedureName,int fileId)
        {
            try
            {
                string ConnectionStr = this.GetConnectionString();
                using (SqlConnection connection = new SqlConnection(ConnectionStr))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(procedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id", fileId);
                        command.ExecuteNonQuery();
                    }

                }
                return "Successfully updated the isProcessed column";
            }
            catch (Exception ex)
            {
                return $"Error : {ex.Message}";
            }
        }
    }
    
}
