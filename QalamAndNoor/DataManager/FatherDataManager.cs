using QalamAndNoor.Models;
using QalamAndNoor.Shared;
using System.Data;
using System.Data.SqlClient;

namespace QalamAndNoor.DataManager
{
    public abstract class FatherDataManager
    {
        #region Mappers
        private static Father FatherMapper(IDataReader dataReader)
        {
            Father tempFather = new Father()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                FirstName = dataReader["FirstName"].ToString(),
                LastName = dataReader["LastName"].ToString(),
                FatherName = dataReader["FatherName"].ToString(),
                MotherName = dataReader["MotherName"].ToString(),
                Career = dataReader["Career"].ToString(),
                PlaceOfResidence = dataReader["PlaceOfResidence"].ToString(),
                TieNumber = dataReader["TieNumber"].ToString(),
                TiePlace = dataReader["TiePlace"].ToString(),
                PlaceOfBirth = dataReader["PlaceOfBirth"].ToString(),
                DateOfBirth = Convert.ToDateTime(dataReader["DateOfBirth"].ToString()),
                Religion = (ReligionEnum)Convert.ToInt32(dataReader["Religion"].ToString()),
                CivilRegisterSecretary = dataReader["CivilRegisterSecretary"].ToString(),
                EducationalStatus = (EducationalStatusEnum)Convert.ToInt32(dataReader["EducationalStatus"].ToString()),
                PhoneNumber = dataReader["PhoneNumber"].ToString(),
                PermenantAddress = dataReader["PermenantAddress"].ToString(),
            };
            return tempFather;
        }
        #endregion
        #region PublicMethods
        public static List<Father> GetFathers()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[Father]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<Father> result = BaseDataManager.GetSPItems<Father>(sqlCommand, FatherMapper);
            return result;
        }
        public static int InsertFather(Father father)
        {
            if (father == null) return 0;

            string sqlStatement = "INSERT INTO  [dbo].[Father] (FirstName,LastName,FatherName,MotherName," +
                                  "Career,PlaceOfResidence,TieNumber,TiePlace,PlaceOfBirth,DateOfBirth," +
                                  "Religion,CivilRegisterSecretary,EducationalStatus,PhoneNumber,PermenantAddress) " +
                                  "VALUES (@firstName,@lastName,@fatherName,@motherName," +
                                           "@career,@placeOfResidence,@tieNumber,@tiePlace,@placeOfBirth,@DateOfBirth," +
                                           " @religion,@civilRegisterSecretary,@educationalStatus,@phoneNumber,@permenantAddress)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@firstName", father.FirstName));
            sqlCommand.Parameters.Add(new SqlParameter("@LastName", father.LastName));
            sqlCommand.Parameters.Add(new SqlParameter("@fatherName", father.FatherName));
            sqlCommand.Parameters.Add(new SqlParameter("@motherName", father.MotherName));
            sqlCommand.Parameters.Add(new SqlParameter("@career", father.Career));
            sqlCommand.Parameters.Add(new SqlParameter("@placeOfResidence", father.PlaceOfResidence));
            sqlCommand.Parameters.Add(new SqlParameter("@tieNumber", father.TieNumber));
            sqlCommand.Parameters.Add(new SqlParameter("@tiePlace", father.TiePlace));
            sqlCommand.Parameters.Add(new SqlParameter("@placeOfBirth", father.PlaceOfBirth));
            sqlCommand.Parameters.Add(new SqlParameter("@dateOfBirth", father.DateOfBirth));
            sqlCommand.Parameters.Add(new SqlParameter("@religion",(int) father.Religion));
            sqlCommand.Parameters.Add(new SqlParameter("@civilRegisterSecretary",father.CivilRegisterSecretary));
            sqlCommand.Parameters.Add(new SqlParameter("@educationalStatus",(int) father.EducationalStatus));
            sqlCommand.Parameters.Add(new SqlParameter("@phoneNumber", father.PhoneNumber));
            sqlCommand.Parameters.Add(new SqlParameter("@permenantAddress", father.PermenantAddress));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result == 1)
            {
                List<Father> fathers = GetFathers();
                return fathers.Max(x => x.ID);

            }
            return 0;
        }
        public static int UpdateFather(Father father)
        {
            if (father == null) return 0;

            string sqlStatement = "UPDATE  [dbo].[Father] SET " +
                                  "FirstName=@firstName,LastName=@lastName,FatherName=@fatherName,MotherName=@motherName," +
                                  "Career=@career,PlaceOfResidence=@placeOfResidence,TieNumber=@tieNumber,TiePlace=@tiePlace," +
                                  "PlaceOfBirth=@placeOfBirth,DateOfBirth=@dateOfBirth,Religion=@religion,CivilRegisterSecretary=@civilRegisterSecretary," +
                                  "EducationalStatus=@educationalStatus,PhoneNumber=@phoneNumber,PermenantAddress=@permenantAddress " +
                                  "WHERE ID=@id;";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", father.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@firstName", father.FirstName));
            sqlCommand.Parameters.Add(new SqlParameter("@LastName", father.LastName));
            sqlCommand.Parameters.Add(new SqlParameter("@fatherName", father.FatherName));
            sqlCommand.Parameters.Add(new SqlParameter("@motherName", father.MotherName));
            sqlCommand.Parameters.Add(new SqlParameter("@career", father.Career));
            sqlCommand.Parameters.Add(new SqlParameter("@placeOfResidence", father.PlaceOfResidence));
            sqlCommand.Parameters.Add(new SqlParameter("@tieNumber", father.TieNumber));
            sqlCommand.Parameters.Add(new SqlParameter("@tiePlace", father.TiePlace));
            sqlCommand.Parameters.Add(new SqlParameter("@placeOfBirth", father.PlaceOfBirth));
            sqlCommand.Parameters.Add(new SqlParameter("@dateOfBirth", father.DateOfBirth));
            sqlCommand.Parameters.Add(new SqlParameter("@religion", (int)father.Religion));
            sqlCommand.Parameters.Add(new SqlParameter("@civilRegisterSecretary", father.CivilRegisterSecretary));
            sqlCommand.Parameters.Add(new SqlParameter("@educationalStatus", (int)father.EducationalStatus));
            sqlCommand.Parameters.Add(new SqlParameter("@phoneNumber", father.PhoneNumber));
            sqlCommand.Parameters.Add(new SqlParameter("@permenantAddress", father.PermenantAddress));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        public static int DeleteFather(Father father)
        {
            if (father == null) return 0;

            string sqlStatement = "DELETE FROM [dbo].[Father] WHERE ID=@id;";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", father.ID));
           
            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        #endregion
    }
}
