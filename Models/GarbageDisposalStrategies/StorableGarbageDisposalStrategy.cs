using RecyclingStation.WasteDisposal.Attributes;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Models.GarbageDisposalStrategies
{
    public class StorableGarbageDisposalStrategy : GarbageDisposalStrategy
    {
        public override IProcessingData ProcessGarbage(IWaste garbage)
        {
            var garbageVolume = garbage.VolumePerKg * garbage.Weight;

            var energyBalance = -(0.13 * garbageVolume);
            var capitalBalance = -(0.65 * garbageVolume);
            IProcessingData data = new ProcessingData(energyBalance, capitalBalance);

            return data;
        }
    }
}
