using DayOneAttrRoute.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DayOneAttrRoute.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var userInstance = db.Users.Where(u => u.Id == userId).FirstOrDefault();
            return View(userInstance);
        }
        [Route("User/{username}")]
        public ActionResult Detail(string username)
        {
            var userInstance = db.Users.Where(u => u.UserName == username).FirstOrDefault();
            return View(userInstance);
        }
    }
}