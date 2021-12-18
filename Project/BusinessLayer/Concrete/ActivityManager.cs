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

        public void ActivityAdd(Activity activity)
        {
            throw new NotImplementedException();
        }

        public void ActivityDelete(Activity activity)
        {
            throw new NotImplementedException();
        }

        public void ActivityUpdate(Activity activity)
        {
            throw new NotImplementedException();
        }

        public List<Activity> GetActivityListWithCategory()
        {
            return _activityDal.GetListWithCategory();
        }

        public Activity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Activity> GetActivityByID(int id)
        {
            return _activityDal.GetListAll(x => x.ActivityID == id);
        }

        public List<Activity> GetList()
        {
            return _activityDal.GetListAll();
        }
    }
}
