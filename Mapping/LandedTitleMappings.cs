using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using CK2ModTests.DataAccess.DataObjects;
using CK2ModTests.DomainModels;

namespace CK2ModTests.Mapping
{
    /// <summary>
    /// Extensions for mapping between a <see cref="LandedTitleEntity"/> data object and a <see cref="LandedTitle"/> domain model.
    /// </summary>
    static class LandedTitleMappings
    {
        /// <summary>
        /// Converts a <see cref="LandedTitleEntity"/> data object into a <see cref="LandedTitle"/> domain model.
        /// </summary>
        /// <returns>The <see cref="LandedTitle"/> domain model.</returns>
        /// <param name="dataObject">The <see cref="LandedTitleEntity"/> data object.</param>
        internal static LandedTitle ToDomainModel(this LandedTitleEntity dataObject)
        {
            LandedTitle domainModel = new LandedTitle
            {
                Id = dataObject.Id,
                ParentId = dataObject.ParentId,
                //Children = landedTitleEntity.Children.ToDomainModels().ToList(),
                FemaleNames = dataObject.FemaleNames,
                MaleNames = dataObject.MaleNames,
                HolySites = dataObject.HolySites,
                DynamicNames = dataObject.DynamicNames.ToDictionary(kvp => kvp.Key, kvp => kvp.Value),
                PrimaryColour = GetColorFromIntArray(dataObject.PrimaryColour),
                SecondaryColour = GetColorFromIntArray(dataObject.SecondaryColour),
                ControlledReligionId = dataObject.ControlledReligionId,
                CultureId = dataObject.CultureId,
                GraphicalCulture = dataObject.GraphicalCulture,
                MercenaryType = dataObject.MercenaryType,
                ReligionId = dataObject.ReligionId,
                TitleFormOfAddress = dataObject.TitleFormOfAddress,
                TitleLocalisationId = dataObject.TitleLocalisationId,
                TitleLocalisationFemaleId = dataObject.TitleLocalisationFemaleId,
                TitleLocalisationPrefixId = dataObject.TitleLocalisationPrefixId,
                TitleNameTierId = dataObject.TitleNameTierId,
                AllowsAssimilation = dataObject.AllowsAssimilation,
                CreationRequiresCapital = dataObject.CreationRequiresCapital,
                TitleContainsCapital = dataObject.TitleContainsCapital,
                HasPurpleBornHeirs = dataObject.HasPurpleBornHeirs,
                HasTopDeJureCapital = dataObject.HasTopDeJureCapital,
                IsCaliphate = dataObject.IsCaliphate,
                IsHolyOrder = dataObject.IsHolyOrder,
                IsIndependent = dataObject.IsIndependent,
                IsLandless = dataObject.IsLandless,
                IsMercenaryGroup = dataObject.IsMercenaryGroup,
                IsPirate = dataObject.IsPirate,
                IsPrimaryTitle = dataObject.IsPrimaryTitle,
                IsTribe = dataObject.IsTribe,
                UseDynastyTitleNames = dataObject.UseDynastyTitleNames,
                UseShortName = dataObject.UseShortName,
                StrengthGrowthPerCentury = dataObject.StrengthGrowthPerCentury,
                CapitalId = dataObject.CapitalId,
                Dignity = dataObject.Dignity,
                MonthlyIncome = dataObject.MonthlyIncome
            };

            return domainModel;
        }

        internal static IEnumerable<LandedTitle> ToDomainModelsRecursively(this LandedTitleEntity landedTitleEntity)
        {
            List<LandedTitle> landedTitles = new List<LandedTitle>();

            landedTitles.Add(landedTitleEntity.ToDomainModel());

            foreach(LandedTitleEntity child in landedTitleEntity.Children)
            {
                landedTitles.AddRange(child.ToDomainModelsRecursively());
            }

            return landedTitles;
        }

        /// <summary>
        /// Converts the domain model into an entity.
        /// </summary>
        /// <returns>The entity.</returns>
        /// <param name="landedTitle">LandedTitle.</param>
        internal static LandedTitleEntity ToEntity(this LandedTitle landedTitle)
        {
            LandedTitleEntity landedTitleEntity = new LandedTitleEntity
            {
                Id = landedTitle.Id,
                ParentId = landedTitle.ParentId,
                //Children = landedTitle.Children.ToEntities().ToList(),
                FemaleNames = landedTitle.FemaleNames,
                MaleNames = landedTitle.MaleNames,
                HolySites = landedTitle.HolySites,
                DynamicNames = landedTitle.DynamicNames,
                PrimaryColour = new int[] { landedTitle.PrimaryColour.R, landedTitle.PrimaryColour.G, landedTitle.PrimaryColour.B },
                SecondaryColour = new int[] { landedTitle.SecondaryColour.R, landedTitle.SecondaryColour.G, landedTitle.SecondaryColour.B },
                CultureId = landedTitle.CultureId,
                ControlledReligionId = landedTitle.ControlledReligionId,
                GraphicalCulture = landedTitle.GraphicalCulture,
                MercenaryType = landedTitle.MercenaryType,
                ReligionId = landedTitle.ReligionId,
                TitleFormOfAddress = landedTitle.TitleFormOfAddress,
                TitleLocalisationId = landedTitle.TitleLocalisationId,
                TitleLocalisationFemaleId = landedTitle.TitleLocalisationFemaleId,
                TitleLocalisationPrefixId = landedTitle.TitleLocalisationPrefixId,
                TitleNameTierId = landedTitle.TitleNameTierId,
                AllowsAssimilation = landedTitle.AllowsAssimilation,
                CreationRequiresCapital = landedTitle.CreationRequiresCapital,
                TitleContainsCapital = landedTitle.TitleContainsCapital,
                HasPurpleBornHeirs = landedTitle.HasPurpleBornHeirs,
                HasTopDeJureCapital = landedTitle.HasTopDeJureCapital,
                IsCaliphate = landedTitle.IsCaliphate,
                IsHolyOrder = landedTitle.IsHolyOrder,
                IsIndependent = landedTitle.IsIndependent,
                IsLandless = landedTitle.IsLandless,
                IsMercenaryGroup = landedTitle.IsMercenaryGroup,
                IsPirate = landedTitle.IsPirate,
                IsPrimaryTitle = landedTitle.IsPrimaryTitle,
                IsTribe = landedTitle.IsTribe,
                UseDynastyTitleNames = landedTitle.UseDynastyTitleNames,
                UseShortName = landedTitle.UseShortName,
                StrengthGrowthPerCentury = landedTitle.StrengthGrowthPerCentury,
                CapitalId = landedTitle.CapitalId,
                Dignity = landedTitle.Dignity,
                MonthlyIncome = landedTitle.MonthlyIncome
            };

            return landedTitleEntity;
        }

        internal static LandedTitleEntity ToEntity(this IEnumerable<LandedTitle> landedTitles)
        {
            LandedTitleEntity landedTitleEntity = landedTitles.FirstOrDefault(x => landedTitles.All(y => y.Id != x.ParentId)).ToEntity();

            AddChildrenToEntityRecursively(landedTitleEntity, landedTitles);

            return landedTitleEntity;
        }

        private static void AddChildrenToEntityRecursively(LandedTitleEntity landedTitleEntity, IEnumerable<LandedTitle> landedTitles)
        {
            foreach(LandedTitle landedTitle in landedTitles.Where(x => x.ParentId == landedTitleEntity.Id))
            {
                LandedTitleEntity child = landedTitle.ToEntity();
                landedTitleEntity.Children.Add(child);

                AddChildrenToEntityRecursively(child, landedTitles);
            }
        }

        /// <summary>
        /// Converts the entities into domain models.
        /// </summary>
        /// <returns>The domain models.</returns>
        /// <param name="landedTitleEntities">LandedTitle entities.</param>
        internal static IEnumerable<LandedTitle> ToDomainModels(this IEnumerable<LandedTitleEntity> landedTitleEntities)
        {
            List<LandedTitle> landedTitles = new List<LandedTitle>();

            foreach(LandedTitleEntity landedTitleEntity in landedTitleEntities)
            {
                IEnumerable<LandedTitle> landedTitlesChildren = landedTitleEntity.ToDomainModelsRecursively();

                landedTitles.AddRange(landedTitlesChildren);
            }
            
            return landedTitles;
        }

        /// <summary>
        /// Converts the domain models into entities.
        /// </summary>
        /// <returns>The entities.</returns>
        /// <param name="landedTitles">LandedTitles.</param>
        internal static IEnumerable<LandedTitleEntity> ToEntities(this IEnumerable<LandedTitle> landedTitles)
        {
            IEnumerable<LandedTitle> roots = landedTitles.Where(x => landedTitles.All(y => y.Id != x.ParentId));
            List<LandedTitleEntity> landedTitleEntities = new List<LandedTitleEntity>();

            foreach(LandedTitle root in roots)
            {
                LandedTitleEntity landedTitleEntity = root.ToEntity();

                AddChildrenToEntityRecursively(landedTitleEntity, landedTitles);

                landedTitleEntities.Add(landedTitleEntity);
            }

            return landedTitleEntities;
        }

        private static Color GetColorFromIntArray(int[] rgb)
        {
            int r = Math.Min(Math.Max(0, rgb[0]), 255);
            int g = Math.Min(Math.Max(0, rgb[1]), 255);
            int b = Math.Min(Math.Max(0, rgb[2]), 255);

            return Color.FromArgb(255, r, g, b);
        }
    }
}
