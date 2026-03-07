namespace item_api.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public bool IsDeleted { get; set; } = false;
    }
}
