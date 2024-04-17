using APBD_4;

Animal animal1 = new Animal("Pikachu", "Pokemon", 100, "yellow");
Animal animal2 = new Animal("Eve", "Pokemon", 80, "Brown");

animal1.EditAnimal(name: "Raichu", weight: 120);
foreach (Animal animal in Animal.GetAnimalList())
{
    Console.WriteLine(animal.ToString());
}
