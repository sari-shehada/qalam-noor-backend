using QalamAndNoor.Models;
using QalamAndNoor.Models.HelperModels;
using System.Data;
using System.Data.SqlClient;

namespace QalamAndNoor.DataManager.Helper
{
    public abstract class StudentTakenVaccineDataManager
    {
        private static StudentTakenVaccine StudentTakenVaccineMapper(IDataReader dataReader)
        {
            StudentTakenVaccine tempStudentTakenVaccine = new StudentTakenVaccine()
            {
                TakenVaccineId = (int)dataReader["ID"] ,
                VaccineName = dataReader["Name"].ToString(),
                ShotDate = Convert.ToDateTime(dataReader["Date"].ToString()),
                Note = dataReader["Note"].ToString().Trim() == string.Empty ? null : dataReader["Note"].ToString(),

            };
            return tempStudentTakenVaccine;
        }
        public static List<StudentTakenVaccine> GetStudentTakenVaccinesByStudentId(int studentId)
        {
            string sqlStatement = $"select TokenVaccine.ID as \"ID\",Vaccine.Name as \"Name\",TokenVaccine.ShotDate as \"Date\",TokenVaccine.Note as \"Note\" from Vaccine,TokenVaccine where Vaccine.ID=TokenVaccine.VaccineId and TokenVaccine.MedicalRecordId={studentId}";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<StudentTakenVaccine> result = BaseDataManager.GetSPItems(sqlCommand, StudentTakenVaccineMapper);
            return result;
        }
    }
}
