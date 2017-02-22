using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NationBuilder.Models
{
    public class Nation
    {
        [Key]
        public int NationId { get; set; }
        public string Name { get; set; }
        public string Government { get; set; }
        public int[] ResourceGrowth { get; set; }
        // [Population, Happiness, Coal, Currency, Food(index: 4), Lumber, Medical, Oil, RareEarth, Steel]
        public string Economy { get; set; }
        public string Geography { get; set; }
        public string Religion { get; set; }
        public string Capital { get; set; }
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
        public int[] LaborPool { get; set; }
        // [0, 0, Coal, Currency, Food(index: 4), Lumber, Medical, Oil, RareEarth, Steel]
        public int LaborPoints { get; set; }

        public Nation(string NationName, string NationCapital, string NationGovernment, string NationEconomy, string NationGeography, string NationReligion)
        {
            Population = 1000;
            Happiness = 100;
            Coal = 100;
            Currency = 100;
            Food = 100;
            Lumber = 100;
            Medical = 100;
            Oil = 100;
            RareEarth = 100;
            Steel = 100;
            Name = NationName;
            Capital = NationCapital;
            Government = NationGovernment.ToLower();
            Economy = NationEconomy.ToLower();
            Geography = NationGeography.ToLower();
            Religion = NationReligion.ToLower();
            ResourceGrowth = [100, 0, 20, 20, 20, 20, 20, 20, 20, 20];
            LaborPoints = 1;
            LaborPool = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0];

            // Government Switch
            switch (Government)
            {
                case "democracy":
                    break;
                case "monarchy":
                    break;
                case "communism":
                    Economy = "planned(socialism)";
                    break;
            }

            // Religion Switch
            switch (Religion)
            {
                case "monotheism":
                    break;
                case "polytheism":
                    break;
                case "atheism":
                    break;
            }

            // Geography Switch
            switch (Geography)
            {
                case "plains":
                    break;
                case "desert":
                    break;
                case "mountains":
                    break;
                case "forest":
                    break;
                case "coastal":
                    break;
            }

            // Economy Switch
            switch (Economy)
            {
                case "capitalism":
                    break;
                case "planned(socialism)":
                    break;
                case "barter":
                    break;
            }
        }


    }
}
