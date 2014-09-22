using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Instaply.GourmetFeed.Models;
using Instaply.GourmetFeed.Services.Core;

namespace Instaply.GourmetFeed.Services.RestApi
{
    public class PostsHelper
    {
        private static volatile PostsHelper instance;
        private static object syncRoot = new Object();

        private PostsHelper() { }

        public static PostsHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new PostsHelper();
                    }
                }

                return instance;
            }
        }

        public async Task<Post> LoadPosts()
        {
            return await RestApiHelper.ExecuteAsync<Post>(ApiEndpoints.GetPosts, HttpMethod.Get);
        }

        public async Task<Post> LikePost(PostDetails post)
        {
            return await RestApiHelper.ExecuteAsync<Post>(ApiEndpoints.GetPosts + post.ResourceIdentifier + "/like", HttpMethod.Post);
        }
    }
}
