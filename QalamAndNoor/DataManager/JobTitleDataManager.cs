using QalamAndNoor.Models;
using System.Data.SqlClient;
using System.Data;

namespace QalamAndNoor.DataManager
{
    public abstract class JobTitleDataManager
    {
        #region Mappers
        private static JobTitle JobTitleMapper(IDataReader dataReader)
        {
            JobTitle tempJobTitle = new JobTitle()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                Name = dataReader["Name"].ToString(),
                Details = dataReader["Details"].ToString(),
            };
            return tempJobTitle;
        }
        #endregion
        // #region Public Methods
        #region PublicMethods
        public static List<JobTitle> GetJobTitles()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[JobTitle]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<JobTitle> result = BaseDataManager.GetSPItems<JobTitle>(sqlCommand, JobTitleMapper);
            return result;
        }
        public static int InsertJobTitle(JobTitle jobTitle)
        {
            if (jobTitle == null) return 0;

            string sqlStatement = "INSERT INTO  [dbo].[JobTitle] (Name,Details) " +
                                  "VALUES (@name,@details)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@name", jobTitle.Name));
            sqlCommand.Parameters.Add(new SqlParameter("@details", jobTitle.Details));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result == 1)
            {
                List<JobTitle> cities = GetJobTitles();
                return cities.Max(x => x.ID);

            }
            return 0;
        }
        public static int UpdateJobTitle(JobTitle jobTitle)
        {
            if (jobTitle == null) return 0;

            string sqlStatement = "UPDATE  [dbo].[JobTitle] SET " +
                                  "Name=@name,Details=@details " +
                                  "WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", jobTitle.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@name", jobTitle.Name));
            sqlCommand.Parameters.Add(new SqlParameter("@details", jobTitle.Details));


            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        public static int DeleteJobTitle(JobTitle jobTitle)
        {
            if (jobTitle == null) return 0;

            string sqlStatement = "DELETE FROM [dbo].[JobTitle] WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", jobTitle.ID));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }


        #endregion
    }
}
