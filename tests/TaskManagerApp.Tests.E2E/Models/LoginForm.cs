namespace TaskManagerApp.Tests.E2E.Models
{
    public sealed class LoginForm
    {
        private LoginForm()
        {
        }

        public static LoginForm AsValid(string userNameOrEmail, string password)
        {
            return new LoginForm
            {
                UserNameOrEmail = userNameOrEmail,
                Password = password,
            };
        }

        public static LoginForm FromSignup(SignupForm signupForm)
        {
            return new LoginForm
            {
                UserNameOrEmail = signupForm.UserName,
                Password = signupForm.Password,
            };
        }

        public string UserNameOrEmail { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}