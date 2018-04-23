using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using MVCxGridViewDataBinding.Models;

namespace Q588216.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public List<MyModel> Data {

            get {
                return Session["data"] as List<MyModel> == null ? (List<MyModel>)(Session["data"] = MyModel.GetModelList()) : Session["data"] as List<MyModel>;
            }
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            
            
            return PartialView("_GridViewPartial",Data);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialAddNew(MVCxGridViewDataBinding.Models.MyModel item)
        {
            ViewData["Item"] = item;
            var model = MyModel.GetModelList();
            if (ModelState.IsValid)
            {
                try
                {
                    MyModel.InsertModel(Data, item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUpdate(MVCxGridViewDataBinding.Models.MyModel item)
        {
           
            ViewData["Item"] = item;
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                    MyModel.UpdateModel(Data, item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartial", Data);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialDelete(Int32 ModelID)
        {
            if (ModelID >= 0)
            {
                try
                {
                    MyModel.DeleteModel(Data, ModelID);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridViewPartial", Data);
        }
    }
}
