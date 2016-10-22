using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using managermentSmartphone.Models;

namespace managermentSmartphone.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
     SmartPhoneManagermentEntitiy db = new SmartPhoneManagermentEntitiy();
        public ActionResult Index()
        {
            return View(db.SmartPhone.Where(n=>n.news==1).ToList());
        }
	}
}