
using ContainerSpace;

namespace APBD2.ContainerSpace
{
    internal class ContainerCold : Container
    {
        protected static Dictionary<string, double> productDictionary = new Dictionary<string, double>();
        protected string typeOfProduct;
        protected double temperature;

        public ContainerCold(double cargoWeightKg, double heightCm, double ownWeightKg, double depthCm, double maxLoadCapacityKg, string typeOfProduct, double temperature) : base(cargoWeightKg, heightCm, ownWeightKg, depthCm, maxLoadCapacityKg)
        {
            this.typeOfProduct = typeOfProduct;
            this.temperature = temperature;
        }

        protected override string GenerateSerialNumber()
        {
            lastNumber++;
            return $"CON-C-{lastNumber}";
        }

        public static void AddProductToDictionary(string typeOfProduct, double minTemperature)
        {
            productDictionary[typeOfProduct] = minTemperature;
        }
        
        public override void LoadCargo(double cargoWeight, string typeOfProduct="default-1")
        {   
            if (typeOfProduct.Equals("default-1"))typeOfProduct = this.typeOfProduct;
            
            if (cargoWeight > maxLoadCapacityKg)
            {
                throw new OverfillException("Cargo weight exceeds container's maximum load capacity.");
            }

            if (!productDictionary.ContainsKey(typeOfProduct) || !this.typeOfProduct.Equals(typeOfProduct))
            {
                Console.WriteLine("Container wasn't loaded. Check product type or product Dictionary.");
                return;
            }
            if (this.cargoWeightKg == 0 && !this.typeOfProduct.Equals(typeOfProduct))
            {
                this.typeOfProduct = typeOfProduct;
            }
            if (temperature < productDictionary[typeOfProduct])
            {
                Console.WriteLine("Container wasn't loaded. Temperature is too low.");
                return;
            }


            cargoWeightKg = cargoWeight;
            Console.WriteLine($"Cargo loaded successfully with a weight of {cargoWeightKg} kg.");
        }

        public void ChangeTemperature(double temperature)
        {
            this.temperature= temperature;
            Console.WriteLine($"Temperature has been chagend in container: {serialNumber} to {temperature} degrees");
        }
    }
}
