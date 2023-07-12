using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.DataManager;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Controllers
{
    public class ClassController : ControllerBase
    {
        [Route("ClassController/InsertClass")]
        [HttpPost]
        public int InsertClass([FromBody] Class cls)
        {
            return ClassManager.InsertClass(cls);
        }
        [Route("ClassController/UpdateClass")]
        [HttpPost]
        public int UpdateClass([FromBody] Class cls)
        {
            return ClassManager.UpdateClass(cls);
        }
        [Route("ClassController/DeleteClass")]
        [HttpPost]
        public int DeleteClass([FromBody] Class cls)
        {
            return ClassManager.DeleteClass(cls);
        }


        [Route("ClassController/GetClasses")]
        [HttpGet]
        public List<Class> GetClasses()
        {
            return ClassManager.GetClasses();
        }
        [Route("ClassController/GetClassById")]
        [HttpGet]
        public Class GetClassById(int id)
        {
            return ClassManager.GetClassById(id);
        }
        [Route("ClassController/GetClassesByName")]
        [HttpGet]
        public List<Class> GetClassesByName(string name)
        {
            return ClassManager.GetClassesByName(name);
        }

        [Route("ClassController/GetOpentClassesinCurrentSchoolYear")]
        [HttpGet]
        public List<Class> GetOpentClassesinCurrentSchoolYear()
        {
            return ClassDataManager.GetOpentClassesinCurrentSchoolYear();
        }
        [Route("ClassController/GetClassesBySchoolYearId")]
        [HttpGet]
        public List<Class> GetClassesBySchoolYearId(int schoolYearId)
        {
            return ClassDataManager.GetClassesBySchoolYearId(schoolYearId);
        }
    }
}
