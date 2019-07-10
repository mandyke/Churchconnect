using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchConnectLite.Core.Entities
{
   public class Church
    {
        public int ID { get; set; }

        public int? DenominationId { get; set; }

        public string ApplicationUserId { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public int Visitor { get; set; }
        public string Name   { get; set; }
        public int? YearFounded { get; set; }

        public string About { get; set; }

      

        public string Email { get; set; }

        public string Phone1 { get; set; }
        public string Phone2 { get; set; }

        public string WorshipDays { get; set; }

        public string Website { get; set; }

        public string LogoUrl { get; set; }

        public string LogoBlobName { get; set; }
        public string Address { get; set; }
        public string OnlineServiceUrl { get; set; }
        
        // Bank Account Details
        public string BankName { get; set; }

        public string AccountName { get; set; }

        public string AccountNumber { get; set; }

        // Social Media Handle

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string Instagram { get; set; }

        // Navigation Properties

        public ApplicationUser ApplicationUser { get; set; }
       
        public Denomination Denominations { get; set; }

        public MainMinister MainMinisters { get; set; }
        public ICollection<Minister> Ministers { get; set; }

        public ICollection<Image> Gallery { get; set; }

        public ICollection<Donation> Donations { get; set; }

    }
}
