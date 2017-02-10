using System;
using System.Collections.Generic;

namespace warranty
{
    public class Claim
    {
        public int Id;
        public double Amount;
        public DateTime Date;
        public List<RepairPo> RepairPo = new List<RepairPo>();

        public Claim(int id, double amount, DateTime date)
        {
            Id = id;
            Amount = amount;
            Date = date;
        }
    }
}
