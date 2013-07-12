using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Android.Server.WebAPI.Models
{
    public enum ErrorCode { AppValidateFailed, AppForbidden, AccountValidateFailed, AccountForbidden, TokenValueExpired }

    public class ErrorModel
    {
        public virtual ErrorCode errorCode { get; set; }
        public virtual string errorMessage { get; set; }
        public virtual string requestUri { get; set; }
    }
}