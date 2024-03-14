using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager.ViewsManager;
using QalamAndNoor.MyViews;

namespace QalamAndNoor.Controllers.ViewsController
{
    public class StudnetProfileViewController : ControllerBase
    {
        [Route("StudnetProfileViewController/GetStudentProfileViews")]
        [HttpGet]
        public List<StudentProfileView> GetStudentProfileViews()
        {
            return StudentProfileViewManager.GetStudentProfileViews();
        }
        [Route("StudnetProfileViewController/GetStudentProfileViewByStudentId")]
        [HttpGet]
        public StudentProfileView GetStudentProfileViewByStudentId(int studentId)
        {
            return StudentProfileViewManager.GetStudentProfileViewByStudentId(studentId);
        }
    }
}
