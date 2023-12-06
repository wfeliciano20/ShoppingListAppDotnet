using ShoppingListApp.Dtos;
using ShoppingListApp.Models;
namespace ShoppingListApp.Data.Repositories
{
    public interface IShoppingListRepository
    {

        Task<ServiceResponse<List<Item>>> GetAllItemsList();

        Task<ServiceResponse<Item>> GetItemById(int id);

        Task<ServiceResponse<Item>> AddItem(AddItemDto itemDto);

        Task<ServiceResponse<Item>> DeleteItem(int id);

        Task<ServiceResponse<Item>> UpdateItem(int id, UpdateItemDto itemDto);
    }
}

