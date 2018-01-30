using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserPortalWebApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
    }
}