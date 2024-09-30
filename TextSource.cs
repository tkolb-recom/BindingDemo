using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BindingDemo
{
    internal class TextSource : INotifyPropertyChanged, IDataErrorInfo
    {
        #region INotifyPropertyChanged
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion

        #region IDataErrorInfo

        public string Error => string.Empty;

        public string this[string columnName]
        {
            get
            {
                if (columnName == nameof(Text))
                {
                    return string.IsNullOrEmpty(_text) ? "Darf nicht leer sein" : string.Empty;
                }

                return null;
            }
        }

        #endregion

        private string _text;
        
        public string Text
        {
            get => _text;
            set => this.SetField(ref _text, value);
        }

        private string _other;

        public string Other
        {
            get => _other;
            set => this.SetField(ref _other, value);
        }
    }
}
