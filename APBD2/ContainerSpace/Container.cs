namespace ContainerSpace
{
    internal class Container
    {
        private double cargoWeightKg;
        private double heightCm;
        private double ownWeightKg;
        private double depthCm;
        private string serialNumber;
        private double maxLoadCapacityKg;

        private static int lastNumber = 0;

        public Container(double cargoWeightKg, double heightCm, double ownWeightKg, double depthCm, double maxLoadCapacityKg)
        {
            this.cargoWeightKg = cargoWeightKg;
            this.heightCm = heightCm;
            this.ownWeightKg = ownWeightKg;
            this.depthCm = depthCm;
            this.maxLoadCapacityKg = maxLoadCapacityKg;

            this.serialNumber = GenerateSerialNumber();
        }

        private string GenerateSerialNumber()
        {
            lastNumber++;
            return $"CON-C-{lastNumber}";
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