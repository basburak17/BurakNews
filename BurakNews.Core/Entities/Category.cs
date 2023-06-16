namespace BurakNews.Core.Entities
{
    public class Category : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        // Relational Prop
        public ICollection<New> News { get; set; }
    }
}
