using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NationBuilder.Models
{
    public class Resource
    {
        [Key]
        public int ResourcesId { get; set; }
        public int Population { get; set; }
        public int Happiness { get; set; }
        public int Coal { get; set; }
        public int Currency { get; set; }
        public int Food { get; set; }
        public int Lumber { get; set; }
        public int Medical { get; set; }
        public int Oil { get; set; }
        public int RareEarth { get; set; }
        public int Steel { get; set; }
        public int LaborPoints { get; set; }
        public int PopulationGrowth { get; set; }
        public int HappinessGrowth { get; set; }
        public int CoalGrowth { get; set; }
        public int CurrencyGrowth { get; set; }
        public int FoodGrowth { get; set; }
        public int LumberGrowth { get; set; }
        public int MedicalGrowth { get; set; }
        public int OilGrowth { get; set; }
        public int RareEarthGrowth { get; set; }
        public int SteelGrowth { get; set; }
        public int CoalLabor { get; set; }
        public int CurrencyLabor { get; set; }
        public int FoodLabor { get; set; }
        public int LumberLabor { get; set; }
        public int MedicalLabor { get; set; }
        public int OilLabor { get; set; }
        public int RareEarthLabor { get; set; }
        public int SteelLabor { get; set; }
        public int NationId { get; set; }
        public virtual Nation Nation { get; set; }

        public Resource()
        {
            //LaborPoints = 1;

            //// Current Amounts
            //Population = 1000;
            //Happiness = 100;
            //Coal = 100;
            //Currency = 100;
            //Food = 100;
            //Lumber = 100;
            //Medical = 100;
            //Oil = 100;
            //RareEarth = 100;
            //Steel = 100;

            //// Growth Amounts
            //PopulationGrowth = 100;
            //HappinessGrowth = 0;
            //CoalGrowth = 20;
            //CurrencyGrowth = 20;
            //FoodGrowth = 20;
            //LumberGrowth = 20;
            //MedicalGrowth = 20;
            //OilGrowth = 20;
            //RareEarthGrowth = 20;
            //SteelGrowth = 20;

            //// Labor Amounts
            //CoalLabor = 0;
            //CurrencyLabor = 0;
            //FoodLabor = 0;
            //LumberLabor = 0;
            //MedicalLabor = 0;
            //OilLabor = 0;
            //RareEarthLabor = 0;
            //SteelLabor = 0;
        }
    }
}
