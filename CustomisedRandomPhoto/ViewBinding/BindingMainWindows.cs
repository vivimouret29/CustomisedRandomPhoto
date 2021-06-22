using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CustomisedRandomPhoto.ViewBinding
{
    public class BindingMainWindows : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Property of BindingMainWindows class
        /// </summary>
        public string ImageUri
        {
            get;
            set;
        }

        #region INotifyPropertyChanged
        /// <summary>
        /// Interaction logical data change notification
        /// </summary>
        /// <param name="_PropertyChanged"></param>
        protected void OnPropertyChanged([CallerMemberName] string _PropertyChanged = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_PropertyChanged));
        }
        #endregion
    }
}
