using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.DTOs
{
    public class UserPublishedDto
    {
        public Guid Id { get; set; }

        public String Email { get; set; }

        public String Password { get; set; }

        public String Event { get; set; }

    }
}