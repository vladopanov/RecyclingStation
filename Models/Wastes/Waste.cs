using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Models.Wastes
{
    public abstract class Waste : IWaste
    {
        protected Waste(string name, double volumePerKg, double weight)
        {
            this.Name = name;
            this.VolumePerKg = volumePerKg;
            this.Weight = weight;
        }
        public string Name { get; }
        public double VolumePerKg { get; }
        public double Weight { get; }
    }
}
