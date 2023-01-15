using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        public ActionResult<List<BasketDto>> GetAll()
        {
            var list = _basketService.GetAll();
            if (list != null)
            {
                return list;
            }

            return NotFound();
        }
        [HttpGet("{basketId}")]
        public ActionResult<Basket> GetSingle(string basketId)
        {
            var basket = _basketService.GetSingle(basketId);
            if (basket != null)
            {
                return basket;
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult AddToBasket(CreateBasketDto basketDto)
        {
            _basketService.AddToBasket(basketDto.ProductId, basketDto.Quantity);

            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateQuantity(UpdateBasketDto updateBasketDto)
        {
            _basketService.UpdateQuantity(updateBasketDto.BasketId, updateBasketDto.Quantity);

            return Ok();
        }

        [HttpDelete("{basketId}")]
        public ActionResult<List<BasketDto>> DeleteBasket(string basketId)
        {
            _basketService.DeleteBasket(basketId);

            return Ok();
        }
    }
}