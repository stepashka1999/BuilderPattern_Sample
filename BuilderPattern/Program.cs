using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    internal class Program
    {
        public class HtmlElement
        {
            private const int _indentSize = 2;

            public string Name, Text;
            //We can do Lazy list but im too lazy to this 
            public List<HtmlElement> Elements = new List<HtmlElement>();

            public HtmlElement() { }

            public HtmlElement(string name, string text)
            {
                Name = name;
                Text = text;
            }

            public override string ToString()
            {
                return ToStringImpl(0);
            }

            private string ToStringImpl(int indent)
            {
                var sb = new StringBuilder();
                var i = new string(' ', _indentSize * indent);
                sb.AppendLine($"{i}<{Name}>");

                if (!string.IsNullOrEmpty(Text))
                {
                    sb.Append(new string(' ', _indentSize * (indent + 1)));
                    sb.Append(Text);
                    sb.AppendLine();
                }

                foreach(var el in Elements)
                    sb.Append(el.ToStringImpl(indent + 1));

                sb.AppendLine($"{i}</{Name}>");

                return sb.ToString();
            }
        }

        public class HtmlBuilder
        {
            private readonly string _rootName;
            protected HtmlElement root = new HtmlElement();

            public HtmlBuilder(string rootName)
            {
                _rootName = rootName;
                root.Name = rootName;
            }

            public void AddChild(string name, string text)
            {
                var el = new HtmlElement(name, text);
                root.Elements.Add(el);
            }

            public override string ToString() => root.ToString();

            public void Clear() => root.Elements.Clear();

            public HtmlElement Build => root;
            
        }

        static void Main(string[] args)
        {
            //StringBuilder
            //The End
            //XD, just kidding

            var words = new[] { "Hello", ", ", "world", "!" };
            var htmlBuilder = new HtmlBuilder("ul");
            foreach(var word in words)
            {
                htmlBuilder.AddChild("li", word);
            }

            Console.WriteLine(htmlBuilder.ToString());
        }
    }
}
