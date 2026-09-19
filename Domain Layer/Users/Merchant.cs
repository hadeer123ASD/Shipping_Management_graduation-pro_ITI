
using System;
using System.Collections.Generic;
using System.Text;




namespace Domain_Layer.Users
{
    public class Merchant
    {
        public int Id { get; set; }
        public string  StoreName { get; set; }
        public string address { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }

    }
}
