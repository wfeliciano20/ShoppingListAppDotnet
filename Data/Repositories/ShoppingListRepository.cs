using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Dtos;
using ShoppingListApp.Models;


namespace ShoppingListApp.Data.Repositories
{
    public class ShoppingListRepository : IShoppingListRepository
    {
        private readonly DataContext _dbContext;

        public ShoppingListRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public object ItemName { get; private set; }

        public async Task<ServiceResponse<Item>> AddItem(AddItemDto itemDto)
        {
            ServiceResponse<Item> response = new ServiceResponse<Item>();
            if (await _dbContext.Items.AnyAsync(i => i.ItemName.Equals(itemDto.ItemName)))
            {
                response.Success = false;
                response.Message = "Item is Already on the List.";
                response.ResponseCode = System.Net.HttpStatusCode.BadRequest;
                return response;
            }
            Item itemToSave = new Item { IsPickedUp = false, ItemName = itemDto.ItemName, ItemQuantity = itemDto.ItemQuantity };
            _dbContext.Items.Add(itemToSave);
            await _dbContext.SaveChangesAsync();
            response.Data = itemToSave;
            return response;
        }

        public async Task<ServiceResponse<Item>> DeleteItem(int id)
        {
            ServiceResponse<Item> response = new ServiceResponse<Item>();
            if (await _dbContext.Items.AnyAsync(i => i.Id == id))
            {
                var itemToDelete = await _dbContext.Items.FirstOrDefaultAsync(i => i.Id == id);
                _dbContext.Items.Remove(itemToDelete);
                await _dbContext.SaveChangesAsync();
                response.Data = itemToDelete;
                return response;
            }
            response.Success = false;
            response.Message = "Item is Not on the List";
            response.ResponseCode = System.Net.HttpStatusCode.NotFound;
            return response;
        }

        public async Task<ServiceResponse<List<Item>>> GetAllItemsList()
        {
            ServiceResponse<List<Item>> response = new ServiceResponse<List<Item>>();
            var items = await _dbContext.Items.ToListAsync();
            response.Data = items;
            return response;
        }

        public async Task<ServiceResponse<Item>> GetItemById(int id)
        {
            ServiceResponse<Item> response = new ServiceResponse<Item>();
            var dbItem = await _dbContext.Items.FirstOrDefaultAsync(item => item.Id == id);
            if (dbItem != null)
            {
                response.Data = dbItem;
                return response;
            }
            response.Success = false;
            response.Message = "Item Not on the List";
            response.ResponseCode = System.Net.HttpStatusCode.NotFound;
            return response;
        }

        public async Task<ServiceResponse<Item>> UpdateItem(int id, UpdateItemDto itemDto)
        {
            ServiceResponse<Item> response = new ServiceResponse<Item>();
            var itemToUpdate = await _dbContext.Items.FirstOrDefaultAsync(i => i.Id == id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Id = itemDto.Id;
                itemToUpdate.ItemName = itemDto.ItemName;
                itemToUpdate.IsPickedUp = itemDto.IsPickedUp;
                itemToUpdate.ItemQuantity = itemDto.ItemQuantity;
                await _dbContext.SaveChangesAsync();
                response.Data = itemToUpdate;
                return response;
            }
            response.Success = false;
            response.Message = "Item not on the List.";
            response.ResponseCode = System.Net.HttpStatusCode.NotFound;
            return response;
        }
    }
}
