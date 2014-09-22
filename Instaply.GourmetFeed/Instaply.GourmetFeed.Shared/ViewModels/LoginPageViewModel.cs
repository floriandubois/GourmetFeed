using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Instaply.GourmetFeed.Common;
using Instaply.GourmetFeed.Models;
using Instaply.GourmetFeed.Models.Core;
using Instaply.GourmetFeed.Services.RestApi;

namespace Instaply.GourmetFeed.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        #region Fields

        private readonly Frame _rootFrame;
        private User _user;
        private bool _isLoading;

        #endregion

        #region Properties

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
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

        #region Commands

        public RelayCommand LoginCommand { get; set; }
        public RelayCommand CreateAccountCommand { get; set; }

        #endregion

        #region Constructor

        public LoginPageViewModel(Frame rootFrame, User user = null)
        {
            _rootFrame = rootFrame;
            IsLoading = false;

            User = user ?? new User();

            LoginCommand = new RelayCommand(() => { Login(); });
            CreateAccountCommand = new RelayCommand(() => { CreateUSer(); });
        }

        #endregion

        #region Methods

        private async void Login()
        {
            if (User == null)
                return;

            eValidationValues validation = User.ValidateLogin();
            if (validation != eValidationValues.Valid)
            {
                NotValidDisplay(validation);
                return;
            }
            IsLoading = true;
            await Task.Delay(15);
            try
            {

                var usr = await UserHelper.Instance.LogIn(User);
                ApplicationContext.User = usr;
                IsLoading = false;

#if WINDOWS_PHONE_APP
            _rootFrame.Navigate(typeof (MainPage));
#endif
                return;
            }
            catch (Exception exception)
            {
                MessageDialog md = new MessageDialog(exception.Message);
                md.ShowAsync();
            }

            IsLoading = false;
        }

        private async void CreateUSer()
        {
#if WINDOWS_PHONE_APP
            _rootFrame.Navigate(typeof (CreateUserPage));
#endif
            IsLoading = false;
        }

        private void NotValidDisplay(eValidationValues result)
        {
            string message;
            switch (result)
            {
                case eValidationValues.EmailAddressEmpty:
                    message = "The email address cannot be empty";
                    break;
                case eValidationValues.PasswordEmpty:
                    message = "The password cannot be empty";
                    break;
                case eValidationValues.EmailInvalid:
                    message = "The email address is invalid";
                    break;
                default:
                    message = "";
                    break;
            }
            MessageDialog messageDialog = new MessageDialog(message);
            messageDialog.ShowAsync();
        }

        #endregion
    }
}
