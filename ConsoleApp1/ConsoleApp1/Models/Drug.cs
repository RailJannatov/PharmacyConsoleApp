using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    class Drug
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public DrugType Type { get; set; }
        public int Id { get; }
        private static int _id = 0;
        public Drug()
        {
            _id++;
            Id = _id;
        }
        public Drug(string name,int count,double price,DrugType type):this()
        {
            Name = name;
            Count = count;
            Price = price;
            Type = type;         
        }
        public override string ToString()
        {
            return $"{Id}  - Dermanin adi: {Name}  Dermanin sayi: {Count}  Dermanin qiymeti: {Price}";
        }

    }
}
