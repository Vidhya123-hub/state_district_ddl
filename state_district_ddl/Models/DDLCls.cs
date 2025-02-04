using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace state_district_ddl.Models
{
    public class stclass
    {
        public int sId { set; get; }
        public string sName { set; get; }
    }
    public class Dclass
    {
        public int DId { set; get; }
        public string DName { set; get; }
    }
    public class DDLCls
    {
        public int sId { set; get; }
        public string sName { set; get; }
        public int DId { set; get; }
        public string DName { set; get; }
        [Required(ErrorMessage ="enter the name")]
        public string Name { set; get; }
        [Range(18,50,ErrorMessage ="enter the age")]
        public int Age { set; get; }
        public string msg { set; get; }
    }
}