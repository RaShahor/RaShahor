using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class FormSigner
    {
        public int Id { get; set; }
        public short ClassId { get; set; }
        public int FormTosignerId { get; set; }
        public string SavedAtFile { get; set; }
        public DateTime Date { get; set; }
        public bool? Known { get; set; }
        [MaxLength(12)]
        [MinLength(8)]
        public string SignedFrom { get; set; }
        [JsonIgnore]
        public virtual Class Class { get; set; }
        [JsonIgnore]
        public virtual FormToSigner FormTosigner { get; set; }
    }
}
