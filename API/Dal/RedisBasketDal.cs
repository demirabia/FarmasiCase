using API.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace API.Dal
{
    public class RedisBasketDal : IBasketDal
    {
        private readonly IConnectionMultiplexer _redis;

        public RedisBasketDal(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }
        // MongoDb'den çekilen ürünün Redis'e bağlı olan sepetimize gönderilmesini içeren kodlar
        public void AddToBasket(string productId, int quantity)
        {
            var newBasket = new Basket()
            {
                ProductId = productId,
                Quantity = quantity
            };
            var db = _redis.GetDatabase();
            var serialBasket = JsonSerializer.Serialize(newBasket);
            db.HashSet("hashbasket", new HashEntry[] { new HashEntry(newBasket.Id, serialBasket) });
        }
        public Basket GetSingle(string BasketId)
        {
            var db = _redis.GetDatabase();
            var basket = db.HashGet("hashbasket", BasketId);

            if (!string.IsNullOrEmpty(basket))
            {
                return JsonSerializer.Deserialize<Basket>(basket);
            }
            return null;
        }
        public void DeleteBasket(string BasketId)
        {
            var db = _redis.GetDatabase();
            db.HashDelete("hashbasket", BasketId);
        }
        public List<Basket> GetAll()
        {
            var db = _redis.GetDatabase();
            var completeSet = db.HashGetAll("hashbasket");

            if (completeSet.Length > 0)
            {
                var obj = Array.ConvertAll(completeSet, val => JsonSerializer.Deserialize<Basket>(val.Value)).ToList();
                return obj;
            }
            return null;
        }
        public void UpdateQuantity(string basketId, int quantity)
        {
            var basket = GetSingle(basketId);
            if (basket == null) return;
            basket.Quantity = quantity;
            var db = _redis.GetDatabase();
            var serialBasket = JsonSerializer.Serialize(basket);
            db.HashSet("hashbasket", new HashEntry[] { new HashEntry(basket.Id, serialBasket) });
        }
        
    }
}