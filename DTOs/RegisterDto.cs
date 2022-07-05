using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.DTOs
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }


        //a number, lowercase, uppercase
      //  [Required]
    //    [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{4,10}$", ErrorMessage = "Password must be complex")]
        public string Password { get; set; }

      //  [Required]
        public string Username { get; set; }

      //  [Required]
      //  public DateTime DoB { get; set; }

    }
}
