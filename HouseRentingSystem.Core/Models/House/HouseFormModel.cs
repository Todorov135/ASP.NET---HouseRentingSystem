namespace HouseRentingSystem.Core.Models.House
{
    using System.ComponentModel.DataAnnotations;
    using static HouseRentingSystem.Data.Common.GlobalConstants;

    public class HouseFormModel
    {
        [Required]
        [StringLength(HouseTitleMaxLength, MinimumLength = HouseTitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(HouseAddressMaxLength, MinimumLength = HouseAddressMinLength)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(HouseDescriptionMaxLength, MinimumLength = HouseDescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Display(Name = "Price Per Month")]
        [Range(typeof(decimal), HousePricePerMonthMinValue, HousePricePerMonthMaxValue)]
        public decimal PricePerMonth { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<HouseCategoriesViewModel> Categories { get; set; } = new List<HouseCategoriesViewModel>();
    }
}
