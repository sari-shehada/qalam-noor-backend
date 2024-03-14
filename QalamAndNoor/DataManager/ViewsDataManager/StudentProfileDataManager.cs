using QalamAndNoor.Models;
using QalamAndNoor.MyViews;
using QalamAndNoor.Shared;
using System.Data;
using System.Data.SqlClient;

namespace QalamAndNoor.DataManager.ViewsDataManager
{
    public abstract class StudentProfileDataManager
    {
        #region StudentProfileMapper
        private static StudentProfileView StudentProfileMapper(IDataReader dataReader)
        {
            StudentProfileView tempStudentProfileView = new StudentProfileView()
            {
                StudentId = Convert.ToInt32(dataReader["StudentId"].ToString()),
                StudentFirstName = dataReader["StudentFirstName"].ToString(),
                StudentDateOfBirth = Convert.ToDateTime(dataReader["StudentDateOfBirth"]),
                StudentPlaceOfBirth = dataReader["StudentPlaceOfBirth"].ToString(),
                Gender = Convert.ToBoolean(dataReader["Gender"].ToString()),
                IncidentNumber = dataReader["IncidentNumber"].ToString(),
                IncidentDate = dataReader["IncidentDate"].ToString(),
                PublicRecordId = Convert.ToInt32(dataReader["PublicRecordId"].ToString()),
                PhoneNumber = dataReader["PhoneNumber"].ToString(),
                WhatsappPhoneNumber = dataReader["WhatsappPhoneNumber"].ToString(),
                LandLine = dataReader["Landline"].ToString(),
                JoinDate = Convert.ToDateTime(dataReader["JionDate"].ToString()),
                LeaveDate = dataReader["LeaveDate"].ToString().Trim() == string.Empty ? null : Convert.ToDateTime(dataReader["LeaveDate"].ToString()),
                StudentReligion= (ReligionEnum)Convert.ToInt32(dataReader["StudentReligion"].ToString()),
               //...........................
                FatherFirstName = dataReader["FatherName"].ToString(),
                GrandFatherName = dataReader["GrandFatherName"].ToString(),
                GrandMotherName = dataReader["GrandMotherName"].ToString(),
                LastName = dataReader["LastName"].ToString(),
                FatherTieNumber = dataReader["TieNumber"].ToString(),
                FatherTiePlace = dataReader["TiePlace"].ToString(),
                FatherPhoneNumber = dataReader["FatherPhoneNumber"].ToString(),
                FatherCareer = dataReader["FatherCareer"].ToString(),
                FatherCivilRegisterSecretary = dataReader["FatherCivilRegisterSecretary"].ToString(),
                FatherPermenantAddress = dataReader["FatherPermenantAddress"].ToString(),
                FatherPlaceOfBirth = dataReader["FatherPlaceOfBirth"].ToString(),
                FatherPlaceOfResidence = dataReader["PlaceOfResidence"].ToString(),
                FatherReligion= (ReligionEnum)Convert.ToInt32(dataReader["FatherReligion"].ToString()),
                EducationalStatus = (EducationalStatusEnum)Convert.ToInt32(dataReader["FatherEducationalStatus"].ToString()),
                //...............................
                MotherName= dataReader["MotherName"].ToString(),
                MotherFatherName = dataReader["MotherFatherName"].ToString(),
                MotherMotherName = dataReader["MotherMotherName"].ToString(),
                MotherLastName = dataReader["MotherLastName"].ToString(),
                MotherCareer = dataReader["MotherCareer"].ToString(),
                MotherDateOfBirth = Convert.ToDateTime(dataReader["MotherDateOfBirth"].ToString()),
                MotherDoesLiveWithHasband = Convert.ToBoolean(dataReader["MotherDoesLiveWithHasband"].ToString()),
                MotherEducationalStatus = (EducationalStatusEnum)Convert.ToInt32(dataReader["MotherEducationalStatus"].ToString()),
                MotherPlaceOfBirth = dataReader["MotherPlaceOfBirth"].ToString(),
                MotherTieNumber = dataReader["MotherTieNumber"].ToString(),
                MotherTiePlace = dataReader["MotherTiePlace"].ToString(),
                MotherPhoneNumber = dataReader["MotherPhoneNumber"].ToString(),
                MotherReligion = (ReligionEnum)Convert.ToInt32(dataReader["MotherReligion"].ToString()),
                //..........................
                UserName = dataReader["UserName"].ToString(),
                Password = dataReader["Password"].ToString(),
                //..................
                AddressDetails = dataReader["AddressDetails"].ToString(),
                AddressName = dataReader["AddressName"].ToString(),
                AreaName = dataReader["AreaName"].ToString(),
                CityName = dataReader["CityName"].ToString(),
            };
            return tempStudentProfileView;
        }
        #endregion
   
        #region PublicMethods

        public static List<StudentProfileView> GetStudentProfileViews()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[StudentProfileView]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<StudentProfileView> result = BaseDataManager.GetSPItems<StudentProfileView>(sqlCommand, StudentProfileMapper);
            return result;
        }

        #endregion



    }
}
