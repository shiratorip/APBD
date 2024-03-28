using ContainerSpace;
namespace APBD2.ContainerSpace
{
    internal class ContainerGas : Container, HazardNotifier
    {
        protected double pressure;
        public ContainerGas(double cargoWeightKg, double heightCm, double ownWeightKg, double depthCm, double maxLoadCapacityKg, double pressure) : base(cargoWeightKg, heightCm, ownWeightKg, depthCm, maxLoadCapacityKg)
        {
            this.pressure = pressure;
        }

        protected override string GenerateSerialNumber()
        {
            lastNumber++;
            return $"CON-G-{lastNumber}";
        }

        public override void LoadCargo(double cargoWeight)
        {
            if (cargoWeight > maxLoadCapacityKg)
            {
                throw new OverfillException("Cargo weight exceeds container's maximum load capacity.");
            }
           
            NotifyDangerousSituation(serialNumber);

            cargoWeightKg = cargoWeight;
            Console.WriteLine($"Cargo loaded successfully with a weight of {cargoWeightKg} kg.");
        }

        public override void UnloadCargo()
        {
            cargoWeightKg = cargoWeightKg*0.05;
            Console.WriteLine($"Cargo unloaded successfully. Cargo weight is {cargoWeightKg} kg");
        }

        public void NotifyDangerousSituation(string containerSerialNumber)
        {
            Console.WriteLine($"Potentially DANGEROUS situation detected in Gas container {containerSerialNumber}.");
        }

        public override string ToString()
        {
            return $"""
                Serial Number: {serialNumber}
                Pressure: {pressure}
                Cargo Weight: {cargoWeightKg} kg
                Height: {heightCm} cm
                Own Weight: {ownWeightKg} kg
                Depth: {depthCm} cm
                Max Load Capacity: {maxLoadCapacityKg} kg

                """;
        }
    }
}
