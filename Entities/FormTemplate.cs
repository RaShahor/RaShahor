using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class FormTemplate
    {
        public FormTemplate()
        {
            FormUsers = new HashSet<FormUser>();
        }

        public int Id { get; set; }
        public int FormUserId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FormUser> FormUsers { get; set; }
    }
}
