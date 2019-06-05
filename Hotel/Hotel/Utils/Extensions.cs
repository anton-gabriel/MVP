using Hotel.Models.Entity;

namespace Hotel.Utils
{
    internal static class Extensions
    {
        public static bool HasDataForLogin(this User user)
        {
            return (user?.Email.Length != 0) && (user?.Password.Length != 0);
        }
        public static bool HasDataForRegister(this User user)
        {
            return (user?.FirstName.Length != 0) &&
                (user?.LastName.Length != 0) &&
                (user?.Email.Length != 0) &&
                (user?.Password.Length != 0);
        }
    }
}
