using APBD2.ContainerSpace;

namespace ContainerSpace
{

    internal class Container
    {
        protected double cargoWeightKg;
        protected double heightCm;
        protected double ownWeightKg;
        protected double depthCm;
        protected string serialNumber;
        protected double maxLoadCapacityKg;

        protected static int lastNumber = 0;

        public Container(double cargoWeightKg, double heightCm, double ownWeightKg, double depthCm, double maxLoadCapacityKg)
        {
            this.cargoWeightKg = cargoWeightKg;
            this.heightCm = heightCm;
            this.ownWeightKg = ownWeightKg;
            this.depthCm = depthCm;
            this.maxLoadCapacityKg = maxLoadCapacityKg;

            this.serialNumber = GenerateSerialNumber();
        }

        protected virtual string GenerateSerialNumber()
        {
            lastNumber++;
            return $"CON-DEFAULT-{lastNumber}";
        }

        public virtual void UnloadCargo()
        {
            cargoWeightKg = 0;
            Console.WriteLine("Cargo unloaded successfully.");
        }

        public virtual void LoadCargo(double cargoWeight)
        {
            if (cargoWeight > maxLoadCapacityKg)
            {
                throw new OverfillException("Cargo weight exceeds container's maximum load capacity.");
            }

            cargoWeightKg = cargoWeight;
            Console.WriteLine($"Cargo loaded successfully with a weight of {cargoWeightKg} kg.");
        }

        public override string ToString()
        {
            return $"""
                Serial Number: {serialNumber}
                Cargo Weight: {cargoWeightKg} kg
                Height: {heightCm} cm
                Own Weight: {ownWeightKg} kg
                Depth: {depthCm} cm
                Max Load Capacity: {maxLoadCapacityKg} kg

                """;
        }
    }
}