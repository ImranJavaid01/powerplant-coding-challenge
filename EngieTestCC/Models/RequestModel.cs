namespace EngieTestCC.Models
{
    public class RequestModel
    {
        public decimal load { get; set; }
        public EngieFuels fuels { get; set; }
        public List<Powerplant> powerplants { get; set; }
    }

    public class EngieFuels
    {
        public decimal gas { get; set; }
        public decimal kerosine { get; set; }
        public decimal co2 { get; set; }
        public decimal wind { get; set; }
    }
}
