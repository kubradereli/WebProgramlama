using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IActivityService
    {
        void ActivityAdd(Activity activity);

        void ActivityDelete(Activity activity);

        void ActivityUpdate(Activity activity);

        List<Activity> GetList();

        Activity GetById(int id);
    }
}
