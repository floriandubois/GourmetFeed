using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Instaply.GourmetFeed.Models.Core
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName))
                return;

            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
