using ContainerSpace;
namespace APBD2.ContainerSpace
{
    internal class ContainerLiquids : Container, HazardNotifier
    {
        protected bool dangerous;
        public ContainerLiquids(double cargoWeightKg, double heightCm, double ownWeightKg, double depthCm, double maxLoadCapacityKg, bool dangerous) : base(cargoWeightKg, heightCm, ownWeightKg, depthCm, maxLoadCapacityKg)
        {
            this.dangerous = dangerous;
        }

        protected override string GenerateSerialNumber()
        {
            lastNumber++;
            return $"CON-L-{lastNumber}";
        }

        public override void LoadCargo(double cargoWeight, string t)
        {
            if (cargoWeight > maxLoadCapacityKg)
            {
                throw new OverfillException("Cargo weight exceeds container's maximum load capacity.");
            }
            if ((dangerous && cargoWeight > 0.5 * this.maxLoadCapacityKg) ||
    (!dangerous && cargoWeight > 0.9 * this.maxLoadCapacityKg))
            {
                NotifyDangerousSituation(serialNumber);
            }


            cargoWeightKg = cargoWeight;
            Console.WriteLine($"Cargo loaded successfully with a weight of {cargoWeightKg} kg.");
        }

        public void NotifyDangerousSituation(string containerSerialNumber)
        {
            Console.WriteLine($"DANGEROUS situation detected in container {containerSerialNumber}.");
        }

        public override string ToString()
        {
            return $"""
                Serial Number: {serialNumber}
                Dangerous: {dangerous}
                Cargo Weight: {cargoWeightKg} kg
                Height: {heightCm} cm
                Own Weight: {ownWeightKg} kg
                Depth: {depthCm} cm
                Max Load Capacity: {maxLoadCapacityKg} kg

                """;
        }
    }
}
