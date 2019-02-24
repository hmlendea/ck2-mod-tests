using System.Collections.Generic;
using System.IO;
using System.Linq;

using Pdoxcl2Sharp;

using CK2ModTests.DataAccess.DataObjects;
using CK2ModTests.DomainModels;

namespace CK2ModTests.DataAccess.IO
{
    public sealed class LandedTitlesFile : IParadoxRead, IParadoxWrite
    {
        public IList<LandedTitleDefinition> LandedTitles { get; set; }

        public LandedTitlesFile()
        {
            LandedTitles = new List<LandedTitleDefinition>();
        }

        public void TokenCallback(ParadoxParser parser, string token)
        {
            LandedTitleDefinition landedTitle = new LandedTitleDefinition();
            landedTitle.Entity.Id = token;

            LandedTitles.Add(parser.Parse(landedTitle));
        }
        
        public void Write(ParadoxStreamWriter writer)
        {
            foreach (LandedTitleDefinition landedTitle in LandedTitles)
            {
                writer.Write(landedTitle.Entity.Id, landedTitle);
            }
        }

        public static IEnumerable<LandedTitleEntity> ReadAllTitles(string fileName)
        {
            LandedTitlesFile landedTitlesFile;
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                landedTitlesFile = ParadoxParser.Parse(fs, new LandedTitlesFile());
            }
            
            return landedTitlesFile.LandedTitles.Select(x => x.Entity);
        }

        public static void WriteAllTitles(string fileName, IEnumerable<LandedTitleEntity> landedTitles)
        {
            LandedTitlesFile landedTitlesFile = new LandedTitlesFile
            {
                LandedTitles = landedTitles.Select(x => new LandedTitleDefinition { Entity = x }).ToList()
            };

            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            using (ParadoxSaver saver = new ParadoxSaver(fs))
            {
                landedTitlesFile.Write(saver);
            }
        }
    }
}
