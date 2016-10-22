using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using managermentSmartphone.Models;

namespace managermentSmartphone.Controllers
{
    public class ManufacturerController : Controller
    {
        //
        // GET: /Manufacturer/
        SmartPhoneManagermentEntitiy db = new SmartPhoneManagermentEntitiy();
        public PartialViewResult manufacturerPartial()
        {
            return PartialView(db.manufacturer.Take(5).OrderBy(n=>n.namemanufacturer).ToList());
        }
        //hiển thị diện thoại theo nhà sản xuát
        public ViewResult phoneinManufacturer(int codemanufacturer = 0)
        {
            manufacturer xb = db.manufacturer.SingleOrDefault(x =>x.codemanufacturer == codemanufacturer);
            if (xb == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //truy xuất danh sách phone theo nhà sản xuất
            List<SmartPhone> SmPhone = db.SmartPhone.Where(t => t.codemanufacturer == codemanufacturer).OrderBy(p => p.price).ToList();
            if (SmPhone.Count == 0)
            {
                ViewBag.Phone = "we are sorry! it Supject not defauld";
            }
            return View(SmPhone);
        }
        //truy xuất danh sách nhà sản xuất
        public ViewResult Listofmanufacturers()
        {
            return View(db.manufacturer.ToList());
        }
	}
}