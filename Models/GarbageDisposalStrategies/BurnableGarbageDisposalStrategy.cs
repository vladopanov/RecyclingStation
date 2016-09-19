using RecyclingStation.WasteDisposal.Attributes;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Models.GarbageDisposalStrategies
{
    public class BurnableGarbageDisposalStrategy : GarbageDisposalStrategy
    {
        public override IProcessingData ProcessGarbage(IWaste garbage)
        {
            var garbageVolume = garbage.VolumePerKg*garbage.Weight;

            var energyBalance = garbageVolume - (garbageVolume / 5);
            const double capitalBalance = 0;
            IProcessingData data = new ProcessingData(energyBalance, capitalBalance);

            return data;
        }
    }
}
