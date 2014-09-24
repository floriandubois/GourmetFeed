using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Instaply.GourmetFeed.Models.Core;

namespace Instaply.GourmetFeed.Models
{
   public partial class  PostDetails
   {

       /// <summary>
       /// URL of the photos
       /// </summary>
       public bool IsLiked
       {
           get
           {
               if (LikingUsers != null && LikingUsers.Any())
                   return LikingUsers.Any(x => x.FirstName == ApplicationContext.User.FirstName);

               return false;
           }
       }
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
    }
}
