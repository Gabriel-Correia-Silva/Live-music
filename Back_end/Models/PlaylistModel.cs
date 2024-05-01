using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_end.Models
{
    public class PlaylistModel
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPlaylist { get; set; }

        public string NamePlaylist { get; set; }

        public List<int> MusicIds { get; set; } = new List<int>();

        public int IdUser { get; set; }
    }
}