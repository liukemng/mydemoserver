using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Android.Server.DomainModels
{
    public partial class Account
    {
        public virtual int Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string PassWord { get; set; }
        public virtual bool Enabled { get; set; }
    }
}
