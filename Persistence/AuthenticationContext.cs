﻿using AuthenticationService.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.Persistence
{
    public class AuthenticationContext : IdentityDbContext<User>
    {
        public AuthenticationContext(DbContextOptions options) : base(options)
        {
           
    }
       
    }
}
