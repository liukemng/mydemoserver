using Android.Server.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Android.Server.WebAPI.Models
{
    public class TestMessageModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string detail { get; set; }
        public string userName { get; set; }
        public DateTime createTime { get; set; }
    }

    public static class TestMessageModelExtensions
    {
        public static TestMessageModel ToTestMessageModel(this TestMessage model)
        {
            return new TestMessageModel
            {
                id = model.Id,
                title = model.Title,
                detail = model.Detail,
                userName = model.Account != null ? model.Account.UserName : string.Empty,
                createTime = model.CreateTime
            };
        }

        public static IList<TestMessageModel> ToTestMessageModels(this IList<TestMessage> models)
        {
            var ret = new List<TestMessageModel>();
            foreach (var x in models)
            {
                ret.Add(x.ToTestMessageModel());
            }
            return ret;
        }
    }
}