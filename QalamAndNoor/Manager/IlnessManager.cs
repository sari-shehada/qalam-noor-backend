using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class IlnessManager
    {
        public static List<Ilness> GetIlnesses()
        {
            return IlnessDataManager.GetIlnesses().ToList();
        }
        public static int InsertIlness(Ilness ilness)
        {
            return IlnessDataManager.InsertIlness(ilness);
        }
        public static int UpdateIlness(Ilness ilness)
        {
            return IlnessDataManager.UpdateIlness(ilness);
        }
        public static int DeleteIlness(Ilness ilness)
        {
            return IlnessDataManager.DeleteIlness(ilness);
        }
        public static Ilness GetIlnessById(int id)
        {
            List<Ilness> ilnesses = GetIlnesses();
            foreach (Ilness ilness in ilnesses)
            {
                if (ilness.ID==id)
                {
                    return ilness;
                }
            }
            return null;
        }

    }
}
