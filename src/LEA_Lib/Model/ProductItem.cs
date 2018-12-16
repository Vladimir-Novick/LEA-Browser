using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace LEA.Lib.Model
{
    public sealed class ProductItem : ICloneable
    {
        public int Id { get; set; }
        public int Type { get; set; }
        [DisplayName("Creation Date")]
        public DateTime CreationDate { get; set; }
        public String Source { get; set; }
        public String Destination { get; set; }
        public int InvestigationId { get; set; }
        [DisplayName("Investigation")]
        public string Investigation { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
