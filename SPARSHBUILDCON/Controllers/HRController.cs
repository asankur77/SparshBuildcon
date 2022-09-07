using SPARSHBUILDCON.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SPARSHBUILDCON.Controllers
{
    public class HRController : Controller
    {
        SqlConnection con = new SqlConnection();
        UsersContext db = new UsersContext();
     
        string gid()
        {

            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {

                i *= ((int)b + 1);
            }


            if (i < 0)
            {
                i = -i;
            }
            string s = i.ToString();
            return s.Substring(0, 10);


        }
        //
        // GET: /HR/




        public JsonResult AutoCompleteEmpid(string term)
        {

            var list = (from r in db.Emp_Salarys where r.empid.ToLower().Contains(term.ToLower()) select new { r.empid }).Distinct();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AutoCompleteSalaryMonth(string term)
        {

            var list = (from r in db.Salary_ems where r.month.ToLower().Contains(term.ToLower()) select new { r.month }).Distinct();
            return Json(list, JsonRequestBehavior.AllowGet);
        }


        public JsonResult AutoCompleteEmpDesignation(string term)
        {

            var list = (from r in db.Emp_Regs where r.designation.ToLower().Contains(term.ToLower()) select new { r.designation }).Distinct();
            return Json(list, JsonRequestBehavior.AllowGet);
        }


        public JsonResult AutoCompleteEmpDepartment(string term)
        {

            var list = (from r in db.Emp_Regs where r.department.ToLower().Contains(term.ToLower()) select new { r.department }).Distinct();
            return Json(list, JsonRequestBehavior.AllowGet);
        }


        public JsonResult AutoCompleteEmp_sal_month(string term)
        {

            var list = (from r in db.Emp_Salarys where r.month.ToLower().Contains(term.ToLower()) select new { r.month }).Distinct();
            return Json(list, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult EmployeeReg()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult EmployeeReg(Emp_Reg model, HttpPostedFileBase Photo, HttpPostedFileBase Photoimg)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {


                Emp_Reg ad = new Emp_Reg();
                ad.name = model.name;
                ad.father = model.father;
                ad.department = model.department;
                ad.designation = model.designation;
                ad.basicsalary = model.basicsalary;
                ad.dob = model.dob;
                ad.gender = model.gender;
                ad.mob = model.mob;
                ad.doj = DateTime.Now.Date;
                ad.email = model.email;
                ad.address = model.address;
                ad.branchcode = model.branchcode;
                ad.empid = model.empid;
                if (Photo != null)
                {
                    string imgname = gid();
                    ad.cv = "~/Photo/" + imgname + ".doc";
                    Photo.SaveAs(HttpContext.Server.MapPath("~/Photo/") + imgname + ".doc");


                }
                else
                {
                    ad.cv = "~/Photo/default.jpg";

                }



                if (Photoimg != null)
                {
                    string imgname = gid();
                    ad.img = "~/Photo/" + imgname + ".jpg";
                    Photoimg.SaveAs(HttpContext.Server.MapPath("~/Photo/") + imgname + ".jpg");


                }
                else
                {
                    ad.img = "~/Photo/default.jpg";

                }
                db.Emp_Regs.Add(ad);
                db.SaveChanges();
                Response.Write("<script>alert('Employee Registration SuccessFully.')</script>");

            }
            return View();
        }

        [HttpGet]
        public ActionResult EmployeeLeave()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }

            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult EmployeeLeave(Emp_leave model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }

            else
            {
                if (ModelState.IsValid)
                {
                    var ad = db.Emp_Regs.Single(dcl => dcl.empid == model.empid);
                    Emp_leave el = new Emp_leave();
                    el.branchcode = ad.branchcode;
                    el.empid = model.empid;
                    el.leavetype = model.leavetype;
                    el.reason = model.reason;
                    el.sdate = model.sdate;
                    el.edate = model.edate;
                    db.Emp_leaves.Add(el);
                    db.SaveChanges();
                    ViewBag.msg = "Leave application successfully submited.";
                }
                return View();
            }
        }

        [HttpGet]
        public ActionResult EmployeeAtten(string mark, string empid)
        {
            List<Emp_Reg> dn = new List<Emp_Reg>();
            List<Emp_atten> empatten = new List<Emp_atten>();
            DateTime date = DateTime.Now.Date;
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                var or = db.HRTabs.Single(o => o.HRId == User.Identity.Name);
                if (mark == null)
                {

                    empatten = (from ae in db.Emp_attens where ae.date == date select ae).ToList();
                    dn = (from ob in db.Emp_Regs where ob.branchcode == or.BranchCode select ob).ToList();
                    foreach (var ea in empatten)
                    {
                        dn.RemoveAll(x => x.empid == ea.empid);
                    }
                }
                else
                {
                    var er = db.Emp_Regs.Single(o => o.empid == empid);
                    Emp_atten en = new Emp_atten();
                    en.empid = empid;
                    en.name = er.name;
                    en.date = DateTime.Now.Date;
                    en.atten = mark;
                    en.branchcode = or.BranchCode;

                    db.Emp_attens.Add(en);
                    db.SaveChanges();

                    empatten = (from ae in db.Emp_attens where ae.date == date select ae).ToList();
                    dn = (from ob in db.Emp_Regs where ob.branchcode == or.BranchCode select ob).ToList();
                    foreach (var ea in empatten)
                    {
                        dn.RemoveAll(x => x.empid == ea.empid);
                    }


                }


                return View(dn);
            }
        }

        [HttpGet]
        public ActionResult Empl_salary()
        {

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Empl_salary(Emp_Salary model, string empid, int year, string month)
        {

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var count = (from b in db.Emp_Salarys where b.empid == empid && b.year == year && b.month == month select b).Count();
                if (count == 0)
                {


                    Emp_Salary ad = new Emp_Salary();
                    ad.empid = model.empid;
                    ad.branchcode = model.branchcode;
                    ad.opid = User.Identity.Name;
                    ad.HRA = model.HRA;
                    ad.DA = model.DA;
                    ad.CCA = model.CCA;
                    ad.TA = model.TA;
                    ad.medical = model.medical;
                    ad.advance_Pay = model.advance_Pay;
                    ad.professionaltax = model.professionaltax;
                    ad.loan = model.loan;
                    ad.provisional_fund = model.provisional_fund;
                    ad.year = model.year;
                    ad.month = model.month;
                    ad.doj = DateTime.Now.Date;

                    db.Emp_Salarys.Add(ad);
                    db.SaveChanges();
                    Response.Write("<script>alert('Employee Salary SuccessFully.')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Please Fill Correct Empid or Month or Year')</script>");

                }


            }
            return View();
        }

        [HttpGet]
        public ActionResult Viewsalary()
        {
            List<Salary_em> emp = new List<Salary_em>();
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                return View(emp);
            }
        }

        [HttpPost]
        public ActionResult Viewsalary(Emp_Salary o, string empid, string month, int year)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var count = (from b in db.Salary_ems where b.empid == empid && b.year == year && b.month == month select b).Count();
                if (count == 0)
                {

                    var br = db.Emp_Regs.Single(b => b.empid == empid);
                    var cc = db.Emp_Salarys.Single(b => b.empid == empid && b.year == year && b.month == month);
                    // var cc = db.Emp_Salarys.Single(b => b.empid == empid);

                    Salary_em tr = new Salary_em();
                    tr.year = cc.year;
                    tr.img = br.img;
                    tr.month = cc.month;
                    tr.empid = br.empid;
                    tr.name = br.name;
                    tr.designation = br.designation;
                    tr.department = br.department;
                    tr.doj = br.doj;
                    tr.date = DateTime.Now.Date;
                    tr.basicsalary = br.basicsalary;

                    tr.HRA = cc.HRA;
                    tr.DA = cc.DA;
                    tr.CCA = cc.CCA;
                    tr.TA = cc.TA;
                    tr.medical = cc.medical;
                    var incentivesum = cc.HRA + cc.DA + cc.CCA + cc.TA + cc.medical;

                    tr.grossincentive = incentivesum;
                    tr.advance_Pay = cc.advance_Pay;
                    tr.professionaltax = cc.professionaltax;
                    tr.loan = cc.loan;
                    tr.provisional_fund = cc.provisional_fund;
                    var deductionamount = cc.advance_Pay + cc.professionaltax + cc.provisional_fund + cc.loan;

                    tr.deductionamount = deductionamount;
                    var netsalary = (br.basicsalary + incentivesum) - deductionamount;
                    tr.netsalary = netsalary;

                    db.Salary_ems.Add(tr);
                    db.SaveChanges();
                }

                else
                {
                    Response.Write("<script>alert('Please Fill Correct Empid or Month or Year')</script>");

                }

                var dn = db.Salary_ems.Where(c => c.empid == empid);
                return View(dn);
            }
        }


        [HttpGet]
        public ActionResult DuplicateEmpSalary()
        {

            List<Salary_em> emp = new List<Salary_em>();
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                return View(emp);
            }
        }

        [HttpPost]
        public ActionResult DuplicateEmpSalary(Emp_Salary o, string empid, string month, int year)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var count = (from b in db.Salary_ems where b.empid == empid && b.year == year && b.month == month select b).Count();
                if (count == 0)
                {

                    var br = db.Emp_Regs.Single(b => b.empid == empid);
                    var cc = db.Emp_Salarys.Single(b => b.empid == empid && b.year == year && b.month == month);
                    // var cc = db.Emp_Salarys.Single(b => b.empid == empid);

                    Salary_em tr = new Salary_em();
                    tr.year = cc.year;
                    tr.img = br.img;
                    tr.month = cc.month;
                    tr.empid = br.empid;
                    tr.name = br.name;
                    tr.designation = br.designation;
                    tr.department = br.department;
                    tr.doj = br.doj;
                    tr.date = DateTime.Now.Date;
                    tr.basicsalary = br.basicsalary;

                    tr.HRA = cc.HRA;
                    tr.DA = cc.DA;
                    tr.CCA = cc.CCA;
                    tr.TA = cc.TA;
                    tr.medical = cc.medical;
                    var incentivesum = cc.HRA + cc.DA + cc.CCA + cc.TA + cc.medical;

                    tr.grossincentive = incentivesum;
                    tr.advance_Pay = cc.advance_Pay;
                    tr.professionaltax = cc.professionaltax;
                    tr.loan = cc.loan;
                    tr.provisional_fund = cc.provisional_fund;
                    var deductionamount = cc.advance_Pay + cc.professionaltax + cc.provisional_fund + cc.loan;

                    tr.deductionamount = deductionamount;
                    var netsalary = (br.basicsalary + incentivesum) - deductionamount;
                    tr.netsalary = netsalary;

                    db.Salary_ems.Add(tr);
                    db.SaveChanges();
                }

                else
                {
                    Response.Write("<script>alert('Please Fill Correct Empid or Month or Year')</script>");

                }

                var dn = db.Salary_ems.Where(c => c.empid == empid);
                return View(dn);
            }
        }
        [HttpGet]
        public ActionResult EmployeeList()
        {
            var hr = db.HRTabs.Single(h => h.HRId == User.Identity.Name);
            List<Emp_Reg> emplist = new List<Emp_Reg>();
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                emplist = (from dcl in db.Emp_Regs where dcl.branchcode == hr.BranchCode select dcl).ToList();
                return View(emplist);

            }
        }

        public ActionResult MonthlySalary(Salary_em o)
        {

            var dn = db.Salary_ems.Where(c => c.month == o.month);
            ViewData["count"] = dn.Count();
            return View(dn);

        }
        [HttpGet]
        public ActionResult YearlySalary(Salary_em o)
        {

            var dn = db.Salary_ems.Where(c => c.year == o.year);
            ViewData["count"] = dn.Count();
            return View();

        }
        [HttpGet]
        public ActionResult BranchWiseSalary()
        {

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult DepartmentWiseSalary()
        {

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult SearchHR()
        {

            List<Emp_Reg> dn = new List<Emp_Reg>();

            {
                dn = db.Emp_Regs.ToList();
            }
            return View(dn);

        }

        [HttpGet]
        public ActionResult ChangePassword()
        {

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult ChangePassword(string Password, string NewPassword, string ConfirmPassword)
        {

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                if (NewPassword == ConfirmPassword)
                {

                    con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "changepassword";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@user", User.Identity.Name);
                    cmd.Parameters.AddWithValue("@oldpass", Password);
                    cmd.Parameters.AddWithValue("@newpass", NewPassword);

                    SqlParameter p = new SqlParameter("@ans", SqlDbType.Int);
                    p.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(p);
                    try
                    {

                        con.Open();
                        cmd.ExecuteNonQuery();


                        string response1 = cmd.Parameters["@ans"].Value.ToString();
                        int a = Convert.ToInt32(response1);

                        if (a == 0)
                        {
                            ViewBag.msg = "Sorry,Old Password Not matching";

                        }
                        else if (a == 1)
                        {
                            ViewBag.msg = "Password Changed successfully";

                        }
                    }

                    catch (SqlException e)
                    {
                        ViewBag.msg = e.Message;

                    }
                    finally
                    {
                        con.Close();
                    }
                }
                else
                {
                    ViewBag.msg = "Password not matching";
                }
            }
            return View();
        }


        [HttpGet]
        public ActionResult empidwiselist(Emp_Reg o)
        {

            var dn = db.Emp_Regs.Where(c => c.empid == o.empid);

            ViewData["count"] = dn.Count();
            return View(dn);
        }

        [HttpGet]
        public ActionResult empdepartmentwiselist(Emp_Reg o)
        {

            var dn = db.Emp_Regs.Where(c => c.department == o.department);
            ViewData["count"] = dn.Count();
            return View(dn);
        }
        [HttpGet]
        public ActionResult empdesignationwiselist(Emp_Reg o)
        {

            var dn = db.Emp_Regs.Where(c => c.designation == o.designation);
            ViewData["count"] = dn.Count();
            return View(dn);
        }






        public ActionResult Logout()
        {
            int max = (from p in db.hrlogin_details where p.iid == User.Identity.Name select p.Id).Max();
            hrlogin_detail ob = db.hrlogin_details.Single(b => b.Id == max);
            ob.outdatetime = DateTime.Now;
            db.SaveChanges();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }

    }
}
