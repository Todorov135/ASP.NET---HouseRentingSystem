namespace HouseRentingSystem.Data.Common
{
  
    public static class GlobalConstants
    {
        //Category Entity
        public const int CategoryNameMaxLength = 50;

        //House Entity
        public const int HouseTitleMinLength = 10;
        public const int HouseTitleMaxLength = 50;
        public const int HouseAddressMinLength = 30;
        public const int HouseAddressMaxLength = 150;
        public const int HouseDescriptionMinLength = 50;
        public const int HouseDescriptionMaxLength = 500;
        public const int HouseImageUrlMaxLength = 200;
        public const string HousePricePerMonthMinValue = "0";
        public const string HousePricePerMonthMaxValue = "2000";

        //Agent Entity
        public const int AgentPhoneNumberMinLength = 7;
        public const int AgentPhoneNumberMaxLength = 15;
    }
}
