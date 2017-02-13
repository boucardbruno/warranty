using System;

namespace warranty
{
    public struct LineItem : IEquatable<LineItem>
    {
        public double Amount;
        public string Description;

        public LineItem(double amount, string description)
        {
            Amount = amount;
            Description = description;
        }

        public bool Equals(LineItem other)
        {
            return Amount.Equals(other.Amount) && string.Equals(Description, other.Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is LineItem && Equals((LineItem) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Amount.GetHashCode() * 397) ^ (Description != null ? Description.GetHashCode() : 0);
            }
        }
    }
}