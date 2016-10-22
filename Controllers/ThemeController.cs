using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using managermentSmartphone.Models;

namespace managermentSmartphone.Controllers
{
    public class ThemeController : Controller
    {
        //
        // GET: /Theme/
        SmartPhoneManagermentEntitiy db = new SmartPhoneManagermentEntitiy();
        public ActionResult ThemePartial()
        {
            return PartialView(db.theme.Take(4).ToList());
        }
        //phone theo chủ đề
        public ViewResult Phonesubject(int codeTheme = 0)
        {
            //kiểm tra chủ đề tồn tại hay không
            theme th = db.theme.SingleOrDefault(t => t.codetheme == codeTheme);
            if(th == null)
            {
                Response.StatusCode=404;
                return null;
            }
            //truy xuất danh sách phone thoe chủ đề
            List<SmartPhone> SmPhone = db.SmartPhone.Where(t=>t.codetheme == codeTheme).OrderBy(p=>p.price).ToList();
            if(SmPhone.Count == 0)
            {
                ViewBag.Phone = "we are sorry! it Supject not defauld";
            }
            return View(SmPhone);
        }
        //hiển thị các chủ đề
        public ViewResult Subjectcategory()
        {
            return View(db.theme.ToList());

        }

	}
}