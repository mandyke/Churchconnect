using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchConnectLite.Core.Entities
{
   public class Denomination
    {
        public int ID { get; set; }

        public string ApplicationUserId { get; set; }
        public string Name { get; set; }
        public string LogoBlobName { get; set; }

        public string Logo { get; set; }
        public ApplicationUser AppUser { get; set; }
        public virtual ICollection<Church> Churches { get; set; }
    }
}
