using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Android.Server.WebAPI.Controllers
{
    class ValidateIdentify
    {
        public int applicationId { get; set; }
        public int accountId { get; set; }
    }

    public abstract class ApiControllerBase : ApiController
    {
        //public IAccountService AccountService { get; set; }
        //public ITestMessageService TestMessageService { get; set; }
        //public IApplicationService ApplicationService { get; set; }
        //public IAccessTokenService AccessTokenService { get; set; }

        public object GetService(string serviceType)
        {
            var prop = this.GetType().GetProperties().FirstOrDefault(x => x.Name.Equals(serviceType, StringComparison.OrdinalIgnoreCase));
            if (prop != null)
                return prop.GetValue(this, null);
            return null;
        }

        /// <summary>
        /// 当前已经获取AccessToken的账户
        /// 返回 Hashtable 的同步（线程安全）包装
        /// </summary>
        private static Hashtable verifiedAccounts = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        /// 添加或更新验证过的账户
        /// </summary>
        /// <param name="tokenValue"></param>
        /// <param name="applicationId"></param>
        /// <param name="accountId"></param>
        protected void AddOrUpdateVerifiedAccount(string tokenValue, int applicationId, int accountId)
        {
            if (verifiedAccounts.ContainsKey(tokenValue))
                UpdateVerifiedAccount(tokenValue, applicationId, accountId);
            else
                AddVerifiedAccount(tokenValue, applicationId, accountId);
        }

        /// <summary>
        /// 删除验证过的账户
        /// </summary>
        /// <param name="id"></param>
        protected void DeleteVerifiedAccount(string tokenValue)
        {
            verifiedAccounts.Remove(tokenValue);
        }

        /// <summary>
        /// 检查账户是否已经验证过，并传出accountId
        /// </summary>
        /// <param name="tokenValue"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        protected bool IdentityVerify(string tokenValue, ref int accountId)
        {
            if (verifiedAccounts.ContainsKey(tokenValue))
            {
                accountId = ((ValidateIdentify)verifiedAccounts[tokenValue]).accountId;
                return true;
            }
            else
            {
                //var accessToken = AccessTokenService.GetByTokenValue(tokenValue);
                //if (accessToken == null)
                    return false;
                //else
                //{
                //    accountId = accessToken.Account.Id;
                //    AddVerifiedAccount(accessToken.TokenValue, accessToken.Application.Id, accessToken.Account.Id);
                //    return true;
                //}
            }
        }

        /// <summary>
        /// 添加验证过的账户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="accountModel"></param>
        private void AddVerifiedAccount(string tokenValue, int applicationId, int accountId)
        {
            verifiedAccounts.Add(tokenValue, new ValidateIdentify { applicationId = applicationId, accountId = accountId });
        }

        /// <summary>
        /// 更新验证过的账户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="accountModel"></param>
        private void UpdateVerifiedAccount(string tokenValue, int applicationId, int accountId)
        {
            verifiedAccounts[tokenValue] = new ValidateIdentify { applicationId = applicationId, accountId = accountId };
        }
    }
}