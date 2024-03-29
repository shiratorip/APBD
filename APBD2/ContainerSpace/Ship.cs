using ContainerSpace;
using System.Runtime.CompilerServices;

namespace APBD2.ContainerSpace
{
    internal class Ship
    {
        protected double maxSpeed;
        protected int maxNumberOfContainers;
        protected double maxWeightToTransport;
        protected double totalCurrentWeight;
        protected string shipID;
        protected List<Container> containerList = new List<Container>();


        protected static int lastNumber = 0;

        //TODO transport from one ship to another, change one container with another
        public Ship(double maxSpeed, int maxNumberOfContainers, double maxWeightToTransport)
        {
            this.maxSpeed = maxSpeed;
            this.maxNumberOfContainers = maxNumberOfContainers;
            this.maxWeightToTransport = maxWeightToTransport;
            this.shipID = GenerateShipID();
        }

        protected string GenerateShipID()
        {
            lastNumber++;
            return $"Ship-{lastNumber}";
        }

        public void LoadContainer(params Container[] containers)
        {
            int totalContainers = containers.Length;
            double totalWeightToAdd = 0;

            foreach (Container container in containers)
            {
                totalWeightToAdd += container.getTotalWeight();
            }

            if (this.containerList.Count + totalContainers > this.maxNumberOfContainers || totalCurrentWeight + totalWeightToAdd > maxWeightToTransport)
            {
                Console.WriteLine($"No space on the ship. Containers weren't loaded on the ship.");
                return;
            }

            foreach (Container container in containers)
            {
                
                this.containerList.Add(container);
                container.RemoveContainerFromStation();
                totalCurrentWeight += container.getTotalWeight();
            }
        } 
        public void UnloadContainerFromShip(Container container)
        {
            containerList.Remove(container);
            container.AddContainerOnStation();
            totalCurrentWeight-= container.getTotalWeight();
        }
        public void TransportToAnotherShip(Ship ship, Container container)
        {
            if (!this.containerList.Contains(container))
            {
                Console.WriteLine($"There is no {container.getSerialNumber} on this ship {this.shipID}");
                return;
            }
            ship.LoadContainer(container);
            if (!ship.containerList.Contains(container)) return;
            this.containerList.Remove(container);
        }
        public override string ToString()
        {
            string shipString = $"""
                {shipID}
                Max amount of Containers: {maxNumberOfContainers}
                Amount of Containers loaded: {containerList.Count}
                    Containers loaded:

                """;
            foreach (Container container in containerList)
            {
                shipID += container;
            }
            shipString += $"""
                Max weight: {maxWeightToTransport}
                Total weight on board: {totalCurrentWeight}
                """;
            return shipString;
        }
    }
}
