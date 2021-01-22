using Shop.Entities.Concrete;

namespace Shop.Business.Abstract
{
    public interface IUserService
    {
        User GetByUsernameAndPassword(string username, string password);
        User GetByUsernameAndPasswordWithRoles(string username, string password);
    }
}
