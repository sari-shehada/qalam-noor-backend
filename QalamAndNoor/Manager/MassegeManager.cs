using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class MassegeManager
    {
        public static List<Message> GetMasseges()
        {
            return MessageDataManager.GetMasseges().ToList();
        }
        //TODO: Build an endpoint for this data manager message
        public static List<Message> GetMessagesByConversationID(int conversationId)
        {
            return MessageDataManager.GetMasseges()
                .Where(x => x.ConversationId == conversationId)
                .OrderBy(x => x.Date)
                .ToList();
        }
        public static int InsertMassege(Message massege)
        {
            return MessageDataManager.InsertMassege(massege);
        }
        public static int UpdateMassege(Message massege)
        {
            return MessageDataManager.UpdateMassege(massege);
        }
        public static int DeleteMassege(Message massege)
        {
            return MessageDataManager.DeleteMassege(massege);
        }
        public static Message GetMassegeById(int id)
        {
            List<Message> masseges = GetMasseges();
            foreach (Message massege in masseges)
            {
                if (massege.ID == id)
                {
                    return massege;
                }
            }
            return null;
        }

        public static int DeleteAllMassege()
        {
            return MessageDataManager.DeleteAllMassege();
        }

    }
}
