using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BAL
{
    public class classdata
    {
        public int classId
        {
            get;
            set;
        }
        public string cname
        {
            get;
            set;
        }
    }
    public class Studentdata
    {
        public int sid
        {
            get;
            set;
        }
        public string sname
        {
            get;
            set;
        }
        public int? cid
        {
            get;
            set;
        }
    }
    public class Subjectdata
    {
        public int subid
        {
            get;
            set;
        }
        public string subname
        {
            get;
            set;
        }
        public int? cid
        {
            get;
            set;
        }
    }
}
