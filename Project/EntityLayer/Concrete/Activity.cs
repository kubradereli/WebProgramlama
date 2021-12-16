using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Activity
    {
        [Key]
        public int ActivityID { get; set; }

        public string ActivityTitle { get; set; }

        public string ActivityContent { get; set; }

        public string ActivityImage { get; set; }

        public string ActivityCreateDate { get; set; }

        public bool ActivityStatus { get; set; }

        public int CategoryID { get; set; }

        public Category Category { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
