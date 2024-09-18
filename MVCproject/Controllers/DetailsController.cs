using DataAccessLayer;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCproject.Controllers
{
    public class DetailsController : Controller
    {
        IDetailsRepository con = null;
        public DetailsController(IDetailsRepository regis)
        {
            con= regis;
        }
        // GET: DetailsController
        public ActionResult List()
        {
            var result = con.showallname();
            return View("List", result);
        }

        // GET: DetailsController/Details/5
        public ActionResult Details(string name)
        {
            var edit = con.showDetailsbyName(name);
            return View("Details",edit);
        }

        // GET: DetailsController/Create
        public ActionResult Create()
        {
            return View("Add",new Details());
        }

        // POST: DetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Details reg)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var result = con.showDetailsbyName(reg.Name);

                    if (result != null)
                    {
                        ModelState.AddModelError("", "Username Already Exists");
                        return View("Add", reg);
                    }


                    con.InsertDetails(reg);
                    return RedirectToAction(nameof(List));
                }
                else
                {
                    return View("Add", reg);
                }

                con.InsertDetails(reg);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        // GET: DetailsController/Edit/5
        public ActionResult Edit(string name)
        {
            var Edit = con.showDetailsbyName(name);
            return View("Edit", Edit);
        }

        // POST: DetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Details reg)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = con.showDetailsbyName(reg.Name);
                    if (result != null)
                    {
                        ModelState.AddModelError("", "Username Already Exists");
                        return View("Add", reg);
                    }
                    con.UpdateDetatils(reg);
                    return RedirectToAction(nameof(List));
                }


                else
                {
                    return View("Edit", reg);
                }
            }


            catch
            {
                return View();
            }
        }

        // GET: DetailsController/Delete/5
        public ActionResult Delete(string name)
        {
            var Details = con.showDetailsbyName(name);
            return View("ConfirmDelete", Details);
        }

        // POST: DetailsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int DoctorDetailsID)
        {
            try
            {
                con.DeleteTable(DoctorDetailsID);
                return RedirectToAction(nameof(List));
            }
            catch
            {
               
            }
            return View();
        }
    }
}
