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
    public class ActivityManager : IActivityService
    {
        IActivityDal _activityDal;

        public ActivityManager(IActivityDal activityDal)
        {
            _activityDal = activityDal;
        }

        public List<Activity> GetActivityListWithCategory()
        {
            return _activityDal.GetListWithCategory();
        }

        public List<Activity> GetListWithCategoryByUserAm(int id)
        {
            return _activityDal.GetListWithCategoryByUser(id);
        }

        public Activity GetById(int id)
        {
            return _activityDal.GetByID(id);
        }

        public List<Activity> GetActivityByID(int id)
        {
            return _activityDal.GetListAll(x => x.ActivityID == id);
        }

        public List<Activity> GetList()
        {
            return _activityDal.GetListAll();
        }

        public List<Activity> GetLast3Activity()
        {
            return _activityDal.GetListAll().Take(3).ToList();
        }

        public List<Activity> GetActivityListByUser(int id)
        {
            return _activityDal.GetListAll(x => x.UserID == id);
        }

        public void TAdd(Activity t)
        {
            _activityDal.Insert(t);
        }

        public void TDelete(Activity t)
        {
            _activityDal.Delete(t);
        }

        public void TUpdate(Activity t)
        {
            _activityDal.Update(t);
        }
    }
}