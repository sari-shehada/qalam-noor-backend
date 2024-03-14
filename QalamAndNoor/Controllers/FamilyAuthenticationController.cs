using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Controllers
{
    public class FamilyAuthenticationController : ControllerBase
    {
        [Route("FamilyAuthenticationController/Login")]
        [HttpGet]
        public object LogIn(string userName,string password)
        {
            return FamilyAuthenticationManager.FamilyAuthentication(userName, password);
        }
    }
}
