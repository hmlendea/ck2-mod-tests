using System.Collections.Generic;

namespace CK2ModTests.DomainModels
{
    public class CultureGroup
    {
        public string Id { get; set; }

        public IList<string> GraphicalCultures { get; set; }
        
        public IEnumerable<Culture> Cultures { get; set; }

        public CultureGroup()
        {
            Cultures = new List<Culture>();
        }
    }
}
