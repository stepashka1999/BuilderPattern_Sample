using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    internal partial class Program
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
    }
}
