using Microsoft.AspNetCore.Mvc;
using QalamAndNoor.Manager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Controllers
{
    public class EmployeeController : ControllerBase
    {
        [Route("EmployeeController/InsertEmployee")]
        [HttpPost]
        public int InsertEmployee([FromBody] Employee employee)
        {
            return EmployeeManager.InsertEmployee(employee);
        }
        [Route("EmployeeController/UpdateEmployee")]
        [HttpPost]
        public int UpdateEmployee([FromBody] Employee employee)
        {
            return EmployeeManager.UpdateEmployee(employee);
        }
        [Route("EmployeeController/DeleteEmployee")]
        [HttpPost]
        public int DeleteEmployee([FromBody] Employee employee)
        {
            return EmployeeManager.DeleteEmployee(employee);
        }
        [Route("EmployeeController/GetEmployees")]
        [HttpGet]
        public List<Employee> GetEmployees()
        {
            return EmployeeManager.GetEmployees();
        }
        [Route("EmployeeController/GetEmployeeById")]
        [HttpGet]
        public Employee GetEmployeeById(int id)
        {
            return EmployeeManager.GetEmployeeById(id);
        }


    }
}
