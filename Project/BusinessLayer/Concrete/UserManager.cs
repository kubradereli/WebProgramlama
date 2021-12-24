using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _usereDal;

        public UserManager(IUserDal usereDal)
        {
            _usereDal = usereDal;
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetList()
        {
            throw new NotImplementedException();
        }

        public List<User> GetUserById(int id)
        {
            return _usereDal.GetListAll(x => x.UserID == id);
        }

        public void TAdd(User t)
        {
            _usereDal.Insert(t);
        }

        public void TDelete(User t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(User t)
        {
            throw new NotImplementedException();
        }
    }
}
