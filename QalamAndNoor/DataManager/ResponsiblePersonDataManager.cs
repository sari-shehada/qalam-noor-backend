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
                Career = dataReader["Career"].ToString(),
                Address = dataReader["Address"].ToString(),
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

            string sqlStatement = "INSERT INTO  [dbo].[ResponsiblePerson] (FirstName,LastName,RelationToStudent,Career,Address) " +
                                  "VALUES (@firstName,@lastName,@relationToStudent,@career,@address)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@firstName", responsiblePerson.FirstName));
            sqlCommand.Parameters.Add(new SqlParameter("@lastName", responsiblePerson.LastName));
            sqlCommand.Parameters.Add(new SqlParameter("@relationToStudent", responsiblePerson.RelationToStudent));
            sqlCommand.Parameters.Add(new SqlParameter("@career", responsiblePerson.Career));
            sqlCommand.Parameters.Add(new SqlParameter("@address", responsiblePerson.Address));

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
                                  "Career=@career,Address=@address " +
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
            sqlCommand.Parameters.Add(new SqlParameter("@career", responsiblePerson.Career));
            sqlCommand.Parameters.Add(new SqlParameter("@address", responsiblePerson.Address));

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
