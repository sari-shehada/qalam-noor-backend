using QalamAndNoor.Models;
using System.Data.SqlClient;
using System.Data;

namespace QalamAndNoor.DataManager
{
    public abstract class YearRecordDataManager
    {
        #region Mappers
        private static YearRecord YearRecordMapper(IDataReader dataReader)
        {
            YearRecord tempYearRecord = new YearRecord()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                StudentId = Convert.ToInt32(dataReader["StudentId"].ToString()),
                ClassId = Convert.ToInt32(dataReader["ClassId"].ToString()),
                ClassRoomSchoolYearId = Convert.ToInt32(dataReader["ClassRoomSchoolYearId"].ToString()),
                DidPass = Convert.ToBoolean(dataReader["DidPass"].ToString()),
            };
            return tempYearRecord;
        }
        #endregion

        #region PublicMethod

        public static List<YearRecord> GetYearRecords()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[YearRecord]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<YearRecord> result = BaseDataManager.GetSPItems<YearRecord>(sqlCommand, YearRecordMapper);
            return result;
        }
        public static int InsertYearRecord(YearRecord yearRecord)
        {
            if (yearRecord == null) return 0;

            string sqlStatement = "INSERT INTO  [dbo].[YearRecord](StudentId,ClassId," +
                                  "ClassRoomSchoolYearId,DidPass) " +
                                  "VALUES (@studentId,@classId,@classRoomSchoolYearId,@didPass)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@studentId", yearRecord.StudentId));
            sqlCommand.Parameters.Add(new SqlParameter("@classId", yearRecord.ClassId));
            sqlCommand.Parameters.Add(new SqlParameter("@classRoomSchoolYearId", yearRecord.ClassRoomSchoolYearId));
            sqlCommand.Parameters.Add(new SqlParameter("@didPass", yearRecord.DidPass ? "1" : "0"));



            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result==1)
            {
                List<YearRecord> yearRecords = GetYearRecords();
                return yearRecords.Max(x => x.ID);
            }
            return 0;
        }
        public static int UpdateYearRecord(YearRecord yearRecord)
        {
            if (yearRecord == null) return 0;

            string sqlStatement = "UPDATE[dbo].[YearRecord] SET " +
                                  "StudentId=@studentId,ClassId=@classId," +
                                  "ClassRoomSchoolYearId=@classRoomSchoolYearId,DidPass=@didPass " +
                                  "WHERE ID=@id;";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", yearRecord.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@studentId", yearRecord.StudentId));
            sqlCommand.Parameters.Add(new SqlParameter("@classId", yearRecord.ClassId));
            sqlCommand.Parameters.Add(new SqlParameter("@classRoomSchoolYearId", yearRecord.ClassRoomSchoolYearId));
            sqlCommand.Parameters.Add(new SqlParameter("@didPass", yearRecord.DidPass ? "1" : "0"));



            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        public static int DeleteYearRecord(YearRecord yearRecord)
        {
            if (yearRecord == null) return 0;
            //SQL Statement
            string sqlStatement = "DELETE FROM [dbo].[YearRecord] WHERE ID=@id;";

            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };


            sqlCommand.Parameters.Add(new SqlParameter("@id", yearRecord.ID));
            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }

        #endregion

    }
}
