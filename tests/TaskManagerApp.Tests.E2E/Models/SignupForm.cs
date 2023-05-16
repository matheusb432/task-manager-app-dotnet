namespace TaskManagerApp.Tests.E2E.Models
{
    public sealed class SignupForm
    {
        private SignupForm() { }

        public static SignupForm AsValid(
            string name,
            string userName,
            string password,
            string email
        )
        {
            return new SignupForm
            {
                Name = name,
                UserName = userName,
                Password = password,
                ConfirmPassword = password,
                Email = email
            };
        }

        public string Name { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
