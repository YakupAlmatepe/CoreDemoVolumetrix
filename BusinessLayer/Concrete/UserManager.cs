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

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<User> GetAllTs()
        {
            return _userDal.GetListAll();
        }

        public User GetTById(int id)
        {
            return _userDal.GetByID(id);
        }

        public List<User> GetUserByID(int id)
        {
            throw new NotImplementedException();//yeniden yazılacak
        }

        public void TAdd(User t)
        {
            _userDal.Insert(t);
        }

        public void TDelete(User t)
        {
            _userDal.Delete(t);
        }

        public void TUpdate(User t)
        {
            _userDal.Update(t);
        }
    }
}
