using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TritonMVC.Models;

namespace TritonMVC.Controllers
{
    public class WaybillController : Controller
    {
        // GET: Waybill
        public ActionResult Index(string searchString)
        {
            
            ViewData["CurrentFilter"] = searchString;
            IEnumerable<WaybillViewModel> waybillList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("TritonExpressWaybills").Result;
            waybillList = response.Content.ReadAsAsync<IEnumerable<WaybillViewModel>>().Result;

            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                waybillList = waybillList.Where(s => s.RecipientName.ToLower().Contains(searchString)
                                       || s.Address.ToLower().Contains(searchString)
                                       || s.Cell.ToLower().Contains(searchString)
                                       || s.WayBillInfo.ToLower().Contains(searchString)
                                       || s.WayBillweight.ToLower().Contains(searchString)
                                       || s.NumberOfParcels.ToLower().Contains(searchString));
            }

            return View(waybillList);
        }

        public ActionResult AddorEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new WaybillViewModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("TritonExpressWaybills/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<WaybillViewModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddorEdit(WaybillViewModel way)
        {
            if (way.wayBillID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("TritonExpressWaybills", way).Result;
                TempData["SuccessW"] = "Save Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("TritonExpressWaybills/" + way.wayBillID, way).Result;
                TempData["SuccessW"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("TritonExpressWaybills/" + id.ToString()).Result;
            TempData["SuccessW"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}