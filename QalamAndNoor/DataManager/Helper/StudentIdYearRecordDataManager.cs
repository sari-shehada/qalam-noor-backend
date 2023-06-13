using QalamAndNoor.Models;
using QalamAndNoor.Models.HelperModels;
using System.Data;
using System.Data.SqlClient;

namespace QalamAndNoor.DataManager.Helper
{
    public abstract class StudentIdYearRecordDataManager
    {
        private static StudentIdYearRecord StudentIdYearRecordMapper(IDataReader dataReader)
        {
            StudentIdYearRecord tempStudentIdYearRecord = new StudentIdYearRecord()
            {
                StudentId = Convert.ToInt32(dataReader["StudentId"].ToString())
            };
            return tempStudentIdYearRecord;
        }
        public static List<StudentIdYearRecord> GetSuccessfulStudentIdsByClassId(int classId)
        {
            //SQL Statement
            string sqlStatement = $"select YearRecord.StudentId as StudentId from YearRecord where YearRecord.DidPass= 1 group by YearRecord.StudentId having MAX(YearRecord.ClassID) = {classId}";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<StudentIdYearRecord> result = BaseDataManager.GetSPItems<StudentIdYearRecord>(sqlCommand, StudentIdYearRecordMapper);
            return result;
        }
        public static List<StudentIdYearRecord> GetFailingStudentIdsByClassId(int classId)
        {
            //SQL Statement
            string sqlStatement = $"select YearRecord.StudentId as StudentId from YearRecord where YearRecord.DidPass= 0  group by YearRecord.StudentId having MAX(YearRecord.ClassID) = {classId}";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<StudentIdYearRecord> result = BaseDataManager.GetSPItems<StudentIdYearRecord>(sqlCommand, StudentIdYearRecordMapper);
            return result;
        }

    }
}
