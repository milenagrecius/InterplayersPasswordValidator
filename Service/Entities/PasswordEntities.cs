namespace InterplayersPassword.Core.Entities
{
    public class PasswordEntities
    {
        public string Password { get; private set; }
        public PasswordEntities(string password)
        {
            Password = password;
        }
    }
}
