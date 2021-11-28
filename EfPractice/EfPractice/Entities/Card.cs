namespace EfPractice.Entities
{
    public class Card
    {
        public long Id { get; set; }

        public string Number { get; set; }

        public string Name { get; set; }

        public Account Account { get; set; }
    }
}