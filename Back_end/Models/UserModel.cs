namespace Back_end.Models
{
    public class UserModel
    {
        public UserModel(int idUser, string name, string email, string password)
        {
            IdUser = idUser;
            Name = name;
            Email = email;
            Password = password;
        }

        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


    }
}
