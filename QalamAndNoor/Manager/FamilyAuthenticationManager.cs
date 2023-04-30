using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class FamilyAuthenticationManager
    {
        public static object FamilyAuthentication(string userName, string password)
        {
            Family? familyResult = null;
            string message = string.Empty;
            Family? filterResult = FamilyManager.GetFamilies().FirstOrDefault(e => e.UserName == userName);
            if (filterResult == null)
            {
                message = "اسم المستخدم غير موجود";
            }
            else
            {
                if (filterResult.Password == password)
                {
                    message = "تمت عملية تسجيل الدخول بنجاح";
                    familyResult = filterResult;
                }
                else
                {
                    message = "كلمة المرور خاطئة";
                }
            }

            return new
            {
                Message = message,
                Family = familyResult,
                success = familyResult != null
            };
        }
    }
}
