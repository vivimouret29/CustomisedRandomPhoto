using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomisedRandomPhoto.ViewBinding
{
    public class BindingMainWindows : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //private ObservableCollection<string> _ImageUri;

        //public BindingMainWindows()
        //{
        //    ImageUri = _ImageUri;
        //}

        /// <summary>
        /// First attempt at a random site string link
        /// </summary>
        //public ObservableCollection<string> ImageUri
        //{
        //    get => this._ImageUri;
        //    set
        //    {
        //        if (value != this._ImageUri)
        //        {
        //            this._ImageUri = (ObservableCollection<string>)value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}

        /// <summary>
        /// Second attempt at a random site string link
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
