using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class MassegeManager
    {
        public static List<Massege> GetMasseges()
        {
            return MassegeDataManager.GetMasseges().ToList();
        }
        public static int InsertMassege(Massege massege)
        {
            return MassegeDataManager.InsertMassege(massege);
        }
        public static int UpdateMassege(Massege massege)
        {
            return MassegeDataManager.UpdateMassege(massege);
        }
        public static int DeleteMassege(Massege massege)
        {
            return MassegeDataManager.DeleteMassege(massege);
        }
        public static Massege GetMassegeById(int id)
        {
            List<Massege> masseges = GetMasseges();
            foreach (Massege massege  in masseges)
            {
                if (massege.ID==id)
                {
                    return massege;
                }
            }
            return null;
        }
    }
}
