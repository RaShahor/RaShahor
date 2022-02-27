using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class FormUser
    {
        public FormUser()
        {
            FormToSigners = new HashSet<FormToSigner>();
        }

        public int Id { get; set; }
        public string FormName { get; set; }
        public int? FormTemplateId { get; set; }
        public int UserId { get; set; }
        public string Path { get; set; }
        public bool? Resign { get; set; }

        public virtual FormTemplate FormTemplate { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<FormToSigner> FormToSigners { get; set; }
    }
}
