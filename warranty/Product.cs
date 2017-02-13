using System;

namespace warranty
{
    public struct Product : IEquatable<Product>
    {
        public readonly string Name;
        public readonly string SerialNumber;
        public readonly string Make;
        public readonly string Model;

        public Product(string name, string serialNumber, string make, string model)
        {
            Name = name;
            SerialNumber = serialNumber;
            Make = make;
            Model = model;
        }

        public bool Equals(Product other)
        {
            return string.Equals(Name, other.Name) && string.Equals(SerialNumber, other.SerialNumber) && string.Equals(Make, other.Make) && string.Equals(Model, other.Model);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Product && Equals((Product) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (SerialNumber != null ? SerialNumber.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Make != null ? Make.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Model != null ? Model.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}