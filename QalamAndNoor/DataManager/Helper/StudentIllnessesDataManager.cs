using QalamAndNoor.Models.HelperModels;
using System.Data;
using System.Data.SqlClient;

namespace QalamAndNoor.DataManager.Helper
{
    public abstract class StudentIllnessesDataManager
    {
        private static StudentIllnesses StudentIllnessesMapper(IDataReader dataReader)
        {
            StudentIllnesses tempStudentIllnesses = new StudentIllnesses()
            {
                IllnessesMedicalRecordId = (int)dataReader["ID"],
                IllnessName = dataReader["Name"].ToString(),
                Note = dataReader["Note"].ToString().Trim() == string.Empty ? null : dataReader["Note"].ToString(),

            };
            return tempStudentIllnesses;
        }
        public static List<StudentIllnesses> GetStudentIllnessesByStudentId(int studentId)
        {
            string sqlStatement = $"select Ilness.Name as Name,IlnessMedicalRecord.Note as Note,IlnessMedicalRecord.ID as ID from Ilness,IlnessMedicalRecord where Ilness.ID=IlnessMedicalRecord.IlnessId and IlnessMedicalRecord.MedicalRecordId={studentId}";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<StudentIllnesses> result = BaseDataManager.GetSPItems(sqlCommand, StudentIllnessesMapper);
            return result;
        }
    }
}
