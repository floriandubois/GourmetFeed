using Instaply.GourmetFeed.Common;
using Instaply.GourmetFeed.Models;
using Instaply.GourmetFeed.Models.Core;
using Instaply.GourmetFeed.Services.RestApi;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;

namespace Instaply.GourmetFeed.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Field

        private readonly Frame _rootFrame;
        private ObservableCollection<PostDetails> _posts;
        private bool _isLoading;

        #endregion

        #region Commands

        public RelayCommand LoadPostsCommand { get; set; }

        #endregion

        #region Properties

        public ObservableCollection<PostDetails> Posts
        {
            get { return _posts; }
            set
            {
                _posts = value;
                OnPropertyChanged();
            }
        }

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructor

        public MainPageViewModel(Frame rootFrame, ObservableCollection<PostDetails> postDetails = null)
        {
            _rootFrame = rootFrame;

            Posts = postDetails ?? new ObservableCollection<PostDetails>();

            LoadPostsCommand = new RelayCommand(() => { LoadPosts(); });

            if (postDetails == null)
                LoadPosts();
        }

        #endregion

        #region Methods

        private async void LoadPosts()
        {
            IsLoading = true;
            Post posts=null;
            if (ApplicationContext.User == null)
#if WINDOWS_PHONE_APP
                _rootFrame.Navigate(typeof(LoginPage));
#endif
            posts = await PostsHelper.Instance.LoadPosts();
            if (posts == null)
            {
                IsLoading = false;
                return;
            }
            ApplicationContext.ImagesRootUrl = posts.ImagesRootUrl;
            Posts = new ObservableCollection<PostDetails>(posts.Posts);
        }

        #endregion
    }
}
