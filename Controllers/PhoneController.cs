using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using managermentSmartphone.Models;

namespace managermentSmartphone.Controllers
{
    public class PhoneController : Controller
    {
        //
        // GET: /Phone/
        SmartPhoneManagermentEntitiy db = new SmartPhoneManagermentEntitiy();
        public PartialViewResult newphonePartial()
        {
            var listnewPhone = db.SmartPhone.Take(3).ToList();
            return PartialView(listnewPhone);
        }
        //xem chi tết
        public ViewResult viewDetails(int codesmartPhone = 0)
        {
            SmartPhone phone = db.SmartPhone.SingleOrDefault(n=>n.codeSmartphone == codesmartPhone);
            if (phone == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(phone);
        }
	}
}