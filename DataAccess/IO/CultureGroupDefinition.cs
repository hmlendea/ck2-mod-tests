using System;
using System.Collections.Generic;
using System.Linq;

using Pdoxcl2Sharp;

using CK2ModTests.DataAccess.DataObjects;
using CK2ModTests.Extensions;

namespace CK2ModTests.DataAccess.IO
{
    public sealed class CultureGroupDefinition : IParadoxRead
    {
        public CultureGroupEntity Entity { get; set; }

        public CultureGroupDefinition()
        {
            Entity = new CultureGroupEntity();
        }
        
        public void TokenCallback(ParadoxParser parser, string token)
        {
            switch (token)
            {
                case "graphical_cultures":
                    Entity.GraphicalCultures = parser.ReadStringList();
                    break;
                
                default:
                    CultureDefinition culture = new CultureDefinition();
                    culture.Entity.Id = token;

                    Entity.Cultures.Add(parser.Parse(culture).Entity);
                    break;
            }
        }
    }
}
