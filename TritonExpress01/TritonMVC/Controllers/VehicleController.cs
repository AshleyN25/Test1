using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TritonMVC.Models;

namespace TritonMVC.Controllers
{
    public class VehicleController : Controller
    {
        // GET: Vehicle
        public ActionResult Index(string searchString)
        {
            
            ViewData["CurrentFilter"] = searchString;
            IEnumerable<VehicleViewModel> vehicleList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("TritonExpressVehicles").Result;
            vehicleList = response.Content.ReadAsAsync<IEnumerable<VehicleViewModel>>().Result;

            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                vehicleList = vehicleList.Where(s => s.vehiclemake.ToLower().Contains(searchString)
                                       || s.vehiclemodel.ToLower().Contains(searchString)
                                       || s.vehiclereg.ToLower().Contains(searchString)
                                       || Convert.ToString(s.vehicleyear).Contains(searchString)
                                       || Convert.ToString(s.wayBillID).Contains(searchString)
                                       || s.branch.ToLower().Contains(searchString));
            }

            return View(vehicleList);
        }

        public ActionResult AddorEdit(int id = 0)
        {
            List<WaybillViewModel> tritonwaybillList = new List<WaybillViewModel>();
            HttpResponseMessage waybillresponse = GlobalVariables.WebApiClient.GetAsync("TritonExpressWaybills").Result;
            tritonwaybillList = waybillresponse.Content.ReadAsAsync<List<WaybillViewModel>>().Result;
            ViewBag.ListOfWaybill = tritonwaybillList;

            if (id == 0)
            {
                return View(new VehicleViewModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("TritonExpressVehicles/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<VehicleViewModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddorEdit(VehicleViewModel veh)
        {
            if (veh.ID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("TritonExpressVehicles", veh).Result;
                TempData["SuccessV"] = "Save Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("TritonExpressVehicles/" + veh.ID, veh).Result;
                TempData["SuccessV"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("TritonExpressVehicles/" + id.ToString()).Result;
            TempData["SuccessV"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}