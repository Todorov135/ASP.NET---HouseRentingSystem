namespace HouseRentingSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.GlobalConstants;

    public class Category
    {
        public Category()
        {
            this.Houses = new List<House>();
        }

        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; } = null!;

        public IEnumerable<House> Houses { get; init; }
    }
}
