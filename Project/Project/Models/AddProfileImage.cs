using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class AddProfileImage
    {
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string UserAbout { get; set; }

        public IFormFile UserImage { get; set; }

        public string UserMail { get; set; }

        public string UserPassword { get; set; }

        public bool UserStatus { get; set; }
    }
}