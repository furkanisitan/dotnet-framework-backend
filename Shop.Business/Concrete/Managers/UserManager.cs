using Shop.Business.Abstract;
using Shop.DataAccess.Abstract;
using Shop.Entities.Concrete;

namespace Shop.Business.Concrete.Managers
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetByUsernameAndPassword(string username, string password) =>
            _userDal.Get(x => x.Username == username && x.Password == password);

        public User GetByUsernameAndPasswordWithRoles(string username, string password) =>
            _userDal.GetWithRoles(x => x.Username == username && x.Password == password);
    }
}
