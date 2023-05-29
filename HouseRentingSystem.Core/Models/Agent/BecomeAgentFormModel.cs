namespace HouseRentingSystem.Core.Models.Agent
{
    using System.ComponentModel.DataAnnotations;
    using static Data.Common.GlobalConstants;

    public class BecomeAgentFormModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        [StringLength(AgentPhoneNumberMaxLength, MinimumLength = AgentPhoneNumberMinLength)]
        public string  PhoneNumber { get; set; }
    }
}
