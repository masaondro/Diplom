namespace VKR.Contracts.User
{
    public class CreateModeratorDto: RegisterUserDto
    {
        public string CurrentUserId { get; set; }
    }
}