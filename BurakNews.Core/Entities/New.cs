namespace BurakNews.Core.Entities
{
    public class New : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public string? Photo { get; set; }

        public int CategoryId { get; set; }

        // Relational Prop

        public Category Category { get; set; } // Bir haberin bir kategorisi olacaktır.

    }
}
