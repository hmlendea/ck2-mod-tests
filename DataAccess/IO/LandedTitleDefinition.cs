using System.Collections.Generic;
using System.Linq;

using Pdoxcl2Sharp;

using CK2ModTests.DataAccess.DataObjects;
using CK2ModTests.Extensions;

namespace CK2ModTests.DataAccess.IO
{
    public sealed class LandedTitleDefinition : IParadoxRead, IParadoxWrite
    {
        public LandedTitleEntity Entity { get; set; }

        public LandedTitleDefinition()
        {
            Entity = new LandedTitleEntity();
        }
        
        public void TokenCallback(ParadoxParser parser, string token)
        {
            if (token[1] == '_') // Like e_something or c_something
            {
                LandedTitleDefinition landedTitle = new LandedTitleDefinition();
                landedTitle.Entity.ParentId = Entity.Id;
                landedTitle.Entity.Id = token;

                Entity.Children.Add(parser.Parse(landedTitle).Entity);
                return;
            }

            switch (token)
            {
                // TODO: Implement these
                case "allow":
                case "coat_of_arms":
                case "gain_effect":
                case "pagan_coa":
                    parser.ReadInsideBrackets((p) => { });
                    break;

                case "assimilate":
                    Entity.AllowsAssimilation = parser.ReadBool();
                    break;

                case "color":
                    Entity.PrimaryColour = parser.ReadIntList().ToArray();
                    break;

                case "color2":
                    Entity.SecondaryColour = parser.ReadIntList().ToArray();
                    break;

                case "caliphate":
                    Entity.IsCaliphate = parser.ReadBool();
                    break;

                case "capital":
                    Entity.CapitalId = parser.ReadInt32();
                    break;

                case "controls_religion":
                    Entity.ControlledReligionId = parser.ReadString();
                    break;

                case "creation_requires_capital":
                    Entity.CreationRequiresCapital = parser.ReadBool();
                    break;

                case "culture":
                    Entity.CultureId = parser.ReadString();
                    break;

                case "dignity":
                    Entity.Dignity = parser.ReadInt32();
                    break;

                case "dynasty_title_names":
                    Entity.UseDynastyTitleNames = parser.ReadBool();
                    break;

                case "female_names":
                    Entity.FemaleNames = parser.ReadStringList();
                    break;

                case "foa":
                    Entity.TitleFormOfAddress = parser.ReadString();
                    break;

                case "graphical_culture":
                    Entity.GraphicalCulture = parser.ReadString();
                    break;
                    
                case "has_top_de_jure_capital":
                    Entity.HasTopDeJureCapital = parser.ReadBool();
                    break;

                case "holy_order":
                    Entity.IsHolyOrder = parser.ReadBool();
                    break;

                case "holy_site":
                    Entity.HolySites.Add(parser.ReadString());
                    break;

                case "independent":
                    Entity.IsIndependent = parser.ReadBool();
                    break;

                case "landless":
                    Entity.IsLandless = parser.ReadBool();
                    break;

                case "location_ruler_title":
                    Entity.TitleContainsCapital = parser.ReadBool();
                    break;

                case "male_names":
                    Entity.MaleNames = parser.ReadStringList();
                    break;

                case "mercenary":
                    Entity.IsMercenaryGroup = parser.ReadBool();
                    break;

                case "mercenary_type":
                    Entity.MercenaryType = parser.ReadString();
                    break;

                case "monthly_income":
                    Entity.MonthlyIncome = parser.ReadInt32();
                    break;

                case "name_tier":
                    Entity.TitleNameTierId = parser.ReadString();
                    break;

                case "pirate":
                    Entity.IsPirate = parser.ReadBool();
                    break;

                case "primary":
                    Entity.IsPrimaryTitle = parser.ReadBool();
                    break;

                case "purple_born_heirs":
                    Entity.HasPurpleBornHeirs = parser.ReadBool();
                    break;

                case "religion":
                    Entity.ReligionId = parser.ReadString();
                    break;

                case "short_name":
                    Entity.UseShortName = parser.ReadBool();
                    break;

                case "strength_growth_per_century":
                    Entity.StrengthGrowthPerCentury = parser.ReadFloat();
                    break;

                case "title":
                    Entity.TitleLocalisationId = parser.ReadString();
                    break;

                case "title_female":
                    Entity.TitleLocalisationFemaleId = parser.ReadString();
                    break;

                case "title_prefix":
                    Entity.TitleLocalisationPrefixId = parser.ReadString();
                    break;

                case "tribe":
                    Entity.IsTribe = parser.ReadBool();
                    break;

                default:
                    string stringValue = parser.ReadString();
                    int intValue;

                    if (int.TryParse(stringValue, out intValue))
                    {
                        Entity.ReligiousValues.AddOrUpdate(token, intValue);
                    }
                    else
                    {
                        Entity.DynamicNames.AddOrUpdate(token, stringValue);
                    }

                    break;
            }
        }
        
        public void Write(ParadoxStreamWriter writer)
        {
            List<KeyValuePair<string, string>> sortedDynamicNames = Entity.DynamicNames.ToList().OrderBy(x => x.Key).ToList();

            foreach(var dynamicName in sortedDynamicNames)
            {
                writer.WriteLine(dynamicName.Key, dynamicName.Value, ValueWrite.Quoted);
            }

            foreach (LandedTitleEntity landedTitle in Entity.Children)
            {
                LandedTitleDefinition landedTitleDefinition = new LandedTitleDefinition
                {
                    Entity = landedTitle
                };

                writer.Write(landedTitle.Id, landedTitleDefinition);
            }
        }
    }
}
