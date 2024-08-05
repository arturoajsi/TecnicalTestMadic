namespace TecnicalTestMadic.Models
{
    public class GasolinePump
    {
        //Gasoline Pump ID
        public required int PumpId { get; set; }

        //Current status of the gasoline pump
        public required string Status { get; set; }

        //Limit of money stablished by the client depending of how much money wants to spend
        public double MoneyLimit { get; set; }

        //Date and hour when the gasoline pump was used
        public DateTime PumpingDate { get; set; }
    }
}
