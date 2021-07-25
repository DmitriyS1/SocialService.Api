namespace SocialService.Management.DTOs.PopularUserDto
{
    public class PopularUserDto
    {
        public PopularUserDto(
            string login,
            int popularity)
        {
            Login = login;
            Popularity = popularity;
        }

        public string Login { get; }

        public int Popularity { get; }
    }
}
