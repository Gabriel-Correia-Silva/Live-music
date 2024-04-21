using System.ComponentModel.DataAnnotations;

namespace Back_end.Models
{
    public class UserModel
    {

        public int IdUser { get; set; }
        
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }


    }
}
