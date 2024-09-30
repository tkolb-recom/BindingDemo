namespace BindingDemo
{
    internal class ParentSource : ObservableObject
    {
		private TextSource nested = new TextSource();

		public TextSource Nested
		{
			get { return nested; }
			set { nested = value; }
		}

		private string _other;

		public string Other
		{
			get => _other;
			set => this.SetField(ref _other, value);
		}
	}
}
