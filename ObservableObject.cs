using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BindingDemo
{
    internal abstract class ObservableObject : INotifyPropertyChanged, IDataErrorInfo
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [Bindable(false)] 
        public virtual string Error => string.Empty;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        #endregion

        #region IDataErrorInfo

        public string this[string propertyName] => this.ValidateProperty(propertyName);

        protected virtual string ValidateProperty(string propertyName) => string.Empty;

        #endregion
    }
}