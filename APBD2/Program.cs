using APBD2.ContainerSpace;
using ContainerSpace;

//Stworzenie kontenera danego typu
Container containerLiquidsRegular = new ContainerLiquids(0, 200, 100, 150, 10000, true);
Container containerLiquidsDangerous = new ContainerLiquids(0, 200, 100, 150, 10000, false);
Container containerGas = new ContainerGas(0, 200, 100, 150, 10000, 10);
Container con1 = new ContainerLiquids(0, 200, 100, 150, 10000, true);
Container con2 = new ContainerLiquids(0, 200, 100, 150, 10000, true);

ContainerCold.AddProductToDictionary("Bananas", 13.3);
ContainerCold.AddProductToDictionary("Chocolate", 18);
Container containerCold = new ContainerCold(0, 200, 100, 150, 1000, "Bananas", 14.3);

Ship ship1 = new Ship(100, 4, 30000);
Ship ship2 = new Ship(100, 3, 30000);

//Załadowanie kontenera na statek
ship1.LoadContainer(containerLiquidsRegular);
ship1.LoadContainer(con1);
//Załadowanie listy kontenerów na statek
ship2.LoadContainer(containerLiquidsDangerous, containerCold);
ship2.LoadContainer(containerLiquidsRegular);

//Wypisanie informacji o danym kontenerze
Console.WriteLine(containerLiquidsDangerous);

//Wypisanie informacji o danym statku i jego ładunku
Console.WriteLine(ship1);
Console.WriteLine(ship2);

//Załadowanie ładunku do danego kontenera
containerCold.LoadCargo(900,"Bananas");
//containerGas.LoadCargo(900);

//Usunięcie kontenera ze statku
ship2.UnloadContainerFromShip(containerCold);

//Rozładowanie kontenera
containerCold.UnloadCargo();

//Zastąpienie kontenera na statku o danym numerze innym kontenerem TODO
ship1.ExchangeContainerFromStation("CON-L-4", con2);

//Możliwość przeniesienie kontenera między dwoma statkami
ship1.ReplaceContainersBetweenShips(containerLiquidsDangerous, ship2, containerLiquidsRegular);
