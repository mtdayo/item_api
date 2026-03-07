using System.ComponentModel.DataAnnotations;

namespace item_api.DTOs
{
    public class CreateItemDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
    }
}
