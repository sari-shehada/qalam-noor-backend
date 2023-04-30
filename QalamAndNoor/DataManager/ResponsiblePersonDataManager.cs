using QalamAndNoor.Models;
using System.Data;
using System.Data.SqlClient;

namespace QalamAndNoor.DataManager
{
    public abstract class ResponsiblePersonDataManager
    {
        #region Mappers
        private static ResponsiblePerson ResponsiblePersonMapper(IDataReader dataReader)
        {
            ResponsiblePerson tempResponsiblePerson = new ResponsiblePerson()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                FirstName = dataReader["FirstName"].ToString(),
                LastName = dataReader["LastName"].ToString(),
                RelationToStudent = dataReader["RelationToStudent"].ToString(),
                PhoneNumber = dataReader["PhoneNumber"].ToString(),
                DateOfBirth =Convert.ToDateTime( dataReader["DateOfBirth"].ToString()),
                PlaceOfBirth = dataReader["PlaceOfBirth"].ToString(),
            };
            return tempResponsiblePerson;
        }
        #endregion

        #region PublicMethods
        public static List<ResponsiblePerson> GetResponsiblePersons()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[ResponsiblePerson]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<ResponsiblePerson> result = BaseDataManager.GetSPItems<ResponsiblePerson>(sqlCommand, ResponsiblePersonMapper);
            return result;
        }

        public static int InsertResponsiblePerson(ResponsiblePerson responsiblePerson)
        {
            if (responsiblePerson == null) return 0;

            string sqlStatement = "INSERT INTO  [dbo].[ResponsiblePerson] (FirstName,LastName,RelationToStudent,PhoneNumber,DateOfBirth,PlaceOfBirth) " +
                                  "VALUES (@firstName,@lastName,@relationToStudent,@phoneNumber,@dateOfBirth,@placeOfBirth)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@firstName", responsiblePerson.FirstName));
            sqlCommand.Parameters.Add(new SqlParameter("@lastName", responsiblePerson.LastName));
            sqlCommand.Parameters.Add(new SqlParameter("@relationToStudent", responsiblePerson.RelationToStudent));
            sqlCommand.Parameters.Add(new SqlParameter("@phoneNumber", responsiblePerson.PhoneNumber));
            sqlCommand.Parameters.Add(new SqlParameter("@dateOfBirth", responsiblePerson.DateOfBirth));
            sqlCommand.Parameters.Add(new SqlParameter("@placeOfBirth", responsiblePerson.PlaceOfBirth));


            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result == 1)
            {
                List<ResponsiblePerson> responsiblePersons = GetResponsiblePersons();
                return responsiblePersons.Max(x => x.ID);

            }
            return 0;
        }

        public static int UpdateResponsiblePerson(ResponsiblePerson responsiblePerson)
        {
            if (responsiblePerson == null) return 0;

            string sqlStatement = "UPDATE  [dbo].[ResponsiblePerson] SET " +
                                  "FirstName=@firstName,LastName=@lastName,RelationToStudent=@relationToStudent," +
                                  "PhoneNumber=@phoneNumber,DateOfBirht=@dateOfBirth,PlaceOfBirth=@placeOfBirth " +
                                  "WHERE ID=@id;";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", responsiblePerson.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@firstName", responsiblePerson.FirstName));
            sqlCommand.Parameters.Add(new SqlParameter("@lastName", responsiblePerson.LastName));
            sqlCommand.Parameters.Add(new SqlParameter("@relationToStudent", responsiblePerson.RelationToStudent));
            sqlCommand.Parameters.Add(new SqlParameter("@phoneNumber", responsiblePerson.PhoneNumber));
            sqlCommand.Parameters.Add(new SqlParameter("@dateOfBirth", responsiblePerson.DateOfBirth));
            sqlCommand.Parameters.Add(new SqlParameter("@placeOfBirth", responsiblePerson.PlaceOfBirth));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
           
        }

        public static int DeleteResponsiblePerson(ResponsiblePerson responsiblePerson)
        {
            if (responsiblePerson == null) return 0;

            string sqlStatement = "DELETE FROM [dbo].[ResponsiblePerson] WHERE ID=@id;";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", responsiblePerson.ID));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;

        }

        #endregion
    }
}
