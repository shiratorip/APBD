using ContainerSpace;
namespace APBD2.ContainerSpace
{
    internal class ContainerLiquids : Container
    {
        public ContainerLiquids(double cargoWeightKg, double heightCm, double ownWeightKg, double depthCm, double maxLoadCapacityKg) : base(cargoWeightKg, heightCm, ownWeightKg, depthCm, maxLoadCapacityKg)
        {
        }

        protected override string GenerateSerialNumber()
        {
            lastNumber++;
            return $"CON-L-{lastNumber}";
        }
    }
}
