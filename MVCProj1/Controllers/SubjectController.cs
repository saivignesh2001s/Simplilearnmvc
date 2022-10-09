using BAL;
using Hiding;
using MVCProj1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAL;
using Hiding;
using MVCProj1.Models;

namespace MVCProj1.Controllers
{
    public class SubjectController : Controller
    {
        // GET: Subject
        SubjectMethods cs = null;
        public SubjectController()
        {
            cs = new SubjectMethods();
        }
        public List<Subjectmodel> list1()
        {
            List<Subjectmodel> c1 = new List<Subjectmodel>();
            List<Subjectdata> ds = cs.Subjlist();
            foreach (var item in ds)
            {
                Subjectmodel c = new Subjectmodel();
                c.subid = item.subid;
                c.subname = item.subname;
                c.cid = item.cid;
                c1.Add(c);
            }
            return c1;
        }
        public ActionResult Index()
        {
            List<Subjectmodel> s1 = list1();
            return View(s1);
        }
        public ActionResult AddSubject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSubject(FormCollection c)
        {
            try
            {
                Subjectdata s1 = new Subjectdata();
                s1.subid = Convert.ToInt32(Request["subid"]);
                s1.subname = Request["subname"].ToString();
                s1.cid = Convert.ToInt32(Request["cid"]);
                cs.AddSubject(s1);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }

        }
        public ActionResult EditDetails(int id)
        {
            List<Subjectmodel> m = list1();
            Subjectmodel m2 = m.Find(m3 => m3.subid == id);
            return View(m2);
        }
        [HttpPost]
        public ActionResult EditDetails(int id, FormCollection m3)
        {
            try
            {
                Subjectdata s1 = new Subjectdata();
                s1.subid = Convert.ToInt32(Request["subid"]);
                s1.subname = Request["subname"].ToString();
                s1.cid = Convert.ToInt32(Request["cid"]);
                cs.updatesubject(s1);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public ActionResult Details(int id)
        {
            List<Subjectmodel> m = list1();
            Subjectmodel m2 = m.Find(m3 => m3.subid == id);
            return View(m2);

        }
        public ActionResult Delete(int id)
        {
            try
            {
                cs.RemoveSubject(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }

        }
    }
}