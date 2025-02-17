using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuizeManagement.Models
{
    public class UserLoginModel
    {
        public int UserID { get; set; }

        [Required(ErrorMessage ="Name is require")]
        [DisplayName("Enter User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is require")]
        [DisplayName("Enter User Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Name is require")]
        [DisplayName("Enter User Name")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Name is require")]
        [DisplayName("Enter User Name")]

        [MaxLength(10)]
        [Phone]
        public string Mobile { get; set; }
    }
}
