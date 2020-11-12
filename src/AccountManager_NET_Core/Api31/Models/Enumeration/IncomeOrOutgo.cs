using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api31.Models.Enumeration
{
    public class IncomeOrOutgo 
    {
        public IncomeOrOutgo Income = new IncomeOrOutgo(0, "income");
        public IncomeOrOutgo Outgo = new IncomeOrOutgo(1, "outgo");

        public int Id { get; private set; }
        public string Name { get; private set; }
        public IncomeOrOutgo(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
