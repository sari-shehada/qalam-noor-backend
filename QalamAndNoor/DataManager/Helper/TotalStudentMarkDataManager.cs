using QalamAndNoor.Models;
using QalamAndNoor.Models.HelperModels.DbHelper;
using System.Data;
using System.Data.SqlClient;

namespace QalamAndNoor.DataManager.Helper
{
    public abstract class TotalStudentMarkDataManager
    {
        private static TotalStudentMark TotalStudentMarksMapper(IDataReader dataReader)
        {
            TotalStudentMark tempTotalStudentMarks = new TotalStudentMark()
            {
                CourseId = Convert.ToInt32(dataReader["CourseId"].ToString()),
                CourseName = dataReader["Name"].ToString(),
                RequiredToPass = Convert.ToBoolean(dataReader["RequiredToPass"].ToString()),
                RequiredGradeToPass = Convert.ToInt32(dataReader["RequiredGradeToPass"].ToString()),
                AverageGrade = Convert.ToDouble(dataReader["AverageGrade"].ToString()),
                DidPass = Convert.ToBoolean(dataReader["DidPass"].ToString()),

            };
            return tempTotalStudentMarks;
        }
        public static List<TotalStudentMark> GetTotalStudentMarksByStudentIdAndSchoolYearId(int schoolYearId,int studentId)
        {
            //SQL Statement
            string sqlStatement = $"Execute StudentTotalScores {schoolYearId},{studentId}";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<TotalStudentMark> result = BaseDataManager.GetSPItems<TotalStudentMark>(sqlCommand, TotalStudentMarksMapper);
            return result;
        }



    }
}
