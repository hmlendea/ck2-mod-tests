using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using CK2ModTests.DataAccess.DataObjects;
using CK2ModTests.DomainModels;

namespace CK2ModTests.Mapping
{
    /// <summary>
    /// Extensions for mapping between a <see cref="CultureEntity"/> data object and a <see cref="Culture"/> domain model.
    /// </summary>
    static class CultureMappings
    {
        /// <summary>
        /// Converts a <see cref="CultureEntity"/> data object into a <see cref="Culture"/> domain model.
        /// </summary>
        /// <returns>The <see cref="Culture"/> domain model.</returns>
        /// <param name="dataObject">The <see cref="CultureEntity"/> data object.</param>
        internal static Culture ToDomainModel(this CultureEntity dataObject)
        {
            Culture domainModel = new Culture
            {
                Id = dataObject.Id,
                CultureGroupId = dataObject.CultureGroupId,
                ParentId = dataObject.ParentId,
                IsAvailableRandomly = dataObject.IsAvailableRandomly,
                IsNomadicInAlternateStart = dataObject.IsNomadicInAlternateStart,
                IsHorde = dataObject.IsHorde,
                GraphicalCultures = dataObject.GraphicalCultures,
                SecondaryEventPictures = dataObject.SecondaryEventPictures,
                Colour = GetColorFromIntArray(dataObject.Colour),
                FemaleNames = dataObject.FemaleNames,
                MaleNames = dataObject.MaleNames,
                FromDynastyPrefix = dataObject.FromDynastyPrefix,
                BastardDynastyPrefix = dataObject.BastardDynastyPrefix,
                GrammarTransformation = dataObject.GrammarTransformation,
                MalePatronym = dataObject.MalePatronym,
                FemalePatronym = dataObject.FemalePatronym,
                IsPatronymPrefix = dataObject.IsPatronymPrefix,
                IsDynastyNameFirst = dataObject.IsDynastyNameFirst,
                PatrilinealGrandfatherNameChance = dataObject.PatrilinealGrandfatherNameChance,
                PatrilinealGrandmotherNameChance = dataObject.PatrilinealGrandmotherNameChance,
                MatrilinealGrandfatherNameChance = dataObject.MatrilinealGrandfatherNameChance,
                MatrilinealGrandmotherNameChance = dataObject.MatrilinealGrandmotherNameChance,
                FatherNameChance = dataObject.FatherNameChance,
                MotherNameChance = dataObject.MotherNameChance,
                IsDisinheritedFromBlinding = dataObject.IsDisinheritedFromBlinding,
                AreDukesCalledKings = dataObject.AreDukesCalledKings,
                AreBaronTitlesHidden = dataObject.AreBaronTitlesHidden,
                AreCountTitlesHidden = dataObject.AreCountTitlesHidden,
                AreDynastiesNamedByFounders = dataObject.AreDynastiesNamedByFounders,
                HasDynasticTitleNames = dataObject.HasDynasticTitleNames,
                HasCastes = dataObject.HasCastes,
                IsAllowedToLoot = dataObject.IsAllowedToLoot,
                IsSeafarer = dataObject.IsSeafarer,
                TribalName = dataObject.TribalName,
                CulturalModifier = dataObject.CulturalModifier
            };

            return domainModel;
        }

        /// <summary>
        /// Converts a <see cref="CultureEntity"/> data object collection into a <see cref="Culture"/> domain model collection.
        /// </summary>
        /// <returns>The <see cref="Culture"/> domain model collection.</returns>
        /// <param name="dataObjects">The <see cref="CultureEntity"/> data object collection.</param>
        internal static IEnumerable<Culture> ToDomainModels(this IEnumerable<CultureEntity> dataObjects)
        {
            IEnumerable<Culture> domainModels = dataObjects
                .Select(x => x.ToDomainModel())
                .ToList();
            
            return domainModels;
        }

        private static Color? GetColorFromIntArray(int[] rgb)
        {
            if (rgb == null)
            {
                return null;
            }

            if (rgb.Length != 3)
            {
                throw new ArgumentException($"Invalid RGB array length ({rgb.Length}, must be 3)");
            }

            int r = Math.Min(Math.Max(0, rgb[0]), 255);
            int g = Math.Min(Math.Max(0, rgb[1]), 255);
            int b = Math.Min(Math.Max(0, rgb[2]), 255);

            return Color.FromArgb(255, r, g, b);
        }
    }
}
