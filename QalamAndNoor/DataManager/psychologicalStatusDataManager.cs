using QalamAndNoor.Models;
using System.Data.SqlClient;
using System.Data;

namespace QalamAndNoor.DataManager
{
    public abstract class psychologicalStatusDataManager
    {
        #region PsychologicalStatusMapper
        private static PsychologicalStatus PsychologicalStatusMapper(IDataReader dataReader)
        {
            PsychologicalStatus tempPsychologicalStatus = new PsychologicalStatus()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                Name = dataReader["Name"].ToString(),

            };
            return tempPsychologicalStatus;
        }
        #endregion

        #region PublicMethods
        public static List<PsychologicalStatus> GetPsychologicalStatuses()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[PsychologicalStatus]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<PsychologicalStatus> result = BaseDataManager.GetSPItems<PsychologicalStatus>(sqlCommand, PsychologicalStatusMapper);
            return result;
        }
        public static int InsertPsychologicalStatus(PsychologicalStatus psychologicalStatus)
        {
            if (psychologicalStatus == null) return 0;

            string sqlStatement = "INSERT INTO  [dbo].[PsychologicalStatus] (Name) " +
                                  "VALUES (@name)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@name", psychologicalStatus.Name));


            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result == 1)
            {
                List<PsychologicalStatus> psychologicalStatuses = GetPsychologicalStatuses();
                return psychologicalStatuses.Max(x => x.ID);

            }
            return 0;
        }

        public static int UpdatePsychologicalStatus(PsychologicalStatus psychologicalStatus)
        {

            if (psychologicalStatus == null) return 0;
            //SQL Statement
            string sqlStatement = "UPDATE  [dbo].[PsychologicalStatus] SET " +
                                  "Name=@name " +
                                  "WHERE ID=@id;";

            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", psychologicalStatus.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@name", psychologicalStatus.Name));

            //Execute Query
            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        public static int DeletePsychologicalStatus(PsychologicalStatus psychologicalStatus)
        {
            if (psychologicalStatus == null) return 0;
            //SQL Statement
            string sqlStatement = "DELETE FROM [dbo].[PsychologicalStatus] WHERE ID=@id;";

            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };


            sqlCommand.Parameters.Add(new SqlParameter("@id", psychologicalStatus.ID));
            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }

        #endregion
    }
}
