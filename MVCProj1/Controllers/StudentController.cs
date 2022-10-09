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
    public class StudentController : Controller
    {
        // GET: Student
        Studentmethod cs = null;
        public StudentController()
        {
            cs = new Studentmethod();
        }
        public List<Studentlist> list1()
        {
            List<Studentlist> c1 = new List<Studentlist>();
            List<Studentdata> ds = cs.studentdatas();
            foreach (var item in ds)
            {
                Studentlist c = new Studentlist();
               c.sid=item.sid;
                c.sname = item.sname;
                c.cid = item.cid;
                c1.Add(c);
            }
            return c1;
        }
        public ActionResult Index()
        {
            List<Studentlist> s1 = list1();
            return View(s1);
        }
        public ActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(FormCollection c)
        {
            try
            {
                Studentdata s1 = new Studentdata();
                s1.sid = Convert.ToInt32(Request["sid"]);
                s1.sname = Request["sname"].ToString();
                s1.cid = Convert.ToInt32(Request["cid"]);
                cs.AddStudent(s1);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }

        }
        public ActionResult EditDetails(int id)
        {
            List<Studentlist> m = list1();
            Studentlist m2 = m.Find(m3 => m3.sid == id);
            return View(m2);
        }
        [HttpPost]
        public ActionResult EditDetails(int id, FormCollection m3)
        {
            try
            {
                Studentdata s1 = new Studentdata();
                s1.sid = Convert.ToInt32(Request["sid"]);
                s1.sname = Request["sname"].ToString();
                s1.cid = Convert.ToInt32(Request["cid"]);
                cs.updateStudent(s1);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public ActionResult Details(int id)
        {
            List<Studentlist> m = list1();
            Studentlist m2 = m.Find(m3 => m3.sid == id);
            return View(m2);

        }
        public ActionResult Delete(int id)
        {
            try
            {
                cs.RemoveStudent(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }

        }
    }
}