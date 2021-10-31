using System;
using System.Collections.Generic;
using Pharmacy.Utils;

namespace Pharmacy.Models
{
    public class Pharmacy
    {
        public string Name { get; }
        public readonly int ID = new Random().Next();
        public readonly List<Drug> Drugs;


        public Pharmacy(string name)
        {
            this.Name = name;
            Drugs = new List<Drug>();
        }
        
        public bool AddDrug(Drug drug)
        {
            Drug newDrug = Drugs.Find(x => x.Name.ToLower().Contains(drug.Name.Trim().ToLower()));
            if (newDrug != null)
            {
                newDrug.Count += drug.Count;
                return false;
            }
            Drugs.Add(drug);
            return true;
        }

        public bool ShowDrugItems()
        {
            if (Drugs.Count == 0)
            {
                return false;
            }

            foreach (Drug drug in Drugs)
            {
                Extensions.Print(drug.ToString(), ConsoleColor.Green);
            }
            return true;
        }

        public Drug CheckDrug(string drugName)
        {
            return Drugs.Find(x => x.Name.ToLower().Contains(drugName.Trim().ToLower()));
            
        }

        public bool SaleDrug(string drugName, double payed, int countOfDrugs)
        {
            Drug drugs = Drugs.Find(x => x.Name.ToLower().Contains(drugName.Trim().ToLower()));
            if (drugs != null) 
            {
                if (drugs.Count >= countOfDrugs)
                {
                    if (drugs.Price * countOfDrugs <= payed)
                    {
                        drugs.Count -= countOfDrugs;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool InfoDrug(string name)
        {
            var drugs = Drugs.FindAll(x => x.Name.ToLower().Contains(name.Trim().ToLower()));
            if (Drugs.Count == 0)
            {
                return false;
            }
            foreach (var drug in drugs)
            {
                Extensions.Print($"{drug}", ConsoleColor.Red);
            }
            return true;
        }

        public void ShowCategory()
        {
            List<string> result = new List<string>();
            
            foreach (var drug in Drugs)
            {
                if (result.Contains(drug.Type.TypeName)) continue;
                result.Add(drug.Type.TypeName);
            }
            
            foreach (var type in result)
            {
                Extensions.Print($"{type}", ConsoleColor.Cyan);
            }
        }

        public bool ShowByCategory(string drugType)
        {
            var drugs = Drugs.FindAll(x => x.Type.ToString().ToLower().Contains(drugType.Trim().ToLower()));
            if (drugs != null)
            {
                foreach (Drug drug in drugs)
                {
                    Extensions.Print($"{drug}", ConsoleColor.Cyan);
                }
                
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Drugs Name: {this.Name} - Drugs ID {this.ID}";
        }
    }
}