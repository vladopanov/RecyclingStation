namespace RecyclingStation.Models
{
    public class ManagementRequirement
    {
        public ManagementRequirement(double energyBalance, double capitalBalance, string garbageType)
        {
            this.EnergyBalance = energyBalance;
            this.CapitalBalance = capitalBalance;
            this.GarbageType = garbageType;
        }

        public string GarbageType { get; }

        public double CapitalBalance { get; }

        public double EnergyBalance { get; }
    }
}
