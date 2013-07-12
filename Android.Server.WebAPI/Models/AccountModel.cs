using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Android.Server.WebAPI.Models
{
    public class AccountModel
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string passWord { get; set; }
        //[JsonIgnore]//标记属性不被序列化
        //public bool enabled { get; set; }
    }

    public static class AccountModelExtensions
    {
        //public static AccountModel ToAccountModel(this Account model)
        //{
        //    return new AccountModel
        //    {
        //        id = model.Id,
        //        userName = model.UserName,
        //        passWord = model.PassWord
        //        //enabled=model.Enabled
        //    };
        //}
    }
}