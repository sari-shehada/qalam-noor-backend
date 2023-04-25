using QalamAndNoor.Models;
using QalamAndNoor.Shared;
using System.Data.SqlClient;
using System.Data;

namespace QalamAndNoor.DataManager
{
    public abstract class PsychologicalStausMedicalRecordDataManager
    {

        #region PsychologicalStatusMedicalRecordMapper
        private static PsychologicalStatusMedicalRecord PsychologicalStatusMedicalRecordMapper(IDataReader dataReader)
        {
            PsychologicalStatusMedicalRecord PsychologicalStatusMedicalRecord = new PsychologicalStatusMedicalRecord()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                MedicalRecordId = Convert.ToInt32(dataReader["MedicalRecordId"].ToString()),
                PsychologicalStatusId = Convert.ToInt32(dataReader["PsychologicalStatusId"].ToString()),
                StatusLevel = (LevelEnum)Convert.ToInt32(dataReader["StatusLevel"].ToString()),

            };
            return PsychologicalStatusMedicalRecord;
        }
        #endregion

        #region PublicMethods
        public static List<PsychologicalStatusMedicalRecord> GetPsychologicalStatusMedicalRecords()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[PsychologicalStatusMedicalRecord]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<PsychologicalStatusMedicalRecord> result = BaseDataManager.GetSPItems<PsychologicalStatusMedicalRecord>(sqlCommand, PsychologicalStatusMedicalRecordMapper);
            return result;
        }

        public static int InsertPsychologicalStatusMedicalRecord(PsychologicalStatusMedicalRecord psychologicalStatusMedicalRecord)
        {
            if (psychologicalStatusMedicalRecord == null) return 0;

            string sqlStatement = "INSERT INTO  [dbo].[PsychologicalStatusMedicalRecord] (MedicalRecordId,PsychologicalStatusId,StatusLevel) " +
                                  "VALUES (@MedicalRecordId,@PsychologicalStatusId,@StatusLevel)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@MedicalRecordId", psychologicalStatusMedicalRecord.MedicalRecordId));
            sqlCommand.Parameters.Add(new SqlParameter("@PsychologicalStatusId", psychologicalStatusMedicalRecord.PsychologicalStatusId));
            sqlCommand.Parameters.Add(new SqlParameter("@StatusLevel", (int)psychologicalStatusMedicalRecord.StatusLevel));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result == 1)
            {
                List<PsychologicalStatusMedicalRecord> psychologicalStatusMedicalRecords = GetPsychologicalStatusMedicalRecords();
                return psychologicalStatusMedicalRecords.Max(x => x.ID);

            }
            return 0;
        }

        public static int UpdatePsychologicalStatusMedicalRecord(PsychologicalStatusMedicalRecord psychologicalStatusMedicalRecord)
        {

            if (psychologicalStatusMedicalRecord == null) return 0;
            //SQL Statement
            string sqlStatement = "UPDATE  [dbo].[PsychologicalStatusMedicalRecord] SET " +
                                  "Name=@name,AreaId=@areaId,Details=@details " +
                                  "WHERE ID=@id;";

            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", psychologicalStatusMedicalRecord.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@MedicalRecordId", psychologicalStatusMedicalRecord.MedicalRecordId));
            sqlCommand.Parameters.Add(new SqlParameter("@PsychologicalStatusId", psychologicalStatusMedicalRecord.PsychologicalStatusId));
            sqlCommand.Parameters.Add(new SqlParameter("@StatusLevel", (int)psychologicalStatusMedicalRecord.StatusLevel));

            //Execute Query
            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        public static int DeletePsychologicalStatusMedicalRecord(PsychologicalStatusMedicalRecord psychologicalStatusMedicalRecord)
        {
            if (psychologicalStatusMedicalRecord == null) return 0;
            //SQL Statement
            string sqlStatement = "DELETE FROM [dbo].[PsychologicalStatusMedicalRecord] WHERE ID=@id;";

            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };


            sqlCommand.Parameters.Add(new SqlParameter("@id", psychologicalStatusMedicalRecord.ID));
            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }

        #endregion
    }
}
