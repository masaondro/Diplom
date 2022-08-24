namespace VKR.Contracts.User
{
    public class RegisterUserDto
    {
        public string Password { get; set; }
        
        public string PasswordConfirmation { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
    }
}