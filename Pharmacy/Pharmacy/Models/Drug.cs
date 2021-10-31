using System;

namespace Pharmacy.Models
{
    public class Drug
    {
        public string Name { get; }
        private readonly int ID = new Random().Next();
        public DrugType Type { get; set; }

        public readonly double Price = new Random().NextDouble();

        public int Count { get; set; }
        public Drug(string name, DrugType type, int count)
        {
            this.Name = name;
            this.Type = type;
            this.Count = count;
            Price = Math.Round(Price, 2);
        }

        public override string ToString()
        {
            return $"Drug name: {this.Name} - Drug type: {this.Type} - Drug ID: {this.ID} - Drug price: {this.Price} - Drug count: {this.Count}";
        }
    }
}