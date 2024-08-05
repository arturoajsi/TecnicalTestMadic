using TecnicalTestMadic.Models;

namespace TecnicalTestMadic.Interfaces
{
    public interface IGasStationService
    {
        /// <summary>
        /// Change the status of the selected pump to 'opened'
        /// </summary>
        /// <param name="pumpId">Id of the pump selected</param>
        /// <returns>Notify the client if the pump was successfully open</returns>
        string ReleaseGasolinePump(int pumpId);

        /// <summary>
        /// Set the limit of money per gasoline the client can spend
        /// </summary>
        /// <param name="limitMoney">limit of money to be set</param>
        string SetLimitMoney(int pumpId, int limitMoney);

        /// <summary>
        /// Change the status of the selected pump to 'closed'
        /// </summary>
        /// <param name="pumpId">Id of the pump selected</param>
        /// <returns>Notify the client if the pump was successfully close</returns>
        string CloseGasolinePump(int pumpId);

        /// <summary>
        /// Get the current status of all the Pumps
        /// </summary>
        /// <returns>Return a list of GasolinePump</returns>
        List<GasolinePump> GetAllPumpsStatus();

        /// <summary>
        /// Get all the supply history stored
        /// </summary>
        /// <returns>Return a list of SupplyHistory</returns>
        List<SupplyHistory> GetAllSupplyHistories();

        /// <summary>
        /// Stored a supply history 
        /// </summary>
        /// <param name="pump">Contains pump's data to be store</param>
        void StoredSupplyHistory(GasolinePump pump);
    }
}
