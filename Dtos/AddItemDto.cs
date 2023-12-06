namespace ShoppingListApp.Dtos
{
    public class AddItemDto
    {

        public string ItemName { get; set; } = string.Empty;

        public bool IsPickedUp { get; set; } = false;

        public int ItemQuantity { get; set; } = 1;
    }
}