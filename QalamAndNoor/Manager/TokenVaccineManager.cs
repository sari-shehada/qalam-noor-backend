using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class TokenVaccineManager
    {
        public static List<TokenVaccine> GetTokenVaccines()
        {
            return TokenVaccineDataManager.GetTokenVaccines().ToList();
        }
        public static int InsertTokenVaccine(TokenVaccine tokenVaccine)
        {
            return TokenVaccineDataManager.InsertTokenVaccine(tokenVaccine);
        }
        public static int UpdateTokenVaccine(TokenVaccine tokenVaccine)
        {
            return TokenVaccineDataManager.UpdateTokenVaccine(tokenVaccine);
        }
        public static int DeleteTokenVaccine(TokenVaccine tokenVaccine)
        {
            return TokenVaccineDataManager.DeleteTokenVaccine(tokenVaccine);
        }
        public static TokenVaccine GetTokenVaccineById(int id)
        {
            List<TokenVaccine> tokenVaccines = GetTokenVaccines();
            foreach (TokenVaccine tokenVaccine in tokenVaccines)
            {
                if (tokenVaccine.ID==id)
                {
                    return tokenVaccine;
                }
            }
            return null;
        }

        public static List<TokenVaccine> GetTokenVaccinesByMedicalRecordId(int medId)
        {
            List<TokenVaccine> tokenVaccines = GetTokenVaccines();
            List<TokenVaccine> result = new List<TokenVaccine>();
            foreach (TokenVaccine item in tokenVaccines)
            {
                if (item.MedicalRecordId==medId)
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}

