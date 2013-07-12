using Android.Server.WebAPI.Models;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using Android.Server.DomainModels;

namespace Android.Server.WebAPI.Controllers
{
    /// <summary>
    /// 请求类型（刷新还是加载更多）
    /// </summary>
    public enum RequestType { Refresh = 0, Load = 1 }

    public class TestMessageController : ApiControllerBase
    {
        /// <summary>
        /// 获取信息列表
        /// </summary>
        /// <param name="tokenValue"></param>
        /// <returns></returns>
        public HttpResponseMessage Get(string tokenValue)
        {
            var requestUri = Request.RequestUri.PathAndQuery;
            var accountId = 0;
            if (IdentityVerify(tokenValue, ref accountId))
            {
                //var testMessages = TestMessageService.GetByAccountId(accountId);

                //这里的代码仅用于测试
                var testMessages = new List<TestMessage>();
                testMessages.Add(new TestMessage
                {
                    Id = 1,
                    Title = "AA",
                    Detail = "BB",
                    Account = new Account
                    {
                        Id = 1,
                        UserName = "11",
                        PassWord = "11",
                        Enabled = true
                    },
                    CreateTime = DateTime.Now
                });

                return Request.CreateResponse(HttpStatusCode.OK, testMessages.ToTestMessageModels());
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorModel { errorCode = ErrorCode.TokenValueExpired, errorMessage = Resource.tokenValueNullOrExpired, requestUri = requestUri });
        }

        /// <summary>
        /// 获取单条信息
        /// </summary>
        /// <param name="tokenValue">tokenValue</param>
        /// <param name="id">要获取的信息id</param>
        /// <returns></returns>
        public HttpResponseMessage Get(string tokenValue, int id)
        {
            var requestUri = Request.RequestUri.PathAndQuery;
            var accountId = 0;
            if (IdentityVerify(tokenValue, ref accountId))
            {
                //var testMessage = TestMessageService.GetById(id);

                //这里的代码仅用于测试
                var testMessage = new TestMessage
                {
                    Id = 1,
                    Title = "AA",
                    Detail = "BB",
                    Account = new Account
                    {
                        Id = 1,
                        UserName = "11",
                        PassWord = "11",
                        Enabled = true
                    },
                    CreateTime = DateTime.Now
                };

                return Request.CreateResponse(HttpStatusCode.OK, testMessage.ToTestMessageModel());
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorModel { errorCode = ErrorCode.TokenValueExpired, errorMessage = Resource.tokenValueNullOrExpired, requestUri = requestUri });
        }

        /// <summary>
        /// 刷新或加载更多信息
        /// </summary>
        /// <param name="tokenValue">tokenValue</param>
        /// <param name="id">当前id</param>
        /// <param name="type">刷新或者加载</param>
        /// <returns></returns>
        public HttpResponseMessage Get(string tokenValue, int id, RequestType type)
        {
            var requestUri = Request.RequestUri.PathAndQuery;
            var accountId = 0;
            if (IdentityVerify(tokenValue, ref accountId))
            {
                IList<TestMessage> testMessages = new List<TestMessage>();
                if (type == RequestType.Refresh)
                    //testMessages = TestMessageService.Get();

                    //这里的代码仅用于测试
                    testMessages.Add(new TestMessage
                    {
                        Id = 1,
                        Title = "Refresh",
                        Detail = "Refresh",
                        Account = new Account
                        {
                            Id = 1,
                            UserName = "11",
                            PassWord = "11",
                            Enabled = true
                        },
                        CreateTime = DateTime.Now
                    });
                else if (type == RequestType.Load)
                    //testMessages = TestMessageService.Get();

                    //这里的代码仅用于测试
                    testMessages.Add(new TestMessage
                    {
                        Id = 1,
                        Title = "Load",
                        Detail = "Load",
                        Account = new Account
                        {
                            Id = 1,
                            UserName = "11",
                            PassWord = "11",
                            Enabled = true
                        },
                        CreateTime = DateTime.Now
                    });
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorModel { errorCode = ErrorCode.TokenValueExpired, errorMessage = Resource.errorRequestParameters, requestUri = requestUri });
                return Request.CreateResponse(HttpStatusCode.OK, testMessages.ToTestMessageModels());
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorModel { errorCode = ErrorCode.TokenValueExpired, errorMessage = Resource.tokenValueNullOrExpired, requestUri = requestUri });
        }
    }
}