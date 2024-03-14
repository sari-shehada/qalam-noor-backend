using QalamAndNoor.Models;
using System.Data.SqlClient;
using System.Data;
using QalamAndNoor.Manager;

namespace QalamAndNoor.DataManager
{
    public abstract class SchoolYearDataManager
    {
        #region Mappers
        private static SchoolYear SchoolYearMapper(IDataReader dataReader)
        {
            SchoolYear tempSchoolYear = new SchoolYear()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                Name = dataReader["Details"].ToString()!,
                IsFinished = Convert.ToBoolean(dataReader["IsDone"].ToString()),
                PreviousSchoolYearId = dataReader["PreviousSchoolYearId"].ToString().Trim() == string.Empty ? null : Convert.ToInt32(dataReader["PreviousSchoolYearId"].ToString()),
            };
            return tempSchoolYear;
        }
        #endregion
        // #region Public Methods
        #region PublicMethods
        public static List<SchoolYear> GetSchoolYears()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[SchoolYear]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<SchoolYear> result = BaseDataManager.GetSPItems<SchoolYear>(sqlCommand, SchoolYearMapper);
            return result;
        }
        public static object InsertSchoolYear(SchoolYear schoolYear)
        {
            SchoolYear schoolYear1 = SchoolYearManager.GetCurrentSchoolYear();
            if (schoolYear1 is null||schoolYear1.IsFinished==true)
          {
                if (schoolYear == null) return 0;

                string sqlStatement = "INSERT INTO  [dbo].[SchoolYear] (Details,IsDone,PreviousSchoolYearId) " +
                                      "VALUES (@name,@isDone,@previousSchoolYearId)";


                SqlCommand sqlCommand = new SqlCommand()
                {
                    CommandText = sqlStatement,
                    CommandType = CommandType.Text
                };
                sqlCommand.Parameters.Add(new SqlParameter("@name", schoolYear.Name));
                sqlCommand.Parameters.Add(new SqlParameter("@isDone", schoolYear.IsFinished ? '1' : '0'));
                sqlCommand.Parameters.Add(new SqlParameter("@previousSchoolYearId", schoolYear.PreviousSchoolYearId == null ? DBNull.Value : schoolYear.PreviousSchoolYearId));
                int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
                if (result == 1)
                {
                    List<SchoolYear> schoolYears = GetSchoolYears();

                    return new
                    {
                        message = "تمت اضافة عام دراسي جديد بنجاح",
                        schoolYearId = schoolYears.Max(x => x.ID)
                    };

                }
                return new
                {
                    message = " فشلت عملية اضافة عام دراسي جديد ",
                    schoolYearId =0
                };
           }
            return new
            {
                message = " لا يمكن اضافة عام دراسي قبل انتهاء العام الحالي",
                schoolYearId = 0
            };


        }
        public static int UpdateSchoolYear(SchoolYear schoolYear)
        {
            if (schoolYear == null) return 0;

            string sqlStatement = "UPDATE  [dbo].[SchoolYear] SET " +
                                  "Details=@name, IsDone=@isDone, PreviousSchoolYearId=@previousSchoolYearId " +
                                  "WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", schoolYear.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@name", schoolYear.Name));
            sqlCommand.Parameters.Add(new SqlParameter("@isDone", schoolYear.IsFinished ? '1' : '0'));
            sqlCommand.Parameters.Add(new SqlParameter("@previousSchoolYearId", schoolYear.PreviousSchoolYearId == null
                                                                                ? DBNull.Value : schoolYear.PreviousSchoolYearId));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        public static int DeleteSchoolYear(SchoolYear schoolYear)
        {
            if (schoolYear == null) return 0;

            string sqlStatement = "DELETE FROM [dbo].[SchoolYear] WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", schoolYear.ID));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        public static List<SchoolYear> GetSchoolYearsByStudentId(int studentId)
        {
            //SQL Statement
            string sqlStatement = $"select * from SchoolYear where SchoolYear.ID in (select ClassRoomSchoolYear.SchoolYearId from ClassRoomSchoolYear where ClassRoomSchoolYear.SchoolYearId=SchoolYear.ID and ClassRoomSchoolYear.ID in (select YearRecord.ClassRoomSchoolYearId from YearRecord where YearRecord.ClassRoomSchoolYearId=ClassRoomSchoolYear.ID and YearRecord.StudentId={studentId}))";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<SchoolYear> result = BaseDataManager.GetSPItems<SchoolYear>(sqlCommand, SchoolYearMapper);
            return result;
        }

        #endregion
    }
}
