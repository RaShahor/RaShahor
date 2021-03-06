using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class FormToSigner
    {
        public FormToSigner()
        {
            FormSigners = new HashSet<FormSigner>();
        }

        public int Id { get; set; }
        public int SignerId { get; set; }
        public int? FormId { get; set; }
        public int Class { get; set; }
        public int? Status { get; set; }
        public byte? Order { get; set; }

        public virtual FormUser Form { get; set; }
        public virtual Signer Signer { get; set; }
        public virtual ICollection<FormSigner> FormSigners { get; set; }
    }
}
