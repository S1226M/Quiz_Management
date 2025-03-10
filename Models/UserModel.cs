using System.ComponentModel.DataAnnotations;

namespace QuizeManagement.Models
{
    public class UserModel
    {
        public int? UserID { get; set; }

        //[Required(ErrorMessage ="User Name is Required")]
        public string UserName { get; set; }
        //[Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
        //[Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        //[Required(ErrorMessage = "Mobile Number is Required")]
        public string Mobile { get; set; }

        public byte IsActive {  get; set; }

        public byte IsAdmin { get; set; }
        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public class UserDropdownModel
        {
            public int UserID { get; set; }
            public string UserName { get; set; }
        }
    }
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
