using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Android.Server.WebAPI.Models
{
    public class AccessTokenModel
    {
        public string tokenValue { get; set; }
    }

    public static class AccessTokenModelExtensions
    {
        //public static AccountModel ToAccountModel(this AccessToken model)
        //{
        //    return new AccessTokenModel
        //    {
        //        id=model.Id,
        //        userName = model.UserName,
        //        password = model.Password,
        //        enabled=model.Enabled
        //    };
        //}
    }
}