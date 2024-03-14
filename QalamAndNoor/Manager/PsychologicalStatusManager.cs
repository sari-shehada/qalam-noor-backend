using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class PsychologicalStatusManager
    {
        public static List<PsychologicalStatus> GetPsychologicalStatuses()
        {
            return psychologicalStatusDataManager.GetPsychologicalStatuses().ToList();
        }
        public static int InsertPsychologicalStatus(PsychologicalStatus psychologicalStatus)
        {
            return psychologicalStatusDataManager.InsertPsychologicalStatus(psychologicalStatus);
        }
        public static int UpdatePsychologicalStatus(PsychologicalStatus psychologicalStatus)
        {
            return psychologicalStatusDataManager.UpdatePsychologicalStatus(psychologicalStatus);
        }
        public static int DeletePsychologicalStatus(PsychologicalStatus psychologicalStatus)
        {
            return psychologicalStatusDataManager.DeletePsychologicalStatus(psychologicalStatus);
        }

        public static PsychologicalStatus GetPsychologicalStatusById(int id)
        {
            List<PsychologicalStatus> psychologicalStatuses = GetPsychologicalStatuses();
            foreach (PsychologicalStatus psychologicalStatus in psychologicalStatuses)
            {
                if (psychologicalStatus.ID==id)
                {
                    return psychologicalStatus;
                }
            }
            return null;
        }
    }
}
