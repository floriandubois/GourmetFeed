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
    public class CreateAccountPageViewModel : ViewModelBase
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

        public RelayCommand CreateAccountCommand { get; set; }

        #endregion

        #region Constructor

        public CreateAccountPageViewModel(Frame rootFrame, User user = null)
        {
            _rootFrame = rootFrame;
            IsLoading = false;

            User = user ?? new User();
            User.IdentificationService = "1";
            CreateAccountCommand = new RelayCommand(() => { CreateAccount(); });
        }

        #endregion

        #region Methods

        private async void CreateAccount()
        {
            if (User == null)
                return;

            eValidationValues validation = User.ValidateCreateUser();
            if (validation != eValidationValues.Valid)
            {
                NotValidDisplay(validation);
                return;
            }

            IsLoading = true;
            await Task.Delay(15);
            try
            {
                var usr = await UserHelper.Instance.Create(User);
                ApplicationContext.User = usr;
                IsLoading = false;

                return;
            }
            catch (Exception exception)
            {
                MessageDialog md = new MessageDialog(exception.Message);
                md.ShowAsync();
            }

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
                case eValidationValues.FirstNameEmpty:
                    message = "The first name cannot be empty";
                    break;
                case eValidationValues.LastNameEmpty:
                    message = "The last name cannot be empty";
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
