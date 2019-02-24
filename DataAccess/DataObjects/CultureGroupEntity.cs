using System.Collections.Generic;

namespace CK2ModTests.DataAccess.DataObjects
{
    public class CultureGroupEntity
    {
        public string Id { get; set; }

        public IList<string> GraphicalCultures { get; set; }
        
        public IList<CultureEntity> Cultures { get; set; }

        public CultureGroupEntity()
        {
            Cultures = new List<CultureEntity>();
        }
    }
}
