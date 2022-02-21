using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BoutiqueShop;

namespace DressMVC.Controllers
{
    public class DressController : Controller
    {
        // GET: Dress
        public ActionResult GetDresses()
        {
            var com = new DressComponent();
            var dress = com.GetAllDresses();
            return View(dress);
        }

        public ActionResult AddNewDress()
        {
            var con = new DressComponent();
            return View(new DressClass());
        }
        [HttpPost]
        public ActionResult AddNewDress(DressClass Boutique)
        {
            var con = new DressComponent();
            try
            {
                con.AddNewDress(Boutique);
                return View(new DressClass());
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                ViewBag.ErrorMessage = message;
                return View(new DressClass());
            }
        }

        public ActionResult UpdateDress(string id)
        {
            int movieId = Convert.ToInt32(id);
            var con = new DressComponent();
            try
            {
                var Boutique = con.GetHashCode();
                return View(Boutique);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult UpdateDress(DressClass Boutique)
        {
            
            var con = new DressComponent();
            try
            {
                con.UpdateDress(Boutique);
                return RedirectToAction("GetDresses");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult DeleteDress(string id)
        {
            var con = new DressComponent();
            int movieId = Convert.ToInt32(id);
            try
            {
                con.DeleteDress(movieId);
                return RedirectToAction("GetDresses");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

    }
}