using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Android.Server.DomainModels
{
    public partial class TestMessage
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Detail { get; set; }
        public virtual Account Account { get; set; }
        public virtual DateTime CreateTime { get; set; }
    }
}
