
namespace APBD_4
{
    internal class Animal
    {
        private int id;
        private string name;
        private string category;
        private double weight;
        private string furColor;
        private static List<Animal> animals =new List<Animal>();
        private static int lastNumber=1;

        public Animal (string name, string category, double weight, string furColor)
        {
            this.id = lastNumber;
            lastNumber++;

            this.name = name;
            this.category = category;
            this.weight = weight;
            this.furColor = furColor;
            AddToList(this);
        }

        public static List<Animal> GetAnimalList()
        {
            return animals;
        }

        public static Animal GetAnimalById(int id)
        {
            foreach (Animal animal in animals)
            {
                if (animal.id == id)return animal;
            }
            return null;
        }

        public void AddToList(Animal animal)
        {
            animals.Add(animal);
        }
        public void EditAnimal(string? name = null, string? category = null, double? weight = null, string? furColor = null)
        {
            this.name = name ?? this.name;
            this.category = category ?? this.category;
            this.weight = weight ?? this.weight;
            this.furColor = furColor ?? this.furColor;
        }
        public void DeleteAnimal()
        {
            if (animals.Contains(this))
            {
                animals.Remove(this);
            }
        }

        public override string ToString()
        {
            return $"{this.name} {this.category} {this.weight} {this.furColor}";
        }
    }
}
