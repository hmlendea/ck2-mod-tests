using System.Collections.Generic;
using System.Drawing;

namespace CK2ModTests.DomainModels
{
    public class Culture
    {
        public string Id { get; set; }

        public string CultureGroupId { get; set; }

        public string ParentId { get; set; }

        public bool HasParent => !string.IsNullOrWhiteSpace(ParentId);

        public bool IsAvailableRandomly { get; set; }

        public bool IsNomadicInAlternateStart { get; set; }

        public bool IsHorde { get; set; }

        public IList<string> GraphicalCultures { get; set; }

        public IList<string> UnitGraphicalCultures { get; set; }

        public string SecondaryEventPictures { get; set; }

        public Color? Colour { get; set; }

        public IList<string> MaleNames { get; set; }

        public IList<string> FemaleNames { get; set; }

        public bool AreDukesCalledKings { get; set; }

        public bool AreBaronTitlesHidden { get; set; }

        public bool AreCountTitlesHidden { get; set; }

        public string FromDynastyPrefix { get; set; }

        public string BastardDynastyPrefix { get; set; }

        public string GrammarTransformation { get; set; }

        public string MalePatronym { get; set; }

        public string FemalePatronym { get; set; }

        public bool IsPatronymPrefix { get; set; }

        public bool IsDynastyNameFirst { get; set; }

        public int PatrilinealGrandfatherNameChance { get; set; }
        
        public int PatrilinealGrandmotherNameChance { get; set; }

        public int MatrilinealGrandfatherNameChance { get; set; }

        public int MatrilinealGrandmotherNameChance { get; set; }

        public int FatherNameChance { get; set; }

        public int MotherNameChance { get; set; }

        public bool AreDynastiesNamedByFounders { get; set; }

        public bool HasDynasticTitleNames { get; set; }

        public bool HasCastes { get; set; }

        public bool IsDisinheritedFromBlinding { get; set; }

        public bool IsAllowedToLoot { get; set; }

        public bool IsSeafarer { get; set; }

        public string TribalName { get; set; }

        public string CulturalModifier { get; set; }

        public Culture()
        {
            MaleNames = new List<string>();
            FemaleNames = new List<string>();
        }
    }
}
