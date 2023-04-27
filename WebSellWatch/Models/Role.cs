using System;
using System.Collections.Generic;

namespace WebSellWatch.Models
{
    public partial class Role
    {
        public Role()
        {
            Accounts = new HashSet<Account>();
        }

        public int RolesId { get; set; }
        public string RolesName { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
