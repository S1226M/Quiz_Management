using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuizeManagement.Models
{
    public class UserLogin
    {
        [Required]
        [DisplayName("Enter User Name")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Enter User Password")]
        public string Password { get; set; }
        [Required]
        [DisplayName("Enter User Name")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Enter User Name")]
        public string PhoneNumber { get; set; }

    }
}
