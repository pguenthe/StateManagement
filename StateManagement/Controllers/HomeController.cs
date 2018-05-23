using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            HttpCookie cookie = Request.Cookies["Counter"];

            //do they have the cookie called "Counter"?
            if (cookie == null)
            {
                //if no, make one
                cookie = new HttpCookie("Counter");
                cookie.Value = "0";
            }

            //increment--increase the visit count
            int visits;
            bool success = int.TryParse(cookie.Value, out visits);
            if (success)
            {
                visits++;
            }
            else
            {
                visits = 1;
            }

            //storing the info in the cookie
            cookie.Value = visits.ToString();
            cookie.Expires = DateTime.Now.AddDays(14);

            //returning the cookie to the user in the HTTP response
            Response.Cookies.Add(cookie);
            
            return View();
        }

        public ActionResult Contact()
        {
            if(Session["Counter"] == null)
            {
                Session.Add("Counter", 0);
            }
            int visits = (int)Session["Counter"];
            visits++;

            Session["Counter"] = visits;

            return View();
        }

        public ActionResult Logout ()
        {
            Session.Clear();

            return View();
        }
    }
}