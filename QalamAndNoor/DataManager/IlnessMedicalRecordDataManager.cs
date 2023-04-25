using QalamAndNoor.Models;
using System.Data;
using System.Data.SqlClient;

namespace QalamAndNoor.DataManager
{
    public abstract class IlnessMedicalRecordDataManager
    {
        #region Mappers
        private static IlnessMedicalRecord IlnessMedicalRecordMapper(IDataReader dataReader)
        {
            IlnessMedicalRecord tempIlnessMedicalRecord = new IlnessMedicalRecord()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                IlnessId = Convert.ToInt32(dataReader["IlnessId"].ToString()),
                MedicalRecordId = Convert.ToInt32(dataReader["MedicalRecordId"].ToString()),
                Note = dataReader["Note"].ToString().Trim() == string.Empty ? null : dataReader["Note"].ToString(),
            };
            return tempIlnessMedicalRecord;
        }
        #endregion
        #region PublicMethods
        public static List<IlnessMedicalRecord> GetIlnessMedicalRecords()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[IlnessMedicalRecord]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<IlnessMedicalRecord> result = BaseDataManager.GetSPItems<IlnessMedicalRecord>(sqlCommand, IlnessMedicalRecordMapper);
            return result;
        }

        public static int InsertIlnessMedicalRecord(IlnessMedicalRecord ilnessMedical)
        {
            if (ilnessMedical == null) return 0;

            string sqlStatement = "INSERT INTO  [dbo].[IlnessMedicalRecord] (IlnessId,MedicalRecordId,Note) " +
                                  "VALUES (@ilnessId,@medicalRecordId,@note)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@ilnessId", ilnessMedical.IlnessId));
            sqlCommand.Parameters.Add(new SqlParameter("@medicalRecordId", ilnessMedical.MedicalRecordId));
            sqlCommand.Parameters.Add(new SqlParameter("@note", ilnessMedical.Note == null ? DBNull.Value : ilnessMedical.Note));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result == 1)
            {
                List<IlnessMedicalRecord> ilnessMedicals = GetIlnessMedicalRecords();
                return ilnessMedicals.Max(x => x.ID);

            }
            return 0;
        }
        public static int UpdateIlnessMedicalRecord(IlnessMedicalRecord ilnessMedical)
        {
            if (ilnessMedical == null) return 0;

            string sqlStatement = "UPDATE  [dbo].[IlnessMedicalRecord] SET " +
                                  "IlnessId=@ilnessId,MedicalRecordId=@medicalRecordId,Note=@note " +
                                  "WHERE ID=@id;";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", ilnessMedical.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@ilnessId", ilnessMedical.IlnessId));
            sqlCommand.Parameters.Add(new SqlParameter("@medicalRecordId", ilnessMedical.MedicalRecordId));
            sqlCommand.Parameters.Add(new SqlParameter("@note", ilnessMedical.Note == null ? DBNull.Value : ilnessMedical.Note));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        public static int DeleteIlnessMedicalRecord(IlnessMedicalRecord ilnessMedical)
        {
            if (ilnessMedical == null) return 0;

            string sqlStatement = "DELETE FROM [dbo].[IlnessMedicalRecord] WHERE ID=@id;";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", ilnessMedical.ID));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }

        #endregion
    }
}
