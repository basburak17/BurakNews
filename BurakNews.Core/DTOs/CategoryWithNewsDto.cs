namespace BurakNews.Core.DTOs
{
    public class CategoryWithNewsDto : CategoryDto
    {
        public List<NewDto> News { get; set; }
    }
}
