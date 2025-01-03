namespace Charcillaries.Core;

public static class Constants
{
    public const int CommonPageSize = 50;

    public const string BucketName = "charcillaries";

    public static class ObjectStatus
    {
        public const int Active = 1;

        public const int Disabled = 0;
    }

    public static class ConfirmationStatus
    {
        public const int Confirmed = 1;

        public const int Pending = 0;
    }
}