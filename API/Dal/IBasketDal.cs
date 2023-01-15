using API.Models;
using System.Collections.Generic;

namespace API.Dal
{
    public interface IBasketDal
    {
        void AddToBasket(string ProductId, int Quantity);
        void UpdateQuantity(string BasketId, int Quantity);
        void DeleteBasket(string BasketId);
        Basket GetSingle(string BasketId);
        List<Basket> GetAll();

    }
}