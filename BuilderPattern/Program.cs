using System;

namespace BuilderPattern
{
    internal partial class Program
    {
        public class Person
        {
            public string StreetAddress, PostCode, City;
            public string CompanyName, Position;
            public int AnnualIncome;

            public override string ToString()
            {
                return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(PostCode)}: {PostCode}, {nameof(City)}: {City}" +
                       $"\n{nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}" +
                       $"\n{nameof(AnnualIncome)}: {AnnualIncome}";
            }
        }

        public class PersonBuilder
        {
            protected Person person;

            public PersonBuilder()
            {
                person = new Person();
            }

            public PersonBuilder(Person person)
            {
                this.person = person;
            }

            public PersonAddressBuilder Lives => new(person);

            public PersonJobBuilder Works => new(person);

            public static implicit operator Person(PersonBuilder builder) => builder.person;

        }

        public class PersonAddressBuilder : PersonBuilder
        {
            public PersonAddressBuilder(Person person) : base(person) { }

            public PersonAddressBuilder At(string streetAddress)
            {
                person.StreetAddress = streetAddress;
                return this;
            }

            public PersonAddressBuilder WithPostCode(string postcode)
            {
                person.PostCode = postcode;
                return this;
            }

            public PersonAddressBuilder In(string city)
            {
                person.City = city;
                return this;
            }
        }

        public class PersonJobBuilder : PersonBuilder
        {
            public PersonJobBuilder(Person person) : base(person) { }

            public PersonJobBuilder At(string companyName)
            {
                person.CompanyName = companyName;
                return this;
            }

            public PersonJobBuilder AsA(string position)
            {
                person.Position = position;
                return this;
            }

            public PersonJobBuilder Earning(int annualIncome)
            {
                person.AnnualIncome = annualIncome;
                return this;
            }
        }

        static void Main(string[] args)
        {
            //StringBuilder
            //The End
            //XD, just kidding

            //Sample with default builder
            //SampleDemonstrator.DefaultSampleDemonstration();

            //Sample builder with fluent api
            //SampleDemonstrator.FluentInterfaceDemonstration();

            //Sample more advanced builder - PersonBuilder
            SampleDemonstrator.PersonBuilderDempnstration();
        }

        static class SampleDemonstrator
        {
            public static void DefaultSampleDemonstration()
            {
                var words = new[] { "Hello", ", ", "world", "!" };
                var htmlBuilder = new HtmlBuilder("ul");
                foreach (var word in words)
                {
                    htmlBuilder.AddChild("li", word);
                }

                Console.WriteLine(htmlBuilder.ToString());
            }

            public static void FluentInterfaceDemonstration()
            {
                var htmlBuilder = new HtmlBuilder("div");
                var resultHtml = htmlBuilder.AddChild("h1", "Hello World!")
                           .AddChild("p", "*Some lorem text*")
                           .Build()
                           .ToString();
                Console.WriteLine(resultHtml);
            }

            public static void PersonBuilderDempnstration()
            {
                var personBuilder = new PersonBuilder();
                Person person = personBuilder
                                    .Lives
                                        .At("123 Obtobers Street")
                                        .In("Novosibirsk")
                                        .WithPostCode("630008")
                                    .Works
                                        .At("Google")
                                        .AsA("Juniour Engineer")
                                        .Earning(40);

                Console.WriteLine(person);
            }
        }

    }
}
