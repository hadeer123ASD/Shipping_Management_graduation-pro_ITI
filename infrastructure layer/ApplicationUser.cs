using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace infrastructure_layer
{
    public class ApplicationUser : IdentityUser<Guid>
    {

        public string FullName { get; set; }
        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
