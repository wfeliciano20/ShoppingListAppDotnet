namespace ShoppingListApp.Dtos
{
    public class UpdateItemDto
    {
        public int Id { get; set; }
        public string ItemName { get; set; } = string.Empty;

        public bool IsPickedUp { get; set; } = false;

        public int ItemQuantity { get; set; } = 1;
    }
}
