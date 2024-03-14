using QalamAndNoor.Models;
using System.Data;
using System.Data.SqlClient;

namespace QalamAndNoor.DataManager
{
    public abstract class ClassRoomSchoolYearDataManager
    {
        #region Mappers
        private static ClassRoomSchoolYear ClassRoomSchoolYearMapper(IDataReader dataReader)
        {
            
            
            ClassRoomSchoolYear tempClassRoomSchoolYear = new ClassRoomSchoolYear()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                ClassRoomId = Convert.ToInt32(dataReader["ClassRoomId"].ToString()),
                SchoolYearId = Convert.ToInt32(dataReader["SchoolYearId"].ToString()),
            };
            return tempClassRoomSchoolYear;
        }
        #endregion
        #region PublicMethods
        public static List<ClassRoomSchoolYear> GetClassRoomSchoolYears()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[ClassRoomSchoolYear]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<ClassRoomSchoolYear> result = BaseDataManager.GetSPItems<ClassRoomSchoolYear>(sqlCommand, ClassRoomSchoolYearMapper);
            return result;
        }
        public static int InsertClassRoomSchoolYear(ClassRoomSchoolYear classRoomSchoolYear)
        {
            if (classRoomSchoolYear == null) return 0;

            string sqlStatement = "INSERT INTO  [dbo].[ClassRoomSchoolYear] (ClassRoomId,SchoolYearId) " +
                                  "VALUES (@classRoomId,@schoolYearId)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@classRoomId", classRoomSchoolYear.ClassRoomId));
            sqlCommand.Parameters.Add(new SqlParameter("@schoolYearId", classRoomSchoolYear.SchoolYearId));


            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result == 1)
            {
                List<ClassRoomSchoolYear> classRoomSchools = GetClassRoomSchoolYears();
                return classRoomSchools.Max(x => x.ID);

            }
            return 0;
        }
        public static int UpdateClassRoomSchoolYear(ClassRoomSchoolYear classRoomSchoolYear)
        {
            if (classRoomSchoolYear == null) return 0;

            string sqlStatement = "UPDATE  [dbo].[ClassRoomSchoolYear] SET " +
                                  "ClassRoomId=@classRoomId,SchoolYearId=@schoolYearId " +
                                  "WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", classRoomSchoolYear.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@classRoomId", classRoomSchoolYear.ClassRoomId));
            sqlCommand.Parameters.Add(new SqlParameter("@schoolYearId", classRoomSchoolYear.SchoolYearId));


            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        public static int DeleteClassRoomSchoolYear(ClassRoomSchoolYear classRoomSchoolYear)
        {
            if (classRoomSchoolYear == null) return 0;

            string sqlStatement = "DELETE FROM [dbo].[ClassRoomSchoolYear] WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", classRoomSchoolYear.ID));


            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
     
        #endregion
    }
}
