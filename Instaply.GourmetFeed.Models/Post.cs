using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Instaply.GourmetFeed.Models.Core;

namespace Instaply.GourmetFeed.Models
{
    public class Post
    {
        /// <summary>
        /// Represents the root URL of the images
        /// </summary>
        public string ImagesRootUrl { get; set; }
        /// <summary>
        /// List of posts
        /// </summary>
        public List<PostDetails> Posts { get; set; }
    }

    public class PostDetails
    {
        /// <summary>
        /// Title of the post
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Description of the post
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Author of the post
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// Creation time
        /// </summary>
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// UID of the post
        /// </summary>
        public Guid ResourceIdentifier { get; set; }
        /// <summary>
        /// URL of the photos
        /// </summary>
        public string[] PhotoUrls { get; set; }
        /// <summary>
        /// Photos count in post
        /// </summary>
        public int Photos { get; set; }
        /// <summary>
        /// URL of the photos
        /// </summary>
        public string PresentationPicture
        {
            get
            {
                if (PhotoUrls != null && PhotoUrls.Any())
                    return PhotoUrls[0];

                return "";
            }
        }

        public User[] LikingUsers{ get; set; }

        /// <summary>
        /// URL of the photos
        /// </summary>
        public bool IsLiked
        {
            get
            {
                if (LikingUsers != null && LikingUsers.Any())
                    return LikingUsers.Any(x=>x.FirstName==ApplicationContext.User.FirstName);

                return false;
            }
        }
    }
}
