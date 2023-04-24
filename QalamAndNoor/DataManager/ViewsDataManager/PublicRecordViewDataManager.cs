using QalamAndNoor.Models;
using QalamAndNoor.MyViews;
using System.Data;
using System.Data.SqlClient;

namespace QalamAndNoor.DataManager.ViewsDataManager
{
    public abstract class PublicRecordViewDataManager
    {
        #region Mappers
        private static PublicRecordView PublicRecordViewMapper(IDataReader dataReader)
        {
            PublicRecordView tempPublicRecordView = new PublicRecordView()
            {
                PublicRecordId = Convert.ToInt32(dataReader["PublicRecordId"].ToString()),
                ClassId =Convert.ToInt32( dataReader["Class"].ToString()),
                StudentFirstName = dataReader["StudentFirstName"].ToString(),
                FatherName = dataReader["FatherName"].ToString(),
                GrandFatherName = dataReader["GranFatherName"].ToString(),
                StudentLastName = dataReader["StudentLastName"].ToString(),
                MotherName = dataReader["MotherName"].ToString(),
                StudentGender = Convert.ToBoolean(dataReader["StudentGender"].ToString()),
                StudentPlaceOfBirth = dataReader["StudentPlaceOfBirth"].ToString(),
                StudentDateOfBirth = Convert.ToDateTime(dataReader["StudentDateOfBirth"].ToString()),
                StudentPhoneNumber = dataReader["StudentPhoneNumber"].ToString(),
                StudentWhataappPhoneNumber = dataReader["StudentWhataappPhoneNumber"].ToString(),
                StudentLandLine = dataReader["StudentLandLine"].ToString(),
                TieNumber = dataReader["TieNumber"].ToString(),
                TiePlace = dataReader["TiePlace"].ToString(),
                CityName = dataReader["CityName"].ToString(),
                AreaName = dataReader["AreaName"].ToString(),
                AddressName = dataReader["AddressName"].ToString(),
            };
            return tempPublicRecordView;
        }
        #endregion

        #region PublicMethods

        public static List<PublicRecordView> GetPublicRecordViews()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[PublicRecordView]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<PublicRecordView> result = BaseDataManager.GetSPItems<PublicRecordView>(sqlCommand, PublicRecordViewMapper);
            return result;
        }

        #endregion
    }
}
