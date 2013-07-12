using Android.Server.DomainModels;
using Android.Server.WebAPI.Models;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace Android.Server.WebAPI.Controllers
{
    public class AccessTokenController : ApiControllerBase
    {
        /// <summary>
        /// 认证获取accesstoken
        /// </summary>
        /// <param name="appKey"></param>
        /// <param name="appSecret"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public HttpResponseMessage Get(string appKey, string appSecret, string userName, string passWord)
        {
            var requestUri = Request.RequestUri.PathAndQuery;

            //var application = ApplicationService.GetByKeySecret(appKey, appSecret);//从数据库获取对应的application
            //if (application == null)

            //这里的代码仅用于测试
            var application = new Application { 
                Id=1,
                AppName="Test",
                AppKey = "635022223931350076",
                AppSecret = "4166551e59857a2b88b168f92115a4e1",
                Enabled=true
            };
            if (appKey != "635022223931350076" || appSecret != "4166551e59857a2b88b168f92115a4e1")
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorModel { errorCode = ErrorCode.AppValidateFailed, errorMessage = Resource.appValidateFailed, requestUri = requestUri });
            else
            {
                if (application.Enabled)
                {
                    //var account = AccountService.Login(userName, passWord);//从数据库获取对应的account
                    //if (account == null)

                    var account = new Account { 
                        Id=1,
                        UserName="11",
                        PassWord="11",
                        Enabled=true
                    };
                    if (userName!="11" || passWord!="11")
                        return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorModel { errorCode = ErrorCode.AccountValidateFailed, errorMessage = Resource.accountValidateFailed, requestUri = requestUri });
                    else
                    {
                        if (account.Enabled)
                        {
                            //保存或更新AccessToken
                            /*var accessToken = AccessTokenService.GetByAppAccount(application.Id, account.Id);
                            if (accessToken == null)
                            {
                                accessToken = new AccessToken
                                {
                                    Application = new Application { Id = application.Id },
                                    Account = new Account { Id = account.Id },
                                    TokenValue = (application.Id.ToString() + account.Id.ToString() + DateTime.Now.Ticks.ToString()).HashMD5(),
                                    LoginTime = DateTime.Now,
                                    Enabled = true
                                };
                                AccessTokenService.Create(accessToken);//如果不存在就保存登录的AccessToken
                            }
                            else
                            {
                                accessToken.TokenValue = (application.Id.ToString() + account.Id.ToString() + DateTime.Now.Ticks.ToString()).HashMD5();//重新生成TokenValue
                                accessToken.Enabled = true;//设为登录状态
                                AccessTokenService.Update(accessToken);//如果存在就更新AccessToken
                            }*/

                            //这里的代码仅用于测试
                            var accessToken = new AccessToken {
                                Application = new Application { Id = application.Id },
                                Account = new Account { Id = account.Id },
                                TokenValue = (application.Id.ToString() + account.Id.ToString() + DateTime.Now.Ticks.ToString()),//.HashMD5(),
                                LoginTime = DateTime.Now,
                                Enabled = true
                            };

                            AddOrUpdateVerifiedAccount(accessToken.TokenValue, accessToken.Application.Id, accessToken.Account.Id);
                            return Request.CreateResponse(HttpStatusCode.OK, new AccessTokenModel { tokenValue = accessToken.TokenValue });
                        }
                        else
                            return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorModel { errorCode = ErrorCode.AccountForbidden, errorMessage = Resource.accountForbidden, requestUri = requestUri });
                    }
                }
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorModel { errorCode = ErrorCode.AppForbidden, errorMessage = Resource.appForbidden, requestUri = requestUri });
            }
        }
    }
}