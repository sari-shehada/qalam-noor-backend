using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class VaccineManager
    {
        public static List<Vaccine> GetVaccines() 
        {
            return VccineDataManager.GetVaccines().ToList();
        }
        public static int InsertVaccine(Vaccine vaccine)
        {
            return VccineDataManager.InsertVaccine(vaccine);
        }
        public static int UpdateVaccine(Vaccine vaccine)
        {
            return VccineDataManager.UpdateVaccine(vaccine);
        }
        public static int DeleteVaccine(Vaccine vaccine)
        {
            return VccineDataManager.DeleteVaccine(vaccine);
        }
        public static Vaccine GetVaccineById(int id)
        {
            List<Vaccine> vaccines = GetVaccines();
            foreach (Vaccine vaccine in vaccines)
            {
                if (vaccine.ID==id)
                {
                    return vaccine;
                }
            }
            return null;
        }

        public static List<Vaccine> GetTakenVaccinesByStudentId(int studentId)
        {
            List<TokenVaccine> tokenVaccines = TokenVaccineManager.GetTokenVaccinesByMedicalRecordId(studentId);
            List<Vaccine> vaccines = GetVaccines();
            List<Vaccine> result = new List<Vaccine>();
            foreach (var item in tokenVaccines)
            {
                result.Add(vaccines.First((x) => x.ID == item.VaccineId));
            }
            return result;
        }
    }
}
