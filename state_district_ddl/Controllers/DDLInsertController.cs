using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using state_district_ddl.Models;

namespace state_district_ddl.Controllers
{
    public class DDLInsertController : Controller
    {
        MVCASPEntities ob = new MVCASPEntities();
        StateDistrictDB ddlcls = new StateDistrictDB();
        // GET: DDLInsert
        public ActionResult Insertddl_pageload()
        {
            //database to dropdowmlist
            List<stclass> stList = ddlcls.Selectstates();
            ViewBag.selstates = new SelectList(stList, "sId", "sName");
            return View();
        }
        //GET DISTRICTS BY STATE ID AS A JSON FILE
        public JsonResult GetDistricts(int stateId)
        {
            var districts = GetDistrictsByStateId(stateId);
            return Json(districts, JsonRequestBehavior.AllowGet);
        }
        //GET DISTRICTS BY STATE ID
        private List<SelectListItem> GetDistrictsByStateId(int stateId)
        {
            var getdistricts = ddlcls.selectdistricts(stateId);
            var districtsbystate = getdistricts.Select(b => new SelectListItem() { Value = b.DId.ToString(), Text = b.DName }).ToList();
            return districtsbystate;
        }
        public ActionResult Insert_Click(DDLCls clsobj, FormCollection form)
        {
            if (ModelState.IsValid) {
                List<stclass> stList = ddlcls.Selectstates();
                int selectedid = Convert.ToInt32(form["sId"]);
                stclass selecteditem = stList.FirstOrDefault(c => c.sId == selectedid);
                clsobj.sId = selecteditem.sId;//set
                clsobj.sName = selecteditem.sName;//set
                ViewBag.selstates = new SelectList(stList, "sId", "sName");


                int disId = Convert.ToInt32(form["DistrictId"]);
                clsobj.DId = disId;


                ob.sp_DDL_Tab(clsobj.sId, clsobj.DId, clsobj.Name, clsobj.Age);
                clsobj.msg = "successfully";
                return View("Insertddl_pageload", clsobj);
            }
            else
            {
                List<stclass> stList = ddlcls.Selectstates();
                ViewBag.selstates = new SelectList(stList, "sId", "sName");
                return View("Insertddl_pageload", clsobj);
            } 
        }      
    }
}
    
 
