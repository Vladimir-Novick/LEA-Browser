using System;
using System.ComponentModel;

namespace LEA.Lib.Model
{
    public sealed class InvestigationItem : ICloneable
    {
        public int id { get; set; }
        public String Name { get; set; }
        [DisplayName("Creation Date")]
        public DateTime CreationDate { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
