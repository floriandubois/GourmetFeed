using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Instaply.GourmetFeed.Models;
using Instaply.GourmetFeed.Models.Core;
using Instaply.GourmetFeed.Services.Core;

namespace Instaply.GourmetFeed.Services.RestApi
{
    public class UserHelper
    {
        #region Singleton

        private static volatile UserHelper instance;
        private static object syncRoot = new Object();

        private UserHelper() { }

        public static UserHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new UserHelper();
                    }
                }

                return instance;
            }
        }
        
        #endregion
        public async Task<User> LogIn(User user)
        {
            return await RestApiHelper.ExecuteAsync<User, User>(user, ApiEndpoints.Login, HttpMethod.Post);
        }

        public async Task<User> Create(User user)
        {
            return await RestApiHelper.ExecuteAsync<User, User>(user, ApiEndpoints.CreateUser, HttpMethod.Post);
        }
    }
}
