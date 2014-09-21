
namespace Instaply.GourmetFeed.Models
{
    public class User
    {
        /// <summary>
        /// Email of the user
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Password of the user
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// UID of the user
        /// </summary>
        public string IdentificationService { get; set; }
        /// <summary>
        /// First name of the user
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last name of the user
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Access token
        /// </summary>
        public string AccessToken { get; set; }
    }
}
