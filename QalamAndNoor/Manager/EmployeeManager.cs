using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class EmployeeManager
    {
        public static List<Employee> GetEmployees()
        {
            return EmployeeDataManager.GetEmployees().ToList();
        }
        public static int InsertEmployee(Employee employee)
        {
        return EmployeeDataManager.InsertEmployee(employee);
        }
        public static int UpdateEmployee(Employee employee)
        {
            return EmployeeDataManager.UpdateEmployee(employee);
        }
        public static int DeleteEmployee(Employee employee)
        {
            return EmployeeDataManager.DeleteEmployee(employee);
        }
        public static Employee GetEmployeeById(int id)
        {
            List<Employee> employees = GetEmployees();
            foreach (Employee employee in employees)
            {
                if (employee.ID==id)
                {
                    return employee;
                }
            }
            return null;
        }
    }
}
