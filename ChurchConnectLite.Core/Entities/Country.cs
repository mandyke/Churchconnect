using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchConnectLite.Core.Entities
{
   public class Country
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<State> States { get; set; }
        //public ICollection<Church> Churches { get; set; }
    }
}
