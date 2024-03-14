using QalamAndNoor.Models;
using QalamAndNoor.Models.HelperModels;
using System.Data;
using System.Data.SqlClient;

namespace QalamAndNoor.DataManager.Helper
{
    public abstract class PsychologicalStatusStudentCountDataManager
    {
        #region Mappers
        private static PsychologicalStatusStudentCount PsychologicalStatusStudentCountMapper(IDataReader dataReader)
        {
            PsychologicalStatusStudentCount tempPsychologicalStatusStudentCount = new PsychologicalStatusStudentCount()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                StudentsCount = Convert.ToInt32(dataReader["CountStudent"].ToString()),
                PsychologicalStatusName = dataReader["Name"].ToString(),
            };
            return tempPsychologicalStatusStudentCount;
        }
        #endregion
        public static List<PsychologicalStatusStudentCount> GetPsychologicalStatusStudentCount()
        {
            //SQL Statement
            string sqlStatement = "select PsychologicalStatus.ID as ID,PsychologicalStatus.Name as Name,count(Student.ID) as CountStudent from Student,PsychologicalStatus,PsychologicalStatusMedicalRecord,MedicalRecord where PsychologicalStatus.ID=PsychologicalStatusMedicalRecord.PsychologicalStatusId and PsychologicalStatusMedicalRecord.MedicalRecordId=MedicalRecord.StudentId and MedicalRecord.StudentId=Student.ID group By PsychologicalStatus.Name,PsychologicalStatus.ID";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<PsychologicalStatusStudentCount> result = BaseDataManager.GetSPItems<PsychologicalStatusStudentCount>(sqlCommand, PsychologicalStatusStudentCountMapper);
            result = result.OrderBy((a) => a.StudentsCount).ToList();
            result.Reverse();
            return result;
        }
        public static List<PsychologicalStatusStudentCount> GetPsychologicalStatusMaleStudentCount()
        {
            //SQL Statement
            string sqlStatement = "select PsychologicalStatus.ID as ID,PsychologicalStatus.Name as Name,count(Student.ID) as CountStudent from Student,PsychologicalStatus,PsychologicalStatusMedicalRecord,MedicalRecord where PsychologicalStatus.ID=PsychologicalStatusMedicalRecord.PsychologicalStatusId and PsychologicalStatusMedicalRecord.MedicalRecordId=MedicalRecord.StudentId and MedicalRecord.StudentId=Student.ID and Student.IsMale=1 group By PsychologicalStatus.Name,PsychologicalStatus.ID";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<PsychologicalStatusStudentCount> result = BaseDataManager.GetSPItems<PsychologicalStatusStudentCount>(sqlCommand, PsychologicalStatusStudentCountMapper);
            result = result.OrderBy((a) => a.StudentsCount).ToList();
            result.Reverse();
            return result;
        }
        public static List<PsychologicalStatusStudentCount> GetPsychologicalStatusFemaleStudentCount()
        {
            //SQL Statement
            string sqlStatement = "select PsychologicalStatus.ID as ID,PsychologicalStatus.Name as Name,count(Student.ID) as CountStudent from Student,PsychologicalStatus,PsychologicalStatusMedicalRecord,MedicalRecord where PsychologicalStatus.ID=PsychologicalStatusMedicalRecord.PsychologicalStatusId and PsychologicalStatusMedicalRecord.MedicalRecordId=MedicalRecord.StudentId and MedicalRecord.StudentId=Student.ID and Student.IsMale=0 group By PsychologicalStatus.Name,PsychologicalStatus.ID";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<PsychologicalStatusStudentCount> result = BaseDataManager.GetSPItems<PsychologicalStatusStudentCount>(sqlCommand, PsychologicalStatusStudentCountMapper);
            result = result.OrderBy((a) => a.StudentsCount).ToList();
            result.Reverse();
            return result;
        }
    }
}
