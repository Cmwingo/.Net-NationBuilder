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
        public string Capital { get; set; }
        public string Government { get; set; }
        public string Economy { get; set; }
        public string Geography { get; set; }
        public string Religion { get; set; }
        public Dictionary<string, int> Resources { get; set; }
        public Dictionary<string, int> ResourceGrowth { get; set; }
        public int LaborPoints { get; set; }
        public Dictionary<string, int> LaborPool { get; set; }

        public Nation(string NationName, string NationCapital, string NationGovernment, string NationEconomy, string NationGeography, string NationReligion)
        {
            
            Name = NationName;
            Capital = NationCapital;
            Government = NationGovernment.ToLower();
            Economy = NationEconomy.ToLower();
            Geography = NationGeography.ToLower();
            Religion = NationReligion.ToLower();
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
            ResourceGrowth = new Dictionary<string, int> {
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
                        if(key == "Population")
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
        }

        public void EndTurn()
        {
            LaborPoints = Resources["Population"] / 1000;

            foreach (var key in ResourceGrowth.Keys.ToList())
            {
                Resources[key] += (ResourceGrowth[key] + (LaborPool[key] * 20));
                if(Resources[key] < 0)
                {
                    Resources["Happiness"] -= 5;
                }
            }
            
        }

    }
}
