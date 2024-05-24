namespace TAB.Library.Backend.Core.Constants
{
    public static class DefaultSettings
    {
        public const int PageSize = 10;

        public static readonly int MinPageNumber = 1;
        public static readonly int MaxPageNumber = 500;

        public static readonly int MinPageSize = 1;
        public static readonly int MaxPageSize = 50;

        public static readonly int AdministratorRoleId = 1;
        public static readonly int UserRoleId = 2;

        public static readonly int MinUsernameLength = 3;
        public static readonly int MaxUsernameLength = 20;

        public static readonly int MinPasswordLength = 3;
        public static readonly int MaxPasswordLength = 20;

        public static readonly int MinEmailLength = 3;
        public static readonly int MaxEmailLength = 256;

        public static readonly int MinPhoneNumberLength = 3;
        public static readonly int MaxPhoneNumberLength = 20;

        public static readonly int RentalPeriodInDays = 14;
    }
}
