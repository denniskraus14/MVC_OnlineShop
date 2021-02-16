using MVC_OnlineShop.Models; 

namespace MVC_OnlineShop.Model {
    public class CheckOut {
        public bool Paid {get; set;}
        public double getTotal(Cart cart) {
            double total = 0;

            foreach (var p in cart.Products) {
                total += p.Price;
            }

            return total;
        }

        public override string ToString(){
            return "TO DO.. maybe?";
        }
    }
}