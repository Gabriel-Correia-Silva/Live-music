namespace Back_end.Models
{
    public class GroupModel
    {
        public GroupModel(int idGroup, string nameGroup, UserModel idUsers, PlaylistModel playlist, UserModel adminGroup)
        {
            IdGroup = idGroup;
            NameGroup = nameGroup;
            IdUsers = idUsers;
            Playlist = playlist;
            AdminGroup = adminGroup;
        }

        public int IdGroup { get; set; }

        public string NameGroup { get; set; }

        public UserModel IdUsers { get; set; }

        public PlaylistModel Playlist { get; set; }

        public UserModel AdminGroup { get; set; }
    }
}
