using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace CK2ModTests.DomainModels
{
    public class LandedTitle
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the de-jure title it belongs to.
        /// </summary>
        /// <value>The de jure title identifier.</value>
        public string ParentId { get; set; }

        public IList<LandedTitle> Children { get; set; }
        
        /// <summary>
        /// Gets or sets the female names.
        /// </summary>
        /// <value>The female names.</value>
        public IList<string> FemaleNames { get; set; }

        /// <summary>
        /// Gets or sets the male names.
        /// </summary>
        /// <value>The male banes.</value>
        public IList<string> MaleNames { get; set; }

        /// <summary>
        /// Gets or sets the holy sites.
        /// </summary>
        /// <value>The holy sites.</value>
        public IList<string> HolySites { get; set; }

        /// <summary>
        /// Gets or sets the dynamic names.
        /// </summary>
        /// <value>The dynamic names.</value>
        public IDictionary<string, string> DynamicNames { get; set; }

        /// <summary>
        /// Gets or sets the religious values.
        /// </summary>
        /// <value>The religious values.</value>
        public IDictionary<string, int> ReligiousValues { get; set; }

        public Color PrimaryColour { get; set; }

        public Color SecondaryColour { get; set; }

        public string ControlledReligionId { get; set; }

        public string CultureId { get; set; }

        public string GraphicalCulture { get; set; }

        public string MercenaryType { get; set; }

        public string ReligionId { get; set; }

        public string TitleFormOfAddress { get; set; }

        public string TitleLocalisationId { get; set; }

        public string TitleLocalisationFemaleId { get; set; }
        
        public string TitleLocalisationPrefixId { get; set; }

        public string TitleNameTierId { get; set; }

        public bool AllowsAssimilation { get; set; }

        public bool CreationRequiresCapital { get; set; }

        public bool TitleContainsCapital { get; set; }

        public bool HasPurpleBornHeirs { get; set; }

        public bool HasTopDeJureCapital { get; set; }

        public bool IsCaliphate { get; set; }

        public bool IsHolyOrder { get; set; }

        public bool IsIndependent { get; set; }

        public bool IsLandless { get; set; }

        public bool IsMercenaryGroup { get; set; }

        public bool IsPirate { get; set; }

        public bool IsPrimaryTitle { get; set; }

        public bool IsTribe { get; set; }

        public bool UseDynastyTitleNames { get; set; }

        public bool UseShortName { get; set; }

        public float StrengthGrowthPerCentury { get; set; }

        public int CapitalId { get; set; }

        public int Dignity { get; set; }

        public int MonthlyIncome { get; set; }

        public LandedTitle()
        {
            Children = new List<LandedTitle>();
            FemaleNames = new List<string>();
            MaleNames = new List<string>();
            HolySites = new List<string>();

            DynamicNames = new Dictionary<string, string>();
            ReligiousValues = new Dictionary<string, int>();
        }
    }
}
