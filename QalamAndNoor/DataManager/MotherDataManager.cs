using QalamAndNoor.Models;
using QalamAndNoor.Shared;
using System.Data;
using System.Data.SqlClient;

namespace QalamAndNoor.DataManager
{
    public abstract class MotherDataManager
    {
        #region MotherMapper
        private static Mother MotherMapper(IDataReader dataReader)
        {
            Mother tempMother = new Mother()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                FirstName = dataReader["FirstName"].ToString(),
                FatherName = dataReader["FatherName"].ToString(),
                LastName = dataReader["LastName"].ToString(),
                MotherName = dataReader["MotherName"].ToString(),
                DoesLiveWithHasband = (Convert.ToBoolean(dataReader["DoesLiveWithHasband"].ToString())),
                Career = dataReader["Career"].ToString(),
                TieNumber = dataReader["TieNumber"].ToString(),
                TiePlace = dataReader["TiePlace"].ToString(),
                PlaceOfBirth = dataReader["PlaceOfBirth"].ToString(),
                DateOfBirth = Convert.ToDateTime(dataReader["DateOfBirth"].ToString()),
                Religion = (ReligionEnum)Convert.ToInt32(dataReader["Religion"].ToString()),
                EducationalStatus =(EducationalStatusEnum)Convert.ToInt32( dataReader["EducationalStatus"].ToString()),
                PhoneNumber = dataReader["PhoneNumber"].ToString(),
            };
            return tempMother;
        }

        #endregion

        #region PublicMethods

        public static List<Mother> GetMothers()
        {
            string sqlStatement = "SELECT * FROM  [dbo].[Mother];";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<Mother> result = BaseDataManager.GetSPItems<Mother>(sqlCommand, MotherMapper);
            return result;
        }

        public static int InsertMother(Mother mother)
        {
            if (mother == null) return 0;

            string sqlStatement = "INSERT INTO  [dbo].[Mother] (FirstName,LastName,FatherName,MotherName,DoesLiveWithHasband,Career," +
                "TieNumber,TiePlace,PlaceOfBirth,DateOfBirth,Religion,EducationalStatus,PhoneNumber) " +
                                  "VALUES (@firstname,@lastName,@fatherName,@motherName,@doesLiveWithHasband,@career," +
                                  "@tieNumber,@tiePlace,@placeOfBirth,@dateOfBirth,@religion,@educationalStatus,@phoneNumber)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@firstName", mother.FirstName));
            sqlCommand.Parameters.Add(new SqlParameter("@lastName", mother.LastName));
            sqlCommand.Parameters.Add(new SqlParameter("@fatherName", mother.FatherName));
            sqlCommand.Parameters.Add(new SqlParameter("@motherName", mother.MotherName));
            sqlCommand.Parameters.Add(new SqlParameter("@doesLiveWithHasband", mother.DoesLiveWithHasband ? "1" : "0"));
            sqlCommand.Parameters.Add(new SqlParameter("@tiePlace", mother.TiePlace));
            sqlCommand.Parameters.Add(new SqlParameter("tieNumber", mother.TieNumber));
            sqlCommand.Parameters.Add(new SqlParameter("@placeOfBirth", mother.PlaceOfBirth));
            sqlCommand.Parameters.Add(new SqlParameter("@dateOfBirth", mother.DateOfBirth));
            sqlCommand.Parameters.Add(new SqlParameter("@religion", (int)mother.Religion));
            sqlCommand.Parameters.Add(new SqlParameter("@career", mother.Career));
            sqlCommand.Parameters.Add(new SqlParameter("@educationalStatus", mother.EducationalStatus));
            sqlCommand.Parameters.Add(new SqlParameter("@phoneNumber", mother.PhoneNumber));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result == 1)
            {
                List<Mother> mothers = GetMothers();
                return mothers.Max(x => x.ID);

            }
            return 0;
        }

         public static int UpdateMother(Mother mother)
        {
            if (mother == null) return 0;

            string sqlStatement= "UPDATE  [dbo].[Mother] SET " +
                                  "FirstName=@firstName,LastName=@lastName,FatherName=@fatherName,MotherName=@motherName," +
                                  "DoesLiveWithHasband=@doesLiveWithHasband,Career=@career,TieNumber=@tieNumber,TiePlace=@tiePlace," +
                                  ",PlaceOdBirth=@placeOdBirth,DateOfBirth=@dateOfBirth,Relegion=@relegion," +
                                  "EducationalStatus=@educationalStatus,PhoneNumber=@phoneNumber " +
                                  "WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", mother.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@firstName", mother.FirstName));
            sqlCommand.Parameters.Add(new SqlParameter("@lastName", mother.LastName));
            sqlCommand.Parameters.Add(new SqlParameter("@fatherName", mother.FatherName));
            sqlCommand.Parameters.Add(new SqlParameter("@motherName", mother.MotherName));
            sqlCommand.Parameters.Add(new SqlParameter("@doesLiveWithHasband", mother.DoesLiveWithHasband ? "1" : "0"));
            sqlCommand.Parameters.Add(new SqlParameter("@tiePlace", mother.TiePlace));
            sqlCommand.Parameters.Add(new SqlParameter("tieNumber", mother.TieNumber));
            sqlCommand.Parameters.Add(new SqlParameter("@placOfBirth", mother.PlaceOfBirth));
            sqlCommand.Parameters.Add(new SqlParameter("@dateOfBirth", mother.DateOfBirth));
            sqlCommand.Parameters.Add(new SqlParameter("@religion", (int)mother.Religion));
            sqlCommand.Parameters.Add(new SqlParameter("@career", mother.Career));
            sqlCommand.Parameters.Add(new SqlParameter("@educationalStatus", mother.EducationalStatus));
            sqlCommand.Parameters.Add(new SqlParameter("@phoneNumber", mother.PhoneNumber));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }

        public static int DeleteMother(Mother mother)
        {
            if (mother == null) return 0;

            string sqlStatement = "DELETE FROM [dbo].[Mother] WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", mother.ID));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }

        #endregion

    }
}
