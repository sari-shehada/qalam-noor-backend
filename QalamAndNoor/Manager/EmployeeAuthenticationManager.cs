using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class EmployeeAuthenticationManager
    {
        public static object EmployeeAuthentication(string userName, string password)
        {
            Employee? employeeResult = null;
            string message = string.Empty;
            JobTitle? jobTitle= null;
            Employee? filterResult = EmployeeManager.GetEmployees().FirstOrDefault(e => e.UserName == userName);
            if (filterResult == null)
            {
                message = "اسم المستخدم غير موجود";
            }
            else
            {
                if (filterResult.Password == password)
                {
                    message = "تمت عملية تسجيل الدخول بنجاح";
                    employeeResult = filterResult;
                    jobTitle = JobTitleManager.GetJobTitleById(employeeResult.JobTitleId);
                }
                else
                {
                    message = "كلمة المرور خاطئة";
                }
            }

            return new
            {
                Message = message,
                Employee = employeeResult,
                success = employeeResult != null,
                JobTitle= jobTitle
            };
        }
    }
}
