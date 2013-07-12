using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Android.Server.DomainModels
{
    public partial class Application
    {
        public virtual int Id { get; set; }
        /// <summary>
        /// 应用名称
        /// </summary>
        public virtual string AppName { get; set; }
        public virtual string AppKey { get; set; }
        public virtual string AppSecret { get; set; }
        public virtual bool Enabled { get; set; }
    }
}
