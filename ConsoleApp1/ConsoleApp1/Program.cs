using ConsoleApp1.Models;
using ConsoleApp1.Utils;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<Pharmacy> pharmacies = new List<Pharmacy>();
            bool isInitial = true;
            while (true)
            {
                if (isInitial)
                {
                    Helper.Print(ConsoleColor.DarkYellow, "Aptekin adını daxil edin");
                selectPharmacy:
                    string pharmancyname = Console.ReadLine();
                    if (pharmancyname.Contains(' '))
                    {
                        Helper.Print(ConsoleColor.Red, "Adı daxil edin");
                        goto selectPharmacy;

                    }
                    if (string.IsNullOrEmpty(pharmancyname))
                    {
                        Helper.Print(ConsoleColor.Red, "Adı daxil edin");
                        goto selectPharmacy;
                    }
                    var pharmacy1 = new Pharmacy(pharmancyname);
                    Helper.Print(ConsoleColor.Green, $"{pharmancyname} adlı aptek yarandı");
                    pharmacies.Add(pharmacy1);
                }
                Helper.Print(ConsoleColor.Blue, "1-Aptek yarat,2-Dərman əlave eləmək,3-Istədiyiniz dərmanin məlumatını öyrənmək," +
                    "4-Dərman almaq,5-Dərmanların siyahısı,6-Çıxış");
                string result = Console.ReadLine();
                bool isInt = int.TryParse(result, out int option);
                if (isInt && (option >= 1 && option <= 6))
                {
                    if (option == 6)
                    {
                        break;
                    }
                    switch (option)
                    {
                        case 1:
                            Helper.Print(ConsoleColor.DarkBlue, "Aptekin adini daxil edin");
                            string pharmancyname = Console.ReadLine();
                            var pharmacy1 = new Pharmacy(pharmancyname);
                            Helper.Print(ConsoleColor.Green, $"{pharmancyname} adlı aptek yarandı ");
                            pharmacies.Add(pharmacy1);
                            isInitial = false;
                            break;
                        case 2:
                            Helper.Print(ConsoleColor.Blue, "Dərmanın adını daxil edin");
                            string drugName = Console.ReadLine();
                        selectPrice:
                            Helper.Print(ConsoleColor.Blue, "Dərmanın qiymətini daxil edin");
                            string drugPrice = Console.ReadLine();
                        selectCount:
                            Helper.Print(ConsoleColor.Blue, "Dərmanın sayını daxil edin");
                            string drugCount = Console.ReadLine();
                        selectType:
                            Helper.Print(ConsoleColor.Blue, "Dərmanın tipini daxil edin");
                            string drugType = Console.ReadLine();
                            bool resultPrice = double.TryParse(drugPrice, out double drugConvertedPrice);
                            if (!resultPrice)
                            {
                                Helper.Print(ConsoleColor.Red, "Ədəd daxil edin");
                                goto selectPrice;
                            }
                            bool resultCount = int.TryParse(drugCount, out int drugConvertedCount);
                            if (!resultCount)
                            {
                                Helper.Print(ConsoleColor.Red, "Ədəd daxil edin");
                                goto selectCount;
                            }

                            bool resultType = int.TryParse(drugType, out int drugConvertedType);
                            if (resultType)
                            {
                                Helper.Print(ConsoleColor.Red, "Ədəd daxil etmek olmaz");
                                goto selectType;
                            }
                            DrugType drugType2 = new DrugType(drugConvertedType.ToString());

                            Helper.Print(ConsoleColor.Blue, "Əlavə etmək istədiyiniz aptekin adını daxil edin:");

                            foreach (Pharmacy item in pharmacies)
                            {
                                Helper.Print(ConsoleColor.Green, item.Name);
                            }
                            string selectedPharmacy = Console.ReadLine();


                            Pharmacy existPhaarmacy = pharmacies.Find(x => x.Name.ToLower() == selectedPharmacy.ToLower());
                            if (existPhaarmacy == null)
                            {
                                Helper.Print(ConsoleColor.Red, "Belə bir adda aptek yoxdur");

                            }

                            Drug drug1 = new Drug(drugName, drugConvertedCount, drugConvertedPrice, drugType2);

                            existPhaarmacy.AddDrug(drug1);
                            Helper.Print(ConsoleColor.Green, $"{selectedPharmacy} aptekinə əlave olundu");
                            isInitial = false;
                            break;
                        case 3:
                            Helper.Print(ConsoleColor.Blue, "Məlumat almaq istədiyiniz dərmanin adını qeyd edin");
                        selectedInfo:
                            string name = Console.ReadLine();
                            bool isStringName = int.TryParse(name, out int info);
                            if (isStringName)
                            {
                                Helper.Print(ConsoleColor.Red, "Ədəd daxil etmek olmaz");
                                goto selectedInfo;

                            }
                            foreach (var drug in pharmacies)
                            {
                                List<Drug> drugs = drug.InfoDrug(name);
                                foreach (var item in drugs)
                                {
                                    Console.WriteLine(item);
                                }
                            }
                            break;
                        case 4:
                            Helper.Print(ConsoleColor.Blue, "Almaq istədiyiniz dərmanı daxil edin");
                            string inputDrugName = Console.ReadLine();
                            foreach (var pharmacy in pharmacies)
                            {
                                var allPharmacyDrugs = pharmacy.ShowDrugItems();
                                var existingDrugs = allPharmacyDrugs.FindAll(x => x.Name.ToLower().Contains(inputDrugName.ToLower()));
                                if (existingDrugs.Count > 0)
                                {
                                    Helper.Print(ConsoleColor.Blue, pharmacy.Name);
                                    foreach (var item in existingDrugs)
                                    {
                                        Console.WriteLine(item);
                                    }
                                }

                            }
                            Helper.Print(ConsoleColor.DarkMagenta, "Almaq istədiyiniz apteki daxil edin");
                            string buyPharmacyName = Console.ReadLine();
                            var selectPharmacy = pharmacies.Find(x => x.Name.ToLower() == buyPharmacyName.ToLower());
                            if (selectPharmacy == null)
                            {
                                Helper.Print(ConsoleColor.Red, "Bu adda aptek yoxdur əməliyyat dayandırılmışdır");
                                break;
                            }

                            var allSelectedPharmacyDrugs = selectPharmacy.ShowDrugItems();
                            var selectedExistingDrugs = allSelectedPharmacyDrugs.FindAll(x => x.Name.ToLower().Contains(inputDrugName.ToLower()));
                            if (selectedExistingDrugs.Count > 0)
                            {
                                foreach (var item in selectedExistingDrugs)
                                {
                                    Console.WriteLine(item);
                                }
                            }

                            Helper.Print(ConsoleColor.Blue, "Almaq istədiyiniz dərmanın indexini daxil edin");
                            string buyDrugName = Console.ReadLine();
                            bool isIntIndex = int.TryParse(buyDrugName, out int drugID);
                            if (!isIntIndex)
                            {
                                Helper.Print(ConsoleColor.Red, "Indexlərdən birini seçin");
                            }
                            var selectedDrug = selectPharmacy._drugs.Find(x => x.Id == drugID);
                            Helper.Print(ConsoleColor.Blue, "Almaq istədiyiniz dərmanın sayını daxil edin");
                            string buyDrugCount = Console.ReadLine();
                            if (!int.TryParse(buyDrugCount, out int inpuDrugCount))
                            {
                                Helper.Print(ConsoleColor.Red, "Ədəd daxil edin");
                            }
                            Helper.Print(ConsoleColor.Blue, "Məbləğınizi daxil edin");
                            
                            string buyDrugPayment = Console.ReadLine();
                            if (!int.TryParse(buyDrugPayment, out int inpuDrugPayment))
                            {
                                Helper.Print(ConsoleColor.Red, "Mebleğ daxil edin");
                            }
                            selectPharmacy.SaleDrug(selectedDrug.Id, inpuDrugCount, inpuDrugPayment);
                            break;
                        case 5:
                            Helper.Print(ConsoleColor.Yellow, "Hansi aptekdəki dərmanlar görmək istəyirsiz");
                            foreach (var pharmacy in pharmacies)
                            {
                                Helper.Print(ConsoleColor.DarkYellow, $"{pharmacy}");

                            }
                            Helper.Print(ConsoleColor.Green, "Aptekin adını daxil edin");
                            string isListDrugs = Console.ReadLine();
                            var existDrugInPharmacy = pharmacies.Find(x => x.Name.ToLower() == isListDrugs.ToLower());
                            if (existDrugInPharmacy != null)
                            {
                                foreach (var item in existDrugInPharmacy._drugs)
                                {
                                    Helper.Print(ConsoleColor.Green, $"{item.ToString()}");
                                }
                            }
                            break;
                        default:
                            isInitial = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Göstərilən ədədlərdən daxil edin");
                }
            }
        }
    }
}
