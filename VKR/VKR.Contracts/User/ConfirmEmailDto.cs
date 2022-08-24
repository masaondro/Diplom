namespace VKR.Contracts.User
{
    public class ConfirmEmailDto
    {
        public string Token { get; set; }
        public string UserId { get; set; }
    }
}