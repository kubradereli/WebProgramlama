using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Activity
    {
        public int ActivityID { get; set; }

        public string ActivityTitle { get; set; }

        public string ActivityContent { get; set; }

        public string ActivityImage { get; set; }

        public string ActivityCreateDate { get; set; }

        public bool ActivityStatus { get; set; }
    }
}
