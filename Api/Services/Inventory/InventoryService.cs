using Api.Services;
using API.DTOs.Items;
using Domain.Interfaces;
using Domain.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Inventory
{
    public class InventoryService : BaseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InventoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// add a item in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<AddItemResponse> AddNewAsync(AddUserRequest model)
        {
            var item = new Item(model.Name
                , model.Description
                , model.ExpirationDate);

            var repository = _unitOfWork.AsyncRepository<Item>();
            await repository.AddAsync(item);
            await UnitOfWork.SaveChangesAsync();

            var response = new AddItemResponse()
            {
                Id = item.Id,
                ItemName = item.Name
            };

            return response;
        }
        /// <summary>
        /// Get the item that you provided
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetItemResponse> SearchAsync(GetItemRequest request)
        {
            var repository = _unitOfWork.AsyncRepository<Item>();
            var item = await repository
                .GetAsync(i => i.Id == request.Id);

            var itemResponse = item != null ? ValidateItem(item) : null;

            if (itemResponse != null && !string.IsNullOrEmpty(itemResponse.ErrorMessage))
            {
               var itemDeleted = await repository.DeleteAsync(item);
               await _unitOfWork.SaveChangesAsync();
            }

            return itemResponse;
        }
        /// <summary>
        /// Get all items in DDBB validated
        /// </summary>
        /// <returns></returns>
        public async Task<List<GetItemResponse>> GetAllItems()
        {
            var repository = _unitOfWork.AsyncRepository<Item>();
            var items = await repository.ListAsync();
            
            return items
                .Select(i =>
                    {
                        return ValidateItem(i);
                    }).ToList();
        }

        /// <summary>
        /// This method validate if the item has date expired and response an object with this message
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private GetItemResponse ValidateItem(Item item) =>
            item.ExpirationDate > DateTime.UtcNow 
                ? new GetItemResponse() 
                    { 
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        ExpirationDate = item.ExpirationDate
                    } 
                : new GetItemResponse()
                    { 
                       ErrorMessage = "El producto ha caducado"
                    };
    }
}