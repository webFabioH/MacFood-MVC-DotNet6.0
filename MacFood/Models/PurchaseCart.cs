using MacFood.Context;

namespace MacFood.Models
{
    public class PurchaseCart
    {
        private readonly AppDbContext _context;

        public PurchaseCart(AppDbContext context)
        {
            _context = context;
        }

        public string PurchaseCartId { get; set; }
        public List<PurchaseCartItem> PurchaseCartItem { get; set; }

        public static PurchaseCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new PurchaseCart(context)
            {
                PurchaseCartId = cartId
            };
        }

    }
}
