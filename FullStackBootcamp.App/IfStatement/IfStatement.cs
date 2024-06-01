namespace FullStackBootcamp.App.IfStatement
{
    public class User
    {
        public string Password { get; set; }


        public void CreteUser()
        {
            //local function/method
            bool PasswordCheck()
            {
                if (string.IsNullOrEmpty(Password)) return false;

                if (Password.StartsWith("1234")) return false;

                if (Password.Length < 8) return false;


                return true;
                //return string.IsNullOrEmpty(Password) || Password.StartsWith("1234") || Password.Length < 8;
            }

            if (PasswordCheck())
            {
            }
        }
    }
}