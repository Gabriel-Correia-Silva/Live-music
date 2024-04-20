namespace Back_end.Models
{
    public class PlaylistModel
    {
        public PlaylistModel(int idPlaylist, string namePlaylist, MusicModel music, int idUser)
        {
            IdPlaylist = idPlaylist;
            NamePlaylist = namePlaylist;
            Music = music;
            IdUser = idUser;
        }

        public int IdPlaylist { get; set; }

        public string NamePlaylist { get; set; }

        public MusicModel Music { get; set; }

        public int IdUser { get; set; }
    }
}
