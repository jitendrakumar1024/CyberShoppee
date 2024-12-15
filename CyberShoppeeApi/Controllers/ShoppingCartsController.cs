using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CyberShoppeeApi.CyberShoppeeRepository.ProductsRepository;
using CyberShoppeeApi.CyberShoppeeRepository.ShoppingCartsRepository;

namespace CyberShoppeeApi.Controllers
{
    [RoutePrefix("api/shoppingcart")]
    public class ShoppingCartController : ApiController
    {
            private readonly IShoppingCartRepository _shoppingCartRepository;
            private readonly IProductRepository _productRepository = new ProductRepository();

            public ShoppingCartController(IShoppingCartRepository shoppingCartRepository)
            {
                _shoppingCartRepository = shoppingCartRepository;
            }

            // GET: api/shoppingcart/{cartId}
            [HttpGet]
            [Route("{cartId}")]
            public IHttpActionResult GetCartItems(string cartId)
            {
                try
                {
                    var cartItems = _shoppingCartRepository.GetCartItems(cartId);
                    return Ok(cartItems);
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }

            // POST: api/shoppingcart/add
            [HttpPost]
            [Route("add")]
            public IHttpActionResult AddToCart([FromBody] AddToCartDto dto)
            {
                if (dto == null || dto.Quantity <= 0)
                    return BadRequest("Invalid product or quantity.");

                try
                {
                    var product = _productRepository.getProductByCategoriesName(dto.ProductId);
                    if (product == null)
                        return NotFound();

                    _shoppingCartRepository.AddToCart(dto.CartId, dto.ProductId, dto.Quantity);
                    return Ok("Product added to cart successfully.");
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }

            // PUT: api/shoppingcart/update
            [HttpPut]
            [Route("update")]
            public IHttpActionResult UpdateCart([FromBody] UpdateCartDto dto)
            {
                if (dto == null || dto.Quantity < 0)
                    return BadRequest("Invalid product or quantity.");

                try
                {
                    _shoppingCartRepository.UpdateCart(dto.CartId, dto.ProductId, dto.Quantity);
                    return Ok("Cart updated successfully.");
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }

            // DELETE: api/shoppingcart/remove
            [HttpDelete]
            [Route("remove")]
            public IHttpActionResult RemoveFromCart([FromUri] string cartId, [FromUri] int productId)
            {
                if (string.IsNullOrWhiteSpace(cartId) || productId <= 0)
                    return BadRequest("Invalid cart or product ID.");

                try
                {
                    _shoppingCartRepository.RemoveFromCart(cartId, productId);
                    return Ok("Product removed from cart successfully.");
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }

            // GET: api/shoppingcart/total/{cartId}
            [HttpGet]
            [Route("total/{cartId}")]
            public IHttpActionResult GetCartTotal(string cartId)
            {
                try
                {
                    var total = _shoppingCartRepository.GetCartTotal(cartId);
                    return Ok(new { TotalAmount = total });
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }

            // POST: api/shoppingcart/checkout
            [HttpPost]
            [Route("checkout")]
            public IHttpActionResult Checkout([FromBody] CheckoutDto dto)
            {
                if (string.IsNullOrWhiteSpace(dto.CartId))
                    return BadRequest("Invalid cart ID.");

                try
                {
                    var total = _shoppingCartRepository.GetCartTotal(dto.CartId);

                    if (total <= 0)
                        return BadRequest("Cart is empty or invalid.");

                    // Logic for placing an order goes here.
                    _shoppingCartRepository.ClearCart(dto.CartId);
                    return Ok("Checkout successful. Order placed.");
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }
        }

        // DTO classes
        public class AddToCartDto
        {
            public string CartId { get; set; }
            public int ProductId { get; set; }
            public int Quantity { get; set; }
        }

        public class UpdateCartDto
        {
            public string CartId { get; set; }
            public int ProductId { get; set; }
            public int Quantity { get; set; }
        }

        public class CheckoutDto
        {
            public string CartId { get; set; }
        }

}
