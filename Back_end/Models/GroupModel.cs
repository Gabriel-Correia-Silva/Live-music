using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_end.Models
{
    public class GroupModel
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdGroup { get; set; }

        public string NameGroup { get; set; }

        public UserModel IdUsers { get; set; }

        public PlaylistModel Playlist { get; set; }

        public UserModel AdminGroup { get; set; }
    }
}
