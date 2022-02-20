using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities { 
    public partial class Sign
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public short?  PageNum { get; set; }
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }
        public short Class { get; set; }
        [JsonIgnore]
        public virtual Class ClassNavigation { get; set; }
    }
}
