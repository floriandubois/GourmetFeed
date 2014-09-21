using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instaply.GourmetFeed.Services.Core
{
    /// <summary>
    /// Endpoints for contacting service
    /// </summary>
    internal static class ApiEndpoints
    {
        #region Api

        /// <summary>
        /// Base URL of the service
        /// </summary>
        public const string BaseUrl = "http://devapi.gourmetfeed.com/";

        /// <summary>
        /// Current service version
        /// </summary>
        public const string Version = "/v1";

        #endregion

        #region User

        /// <summary>
        /// Login extension
        /// </summary>
        public const string Login = "/login";

        /// <summary>
        /// Create user extension
        /// </summary>
        public const string CreateUser = "/login";

        #endregion

        #region Posts

        /// <summary>
        /// Get posts extension
        /// </summary>
        public const string GetPosts = "/posts";

        #endregion
    }
}
