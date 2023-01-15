using API.Models;
using System.Collections.Generic;

namespace API.Services
{
    public interface IBasketService
    {
        void AddToBasket(string productId, int quantity);
        void UpdateQuantity(string basketId, int quantity);
        void DeleteBasket(string basketId);
        Basket GetSingle(string basketId);
        List<BasketDto> GetAll();
    }
}