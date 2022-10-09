using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProj1.Models;
using Hiding;
using BAL;


namespace MVCProj1.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        Classmethod cs = null;
        public ClassController()
        {
            cs = new Classmethod();
        }
        public List<Classmodel> list1()
        {
            List<Classmodel> c1 = new List<Classmodel>();
            List<classdata> ds = cs.classdatas();
            foreach (var item in ds)
            {
                Classmodel c = new Classmodel();
                c.classId = item.classId;
                c.cname = item.cname;
                c1.Add(c);
            }
            return c1;
        }
        public ActionResult Index()
        {
            List<Classmodel> s1 = list1();
            return View(s1);
        }
        public ActionResult AddClass()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddClass(FormCollection c)
        {
            try
            {
                classdata c1 = new classdata();
                c1.classId = Convert.ToInt32(Request["classId"]);
                c1.cname = Request["cname"].ToString();
                cs.AddClass(c1);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }

        }
        public ActionResult EditDetails(int id)
        {
            List<Classmodel> m = list1();
            Classmodel m2 = m.Find(m3 => m3.classId == id);
            return View(m2);
        }
        [HttpPost]
        public ActionResult EditDetails(int id, FormCollection m3)
        {
            try
            {
                classdata c2 = new classdata();
                c2.classId = Convert.ToInt32(Request["classId"]);
                c2.cname = Request["cname"].ToString();
                cs.updateClass(c2);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public ActionResult Details(int id)
        {
            List<Classmodel> m = list1();
            Classmodel m2 = m.Find(m3 => m3.classId == id);
            return View(m2);

        }
        public ActionResult Delete(int id)
        {
            try
            {
                cs.RemoveClass(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }

        }
    }
}