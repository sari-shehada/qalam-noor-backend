using QalamAndNoor.Models;
using System.Data;
using System.Data.SqlClient;

namespace QalamAndNoor.DataManager
{
    public abstract class SemesterYearRecordDataManager
    {
        #region Mappers
        private static SemesterYearRecord SemesterYearRecordMapper(IDataReader dataReader)
        {
            SemesterYearRecord tempSemesterYearRecord = new SemesterYearRecord()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                SemesterId = Convert.ToInt32(dataReader["SemesterId"].ToString()),
                YearRecordId = Convert.ToInt32(dataReader["YearRecordId"].ToString()),

            };
            return tempSemesterYearRecord;
        }
        #endregion
        public static List<SemesterYearRecord> GetSemesterYearRecords()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[SemesterYearRecord]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<SemesterYearRecord> result = BaseDataManager.GetSPItems<SemesterYearRecord>(sqlCommand, SemesterYearRecordMapper);
            return result;
        }
        public static int InsertSemesterYearRecord(SemesterYearRecord semesterYearRecord)
        {
            if (semesterYearRecord == null) return 0;

            string sqlStatement = "INSERT INTO  [dbo].[SemesterYearRecord] (SemesterId,YearRecordId) " +
                                  "VALUES (@semesterId,@yearRecordId)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@semesterId", semesterYearRecord.SemesterId));
            sqlCommand.Parameters.Add(new SqlParameter("@yearRecordId", semesterYearRecord.YearRecordId));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result == 1)
            {
                List<SemesterYearRecord> semesterYearRecords = GetSemesterYearRecords();
                return semesterYearRecords.Max(x => x.ID);

            }
            return 0;
        }
        public static int UpdateSemesterYearRecord(SemesterYearRecord semesterYearRecord)
        {
            if (semesterYearRecord == null) return 0;

            string sqlStatement = "UPDATE  [dbo].[SemesterYearRecord] SET " +
                                  "SemesterId=@semesterId,YearRecordId=@yearRecordId " +
                                  "WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", semesterYearRecord.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@semesterId", semesterYearRecord.SemesterId));
            sqlCommand.Parameters.Add(new SqlParameter("@yearRecordId", semesterYearRecord.YearRecordId));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        public static int DeleteSemesterYearRecord(SemesterYearRecord semesterYearRecord)
        {
            if (semesterYearRecord == null) return 0;

            string sqlStatement = "DELETE FROM [dbo].[SemesterYearRecord] WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", semesterYearRecord.ID));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
    }
}
