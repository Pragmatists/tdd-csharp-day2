using System.Collections.Generic;
using System.Linq;
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

        [Test]
        public void CheckEqualityWithFluentSetters()
        {
            // TODO
        }

        [Test]
        public void CheckEqualityWithBuilder()
        {
            // TODO
        }

        [Test]
        public void CheckEqualityWithNestedBuilders()
        {
            // TODO
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

    public class Address
    {
        public string City { get; set; }
        public string State { get; set; }

        public Address(string city, string state)
        {
            City = city;
            State = state;
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
    }
}