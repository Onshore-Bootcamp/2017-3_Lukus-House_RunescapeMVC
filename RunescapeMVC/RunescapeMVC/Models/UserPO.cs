using System.ComponentModel.DataAnnotations;

namespace RunescapeMVC.Models
{
    public class UserPO
    {
        public long UserID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public int Role { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}