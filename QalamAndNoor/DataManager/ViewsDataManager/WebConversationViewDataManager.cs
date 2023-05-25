using QalamAndNoor.Models;
using QalamAndNoor.Models.HelperModels;
using QalamAndNoor.MyViews;
using QalamAndNoor.Shared;
using System.Data;
using System.Data.SqlClient;

namespace QalamAndNoor.DataManager.ViewsDataManager
{
    public abstract class WebConversationViewDataManager
    {
        #region WebConversationMapper
        private static WebConversation WebConversationMapper(IDataReader dataReader)
        {
            WebConversation tempWebConversation = new WebConversation()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                StudentId = Convert.ToInt32(dataReader["StudentId"].ToString()),
                Title = dataReader["Title"].ToString(),
                Status = (ConversationStatusEnum)Convert.ToInt32(dataReader["Status"].ToString()),
                OrginalIssuer = (ConversationPartyEnum)Convert.ToInt32(dataReader["OriginalIssuer"].ToString()),
                IsReadOther = Convert.ToBoolean(dataReader["IsReadOther"].ToString()),
                IsReadParent = Convert.ToBoolean(dataReader["IsReadParent"].ToString()),
                StudentName = dataReader["StudentName"].ToString(),
                FatherName = dataReader["FatherName"].ToString(),
                LastName = dataReader["LastName"].ToString(),
                MotherName = dataReader["MotherName"].ToString(),
                PublicRecordId = Convert.ToInt32(dataReader["PublicRecordId"].ToString())
            };
            return tempWebConversation;
        }
        #endregion
        #region PublicMethods

        public static List<WebConversation> GetWebConversations()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[WebConverationView]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<WebConversation> result = BaseDataManager.GetSPItems<WebConversation>(sqlCommand, WebConversationMapper);
            return result;
        }

        #endregion
    }
}
