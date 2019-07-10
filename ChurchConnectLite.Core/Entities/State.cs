using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchConnectLite.Core.Entities
{
   public class State
    {
        public int ID { get; set; }
        public int? CountryId { get; set; }
        public string Name { get; set; }

        public virtual Country Country { get; set; }
        //public virtual ICollection<Church> Churches { get; set; }
    }
}
