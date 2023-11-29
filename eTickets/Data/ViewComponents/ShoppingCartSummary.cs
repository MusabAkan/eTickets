using eTickets.Data.Cart;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Data.ViewComponents
{
    public class ShoppingCartSummary(ShoppingCart shoppingCart) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var items = shoppingCart.GetShoppingCartItems();
            return View(items.Count);
        }
    }
}
