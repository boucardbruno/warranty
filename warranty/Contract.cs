using System;
using System.Collections.Generic;

namespace warranty
{
    public class Contract
    {
        public enum Lifecycle { Pending, Active, Expired }

        public int Id;
        public double PurchasePrice;
        public DateTime EffectiveDate = new DateTime();
        public DateTime ExpirationDate = new DateTime();
        public DateTime PurchaseDate = new DateTime();
        public int InStoreGuaranteeDays;
        public Lifecycle Status { get; set; }
        public Product Product;

        private readonly List<Claim> _claims = new List<Claim>();

        public Contract(int id, double d)
        {
            Id = id;
            PurchasePrice = d;
            Status = Lifecycle.Pending;
        }

        public void Add(Claim claim)
        {
            _claims.Add(claim);
        }

        public List<Claim> Claims
        {
            get { return _claims; }
        }

        public void Remove(Claim claim)
        {
            _claims.Remove(claim);
        }
    }
}