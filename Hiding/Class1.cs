using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BAL;
using DAL;
namespace Hiding
{
    public class Classmethod
    {
        public void AddClass(classdata s)
        {
            rainbowschoolsEntities context = new rainbowschoolsEntities();
            Class s1 = new Class();
            s1.ClassID = s.classId;
            s1.ClassName = s.cname;
            context.Classes.Add(s1);
            context.SaveChanges();


        }
        public bool RemoveClass(int id)
        {
            rainbowschoolsEntities context = new rainbowschoolsEntities();
            List<Class> m1 = context.Classes.ToList();
            Class s2 = m1.Find(m => m.ClassID == id);
            if (s2 != null)
            {
                context.Classes.Remove(s2);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public void updateClass(classdata s)
        {
            rainbowschoolsEntities context = new rainbowschoolsEntities();
            List<Class> m1 = context.Classes.ToList();
            Class s2 = m1.Find(m => m.ClassID == s.classId);
            s2.ClassID = s.classId;
            s2.ClassName = s.cname;
            context.SaveChanges();
        }
        public List<classdata> classdatas()
        {
            rainbowschoolsEntities context = new rainbowschoolsEntities();
            List<classdata> s = new List<classdata>();
            List<Class> m1 = context.Classes.ToList();
            foreach (var item in m1)
            {
                s.Add(new classdata
                {
                    classId = item.ClassID,
                    cname = item.ClassName
                });
            }
            return s;
        }

    }
    public class Studentmethod {
        public void AddStudent(Studentdata s){
            rainbowschoolsEntities context = new rainbowschoolsEntities();
            Student s1 = new Student();
            s1.StudentID = s.sid;
            s1.StudentName = s.sname;
            s1.ClassID = s.cid;
            context.Students.Add(s1);
            context.SaveChanges();

            }
        public void RemoveStudent(int id)
        {
            rainbowschoolsEntities context = new rainbowschoolsEntities();
            List<Student> s = context.Students.ToList();
            Student s1 = s.Find(m => m.StudentID == id);
            context.Students.Remove(s1);
            context.SaveChanges();
        }
        public void updateStudent(Studentdata s2)
        {
            rainbowschoolsEntities context = new rainbowschoolsEntities();
            List<Student> s = context.Students.ToList();
            Student s1 = s.Find(m => m.StudentID ==s2.sid);
            s1.StudentID = s2.sid;
            s1.StudentName = s2.sname;
            s1.ClassID = s2.cid;
            context.SaveChanges();
        }
        public List<Studentdata> studentdatas()
        {
            rainbowschoolsEntities context = new rainbowschoolsEntities();
            List<Studentdata> s = new List<Studentdata>();
            List<Student> s1 = context.Students.ToList();
            foreach(var item in s1)
            {
                s.Add(
                    new Studentdata
                    {
                        sid = item.StudentID,
                        sname = item.StudentName,
                        cid = item.ClassID

                    }
                );
            }
            return s;
        }
        }
    public class SubjectMethods
    {
       public void AddSubject(Subjectdata s)
        {
            rainbowschoolsEntities context = new rainbowschoolsEntities();
            Subject s1 = new Subject();
            s1.SubjectID = s.subid;
            s1.SubjectName = s.subname;
            s1.ClassID = s.cid;
            context.Subjects.Add(s1);
            context.SaveChanges();

        }
        public void RemoveSubject(int id)
        {
            rainbowschoolsEntities context = new rainbowschoolsEntities();
            List<Subject> s1 = context.Subjects.ToList();
            Subject s2=s1.Find(m=>m.SubjectID==id);
            context.Subjects.Remove(s2);
            context.SaveChanges();
        }
        public void updatesubject(Subjectdata s)
        {
            rainbowschoolsEntities context = new rainbowschoolsEntities();
            List<Subject> s1 = context.Subjects.ToList();
            Subject s2 = s1.Find(m => m.SubjectID == s.subid);
            s2.SubjectID = s.subid;
            s2.SubjectName=s.subname;
            s2.ClassID = s.cid;
            context.SaveChanges();

        }
        public List<Subjectdata> Subjlist()
        {
            List<Subjectdata> s1 = new List<Subjectdata>();
            rainbowschoolsEntities context = new rainbowschoolsEntities();
            List<Subject> s = context.Subjects.ToList();
            foreach(var item in s)
            {
                s1.Add(
                    new Subjectdata
                    {
                        subid = item.SubjectID,
                        subname = item.SubjectName,
                        cid = item.ClassID
                    });
            }
            return s1;
        }
    }
}
