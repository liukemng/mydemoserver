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
    public class AccountController : ApiControllerBase
    {
        /// <summary>
        /// 获取Account
        /// </summary>
        /// <param name="tokenValue"></param>
        /// <returns></returns>
        public HttpResponseMessage Get(string tokenValue)
        {
            System.Threading.Thread.Sleep(1000);
            //设置IIS Express外部访问：配置完applicationhost.config之后以管理员身份在cmd下添加下面的命令
            //netsh http add urlacl url=http://192.168.1.27:5511/ user=everyone
            var requestUri = Request.RequestUri.PathAndQuery;
            var accountId = 0;
            if (IdentityVerify(tokenValue, ref accountId))
            {
                //var account = AccountService.GetById(accountId);

                //这里的代码仅用于测试
                var account = new Account { 
                    Id=1,
                    UserName="11",
                    PassWord="11"
                };

                return Request.CreateResponse(HttpStatusCode.OK, new AccountModel { id = account.Id, userName = account.UserName, passWord = account.PassWord });
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorModel { errorCode = ErrorCode.TokenValueExpired, errorMessage = Resource.tokenValueNullOrExpired, requestUri = requestUri });
        }
    }
}