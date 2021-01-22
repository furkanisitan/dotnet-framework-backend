using Shop.Entities.Concrete;

namespace Shop.MVCWebUI.Models
{
    public class UserLoginViewModel
    {
        public User User { get; set; }
        public bool RememberMe { get; set; }
    }
}