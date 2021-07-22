namespace SocialService.Storage.ValueObjects
{
    public class User
    {
        // Explain about immutable model
        public User(
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
