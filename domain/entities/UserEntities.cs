namespace API_de_rede_social.domain.entities
{
    public class UserEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public string PasswordHad { get; private set; }
        public object Followers { get; internal set; }

        public UserEntity(Guid id, string name, string email, string, string password)
        {

            Id = id;
            Name = name;
            Email = email;
            PasswordHad = password;
        }

    }

}
