namespace PumpItUp.DAL.Common
{
    public static class AppConstants
    {
        public const string EmailPattern = @"[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})"; 

        public const string PasswordPattern = @"(?=.*\\d)(?=.*[A-Z])(?=.*[a-z])[A-Za-z\\d]{8,}";

        public const string FirstAndLastNamePattern = "[A-Z][a-z]+";

        public const string AgePattern = "[0-9]+";

        public const string CardNumberPattern = @"^\d{16}$";
        
        public const string CvvPattern = @"^\d{3,4}$";
        
        public const string ExpirationDatePattern = @"^(0[1-9]|1[0-2])\/\d{2}$";
    }
}