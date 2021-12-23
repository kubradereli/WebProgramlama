﻿using BusinessLayer.Abstract;
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

        public void UserAdd(User user)
        {
            _usereDal.Insert(user);
        }
    }
}
