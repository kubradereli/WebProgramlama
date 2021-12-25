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
        IUserDal _userDal;

        public UserManager(IUserDal usereDal)
        {
            _userDal = usereDal;
        }

        public User GetById(int id)
        {
            return _userDal.GetByID(id);
        }

        public List<User> GetList()
        {
            throw new NotImplementedException();
        }

        public List<User> GetUserById(int id)
        {
            return _userDal.GetListAll(x => x.UserID == id);
        }

        public void TAdd(User t)
        {
            _userDal.Insert(t);
        }

        public void TDelete(User t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(User t)
        {
            _userDal.Update(t);
        }
    }
}