using EfPractice.Repositories;

namespace EfPractice.Entities
{
    public class Card : IEntity
    {
        public long Id { get; set; }

        public string Number { get; set; }

        public string Name { get; set; }

        public Account Account { get; set; }
    }
}