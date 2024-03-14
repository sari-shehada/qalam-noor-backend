using QalamAndNoor.Models;
using System.Data;
using System.Data.SqlClient;

namespace QalamAndNoor.DataManager
{
    public abstract class MedicalRecordDataManager
    {
        #region Mappers
        private static MedicalRecord MedicalRecordMapper(IDataReader dataReader)
        {
            MedicalRecord tempMedicalRecord = new MedicalRecord()
            {
                StudentId = Convert.ToInt32(dataReader["StudentId"].ToString()),
                StudentHight = Convert.ToDouble(dataReader["StudentHeight"].ToString()),
                StudentWeight = Convert.ToDouble(dataReader["StudentWeight"].ToString()),
            };
            return tempMedicalRecord;
        }
        #endregion
      
        #region PublicMethods
        public static List<MedicalRecord> GetMedicalRecords()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[MedicalRecord]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<MedicalRecord> result = BaseDataManager.GetSPItems<MedicalRecord>(sqlCommand, MedicalRecordMapper);
            return result;
        }

        public static int InsertMedicalRecord(MedicalRecord medicalRecord)
        {
            if (medicalRecord == null) return 0;

            string sqlStatement = "INSERT INTO  [dbo].[MedicalRecord] (StudentId,StudentHeight,StudentWeight) " +
                                  "VALUES (@studentId,@studentHeight,@studentWeight)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@studentId", medicalRecord.StudentId));
            sqlCommand.Parameters.Add(new SqlParameter("@studentHeight", medicalRecord.StudentHight));
            sqlCommand.Parameters.Add(new SqlParameter("@studentWeight", medicalRecord.StudentWeight));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result == 1)
            {
                List<MedicalRecord> medicalRecords = GetMedicalRecords();
                return medicalRecords.Max(x => x.StudentId);

            }
            return 0;
        }

        public static int UpdateMedicalRecord(MedicalRecord medicalRecord)
        {
            if (medicalRecord == null) return 0;

            string sqlStatement = "UPDATE  [dbo].[MedicalRecord] SET " +
                                  "StudentHeight=@studentHeight,StudentWeight=@studentWeight " +
                                  "WHERE StudentId=@studentId;";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@studentId", medicalRecord.StudentId));
            sqlCommand.Parameters.Add(new SqlParameter("@studentHeight", medicalRecord.StudentHight));
            sqlCommand.Parameters.Add(new SqlParameter("@studentWeight", medicalRecord.StudentWeight));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }

        public static int DeleteMedicalRecord(MedicalRecord medicalRecord)
        {
            if (medicalRecord == null) return 0;

            string sqlStatement = "DELETE FROM [dbo].[MedicalRecord] WHERE StudentId=@studentId;";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@studentId", medicalRecord.StudentId));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        #endregion
    }
}
