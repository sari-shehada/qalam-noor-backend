using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Controllers
{
    public class ResponsiblePersonController : ControllerBase
    {
        [Route("ResponsiblePersonController/InsertResponsiblePerson")]
        [HttpPost]
        public int InsertResponsiblePerson([FromBody] ResponsiblePerson responsiblePerson)
        {
            return ResponsiblePersonManager.InsertResponsiblePerson(responsiblePerson);
        }
        [Route("ResponsiblePersonController/UpdateResponsiblePerson")]
        [HttpPost]
        public int UpdateResponsiblePerson([FromBody] ResponsiblePerson responsiblePerson)
        {
            return ResponsiblePersonManager.UpdateResponsiblePerson(responsiblePerson);
        }
        [Route("ResponsiblePersonController/DeleteResponsiblePerson")]
        [HttpPost]
        public int DeleteResponsiblePerson([FromBody] ResponsiblePerson responsiblePerson)
        {
            return ResponsiblePersonManager.DeleteResponsiblePerson(responsiblePerson);
        }
        [Route("ResponsiblePersonController/GetResponsiblePersons")]
        [HttpGet]
        public List<ResponsiblePerson> GetResponsiblePersons()
        {
            return ResponsiblePersonManager.GetResponsiblePersons();
        }
        [Route("ResponsiblePersonController/GetResponsiblePersonById")]
        [HttpGet]
        public ResponsiblePerson GetResponsiblePersonById(int id)
        {
            return ResponsiblePersonManager.GetResponsiblePersonById(id);
        }
    }
}
