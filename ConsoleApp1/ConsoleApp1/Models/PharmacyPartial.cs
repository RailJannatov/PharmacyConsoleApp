using ConsoleApp1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    partial class Pharmacy
    {
        public override string ToString()
        {
            return $"{ Id}   -  {Name}";
        }
        public bool AddDrug(Drug drug)
        {
            bool isFalse = false;
            foreach (var item in _drugs)
            {
                if (item.Name==drug.Name)
                {
                    item.Count += drug.Count;
                    return true;
                }
                
            }
            if (isFalse==false)
            {
                _drugs.Add(drug);
            }
            
            return false;
        }
        public List<Drug> InfoDrug(string name)
        {
            var infodrug = _drugs.FindAll(x => x.Name.ToLower().Contains(name.ToLower()));
            if (infodrug==null)
            {
                Helper.Print(ConsoleColor.Red, "Bele derman yoxdur");
            }
          
            return infodrug;
            
        }
        public List<Drug> ShowDrugItems()
        {
            return _drugs;
            
        }
        public void SaleDrug(int id, int count, double payment)
        {
            var existDrug = _drugs.Find(x => x.Id==id);
            if (existDrug == null)
            {
                Helper.Print(ConsoleColor.Red, "Daxil etdiyiniz adda derman yoxdur");
                return;
            }
            if (existDrug.Count < count)
            {
                Helper.Print(ConsoleColor.Red, "Istediyiniz sayda derman yoxdu");
                return;
            }
             if (existDrug.Price*count > payment)
            {
                Helper.Print(ConsoleColor.Red, "Mebleg chatishmir");
                return;
            }
            existDrug.Count -= count;
            Helper.Print(ConsoleColor.Green, "Satish bash tutdu");
        }


    }
}
