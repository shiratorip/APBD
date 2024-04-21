namespace SampleAPI.Models;

public class Animal
{
    public int id { get; set; }
    public string name { get; set; }
    public string category { get; set; }
    public double weight { get; set; }
    public string furColor { get; set; }
    public static List<Animal> Animals = new List<Animal>();

    public Animal()
    {
        Animals.Add(this);
    }

    public static Animal GetAnimal(int id)
    {
        return Animals.FirstOrDefault(animal => animal.id == id);
        
    }
}