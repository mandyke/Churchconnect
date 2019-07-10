using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchConnectLite.Core.Entities
{
    public class ChurchSize
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NumericDescription { get; set; }

        public virtual ICollection<Church> Churches { get; set; }
    }
}
