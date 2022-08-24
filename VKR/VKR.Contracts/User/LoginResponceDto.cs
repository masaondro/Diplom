namespace VKR.Contracts.User
{
    public class LoginResponceDto
    {
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string[] Roles { get; set; }
        public string Token { get; set; }
    }
}