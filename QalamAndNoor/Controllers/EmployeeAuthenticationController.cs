using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager;

namespace QalamAndNoor.Controllers
{
    public class EmployeeAuthenticationController : ControllerBase
    {
        [Route("EmployeeAuthenticationController/Login")]
        [HttpGet]
        public object LogIn(string userName, string password)
        {
            return EmployeeAuthenticationManager.EmployeeAuthentication(userName, password);
        }
    }
}
