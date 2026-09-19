using System;
using System.Collections.Generic;
using System.Text;

namespace Domain_Layer.Users
{
    public class Courier
    {

        public int Id { get; set; }
        public string CourierCode { get; set; }
        public string NationalId { get; set; }
        public string VehicleType { get; set; }
        public string VehicleNumber { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }
    }
}
