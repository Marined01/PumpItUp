namespace PumpItUp.DAL.DTOs
{
    public class BankDataRequest
    {
        public string? CardHolderName { get; set; }
        public string? CardNumber { get; set; }
        public string? Cvv { get; set; }
        public string? ExpirationDate { get; set; }
        public string? BankName { get; set; }
    }
}