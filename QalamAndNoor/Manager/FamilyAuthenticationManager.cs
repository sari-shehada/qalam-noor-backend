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
                message = "Username Does Not Exist";
            }
            else
            {
                if (filterResult.Password == password)
                {
                    message = "Logged In Successfully";
                    familyResult = filterResult;
                }
                else
                {
                    message = "Password Incorrect";
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
