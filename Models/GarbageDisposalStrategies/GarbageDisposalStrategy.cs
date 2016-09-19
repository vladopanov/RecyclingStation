using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Models.GarbageDisposalStrategies
{
    public abstract class GarbageDisposalStrategy : IGarbageDisposalStrategy
    {
        public abstract IProcessingData ProcessGarbage(IWaste garbage);
    }
}
