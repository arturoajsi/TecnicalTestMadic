using TecnicalTestMadic.Interfaces;
using TecnicalTestMadic.Models;

namespace TecnicalTestMadic.Services
{
    public class GasStationService : IGasStationService
    {
        private List<GasolinePump> _pumpList;
        private List<SupplyHistory> _supplyHistoryList;
        private int _gasolinePrice = 1;

        public GasStationService()
        {
            _supplyHistoryList = new List<SupplyHistory>();

            _pumpList = new List<GasolinePump>();

            var random = new Random();

            for (int i = 1; i < 9; i++)
            {
                _pumpList.Add(
                    new GasolinePump {
                        PumpId = i,
                        Status = "Closed",
                        MoneyLimit = 0,
                    }
                );

                _supplyHistoryList.Add(
                    new SupplyHistory
                    {
                        PumpId = i,
                        SupplyHistoryId = i,
                        PumpingDate = DateTime.Now.AddDays(random.Next(1, 10)),
                        MoneyLimit = 0,
                        MoneyTotal = random.Next(1, 10)
                    }
                );
            }
        }

        /// <summary>
        /// Change the status of the selected pump to 'Opened'
        /// </summary>
        /// <param name="pumpId">Id of the pump selected</param>
        public string ReleaseGasolinePump(int pumpId)
        {
            var pump = _pumpList.FirstOrDefault(p => p.PumpId.Equals(pumpId));

            if(pump != null)
            {
                if(pump.Status == "Closed")
                {
                    pump.Status = "Opened";
                    pump.PumpingDate = DateTime.Now;

                    return "Pump " + pumpId + " is now open";
                }
                else
                {
                    return "Pump " + pumpId + " is already open";
                }
            } else
            {
                return "Sorry, there's no pump " + pumpId;
            }
        }

        /// <summary>
        /// Set the limit of money per gasoline the client can spend
        /// </summary>
        /// <param name="limitMoney">limit of money to be set</param>
        public string SetLimitMoney(int pumpId, int moneyLimit)
        {
            var pump = _pumpList.FirstOrDefault(p => p.PumpId.Equals(pumpId));

            if (pump != null)
            {
                if(pump.Status == "Closed")
                {
                    pump.MoneyLimit = moneyLimit;

                    return "Pump " + pumpId + " money limit has been set";
                } 
                else
                {
                    return "The pump must be closed to set the money limit";
                }
            }
            else
            {
                return "Sorry, there's no pump " + pumpId;
            }
        }

        /// <summary>
        /// Change the status of the selected pump to 'Closed'
        /// </summary>
        /// <param name="pumpId">Id of the pump selected</param>
        public string CloseGasolinePump(int pumpId)
        {
            var pump = _pumpList.FirstOrDefault(p => p.PumpId.Equals(pumpId));

            if (pump != null)
            {
                if (pump.Status == "Opened")
                {
                    StoredSupplyHistory(pump);

                    pump.Status = "Closed";
                    pump.MoneyLimit = 0;

                    return "Pump " + pumpId + " is now close and reset";
                }
                else
                {
                    return "Pump " + pumpId + " is already close";
                }
            }
            else
            {
                return "Sorry, there's no pump " + pumpId;
            }
        }

        /// <summary>
        /// Get the current status of all the Pumps
        /// </summary>
        /// <returns>Return a list of GasolinePump</returns>
        public List<GasolinePump> GetAllPumpsStatus()
        {
            return _pumpList;
        }

        /// <summary>
        /// Get all the supply history stored
        /// </summary>
        /// <returns>Return a list of SupplyHistory</returns>
        public List<SupplyHistory> GetAllSupplyHistories()
        {
            return _supplyHistoryList.OrderByDescending(s => s.MoneyTotal).ThenByDescending(s => s.PumpingDate).ToList();
        }


        /// <summary>
        /// Stored pump's data that
        /// </summary>
        /// <param name="pump">Contains pump's data to be store</param>
        public void StoredSupplyHistory(GasolinePump pump)
        {
            var moneyTotal = (DateTime.Now - pump.PumpingDate).TotalSeconds * _gasolinePrice;

            _supplyHistoryList.Add(
                new SupplyHistory
                {
                    SupplyHistoryId = _supplyHistoryList.Count + 1,
                    PumpId = pump.PumpId,
                    MoneyLimit = pump.MoneyLimit,
                    MoneyTotal = Math.Round(moneyTotal, 2),
                    PumpingDate = pump.PumpingDate,
                }
            );
        }
    }
}
