using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace BuildersKata
{
    public class ProductBuildingTest
    {
        [Test]
        public void CheckEquality()
        {
            var product = new Product(1L, "pencil", "sharp one",
                new Supplier("Pentel",
                    new Address("Osielsko", "pomorskie")),
                new List<Price>
                {
                    new Price(500, "PLN"),
                    new Price(100, "EUR")
                });

            Assert.That(product, Is.EqualTo(Pencil()));
        }

        //[Test]
        //public void CheckEqualityWithFluentSetters()
        //{
        //    var product = new Product().WithId(1L)
        //        .WithName("pencil")
        //        .WithDescription("sharp one")
        //        .WithSupplier(new Supplier().WithName("Pentel")
        //            .WithAddress(new Address().WithCity("Osielsko").WithState("pomorskie")))
        //        .WithPrice("500PLN", "100EUR");

        //    var product = CreateProductWithPrice()
        //    Assert.That(product, Is.EqualTo(Pencil()));
        //}

        [Test]
        public void CheckEqualityWithInitializer()
        {
            var product = new Product
            {
                Id = 1L,
                Name = "pencil",
                Description = "sharp one",
                Supplier = new Supplier
                {
                    Name = "Pentel",
                    Address = new Address
                    {
                        City = "Osielsko",
                        State = "pomorskie"
                    }
                },
                Price = new List<Price>
                {
                    new Price{Value = 500, CurrencyCode = "PLN"},
                    new Price{Value =100,CurrencyCode= "EUR"}
}
            };

            Assert.That(product, Is.EqualTo(Pencil()));
        }

        [Test]
        public void CheckEqualityWithBuilder()
        {
            var product = new ProductBuilder().WithId(1L)
                .WithName("pencil")
                .WithDescription("sharp one")
                .WithSupplier(
                    new SupplierBuilder().WithName("Pentel")
                        .WithAddress(new AddressBuilder().WithCity("Osielsko").WithState("pomorskie").Build())
                        .Build())
                .WithPrices(new PriceBuilder().WithValue(500).WithCurrencyCode("PLN").Build(),
                    new PriceBuilder().WithValue(100).WithCurrencyCode("EUR").Build())
                .Build();

            Assert.That(product, Is.EqualTo(Pencil()));

        }

        [Test]
        public void CheckEqualityWithNestedBuilders()
        {
            var product = new ProductBuilder().WithId(1L)
                .WithName("pencil")
                .WithDescription("sharp one")
                .WithSupplier(
                    new SupplierBuilder().WithName("Pentel")
                        .WithAddress(new AddressBuilder().WithCity("Osielsko").WithState("pomorskie"))
                        )
                .WithPrices(new PriceBuilder().WithValue(500).WithCurrencyCode("PLN"),
                    new PriceBuilder().WithValue(100).WithCurrencyCode("EUR"))
                .Build();

            Assert.That(product, Is.EqualTo(Pencil()));

        }

        private static Product Pencil()
        {
            return new Product(1L, "pencil", "sharp one",
                new Supplier("Pentel",
                    new Address("Osielsko", "pomorskie")),
                new List<Price>
                {
                    new Price(500, "PLN"),
                    new Price(100, "EUR")
                });
        }
    }

    public class AddressBuilder
    {
        private string city;
        private string state;

        public AddressBuilder WithCity(string city)
        {
            this.city = city;
            return this;
        }

        public AddressBuilder WithState(string state)
        {
            this.state = state;
            return this;
        }

        public Address Build()
        {
            return new Address(city, state);
        }
    }

    public class SupplierBuilder
    {
        private string name;
        private Address address;

        public SupplierBuilder WithName(string name)
        {
            this.name = name;
            return this;
        }

        public SupplierBuilder WithAddress(Address address)
        {
            this.address = address;
            return this;
        }

        public Supplier Build()
        {
            return new Supplier(name, address);
        }

        public SupplierBuilder WithAddress(AddressBuilder addressBuilder)
        {
            return WithAddress(addressBuilder.Build());
        }
    }

    public class ProductBuilder
    {
        private long id;
        private string name;
        private string description;
        private Supplier supplier;
        private Price[] prices;

        public ProductBuilder WithId(long id)
        {
            this.id = id;
            return this;
        }

        public ProductBuilder WithName(string name)
        {
            this.name = name;
            return this;
        }

        public ProductBuilder WithDescription(string description)
        {
            this.description = description;
            return this;
        }

        public ProductBuilder WithSupplier(Supplier supplier)
        {
            this.supplier = supplier;
            return this;
        }

        public ProductBuilder WithPrices(params Price[] prices)
        {
            this.prices = prices;
            return this;
        }

        public ProductBuilder WithPrices(params PriceBuilder[] prices)
        {
            this.prices = prices.Select(x=>x.Build()).ToArray();
            return this;
        }

        public Product Build()
        {
            return new Product(id, name, description, supplier, new List<Price>(prices));
        }

        public ProductBuilder WithSupplier(SupplierBuilder supplierBuilder)
        {
            return WithSupplier(supplierBuilder.Build());
        }
    }

    public class PriceBuilder
    {
        private int value;
        private string currencyCode;

        public PriceBuilder WithValue(int value)
        {
            this.value = value;
            return this;
        }

        public PriceBuilder WithCurrencyCode(string currencyCode)
        {
            this.currencyCode = currencyCode;
            return this;
        }

        public Price Build()
        {
            return new Price(value, currencyCode);
        }
    }

    public class Address
    {
        public string City { get; set; }
        public string State { get; set; }

        public Address(string city, string state)
        {
            City = city;
            State = state;
        }

        public Address()
        {
        }

        protected bool Equals(Address other)
        {
            return string.Equals(City, other.City) && string.Equals(State, other.State);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Address) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (City.GetHashCode()*397) ^ State.GetHashCode();
            }
        }

        public Address WithCity(string city)
        {
            City = city;
            return this;
        }

        public Address WithState(string state)
        {
            State = state;
            return this;
        }
    }

    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Supplier Supplier { get; set; }
        public IList<Price> Price { get; set; }

        public Product(long id, string name, string description, Supplier supplier, IList<Price> price)
        {
            Id = id;
            Name = name;
            Description = description;
            Supplier = supplier;
            Price = price;
        }

        public Product()
        {
        }

        protected bool Equals(Product other)
        {
            return Id == other.Id && string.Equals(Name, other.Name) && string.Equals(Description, other.Description) &&
                   Supplier.Equals(other.Supplier) && Price.SequenceEqual(other.Price);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Product) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode*397) ^ Name.GetHashCode();
                hashCode = (hashCode*397) ^ Description.GetHashCode();
                hashCode = (hashCode*397) ^ Supplier.GetHashCode();
                hashCode = (hashCode*397) ^ Price.GetHashCode();
                return hashCode;
            }
        }

        public Product WithId(long id)
        {
            Id = id;
            return this;
        }

        public Product WithName(string name)
        {
            Name = name;
            return this;
        }

        public Product WithDescription(string description)
        {
            Description = description;
            return this;
        }

        public Product WithSupplier(Supplier supplier)
        {
            Supplier = supplier;
            return this;
        }

        public Product WithPrice(List<Price> prices)
        {
            Price = prices;
            return this;
        }
    }

    public class Price
    {
        public int Value { get; set; }
        public string CurrencyCode { get; set; }

        public Price(int value, string currencyCode)
        {
            Value = value;
            CurrencyCode = currencyCode;
        }

        public Price()
        {
        }

        protected bool Equals(Price other)
        {
            return string.Equals(CurrencyCode, other.CurrencyCode) && Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Price) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (CurrencyCode.GetHashCode()*397) ^ Value;
            }
        }

        public Price WithValue(int value)
        {
            Value = value;
            return this;
        }

        public Price WithCurrencyCode(string currencyCode)
        {
            CurrencyCode = currencyCode;
            return this;
        }
    }

    public class Supplier
    {
        public string Name { get; set; }
        public Address Address { get; set; }

        public Supplier(string name, Address address)
        {
            Name = name;
            Address = address;
        }

        public Supplier()
        {
        }

        protected bool Equals(Supplier other)
        {
            return string.Equals(Name, other.Name) && Address.Equals(other.Address);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Supplier) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Name.GetHashCode()*397) ^ Address.GetHashCode();
            }
        }

        public Supplier WithName(string name)
        {
            Name = name;
            return this;
        }

        public Supplier WithAddress(Address address)
        {
            Address = address;
            return this;
        }
    }
}