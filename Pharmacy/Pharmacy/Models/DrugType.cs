using System;

namespace Pharmacy.Models
{
    public class DrugType
    {
        public int ID = new Random().Next();
        public string TypeName { get; }
        
        public DrugType(string typeName)
        {
            this.TypeName = typeName;
        }
        
        public override string ToString()
        {
            return this.TypeName;
        }
    }
}