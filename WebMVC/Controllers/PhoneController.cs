using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class PhoneController : Controller
    {
        // GET: Phone
        public ActionResult Index()
        {
            IEnumerable<mvcPhoneModel> phoList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Phone").Result;
            phoList = response.Content.ReadAsAsync<IEnumerable<mvcPhoneModel>>().Result;

            return View(phoList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new mvcPhoneModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Phone/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcPhoneModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcPhoneModel emp)
        {
            if (emp.ID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Phone", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Phone/" + emp.ID, emp).Result;
                TempData["SuccessMessage"] = "Update Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Phone/" +id.ToString()).Result;
            TempData["SuccessMessage"] = "Delete Successfully";
            return RedirectToAction("Index");
        }
    }
}