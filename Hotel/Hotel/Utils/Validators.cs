using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Hotel.Utils
{
    internal static class Validators
    {
        public static bool ValidateEmail(string email)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(email);
                return true;
            }
            catch (System.FormatException)
            {
                UserDialog.MessageDialog(message: "Invalid email adress!", type: DialogType.Alert);
            }
            catch(System.Exception)
            {

            }
            return false;
        }

        public static bool ValidatePassword(string password)
        {
            //match further only if there are two digits anywhere
            //match further only if there is an upper-lower case letter
            //match further only if theres anything except letter or digit
            //match 8 or more characters
            UserDialog.MessageDialog(message: "Password must contains more than 8 characters upper and lower, more than 2 digits, and symbols.", type: DialogType.Alert);
            return Regex.IsMatch(password, @"^(?=(.*\d){2})(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z\d]).{8,}$");
        }
    }
}
