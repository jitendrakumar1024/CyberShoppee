using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CyberShoppeeDataAccessLayer.CyberShoppeeContext;
using CyberShoppeeDataAccessLayer.Entity;

namespace CyberShoppeeApi.CyberShoppeeRepository.ShoppingCartsRepository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly CyberShoppeeContext _dbContext = new CyberShoppeeContext();

        public ShoppingCartRepository(CyberShoppeeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CartItemDto> GetCartItems(string cartId)
        {
            return _dbContext.ShoppingCarts
                .Where(c => c.CartId == cartId)
                .Select(c => new CartItemDto
                {
                    ProductId = c.ProductId,
                    ProductName = _dbContext.Products.FirstOrDefault(p => p.ProductId == c.ProductId).ModelName,
                    Model = _dbContext.Products.FirstOrDefault(p => p.ProductId == c.ProductId).ModelNumber,
                    Quantity = c.Quantity,
                    Price = _dbContext.Products.FirstOrDefault(p => p.ProductId == c.ProductId).UnitCost,
                    SubTotal = c.Quantity * _dbContext.Products.FirstOrDefault(p => p.ProductId == c.ProductId).UnitCost
                }).ToList();
        }

        public void AddToCart(string cartId, int productId, int quantity)
        {
            var existingItem = _dbContext.ShoppingCarts.FirstOrDefault(c => c.CartId == cartId && c.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _dbContext.ShoppingCarts.Add(new ShoppingCart
                {
                    CartId = cartId,
                    ProductId = productId,
                    Quantity = quantity,
                    DateCreated = DateTime.UtcNow
                });
            }

            _dbContext.SaveChanges();
        }

        public void UpdateCart(string cartId, int productId, int quantity)
        {
            var cartItem = _dbContext.ShoppingCarts.FirstOrDefault(c => c.CartId == cartId && c.ProductId == productId);

            if (cartItem != null)
            {
                cartItem.Quantity = quantity;

                if (quantity == 0)
                {
                    _dbContext.ShoppingCarts.Remove(cartItem);
                }

                _dbContext.SaveChanges();
            }
        }

        public void RemoveFromCart(string cartId, int productId)
        {
            var cartItem = _dbContext.ShoppingCarts.FirstOrDefault(c => c.CartId == cartId && c.ProductId == productId);

            if (cartItem != null)
            {
                _dbContext.ShoppingCarts.Remove(cartItem);
                _dbContext.SaveChanges();
            }
        }

        public decimal GetCartTotal(string cartId)
        {
            return _dbContext.ShoppingCarts
                .Where(c => c.CartId == cartId)
                .Sum(c => c.Quantity * _dbContext.Products.FirstOrDefault(p => p.ProductId == c.ProductId).UnitCost);
        }

        public void ClearCart(string cartId)
        {
            var cartItems = _dbContext.ShoppingCarts.Where(c => c.CartId == cartId);

            _dbContext.ShoppingCarts.RemoveRange(cartItems);
            _dbContext.SaveChanges();
        }

    }

}