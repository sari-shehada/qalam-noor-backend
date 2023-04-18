using QalamAndNoor.Models;
using QalamAndNoor.Shared;
using System.Data;
using System.Data.SqlClient;

namespace QalamAndNoor.DataManager
{
    public abstract class MassegeDataManager
    {
        #region Mappers
        private static Massege MassegeMapper(IDataReader dataReader)
        {
            Massege tempMassege = new Massege()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                Title = dataReader["Title"].ToString(),
                Body = dataReader["Body"].ToString(),
                Sender = (MassegeSenderEnum)Convert.ToInt32(dataReader["Sender"].ToString()),
                Sequence = Convert.ToInt32(dataReader["Sequence"].ToString()),
                Date = Convert.ToDateTime(dataReader["Date"].ToString()),
                ConversationId = Convert.ToInt32(dataReader["ConversationId"].ToString()),
            };
            return tempMassege;
        }
        #endregion
        #region PublicMethods
        public static List<Massege> GetMasseges()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[Massege]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<Massege> result = BaseDataManager.GetSPItems<Massege>(sqlCommand, MassegeMapper);
            return result;
        }
        public static int InsertMassege(Massege massege)
        {
            if (massege == null) return 0;

            string sqlStatement = "INSERT INTO  [dbo].[Massege] (Title,Body,Sender,Sequence,Date,ConversationId) " +
                                  "VALUES (@title,@body,@sender,@sequence,@date,@conversationId)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@title", massege.Title));
            sqlCommand.Parameters.Add(new SqlParameter("@body", massege.Body));
            sqlCommand.Parameters.Add(new SqlParameter("@sender", (int)massege.Sender));
            sqlCommand.Parameters.Add(new SqlParameter("@sequence", massege.Sequence));
            sqlCommand.Parameters.Add(new SqlParameter("@date", massege.Date));
            sqlCommand.Parameters.Add(new SqlParameter("@conversationId",massege.ConversationId));


            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result == 1)
            {
                List<Massege> masseges = GetMasseges();
                return masseges.Max(x => x.ID);

            }
            return 0;
        }
        public static int UpdateMassege(Massege massege)
        {
            if (massege == null) return 0;

            string sqlStatement = "UPDATE  [dbo].[Massege] SET " +
                                  "Title=@title,Body=@body,Sender=@sender" +
                                  "Sequence=@sequence,Date=@date,ConversationId=@conversationId " +
                                  "WHERE ID=@id;";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", massege.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@title", massege.Title));
            sqlCommand.Parameters.Add(new SqlParameter("@body", massege.Body));
            sqlCommand.Parameters.Add(new SqlParameter("@sender", (int)massege.Sender));
            sqlCommand.Parameters.Add(new SqlParameter("@sequence", massege.Sequence));
            sqlCommand.Parameters.Add(new SqlParameter("@date", massege.Date));
            sqlCommand.Parameters.Add(new SqlParameter("@conversationId", massege.ConversationId));


            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        public static int DeleteMassege(Massege massege)
        {
            if (massege == null) return 0;

            string sqlStatement = "DELETE FROM [dbo].[Massege] WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", massege.ID));


            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }


        #endregion
    }
}
