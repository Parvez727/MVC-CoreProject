using CoreMonthlyevidence.Context;
using CoreMonthlyevidence.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMonthlyevidence.Controllers
{
    public class Department_Student : Controller
    {
        private MyDBContext db;
        private IHostingEnvironment _HostEnvironment;
        public Department_Student(MyDBContext _db,IHostingEnvironment HostingEnvironment)
        {
            db = _db;
            _HostEnvironment = HostingEnvironment;
        }
        public IActionResult Create()
        {
            return View();
        }

        //public JsonResult JsonIndex()
        //{
        //    return Json(db.Departments, JsonRequestBehavior.AllowGet);
        //}




        public IActionResult main()
        {
            List<ItemCount> a = (from d in db.Departments
                                 select new ItemCount
                                 {
                                     departmentid = d.departmentid,
                                     departmentname = d.departmentname,
                                     count = d.Students.Count
                                 }).ToList();
            return View(a);
        }

        public JsonResult GetDepartment(string id)
        {
            var a = (from d in db.Departments
                     where d.departmentid == id
                     //select d);
                     select new
                     {
                         d.departmentid,
                         d.departmentname,
                         d.departmentlocation
                     });
            return Json(a);
        }

        public JsonResult GetStudent(string id)
        {
            var a = (from d in db.Students
                     where d.departmentid == id
                     //select d);
                     select new
                     {
                         d.studentid,
                         d.studentname,
                         d.gender,
                         d.date,
                         d.picture
                     });
            return Json(a);
        }

        public JsonResult GetStudentBystudentid(string id)
        {
            var a = (from d in db.Students where d.studentid == id select d);
            return Json(a);
        }

        public JsonResult GetDepartmentStudent(string id)
        {
            var a = (from d in db.Departments
                     where d.departmentid == id
                     select new
                        {
                        d.departmentid,
                        d.departmentname,
                        d.departmentlocation,
                        d.Students.Count
                        });
            return Json(a);
        }

        public JsonResult InsertDepartment(Department e)
        {
            Department a = new Department();
            a.departmentid = e.departmentid;
            a.departmentname = e.departmentname;
            a.departmentlocation = e.departmentlocation;
            db.Departments.Add(a);
            db.SaveChanges();
            return Json(a);
        }

        public JsonResult InsertStudent(Student e)
        {
            Student a1 = new Student();
            a1.studentid = e.studentid;
            a1.studentname = e.studentname;
            a1.departmentid = e.departmentid;
            a1.gender = e.gender;
            a1.date = DateTime.Parse(e.date.ToShortDateString());
            a1.picture = e.picture;
            db.Students.Add(a1);
            db.SaveChanges();
            return Json(a1);
        }

        public JsonResult DeleteAll(string id)
        {
            List<Student> st2 = db.Students.Where(xx => xx.departmentid == id).ToList();
            db.Students.RemoveRange(st2);

            Department st3 = db.Departments.Find(id);
            if(st3 != null)
            {
                db.Departments.Remove(st3);
            }
            db.SaveChanges();
            return Json("OK");
        }

        [HttpPost]
        public JsonResult UploadFiles()
        {
            if(Request.Form.Files.Count > 0)
            {
                try
                {
                    var files = Request.Form.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        IFormFile file = files[i];
                        string fname;
                        fname = file.FileName;
                        string webRootPath = _HostEnvironment.WebRootPath;
                        string fname1 = "";
                        fname1 = Path.Combine(webRootPath, "Uploads/" + fname);
                        file.CopyTo(new FileStream(fname1, FileMode.Create));
                    }
                    return Json("File Uploaded Successfully!");
                }
                catch(Exception ex)
                {
                    return Json("Error occured.Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }
    }
}
