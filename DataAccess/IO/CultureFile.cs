using System.Collections.Generic;
using System.IO;
using System.Linq;

using Pdoxcl2Sharp;

using CK2ModTests.DataAccess.DataObjects;
using CK2ModTests.DomainModels;

namespace CK2ModTests.DataAccess.IO
{
    public sealed class CultureFile : IParadoxRead
    {
        public IList<CultureGroupDefinition> CultureGroups { get; private set; }

        public CultureFile()
        {
            CultureGroups = new List<CultureGroupDefinition>();
        }

        public void TokenCallback(ParadoxParser parser, string token)
        {
            CultureGroupDefinition cultureGroup = new CultureGroupDefinition();
            cultureGroup.Entity.Id = token;

            CultureGroups.Add(parser.Parse(cultureGroup));
        }
        
        public static IEnumerable<CultureGroupEntity> ReadAllCultureGroups(string fileName)
        {
            CultureFile cultureFile;

            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                cultureFile = ParadoxParser.Parse(fs, new CultureFile());
            }

            IEnumerable<CultureGroupEntity> cultureGroups = cultureFile.CultureGroups.Select(x => x.Entity);
            
            return cultureGroups.ToList();
        }
        
        public static IEnumerable<CultureEntity> ReadAllCultures(string fileName)
        {
            CultureFile cultureFile;

            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                cultureFile = ParadoxParser.Parse(fs, new CultureFile());
            }

            IEnumerable<CultureGroupEntity> cultureGroups = cultureFile.CultureGroups.Select(x => x.Entity);
            
            return cultureGroups.SelectMany(x => x.Cultures);
        }
    }
}
