using RecyclingStation.WasteDisposal.Attributes;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Models.GarbageDisposalStrategies
{
    public class RecyclableGarbageDsiposalStrategy : GarbageDisposalStrategy
    {
        public override IProcessingData ProcessGarbage(IWaste garbage)
        {
            var garbageVolume = garbage.VolumePerKg * garbage.Weight;

            var energyBalance = -(garbageVolume / 2);
            var capitalBalance = 400 * garbage.Weight;
            IProcessingData data = new ProcessingData(energyBalance, capitalBalance);

            return data;
        }
    }
}
