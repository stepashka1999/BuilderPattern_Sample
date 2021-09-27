namespace BuilderPattern
{
    internal partial class Program
    {
        public class HtmlBuilder
        {
            private readonly string _rootName;
            protected HtmlElement root = new HtmlElement();

            public HtmlBuilder(string rootName)
            {
                _rootName = rootName;
                root.Name = rootName;
            }

            public HtmlBuilder AddChild(string name, string text)
            {
                var el = new HtmlElement(name, text);
                root.Elements.Add(el);

                return this;
            }

            public override string ToString() => root.ToString();

            public void Clear() => root.Elements.Clear();

            public HtmlElement Build() => root;
            
            public static implicit operator HtmlElement(HtmlBuilder builder)
            {
                return builder.root;
            }
        }
    }
}
