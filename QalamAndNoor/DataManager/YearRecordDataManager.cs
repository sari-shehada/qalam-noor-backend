using QalamAndNoor.Models;
using System.Data.SqlClient;
using System.Data;
using QalamAndNoor.Shared;

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
                ClassRoomSchoolYearId = dataReader["ClassRoomSchoolYearId"].ToString().Trim() == string.Empty ? null : Convert.ToInt32(dataReader["ClassRoomSchoolYearId"].ToString()),
                Status = (StudentStatusEnum)Convert.ToInt32(dataReader["Status"].ToString()),
                YearGrade = dataReader["YearGrade"].ToString().Trim() == string.Empty ? null : Convert.ToInt32(dataReader["YearGrade"].ToString()),
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
                                  "ClassRoomSchoolYearId,Status,YearGrade) " +
                                  "VALUES (@studentId,@classId,@classRoomSchoolYearId,@status,@yearGrade)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@studentId", yearRecord.StudentId));
            sqlCommand.Parameters.Add(new SqlParameter("@classId", yearRecord.ClassId));
            sqlCommand.Parameters.Add(new SqlParameter("@classRoomSchoolYearId", yearRecord.ClassRoomSchoolYearId == null ? DBNull.Value : yearRecord.ClassRoomSchoolYearId));
            sqlCommand.Parameters.Add(new SqlParameter("@yearGrade", yearRecord.YearGrade == null ? DBNull.Value : yearRecord.YearGrade));
            sqlCommand.Parameters.Add(new SqlParameter("@status", (int)yearRecord.Status));



            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result == 1)
            {
                {
                    List<YearRecord> yearRecords = GetYearRecords();
                    return yearRecords.Max(x => x.ID);
                }
            }
                return 0;
            }
        
        
            public static int UpdateYearRecord(YearRecord yearRecord)
            {
                if (yearRecord == null) return 0;

                string sqlStatement = "UPDATE[dbo].[YearRecord] SET " +
                                      "StudentId=@studentId,ClassId=@classId," +
                                      "ClassRoomSchoolYearId=@classRoomSchoolYearId,Status=@status,YearGrade=@yearGrade " +
                                      "WHERE ID=@id;";


                SqlCommand sqlCommand = new SqlCommand()
                {
                    CommandText = sqlStatement,
                    CommandType = CommandType.Text,
                };
                sqlCommand.Parameters.Add(new SqlParameter("@id", yearRecord.ID));
                sqlCommand.Parameters.Add(new SqlParameter("@studentId", yearRecord.StudentId));
                sqlCommand.Parameters.Add(new SqlParameter("@classId", yearRecord.ClassId));
                sqlCommand.Parameters.Add(new SqlParameter("@classRoomSchoolYearId", yearRecord.ClassRoomSchoolYearId == null ? DBNull.Value : yearRecord.ClassRoomSchoolYearId));
                sqlCommand.Parameters.Add(new SqlParameter("@yearGrade", yearRecord.YearGrade == null ? DBNull.Value : yearRecord.YearGrade));
                sqlCommand.Parameters.Add(new SqlParameter("@status", (int)yearRecord.Status));



                int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
                return result;
            }
            public static int UpdateNullCLassRoomSchoolYearYearRecord(YearRecord yearRecord)
            {
                if (yearRecord == null) return 0;

                string sqlStatement = "UPDATE[dbo].[YearRecord] SET " +
                                      "ClassRoomSchoolYearId=Null;";


                SqlCommand sqlCommand = new SqlCommand()
                {
                    CommandText = sqlStatement,
                    CommandType = CommandType.Text,
                };
                sqlCommand.Parameters.Add(new SqlParameter("@id", yearRecord.ID));
                sqlCommand.Parameters.Add(new SqlParameter("@studentId", yearRecord.StudentId));
                sqlCommand.Parameters.Add(new SqlParameter("@classId", yearRecord.ClassId));
                sqlCommand.Parameters.Add(new SqlParameter("@classRoomSchoolYearId", yearRecord.ClassRoomSchoolYearId == null ? DBNull.Value : yearRecord.ClassRoomSchoolYearId));
                sqlCommand.Parameters.Add(new SqlParameter("@status", (int)yearRecord.Status));



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
            public static List<YearRecord> GetYearRecordsInSchoolYear()
            {
                //SQL Statement
                string sqlStatement = "select * from YearRecord where YearRecord.ClassRoomSchoolYearId in (select ClassRoomSchoolYear.ID from ClassRoomSchoolYear where ClassRoomSchoolYear.SchoolYearId = (select max(SchoolYear.ID)from SchoolYear));\r\n";
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

            #endregion

        }
    }
