namespace RecyclingStation.WasteDisposal
{
    using System;
    using System.Linq;
    using Attributes;
    using Interfaces;

    public class GarbageProcessor : IGarbageProcessor
    {
        public GarbageProcessor(IStrategyHolder strategyHolder)
        {
            this.StrategyHolder = strategyHolder;
        }

        public GarbageProcessor() : this(new StrategyHolder())
        {
        }

        public IStrategyHolder StrategyHolder { get; private set; }

        public IProcessingData ProcessWaste(IWaste garbage)
        {
            Type type = garbage.GetType();
            DisposableAttribute disposalAttribute = (DisposableAttribute)type.GetCustomAttributes(true).FirstOrDefault();
            IGarbageDisposalStrategy currentStrategy;
            if (disposalAttribute == null || !this.StrategyHolder.GetDisposalStrategies.TryGetValue(disposalAttribute.GetType(), out currentStrategy))
            {
                return null;
            }

            return currentStrategy.ProcessGarbage(garbage);
        }
    }
}
