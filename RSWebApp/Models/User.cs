using System;
using System.Collections.Generic;

#nullable disable

namespace RSWebApp.Models
{
    public partial class User
    {
        public User()
        {
            FormUsers = new HashSet<FormUser>();
            Signers = new HashSet<Signer>();
        }

        public int Id { get; set; }
        public int? PersonId { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<FormUser> FormUsers { get; set; }
        public virtual ICollection<Signer> Signers { get; set; }
    }
}
