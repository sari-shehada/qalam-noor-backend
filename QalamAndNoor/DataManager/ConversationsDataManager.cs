using QalamAndNoor.Models;
using QalamAndNoor.Shared;
using System.Data;
using System.Data.SqlClient;

namespace QalamAndNoor.DataManager
{
    public abstract class ConversationsDataManager
    {
        #region Mappers
        private static Conversation ConversationMapper(IDataReader dataReader)
        {
            Conversation tempConversation = new Conversation()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                StudentId = Convert.ToInt32(dataReader["StudentId"].ToString()),
                Title = dataReader["Title"].ToString(),
                Status = (ConversationStatusEnum)Convert.ToInt32(dataReader["Status"].ToString()),
                OrginalIssuer = (ConversationPartyEnum)Convert.ToInt32(dataReader["OriginalIssuer"].ToString()),
                IsReadOther = Convert.ToBoolean(dataReader["IsReadOther"].ToString()),
                IsReadParent = Convert.ToBoolean(dataReader["IsReadParent"].ToString())
            };
            return tempConversation;
        }
        #endregion

        #region PublicMethods
        public static List<Conversation> GetConversations()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[Conversation]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<Conversation> result = BaseDataManager.GetSPItems<Conversation>(sqlCommand, ConversationMapper);
            return result;
        }
        public static int InsertConversation(Conversation conversation)
        {
            if (conversation == null) return 0;

            string sqlStatement = "INSERT INTO  [dbo].[Conversation] (StudentId,Title,Status,OriginalIssuer,IsReadParent,IsReadOther) " +
                                  "VALUES (@studentId,@title,@status,@originalIssuer,@isReadParent,@isReadOther)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@studentId", conversation.StudentId));
            sqlCommand.Parameters.Add(new SqlParameter("@title", conversation.Title));
            sqlCommand.Parameters.Add(new SqlParameter("@status", (int)conversation.Status));
            sqlCommand.Parameters.Add(new SqlParameter("@originalIssuer", (int)conversation.OrginalIssuer));
            sqlCommand.Parameters.Add(new SqlParameter("@isReadParent", conversation.IsReadParent ? "1" : "0"));
            sqlCommand.Parameters.Add(new SqlParameter("@isReadOther", conversation.IsReadOther ? "1" : "0"));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result == 1)
            {
                List<Conversation> conversations = GetConversations();
                return conversations.Max(x => x.ID);

            }
            return 0;
        }
        public static int UpdateConversation(Conversation conversation)
        {
            if (conversation == null) return 0;

            string sqlStatement = "UPDATE  [dbo].[Conversation] SET " +
                                  "StudentId=@studentId,Title=@title,Status=@status,OriginalIssuer=@originalIssuer,IsReadOther=@isReadOther,IsReadParent=@isReadParent " +
                                  "WHERE ID=@id;";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
          
            sqlCommand.Parameters.Add(new SqlParameter("@id", conversation.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@studentId", conversation.StudentId));
            sqlCommand.Parameters.Add(new SqlParameter("@title", conversation.Title));
            sqlCommand.Parameters.Add(new SqlParameter("@status", (int)conversation.Status));
            sqlCommand.Parameters.Add(new SqlParameter("@originalIssuer", (int)conversation.OrginalIssuer));
            sqlCommand.Parameters.Add(new SqlParameter("@isReadParent", conversation.IsReadParent ? "1" : "0"));
            sqlCommand.Parameters.Add(new SqlParameter("@isReadOther", conversation.IsReadOther ? "1" : "0"));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        public static int DeleteConversation(Conversation conversation)
        {
            if (conversation == null) return 0;

            string sqlStatement = "DELETE FROM [dbo].[Conversation] WHERE ID=@id;";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };

            sqlCommand.Parameters.Add(new SqlParameter("@id", conversation.ID));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        public static int DeleteAllConversation()
        {

            string sqlStatement = "DELETE FROM [dbo].[Conversation] ";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };


            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        #endregion
    }
}
