using System;
using System.Collections.Generic;

#nullable disable

namespace RSWebApp.Models
{
    public partial class Class
    {
        public Class()
        {
            FormSigners = new HashSet<FormSigner>();
            Signs = new HashSet<Sign>();
        }

        public short Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<FormSigner> FormSigners { get; set; }
        public virtual ICollection<Sign> Signs { get; set; }
    }
}
