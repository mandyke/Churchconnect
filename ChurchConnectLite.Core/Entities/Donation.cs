using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchConnectLite.Core.Entities
{
   public class Donation
    {
        public int ID { get; set; }
        public int ChurchId { get; set; }
        public string Email { get; set; }
        public decimal Amount { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public int? TransactionID { get; set; }
        public int? ReferenceId { get; set; }
        public Church Church { get; set; }
    }
}
