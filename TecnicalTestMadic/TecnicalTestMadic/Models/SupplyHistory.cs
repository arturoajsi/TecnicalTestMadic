using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnicalTestMadic.Models
{
    public class SupplyHistory
    {
        //Supply history id
        public int SupplyHistoryId { get; set; }

        //Gasoline pump id
        public int PumpId { get; set; }

        //Date and hour when the gasoline pump was used
        public DateTime PumpingDate { get; set; }

        //Amount of fuel used
        public double MoneyTotal { get; set; }

        //Limit of money stablished by the client depending of how much money wants to spend
        public double MoneyLimit { get; set; }
    }
}
