using API.Dal;
using API.Models;
using System;
using System.Collections.Generic;

namespace API.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketDal _basketDal;
        private IProductDal _productDal;

        public BasketService(IBasketDal basketDal, IProductDal productDal)
        {
            _basketDal = basketDal;
            _productDal = productDal;
        }

        public void AddToBasket(string productId, int quantity)
        {
            _basketDal.AddToBasket(productId, quantity);
        }

        public void DeleteBasket(string basketId)
        {
            _basketDal.DeleteBasket(basketId);
        }

        public List<BasketDto> GetAll()
        {
            var retVal = new List<BasketDto>();

            var baskets = _basketDal.GetAll();
            foreach (var basket in baskets)
            {
                var dto = new BasketDto()
                {
                    Id = basket.Id,
                    ProductId = basket.ProductId,
                    Quantity = basket.Quantity
                };

                dto.ProductName = _productDal.GetAsync(basket.ProductId).GetAwaiter().GetResult().Name;
                // dto.ProductStock = (int)_productDal.GetAsync(basket.ProductId).GetAwaiter().GetResult().Stock;


                retVal.Add(dto);
            }

            return retVal;
        }

        public Basket GetSingle(string basketId)
        {
            var basket = _basketDal.GetSingle(basketId);
            return basket;
        }

        public void UpdateQuantity(string basketId, int quantity)
        {
            _basketDal.UpdateQuantity(basketId, quantity);
        }

    }
}
