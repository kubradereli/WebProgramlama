using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ActivityRepository : IActivityDal
    {
        public void AddActivity(Activity activity)
        {
            using var c = new Context();
            c.Add(activity);
            c.SaveChanges();
        }

        public void Delete(Activity t)
        {
            throw new NotImplementedException();
        }

        public void DeleteActivity(Activity activity)
        {
            using var c = new Context();
            c.Remove(activity);
            c.SaveChanges();
        }

        public Activity GetById(int id)
        {
            using var c = new Context();
            return c.Activities.Find(id);
        }

        public Activity GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Activity> GetListAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Activity t)
        {
            throw new NotImplementedException();
        }

        public List<Activity> ListAllActivity()
        {
            using var c = new Context();
            return c.Activities.ToList();
        }

        public void Update(Activity t)
        {
            throw new NotImplementedException();
        }

        public void UpdateActivity(Activity activity)
        {
            using var c = new Context();
            c.Update(activity);
            c.SaveChanges();
        }
    }
}
