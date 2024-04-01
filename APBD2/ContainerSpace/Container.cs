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
        protected string place;

        protected static int lastNumber = 0;
        protected static List<Container> containerOnStationList = new List<Container>();
        protected static List<Container> allContainers = new List<Container>();

        public Container(double cargoWeightKg, double heightCm, double ownWeightKg, double depthCm, double maxLoadCapacityKg)
        {
            this.cargoWeightKg = cargoWeightKg;
            this.heightCm = heightCm;
            this.ownWeightKg = ownWeightKg;
            this.depthCm = depthCm;
            this.maxLoadCapacityKg = maxLoadCapacityKg;
            this.place = "";

            this.serialNumber = GenerateSerialNumber();
            this.AddContainerOnStation();
            allContainers.Add(this);
        }

        protected virtual string GenerateSerialNumber()
        {
            lastNumber++;
            return $"CON-DEFAULT-{lastNumber}";
        }
        public Container GetContainerFromStation(string serialNumber)
        {
            return containerOnStationList.Find(container => container.serialNumber == serialNumber);   
        }
        public void AddContainerOnStation()
        {
            containerOnStationList.Add(this);
        }
        public void RemoveContainerFromStation()
        {
            containerOnStationList.Remove(this);
        }
        public static bool CheckIfContainerOnStation(Container container)
        {
            return containerOnStationList.Contains(container);
        }
        public static Container SearchBySerialNumber(string serialNumber)
        {
            foreach (Container container in allContainers)
            {
                if (container.serialNumber == serialNumber)
                {
                    return container;
                }
            }
            return null;
        }
        public bool IsOnStation()
        {
            return containerOnStationList.Contains(this);
        }
        public virtual void UnloadCargo()
        {
            cargoWeightKg = 0;
            Console.WriteLine("Cargo unloaded successfully.");
        }

        public virtual void LoadCargo(double cargoWeight, string productType = "default-1")
        {
            if (cargoWeight > maxLoadCapacityKg)
            {
                throw new OverfillException("Cargo weight exceeds container's maximum load capacity.");
            }

            cargoWeightKg = cargoWeight;
            Console.WriteLine($"Cargo loaded successfully with a weight of {cargoWeightKg} kg.");
        }

        public string GetSerialNumber()
        {
            return this.serialNumber;
        }
        internal double GetTotalWeight()
        {
            return cargoWeightKg + ownWeightKg;
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