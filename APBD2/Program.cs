using APBD2.ContainerSpace;
using ContainerSpace;

Container container = new Container(0, 200, 100, 150, 10000);
Container container2 = new ContainerLiquids(0, 200, 100, 150, 10000, true);
Container container3 = new Container(0, 200, 100, 150, 10000);
Console.WriteLine(container);
Console.WriteLine(container2);
Console.WriteLine(container3);
container2.LoadCargo(6000);
Console.WriteLine(container2);


