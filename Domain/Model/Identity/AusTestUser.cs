using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AusTest.Domain.Model.Identity
{
    public class AusTestUser : IdentityUser<int>
    {
        public IList<Requirement> Resuirements { get; set; } 
    }
}
