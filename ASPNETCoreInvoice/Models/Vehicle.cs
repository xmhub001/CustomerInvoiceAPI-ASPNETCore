namespace ASPNETCoreInvoice.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public required string? VIN { get; set; }
        public string? LicensePlate { get; set; }
        public string? LicenseState { get; set; }
        public string? Model { get; set; }
        public string? Make { get; set; }
        public string? Year { get; set; }

    }
}
