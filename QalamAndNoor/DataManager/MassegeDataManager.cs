using QalamAndNoor.Manager;
using QalamAndNoor.Models;
using QalamAndNoor.Shared;
using System.Data;
using System.Data.SqlClient;

namespace QalamAndNoor.DataManager
{
    public abstract class MessageDataManager
    {
        #region Mappers
        private static Message MassegeMapper(IDataReader dataReader)
        {
            Message tempMassege = new Message()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                Body = dataReader["Body"].ToString()!,
                Sender = (MessageSenderEnum)Convert.ToInt32(dataReader["Sender"].ToString()),
                Date = dataReader["Date"].ToString()!,
                ConversationId = Convert.ToInt32(dataReader["ConversationId"].ToString()),
            };
            return tempMassege;
        }
        #endregion
        #region PublicMethods
        public static List<Message> GetMasseges()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[Massage]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<Message> result = BaseDataManager.GetSPItems<Message>(sqlCommand, MassegeMapper);
            return result;
        }

        public static int InsertMassege(Message message)
        {
            if (message == null) return 0;
            //TODO: Get Convo by id

            var conversation = ConversationManager.GetConverstionById(message.ConversationId);
            conversation!.IsReadParent = message.Sender == MessageSenderEnum.parents;
            conversation.IsReadOther = message.Sender != MessageSenderEnum.parents;
            //Update Convo
            ConversationManager.UpdateConversation(conversation);


            message.Date = DateTimeOffset.Now.ToUnixTimeSeconds().ToString(); //Date Time Since Epoch

            //TODO: Edit Query
            string sqlStatement = "INSERT INTO  [dbo].[Massage] (Body,Sender,Date,ConversationId) " +
                                  "VALUES (@body,@sender,@date,@conversationId)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@body", message.Body));
            sqlCommand.Parameters.Add(new SqlParameter("@sender", (int)message.Sender));
            sqlCommand.Parameters.Add(new SqlParameter("@date", message.Date));
            sqlCommand.Parameters.Add(new SqlParameter("@conversationId", message.ConversationId));


            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result == 1)
            {
                List<Message> masseges = GetMasseges();
                return masseges.Max(x => x.ID);

            }
            return 0;
        }

        public static int UpdateMassege(Message massege)
        {
            if (massege == null) return 0;

            string sqlStatement = "UPDATE  [dbo].[Massage] SET " +
                                  "Body=@body,Sender=@sender" +
                                  ",Date=@date,ConversationId=@conversationId " +
                                  "WHERE ID=@id;";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", massege.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@body", massege.Body));
            sqlCommand.Parameters.Add(new SqlParameter("@sender", (int)massege.Sender));
            sqlCommand.Parameters.Add(new SqlParameter("@date", massege.Date));
            sqlCommand.Parameters.Add(new SqlParameter("@conversationId", massege.ConversationId));


            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }

        public static int DeleteMassege(Message massege)
        {
            if (massege == null) return 0;

            string sqlStatement = "DELETE FROM [dbo].[Massage] WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", massege.ID));


            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        public static int DeleteAllMassege()
        {
          

            string sqlStatement = "DELETE FROM [dbo].[Massage]";

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
