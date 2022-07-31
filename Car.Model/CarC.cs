namespace Car.Model
{
    internal class CarC
    {
        public int Id { get; set; }
        public string Mark { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int VIN { get; set; }
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}