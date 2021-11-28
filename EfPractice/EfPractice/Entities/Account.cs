namespace EfPractice.Entities
{
    public class Account
    {
        public long Id { get; set; }

        public string Number { get; set; }

        public long CardId { get; set; }
        public Card Card { get; set; }
    }
}