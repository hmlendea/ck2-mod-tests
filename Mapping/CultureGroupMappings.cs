using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using CK2ModTests.DataAccess.DataObjects;
using CK2ModTests.DomainModels;

namespace CK2ModTests.Mapping
{
    /// <summary>
    /// Extensions for mapping between a <see cref="CultureGroupEntity"/> data object and a <see cref="CultureGroup"/> domain model.
    /// </summary>
    static class CultureGroupMappings
    {
        /// <summary>
        /// Converts a <see cref="CultureGroupEntity"/> data object into a <see cref="CultureGroup"/> domain model.
        /// </summary>
        /// <returns>The <see cref="CultureGroup"/> domain model.</returns>
        /// <param name="dataObject">The <see cref="CultureGroupEntity"/> data object.</param>
        internal static CultureGroup ToDomainModel(this CultureGroupEntity dataObject)
        {
            CultureGroup culture = new CultureGroup
            {
                Id = dataObject.Id,
                GraphicalCultures = dataObject.GraphicalCultures,
                Cultures = dataObject.Cultures.ToDomainModels()
            };

            return culture;
        }

        /// <summary>
        /// Converts a <see cref="CultureGroupEntity"/> data object collection into a <see cref="CultureGroup"/> domain model collection.
        /// </summary>
        /// <returns>The <see cref="CultureGroup"/> domain model collection.</returns>
        /// <param name="dataObjects">The <see cref="CultureGroupEntity"/> data object collection.</param>
        internal static IEnumerable<CultureGroup> ToDomainModels(this IEnumerable<CultureGroupEntity> dataObjects)
        {
            IEnumerable<CultureGroup> domainModels = dataObjects
                .Select(x => x.ToDomainModel())
                .ToList();
            
            return domainModels;
        }
    }
}
