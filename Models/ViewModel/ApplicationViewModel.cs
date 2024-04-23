using System.ComponentModel.DataAnnotations;

namespace Custom_User_Management.Models.ViewModel
{
    public class ApplicationViewModel
    {
        public string Id { get; set; }

        //[Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }   

        //[Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        //[RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "Invalid email format.")]

        //[Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //[Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        //[Required]
        [Display(Name = "Phone Number")]
        //[RegularExpression(@"^\+?[0-9]{3}-?[0-9]{6,12}$", ErrorMessage = "Invalid phone number format.")]
        public string PhoneNumber { get; set; }

        //[Required]
        [Display(Name = "Profile Picture")]
        public byte[] ProfilePicture { get; set; }
        public bool RememberMe { get; internal set; }
    }
}
