using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Controllers
{
    public class JobTitleController : ControllerBase
    {
        [Route("JobTitleController/InsertJobTitle")]
        [HttpPost]
        public int InsertJobTitle([FromBody] JobTitle jobTitle)
        {
            return JobTitleManager.InsertJobTitle(jobTitle);
        }
        [Route("JobTitleController/UpdateJobTitle")]
        [HttpPost]
        public int UpdateJobTitle([FromBody] JobTitle jobTitle)
        {
            return JobTitleManager.UpdateJobTitle(jobTitle);
        }
        [Route("JobTitleController/DeleteJobTitle")]
        [HttpPost]
        public int DeleteJobTitle([FromBody] JobTitle jobTitle)
        {
            return JobTitleManager.DeleteJobTitle(jobTitle);
        }
        [Route("JobTitleController/GetJobTitles")]
        [HttpGet]
        public List<JobTitle> GetJobTitles()
        {
            return JobTitleManager.GetJobTitles();
        }
        [Route("JobTitleController/GetJobTitleById")]
        [HttpGet]
        public JobTitle GetJobTitleById(int id)
        {
            return JobTitleManager.GetJobTitleById(id);
        }
        [Route("JobTitleController/GetTeachersJobTitles")]
        [HttpGet]
        public List<JobTitle> GetTeachersJobTitles()
        {
            return JobTitleManager.GetTeachersJobTitles();
        }
        [Route("JobTitleController/GetTeachersJobTitlesByDetails")]
        [HttpGet]
        public List<JobTitle> GetTeachersJobTitlesByDetails(string details)
        {
            return JobTitleManager.GetTeachersJobTitlesByDetails(details);
        }

    }
}
