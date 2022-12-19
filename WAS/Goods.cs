using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAS
{
    internal class Goods
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }

        public Goods(int id, string name, string description, string category, int quantity)
        {
            Id = id;
            Name = name;
            Description = description;
            Category = category;
            Quantity = quantity;
        }
    }

}
