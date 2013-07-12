using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Android.Server.DomainModels
{
    public partial class AccessToken
    {
        public virtual int Id { get; set; }
        /// <summary>
        /// 该token所属的APP
        /// </summary>
        public virtual Application Application { get; set; }
        /// <summary>
        /// 该token所属的账户
        /// </summary>
        public virtual Account Account { get; set; }
        /// <summary>
        /// token值
        /// </summary>
        public virtual string TokenValue { get; set; }
        /// <summary>
        /// 最后一次登录时间
        /// </summary>
        public virtual DateTime LoginTime { get; set; }
        /// <summary>
        /// 用来表示是否在登录状态
        /// </summary>
        public virtual bool Enabled { get; set; }
    }
}
