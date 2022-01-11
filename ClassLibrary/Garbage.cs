using System;

namespace ClassLibrary
{
    public class Garbage
    {
        //public int Year { get; set; }
        public int Month { get; set; }
        public string DistrictType { get; set; }
        public int AmountIndustrial { get; set; }
        public int AmountConstruction { get; set; }
        public int AmountMunicipal { get; set; }

        public Garbage() { }

        public Garbage(int month, string type, int indus, int constr, int munic)
        {
            Month = month;
            DistrictType = type;
            AmountIndustrial = indus;
            AmountConstruction = constr;
            AmountMunicipal = munic;
        }


    }
}