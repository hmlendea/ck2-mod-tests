using System;
using System.Collections.Generic;
using System.Linq;

using Pdoxcl2Sharp;

using CK2ModTests.DataAccess.DataObjects;
using CK2ModTests.Extensions;

namespace CK2ModTests.DataAccess.IO
{
    public sealed class CultureDefinition : IParadoxRead
    {
        public CultureEntity Entity { get; set; }

        public CultureDefinition()
        {
            Entity = new CultureEntity();
        }
        
        public void TokenCallback(ParadoxParser parser, string token)
        {
            switch (token)
            {
                case "parent":
                    Entity.ParentId = parser.ReadString();
                    break;

                case "graphical_cultures":
                    Entity.GraphicalCultures = parser.ReadStringList();
                    break;

                case "unit_graphical_cultures":
                    Entity.UnitGraphicalCultures = parser.ReadStringList();
                    break;

                case "secondary_event_pictures":
                    Entity.SecondaryEventPictures = parser.ReadString();
                    break;

                case "used_for_random":
                    Entity.IsAvailableRandomly = parser.ReadBool();
                    break;

                case "nomadic_in_alt_start":
                    Entity.IsNomadicInAlternateStart = parser.ReadBool();
                    break;

                case "horde":
                    Entity.IsHorde = parser.ReadBool();
                    break;

                case "color":
                    Entity.Colour = parser.ReadIntList().ToArray();
                    break;

                case "male_names":
                    Entity.MaleNames = parser.ReadStringList();
                    break;

                case "female_names":
                    Entity.FemaleNames = parser.ReadStringList();
                    break;

                case "from_dynasty_prefix":
                    Entity.FromDynastyPrefix = parser.ReadString();
                    break;

                case "bastard_dynasty_prefix":
                    Entity.BastardDynastyPrefix = parser.ReadString();
                    break;

                case "grammar_transform":
                    Entity.GrammarTransformation = parser.ReadString();
                    break;

                case "male_patronym":
                    Entity.MalePatronym = parser.ReadString();
                    break;

                case "female_patronym":
                    Entity.FemalePatronym = parser.ReadString();
                    break;

                case "prefix":
                    Entity.IsPatronymPrefix = parser.ReadBool();
                    break;

                case "dynasty_name_first":
                    Entity.IsDynastyNameFirst = parser.ReadBool();
                    break;

                case "pat_grf_name_chance":
                    Entity.PatrilinealGrandfatherNameChance = parser.ReadInt16();
                    break;

                case "pat_grm_name_chance":
                    Entity.PatrilinealGrandmotherNameChance = parser.ReadInt16();
                    break;

                case "mat_grf_name_chance":
                    Entity.MatrilinealGrandfatherNameChance = parser.ReadInt16();
                    break;

                case "mat_grm_name_chance":
                    Entity.MatrilinealGrandmotherNameChance = parser.ReadInt16();
                    break;

                case "father_name_chance":
                    Entity.FatherNameChance = parser.ReadInt16();
                    break;

                case "mother_name_chance":
                    Entity.MotherNameChance = parser.ReadInt16();
                    break;
                
                case "dukes_called_kings":
                    Entity.AreDukesCalledKings = parser.ReadBool();
                    break;
                
                case "baron_titles_hidden":
                    Entity.AreBaronTitlesHidden = parser.ReadBool();
                    break;
                
                case "count_titles_hidden":
                    Entity.AreCountTitlesHidden = parser.ReadBool();
                    break;

                case "founder_named_dynasties":
                    Entity.AreDynastiesNamedByFounders = parser.ReadBool();
                    break;

                case "dynasty_title_names":
                    Entity.HasDynasticTitleNames = parser.ReadBool();
                    break;

                case "castes":
                    Entity.HasCastes = parser.ReadBool();
                    break;

                case "disinherit_from_blinding":
                    Entity.IsDisinheritedFromBlinding = parser.ReadBool();
                    break;

                case "allow_looting":
                    Entity.IsAllowedToLoot = parser.ReadBool();
                    break;

                case "seafarer":
                    Entity.IsSeafarer = parser.ReadBool();
                    break;

                case "tribal_name":
                    Entity.TribalName = parser.ReadString();
                    break;

                case "modifier":
                    Entity.CulturalModifier = parser.ReadString();
                    break;

                default:
                    throw new InvalidOperationException($"Unexpected token \"{token}\"");
            }
        }
    }
}
