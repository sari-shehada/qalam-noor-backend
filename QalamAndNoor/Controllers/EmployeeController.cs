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
        [Route("EmployeeController/GetEmployeesByJobTitleId")]
        [HttpGet]
        public List<Employee> GetEmployeesByJobTitleId(int jobTitleId)
        {
            return EmployeeManager.GetEmployeesByJobTitleId(jobTitleId);
        }
        [Route("EmployeeController/GetTeachers")]
        [HttpGet]
        public List<Employee> GetTeachers( )
        {
            return EmployeeManager.GetTeachers();
        }

        [Route("EmployeeController/GetTeachersByJobTitleId")]
        [HttpGet]
        public List<Employee> GetTeachersByJobTitleId(int jobTitleId)
        {
            return EmployeeManager.GetTeachersByJobTitleId(jobTitleId);
        }
        [Route("EmployeeController/GetEmployeesByName")]
        [HttpGet]
        public List<Employee> GetEmployeesByName(string name)
        {
            return EmployeeManager.GetEmployeesByName(name);
        }

    }
}
