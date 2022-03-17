using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMonthlyevidence.Models
{
   public class Department
    {
        [Key]
        public string departmentid { get; set; }
        public string departmentname { get; set; }
        public string departmentlocation { get; set; }
        public IList<Student> Students { get; set; }
   }

    public class Student
    {
        [Key]
        public string studentid { get; set; }
        public string studentname { get; set; }
        public string gender { get; set; }
        public DateTime date { get; set; }
        public string picture { get; set; }
        [ForeignKey("department")]
        public string departmentid { get; set; }
        public Department department { get; set; }
    }

    public class ItemCount
    {
        public string departmentid { get; set; }
        public string departmentname { get; set; }
        public int count { get; set; }
    }

    //public class Department_Student
    //{
    //    public string departmentid { get; set; }
    //    public string departmentname { get; set; }
    //    public string departmentlocation { get; set; }
    //    public string studentid { get; set; }
    //    public string studentname { get; set; }
    //    public string gender { get; set; }
    //    public DateTime date { get; set; }
    //    public string picture { get; set; }
    //    public string sid { get; set; }

    //}
}
