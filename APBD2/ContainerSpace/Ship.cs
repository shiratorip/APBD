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
        if (!container.IsOnStation())
        {
            Console.WriteLine($"Container {container.GetSerialNumber()} cannot be loaded because it's not on the station.");
            totalContainers--;
            continue;
        }
        totalWeightToAdd += container.GetTotalWeight();
    }

    if (this.containerList.Count + totalContainers > this.maxNumberOfContainers || totalCurrentWeight + totalWeightToAdd > maxWeightToTransport)
    {
        Console.WriteLine($"No space on the ship. Some containers weren't loaded on the ship.");
        return;
    }

    foreach (Container container in containers)
    {
        if (!container.IsOnStation())
        {
                    continue;
        }
        this.containerList.Add(container);
        container.RemoveContainerFromStation();
        totalCurrentWeight += container.GetTotalWeight();
    }
} 
        public void UnloadContainerFromShip(Container container)
        {
            containerList.Remove(container);
            container.AddContainerOnStation();
            totalCurrentWeight-= container.GetTotalWeight();
        }
        public void TransportToAnotherShip(Ship ship, Container container)
        {
            if (!this.containerList.Contains(container))
            {
                Console.WriteLine($"There is no {container.GetSerialNumber()} on this ship {this.shipID}");
                return;
            }
            ship.LoadContainer(container);
            if (!ship.containerList.Contains(container)) return;
            this.containerList.Remove(container);
        }
        public void ReplaceContainersBetweenShips(Container container1, Ship ship2, Container container2)
        {
            bool totalWeightCheckFirstShip = this.totalCurrentWeight - container1.GetTotalWeight() + container2.GetTotalWeight() < this.maxWeightToTransport;
            bool totalWeightCheckSecondShip = ship2.totalCurrentWeight - container2.GetTotalWeight() + container1.GetTotalWeight() < ship2.maxWeightToTransport;

            if (totalWeightCheckFirstShip && totalWeightCheckSecondShip)
            {
                this.UnloadContainerFromShip(container1);
                ship2.UnloadContainerFromShip(container2);
                this.LoadContainer(container2);
                ship2.LoadContainer(container1);
            }
            else
            {
                Console.WriteLine("REPLACEMENT didn't work");
            }
        }
        public override string ToString()
        {
            string shipString = $"""
                ______________________
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
                ______________________
                """;
            return shipString;
        }
    }
}
