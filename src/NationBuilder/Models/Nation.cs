using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NationBuilder.Models
{
    public class Nation
    {
        [Key]
        public int NationId { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public string Government { get; set; }
        public string Economy { get; set; }
        public string Geography { get; set; }
        public string Religion { get; set; }
        [NotMapped]
        public Dictionary<string, int> Resources { get; set; }
        [NotMapped]
        public Dictionary<string, int> ResourceGrowth { get; set; }
        [NotMapped]
        public int LaborPoints { get; set; }
        [NotMapped]
        public Dictionary<string, int> LaborPool { get; set; }
        public virtual Resource ResourcesObj { get; set; }
        public virtual ApplicationUser User { get; set; }

        public Nation(string NationName, string NationCapital, string NationGovernment, string NationEconomy, string NationGeography, string NationReligion)
        {
            
            Name = NationName;
            Capital = NationCapital;
            Government = NationGovernment.ToLower();
            Economy = NationEconomy.ToLower();
            Geography = NationGeography.ToLower();
            Religion = NationReligion.ToLower();
        }

        // Don't run build until you have an associated resource!
        public void Build()
        {
            Resources = new Dictionary<string, int>
            {
                ["Population"] = 1000,
                ["Happiness"] = 100,
                ["Coal"] = 100,
                ["Currency"] = 100,
                ["Food"] = 100,
                ["Lumber"] = 100,
                ["Medical"] = 100,
                ["Oil"] = 100,
                ["Rare Earth"] = 100,
                ["Steel"] = 100
            };
            ResourceGrowth = new Dictionary<string, int>
            {
                ["Population"] = 100,
                ["Happiness"] = 0,
                ["Coal"] = 20,
                ["Currency"] = 20,
                ["Food"] = 20,
                ["Lumber"] = 20,
                ["Medical"] = 20,
                ["Oil"] = 20,
                ["Rare Earth"] = 20,
                ["Steel"] = 20
            };
            LaborPoints = 1;
            LaborPool = new Dictionary<string, int>
            {
                ["Population"] = 0,
                ["Happiness"] = 0,
                ["Coal"] = 0,
                ["Currency"] = 0,
                ["Food"] = 0,
                ["Lumber"] = 0,
                ["Medical"] = 0,
                ["Oil"] = 0,
                ["Rare Earth"] = 0,
                ["Steel"] = 0
            };

            // Government Switch
            switch (Government)
            {
                case "democracy":
                    ResourceGrowth["Happiness"] += 5;
                    break;
                case "monarchy":
                    Resources["Currency"] += 1000;
                    break;
                case "communism":
                    Economy = "planned(socialism)";
                    LaborPoints += 2;
                    break;
            }

            // Religion Switch
            switch (Religion)
            {
                case "monotheism":
                    ResourceGrowth["Happiness"] += 5;
                    break;
                case "polytheism":
                    ResourceGrowth["Population"] += 50;
                    break;
                case "atheism":
                    ResourceGrowth["Medical"] += 10;
                    break;
            }

            // Geography Switch
            switch (Geography)
            {
                case "plains":
                    ResourceGrowth["Food"] += 15;
                    ResourceGrowth["Oil"] += 5;
                    break;
                case "desert":
                    ResourceGrowth["Oil"] += 15;
                    ResourceGrowth["Rare Earth"] += 5;
                    break;
                case "mountains":
                    ResourceGrowth["Coal"] += 15;
                    ResourceGrowth["Steel"] += 5;
                    break;
                case "forest":
                    ResourceGrowth["Lumber"] += 15;
                    ResourceGrowth["Food"] += 5;
                    break;
                case "coastal":
                    ResourceGrowth["Currency"] += 15;
                    ResourceGrowth["Food"] += 5;
                    break;
            }

            // Economy Switch
            switch (Economy)
            {
                case "capitalism":
                    ResourceGrowth["Currency"] += 15;
                    break;
                case "planned(socialism)":
                    ResourceGrowth["Medical"] += 15;
                    break;
                case "barter":
                    foreach (var key in ResourceGrowth.Keys.ToList())
                    {
                        if (key == "Population")
                        {
                            ResourceGrowth[key] += 20;
                        }
                        else
                        {
                            ResourceGrowth[key] += 2;
                        }
                    }
                    break;
            }

            SaveResources();
        }

        public void EndTurn()
        {
            foreach (var key in ResourceGrowth.Keys.ToList())
            {
                Resources[key] += (ResourceGrowth[key] + (LaborPool[key] * 20));
            }

            Resources["Population"] += (Resources["Food"] / 10);

            foreach (var key in ResourceGrowth.Keys.ToList())
            {
                if (Resources[key] <= 0)
                {
                    var happyReduce = Resources[key] / -100;
                    Resources["Happiness"] -= ((happyReduce * 2) + 2);
                    if(key == "Food")
                    {
                        Resources["Population"] -= ((Resources[key] / -10) + 100);
                    }
                }
            }

            LaborPoints = Resources["Population"] / 1000;
        }

        public void RetrieveResources()
        {
            LaborPoints = ResourcesObj.LaborPoints;

            Resources = new Dictionary<string, int>
            {
                ["Population"] = ResourcesObj.Population,
                ["Happiness"] = ResourcesObj.Happiness,
                ["Coal"] = ResourcesObj.Coal,
                ["Currency"] = ResourcesObj.Currency,
                ["Food"] = ResourcesObj.Food,
                ["Lumber"] = ResourcesObj.Lumber,
                ["Medical"] = ResourcesObj.Medical,
                ["Oil"] = ResourcesObj.Oil,
                ["Rare Earth"] = ResourcesObj.RareEarth,
                ["Steel"] = ResourcesObj.Steel
            };

            ResourceGrowth = new Dictionary<string, int>
            {
                ["Population"] = ResourcesObj.PopulationGrowth,
                ["Happiness"] = ResourcesObj.HappinessGrowth,
                ["Coal"] = ResourcesObj.CoalGrowth,
                ["Currency"] = ResourcesObj.CurrencyGrowth,
                ["Food"] = ResourcesObj.FoodGrowth,
                ["Lumber"] = ResourcesObj.LumberGrowth,
                ["Medical"] = ResourcesObj.MedicalGrowth,
                ["Oil"] = ResourcesObj.OilGrowth,
                ["Rare Earth"] = ResourcesObj.RareEarthGrowth,
                ["Steel"] = ResourcesObj.SteelGrowth
            };

            LaborPool = new Dictionary<string, int>
            {
                ["Coal"] = ResourcesObj.CoalLabor,
                ["Currency"] = ResourcesObj.CurrencyLabor,
                ["Food"] = ResourcesObj.FoodLabor,
                ["Lumber"] = ResourcesObj.LumberLabor,
                ["Medical"] = ResourcesObj.MedicalLabor,
                ["Oil"] = ResourcesObj.OilLabor,
                ["Rare Earth"] = ResourcesObj.RareEarthLabor,
                ["Steel"] = ResourcesObj.SteelLabor
            };
        }

        public void SaveResources()
        {
            ResourcesObj.LaborPoints = LaborPoints;

            ResourcesObj.Population = Resources["Population"];
            ResourcesObj.Happiness = Resources["Happiness"];
            ResourcesObj.Coal = Resources["Coal"];
            ResourcesObj.Currency = Resources["Currency"];
            ResourcesObj.Food = Resources["Food"];
            ResourcesObj.Lumber = Resources["Lumber"];
            ResourcesObj.Medical = Resources["Medical"];
            ResourcesObj.Oil = Resources["Oil"];
            ResourcesObj.RareEarth = Resources["Rare Earth"];
            ResourcesObj.Steel = Resources["Steel"];

            ResourcesObj.PopulationGrowth = ResourceGrowth["Population"];
            ResourcesObj.HappinessGrowth = ResourceGrowth["Happiness"];
            ResourcesObj.CoalGrowth = ResourceGrowth["Coal"];
            ResourcesObj.CurrencyGrowth = ResourceGrowth["Currency"];
            ResourcesObj.FoodGrowth = ResourceGrowth["Food"];
            ResourcesObj.LumberGrowth = ResourceGrowth["Lumber"];
            ResourcesObj.MedicalGrowth = ResourceGrowth["Medical"];
            ResourcesObj.OilGrowth = ResourceGrowth["Oil"];
            ResourcesObj.RareEarthGrowth = ResourceGrowth["Rare Earth"];
            ResourcesObj.SteelGrowth = ResourceGrowth["Steel"];

            ResourcesObj.CoalLabor = LaborPool["Coal"];
            ResourcesObj.CurrencyLabor = LaborPool["Currency"];
            ResourcesObj.FoodLabor = LaborPool["Food"];
            ResourcesObj.LumberLabor = LaborPool["Lumber"];
            ResourcesObj.MedicalLabor = LaborPool["Medical"];
            ResourcesObj.OilLabor = LaborPool["Oil"];
            ResourcesObj.RareEarthLabor = LaborPool["Rare Earth"];
            ResourcesObj.SteelLabor = LaborPool["Steel"];
        }
    }
}
