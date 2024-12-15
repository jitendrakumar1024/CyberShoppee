using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberShoppeeDataAccessLayer.Entity;

namespace CyberShoppeeApi.CyberShoppeeRepository.ShoppingCartsRepository
{
    public interface IShoppingCartRepository
    {
        IEnumerable<CartItemDto> GetCartItems(string cartId);
        void AddToCart(string cartId, int productId, int quantity);
        void UpdateCart(string cartId, int productId, int quantity);
        void RemoveFromCart(string cartId, int productId);
        decimal GetCartTotal(string cartId);
        void ClearCart(string cartId);
    }

}
