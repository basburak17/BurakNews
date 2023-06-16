namespace BurakNews.Core.DTOs
{
    public class NewDto : BaseDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public string? Photo { get; set; }
        public int CategoryId { get; set; }

    }
}
