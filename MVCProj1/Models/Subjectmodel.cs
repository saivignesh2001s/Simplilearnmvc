using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProj1.Models
{
    public class Subjectmodel
    {
        [Required()]
        public int subid
        {
            get;
            set;
        }
        [MaxLength(20,ErrorMessage ="Characters above 20 chars")]
        [MinLength(3,ErrorMessage ="Characters below 3")]
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