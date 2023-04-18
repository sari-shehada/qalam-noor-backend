using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class JobTitleManager
    {
        public static List<JobTitle> GetJobTitles()
        {
            return JobTitleDataManager.GetJobTitles().ToList();
        }
        public static int InsertJobTitle(JobTitle jobTitle)
        {
            return JobTitleDataManager.InsertJobTitle(jobTitle);
        }
        public static int UpdateJobTitle(JobTitle jobTitle)
        {
            return JobTitleDataManager.UpdateJobTitle(jobTitle);
        }
        public static int DeleteJobTitle(JobTitle jobTitle)
        {
            return JobTitleDataManager.DeleteJobTitle(jobTitle);
        }
        public static JobTitle GetJobTitleById(int id)
        {
            List<JobTitle> jobTitles = GetJobTitles();
            foreach (JobTitle jobTitle in jobTitles)
            {
                if (jobTitle.ID==id)
                {
                    return jobTitle;
                }
            }
            return null;
        }
    }
}
