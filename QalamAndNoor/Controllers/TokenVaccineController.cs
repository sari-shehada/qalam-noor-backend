using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Controllers
{
    public class TokenVaccineController : ControllerBase
    {
        [Route("TokenVaccineController/InsertTokenVaccine")]
        [HttpPost]
        public int InsertTokenVaccine([FromBody] TokenVaccine tokenVaccine)
        {
            return TokenVaccineManager.InsertTokenVaccine(tokenVaccine);
        }
        [Route("TokenVaccineController/UpdateTokenVaccine")]
        [HttpPost]
        public int UpdateTokenVaccine([FromBody] TokenVaccine tokenVaccine)
        {
            return TokenVaccineManager.UpdateTokenVaccine(tokenVaccine);
        }
        [Route("TokenVaccineController/DeleteTokenVaccine")]
        [HttpPost]
        public int DeleteTokenVaccine([FromBody] TokenVaccine tokenVaccine)
        {
            return TokenVaccineManager.DeleteTokenVaccine(tokenVaccine);
        }
        [Route("TokenVaccineController/GetTokenVaccines")]
        [HttpGet]
        public List<TokenVaccine> GetTokenVaccines()
        {
            return TokenVaccineManager.GetTokenVaccines();
        }
        [Route("TokenVaccineController/GetTokenVaccineById")]
        [HttpGet]
        public TokenVaccine GetTokenVaccineById(int id)
        {
            return TokenVaccineManager.GetTokenVaccineById(id);
        }
    }
}
