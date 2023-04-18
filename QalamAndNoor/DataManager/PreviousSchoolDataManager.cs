using QalamAndNoor.Models;
using System.Data.SqlClient;
using System.Data;

namespace QalamAndNoor.DataManager
{
    public abstract class PreviousSchoolDataManager
    {
        #region Mapper
        private static PreviousSchool PreviousSchoolMapper(IDataReader dataReader)
        {
            PreviousSchool tempPreviousSchool = new PreviousSchool()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                Name = dataReader["Name"].ToString(),
                Details = dataReader["Details"].ToString(),
            };
            return tempPreviousSchool;
        }
        #endregion

        #region PublicMethods
        public static List<PreviousSchool> GetPreviousSchools()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[PreviousSchool]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<PreviousSchool> result = BaseDataManager.GetSPItems<PreviousSchool>(sqlCommand, PreviousSchoolMapper);
            return result;
        }
        public static int InsertPreviousSchool(PreviousSchool previousSchool)
        {
            if (previousSchool == null) return 0;

            string sqlStatement = "INSERT INTO  [dbo].[PreviousSchool](Name,Details) " +
                                  "VALUES (@name,@details)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@name", previousSchool.Name));
            sqlCommand.Parameters.Add(new SqlParameter("@details", previousSchool.Details));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result == 1)
            {
                List<PreviousSchool> previousSchools = GetPreviousSchools();
                return previousSchools.Max(x => x.ID);

            }
            return 0;
        }
        public static int UpdatePreviousSchool(PreviousSchool previousSchool)
        {

            if (previousSchool == null) return 0;
            //SQL Statement
            string sqlStatement = "UPDATE  [dbo].[PreviousSchool] SET " +
                                  "Name=@name,Details=@details " +
                                  "WHERE ID=@id;";

            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", previousSchool.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@name", previousSchool.Name));
            sqlCommand.Parameters.Add(new SqlParameter("@details",   previousSchool.Details));

            //Execute Query
            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }

        public static int DeletePreviousSchool(PreviousSchool previousSchool)
        {
            if (previousSchool == null) return 0;
            //SQL Statement
            string sqlStatement = "DELETE FROM [dbo].[PreviousSchool] WHERE ID=@id;";

            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };


            sqlCommand.Parameters.Add(new SqlParameter("@id", previousSchool.ID));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        #endregion
    }
}
