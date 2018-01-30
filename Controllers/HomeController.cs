using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using UserPortalWebApi.Models;
using UserPortalWebApi.Providers;

namespace UserPortalWebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HomeController : ApiController
    {
        public List<User> Get()
        {
            using (var db = new Context())
            {
                return db.Users.ToList();
            }
        }

        [HttpPost]
        public void Add(User user)
        {
            using (var db = new Context())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        [HttpPut]
        //[CustomAuthorize("Admin")]
        //[Authorize]
        public void Update(User user)
        {
            User dbUser;
            using (var db = new Context())
            {
                dbUser = db.Users.SingleOrDefault(x => x.Id == user.Id);
                dbUser.Firstname = user.Firstname;
                dbUser.Lastname = user.Lastname;
                dbUser.Password = user.Password;
                dbUser.Phonenumber = user.Phonenumber;
                dbUser.Email = user.Email;
                db.SaveChanges();
            }
        }
    }
}
