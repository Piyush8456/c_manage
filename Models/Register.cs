using System.ComponentModel.DataAnnotations;

namespace Custom_User_Management.Models
{
    public class Register
    {
        public string Id { get; set; }

   
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] ProfilePicture { get; set; }
    }
}
