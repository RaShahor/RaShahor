using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
        public int? Class { get; set; }
        public int? Status { get; set; }
        public int? Order { get; set; }//changed from byte to int!
        [JsonIgnore]
        public virtual FormUser Form { get; set; }
        [JsonIgnore]
        public virtual Signer Signer { get; set; }
        [JsonIgnore]
        public virtual ICollection<FormSigner> FormSigners { get; set; }
    }
}
