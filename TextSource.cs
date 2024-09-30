namespace BindingDemo
{
    internal class TextSource : ObservableObject
    {
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
        
        /// <inheritdoc />
        protected override string ValidateProperty(string propertyName)
        {
            if (propertyName == nameof(Text))
            {
                return string.IsNullOrEmpty(_text) ? "Darf nicht leer sein" : string.Empty;
            }
            
            return string.Empty;
        }
    }
}
