using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    class DrugType
    {
        public string TypeName { get; set; }
        public int Id { get; }
        private static int _id = 0;
        public DrugType()
        {
            _id++;
            Id = _id;
        }
        public DrugType(string typename) : this()
        {
            TypeName = typename;
        }
        public override string ToString()
        {
            return TypeName;
        }
    }
}
