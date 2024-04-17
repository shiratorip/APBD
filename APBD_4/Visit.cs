

namespace APBD_4
{
    internal class Visit
    {
        private int id;
        private DateTime date = new DateTime();
        private Animal? animal;
        private string description;
        private int price;
        private static int lastNumber = 1;
        private static List<Visit> visits = new List<Visit>();


        public Visit(DateTime date, Animal animal, string description, int price)
        {
            this.date = date;
            this.animal = animal;
            this.description = description;
            this.price = price;
            this.id = lastNumber;
            lastNumber++;
            visits.Add(this);
        }

        public static List<Visit> GetAnimalVisits(Animal animal)
        {
            List<Visit> newVisitList = new List<Visit>();
            foreach (Visit visit in visits)
            {
                if (visit.animal == animal)
                {
                    newVisitList.Add(visit);
                }
            }
            return newVisitList;
        }
    }  
}
