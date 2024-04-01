using APBD2.ContainerSpace;
using ContainerSpace;

Container containerLiquidsRegular = new ContainerLiquids(0, 200, 100, 150, 10000, true);
Container containerLiquidsDangerous = new ContainerLiquids(0, 200, 100, 150, 10000, false);
Container containerGas = new ContainerGas(0, 200, 100, 150, 10000, 10);

ContainerCold.AddProductToDictionary("Bananas", 13.3);
ContainerCold.AddProductToDictionary("Chocolate", 18);
Container containerCold = new ContainerCold(0, 200, 100, 150, 1000, "Bananas", 14.3);

Ship ship1 = new Ship(100, 3, 30000);
Ship ship2 = new Ship(100, 3, 30000);

ship1.LoadContainer(containerLiquidsRegular);
ship2.LoadContainer(containerLiquidsDangerous, containerCold);
ship2.LoadContainer(containerLiquidsRegular);
Console.WriteLine(ship1);
Console.WriteLine(ship2);

