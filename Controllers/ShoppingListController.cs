using Microsoft.AspNetCore.Mvc;
using ShoppingListApp.Data.Repositories;
using ShoppingListApp.Dtos;
using ShoppingListApp.Models;

namespace ShoppingList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListRepository _repository;

        public ShoppingListController(IShoppingListRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Item>>> GetAllItemsList()
        {
            return Ok(await _repository.GetAllItemsList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItemById(int id)
        {
            return Ok(await _repository.GetItemById(id));
        }


        [HttpPost]
        public async Task<ActionResult<Item>> AddItem(AddItemDto itemDto)
        {
            return Ok(await _repository.AddItem(itemDto));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Item>> UpdateItem(int id, UpdateItemDto itemDto)
        {
            return Ok(await _repository.UpdateItem(id, itemDto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Item>> DeleteItem(int id)
        {
            return Ok(await _repository.DeleteItem(id));
        }
    }
}
