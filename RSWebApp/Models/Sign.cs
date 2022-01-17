using System;
using System.Collections.Generic;

#nullable disable

namespace RSWebApp.Models
{
    public partial class Sign
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public short? PageNum { get; set; }
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }
        public short Class { get; set; }

        public virtual Class ClassNavigation { get; set; }
    }
}
