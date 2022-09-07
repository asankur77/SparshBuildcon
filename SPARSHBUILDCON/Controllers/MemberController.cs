using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mvc; 
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SPARSHBUILDCON.Models;
using System.Web.Security;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Text.RegularExpressions;
using PagedList;
using System.Web.Helpers;
using System.Net.NetworkInformation;


namespace SPARSHBUILDCON.Controllers
{
    public class MemberController : Controller
    {
        UsersContext db = new UsersContext();
        SqlConnection con = new SqlConnection();
        public static string newsplitid;

        //
        // GET: /Member/
        public bool IsLoggedIn()
        {

            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    int count = (from n in db.NewLogins where n.UserName == User.Identity.Name select n.UserName).Count();
                    if (count == 1)
                    {
                        var log = db.NewLogins.Single(a => a.UserName == User.Identity.Name);
                        if (log.status == 1 && log.type == "Member")
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        string gidref()
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
            return s.Substring(0, 4);


        }

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
            return s.Substring(0, 8);
        }

        string gid2()
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
            return s.Substring(0, 8);
        }

        string gid3()
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
            return s.Substring(0, 6);
        }

        string gid4()
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
            return s.Substring(0, 7);
        }

        #region json starts

        public JsonResult AutoCompleteTeamAgentid(string term)
        {
            var teamlist = (from gt in db.genology_tabs where gt.newid == User.Identity.Name select gt.cust_id).Distinct();
            var alist = (from it in db.AgentDetails where teamlist.Contains(it.uid) select it).ToList();
            var list = (from r in alist where r.NewAgentId.ToLower().Contains(term.ToLower()) || r.name.ToLower().Contains(term.ToLower()) select new { r.NewAgentId, r.name }).Distinct();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult verifyid(string intro)
        {
            var teamlist = (from gt in db.genology_tabs where gt.newid == User.Identity.Name select gt.cust_id).Distinct();
            var alist = (from it in db.AgentDetails where teamlist.Contains(it.uid) select it).ToList();
            var count = alist.Where(a => a.NewAgentId == intro).Count();
            return Json(count, JsonRequestBehavior.AllowGet);
        }

        public JsonResult mobile(string mem)
        {
            var list = db.AgentDetails.Single(a => a.NewAgentId == mem).Mobile;
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult name(string mem)
        {
            var list = db.AgentDetails.Single(a => a.NewAgentId == mem).name;
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult downlinemem(string naam, string mem)
        {
            List<Downline> dw = new List<Models.Downline>();

            var memberid = db.AgentDetails.Single(a => a.NewAgentId == naam);

            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            cmd.Connection = con;
            SqlDataReader sdr;
            cmd.CommandText = "brokerchain";
            cmd.Parameters.AddWithValue("@kamal", memberid.AgencyCode);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();
                sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        var dn = new Downline();

                        dn.MemberId = sdr["memberid"].ToString();
                        dn.Introducer = sdr["introducerid"].ToString();

                        var username = db.AgentDetails.Single(a => a.NewAgentId == dn.MemberId);
                        var introname = db.AgentDetails.Single(a => a.NewAgentId == dn.Introducer);

                        dn.MemberName = introname.name;
                        dn.status = Convert.ToInt32(sdr["status"].ToString());
                        dn.MemberName = sdr["membername"].ToString();
                        dn.IntroducerName = introname.name;
                        dn.JoinDate = username.Doj;
                        dw.Add(dn);
                    }
                }

                var list = (from a in dw where a.MemberId.ToLower().Contains(mem.ToLower()) select new { a.MemberId, a.MemberName }).Distinct();
                return Json(list, JsonRequestBehavior.AllowGet);
            }



            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
            finally
            {
                con.Close();
            }
            return Json(JsonRequestBehavior.AllowGet);
        }

        public JsonResult SelectIntroName(string intro)
        {
            var list = (from o in db.AgentDetails where o.NewAgentId == intro select o.name);
            return Json(list, JsonRequestBehavior.AllowGet);

        }

        public JsonResult intro(string introid)
        {
            var list = (from j in db.genology_tabs where j.newid.ToLower().Contains(introid.ToLower()) select new { j.newid }).Distinct();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Imagepost(HttpPostedFileBase Image, string id)
        {
            int status = 0;
            var member_dtl = db.AgentDetails.Single(a => a.NewAgentId == User.Identity.Name);

            if (Image != null)
            {
                string imgname = gid();
                member_dtl.Photo = "~/Images/" + imgname + ".jpg";
                Image.SaveAs(HttpContext.Server.MapPath("~/Images/") + imgname + ".jpg");
                Response.Write("<script>alert('Profile photo successfully changed !')</script>");
                status = 1;
            }
            db.Entry(member_dtl).State = EntityState.Modified;
            db.SaveChanges();


            return Json(status, JsonRequestBehavior.AllowGet);
        }
        #endregion

        //Region Duregesh 2/08/2018 start
        public JsonResult getincomelist(string memberid)
        {

            List<string> pay = new List<string>();
            var incomedate = db.PayoutSummarys.Where(x => x.Newintroid == memberid).ToList();
            foreach (var i in incomedate)
            {
                pay.Add(i.edate.ToString());


            }
            return Json(pay, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult incomecheck()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                return View();

            }
        }
        [HttpPost]
        public ActionResult incomecheck(DateTime paydate)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                if (paydate != null)
                {
                    var NewAgentId = User.Identity.Name;
                    var payoutdate = paydate.ToString("yyyy-MM-dd");
                    TempData["memberid"] = NewAgentId;

                    List<PayoutSummary> temppayout = new List<PayoutSummary>();
                    SqlConnection con = new SqlConnection();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "select * from payoutsummary where Newintroid='" + NewAgentId + "' and edate='" + payoutdate + "'";
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    try
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow item in ds.Tables[0].Rows)
                            {
                                temppayout.Add(new PayoutSummary
                                {
                                    status = Convert.ToInt32(item["status"]),
                                    paydate = Convert.ToDateTime(item["paydate"]),
                                    sdate = Convert.ToDateTime(item["sdate"]),
                                    edate = Convert.ToDateTime(item["edate"]),
                                    Newintroid = item["Newintroid"].ToString(),
                                    IntroName = item["IntroName"].ToString(),
                                    LevelIncome = Convert.ToDouble(item["LevelIncome"]),
                                    BinaryIncome = Convert.ToDouble(item["BinaryIncome"]),
                                    DSIIncome = Convert.ToDouble(item["DSIIncome"]),
                                    PoolIncome = Convert.ToDouble(item["PoolIncome"]),
                                    MagicIncome = Convert.ToDouble(item["MagicIncome"]),
                                    Leadershipincome = Convert.ToDouble(item["Leadershipincome"]),
                                    Rewards = Convert.ToDouble(item["Rewards"]),
                                    totalamount = Convert.ToDouble(item["totalamount"]),
                                    netamount = Convert.ToDouble(item["netamount"]),
                                    TDS = Convert.ToDouble(item["TDS"]),
                                    AdminFee = Convert.ToDouble(item["AdminFee"]),
                                    Roiincome = Convert.ToDouble(item["Roiincome"]),
                                    Slcincome = Convert.ToDouble(item["Slcincome"]),
                                    Royaltyincome = Convert.ToDouble(item["Royaltyincome"]),
                                    Directincome = Convert.ToDouble(item["Directincome"])


                                });
                            }

                        }
                    }

                    catch (Exception ex)
                    {
                        TempData["my9"] = ex.Message;
                        // Response.Write("<script>alert('" + ex.Message + "')</script>");
                    }
                    finally
                    {
                        con.Close();
                    }
                    return View(temppayout);
                }
                else
                {
                    return View();
                }
            }
        }
        //Region Duregesh 2/08/2018 end

        public ActionResult newlayout()
        {
            return View();
        }

        #region Action starts

        public ActionResult Dashboard()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                ViewData["msg"] = TempData["msg"];
                var turnover = 0;
                var teamstrength = 0;
                List<Downline> dw = new List<Models.Downline>();
                var memberid = db.AgentDetails.Single(a => a.NewAgentId == User.Identity.Name);

                SqlCommand cmd = new SqlCommand();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                cmd.Connection = con;
                SqlDataReader sdr;
                cmd.CommandText = "brokerchain";
                cmd.Parameters.AddWithValue("@kamal", memberid.AgencyCode);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    sdr = cmd.ExecuteReader();
                    cmd.CommandTimeout = 10000000;
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            var dn = new Downline();

                            dn.MemberId = sdr["memberid"].ToString();
                            dn.Introducer = sdr["introducerid"].ToString();

                            var username = db.AgentDetails.Single(a => a.NewAgentId == dn.MemberId);
                            var introname = db.AgentDetails.Single(a => a.NewAgentId == dn.Introducer);

                            dn.MemberName = introname.name;
                            dn.MemberName = sdr["membername"].ToString();
                            dn.IntroducerName = introname.name;

                            dn.JoinDate = username.Doj;
                            dw.Add(dn);
                        }
                    }


                }

                catch (Exception ex)
                {
                    //Response.Write("<script>alert('" + ex.Message + "')</script>");
                }
                finally
                {
                    con.Close();
                }

                return View(dw);

            }
        }

        public ActionResult businessplan()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                return View();
            }
        }

        public ActionResult WelcomeNote()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                return View();
            }
        }

        public ActionResult profilestatus()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Update_Profile()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                ViewData["msg"] = TempData["msg"];
                return View();
            }
        }
        [HttpPost]
        public ActionResult Update_Profile(AgentDetail ui, HttpPostedFileBase memberprofile)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                var ui1 = db.AgentDetails.Single(a => a.NewAgentId == User.Identity.Name);

                string imgname = gid();
                ui1.Nationality = ui.Nationality;
                ui1.Address = ui.Address;
                ui1.Father = ui.Father;
                ui1.District = ui.District;
                if (memberprofile != null)
                {
                    memberprofile.SaveAs(HttpContext.Server.MapPath("../Images/" + imgname + ".jpg"));
                    ui1.Photo = "../Images/" + imgname + ".jpg";
                }
                else
                {
                    ui1.Photo = ui1.Photo;
                }
                ui1.State = ui.State;
                ui1.PinCode = ui.PinCode;
                ui1.Mobile = ui.Mobile;
                ui1.Email = ui.Email;
                ui1.NomineeName = ui.NomineeName;
                if (ui.Dob == null)
                {
                    ui1.Dob = ui1.Dob;
                }
                else
                {
                    ui1.Dob = ui.Dob;
                }
                ui.Relationship = ui.Relationship;
                ui1.Age = ui.Age;
                ui1.Relationship = ui.Relationship;
                ui1.Gender = ui.Gender;
                db.Entry(ui1).State = EntityState.Modified;
                db.SaveChanges();

                TempData["msg"] = "Profile Detail Updated Suucessfully !!!";

                return RedirectToAction("Update_Profile", "Member");
            }
        }

        [HttpGet]
        public ActionResult Bank_Update()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                //var ck = db.AgentDetails.Single(a => a.NewAgentId == User.Identity.Name);
                //if (ck.RegistrationType == "Bulk" && User.Identity.Name == ck.Topnewid)
                //{

                ViewData["msg"] = TempData["msg"];
                return View();
                //}
                //else
                //{
                //    Response.Write("<script>alert('Sorry Please upload kyc by super member Id Panel!')</script>");
                //    TempData["msg"] = "Sorry Please upload kyc by super member Id Panel!";
                //    return RedirectToAction("Dashboard", "Member");
                //}

            }
        }
        [HttpPost]
        public ActionResult Bank_Update(AgentDetail bk, HttpPostedFileBase bank_img, HttpPostedFileBase pan_img, HttpPostedFileBase aadhaar_img)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                var ck = db.AgentDetails.Single(a => a.NewAgentId == User.Identity.Name);
                //if (ck.RegistrationType == "Bulk" && User.Identity.Name == ck.Topnewid && ck.kyc_status == 0)
                //{
                //    var list = db.AgentDetails.Where(a => a.Topnewid == User.Identity.Name).ToList();
                //    foreach (var i in list)
                //    {
                //        var up = db.AgentDetails.Single(a => a.NewAgentId == i.NewAgentId);
                //        up.BankName = bk.BankName;
                //        up.BranchName = bk.BranchName;
                //        up.AccountHolder = bk.AccountHolder;
                //        ck.BankAccountNo = bk.BankAccountNo;
                //        up.AccountType = bk.AccountType;
                //        up.IFSC = bk.IFSC;
                //        up.PAN = bk.PAN;
                //        up.aadhaar = bk.aadhaar;

                //        if (bank_img != null)
                //        {
                //            string imgname = gid();
                //            up.bank_img = "~/Images/" + imgname + ".jpg";
                //            bank_img.SaveAs(HttpContext.Server.MapPath("~/Images/") + imgname + ".jpg");
                //        }
                //        else
                //        {
                //            up.bank_img = "~/Content/Home2/passbook.jpg";
                //        }


                //        if (pan_img != null)
                //        {
                //            string imgname = gid();
                //            up.pan_img = "~/Images/" + imgname + ".jpg";
                //            pan_img.SaveAs(HttpContext.Server.MapPath("~/Images/") + imgname + ".jpg");
                //        }
                //        else
                //        {
                //            up.pan_img = "~/Content/Home2/pan.jpg";
                //        }



                //        if (aadhaar_img != null)
                //        {
                //            string imgname = gid();
                //            up.aadhaar_img = "~/Images/" + imgname + ".jpg";
                //            aadhaar_img.SaveAs(HttpContext.Server.MapPath("~/Images/") + imgname + ".jpg");
                //        }
                //        else
                //        {
                //            up.aadhaar_img = "~/Content/Home2/aadhaar.jpg";
                //        }

                //        db.Entry(up).State = EntityState.Modified;
                //        db.SaveChanges();

                //        TempData["msg"] = "Bulk Kyc Detail Updated Successfully !!!";

                //    }
                //}
                if (ck.kyc_status == 0)
                {
                    ck.BankName = bk.BankName;
                    ck.BankBranchName = bk.BankBranchName;
                    ck.AccountHolder = bk.AccountHolder;
                    ck.BankAccountno = bk.BankAccountno;
                    ck.AccountType = bk.AccountType;
                    ck.IFCCode = bk.IFCCode;
                    ck.Panno = bk.Panno;
                    ck.Aadhaar_No = bk.Aadhaar_No;

                    if (bank_img != null)
                    {
                        string imgname = gid();
                        ck.bank_img = "~/Images/" + imgname + ".jpg";
                        bank_img.SaveAs(HttpContext.Server.MapPath("~/Images/") + imgname + ".jpg");
                    }
                    else
                    {
                        ck.bank_img = "~/Content/Home2/passbook.jpg";
                    }


                    if (pan_img != null)
                    {
                        string imgname = gid();
                        ck.pan_img = "~/Images/" + imgname + ".jpg";
                        pan_img.SaveAs(HttpContext.Server.MapPath("~/Images/") + imgname + ".jpg");
                    }
                    else
                    {
                        ck.pan_img = "~/Content/Home2/pan.jpg";
                    }



                    if (aadhaar_img != null)
                    {
                        string imgname = gid();
                        ck.aadhaar_img = "~/Images/" + imgname + ".jpg";
                        aadhaar_img.SaveAs(HttpContext.Server.MapPath("~/Images/") + imgname + ".jpg");
                    }
                    else
                    {
                        ck.aadhaar_img = "~/Content/Home2/aadhaar.jpg";
                    }

                    db.Entry(ck).State = EntityState.Modified;
                    db.SaveChanges();

                    TempData["msg"] = "Kyc Detail Updated Successfully !!!";
                }
                else
                {
                    TempData["msg"] = "Sorry Your KYC Approved it is not modified!!!";
                }


                return RedirectToAction("Bank_Update", "Member");
            }
        }

        public ActionResult Mydirect(int? page)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                AgentDetail objStudent = new AgentDetail();
                List<AgentDetail> tempdirect = new List<AgentDetail>();
                SqlConnection con = new SqlConnection();
                DataSet ds = new DataSet();

                int pageSize = 50;
                int pageIndex = 1;
                pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
                ViewData["pageno"] = pageIndex;
                int akhiri = (pageIndex - 1) * 50;
                ViewData["srno"] = akhiri;
                IPagedList<AgentDetail> stu = null;
                SqlCommand cmd = new SqlCommand();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "select * from AgentDetail where spilid ='" + User.Identity.Name + "'";
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            tempdirect.Add(new AgentDetail
                            {

                                NewAgentId = item["NewAgentId"].ToString(),
                                name = item["name"].ToString(),
                                Doj = Convert.ToDateTime(item["Doj"]),
                                position = Convert.ToInt32(item["position"])

                            });
                        }

                    }
                }

                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                }
                finally
                {
                    con.Close();
                }
                int countdirect = tempdirect.Count();
                TempData["totaldirect"] = countdirect;
                stu = tempdirect.ToPagedList(pageIndex, pageSize);
                return View(stu);
            }
        }

        public ActionResult Downline()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                List<Downline> dw = new List<Models.Downline>();

                var memberid = db.AgentDetails.Single(a => a.NewAgentId == User.Identity.Name);

                SqlCommand cmd = new SqlCommand();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                cmd.Connection = con;
                SqlDataReader sdr;
                cmd.CommandText = "brokerchain";
                cmd.Parameters.AddWithValue("@kamal", memberid.AgencyCode);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            var dn = new Downline();

                            dn.MemberId = sdr["memberid"].ToString();
                            dn.Introducer = sdr["introducerid"].ToString();

                            var username = db.AgentDetails.Single(a => a.NewAgentId == dn.MemberId);
                            var introname = db.AgentDetails.Single(a => a.NewAgentId == dn.Introducer);

                            dn.MemberName = introname.name;

                            dn.MemberName = sdr["membername"].ToString();
                            dn.IntroducerName = introname.name;

                            dn.JoinDate = username.Doj;
                            dw.Add(dn);
                        }
                    }
                }

                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                }
                finally
                {
                    con.Close();
                }
                return View(dw);
            }
        }

        public ActionResult Spot_income()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Mycommisionincome()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Weeklyincome()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                return View();
            }
        }

        //[HttpGet]
        //public ActionResult pinwallet()
        //{
        //    if (!User.Identity.IsAuthenticated)
        //    {
        //        return RedirectToAction("Logout", "Member");
        //    }
        //    else
        //    {
        //        ViewData["msg"] = TempData["msg"];
        //        ViewData["balance"] = TempData["balance"];
        //        return View();
        //    }
        //}

        //[HttpPost]
        //public ActionResult pinwallet(Wallet_History wh, wallettab wt, pintab pt, string available, string pinamount, string noofpin)
        //{
        //    if (!User.Identity.IsAuthenticated)
        //    {
        //        return RedirectToAction("Logout", "Member");
        //    }
        //    else
        //    {

        //        Wallet_History wh1 = new Wallet_History();
        //        pintab pt1 = new pintab();
        //        wallettab wt1 = new wallettab();
        //        int rest = Convert.ToInt32(available);
        //        int nopin = Convert.ToInt32(noofpin);
        //        int need = Convert.ToInt32(pinamount);
        //        if(nopin>0)
        //        {
        //        int jh = nopin * need;
        //        if (rest > 0)
        //        {

        //            if (nopin * need <= rest)
        //            {
        //                for (int i = 0; i < nopin; i++)
        //                {
        //                    string gh = gid().ToString();
        //                    pt1.pin = "GLC-" + gh + "-MEM";
        //                    pt1.status = 0;
        //                    pt1.timeofgeneration = DateTime.Now.Date;
        //                    pt1.timeofapproval = DateTime.Now.Date;
        //                    pt1.Assigndate = DateTime.Now.Date;
        //                    pt1.assignto = User.Identity.Name;
        //                    pt1.pinamount = pinamount;
        //                    pt1.Createdby = User.Identity.Name;
        //                    db.pintabs.Add(pt1);
        //                    db.SaveChanges();

        //                    wh1.transactionid = "PW" + gid4().ToString();
        //                    wh1.debit = pt1.pinamount;
        //                    wh1.transactiondate = DateTime.Now;
        //                    wh1.createdpin = pt1.pin;
        //                    wh1.Remark = "Debited Through Pin";
        //                    wh1.pincreatedby = User.Identity.Name;
        //                    db.Wallet_Historys.Add(wh1);
        //                    db.SaveChanges();
        //                }

        //                var walletbalance = db.wallettabs.Single(a => a.UserId == User.Identity.Name);
        //                walletbalance.amount = walletbalance.amount - jh;
        //                db.Entry(walletbalance).State = EntityState.Modified;
        //                db.SaveChanges();

        //                Create_Pin tp = new Create_Pin();
        //                tp.ID = User.Identity.Name;
        //                tp.Total_Pin = noofpin;
        //                tp.Pin_Amount = Convert.ToDouble(pinamount);
        //                tp.Date = DateTime.Now;
        //                db.Create_Pins.Add(tp);
        //                db.SaveChanges();
        //                TempData["msg"] = "Pin Created Successfully !";

        //            }
        //            else
        //            {
        //                TempData["msg"] = "You Do not have Sufficient Balance!";
        //            }
        //        }
        //    }
        //        else
        //        {
        //            TempData["balance"] = "You Do not have Sufficient Balance";
        //        }
        //        return RedirectToAction("pinwallet", "Member");
        //    }
        //    return View();
        //}

        public ActionResult pinallocation()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                return View();
            }
        }

        public ActionResult allocatepins()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                return View();
            }
        }

        public ActionResult allocatepinstoid()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Pinhistory()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                return View();
            }
        }

        public ActionResult e_walletincome()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                return View();
            }
        }

        public ActionResult fundtransfer()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                return View();
            }
        }

        public ActionResult pinwallettransfer()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Amount_deposit()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Bankwallet_Transfer()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Registration()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Location(string pin, string sid, string Regfrom, int side = 0)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                int count = (from n in db.NewLogins where n.UserName == User.Identity.Name select n.UserName).Count();
                if (count == 1)
                {
                    var log = db.NewLogins.Single(a => a.UserName == User.Identity.Name);
                    if (log.status == 1 && log.type == "Member")
                    {

                        ViewData["Pin"] = pin;
                        ViewData["sid"] = sid;
                        ViewData["Regfrom"] = Regfrom;
                        ViewData["side"] = side;


                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Logout", "Member");
                    }
                }
                else
                {
                    return RedirectToAction("Logout", "Member");
                }
            }
        }

        [HttpPost]
        public ActionResult Location(string Introducer, string spilid, string Pin, string Regfrom, int side = 0)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                var introcount = db.AgentDetails.Where(a => a.NewAgentId == Introducer).Count();
                var pincount = db.pintabs.Where(a => a.status == 0 && a.pin == Pin).Count();
                if (introcount == 0 || side == 0)
                {
                    TempData["msg"] = "Sorry Invalid Introducerid or invalid Position";
                    return RedirectToAction("Successfully", "Member");
                }
                else
                {


                    if (spilid == null || spilid == "" || spilid == " ")
                    {
                        spilid = Introducer;
                    }
                    //var IntroId = db.userinfos.Single(a => a.newid == Introducer);
                    var spilr = db.AgentDetails.Single(a => a.NewAgentId == spilid);
                    if (side == 0)
                    {

                    }
                    else if (side == 1)
                    {
                        var downleft = 0;
                        var lperson = 0;
                        var id = 0;
                        var binary = db.binarys.Single(a => a.Id == spilr.uid);
                        lperson = binary.lperson;
                        downleft = binary.downleft;
                        id = spilr.uid;
                        while (lperson != 0)
                        {
                            var binary1 = db.binarys.Single(a => a.Id == downleft);
                            lperson = binary1.lperson;
                            downleft = binary1.downleft;
                            id = binary1.Id;
                        }

                        var uy = db.AgentDetails.Single(n => n.uid == id);
                        TempData["Introducer"] = Introducer;
                        TempData["SpilId"] = uy.NewAgentId;
                        TempData["Pin"] = Pin;
                        TempData["side"] = 1;
                        TempData["Regfrom"] = Regfrom;

                        return RedirectToAction("FillMemberDetails", "Member");

                    }
                    else if (side == 2)
                    {
                        var downright = 0;
                        var rperson = 0;
                        var id = 0;
                        var binary = db.binarys.Single(a => a.Id == spilr.uid);
                        rperson = binary.rperson;
                        downright = binary.downright;
                        id = spilr.uid;
                        while (rperson != 0)
                        {
                            var binary1 = db.binarys.Single(a => a.Id == downright);
                            rperson = binary1.rperson;
                            downright = binary1.downright;
                            id = binary1.Id;
                        }

                        var uy = db.AgentDetails.Single(n => n.uid == id);
                        TempData["Introducer"] = Introducer;
                        TempData["SpilId"] = uy.NewAgentId;
                        TempData["Pin"] = Pin;
                        TempData["side"] = 2;
                        TempData["Regfrom"] = Regfrom;

                        return RedirectToAction("FillMemberDetails", "Member");

                    }

                }
                return View();
            }


        }

        [HttpGet]
        public ActionResult FillMemberDetails()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                int count = (from n in db.NewLogins where n.UserName == User.Identity.Name select n.UserName).Count();
                if (count == 1)
                {
                    var log = db.NewLogins.Single(a => a.UserName == User.Identity.Name);
                    if (log.status == 1 && log.type == "Member")
                    {
                        ViewData["Introducer"] = TempData["Introducer"];
                        ViewData["SpilId"] = TempData["SpilId"];
                        ViewData["Pin"] = TempData["Pin"];
                        ViewData["side"] = TempData["side"];
                        ViewData["Regfrom"] = TempData["Regfrom"];


                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Logout", "Member");
                    }
                }
                else
                {
                    return RedirectToAction("Logout", "Member");
                }
            }


        }

        //[HttpPost]
        //public ActionResult FillMemberDetails(AgentDetail model, string pin, string introducerid, string spilid, string Password, string Regfrom, int DOB = 0)
        //{

        //    if (!User.Identity.IsAuthenticated)
        //    {
        //        return RedirectToAction("Logout", "Member");
        //    }
        //    else
        //    {
        //        //if (Regfrom == "Tree")
        //        //{
        //        //    pintab pt2 = new pintab();

        //        //    string gh = gid().ToString();
        //        //    pt2.pin = "PG-" + gh + "-MEM";
        //        //    pt2.status = Convert.ToInt32(1);
        //        //    pt2.timeofgeneration = DateTime.Now.Date;
        //        //    pt2.timeofapproval = DateTime.Now.Date;
        //        //    pt2.pinamount = "0";
        //        //    pt2.Assigndate = DateTime.Now.Date;
        //        //    pt2.Createdby = "Auto DRT";
        //        //    db.pintabs.Add(pt2);
        //        //    db.SaveChanges();
        //        //    //Response.Write("<script>alert('Pin Created Successfully !')</script>");
        //        //    pin = pt2.pin;


        //        //}
        //        var comp = db.CompanyInfos.Single(a => a.Id == 1);

        //        //string newid = comp.NewidPrefix + gid3();
        //        var checknewid = db.AgentDetails.Where(a => a.NewAgentId == newid).Count();
        //        var introcount = db.AgentDetails.Where(a => a.NewAgentId == introducerid).Count();
        //        var spilcount = db.AgentDetails.Where(a => a.NewAgentId == spilid).Count();
        //        var pinstatus = db.pintabs.Where(bb => bb.pin == pin && bb.status == 0).Count();
        //        var logstatus = db.NewLogins.Where(bb => bb.UserName == newid).Count();


        //        if (checknewid == 0 && introcount == 1 && spilcount == 1 && pinstatus == 1 && logstatus==0)
        //        {


        //            System.Threading.Thread.Sleep(2000);
        //            var uid1 = 0;





        //            var count = db.AgentDetails.Where(a => a.NewAgentId == spilid).Count();
        //            if (count == 1)
        //            {
        //                var Singleuser = db.AgentDetails.Single(a => a.NewAgentId == spilid);
        //                var Filluser = new AgentDetail();
        //                var Fillbinary = new binary();
        //                var genology = new genology_tab();
        //                var Updatebinary = db.binarys.Single(a => a.Id == Singleuser.uid);
        //                var UpdatePinTab = db.pintabs.Single(a => a.pin == pin);
        //                var intro = db.AgentDetails.Single(a => a.NewAgentId == introducerid);
        //                var FillLogin = new newlogin();
        //                var wt1 = new wallettab();
        //                var Fillspil = new spiltab();
        //                //-------Fill User Info Table---------------------
        //                Filluser.NewAgentId = newid;
        //                if (model.position == 1)
        //                {
        //                    Filluser.position = 1;
        //                    uid1 = Updatebinary.downleft;
        //                    Updatebinary.lperson = 1;

        //                }
        //                else if (model.position == 2)
        //                {
        //                    Filluser.position = 2;
        //                    uid1 = Updatebinary.downright;
        //                    Updatebinary.rperson = 1;
        //                }
        //                Filluser.uid = uid1;

        //                Filluser.introducerid = intro.NewAgentId;
        //                Filluser.spillid = spilid;
        //                Filluser.rank = 0;
        //                Filluser.name = model.name;
        //                Filluser.mobile = model.mobile;
        //                Filluser.DSIid = intro.NewAgentId;
        //                Filluser.name = model.name;
        //                Filluser.opid = User.Identity.Name;
        //                Filluser.rank = 0;
        //                Filluser.dob = DateTime.Now.Date;
        //                Filluser.Nationality = model.Nationality;
        //                Filluser.address = model.address;
        //                Filluser.city = model.city;
        //                Filluser.state = model.state;
        //                Filluser.pincode = model.pincode;
        //                Filluser.mobile = model.mobile;
        //                Filluser.pinused = pin;
        //                Filluser.email = model.email;
        //                Filluser.nominee = model.nominee;
        //                Filluser.Age = model.Age;
        //                Filluser.relation = model.relation;
        //                Filluser.NewAgentId = newid;
        //                Filluser.joindate = DateTime.Now.Date;
        //                Filluser.activationdate = DateTime.Now.Date;
        //                var pinamount = Convert.ToInt32(db.pintabs.Single(a => a.pin == pin).pinamount);

        //                if (pinamount > 0)
        //                {
        //                    Filluser.Status = 1;
        //                }
        //                else
        //                {
        //                    Filluser.Status = 0;
        //                }
        //                Filluser.gender = model.gender;
        //                db.AgentDetails.Add(Filluser);
        //                db.Entry(Updatebinary).State = EntityState.Modified;
        //                db.SaveChanges();
        //                //-------End User Info Table---------------------


        //                FillLogin.reg_date = DateTime.Now;
        //                FillLogin.userid = newid;
        //                FillLogin.password = gid3();
        //                FillLogin.status = 1;
        //                FillLogin.type = "Member";
        //                db.NewLogins.Add(FillLogin);
        //                db.SaveChanges();


        //                wt1.amount = 0;
        //                wt1.UserId = newid;
        //                db.wallettabs.Add(wt1);
        //                db.SaveChanges();



        //                UpdatePinTab.timeofapproval = DateTime.Now;
        //                UpdatePinTab.usedby = newid;
        //                UpdatePinTab.status = 1;
        //                db.Entry(UpdatePinTab).State = EntityState.Modified;
        //                db.SaveChanges();
        //                TempData["msg"] = "Registration Successfull ..";







        //                //-------Insert Binary Table---------------------
        //                var max = (from o in db.binarys select o.downright).Max();
        //                Fillbinary.Id = uid1;
        //                Fillbinary.intid = Singleuser.uid;
        //                Fillbinary.lperson = 0;
        //                Fillbinary.rperson = 0;
        //                Fillbinary.pair = 0;
        //                Fillbinary.upline = "upline";
        //                Fillbinary.downleft = max + 1;
        //                Fillbinary.downright = max + 2;
        //                Fillbinary.completelevel = 0;
        //                db.binarys.Add(Fillbinary);
        //                db.SaveChanges();
        //                //-------End insert Binary Table---------------------

        //                //-------Update Binary Table---------------------
        //                var Checkbinary = db.binarys.Single(a => a.Id == Singleuser.uid);
        //                if (Checkbinary.rperson == 1 && Checkbinary.lperson == 1)
        //                {
        //                    Checkbinary.pair = 1;
        //                }


        //                //-------End Update Binary Table---------------------
        //                //---Insert Into Spiltab -------------------


        //                Fillspil.custid = uid1;
        //                Fillspil.spilid = Singleuser.uid;
        //                Fillspil.intid = intro.uid;
        //                db.spiltabs.Add(Fillspil);
        //                //------End spiltab------------------



        //                //----------End Genology Table All Chain-------------------
        //                db.SaveChanges();

        //                //----------Insert Genology Table All Chain----------------
        //                var introducer = 0;
        //                var custid = uid1;
        //                while (introducer != 1)
        //                {
        //                    var usertab = db.AgentDetails.Single(a => a.uid == custid);

        //                    var introdd = db.AgentDetails.Single(bb => bb.NewAgentId == usertab.spillid);
        //                    introducer = introdd.uid;
        //                    var introdetail = db.AgentDetails.Single(a => a.uid == introducer);
        //                    genology.id = introdd.uid;
        //                    genology.newid = introdetail.NewAgentId;
        //                    genology.position = usertab.position;
        //                    genology.cust_id = uid1;

        //                    genology.rank = 25;
        //                    genology.join_date = DateTime.Now.Date;
        //                    genology.rs = 3000;
        //                    genology.paid_status = 0;
        //                    genology.paid_status_level = 0;
        //                    db.genology_tabs.Add(genology);
        //                    db.SaveChanges();
        //                    custid = introducer;
        //                }



        //                MyClass.Sendmsg(model.mobile, "Dear " + model.name + " you are successfully registered with " + comp.WebContactNo + " .Your Login Id is " + FillLogin.userid + " password is " + FillLogin.password + ".Thanks n regards " + comp.CompanyName + "");
        //                TempData["msg"] = "Registered Successfully. Member Login Id is " + FillLogin.userid + " password is " + FillLogin.password + ".Thanks and regards " + comp.CompanyName + "";
        //                TempData["spilnew"] = spilid;
        //                return RedirectToAction("Successfully", "Member");

        //            }
        //            else
        //            {
        //                TempData["msg"] = "Invalid introducerid";
        //                ViewBag.msg = "This Introducer Id Invalid";
        //            }
        //        }
        //        else
        //        {
        //            TempData["msg"] = "You are not Registered Due to Some thing is wrong, Invalid introducer id or already used this Agent Id or already used pin";
        //            return RedirectToAction("Successfully", "Member");
        //        }
        //        return RedirectToAction("Successfully", "Member");
        //    }

        //}

        [HttpGet]
        public ActionResult ochange_pwd()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            ViewData["msg"] = "";
            return View();
        }
        [HttpPost]
        public ActionResult ochange_pwd(string oldpwd, string newpwd, string conpwd)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {

                var lgn = db.NewLogins.Single(a => a.UserName == User.Identity.Name);
                if (lgn.Password == oldpwd)
                {
                    if (newpwd == conpwd)
                    {
                        lgn.Password = newpwd;
                        db.Entry(lgn).State = EntityState.Modified;
                        db.SaveChanges();
                        ViewData["msg"] = "Old Password Changed Successfully ";
                        Response.Write("<script>alert('Old Password Changed Successfully !')</script>");

                    }
                    else
                    {

                        ViewData["msg"] = "Oh! Confirm Password doesn't Match";
                        Response.Write("<script>alert('Oh! Confirm Password doesn't Match !')</script>");
                    }
                }
                else
                {
                    ViewData["msg"] = "Oh! Old Password doesn't Match ";
                    Response.Write("<script>alert('Oh! Old Password doesn't Match !')</script>");
                }


            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");

        }
        #endregion

        #region E Wallet

        [HttpGet]
        public ActionResult Ewallet()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult EwalletWithdrawal()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                ViewData["msg"] = TempData["msg"];
                return View();
            }

        }
        [HttpPost]
        public ActionResult EwalletWithdrawal(float amount = 0, float netamount = 0, float tds = 0)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                //  var payout="PAYOUT-";
                var memberinfo = db.AgentDetails.Single(a => a.NewAgentId == User.Identity.Name);
                //var introid = db.AgentDetails.Single(b => b.Id == memberinfo.introducerid);
                // var transaction = (from x in db.TransactionTabs where x.accountno == User.Identity.Name && x.remark.ToLower().Contains(payout.ToLower()) select x.Id ).Max();
                Double ewalletbalance = db.wallettabs.Single(bb => bb.UserId == User.Identity.Name).amount;

                if (amount <= ewalletbalance)
                {
                    if (amount >= 1000)
                    {
                        var user = db.AgentDetails.Single(a => a.NewAgentId == User.Identity.Name);

                        WithdrawalRequest wr = new WithdrawalRequest();

                        wr.introid = user.AgencyCode;
                        wr.intronewid = user.NewAgentId;
                        wr.Request_Date = DateTime.Now.Date;
                        wr.Amount = amount;
                        wr.NetAmount = netamount;
                        wr.tds = tds;
                        wr.Request_Completed_Date = DateTime.Now.Date;
                        wr.Status = 0;

                        db.WithdrawalRequests.Add(wr);
                        db.SaveChanges();

                        //---------------------------------- Wallet Tabs --------------------------------------

                        var wallet = db.wallettabs.Single(aa => aa.UserId == User.Identity.Name);
                        double totalamount = wallet.amount - amount;
                        wallet.amount = totalamount;
                        db.Entry(wallet).State = EntityState.Modified;
                        db.SaveChanges();

                        //---------------------------------- Wallet Tabs --------------------------------------

                        //---------------------- TransactionTab Update ------------------------------------

                        var j = db.TransactionTabs.Where(s => s.accountno == user.NewAgentId).Count();

                        TransactionTab ad = new TransactionTab();
                        string aaa = gid();
                        ad.transactionid = aaa;

                        ad.accountno = user.NewAgentId;

                        ad.acholdername = user.name;
                        ad.paymethod = "Transfer";
                        ad.pdate = DateTime.Now.Date;
                        ad.checkorddno = "NA";
                        ad.drawon = "NA";
                        ad.credit = 0;
                        ad.debit = netamount;
                        ad.balance = wallet.amount;
                        ad.remark = "Withdrawal Request";
                        ad.opid = User.Identity.Name;
                        ad.status = (j + 1);
                        ad.type = "Debit";
                        ad.Time = DateTime.Now.ToShortTimeString();
                        //ad.creditaccount = "NA";

                        db.TransactionTabs.Add(ad);
                        db.SaveChanges();

                        //------------------------------------------------------------------------------------

                        TempData["msg"] = "Withdrawl Request Send Successfully !";
                        Response.Write("<script>alert('Withdrawal Request Send Successfully !')</script>");
                    }
                    else
                    {
                        TempData["msg"] = "Minimum withdrawal Rs. 500/-";
                        Response.Write("<script>alert('Minimum withdrawal Rs. 500/- !')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('You have insufficent Balance !')</script>");
                }
                return View();
            }

        }

        [HttpGet]
        public ActionResult EwalletWithdrawalHistory(int? page)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                WithdrawalRequest objStudent = new WithdrawalRequest();
                List<WithdrawalRequest> tempwithral = new List<WithdrawalRequest>();
                SqlConnection con = new SqlConnection();
                DataSet ds = new DataSet();

                int pageSize = 50;
                int pageIndex = 1;
                pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
                ViewData["pageno"] = pageIndex;
                int akhiri = (pageIndex - 1) * 50;
                ViewData["srno"] = akhiri;
                IPagedList<WithdrawalRequest> stu = null;
                SqlCommand cmd = new SqlCommand();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "select * from WithdrawalRequest where intronewid='" + User.Identity.Name + "'";
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            tempwithral.Add(new WithdrawalRequest
                            {

                                NetAmount = Convert.ToSingle(item["NetAmount"]),
                                Amount = Convert.ToInt32(item["Amount"]),
                                tds = Convert.ToInt32(item["tds"]),
                                Request_Date = Convert.ToDateTime(item["Request_Date"]),
                                Status = Convert.ToInt32(item["Status"])

                            });
                        }

                    }
                }

                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                }
                finally
                {
                    con.Close();
                }
                stu = tempwithral.ToPagedList(pageIndex, pageSize);
                return View(stu);
            }

        }

        //[HttpGet]
        //public ActionResult wallet_to_wallet_trans()
        //{
        //    if (!User.Identity.IsAuthenticated)
        //    {
        //        return RedirectToAction("Logout", "Member");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
        //[HttpPost]
        //public ActionResult wallet_to_wallet_trans(double amount, string Tomemberid)
        //{
        //    if (!User.Identity.IsAuthenticated)
        //    {
        //        return RedirectToAction("Logout", "Member");
        //    }
        //    else
        //    {
        //        var wcamt = (from a in db.wallettabs where a.UserId == User.Identity.Name select a.amount).DefaultIfEmpty(0).Sum();

        //        var totamt = wcamt;
        //        var Fromacnt = db.AgentDetails.Single(a => a.NewAgentId == User.Identity.Name);
        //        var Toacnt = db.AgentDetails.Single(a => a.NewAgentId == Tomemberid);
        //        var balance = (wcamt - amount);
        //        var tfstatus = 0;
        //        if (amount > 0)
        //        {
        //            if (balance > 0)
        //            {
        //                var j = db.TransactionTabs.Where(s => s.accountno == Fromacnt.NewAgentId).Count();
        //                TransactionTab ad = new TransactionTab();
        //                string aaa = gid();
        //                ad.transactionid = aaa;

        //                ad.accountno = User.Identity.Name; ;

        //                ad.acholdername = Fromacnt.name;
        //                ad.paymethod = "Transfer";
        //                ad.pdate = DateTime.Now.Date;
        //                ad.checkorddno = "NA";
        //                ad.drawon = "NA";
        //                ad.credit = 0;
        //                ad.debit = amount;
        //                ad.balance = balance;
        //                ad.remark = "Amount Transfer To " + Toacnt.NewAgentId;
        //                ad.opid = User.Identity.Name;
        //                ad.status = (j + 1);
        //                ad.type = "Debit";
        //                ad.Time = DateTime.Now.ToShortTimeString();
        //                ad.creditaccount = "NA";

        //                db.TransactionTabs.Add(ad);
        //                db.SaveChanges();

        //                var wallet = db.wallettabs.Single(aa => aa.UserId == User.Identity.Name);

        //                double totalamount = wallet.amount - amount;

        //                wallet.amount = totalamount;

        //                db.Entry(wallet).State = EntityState.Modified;
        //                db.SaveChanges();

        //                tfstatus = 1;
        //                MyClass.Sendmsg(Fromacnt.mobile, "Your A/c xxxxxx" + Fromacnt.NewAgentId.Substring(Fromacnt.NewAgentId.Length - 4, 4) + " debited with INR " + amount + " on " + DateTime.Now.Date.ToString("dd/MM/yyyy") + "- Remark-Avl Bal. INR " + balance + ", For more details Visit plan2.pragatigreensales.com");
        //                var aaaaa = Fromacnt.NewAgentId.Substring(Fromacnt.NewAgentId.Length - 4, 4);
        //                if (tfstatus == 1)
        //                {
        //                    //var twcamt = (from r in db.TransactionTabs where r.accountno == Tomemberid select r.credit).DefaultIfEmpty(0).Sum();
        //                    //var twdamt = (from r in db.TransactionTabs where r.accountno == Tomemberid select r.debit).DefaultIfEmpty(0).Sum();
        //                    //var tttotamt = twcamt - twdamt;
        //                    var towcamt = (from a in db.wallettabs where a.UserId == Tomemberid select a.amount).DefaultIfEmpty(0).Sum();
        //                    var k = db.TransactionTabs.Where(s => s.accountno == Toacnt.memberid).Count();
        //                    TransactionTab ad1 = new TransactionTab();
        //                    // string aaa1 = gid();
        //                    ad1.transactionid = aaa;

        //                    ad1.accountno = Tomemberid; ;

        //                    ad1.acholdername = Toacnt.name;
        //                    ad1.paymethod = "Transfer";
        //                    ad1.pdate = DateTime.Now.Date;
        //                    ad1.checkorddno = "NA";
        //                    ad1.drawon = "NA";
        //                    ad1.credit = amount;
        //                    ad1.debit = 0;
        //                    ad1.balance = (towcamt + amount);
        //                    ad1.remark = "Amount Credit From Acc/o " + User.Identity.Name;
        //                    ad1.opid = User.Identity.Name;
        //                    ad1.status = (k + 1);
        //                    ad1.type = "Credit";
        //                    ad1.Time = DateTime.Now.ToShortTimeString();
        //                    ad1.creditaccount = amount.ToString();

        //                    db.TransactionTabs.Add(ad1);
        //                    db.SaveChanges();

        //                    var wallet2 = db.wallettabs.Single(aa => aa.UserId == Tomemberid);

        //                    double totalamount2 = wallet2.amount + amount;

        //                    wallet2.amount = totalamount2;

        //                    db.Entry(wallet2).State = EntityState.Modified;
        //                    db.SaveChanges();



        //                    MyClass.Sendmsg(Toacnt.mobile, "Your A/c xxxxxx" + Toacnt.NewAgentId.Substring(Toacnt.NewAgentId.Length - 4, 4) + " credit with INR " + amount + " on " + DateTime.Now.Date.ToString("dd/MM/yyyy") + "- Remark-Avl Bal. INR " + (towcamt + amount) + ", For more details Visit plan2.pragatigreensales.com");

        //                    Response.Write("<script>alert('!! Wallet To Wallet amount transfer successfully ')</script>");
        //                }



        //            }
        //            else
        //            {
        //                Response.Write("<script>alert('!!Sorry You have insufficient Balance ')</script>");
        //            }
        //        }
        //        else
        //        {
        //            Response.Write("<script>alert('!!Sorry Must Transfer more than 0 Balance ')</script>");
        //        }

        //        return View();
        //    }
        //}

        public ActionResult Pintransferhistory()
        {
            return View();
        }

        #endregion

        [HttpGet]
        public ActionResult Pintransfer()
        {
            ViewData["assign"] = TempData["assign"];
            return View();
        }
        [HttpPost]
        public ActionResult Pintransfer(pintab pt, string NewAgentId, string pinamount, int noofpin)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("oLogout", "Admin");
            }
            else
            {
                pintab pt1 = new pintab();
                if (noofpin > 0)
                {
                    int pinno = Convert.ToInt32(noofpin);
                    int pinamt = db.pintabs.Where(a => a.pinamount == pt.pinamount && a.status == 0 && a.assignto == User.Identity.Name && a.mobile == null && a.email == null && (a.Createdby == User.Identity.Name || a.Createdby != User.Identity.Name)).Count();
                    if (pinamt == 0)
                    {
                        TempData["assign"] = "No Pin avalaible to assign";
                    }
                    else if (pinamt < pinno)
                    {
                        TempData["assign"] = "No of Pin avalaible to assign are less than required";
                    }
                    else if (pinno <= pinamt)
                    {
                        int n = 0;
                        while (n < pinno)
                        {
                            var pindo = (from a in db.pintabs where a.pinamount == pt.pinamount && a.status == 0 && a.assignto == User.Identity.Name && a.mobile == null && a.email == null && (a.Createdby == User.Identity.Name || a.Createdby != User.Identity.Name) select a.pin).Min();
                            var pindi = db.pintabs.Single(a => a.pinamount == pt.pinamount && a.status == 0 && a.assignto == User.Identity.Name && a.mobile == null && a.email == null && (a.Createdby == User.Identity.Name || a.Createdby != User.Identity.Name) && a.pin == pindo);
                            pindi.assignto = NewAgentId;
                            pindi.Assigndate = DateTime.Now.Date;
                            db.Entry(pindi).State = EntityState.Modified;
                            db.SaveChanges();
                            n = n + 1;
                        }

                        Transfer_Pin tp = new Transfer_Pin();
                        tp.Total_Pin = noofpin.ToString();
                        tp.Transfer_By = User.Identity.Name;
                        tp.Transfer_To = NewAgentId;

                        tp.Date = DateTime.Now;
                        db.Transfer_Pins.Add(tp);
                        db.SaveChanges();
                        TempData["assign"] = "Pin assigned successfully";


                    }
                    return RedirectToAction("Pintransfer", "Member");
                }
                else
                {
                    TempData["assign"] = "Invalid Pin";
                    return RedirectToAction("Pintransfer", "Member");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult PoolBtree(string newid, string aa)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                List<Downline1> down = new List<Downline1>();
                int lcount = (from n in db.NewLogins where n.UserName == User.Identity.Name select n.UserName).Count();
                if (lcount == 1)
                {
                    var log = db.NewLogins.Single(a => a.UserName == User.Identity.Name);
                    if (log.status == 1 && log.type == "Member")
                    {
                        if (newid == null)
                        {
                            newid = User.Identity.Name;
                            ViewData["cmid"] = newid;
                        }
                        //SqlCommand cmd = new SqlCommand();
                        //SqlConnection con = new SqlConnection();
                        //con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                        //cmd.Connection = con;
                        //SqlDataReader sdr;
                        //cmd.CommandText = "Treedetails";
                        //cmd.Parameters.AddWithValue("@memberid", newid);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //try
                        //{
                        //    con.Open();
                        //    sdr = cmd.ExecuteReader();
                        //    if (sdr.HasRows)
                        //    {
                        //        while (sdr.Read())
                        //        {

                        //            ViewData["directactive"] = sdr["directactive"];
                        //            ViewData["directinactive"] = sdr["directinactive"];
                        //            ViewData["directtotal"] = sdr["directtotal"];
                        //            ViewData["genoleftactive"] = sdr["genoleftactive"];
                        //            ViewData["genoleftinactive"] = sdr["genoleftinactive"];
                        //            ViewData["genorightactive"] = sdr["genorightactive"];
                        //            ViewData["genorightinactive"] = sdr["genorightinactive"];
                        //            ViewData["genoleft"] = sdr["genoleft"];
                        //            ViewData["genoright"] = sdr["genoright"];
                        //            ViewData["totalactive"] = sdr["totalactive"];
                        //            ViewData["totalinactive"] = sdr["totalinactive"];
                        //            ViewData["totalmember"] = sdr["totalmember"];
                        //            ViewData["binaryactive"] = sdr["binaryactive"];
                        //            ViewData["binaryinactive"] = sdr["binaryinactive"];
                        //            ViewData["binarytotal"] = sdr["binarytotal"];

                        //        }
                        //    }
                        //}

                        //catch (Exception ex)
                        //{
                        //    Response.Write("<script>alert('" + ex.Message + "')</script>");
                        //}
                        //finally
                        //{
                        //    con.Close();
                        //}
                        var MainId = "Not Present";
                        var MainName = "Not Present";
                        var LeftId = "Not Present";
                        var LeftName = "Not Present";
                        var RightId = "Not Present";
                        var RightName = "Not Present";
                        var LeftLeftId = "Not Present";
                        var LeftLeftName = "Not Present";
                        var LeftRightId = "Not Present";
                        var LeftRightName = "Not Present";
                        var RightRightId = "Not Present";
                        var RightRightName = "Not Present";
                        var RightLeftId = "Not Present";
                        var RightLeftName = "Not Present";
                        var LLLId = "Not Present";
                        var LLLName = "Not Present";
                        var LLRId = "Not Present";
                        var LLRName = "Not Present";
                        var LRLName = "Not Present";
                        var LRLId = "Not Present";
                        var LRRId = "Not Present";
                        var LRRName = "Not Present";
                        var RLLId = "Not Present";
                        var RLLName = "Not Present";
                        var RLRId = "Not Present";
                        var RLRName = "Not Present";
                        var RRLId = "Not Present";
                        var RRLName = "Not Present";
                        var RRRId = "Not Present";
                        var RRRName = "Not Present";

                        var Mprofile = string.Empty;
                        var Lprofile = string.Empty;
                        var Rprofile = string.Empty;
                        var LLprofile = string.Empty;
                        var LRprofile = string.Empty;
                        var RLprofile = string.Empty;
                        var RRprofile = string.Empty;
                        var LLLprofile = string.Empty;
                        var LLRprofile = string.Empty;
                        var LRLprofile = string.Empty;
                        var LRRprofile = string.Empty;
                        var RLLprofile = string.Empty;
                        var RLRprofile = string.Empty;
                        var RRLprofile = string.Empty;
                        var RRRprofile = string.Empty;



                        if (!User.Identity.IsAuthenticated)
                        {
                            return RedirectToAction("Home", "Login");
                        }
                        else
                        {

                            var count = db.AgentDetails.Where(a => a.NewAgentId == newid).Count();
                            if (count == 1)
                            {
                                #region Select Main Id and Name
                                var user = db.AgentDetails.Single(a => a.NewAgentId == newid);
                                var binary = db.binary2s.Single(a => a.Id == user.uid);
                                MainId = user.NewAgentId;
                                MainName = user.name;

                                if (user.Status == 1)
                                {
                                    Mprofile = "~/Images/star/green.png";
                                }
                                else
                                {
                                    Mprofile = "~/Images/star/red.png";
                                }

                                #endregion Select Main Id and Name

                                if (binary.lperson == 1)
                                {
                                    //-----------Select Left Id and Name
                                    var user1 = db.AgentDetails.Single(a => a.uid == binary.downleft);
                                    var binary1 = db.binary2s.Single(a => a.Id == binary.downleft);
                                    LeftId = user1.NewAgentId;
                                    LeftName = user1.name;


                                    if (user1.Status == 1)
                                    {
                                        Lprofile = "~/Images/star/green.png";
                                    }
                                    else
                                    {
                                        Lprofile = "~/Images/star/red.png";
                                    }
                                    //-----------End Select Left Id and Name
                                    if (binary1.lperson == 1)
                                    {
                                        //-----------Select Left Ki left Id and Name
                                        var user2 = db.AgentDetails.Single(a => a.uid == binary1.downleft);
                                        var binary2 = db.binary2s.Single(a => a.Id == binary1.downleft);
                                        LeftLeftId = user2.NewAgentId;
                                        LeftLeftName = user2.name;

                                        if (user2.Status == 1)
                                        {
                                            LLprofile = "~/Images/star/green.png";
                                        }
                                        else
                                        {
                                            LLprofile = "~/Images/star/red.png";
                                        }
                                        //-----------End Select Left Ki left Id and Name


                                        if (binary2.lperson == 1)
                                        {
                                            //-----------Select LLL Id and Name
                                            var llluser = db.AgentDetails.Single(a => a.uid == binary2.downleft);
                                            var lllbinary = db.binary2s.Single(a => a.Id == binary2.downleft);
                                            LLLId = llluser.NewAgentId;
                                            LLLName = llluser.name;

                                            if (llluser.Status == 1)
                                            {
                                                LLLprofile = "~/Images/star/green.png";
                                            }
                                            else
                                            {
                                                LLLprofile = "~/Images/star/red.png";
                                            }
                                            //-----------End Select LLL Id and Name
                                        }
                                        else
                                        {
                                            LLLId = "Not Present";
                                            LLLName = "Not Present";
                                        }



                                        if (binary2.rperson == 1)
                                        {
                                            //-----------Select LLR Id and Name

                                            var llRuser = db.AgentDetails.Single(a => a.uid == binary2.downright);
                                            var llRbinary = db.binary2s.Single(a => a.Id == binary2.downright);
                                            LLRId = llRuser.NewAgentId;
                                            LLRName = llRuser.name;

                                            if (llRuser.Status == 1)
                                            {
                                                LLRprofile = "~/Images/star/green.png";
                                            }
                                            else
                                            {
                                                LLRprofile = "~/Images/star/red.png";
                                            }

                                            //-----------Select LLR Id and Name
                                        }
                                        else
                                        {
                                            LLRId = "Not Present";
                                            LLRName = "Not Present";
                                        }


                                    }
                                    else
                                    {
                                        LeftLeftId = "Not Present";
                                        LeftLeftName = "Not Present";
                                    }
                                    if (binary1.rperson == 1)
                                    {
                                        //-----------Select Left Ki Right Id and Name

                                        var user2 = db.AgentDetails.Single(a => a.uid == binary1.downright);
                                        var binary2 = db.binary2s.Single(a => a.Id == binary1.downright);
                                        LeftRightId = user2.NewAgentId;
                                        LeftRightName = user2.name;

                                        if (user2.Status == 1)
                                        {
                                            LRprofile = "~/Images/star/green.png";
                                        }
                                        else
                                        {
                                            LRprofile = "~/Images/star/red.png";
                                        }

                                        //-----------End Select Left Ki Right Id and Name



                                        if (binary2.lperson == 1)
                                        {
                                            //-----------Select LRL Id and Name
                                            var LRLuser = db.AgentDetails.Single(a => a.uid == binary2.downleft);
                                            var LRLbinary = db.binary2s.Single(a => a.Id == binary2.downleft);
                                            LRLId = LRLuser.NewAgentId;
                                            LRLName = LRLuser.name;

                                            if (LRLuser.Status == 1)
                                            {
                                                LRLprofile = "~/Images/star/green.png";
                                            }
                                            else
                                            {
                                                LRLprofile = "~/Images/star/red.png";
                                            }
                                            //-----------End Select LRL Id and Name

                                        }
                                        else
                                        {
                                            LRLId = "Not Present";
                                            LRLName = "Not Present";
                                        }


                                        if (binary2.rperson == 1)
                                        {
                                            //-----------Select LRR Id and Name

                                            var LRRuser = db.AgentDetails.Single(a => a.uid == binary2.downright);
                                            var LRRbinary = db.binary2s.Single(a => a.Id == binary2.downright);
                                            LRRId = LRRuser.NewAgentId;
                                            LRRName = LRRuser.name;


                                            if (LRRuser.Status == 1)
                                            {
                                                LRRprofile = "~/Images/star/green.png";
                                            }
                                            else
                                            {
                                                LRRprofile = "~/Images/star/red.png";
                                            }

                                            //-----------End Select LRR Id and Name

                                        }
                                        else
                                        {
                                            LRRId = "Not Present";
                                            LRRName = "Not Present";
                                        }

                                    }
                                    else
                                    {
                                        LeftRightId = "Not Present";
                                        LeftRightName = "Not Present";
                                    }
                                }
                                else
                                {
                                    LeftId = "Not Present";
                                    LeftName = "Not Present";
                                }
                                if (binary.rperson == 1)
                                {
                                    //-----------Select Right Id and Name
                                    var user1 = db.AgentDetails.Single(a => a.uid == binary.downright);
                                    var binary1 = db.binary2s.Single(a => a.Id == binary.downright);
                                    RightId = user1.NewAgentId;
                                    RightName = user1.name;

                                    if (user1.Status == 1)
                                    {
                                        Rprofile = "~/Images/star/green.png";
                                    }
                                    else
                                    {
                                        Rprofile = "~/Images/star/red.png";
                                    }
                                    //-----------End Select Right Id and Name
                                    if (binary1.lperson == 1)
                                    {
                                        //-----------Select Right Ki Left Id and Name
                                        var user2 = db.AgentDetails.Single(a => a.uid == binary1.downleft);
                                        var binary2 = db.binary2s.Single(a => a.Id == binary1.downleft);
                                        RightLeftId = user2.NewAgentId;
                                        RightLeftName = user2.name;

                                        if (user2.Status == 1)
                                        {
                                            RLprofile = "~/Images/star/green.png";
                                        }
                                        else
                                        {
                                            RLprofile = "~/Images/star/red.png";
                                        }
                                        //-----------Select Right Ki Left Id and Name

                                        if (binary2.lperson == 1)
                                        {
                                            //-----------Select RLL Id and Name

                                            var RLLuser = db.AgentDetails.Single(a => a.uid == binary2.downleft);
                                            var RLLbinary = db.binary2s.Single(a => a.Id == binary2.downleft);
                                            RLLId = RLLuser.NewAgentId;
                                            RLLName = RLLuser.name;

                                            if (RLLuser.Status == 1)
                                            {
                                                RLLprofile = "~/Images/star/green.png";
                                            }
                                            else
                                            {
                                                RLLprofile = "~/Images/star/red.png";
                                            }

                                            //-----------End Select RLL Id and Name

                                        }
                                        else
                                        {
                                            RLLId = "Not Present";
                                            RLLName = "Not Present";
                                        }

                                        if (binary2.rperson == 1)
                                        {
                                            //-----------Select RLR Id and Name

                                            var RLRuser = db.AgentDetails.Single(a => a.uid == binary2.downright);
                                            var RLRbinary = db.binary2s.Single(a => a.Id == binary2.downright);
                                            RLRId = RLRuser.NewAgentId;
                                            RLRName = RLRuser.name;

                                            if (RLRuser.Status == 1)
                                            {
                                                RLRprofile = "~/Images/star/green.png";
                                            }
                                            else
                                            {
                                                RLRprofile = "~/Images/star/red.png";
                                            }

                                            //-----------End Select RLR Id and Name
                                        }
                                        else
                                        {
                                            RLRId = "Not Present";
                                            RLRName = "Not Present";
                                        }

                                    }
                                    else
                                    {
                                        RightLeftId = "Not Present";
                                        RightLeftName = "Not Present";
                                    }
                                    if (binary1.rperson == 1)
                                    {
                                        //-----------Select Right Ki Right Id and Name

                                        var user2 = db.AgentDetails.Single(a => a.uid == binary1.downright);
                                        var binary2 = db.binary2s.Single(a => a.Id == binary1.downright);
                                        RightRightId = user2.NewAgentId;
                                        RightRightName = user2.name;

                                        if (user2.Status == 1)
                                        {
                                            RRprofile = "~/Images/star/green.png";
                                        }
                                        else
                                        {
                                            RRprofile = "~/Images/star/red.png";
                                        }

                                        //-----------Select Right Ki Right Id and Name


                                        if (binary2.lperson == 1)
                                        {
                                            //-----------Select RRL Id and Name

                                            var RRluser = db.AgentDetails.Single(a => a.uid == binary2.downleft);
                                            var RRLbinary = db.binary2s.Single(a => a.Id == binary2.downleft);
                                            RRLId = RRluser.NewAgentId;
                                            RRLName = RRluser.name;

                                            if (RRluser.Status == 1)
                                            {
                                                RRLprofile = "~/Images/star/green.png";
                                            }
                                            else
                                            {
                                                RRLprofile = "~/Images/star/red.png";
                                            }

                                            //-----------End Select RRL Id and Name
                                        }
                                        else
                                        {
                                            RRLId = "Not Present";
                                            RRLName = "Not Present";
                                        }

                                        if (binary2.rperson == 1)
                                        {
                                            //-----------Select RRR Id and Name

                                            var RRRuser = db.AgentDetails.Single(a => a.uid == binary2.downright);
                                            var RRRbinary = db.binary2s.Single(a => a.Id == binary2.downright);
                                            RRRId = RRRuser.NewAgentId;
                                            RRRName = RRRuser.name;

                                            if (RRRuser.Status == 1)
                                            {
                                                RRRprofile = "~/Images/star/green.png";
                                            }
                                            else
                                            {
                                                RRRprofile = "~/Images/star/red.png";
                                            }

                                            //-----------End Select RRR Id and Name
                                        }
                                        else
                                        {
                                            RRLId = "Not Present";
                                            RRLName = "Not Present";
                                        }

                                    }
                                    else
                                    {
                                        RightRightId = "Not Present";
                                        RightRightName = "Not Present";
                                    }

                                }
                                else
                                {
                                    RightId = "Not Present";
                                    RightName = "Not Present";
                                }

                            }
                            else
                            {
                                MainId = "Not Present";
                                MainName = "Not Present";
                            }
                            down.Add(new Downline1
                            {

                                MainId = MainId,
                                MainName = MainName,
                                LeftId = LeftId,
                                LeftName = LeftName,
                                RightId = RightId,
                                RightName = RightName,
                                LeftLeftId = LeftLeftId,
                                LeftLeftName = LeftLeftName,
                                LeftRightId = LeftRightId,
                                LeftRightName = LeftRightName,
                                RightRightId = RightRightId,
                                RightRightName = RightRightName,
                                RightLeftId = RightLeftId,
                                RightLeftName = RightLeftName,
                                LLLId = LLLId,
                                LLLName = LLLName,
                                LLRId = LLRId,
                                LLRName = LLRName,
                                LRLId = LRLId,
                                LRLName = LRLName,
                                LRRId = LRRId,
                                LRRName = LRRName,
                                RLLId = RLLId,
                                RLLName = RLLName,
                                RLRId = RLRId,
                                RLRName = RLRName,
                                RRLId = RRLId,
                                RRLName = RRLName,
                                RRRId = RRRId,
                                RRRName = RRRName,
                                Mprofile = Mprofile,
                                Lprofile = Lprofile,
                                Rprofile = Rprofile,
                                LRprofile = LRprofile,
                                LLprofile = LLprofile,
                                RRprofile = RRprofile,
                                RLprofile = RLprofile,
                                LLLprofile = LLLprofile,
                                LLRprofile = LLRprofile,
                                LRLprofile = LRLprofile,
                                LRRprofile = LRRprofile,
                                RLLprofile = RLLprofile,
                                RLRprofile = RLRprofile,
                                RRLprofile = RRLprofile,
                                RRRprofile = RRRprofile

                            });
                        }
                        ViewData["cmid"] = newid;
                        return View(down);


                    }
                    else
                    {
                        return RedirectToAction("Logout", "Member");
                    }
                }
                else
                {
                    return RedirectToAction("Logout", "Member");
                }
                ViewData["cmid"] = newid;
                return View(down);
            }

        }
        [HttpPost]
        public ActionResult PoolBtree(string newid)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                List<Downline1> down = new List<Downline1>();
                if (newid == null)
                {
                    newid = db.AgentDetails.FirstOrDefault().NewAgentId;
                }
                var c = db.AgentDetails.Where(a => a.NewAgentId == newid).Count();
                if (c == 1)
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    cmd.Connection = con;
                    SqlDataReader sdr;
                    cmd.CommandText = "Treedetails";
                    cmd.Parameters.AddWithValue("@memberid", newid);
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        if (sdr.HasRows)
                        {
                            while (sdr.Read())
                            {

                                ViewData["directactive"] = sdr["directactive"];
                                ViewData["directinactive"] = sdr["directinactive"];
                                ViewData["directtotal"] = sdr["directtotal"];
                                ViewData["genoleftactive"] = sdr["genoleftactive"];
                                ViewData["genoleftinactive"] = sdr["genoleftinactive"];
                                ViewData["genorightactive"] = sdr["genorightactive"];
                                ViewData["genorightinactive"] = sdr["genorightinactive"];
                                ViewData["genoleft"] = sdr["genoleft"];
                                ViewData["genoright"] = sdr["genoright"];
                                ViewData["totalactive"] = sdr["totalactive"];
                                ViewData["totalinactive"] = sdr["totalinactive"];
                                ViewData["totalmember"] = sdr["totalmember"];
                                ViewData["binaryactive"] = sdr["binaryactive"];
                                ViewData["binaryinactive"] = sdr["binaryinactive"];
                                ViewData["binarytotal"] = sdr["binarytotal"];

                            }
                        }
                    }

                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('" + ex.Message + "')</script>");
                    }
                    finally
                    {
                        con.Close();
                    }
                    var MainId = "Not Present";
                    var MainName = "Not Present";
                    var LeftId = "Not Present";
                    var LeftName = "Not Present";
                    var RightId = "Not Present";
                    var RightName = "Not Present";
                    var LeftLeftId = "Not Present";
                    var LeftLeftName = "Not Present";
                    var LeftRightId = "Not Present";
                    var LeftRightName = "Not Present";
                    var RightRightId = "Not Present";
                    var RightRightName = "Not Present";
                    var RightLeftId = "Not Present";
                    var RightLeftName = "Not Present";
                    var Mprofile = string.Empty;
                    var Lprofile = string.Empty;
                    var Rprofile = string.Empty;
                    var LLprofile = string.Empty;
                    var LRprofile = string.Empty;
                    var RLprofile = string.Empty;
                    var RRprofile = string.Empty;
                    var LLLId = "Not Present";
                    var LLLName = "Not Present";
                    var LLRId = "Not Present";
                    var LLRName = "Not Present";
                    var LRLName = "Not Present";
                    var LRLId = "Not Present";
                    var LRRId = "Not Present";
                    var LRRName = "Not Present";
                    var RLLId = "Not Present";
                    var RLLName = "Not Present";
                    var RLRId = "Not Present";
                    var RLRName = "Not Present";
                    var RRLId = "Not Present";
                    var RRLName = "Not Present";
                    var RRRId = "Not Present";
                    var RRRName = "Not Present";
                    var LLLprofile = string.Empty;
                    var LLRprofile = string.Empty;
                    var LRLprofile = string.Empty;
                    var LRRprofile = string.Empty;
                    var RLLprofile = string.Empty;
                    var RLRprofile = string.Empty;
                    var RRLprofile = string.Empty;
                    var RRRprofile = string.Empty;


                    if (!User.Identity.IsAuthenticated)
                    {
                        return RedirectToAction("Home", "Login");
                    }
                    else
                    {

                        var count = db.AgentDetails.Where(a => a.NewAgentId == newid).Count();
                        if (count == 1)
                        {
                            //-----------Select Main Id and Name
                            var user = db.AgentDetails.Single(a => a.NewAgentId == newid);
                            var binary = db.binary2s.Single(a => a.Id == user.uid);
                            MainId = user.NewAgentId;
                            MainName = user.name;
                            if (user.Status == 1)
                            {
                                Mprofile = "~/Images/star/green.png";
                            }
                            else
                            {
                                Mprofile = "~/Images/star/red.png";
                            }

                            //-----------End Select Main Id and Name
                            if (binary.lperson == 1)
                            {
                                //-----------Select Left Id and Name
                                var user1 = db.AgentDetails.Single(a => a.uid == binary.downleft);
                                var binary1 = db.binary2s.Single(a => a.Id == binary.downleft);
                                LeftId = user1.NewAgentId;
                                LeftName = user1.name;

                                if (user1.Status == 1)
                                {
                                    Lprofile = "~/Images/star/green.png";
                                }
                                else
                                {
                                    Lprofile = "~/Images/star/red.png";
                                }
                                //-----------End Select Left Id and Name
                                if (binary1.lperson == 1)
                                {
                                    //-----------Select Left Ki left Id and Name
                                    var user2 = db.AgentDetails.Single(a => a.uid == binary1.downleft);
                                    var binary2 = db.binary2s.Single(a => a.Id == binary1.downleft);
                                    LeftLeftId = user2.NewAgentId;
                                    LeftLeftName = user2.name;

                                    if (user2.Status == 1)
                                    {
                                        LLprofile = "~/Images/star/green.png";
                                    }
                                    else
                                    {
                                        LLprofile = "~/Images/star/red.png";
                                    }
                                    //-----------End Select Left Ki left Id and Name


                                    if (binary2.lperson == 1)
                                    {
                                        //-----------Select LLL Id and Name
                                        var llluser = db.AgentDetails.Single(a => a.uid == binary2.downleft);
                                        var lllbinary = db.binary2s.Single(a => a.Id == binary2.downleft);
                                        LLLId = llluser.NewAgentId;
                                        LLLName = llluser.name;


                                        if (llluser.Status == 1)
                                        {
                                            LLLprofile = "~/Images/star/green.png";
                                        }
                                        else
                                        {
                                            LLLprofile = "~/Images/star/red.png";
                                        }


                                        //-----------End Select LLL Id and Name
                                    }
                                    else
                                    {
                                        LLLId = "Not Present";
                                        LLLName = "Not Present";
                                    }


                                    if (binary2.rperson == 1)
                                    {
                                        //-----------Select LLR Id and Name

                                        var llRuser = db.AgentDetails.Single(a => a.uid == binary2.downright);
                                        var llRbinary = db.binary2s.Single(a => a.Id == binary2.downright);
                                        LLRId = llRuser.NewAgentId;
                                        LLRName = llRuser.name;


                                        if (llRuser.Status == 1)
                                        {
                                            LLRprofile = "~/Images/star/green.png";
                                        }
                                        else
                                        {
                                            LLRprofile = "~/Images/star/red.png";
                                        }



                                        //-----------Select LLR Id and Name
                                    }
                                    else
                                    {
                                        LLRId = "Not Present";
                                        LLRName = "Not Present";
                                    }



                                }
                                else
                                {
                                    LeftLeftId = "Not Present";
                                    LeftLeftName = "Not Present";
                                }
                                if (binary1.rperson == 1)
                                {
                                    //-----------Select Left Ki Right Id and Name
                                    var user2 = db.AgentDetails.Single(a => a.uid == binary1.downright);
                                    var binary2 = db.binary2s.Single(a => a.Id == binary1.downright);
                                    LeftRightId = user2.NewAgentId;
                                    LeftRightName = user2.name;

                                    if (user2.Status == 1)
                                    {
                                        LRprofile = "~/Images/star/green.png";
                                    }
                                    else
                                    {
                                        LRprofile = "~/Images/star/red.png";
                                    }
                                    //-----------End Select Left Ki Right Id and Name


                                    if (binary2.lperson == 1)
                                    {
                                        //-----------Select LRL Id and Name
                                        var LRLuser = db.AgentDetails.Single(a => a.uid == binary2.downleft);
                                        var LRLbinary = db.binary2s.Single(a => a.Id == binary2.downleft);
                                        LRLId = LRLuser.NewAgentId;
                                        LRLName = LRLuser.name;

                                        if (LRLuser.Status == 1)
                                        {
                                            LRLprofile = "~/Images/star/green.png";
                                        }
                                        else
                                        {
                                            LRLprofile = "~/Images/star/red.png";
                                        }
                                        //-----------End Select LRL Id and Name

                                    }
                                    else
                                    {
                                        LRLId = "Not Present";
                                        LRLName = "Not Present";
                                    }


                                    if (binary2.rperson == 1)
                                    {
                                        //-----------Select LRR Id and Name

                                        var LRRuser = db.AgentDetails.Single(a => a.uid == binary2.downright);
                                        var LRRbinary = db.binary2s.Single(a => a.Id == binary2.downright);
                                        LRRId = LRRuser.NewAgentId;
                                        LRRName = LRRuser.name;


                                        if (LRRuser.Status == 1)
                                        {
                                            LRRprofile = "~/Images/star/green.png";
                                        }
                                        else
                                        {
                                            LRRprofile = "~/Images/star/red.png";
                                        }

                                        //-----------End Select LRR Id and Name

                                    }
                                    else
                                    {
                                        LRRId = "Not Present";
                                        LRRName = "Not Present";
                                    }


                                }
                                else
                                {
                                    LeftRightId = "Not Present";
                                    LeftRightName = "Not Present";
                                }
                            }
                            else
                            {
                                LeftId = "Not Present";
                                LeftName = "Not Present";
                            }
                            if (binary.rperson == 1)
                            {
                                //-----------Select Right Id and Name
                                var user1 = db.AgentDetails.Single(a => a.uid == binary.downright);
                                var binary1 = db.binary2s.Single(a => a.Id == binary.downright);
                                RightId = user1.NewAgentId;
                                RightName = user1.name;



                                if (user1.Status == 1)
                                {
                                    Rprofile = "~/Images/star/green.png";
                                }
                                else
                                {
                                    Rprofile = "~/Images/star/red.png";
                                }
                                //-----------End Select Right Id and Name
                                if (binary1.lperson == 1)
                                {
                                    //-----------Select Right Ki Left Id and Name
                                    var user2 = db.AgentDetails.Single(a => a.uid == binary1.downleft);
                                    var binary2 = db.binary2s.Single(a => a.Id == binary1.downleft);
                                    RightLeftId = user2.NewAgentId;
                                    RightLeftName = user2.name;

                                    if (user2.Status == 1)
                                    {
                                        RLprofile = "~/Images/star/green.png";
                                    }
                                    else
                                    {
                                        RLprofile = "~/Images/star/red.png";
                                    }
                                    //-----------Select Right Ki Left Id and Name

                                    if (binary2.lperson == 1)
                                    {
                                        //-----------Select RLL Id and Name

                                        var RLLuser = db.AgentDetails.Single(a => a.uid == binary2.downleft);
                                        var RLLbinary = db.binary2s.Single(a => a.Id == binary2.downleft);
                                        RLLId = RLLuser.NewAgentId;
                                        RLLName = RLLuser.name;

                                        if (RLLuser.Status == 1)
                                        {
                                            RLLprofile = "~/Images/star/green.png";
                                        }
                                        else
                                        {
                                            RLLprofile = "~/Images/star/red.png";
                                        }

                                        //-----------End Select RLL Id and Name

                                    }
                                    else
                                    {
                                        RLLId = "Not Present";
                                        RLLName = "Not Present";
                                    }

                                    if (binary2.rperson == 1)
                                    {
                                        //-----------Select RLR Id and Name

                                        var RLRuser = db.AgentDetails.Single(a => a.uid == binary2.downright);
                                        var RLRbinary = db.binary2s.Single(a => a.Id == binary2.downright);
                                        RLRId = RLRuser.NewAgentId;
                                        RLRName = RLRuser.name;

                                        if (RLRuser.Status == 1)
                                        {
                                            RLRprofile = "~/Images/star/green.png";
                                        }
                                        else
                                        {
                                            RLRprofile = "~/Images/star/red.png";
                                        }

                                        //-----------End Select RLR Id and Name
                                    }
                                    else
                                    {
                                        RLRId = "Not Present";
                                        RLRName = "Not Present";
                                    }


                                }
                                else
                                {
                                    RightLeftId = "Not Present";
                                    RightLeftName = "Not Present";
                                }
                                if (binary1.rperson == 1)
                                {
                                    //-----------Select Right Ki Right Id and Name
                                    var user2 = db.AgentDetails.Single(a => a.uid == binary1.downright);
                                    var binary2 = db.binary2s.Single(a => a.Id == binary1.downright);
                                    RightRightId = user2.NewAgentId;
                                    RightRightName = user2.name;

                                    if (user2.Status == 1)
                                    {
                                        RRprofile = "~/Images/star/green.png";
                                    }
                                    else
                                    {
                                        RRprofile = "~/Images/star/red.png";
                                    }
                                    //-----------Select Right Ki Right Id and Name


                                    if (binary2.lperson == 1)
                                    {
                                        //-----------Select RRL Id and Name

                                        var RRluser = db.AgentDetails.Single(a => a.uid == binary2.downleft);
                                        var RRLbinary = db.binary2s.Single(a => a.Id == binary2.downleft);
                                        RRLId = RRluser.NewAgentId;
                                        RRLName = RRluser.name;

                                        if (RRluser.Status == 1)
                                        {
                                            RRLprofile = "~/Images/star/green.png";
                                        }
                                        else
                                        {
                                            RRLprofile = "~/Images/star/red.png";
                                        }

                                        //-----------End Select RRL Id and Name
                                    }
                                    else
                                    {
                                        RRLId = "Not Present";
                                        RRLName = "Not Present";
                                    }

                                    if (binary2.rperson == 1)
                                    {
                                        //-----------Select RRR Id and Name

                                        var RRRuser = db.AgentDetails.Single(a => a.uid == binary2.downright);
                                        var RRRbinary = db.binary2s.Single(a => a.Id == binary2.downright);
                                        RRRId = RRRuser.NewAgentId;
                                        RRRName = RRRuser.name;


                                        if (RRRuser.Status == 1)
                                        {
                                            RRRprofile = "~/Images/star/green.png";
                                        }
                                        else
                                        {
                                            RRRprofile = "~/Images/star/red.png";
                                        }

                                        //-----------End Select RRR Id and Name
                                    }
                                    else
                                    {
                                        RRLId = "Not Present";
                                        RRLName = "Not Present";
                                    }

                                }
                                else
                                {
                                    RightRightId = "Not Present";
                                    RightRightName = "Not Present";
                                }

                            }
                            else
                            {
                                RightId = "Not Present";
                                RightName = "Not Present";
                            }

                        }
                        else
                        {
                            MainId = "Not Present";
                            MainName = "Not Present";
                        }
                        down.Add(new Downline1
                        {

                            MainId = MainId,
                            MainName = MainName,
                            LeftId = LeftId,
                            LeftName = LeftName,
                            RightId = RightId,
                            RightName = RightName,
                            LeftLeftId = LeftLeftId,
                            LeftLeftName = LeftLeftName,
                            LeftRightId = LeftRightId,
                            LeftRightName = LeftRightName,
                            RightRightId = RightRightId,
                            RightRightName = RightRightName,
                            RightLeftId = RightLeftId,
                            RightLeftName = RightLeftName,
                            LLLId = LLLId,
                            LLLName = LLLName,
                            LLRId = LLRId,
                            LLRName = LLRName,
                            LRLId = LRLId,
                            LRLName = LRLName,
                            LRRId = LRRId,
                            LRRName = LRRName,
                            RLLId = RLLId,
                            RLLName = RLLName,
                            RLRId = RLRId,
                            RLRName = RLRName,
                            RRLId = RRLId,
                            RRLName = RRLName,
                            RRRId = RRRId,
                            RRRName = RRRName,
                            Mprofile = Mprofile,
                            Lprofile = Lprofile,
                            Rprofile = Rprofile,
                            LRprofile = LRprofile,
                            LLprofile = LLprofile,
                            RRprofile = RRprofile,
                            RLprofile = RLprofile,
                            LLLprofile = LLLprofile,
                            LLRprofile = LLRprofile,
                            LRLprofile = LRLprofile,
                            LRRprofile = LRRprofile,
                            RLLprofile = RLLprofile,
                            RLRprofile = RLRprofile,
                            RRLprofile = RRLprofile,
                            RRRprofile = RRRprofile


                        });
                    }

                }
                else
                {
                    Response.Write("<script>alert('Please Enter Valid Member Id')</script>");
                }
                return View(down);
            }
        }

        public ActionResult myslcincome_income()
        {
            List<Memberlist> myin = new List<Memberlist>();

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                var cominfo = db.CompanyInfos.Single(a => a.Id == 1);

                var d = db.AgentDetails.Single(a => a.NewAgentId == User.Identity.Name);
                var myslc = db.slcincomes.Where(a => a.introid == d.AgencyCode);
                foreach (var i in myslc)
                {
                    if (i.status == 1)
                    {

                        myin.Add(new Memberlist { MemberName = i.custname, MemberId = i.custname, totalamt = i.rs, JoinDate = i.nextsunday, point = i.point, PAN = "Paid", Company_name = cominfo.CompanyName, Comp_address = cominfo.Address, AccountHolder = d.NewAgentId, BankName = d.name });
                    }
                    else
                    {
                        myin.Add(new Memberlist { MemberName = i.custname, MemberId = i.custname, totalamt = i.rs, JoinDate = i.nextsunday, point = i.point, PAN = "Unpaid", Company_name = cominfo.CompanyName, Comp_address = cominfo.Address, AccountHolder = d.NewAgentId, BankName = d.name });
                    }
                }





                return View(myin);
            }
        }

        public ActionResult Printmylevelincome()
        {
            List<Memberlist> myin = new List<Memberlist>();

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                var cominfo = db.CompanyInfos.Single(a => a.Id == 1);

                var d = db.AgentDetails.Single(a => a.NewAgentId == User.Identity.Name);
                var mylevel = db.LevelIncomees.Where(a => a.introid == d.AgencyCode);
                foreach (var i in mylevel)
                {
                    if (i.status == 0)
                    {
                        myin.Add(new Memberlist { MemberName = i.custname, MemberId = i.custname, totalamt = i.rs, JoinDate = i.nextsunday, point = i.point, PAN = "UnPaid", Company_name = cominfo.CompanyName, Comp_address = cominfo.Address, AccountHolder = d.NewAgentId, BankName = d.name });
                    }
                    else
                    {
                        myin.Add(new Memberlist { MemberName = i.custname, MemberId = i.custname, totalamt = i.rs, JoinDate = i.nextsunday, point = i.point, PAN = "Paid", Company_name = cominfo.CompanyName, Comp_address = cominfo.Address, AccountHolder = d.NewAgentId, BankName = d.name });
                    }

                }
                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "Level_income.rpt"));
                rd.SetDataSource(myin);

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                try
                {

                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);

                    return new FileStreamResult(stream, "application/pdf");
                }

                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                }
                finally
                {
                    rd.Close();
                    rd.Dispose();
                }
                return View();
            }
        }

        public ActionResult matching_income(int? page)
        {

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                matching_income_detail objStudent = new matching_income_detail();
                List<matching_income_detail> tempmatchinincom = new List<matching_income_detail>();
                SqlConnection con = new SqlConnection();
                DataSet ds = new DataSet();

                var member_id = db.AgentDetails.Single(x => x.NewAgentId == User.Identity.Name).NewAgentId;
                int pageSize = 50;
                int pageIndex = 1;
                pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
                ViewData["pageno"] = pageIndex;
                int akhiri = (pageIndex - 1) * 50;
                ViewData["srno"] = akhiri;
                IPagedList<matching_income_detail> stu = null;
                SqlCommand cmd = new SqlCommand();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "select * from matching_income_detail where newmemberid='" + member_id + "'";
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            tempmatchinincom.Add(new matching_income_detail
                            {
                                uid = Convert.ToInt32(item["uid"]),
                                newmemberid = item["newmemberid"].ToString(),
                                amount = Convert.ToInt32(item["amount"]),
                                actualamount = Convert.ToInt32(item["actualamount"]),
                                leftbusiness = Convert.ToInt32(item["leftbusiness"]),
                                rightbusiness = Convert.ToInt32(item["rightbusiness"]),
                                payout_date = Convert.ToDateTime(item["payout_date"]),
                                carryleft = Convert.ToInt32(item["carryleft"]),
                                carryright = Convert.ToInt32(item["carryright"]),
                                status = Convert.ToInt32(item["status"])

                            });
                        }

                    }
                }

                catch (Exception ex)
                {
                    TempData["my7"] = ex.Message;
                    // Response.Write("<script>alert('" + ex.Message + "')</script>");
                }
                finally
                {
                    con.Close();
                }
                stu = tempmatchinincom.ToPagedList(pageIndex, pageSize);

                return View(stu);
            }
        }

        public ActionResult Levelbonus_income(int? page)
        {
            List<Memberlist> myin = new List<Memberlist>();


            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                //var cominfo = db.CompanyInfos.Single(a => a.Id == 1);

                var d = db.AgentDetails.Single(a => a.NewAgentId == User.Identity.Name);

                DirectIncome objStudent = new DirectIncome();
                List<DirectIncome> templevel = new List<DirectIncome>();
                SqlConnection con = new SqlConnection();
                DataSet ds = new DataSet();

                int pageSize = 50;
                int pageIndex = 1;
                pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
                ViewData["pageno"] = pageIndex;
                int akhiri = (pageIndex - 1) * 50;
                ViewData["srno"] = akhiri;
                IPagedList<DirectIncome> stu = null;
                SqlCommand cmd = new SqlCommand();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "select * from DirectIncome where intronewid='" + d.NewAgentId + "'";
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            templevel.Add(new DirectIncome
                            {
                                intronewid = item["intronewid"].ToString(),
                                introname = item["introname"].ToString(),
                                package = Convert.ToInt32(item["package"]),
                                rs = Convert.ToDouble(item["rs"]),
                                point = Convert.ToInt32(item["point"]),
                                nextsunday = Convert.ToDateTime(item["nextsunday"]),
                                LastPaidDate = Convert.ToDateTime(item["LastPaidDate"]),
                                status = Convert.ToInt32(item["status"])

                            });
                        }

                    }
                }

                catch (Exception ex)
                {
                    TempData["my6"] = ex.Message;
                    // Response.Write("<script>alert('" + ex.Message + "')</script>");
                }
                finally
                {
                    con.Close();
                }
                stu = templevel.ToPagedList(pageIndex, pageSize);
                //var memlist = db.AgentDetails.Where(a => a.joindate >= sdate && a.joindate <= edate).ToList();
                return View(stu);

            }
        }

        public ActionResult Performance_income_Team(int? page)
        {
            int pageSize = 50;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewData["pageno"] = pageIndex;
            int akhiri = (pageIndex - 1) * 50;
            ViewData["srno"] = akhiri;
            IPagedList<Memberlist> stu = null;
            List<Memberlist> myin = new List<Memberlist>();

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                var cominfo = db.CompanyInfos.Single(a => a.Id == 1);

                var d = db.AgentDetails.Single(a => a.NewAgentId == User.Identity.Name);
                var Perform = db.Performance_incomes.Where(a => a.introid == d.uid && a.paidstatus == 1 && a.nextsunday <= DateTime.Now);
                foreach (var i in Perform)
                {
                    if (i.paidstatus == 0)
                    {
                        myin.Add(new Memberlist { MemberName = i.introname, MemberId = i.intronewid, totalamt = i.rs, JoinDate = i.nextsunday, point = i.point, PAN = "UnPaid", Company_name = cominfo.CompanyName, Comp_address = cominfo.Address, AccountHolder = d.NewAgentId, BankName = d.name });
                    }
                    else
                    {
                        myin.Add(new Memberlist { MemberName = i.introname, MemberId = i.intronewid, totalamt = i.rs, JoinDate = i.nextsunday, point = i.point, PAN = "Paid", Company_name = cominfo.CompanyName, Comp_address = cominfo.Address, AccountHolder = d.NewAgentId, BankName = d.name });
                    }

                }
                stu = myin.ToPagedList(pageIndex, pageSize);

                return View(stu);
            }
        }

        public ActionResult Performance_income(int? page)
        {
            int pageSize = 50;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewData["pageno"] = pageIndex;
            int akhiri = (pageIndex - 1) * 50;
            ViewData["srno"] = akhiri;
            IPagedList<Memberlist> stu = null;
            List<Memberlist> myin = new List<Memberlist>();

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                var cominfo = db.CompanyInfos.Single(a => a.Id == 1);

                var d = db.AgentDetails.Single(a => a.NewAgentId == User.Identity.Name);
                var Performcount = db.Roiincomes.Where(a => a.intronewid == d.NewAgentId && a.nextsunday <= DateTime.Now).Count();
                if (Performcount > 0)
                {
                    var Perform = db.Roiincomes.Where(a => a.intronewid == d.NewAgentId && a.nextsunday <= DateTime.Now);
                    foreach (var i in Perform)
                    {
                        if (i.paidstatus == 0)
                        {
                            myin.Add(new Memberlist { MemberName = i.introname, MemberId = i.intronewid, paidstatus = i.paidstatus, package = i.package, totalamt = i.rs, JoinDate = i.nextsunday, paiddate = i.LastPaidDate, point = i.point, PAN = "UnPaid", Company_name = cominfo.CompanyName, Comp_address = cominfo.Address, AccountHolder = d.NewAgentId, BankName = d.name });
                        }
                        else
                        {
                            myin.Add(new Memberlist { MemberName = i.introname, MemberId = i.intronewid, paidstatus = i.paidstatus, package = i.package, totalamt = i.rs, JoinDate = i.nextsunday, paiddate = i.LastPaidDate, point = i.point, PAN = "Paid", Company_name = cominfo.CompanyName, Comp_address = cominfo.Address, AccountHolder = d.NewAgentId, BankName = d.name });
                        }

                    }
                    stu = myin.ToPagedList(pageIndex, pageSize);

                    return View(stu);
                }
                else
                {
                    TempData["my5"] = "You have no Direct/Team Performance Bonus Income";
                    return View();
                }
            }
        }

        public ActionResult Autopool_income(int? page)
        {
            int pageSize = 50;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewData["pageno"] = pageIndex;
            int akhiri = (pageIndex - 1) * 50;
            ViewData["srno"] = akhiri;
            IPagedList<Memberlist> stu = null;
            List<Memberlist> myin = new List<Memberlist>();

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                var cominfo = db.CompanyInfos.Single(a => a.Id == 1);

                var d = db.AgentDetails.Single(a => a.NewAgentId == User.Identity.Name);
                var Performcount = db.AutopoolIncomes.Where(a => a.introid == d.uid && a.paidstatus == 1).Count();
                if (Performcount > 0)
                {
                    var Perform = db.AutopoolIncomes.Where(a => a.introid == d.uid && a.paidstatus == 1);
                    foreach (var i in Perform)
                    {
                        if (i.paidstatus == 0)
                        {
                            myin.Add(new Memberlist { MemberName = i.introname, MemberId = i.intronewid, totalamt = i.rs, JoinDate = i.nextsunday, point = i.point, PAN = "UnPaid", Company_name = cominfo.CompanyName, Comp_address = cominfo.Address, AccountHolder = d.NewAgentId, BankName = d.name });
                        }
                        else
                        {
                            myin.Add(new Memberlist { MemberName = i.introname, MemberId = i.intronewid, totalamt = i.rs, JoinDate = i.nextsunday, point = i.point, PAN = "Paid", Company_name = cominfo.CompanyName, Comp_address = cominfo.Address, AccountHolder = d.NewAgentId, BankName = d.name });
                        }

                    }
                    stu = myin.ToPagedList(pageIndex, pageSize);

                    return View(stu);
                }
                else
                {
                    TempData["my2"] = "You Have no Auto Pool Income";
                    return View();
                }
            }
        }

        public ActionResult Clubroyalty_income(int? page)
        {
            int pageSize = 50;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewData["pageno"] = pageIndex;
            int akhiri = (pageIndex - 1) * 50;
            ViewData["srno"] = akhiri;
            IPagedList<Memberlist> stu = null;
            List<Memberlist> myin = new List<Memberlist>();

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                var cominfo = db.CompanyInfos.Single(a => a.Id == 1);

                var d = db.AgentDetails.Single(a => a.NewAgentId == User.Identity.Name);
                var Royaltycount = db.LeaderIncomes.Where(a => a.intronewid == User.Identity.Name).Count();
                if (Royaltycount > 0)
                {
                    var myRoyalty = db.LeaderIncomes.Where(a => a.intronewid == User.Identity.Name);
                    foreach (var i in myRoyalty)
                    {
                        if (i.paidstatus == 0)
                        {
                            myin.Add(new Memberlist { MemberName = i.introname, MemberId = i.intronewid, totalamt = i.rs, JoinDate = i.nextsunday, point = i.point, PAN = "UnPaid", Company_name = cominfo.CompanyName, Comp_address = cominfo.Address, AccountHolder = d.NewAgentId, BankName = d.name });
                        }
                        else
                        {
                            myin.Add(new Memberlist { MemberName = i.introname, MemberId = i.intronewid, totalamt = i.rs, JoinDate = i.nextsunday, point = i.point, PAN = "Paid", Company_name = cominfo.CompanyName, Comp_address = cominfo.Address, AccountHolder = d.NewAgentId, BankName = d.name });
                        }

                    }
                    stu = myin.ToPagedList(pageIndex, pageSize);

                    return View(stu);
                }
                else
                {
                    TempData["my3"] = "You Have no Loyalty Bonus Income";
                    return View();
                }
            }
        }

        //[HttpGet]
        //public ActionResult Carry_forword_Report()
        //{
        //    if (!User.Identity.IsAuthenticated)
        //    {
        //        return RedirectToAction("Logout", "Member");
        //    }
        //    else
        //    {

        //        List<matching_income2> myin = new List<matching_income2>();
        //        SqlCommand cmd = new SqlCommand();
        //        SqlConnection con = new SqlConnection();
        //        con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //        cmd.Connection = con;
        //        SqlDataReader sdr;
        //        cmd.CommandText = "MatchingIncome_Pro";
        //        cmd.Parameters.AddWithValue("@memberid", User.Identity.Name);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        try
        //        {
        //            con.Open();
        //            sdr = cmd.ExecuteReader();
        //            if (sdr.HasRows)
        //            {
        //                while (sdr.Read())
        //                {
        //                    var newmemberid = sdr["newmemberid"].ToString();
        //                    var amount = Convert.ToInt32(sdr["amount"]);
        //                    var actualamount = Convert.ToInt32(sdr["actualamount"]);
        //                    var leftbusiness = Convert.ToInt32(sdr["leftbusiness"]);
        //                    var rightbusiness = Convert.ToInt32(sdr["rightbusiness"]);
        //                    var payout_date = Convert.ToDateTime(sdr["payout_date"]);
        //                    var carryleft = Convert.ToInt32(sdr["carryleft"]);
        //                    var carryright = Convert.ToInt32(sdr["carryright"]);
        //                    var status = Convert.ToInt32(sdr["status"]);

        //                    myin.Add(new matching_income2 { newmemberid = newmemberid, amount = amount, actualamount = actualamount, leftbusiness = leftbusiness, rightbusiness = rightbusiness, payout_date = payout_date, carryleft = carryleft, carryright = carryright });


        //                }
        //            }
        //        }

        //        catch (Exception ex)
        //        {
        //            Response.Write("<script>alert('" + ex.Message + "')</script>");
        //        }
        //        finally
        //        {
        //            con.Close();
        //        }




        //        return View(myin);
        //    }
        //}

        [HttpPost]
        public ActionResult Carry_forword_Report(DateTime sdate, DateTime edate)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                var carrylist = db.matching_income_details.Where(a => a.payout_date >= sdate && a.payout_date <= edate && a.newmemberid == User.Identity.Name).ToList();


                return View(carrylist);
            }
        }

        public ActionResult myProfitsharing_income()
        {
            List<Memberlist> myin = new List<Memberlist>();

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                var cominfo = db.CompanyInfos.Single(a => a.Id == 1);

                var d = db.AgentDetails.Single(a => a.NewAgentId == User.Identity.Name);
                var myroi = db.Roiincomes.Where(a => a.introid == d.AgencyCode);
                foreach (var i in myroi)
                {
                    if (i.status == 1)
                    {
                        myin.Add(new Memberlist { MemberName = i.introname, MemberId = i.intronewid, totalamt = i.rs, JoinDate = i.nextsunday, point = i.point, PAN = "Paid", Company_name = cominfo.CompanyName, Comp_address = cominfo.Address, AccountHolder = d.NewAgentId, BankName = d.name });
                    }


                }

                return View(myin);
            }
        }

        public ActionResult myDaily_income()
        {
            List<Memberlist> myin = new List<Memberlist>();

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                //var cominfo = db.CompanyInfos.Single(a => a.Id == 1);

                //var d = db.AgentDetails.Single(a => a.NewAgentId == User.Identity.Name);
                //var mylevel = db.PayoutSummarys.Where(a => a.introid == d.AgencyCode);
                //foreach (var i in mylevel)
                //{
                //    myin.Add(new Memberlist { MemberName = d.name, MemberId = d.NewAgentId, totalamt = i.Roiincome, JoinDate = i.paydate, PAN = "Paid", Company_name = cominfo.CompanyName, Comp_address = cominfo.Address });

                //}


                return View(myin);
            }
        }

        public ActionResult MyAllincome(int? page)
        {
            int pageSize = 50;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewData["pageno"] = pageIndex;
            int akhiri = (pageIndex - 1) * 50;
            ViewData["srno"] = akhiri;
            IPagedList<Payout> stu = null;
            List<Payout> pay = new List<Payout>();

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {

                var cominfo = db.CompanyInfos.Single(aa => aa.Id == 1);
                var a = db.AgentDetails.Single(aa => aa.NewAgentId == User.Identity.Name);
                var prcount = db.PayoutSummarys.Where(pp => pp.Newintroid == a.NewAgentId).Count();
                if (prcount > 0)
                {
                    var pr = db.PayoutSummarys.Where(pp => pp.Newintroid == a.NewAgentId).ToList();
                    foreach (var i in pr)
                    {

                        var memberdetail = db.AgentDetails.Single(c => c.NewAgentId == a.NewAgentId);
                        pay.Add(new Payout { LeadershipIncome = i.Leadershipincome, Directincome = i.Directincome, Roiincome = i.Roiincome, TDS = i.TDS, Name = memberdetail.name, paydate = i.paydate, id = memberdetail.AgencyCode, AdminFee = i.AdminFee, LevelIncome = i.LevelIncome, BinaryIncome = i.BinaryIncome, PoolIncome = i.PoolIncome, TotalIncome = i.totalamount, NetIncome = i.netamount, Dayname = i.dayname.ToString(), Company_name = cominfo.CompanyName, Comp_address = cominfo.Address });
                    }
                    stu = pay.ToPagedList(pageIndex, pageSize);
                    return View(stu);
                }
                else
                {
                    TempData["my1"] = "You have no payout summary";
                    return View(stu);
                }
            }

        }

        public ActionResult PrintMyAllincome()
        {
            List<Memberlist> myin = new List<Memberlist>();

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                var cominfo = db.CompanyInfos.Single(a => a.Id == 1);

                var d = db.AgentDetails.Single(a => a.NewAgentId == User.Identity.Name);
                var mylevel = db.LevelIncomees.Where(a => a.introid == d.AgencyCode);
                foreach (var i in mylevel)
                {
                    if (i.status == 0)
                    {
                        myin.Add(new Memberlist { MemberName = i.custname, MemberId = i.custname, totalamt = i.rs, JoinDate = i.nextsunday, point = i.point, PAN = "UnPaid", Company_name = cominfo.CompanyName, Comp_address = cominfo.Address, AccountHolder = d.NewAgentId, BankName = d.name });
                    }
                    else
                    {
                        myin.Add(new Memberlist { MemberName = i.custname, MemberId = i.custname, totalamt = i.rs, JoinDate = i.nextsunday, point = i.point, PAN = "Paid", Company_name = cominfo.CompanyName, Comp_address = cominfo.Address, AccountHolder = d.NewAgentId, BankName = d.name });
                    }

                }
                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "Level_income.rpt"));
                rd.SetDataSource(myin);

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                try
                {

                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);

                    return new FileStreamResult(stream, "application/pdf");
                }

                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                }
                finally
                {
                    rd.Close();
                    rd.Dispose();
                }
                return View();
            }
        }

        [HttpGet]
        public ActionResult CreateBroker()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult CreateBroker(AgentDetail model, HttpPostedFileBase Photo, string command, string memberid)
        {
            List<Member_tab> mt = new List<Member_tab>();
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {

                switch (command)
                {
                    case "Search":

                        switch (memberid)
                        {
                            case "":
                                Response.Write("<script>alert('Please Select Member Id First')</script>");
                                break;
                            default:

                                mt = db.Member_tabs.Where(c => c.NewMemberId == memberid).ToList();
                                return View(mt);
                        }

                        break;

                    case "Submit":
                        var ds = db.Blockdates.Where(c => c.date == model.Doj && c.branchcode == model.BranchCode && c.status == 0).Count();
                        if (ds > 0)
                        {
                            Response.Write("<script>alert('This Date is closed please select another date')</script>");
                        }
                        else
                        {
                            string localIP = "";
                            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                            {
                                if (nic.OperationalStatus == OperationalStatus.Up)
                                {
                                    localIP += nic.GetPhysicalAddress().ToString();
                                    break;
                                }
                            }


                            AgentDetail ad = new AgentDetail();
                            var r = new AgentDetail();
                            string passw = gid();
                            var row1 = db.Branchtabs.Single(c => c.BranchCode == model.BranchCode);
                            var csrt = db.CompanyInfos.Single(a => a.AdminId == row1.companyid);
                            int max = (from a in db.AgentDetails select a).Count();
                            var row = db.Ranktabs.Single(c => c.RankCode == 1);

                            var newagentid = string.Empty;
                            int bwcount = (from a in db.AgentDetails select a.Suffix).DefaultIfEmpty(0).Max() + 1;
                            if (bwcount < 10)
                            {
                                newagentid = "SBC0000000" + bwcount;
                            }
                            else if (bwcount < 100 && bwcount >= 10)
                            {
                                newagentid = "SBC000000" + bwcount;
                            }
                            else if (bwcount < 1000 && bwcount >= 100)
                            {
                                newagentid = "SBC00000" + bwcount;
                            }
                            else if (bwcount < 10000 && bwcount >= 1000)
                            {
                                newagentid = "SBC0000" + bwcount;
                            }
                            else if (bwcount < 100000 && bwcount >= 10000)
                            {
                                newagentid = "SBC000" + bwcount;
                            }
                            else if (bwcount < 1000000 && bwcount >= 100000)
                            {
                                newagentid = "SBC00" + bwcount;
                            }
                            else if (bwcount < 10000000 && bwcount >= 1000000)
                            {
                                newagentid = "SBC0" + bwcount;
                            }
                            else
                            {
                                newagentid = "SBC" + bwcount;
                            }

                            int bcnt = bwcount;
                            //var mrow = db.Member_tabs.Single(p => p.NewMemberId == model.newmemberid);

                            if (max > 0)
                            {
                                r = db.AgentDetails.Single(c => c.NewAgentId == model.NewIntroducerId);
                            }

                            #region binary system
                            System.Threading.Thread.Sleep(2000);
                            var comp = db.CompanyInfos.Single(a => a.Id == 1);
                            var introcount = db.AgentDetails.Where(cc => cc.NewAgentId == model.NewIntroducerId).Count();

                            string topnewid = string.Empty;
                            if (introcount != 0)
                            {

                                var uid1 = 0;
                                string pwd = gid();
                                var userdata = db.AgentDetails.Single(s => s.NewAgentId == model.NewIntroducerId);

                                string spildnewid = string.Empty;
                                string spildnewid2 = string.Empty;

                                var countt = db.binarys.Where(c => c.Id == userdata.uid).ToList().Count();
                                if (countt == 0)
                                {
                                    ViewBag.msg = "Please Enter Valid Id";
                                }
                                else
                                {
                                    var count2 = db.binarys.Single(c => c.Id == userdata.uid);
                                    if (count2.pair == 0)
                                    {
                                        spildnewid = userdata.NewAgentId;
                                    }
                                    else
                                    {
                                        spildnewid = userdata.NewAgentId;
                                    }
                                }

                                var spilr = db.AgentDetails.Single(a => a.NewAgentId == spildnewid);
                                if (model.position == 0)
                                {

                                }
                                else if (model.position == 1)
                                {
                                    var downleft = 0;
                                    var lperson = 0;
                                    var id = 0;
                                    var binary = db.binarys.Single(a => a.Id == spilr.uid);
                                    lperson = binary.lperson;
                                    downleft = binary.downleft;
                                    id = spilr.uid;
                                    while (lperson != 0)
                                    {
                                        var binary1 = db.binarys.Single(a => a.Id == downleft);
                                        lperson = binary1.lperson;
                                        downleft = binary1.downleft;
                                        id = binary1.Id;
                                    }

                                    var uy = db.AgentDetails.Single(n => n.uid == id);
                                    spildnewid2 = uy.NewAgentId;

                                }
                                else if (model.position == 2)
                                {
                                    var downright = 0;
                                    var rperson = 0;
                                    var id = 0;
                                    var binary = db.binarys.Single(a => a.Id == spilr.uid);
                                    rperson = binary.rperson;
                                    downright = binary.downright;
                                    id = spilr.uid;
                                    while (rperson != 0)
                                    {
                                        var binary1 = db.binarys.Single(a => a.Id == downright);
                                        rperson = binary1.rperson;
                                        downright = binary1.downright;
                                        id = binary1.Id;
                                    }
                                    var uy = db.AgentDetails.Single(n => n.uid == id);
                                    spildnewid2 = uy.NewAgentId;
                                }
                                // ------------------------------ Spild Id -------------------------------------

                                var count = db.AgentDetails.Where(a => a.NewAgentId == model.NewIntroducerId).Count();
                                if (count == 1)
                                {
                                    var Singleuser = db.AgentDetails.Single(a => a.NewAgentId == spildnewid2);
                                    var Updatebinary = db.binarys.Single(a => a.Id == Singleuser.uid);

                                    if (model.position == 1)
                                    {
                                        ad.position = 1;
                                        uid1 = Updatebinary.downleft;
                                        Updatebinary.lperson = 1;

                                    }
                                    else if (model.position == 2)
                                    {
                                        ad.position = 2;
                                        uid1 = Updatebinary.downright;
                                        Updatebinary.rperson = 1;
                                    }

                                    var Checkbinary = db.binarys.Single(a => a.Id == Singleuser.uid);
                                    if (Checkbinary.rperson == 1 && Checkbinary.lperson == 1)
                                    {
                                        Checkbinary.pair = 1;
                                    }


                                    //------- Wallettab Entry ------------------------
                                    var wt1 = new wallettab();
                                    wt1.amount = 0;
                                    wt1.UserId = newagentid;
                                    db.wallettabs.Add(wt1);


                                    //------------------------------------------------
                                    //-------Insert Binary Table---------------------

                                    var bmax = (from o in db.binarys select o.downright).Max();
                                    var Fillbinary = new binary();
                                    Fillbinary.Id = uid1;
                                    Fillbinary.intid = Singleuser.uid;
                                    Fillbinary.lperson = 0;
                                    Fillbinary.rperson = 0;
                                    Fillbinary.pair = 0;
                                    Fillbinary.upline = "upline";
                                    Fillbinary.downleft = bmax + 1;
                                    Fillbinary.downright = bmax + 2;
                                    Fillbinary.completelevel = 0;
                                    db.binarys.Add(Fillbinary);


                                    //-------End insert Binary Table---------------------

                            #endregion

                                    ad.kyc_status = 0;
                                    ad.uid = uid1;
                                    ad.spilid = Singleuser.NewAgentId;
                                    ad.formfee = model.formfee;
                                    ad.BranchCode = model.BranchCode;
                                    ad.name = model.name;
                                    ad.Father = model.Father;
                                    ad.Mother = model.Mother;
                                    ad.Gender = model.Gender;
                                    ad.NewAgentId = newagentid;
                                    if (max > 0)
                                    {
                                        ad.IntroducerCode = r.AgencyCode;
                                    }
                                    else
                                    {
                                        ad.IntroducerCode = max;
                                    }
                                    ad.NewIntroducerId = model.NewIntroducerId;
                                    ad.IntroName = model.IntroName;
                                    ad.RankCode = 1;
                                    ad.Nationality = model.Nationality;
                                    ad.Dob = DateTime.Now.Date;
                                    ad.Age = model.Age;
                                    ad.BloodGroup = model.BloodGroup;
                                    ad.Occupation = model.Occupation;
                                    ad.Qualification = model.Qualification;
                                    ad.Panno = model.Panno;
                                    ad.Passportno = model.Passportno;
                                    ad.Drivinglno = model.Drivinglno;
                                    ad.Icardno = model.Icardno;
                                    ad.Issueon = model.Doj;
                                    ad.Validupto = model.Doj.AddYears(1);
                                    ad.BankName = model.BankName;
                                    ad.BankAccountno = model.BankAccountno;
                                    ad.IFCCode = model.IFCCode;
                                    ad.BankAddress = model.BankAddress;
                                    ad.Address = model.Address;
                                    ad.District = model.District;
                                    ad.State = model.State;
                                    ad.PinCode = model.PinCode;
                                    ad.Landlineno = model.Landlineno;
                                    ad.Mobile = model.Mobile;
                                    ad.Email = model.Email;
                                    ad.NomineeName = model.NomineeName;
                                    ad.NomineeAge = model.NomineeAge;
                                    ad.NomineeAddress = model.NomineeAddress;
                                    ad.Organization = model.Organization;
                                    ad.Doj = model.Doj;
                                    ad.activationdate = model.Doj;
                                    ad.areaofoccupation = model.areaofoccupation;
                                    ad.approximatenoofactive = model.approximatenoofactive;
                                    ad.operatorid = User.Identity.Name;
                                    ad.Company = model.Company;
                                    ad.Yoe = model.Yoe;
                                    ad.Mobileno = model.Mobileno;
                                    ad.cmpnyaddress = model.cmpnyaddress;
                                    ad.Experience = model.Experience;
                                    ad.Password = passw;
                                    ad.RankName = row.RankName;
                                    ad.Suffix = bwcount;
                                    ad.newmemberid = "NA";
                                    ad.memberid = 0;
                                    if (Photo != null)
                                    {
                                        string imgname = gid();
                                        ad.Photo = "~/Photo/" + imgname + ".jpg";
                                        Photo.SaveAs(HttpContext.Server.MapPath("~/Photo/") + imgname + ".jpg");
                                    }
                                    else
                                    {
                                        ad.Photo = "~/Photo/default.jpg";
                                    }
                                    ad.Type = "Agent";
                                    ad.Status = 0;
                                    ad.Macaddress = localIP;
                                    ad.Time = DateTime.Now.ToShortTimeString();
                                    /**/
                                    ad.BankBranchName = "N/A";
                                    ad.OtherMobile = 0;

                                    ad.Aadhaar_No = "N/A";
                                    ad.Aadhaar_ReqDate = Convert.ToDateTime("1991-01-01");
                                    ad.Aadhaar_status = 0;
                                    ad.Aadhaar_AppDate = Convert.ToDateTime("1991-01-01");
                                    ad.PAN_AppDate = Convert.ToDateTime("1991-01-01");
                                    ad.PAN_ReqDate = Convert.ToDateTime("1991-01-01");
                                    ad.PanStatus = 0;
                                    var csr = gidref();
                                    int year = DateTime.Now.Year, syear = year + 1;
                                    string refyear = year.ToString().Substring(2, 2) + "-" + syear.ToString().Substring(2, 2);
                                    string refno = "DRE/WEL/" + refyear + "/" + csr;
                                    ad.refno = refno;
                                    /**/
                                    NewLogin nl = new NewLogin();
                                    nl.UserName = newagentid;
                                    nl.Password = passw;
                                    nl.Mobile = model.Mobile;
                                    nl.type = "Agent";
                                    nl.status = 1;
                                    db.NewLogins.Add(nl);
                                    db.AgentDetails.Add(ad);
                                    db.SaveChanges();

                                    //----------Insert Genology Table All Chain----------------

                                    con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                                    SqlCommand cmd = new SqlCommand();
                                    cmd.Connection = con;
                                    cmd.CommandText = "genology";
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@cust_id", uid1);

                                    try
                                    {
                                        con.Open();
                                        cmd.ExecuteNonQuery();
                                    }
                                    catch (SqlException ex)
                                    {
                                        ViewBag.msg = ex.Message;
                                    }
                                    finally
                                    {
                                        con.Close();
                                    }

                                    //----------End Genology Table All Chain-------------------

                                    var cr = db.CompanyInfos.Single(d => d.Id == 1);
                                    MyClass.Sendmsg(model.Mobile, "Dear " + model.name + " Thank you for Being a part of " + cr.CompanyName + " . Regards- " + cr.CompanyName + ".");
                                    MyClass.Sendmsg(model.Mobile, "Dear " + ad.name + ", login on " + cr.HeadOffice + " with your user ID as " + nl.UserName + " and password is " + nl.Password + ". Use " + nl.UserName + " as referral ID. Regards- " + cr.CompanyName + ".");
                                    var memag = db.Members.Single(agm => agm.Id == 1);
                                    Response.Write("<script>alert('" + memag.agentname + " SuccessFully Created Your Id: " + nl.UserName + " and Password: " + nl.Password + " ')</script>");
                                    ViewBag.msg = memag.agentname + " SuccessFully Created Your Id: " + nl.UserName + " and Password: " + nl.Password;
                                }
                                else
                                {
                                    Response.Write("<script>alert('This Introducer Id is Invalid')</script>");
                                    ViewData["msg"] = "This Introducer Id Invalid";
                                }
                            }
                            else
                            {
                                Response.Write("<script>alert('This Introducer Id is Invalid')</script>");
                            }

                        }
                        break;
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult BTree(string newid, string aa)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                List<Downline1> down = new List<Downline1>();
                int lcount = (from n in db.NewLogins where n.UserName == User.Identity.Name select n.UserName).Count();
                if (lcount == 1)
                {
                    var log = db.NewLogins.Single(a => a.UserName == User.Identity.Name);
                    if (log.status == 1 || log.type == "Member")
                    {
                        if (newid == null)
                        {
                            newid = User.Identity.Name;
                            ViewData["cmid"] = newid;
                        }
                        SqlCommand cmd = new SqlCommand();
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                        cmd.Connection = con;
                        SqlDataReader sdr;
                        cmd.CommandText = "binarylastid";
                        if (newid == null)
                        {
                            newid = User.Identity.Name;
                            cmd.Parameters.AddWithValue("@introid", newid);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@introid", newid);
                        }
                        cmd.CommandType = CommandType.StoredProcedure;
                        try
                        {
                            con.Open();
                            cmd.CommandTimeout = 1000000;
                            sdr = cmd.ExecuteReader();
                            if (sdr.HasRows)
                            {
                                while (sdr.Read())
                                {
                                    ViewData["lastleftid"] = sdr["lastleftid"];
                                    ViewData["lastleftname"] = sdr["lastleftname"];
                                    ViewData["lastleftprofile"] = sdr["lastleftprofile"];
                                    ViewData["lastrightid"] = sdr["lastrightid"];
                                    ViewData["lastrightname"] = sdr["lastrightname"];
                                    ViewData["lastrightprofile"] = sdr["lastrightprofile"];

                                }
                            }
                        }

                        catch (Exception ex)
                        {
                            Response.Write("<script>alert('" + ex.Message + "')</script>");
                        }
                        finally
                        {
                            con.Close();
                        }

                        var lastid = ViewData["lastleftid"];
                        var lastname = ViewData["lastleftname"];
                        var lastprofile = ViewData["lastleftprofile"];
                        var lastrightid = ViewData["lastrightid"];
                        var lastrightname = ViewData["lastrightname"];
                        var lastrightprofile = ViewData["lastrightprofile"];


                        var MainId = "Not Present";
                        var MainName = "Not Present";
                        var LeftId = "Not Present";
                        var LeftName = "Not Present";
                        var RightId = "Not Present";
                        var RightName = "Not Present";
                        var LeftLeftId = "Not Present";
                        var LeftLeftName = "Not Present";
                        var LeftRightId = "Not Present";
                        var LeftRightName = "Not Present";
                        var RightRightId = "Not Present";
                        var RightRightName = "Not Present";
                        var RightLeftId = "Not Present";
                        var RightLeftName = "Not Present";
                        var LLLId = "Not Present";
                        var LLLName = "Not Present";
                        var LLRId = "Not Present";
                        var LLRName = "Not Present";
                        var LRLName = "Not Present";
                        var LRLId = "Not Present";
                        var LRRId = "Not Present";
                        var LRRName = "Not Present";
                        var RLLId = "Not Present";
                        var RLLName = "Not Present";
                        var RLRId = "Not Present";
                        var RLRName = "Not Present";
                        var RRLId = "Not Present";
                        var RRLName = "Not Present";
                        var RRRId = "Not Present";
                        var RRRName = "Not Present";
                        var LastLeftId = "Not Represent";
                        var LastLeftName = "Not Represent";
                        var LastRightId = "Not Represent";
                        var LastRightName = "Not Represent";

                        var LastLeftProfile = string.Empty;
                        var LastRightProfile = string.Empty;
                        var Mprofile = string.Empty;
                        var Lprofile = string.Empty;
                        var Rprofile = string.Empty;
                        var LLprofile = string.Empty;
                        var LRprofile = string.Empty;
                        var RLprofile = string.Empty;
                        var RRprofile = string.Empty;
                        var LLLprofile = string.Empty;
                        var LLRprofile = string.Empty;
                        var LRLprofile = string.Empty;
                        var LRRprofile = string.Empty;
                        var RLLprofile = string.Empty;
                        var RLRprofile = string.Empty;
                        var RRLprofile = string.Empty;
                        var RRRprofile = string.Empty;


                        if (!User.Identity.IsAuthenticated)
                        {
                            return RedirectToAction("Home", "Login");
                        }
                        else
                        {

                            var count = db.AgentDetails.Where(a => a.NewAgentId == newid).Count();
                            if (count == 1)
                            {
                                #region Select Main Id and Name
                                var user = db.AgentDetails.Single(a => a.NewAgentId == newid);
                                var binary = db.binarys.Single(a => a.Id == user.uid);
                                MainId = user.NewAgentId;
                                 MainName = user.name;

                                if (user.Status == 1)
                                {
                                    Mprofile = "~/Images/star/green.png";
                                }
                                else if (user.Status == 2)
                                {
                                    Mprofile = "~/Images/star/oreng.png";
                                }
                                else
                                {
                                    Mprofile = "~/Images/star/red.png";
                                }

                                #endregion Select Main Id and Name

                                if (binary.lperson == 1)
                                {
                                    //-----------Select Left Id and Name
                                    var user1 = db.AgentDetails.Single(a => a.uid == binary.downleft);
                                    var binary1 = db.binarys.Single(a => a.Id == binary.downleft);
                                    LeftId = user1.NewAgentId;
                                    LeftName = user1.name;


                                    if (user1.Status == 1)
                                    {
                                        Lprofile = "~/Images/star/green.png";
                                    }
                                    else if (user1.Status == 2)
                                    {
                                        Lprofile = "~/Images/star/oreng.png";
                                    }
                                    else
                                    {
                                        Lprofile = "~/Images/star/red.png";
                                    }
                                    //-----------End Select Left Id and Name
                                    if (binary1.lperson == 1)
                                    {
                                        //-----------Select Left Ki left Id and Name
                                        var user2 = db.AgentDetails.Single(a => a.uid == binary1.downleft);
                                        var binary2 = db.binarys.Single(a => a.Id == binary1.downleft);
                                        LeftLeftId = user2.NewAgentId;
                                        LeftLeftName = user2.name;

                                        if (user2.Status == 1)
                                        {
                                            LLprofile = "~/Images/star/green.png";
                                        }
                                        else if (user2.Status == 2)
                                        {
                                            LLprofile = "~/Images/star/oreng.png";
                                        }
                                        else
                                        {
                                            LLprofile = "~/Images/star/red.png";
                                        }
                                        //-----------End Select Left Ki left Id and Name


                                        if (binary2.lperson == 1)
                                        {
                                            //-----------Select LLL Id and Name
                                            var llluser = db.AgentDetails.Single(a => a.uid == binary2.downleft);
                                            var lllbinary = db.binarys.Single(a => a.Id == binary2.downleft);
                                            LLLId = llluser.NewAgentId;
                                            LLLName = llluser.name;

                                            if (llluser.Status == 1)
                                            {
                                                LLLprofile = "~/Images/star/green.png";
                                            }
                                            else if (llluser.Status == 2)
                                            {
                                                LLLprofile = "~/Images/star/oreng.png";
                                            }
                                            else
                                            {
                                                LLLprofile = "~/Images/star/red.png";
                                            }
                                            //-----------End Select LLL Id and Name
                                        }
                                        else
                                        {
                                            LLLId = "Not Present";
                                            LLLName = "Not Present";
                                        }



                                        if (binary2.rperson == 1)
                                        {
                                            //-----------Select LLR Id and Name

                                            var llRuser = db.AgentDetails.Single(a => a.uid == binary2.downright);
                                            var llRbinary = db.binarys.Single(a => a.Id == binary2.downright);
                                            LLRId = llRuser.NewAgentId;
                                            LLRName = llRuser.name;

                                            if (llRuser.Status == 1)
                                            {
                                                LLRprofile = "~/Images/star/green.png";
                                            }
                                            else if (llRuser.Status == 2)
                                            {
                                                LLRprofile = "~/Images/star/oreng.png";
                                            }
                                            else
                                            {
                                                LLRprofile = "~/Images/star/red.png";
                                            }

                                            //-----------Select LLR Id and Name
                                        }
                                        else
                                        {
                                            LLRId = "Not Present";
                                            LLRName = "Not Present";
                                        }


                                    }
                                    else
                                    {
                                        LeftLeftId = "Not Present";
                                        LeftLeftName = "Not Present";
                                    }
                                    if (binary1.rperson == 1)
                                    {
                                        //-----------Select Left Ki Right Id and Name

                                        var user2 = db.AgentDetails.Single(a => a.uid == binary1.downright);
                                        var binary2 = db.binarys.Single(a => a.Id == binary1.downright);
                                        LeftRightId = user2.NewAgentId;
                                        LeftRightName = user2.name;

                                        if (user2.Status == 1)
                                        {
                                            LRprofile = "~/Images/star/green.png";
                                        }
                                        else if (user2.Status == 2)
                                        {
                                            LRprofile = "~/Images/star/oreng.png";
                                        }
                                        else
                                        {
                                            LRprofile = "~/Images/star/red.png";
                                        }

                                        //-----------End Select Left Ki Right Id and Name



                                        if (binary2.lperson == 1)
                                        {
                                            //-----------Select LRL Id and Name
                                            var LRLuser = db.AgentDetails.Single(a => a.uid == binary2.downleft);
                                            var LRLbinary = db.binarys.Single(a => a.Id == binary2.downleft);
                                            LRLId = LRLuser.NewAgentId;
                                            LRLName = LRLuser.name;

                                            if (LRLuser.Status == 1)
                                            {
                                                LRLprofile = "~/Images/star/green.png";
                                            }
                                            else if (LRLuser.Status == 2)
                                            {
                                                LRLprofile = "~/Images/star/oreng.png";
                                            }
                                            else
                                            {
                                                LRLprofile = "~/Images/star/red.png";
                                            }
                                            //-----------End Select LRL Id and Name

                                        }
                                        else
                                        {
                                            LRLId = "Not Present";
                                            LRLName = "Not Present";
                                        }


                                        if (binary2.rperson == 1)
                                        {
                                            //-----------Select LRR Id and Name

                                            var LRRuser = db.AgentDetails.Single(a => a.uid == binary2.downright);
                                            var LRRbinary = db.binarys.Single(a => a.Id == binary2.downright);
                                            LRRId = LRRuser.NewAgentId;
                                            LRRName = LRRuser.name;


                                            if (LRRuser.Status == 1)
                                            {
                                                LRRprofile = "~/Images/star/green.png";
                                            }
                                            else if (LRRuser.Status == 2)
                                            {
                                                LRRprofile = "~/Images/star/oreng.png";
                                            }
                                            else
                                            {
                                                LRRprofile = "~/Images/star/red.png";
                                            }

                                            //-----------End Select LRR Id and Name

                                        }
                                        else
                                        {
                                            LRRId = "Not Present";
                                            LRRName = "Not Present";
                                        }

                                    }
                                    else
                                    {
                                        LeftRightId = "Not Present";
                                        LeftRightName = "Not Present";
                                    }
                                }
                                else
                                {
                                    LeftId = "Not Present";
                                    LeftName = "Not Present";
                                }




                                if (binary.rperson == 1)
                                {
                                    //-----------Select Right Id and Name
                                    var user1 = db.AgentDetails.Single(a => a.uid == binary.downright);
                                    var binary1 = db.binarys.Single(a => a.Id == binary.downright);
                                    RightId = user1.NewAgentId;
                                    RightName = user1.name;

                                    if (user1.Status == 1)
                                    {
                                        Rprofile = "~/Images/star/green.png";
                                    }
                                    else if (user1.Status == 2)
                                    {
                                        Rprofile = "~/Images/star/oreng.png";
                                    }
                                    else
                                    {
                                        Rprofile = "~/Images/star/red.png";
                                    }
                                    //-----------End Select Right Id and Name
                                    if (binary1.lperson == 1)
                                    {
                                        //-----------Select Right Ki Left Id and Name
                                        var user2 = db.AgentDetails.Single(a => a.uid == binary1.downleft);
                                        var binary2 = db.binarys.Single(a => a.Id == binary1.downleft);
                                        RightLeftId = user2.NewAgentId;
                                        RightLeftName = user2.name;

                                        if (user2.Status == 1)
                                        {
                                            RLprofile = "~/Images/star/green.png";
                                        }
                                        else if (user2.Status == 2)
                                        {
                                            RLprofile = "~/Images/star/oreng.png";
                                        }
                                        else
                                        {
                                            RLprofile = "~/Images/star/red.png";
                                        }
                                        //-----------Select Right Ki Left Id and Name

                                        if (binary2.lperson == 1)
                                        {
                                            //-----------Select RLL Id and Name

                                            var RLLuser = db.AgentDetails.Single(a => a.uid == binary2.downleft);
                                            var RLLbinary = db.binarys.Single(a => a.Id == binary2.downleft);
                                            RLLId = RLLuser.NewAgentId;
                                            RLLName = RLLuser.name;

                                            if (RLLuser.Status == 1)
                                            {
                                                RLLprofile = "~/Images/star/green.png";
                                            }
                                            else if (RLLuser.Status == 2)
                                            {
                                                RLLprofile = "~/Images/star/oreng.png";
                                            }
                                            else
                                            {
                                                RLLprofile = "~/Images/star/red.png";
                                            }

                                            //-----------End Select RLL Id and Name

                                        }
                                        else
                                        {
                                            RLLId = "Not Present";
                                            RLLName = "Not Present";
                                        }

                                        if (binary2.rperson == 1)
                                        {
                                            //-----------Select RLR Id and Name

                                            var RLRuser = db.AgentDetails.Single(a => a.uid == binary2.downright);
                                            var RLRbinary = db.binarys.Single(a => a.Id == binary2.downright);
                                            RLRId = RLRuser.NewAgentId;
                                            RLRName = RLRuser.name;

                                            if (RLRuser.Status == 1)
                                            {
                                                RLRprofile = "~/Images/star/green.png";
                                            }
                                            else if (RLRuser.Status == 2)
                                            {
                                                RLRprofile = "~/Images/star/oreng.png";
                                            }
                                            else
                                            {
                                                RLRprofile = "~/Images/star/red.png";
                                            }

                                            //-----------End Select RLR Id and Name
                                        }
                                        else
                                        {
                                            RLRId = "Not Present";
                                            RLRName = "Not Present";
                                        }

                                    }
                                    else
                                    {
                                        RightLeftId = "Not Present";
                                        RightLeftName = "Not Present";
                                    }
                                    if (binary1.rperson == 1)
                                    {
                                        //-----------Select Right Ki Right Id and Name

                                        var user2 = db.AgentDetails.Single(a => a.uid == binary1.downright);
                                        var binary2 = db.binarys.Single(a => a.Id == binary1.downright);
                                        RightRightId = user2.NewAgentId;
                                        RightRightName = user2.name;

                                        if (user2.Status == 1)
                                        {
                                            RRprofile = "~/Images/star/green.png";
                                        }
                                        else if (user2.Status == 2)
                                        {
                                            RRprofile = "~/Images/star/oreng.png";
                                        }
                                        else
                                        {
                                            RRprofile = "~/Images/star/red.png";
                                        }

                                        //-----------Select Right Ki Right Id and Name


                                        if (binary2.lperson == 1)
                                        {
                                            //-----------Select RRL Id and Name

                                            var RRluser = db.AgentDetails.Single(a => a.uid == binary2.downleft);
                                            var RRLbinary = db.binarys.Single(a => a.Id == binary2.downleft);
                                            RRLId = RRluser.NewAgentId;
                                            RRLName = RRluser.name;

                                            if (RRluser.Status == 1)
                                            {
                                                RRLprofile = "~/Images/star/green.png";
                                            }
                                            else if (RRluser.Status == 2)
                                            {
                                                RRLprofile = "~/Images/star/oreng.png";
                                            }
                                            else
                                            {
                                                RRLprofile = "~/Images/star/red.png";
                                            }

                                            //-----------End Select RRL Id and Name
                                        }
                                        else
                                        {
                                            RRLId = "Not Present";
                                            RRLName = "Not Present";
                                        }

                                        if (binary2.rperson == 1)
                                        {
                                            //-----------Select RRR Id and Name

                                            var RRRuser = db.AgentDetails.Single(a => a.uid == binary2.downright);
                                            var RRRbinary = db.binarys.Single(a => a.Id == binary2.downright);
                                            RRRId = RRRuser.NewAgentId;
                                            RRRName = RRRuser.name;

                                            if (RRRuser.Status == 1)
                                            {
                                                RRRprofile = "~/Images/star/green.png";
                                            }
                                            else if (RRRuser.Status == 2)
                                            {
                                                RRRprofile = "~/Images/star/oreng.png";
                                            }
                                            else
                                            {
                                                RRRprofile = "~/Images/star/red.png";
                                            }

                                            //-----------End Select RRR Id and Name
                                        }
                                        else
                                        {
                                            RRLId = "Not Present";
                                            RRLName = "Not Present";
                                        }

                                    }
                                    else
                                    {
                                        RightRightId = "Not Present";
                                        RightRightName = "Not Present";
                                    }

                                }
                                else
                                {
                                    RightId = "Not Present";
                                    RightName = "Not Present";
                                }

                            }
                            else
                            {
                                MainId = "Not Present";
                                MainName = "Not Present";
                            }
                            down.Add(new Downline1
                            {

                                MainId = MainId,
                                MainName = MainName,
                                LeftId = LeftId,
                                LeftName = LeftName,
                                RightId = RightId,
                                RightName = RightName,
                                LeftLeftId = LeftLeftId,
                                LeftLeftName = LeftLeftName,
                                LeftRightId = LeftRightId,
                                LeftRightName = LeftRightName,
                                RightRightId = RightRightId,
                                RightRightName = RightRightName,
                                RightLeftId = RightLeftId,
                                RightLeftName = RightLeftName,
                                LLLId = LLLId,
                                LLLName = LLLName,
                                LLRId = LLRId,
                                LLRName = LLRName,
                                LRLId = LRLId,
                                LRLName = LRLName,
                                LRRId = LRRId,
                                LRRName = LRRName,
                                RLLId = RLLId,
                                RLLName = RLLName,
                                RLRId = RLRId,
                                RLRName = RLRName,
                                RRLId = RRLId,
                                RRLName = RRLName,
                                RRRId = RRRId,
                                RRRName = RRRName,
                                Mprofile = Mprofile,
                                Lprofile = Lprofile,
                                Rprofile = Rprofile,
                                LRprofile = LRprofile,
                                LLprofile = LLprofile,
                                RRprofile = RRprofile,
                                RLprofile = RLprofile,
                                LLLprofile = LLLprofile,
                                LLRprofile = LLRprofile,
                                LRLprofile = LRLprofile,
                                LRRprofile = LRRprofile,
                                RLLprofile = RLLprofile,
                                RLRprofile = RLRprofile,
                                RRLprofile = RRLprofile,
                                RRRprofile = RRRprofile,
                                LastLeftId = lastid.ToString(),
                                LastLeftName = lastname.ToString(),
                                LastLeftProfile = lastprofile.ToString(),
                                LastRightId = lastrightid.ToString(),
                                LastRightName = lastrightname.ToString(),
                                LastRigthProfile = lastrightprofile.ToString()

                            });
                        }
                        ViewData["cmid"] = newid;
                        return View(down);


                    }
                    else
                    {
                        return RedirectToAction("Logout", "Member");
                    }
                }
                else
                {
                    return RedirectToAction("Logout", "Member");
                }
                ViewData["cmid"] = newid;
                return View(down);
            }

        }
        [HttpPost]
        public ActionResult BTree(string newid)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                var treevalidation = 0;
                List<Downline1> down = new List<Downline1>();
                if (newid == null)
                {
                    newid = User.Identity.Name;
                }

                if (newid != null)
                {
                    treevalidation = db.Database.SqlQuery<int>("select count(*) from genology_tab where newid='" + User.Identity.Name + "' and cust_id in (select uid from AgentDetail where NewAgentId='" + newid + "')").FirstOrDefault();
                }
                var c = db.AgentDetails.Where(a => a.NewAgentId == newid).Count();
                if (c == 1 && treevalidation == 1)
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    cmd.Connection = con;
                    SqlDataReader sdr;
                    cmd.CommandText = "binarylastid";
                    if (newid == null)
                    {
                        newid = User.Identity.Name;
                        cmd.Parameters.AddWithValue("@introid", newid);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@introid", newid);
                    }
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        con.Open();
                        cmd.CommandTimeout = 1000000;
                        sdr = cmd.ExecuteReader();
                        if (sdr.HasRows)
                        {
                            while (sdr.Read())
                            {
                                ViewData["lastleftid"] = sdr["lastleftid"];
                                ViewData["lastleftname"] = sdr["lastleftname"];
                                ViewData["lastleftprofile"] = sdr["lastleftprofile"];
                                ViewData["lastrightid"] = sdr["lastrightid"];
                                ViewData["lastrightname"] = sdr["lastrightname"];
                                ViewData["lastrightprofile"] = sdr["lastrightprofile"];

                            }
                        }
                    }

                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('" + ex.Message + "')</script>");
                    }
                    finally
                    {
                        con.Close();
                    }

                    var lastid = ViewData["lastleftid"];
                    var lastname = ViewData["lastleftname"];
                    var lastprofile = ViewData["lastleftprofile"];
                    var lastrightid = ViewData["lastrightid"];
                    var lastrightname = ViewData["lastrightname"];
                    var lastrightprofile = ViewData["lastrightprofile"];

                    var MainId = "Not Present";
                    var MainName = "Not Present";
                    var LeftId = "Not Present";
                    var LeftName = "Not Present";
                    var RightId = "Not Present";
                    var RightName = "Not Present";
                    var LeftLeftId = "Not Present";
                    var LeftLeftName = "Not Present";
                    var LeftRightId = "Not Present";
                    var LeftRightName = "Not Present";
                    var RightRightId = "Not Present";
                    var RightRightName = "Not Present";
                    var RightLeftId = "Not Present";
                    var RightLeftName = "Not Present";
                    var Mprofile = string.Empty;
                    var Lprofile = string.Empty;
                    var Rprofile = string.Empty;
                    var LLprofile = string.Empty;
                    var LRprofile = string.Empty;
                    var RLprofile = string.Empty;
                    var RRprofile = string.Empty;
                    var LLLId = "Not Present";
                    var LLLName = "Not Present";
                    var LLRId = "Not Present";
                    var LLRName = "Not Present";
                    var LRLName = "Not Present";
                    var LRLId = "Not Present";
                    var LRRId = "Not Present";
                    var LRRName = "Not Present";
                    var RLLId = "Not Present";
                    var RLLName = "Not Present";
                    var RLRId = "Not Present";
                    var RLRName = "Not Present";
                    var RRLId = "Not Present";
                    var RRLName = "Not Present";
                    var RRRId = "Not Present";
                    var RRRName = "Not Present";
                    var LLLprofile = string.Empty;
                    var LLRprofile = string.Empty;
                    var LRLprofile = string.Empty;
                    var LRRprofile = string.Empty;
                    var RLLprofile = string.Empty;
                    var RLRprofile = string.Empty;
                    var RRLprofile = string.Empty;
                    var RRRprofile = string.Empty;


                    if (!User.Identity.IsAuthenticated)
                    {
                        return RedirectToAction("Home", "Login");
                    }
                    else
                    {

                        var count = db.AgentDetails.Where(a => a.NewAgentId == newid).Count();
                        if (count == 1)
                        {
                            //-----------Select Main Id and Name
                            var user = db.AgentDetails.Single(a => a.NewAgentId == newid);
                            var binary = db.binarys.Single(a => a.Id == user.uid);
                            MainId = user.NewAgentId;
                            MainName = user.name;
                            if (user.Status == 1)
                            {
                                Mprofile = "~/Images/star/green.png";
                            }
                            else
                            {
                                Mprofile = "~/Images/star/red.png";
                            }

                            //-----------End Select Main Id and Name
                            if (binary.lperson == 1)
                            {
                                //-----------Select Left Id and Name
                                var user1 = db.AgentDetails.Single(a => a.uid == binary.downleft);
                                var binary1 = db.binarys.Single(a => a.Id == binary.downleft);
                                LeftId = user1.NewAgentId;
                                LeftName = user1.name;

                                if (user1.Status == 1)
                                {
                                    Lprofile = "~/Images/star/green.png";
                                }
                                else
                                {
                                    Lprofile = "~/Images/star/red.png";
                                }
                                //-----------End Select Left Id and Name
                                if (binary1.lperson == 1)
                                {
                                    //-----------Select Left Ki left Id and Name
                                    var user2 = db.AgentDetails.Single(a => a.uid == binary1.downleft);
                                    var binary2 = db.binarys.Single(a => a.Id == binary1.downleft);
                                    LeftLeftId = user2.NewAgentId;
                                    LeftLeftName = user2.name;

                                    if (user2.Status == 1)
                                    {
                                        LLprofile = "~/Images/star/green.png";
                                    }
                                    else
                                    {
                                        LLprofile = "~/Images/star/red.png";
                                    }
                                    //-----------End Select Left Ki left Id and Name


                                    if (binary2.lperson == 1)
                                    {
                                        //-----------Select LLL Id and Name
                                        var llluser = db.AgentDetails.Single(a => a.uid == binary2.downleft);
                                        var lllbinary = db.binarys.Single(a => a.Id == binary2.downleft);
                                        LLLId = llluser.NewAgentId;
                                        LLLName = llluser.name;


                                        if (llluser.Status == 1)
                                        {
                                            LLLprofile = "~/Images/star/green.png";
                                        }
                                        else
                                        {
                                            LLLprofile = "~/Images/star/red.png";
                                        }


                                        //-----------End Select LLL Id and Name
                                    }
                                    else
                                    {
                                        LLLId = "Not Present";
                                        LLLName = "Not Present";
                                    }


                                    if (binary2.rperson == 1)
                                    {
                                        //-----------Select LLR Id and Name

                                        var llRuser = db.AgentDetails.Single(a => a.uid == binary2.downright);
                                        var llRbinary = db.binarys.Single(a => a.Id == binary2.downright);
                                        LLRId = llRuser.NewAgentId;
                                        LLRName = llRuser.name;


                                        if (llRuser.Status == 1)
                                        {
                                            LLRprofile = "~/Images/star/green.png";
                                        }
                                        else
                                        {
                                            LLRprofile = "~/Images/star/red.png";
                                        }



                                        //-----------Select LLR Id and Name
                                    }
                                    else
                                    {
                                        LLRId = "Not Present";
                                        LLRName = "Not Present";
                                    }



                                }
                                else
                                {
                                    LeftLeftId = "Not Present";
                                    LeftLeftName = "Not Present";
                                }
                                if (binary1.rperson == 1)
                                {
                                    //-----------Select Left Ki Right Id and Name
                                    var user2 = db.AgentDetails.Single(a => a.uid == binary1.downright);
                                    var binary2 = db.binarys.Single(a => a.Id == binary1.downright);
                                    LeftRightId = user2.NewAgentId;
                                    LeftRightName = user2.name;

                                    if (user2.Status == 1)
                                    {
                                        LRprofile = "~/Images/star/green.png";
                                    }
                                    else
                                    {
                                        LRprofile = "~/Images/star/red.png";
                                    }
                                    //-----------End Select Left Ki Right Id and Name


                                    if (binary2.lperson == 1)
                                    {
                                        //-----------Select LRL Id and Name
                                        var LRLuser = db.AgentDetails.Single(a => a.uid == binary2.downleft);
                                        var LRLbinary = db.binarys.Single(a => a.Id == binary2.downleft);
                                        LRLId = LRLuser.NewAgentId;
                                        LRLName = LRLuser.name;

                                        if (LRLuser.Status == 1)
                                        {
                                            LRLprofile = "~/Images/star/green.png";
                                        }
                                        else
                                        {
                                            LRLprofile = "~/Images/star/red.png";
                                        }
                                        //-----------End Select LRL Id and Name

                                    }
                                    else
                                    {
                                        LRLId = "Not Present";
                                        LRLName = "Not Present";
                                    }


                                    if (binary2.rperson == 1)
                                    {
                                        //-----------Select LRR Id and Name

                                        var LRRuser = db.AgentDetails.Single(a => a.uid == binary2.downright);
                                        var LRRbinary = db.binarys.Single(a => a.Id == binary2.downright);
                                        LRRId = LRRuser.NewAgentId;
                                        LRRName = LRRuser.name;


                                        if (LRRuser.Status == 1)
                                        {
                                            LRRprofile = "~/Images/star/green.png";
                                        }
                                        else
                                        {
                                            LRRprofile = "~/Images/star/red.png";
                                        }

                                        //-----------End Select LRR Id and Name

                                    }
                                    else
                                    {
                                        LRRId = "Not Present";
                                        LRRName = "Not Present";
                                    }


                                }
                                else
                                {
                                    LeftRightId = "Not Present";
                                    LeftRightName = "Not Present";
                                }
                            }
                            else
                            {
                                LeftId = "Not Present";
                                LeftName = "Not Present";
                            }
                            if (binary.rperson == 1)
                            {
                                //-----------Select Right Id and Name
                                var user1 = db.AgentDetails.Single(a => a.uid == binary.downright);
                                var binary1 = db.binarys.Single(a => a.Id == binary.downright);
                                RightId = user1.NewAgentId;
                                RightName = user1.name;



                                if (user1.Status == 1)
                                {
                                    Rprofile = "~/Images/star/green.png";
                                }
                                else
                                {
                                    Rprofile = "~/Images/star/red.png";
                                }
                                //-----------End Select Right Id and Name
                                if (binary1.lperson == 1)
                                {
                                    //-----------Select Right Ki Left Id and Name
                                    var user2 = db.AgentDetails.Single(a => a.uid == binary1.downleft);
                                    var binary2 = db.binarys.Single(a => a.Id == binary1.downleft);
                                    RightLeftId = user2.NewAgentId;
                                    RightLeftName = user2.name;

                                    if (user2.Status == 1)
                                    {
                                        RLprofile = "~/Images/star/green.png";
                                    }
                                    else
                                    {
                                        RLprofile = "~/Images/star/red.png";
                                    }
                                    //-----------Select Right Ki Left Id and Name

                                    if (binary2.lperson == 1)
                                    {
                                        //-----------Select RLL Id and Name

                                        var RLLuser = db.AgentDetails.Single(a => a.uid == binary2.downleft);
                                        var RLLbinary = db.binarys.Single(a => a.Id == binary2.downleft);
                                        RLLId = RLLuser.NewAgentId;
                                        RLLName = RLLuser.name;

                                        if (RLLuser.Status == 1)
                                        {
                                            RLLprofile = "~/Images/star/green.png";
                                        }
                                        else
                                        {
                                            RLLprofile = "~/Images/star/red.png";
                                        }

                                        //-----------End Select RLL Id and Name

                                    }
                                    else
                                    {
                                        RLLId = "Not Present";
                                        RLLName = "Not Present";
                                    }

                                    if (binary2.rperson == 1)
                                    {
                                        //-----------Select RLR Id and Name

                                        var RLRuser = db.AgentDetails.Single(a => a.uid == binary2.downright);
                                        var RLRbinary = db.binarys.Single(a => a.Id == binary2.downright);
                                        RLRId = RLRuser.NewAgentId;
                                        RLRName = RLRuser.name;

                                        if (RLRuser.Status == 1)
                                        {
                                            RLRprofile = "~/Images/star/green.png";
                                        }
                                        else
                                        {
                                            RLRprofile = "~/Images/star/red.png";
                                        }

                                        //-----------End Select RLR Id and Name
                                    }
                                    else
                                    {
                                        RLRId = "Not Present";
                                        RLRName = "Not Present";
                                    }


                                }
                                else
                                {
                                    RightLeftId = "Not Present";
                                    RightLeftName = "Not Present";
                                }
                                if (binary1.rperson == 1)
                                {
                                    //-----------Select Right Ki Right Id and Name
                                    var user2 = db.AgentDetails.Single(a => a.uid == binary1.downright);
                                    var binary2 = db.binarys.Single(a => a.Id == binary1.downright);
                                    RightRightId = user2.NewAgentId;
                                    RightRightName = user2.name;

                                    if (user2.Status == 1)
                                    {
                                        RRprofile = "~/Images/star/green.png";
                                    }
                                    else
                                    {
                                        RRprofile = "~/Images/star/red.png";
                                    }
                                    //-----------Select Right Ki Right Id and Name


                                    if (binary2.lperson == 1)
                                    {
                                        //-----------Select RRL Id and Name

                                        var RRluser = db.AgentDetails.Single(a => a.uid == binary2.downleft);
                                        var RRLbinary = db.binarys.Single(a => a.Id == binary2.downleft);
                                        RRLId = RRluser.NewAgentId;
                                        RRLName = RRluser.name;

                                        if (RRluser.Status == 1)
                                        {
                                            RRLprofile = "~/Images/star/green.png";
                                        }
                                        else
                                        {
                                            RRLprofile = "~/Images/star/red.png";
                                        }

                                        //-----------End Select RRL Id and Name
                                    }
                                    else
                                    {
                                        RRLId = "Not Present";
                                        RRLName = "Not Present";
                                    }

                                    if (binary2.rperson == 1)
                                    {
                                        //-----------Select RRR Id and Name

                                        var RRRuser = db.AgentDetails.Single(a => a.uid == binary2.downright);
                                        var RRRbinary = db.binarys.Single(a => a.Id == binary2.downright);
                                        RRRId = RRRuser.NewAgentId;
                                        RRRName = RRRuser.name;


                                        if (RRRuser.Status == 1)
                                        {
                                            RRRprofile = "~/Images/star/green.png";
                                        }
                                        else
                                        {
                                            RRRprofile = "~/Images/star/red.png";
                                        }

                                        //-----------End Select RRR Id and Name
                                    }
                                    else
                                    {
                                        RRLId = "Not Present";
                                        RRLName = "Not Present";
                                    }

                                }
                                else
                                {
                                    RightRightId = "Not Present";
                                    RightRightName = "Not Present";
                                }

                            }
                            else
                            {
                                RightId = "Not Present";
                                RightName = "Not Present";
                            }

                        }
                        else
                        {
                            MainId = "Not Present";
                            MainName = "Not Present";
                        }
                        down.Add(new Downline1
                        {

                            MainId = MainId,
                            MainName = MainName,
                            LeftId = LeftId,
                            LeftName = LeftName,
                            RightId = RightId,
                            RightName = RightName,
                            LeftLeftId = LeftLeftId,
                            LeftLeftName = LeftLeftName,
                            LeftRightId = LeftRightId,
                            LeftRightName = LeftRightName,
                            RightRightId = RightRightId,
                            RightRightName = RightRightName,
                            RightLeftId = RightLeftId,
                            RightLeftName = RightLeftName,
                            LLLId = LLLId,
                            LLLName = LLLName,
                            LLRId = LLRId,
                            LLRName = LLRName,
                            LRLId = LRLId,
                            LRLName = LRLName,
                            LRRId = LRRId,
                            LRRName = LRRName,
                            RLLId = RLLId,
                            RLLName = RLLName,
                            RLRId = RLRId,
                            RLRName = RLRName,
                            RRLId = RRLId,
                            RRLName = RRLName,
                            RRRId = RRRId,
                            RRRName = RRRName,
                            Mprofile = Mprofile,
                            Lprofile = Lprofile,
                            Rprofile = Rprofile,
                            LRprofile = LRprofile,
                            LLprofile = LLprofile,
                            RRprofile = RRprofile,
                            RLprofile = RLprofile,
                            LLLprofile = LLLprofile,
                            LLRprofile = LLRprofile,
                            LRLprofile = LRLprofile,
                            LRRprofile = LRRprofile,
                            RLLprofile = RLLprofile,
                            RLRprofile = RLRprofile,
                            RRLprofile = RRLprofile,
                            RRRprofile = RRRprofile,
                            LastLeftId = lastid.ToString(),
                            LastLeftName = lastname.ToString(),
                            LastLeftProfile = lastprofile.ToString(),
                            LastRightId = lastrightid.ToString(),
                            LastRightName = lastrightname.ToString(),
                            LastRigthProfile = lastrightprofile.ToString()

                        });
                    }

                }
                else
                {
                    TempData["newid2"] = newid;
                    TempData["erromsg22"] = "This is not in your downline..";
                    return RedirectToAction("BTree", "Member");
                }
                ViewData["cmid"] = newid;
                return View(down);

            }
        }

        [HttpGet]
        public ActionResult DirectReferal()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }

            return View();
        }

        [HttpGet]
        public ActionResult TotalBinary(string memberid, string sdate, string edate, string pin, string command, int? page, int excel = 0)
        {
            List<temptotaldownline> tempdownline = new List<temptotaldownline>();
            var ssdate = String.Empty;
            var eedate = String.Empty;

            if (!string.IsNullOrWhiteSpace(sdate) && !string.IsNullOrWhiteSpace(edate))
            {
                DateTime startdate = Convert.ToDateTime(sdate);
                DateTime enddate = Convert.ToDateTime(edate);
                tempdownline = db.Database.SqlQuery<temptotaldownline>("select bt.newmemberid as memberid,at.name as username,convert(float,bt.amount) as pinamount,convert(float,bt.leftbusiness) as leftbv,convert(float,bt.rightbusiness) as rightbv,bt.payout_date as joindate,bt.carryleft as position,convert(float,bt.carryright) as SelfBV from matching_income_detail as bt inner join agentdetail as at on bt.newmemberid=at.newagentid  where bt.newmemberid='" + memberid + "' AND bt.payout_date between '" + startdate + "' and '" + enddate + "' group by bt.newmemberid,at.name, bt.payout_date,bt.amount,bt.leftbusiness,bt.rightbusiness,bt.carryleft,bt.carryright").ToList();
                ssdate = Convert.ToDateTime(sdate).ToString();
                eedate = Convert.ToDateTime(edate).ToString();
            }
            else
            {
                ssdate = "1990-01-01";
                eedate = "1990-01-01";
            }

            ViewData["sdate"] = ssdate;
            ViewData["edate"] = eedate;
            ViewData["memberid"] = memberid;
            ViewData["pin"] = pin;
            ViewData["command"] = command;
            var temp = ViewData["data2"] as List<temptotaldownline>;

            int pageSize = 500;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewData["pageno"] = pageIndex;
            int akhiri = (pageIndex - 1) * 500;
            ViewData["srno"] = akhiri;
            IPagedList<temptotaldownline> stu = null;

            if (command == "Search")
            {
               
                    List<temptotaldownline> temp1 = new List<temptotaldownline>();
                    temp1 = tempdownline;
                    TempData["data2"] = temp1;
                    TempData.Keep("data2");

                    stu = tempdownline.ToPagedList(pageIndex, pageSize);
                    return View(stu);
            }


            if (page != null)
            {
                TempData.Keep("data2");
                temp = TempData["data2"] as List<temptotaldownline>;
                stu = temp.ToPagedList(pageIndex, pageSize);
                if (excel != 0)
                {
                    WebGrid grid = new WebGrid(null, rowsPerPage: temp.Count());
                    grid.Bind(temp, autoSortAndPage: true, rowCount: temp.Count());
                    string griddata = grid.GetHtml(
                    columns: grid.Columns(
                    grid.Column("memberid", "Member Id"),
                    grid.Column("username", "Member Name"),
                   grid.Column("join_date", "Date"),
                    grid.Column("leftbv", "Left Business"),
                    grid.Column("rightbv", "Right Business"),
                     grid.Column("pinamount", "Amount"),
                     grid.Column("position", "Left Carry"),
                    grid.Column("SelfBV", "Right Carry")
                    )).ToString();
                    Response.ClearContent();
                    Response.AddHeader("content-disposition", "attachment; filename=Matching_Summary.xlsx");
                    Response.ContentType = "application/excel";
                    Response.Write(griddata);
                    Response.End();
                }

                return View(stu);
            }
            else
            {

                return View();
            }
        }

        [HttpGet]
        public ActionResult TotalBusiness(string memberid, string sdate, string edate, string status, string pin, string command, int? page, int excel = 0, int position = 0)
        {
            var treevalidation = 1;    
            List<temptotaldownline> tempdownline = new List<temptotaldownline>();
            var ssdate = String.Empty;
            var eedate = String.Empty;
            
            if (!string.IsNullOrWhiteSpace(sdate) && !string.IsNullOrWhiteSpace(edate))
            {
                DateTime startdate = Convert.ToDateTime(sdate);
                DateTime enddate = Convert.ToDateTime(edate);
                tempdownline = db.Database.SqlQuery<temptotaldownline>("select sum(bt.rs) as pinamount,bt.cust_id as status1,bt.join_date as joindate,at.newbondid as introducerid,at.name as introname,bt.position as position from businesstab as bt inner join appltab as at on bt.cust_id=at.bondid  where bt.newid='" + User.Identity.Name + "' AND bt.join_date between '" + startdate + "' and '" + enddate + "' group by bt.join_date, bt.cust_id,at.newbondid,at.name,bt.position").ToList();
            }
            else
            {
                tempdownline = db.Database.SqlQuery<temptotaldownline>("select sum(bt.rs) as pinamount,bt.cust_id as status1,bt.join_date as joindate,at.newbondid as introducerid,at.name as introname,bt.position as position  from businesstab as bt inner join appltab as at on bt.cust_id=at.bondid  where bt.newid='" + User.Identity.Name + "' group by bt.join_date, bt.cust_id,at.newbondid,at.name,bt.position").ToList();
                ssdate = "1990-01-01";
                eedate = "1990-01-01";
            }
           
            ViewData["sdate"] = ssdate;
            ViewData["edate"] = eedate;
            ViewData["memberid"] = memberid;
            ViewData["status"] = status;
            ViewData["pin"] = pin;
            ViewData["command"] = command;
            var temp = ViewData["data2"] as List<temptotaldownline>;
            

            int pageSize = 500;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewData["pageno"] = pageIndex;
            int akhiri = (pageIndex - 1) * 500;
            ViewData["srno"] = akhiri;
            IPagedList<temptotaldownline> stu = null;
            if (command == "Search")
            {
                if (treevalidation == 1)
                {

                    List<temptotaldownline> temp1 = new List<temptotaldownline>();
                    temp1 = tempdownline;
                    TempData["data2"] = temp1;
                    TempData.Keep("data2");

                    stu = tempdownline.ToPagedList(pageIndex, pageSize);
                    return View(stu);
                }

                else
                {
                    TempData["newid2"] = memberid;
                    TempData["erromsg22"] = "Your are not authorized person for ";
                    return View();
                }
            }
            if (page != null)
            {
                TempData.Keep("data2");
                temp = TempData["data2"] as List<temptotaldownline>;
                stu = temp.ToPagedList(pageIndex, pageSize);
                if (excel != 0)
                {
                    WebGrid grid = new WebGrid(null, rowsPerPage: temp.Count());
                    grid.Bind(temp, autoSortAndPage: true, rowCount: temp.Count());
                    string griddata = grid.GetHtml(
                    columns: grid.Columns(
                    grid.Column("introducerid", "Customer Id"),
                    grid.Column("introname", "Customer Name"),
                    grid.Column("join_date", "Business Date"),
                    grid.Column("positionss", "Position"),
                    grid.Column("pinamount", "Business")
                  
                    )).ToString(); ;
                    Response.ClearContent();
                    Response.AddHeader("content-disposition", "attachment; filename=Customer_Details.xlsx");
                    Response.ContentType = "application/excel";
                    Response.Write(griddata);
                    Response.End();
                }

                return View(stu);
            }
            else
            {

                return View();
            }
        }

        public ActionResult Create_Pin(int? page)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                Create_Pin objStudent = new Create_Pin();
                List<Create_Pin> temppindetail = new List<Create_Pin>();
                SqlConnection con = new SqlConnection();
                DataSet ds = new DataSet();

                int pageSize = 50;
                int pageIndex = 1;
                pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
                ViewData["pageno"] = pageIndex;
                int akhiri = (pageIndex - 1) * 50;
                ViewData["srno"] = akhiri;
                IPagedList<Create_Pin> stu = null;
                SqlCommand cmd = new SqlCommand();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "select * from Create_Pin where srno>0  and Id='" + User.Identity.Name + "'";
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            temppindetail.Add(new Create_Pin
                            {
                                ID = item["ID"].ToString(),
                                Total_Pin = item["Total_Pin"].ToString(),
                                Pin_Amount = Convert.ToDouble(item["Pin_Amount"]),
                                Date = Convert.ToDateTime(item["Date"])



                            });
                        }

                    }
                }

                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                }
                finally
                {
                    con.Close();
                }
                stu = temppindetail.ToPagedList(pageIndex, pageSize);
                //var memlist = db.AgentDetails.Where(a => a.joindate >= sdate && a.joindate <= edate).ToList();
                return View(stu);
            }
        }
        public ActionResult Transfer_Pin_Report()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Successfully()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {

                ViewData["msg"] = TempData["msg"];

            }
            return View();
        }

        //[HttpGet]
        //public ActionResult BulkNewJoining()
        //{

        //    return View();
        //}

        //[HttpPost]
        //public ActionResult BulkNewJoining(AgentDetail model, HttpPostedFileBase Photo, string pin, string Introducer1, int DOB = 0)
        //{
        //    System.Threading.Thread.Sleep(2000);

        //    var introcount = db.AgentDetails.Where(cc => cc.NewAgentId == Introducer1).Count();

        //    if (introcount != 0)
        //    {
        //        var uid1 = 0;
        //        string pwd = gid();

        //        // +1 Member Id Increasing

        //        int maxid = (from a in db.AgentDetails select a).Count();

        //        var newmemberid = "GLC" + gid();
        //        var newid = string.Empty;

        //        var countnewid = db.AgentDetails.Where(a => a.NewAgentId == newmemberid).Count();
        //        if (countnewid == 0)
        //        {
        //            newid = newmemberid;
        //        }
        //        else
        //        {
        //            newid = "GLC" + gid();
        //        }


        //        // ------------------------------ Spild Id -------------------------------------

        //        var userdata = db.AgentDetails.Single(s => s.NewAgentId == Introducer1);

        //        string spildnewid = string.Empty;
        //        string spildnewid2 = string.Empty;

        //        var countt = db.binarys.Where(c => c.Id == userdata.uid).ToList().Count();
        //        if (countt < 1)
        //        {
        //            ViewBag.msg = "Please Enter Valid Id";
        //        }
        //        else
        //        {

        //            var count2 = db.binarys.Single(c => c.Id == userdata.uid);

        //            if (count2.pair == 0)
        //            {
        //                spildnewid = userdata.NewAgentId;
        //            }
        //            else
        //            {
        //                spildnewid = userdata.NewAgentId;
        //            }

        //        }


        //        var spilr = db.AgentDetails.Single(a => a.NewAgentId == spildnewid);
        //        if (model.position == 0)
        //        {

        //        }
        //        else if (model.position == 1)
        //        {
        //            var downleft = 0;
        //            var lperson = 0;
        //            var id = 0;
        //            var binary = db.binarys.Single(a => a.Id == spilr.uid);
        //            lperson = binary.lperson;
        //            downleft = binary.downleft;
        //            id = spilr.uid;
        //            while (lperson != 0)
        //            {
        //                var binary1 = db.binarys.Single(a => a.Id == downleft);
        //                lperson = binary1.lperson;
        //                downleft = binary1.downleft;
        //                id = binary1.Id;
        //            }

        //            var uy = db.AgentDetails.Single(n => n.uid == id);
        //            spildnewid2 = uy.NewAgentId;

        //        }
        //        else if (model.position == 2)
        //        {
        //            var downright = 0;
        //            var rperson = 0;
        //            var id = 0;
        //            var binary = db.binarys.Single(a => a.Id == spilr.uid);
        //            rperson = binary.rperson;
        //            downright = binary.downright;
        //            id = spilr.uid;
        //            while (rperson != 0)
        //            {
        //                var binary1 = db.binarys.Single(a => a.Id == downright);
        //                rperson = binary1.rperson;
        //                downright = binary1.downright;
        //                id = binary1.Id;
        //            }

        //            var uy = db.AgentDetails.Single(n => n.uid == id);
        //            spildnewid2 = uy.NewAgentId;

        //        }
        //        // ------------------------------ Spild Id -------------------------------------

        //        string nxtsun = DateTime.Now.AddDays(7 - (int)DateTime.Now.DayOfWeek).ToShortDateString();
        //        var count = db.AgentDetails.Where(a => a.NewAgentId == Introducer1).Count();
        //        if (count == 1)
        //        {
        //            var Singleuser = db.AgentDetails.Single(a => a.NewAgentId == spildnewid2);
        //            var Filluser = new AgentDetail();
        //            var Fillbinary = new binary();
        //            var genology = new genology_tab();
        //            var Updatebinary = db.binarys.Single(a => a.Id == Singleuser.uid);
        //            var intro = db.AgentDetails.Single(a => a.NewAgentId == Introducer1);
        //            var FillLogin = new newlogin();
        //            var Fillspil = new spiltab();
        //            //-------Fill User Info Table---------------------
        //            Filluser.NewAgentId = newid;
        //            if (model.position == 1)
        //            {
        //                Filluser.position = 1;
        //                uid1 = Updatebinary.downleft;
        //                Updatebinary.lperson = 1;

        //            }
        //            else if (model.position == 2)
        //            {
        //                Filluser.position = 2;
        //                uid1 = Updatebinary.downright;
        //                Updatebinary.rperson = 1;
        //            }
        //            Filluser.uid = uid1;
        //            Filluser.joindate = DateTime.Now.Date;
        //            Filluser.dob = DateTime.Now.Date;
        //            Filluser.spillid = Singleuser.NewAgentId;
        //            Filluser.introducerid = Introducer1;
        //            Filluser.rank = 0;
        //            Filluser.activationdate = DateTime.Now.Date;
        //            if (model.dob == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
        //            {
        //                Filluser.dob = DateTime.Now;
        //            }
        //            else
        //            {
        //                Filluser.dob = model.dob;
        //            }
        //            Filluser.name = model.name;
        //            Filluser.mobile = model.mobile;
        //            Filluser.nominee = model.nominee;
        //            Filluser.address = model.address;
        //            Filluser.opid = "GLC00000001";



        //            db.AgentDetails.Add(Filluser);
        //            db.Entry(Updatebinary).State = EntityState.Modified;
        //            db.SaveChanges();
        //            //-------End User Info Table---------------------

        //            //------- Wallettab Entry ------------------------
        //            var wt1 = new wallettab();
        //            wt1.amount = 0;
        //            wt1.UserId = newid;
        //            db.wallettabs.Add(wt1);
        //            db.SaveChanges();

        //            //------------------------------------------------

        //            //-------Insert Binary Table---------------------

        //            var max = (from o in db.binarys select o.downright).Max();
        //            Fillbinary.Id = uid1;
        //            Fillbinary.intid = Singleuser.uid;
        //            Fillbinary.lperson = 0;
        //            Fillbinary.rperson = 0;
        //            Fillbinary.pair = 0;
        //            Fillbinary.upline = "upline";
        //            Fillbinary.downleft = max + 1;
        //            Fillbinary.downright = max + 2;
        //            Fillbinary.completelevel = 0;
        //            db.binarys.Add(Fillbinary);
        //            db.SaveChanges();

        //            //-------End insert Binary Table---------------------

        //            //-----------Fill Login Tab-----------
        //            FillLogin.userid = newid;
        //            FillLogin.password = pwd;
        //            FillLogin.type = "Member";
        //            FillLogin.status = 1;
        //            FillLogin.reg_date = DateTime.Now.Date;
        //            db.NewLogins.Add(FillLogin);
        //            db.SaveChanges();
        //            //-----------End Fill Login Tab-----------

        //            //-------Update Binary Table---------------------
        //            var Checkbinary = db.binarys.Single(a => a.Id == Singleuser.uid);
        //            if (Checkbinary.rperson == 1 && Checkbinary.lperson == 1)
        //            {
        //                Checkbinary.pair = 1;
        //            }


        //            //-------End Update Binary Table---------------------
        //            //---Insert Into Spiltab -------------------


        //            Fillspil.custid = uid1;
        //            Fillspil.spilid = Singleuser.Id;
        //            Fillspil.intid = intro.Id;
        //            db.spiltabs.Add(Fillspil);
        //            //------End spiltab------------------

        //            //----------Insert Genology Table All Chain----------------
        //            var introducer = 0;
        //            var custid = uid1;
        //            while (introducer != 1)
        //            {
        //                var usertab = db.AgentDetails.Single(a => a.uid == custid);

        //                var introdd = db.AgentDetails.Single(bb => bb.NewAgentId == usertab.spillid);
        //                introducer = introdd.uid;
        //                var introdetail = db.AgentDetails.Single(a => a.uid == introducer);
        //                genology.id = introdd.uid;
        //                genology.newid = introdetail.NewAgentId;
        //                genology.position = usertab.position;
        //                genology.cust_id = uid1;
        //                genology.rank = 1;
        //                genology.join_date = DateTime.Now.Date;
        //                genology.rs = 0.0;
        //                genology.paid_status = 0;
        //                genology.paid_status_level = 0;
        //                db.genology_tabs.Add(genology);
        //                db.SaveChanges();
        //                custid = introducer;
        //            }

        //            //----------End Genology Table All Chain-------------------

        //            var user = db.AgentDetails.Single(d => d.NewAgentId == newid);

        //            var asign = new PackageAssign();

        //            asign.CapLimit = "0";
        //            asign.DSI = 0;
        //            asign.MemberId = user.Id;
        //            asign.MemberIntroId = intro.NewAgentId;
        //            asign.MemberIntroName = intro.name;
        //            asign.MemberNewId = user.NewAgentId;
        //            asign.MemberRegisDate = user.joindate;
        //            asign.Package = 0;
        //            asign.PackageIssueDate = DateTime.Now.Date;
        //            asign.PV = 0;
        //            asign.MemberName = user.name;
        //            asign.PackagePin = pin;
        //            db.PackageAssigns.Add(asign);
        //            db.SaveChanges();

        //            var comp = db.CompanyInfos.Single(c => c.Id == 1);

        //            Response.Write("<script>alert('Member is Successfully Registered')</script>");
        //            TempData["msg"] = "Dear " + model.name + ",Your NewAgentId is: " + newid + " and Password:" + pwd.ToString() + ".you are successfully registered with" + @comp.WebContactNo + "";
        //            MyClass.Sendmsg(model.mobile, "Dear " + model.name + ",Your NewAgentId is: " + newid + "and Password:" + pwd.ToString() + ". you are successfully registered with " + @comp.WebContactNo + " ");
        //            return RedirectToAction("successfull", "Home");

        //        }
        //        else
        //        {
        //            Response.Write("<script>alert('This Introducer Id is Invalid')</script>");
        //            ViewData["msg"] = "This Introducer Id Invalid";
        //        }
        //    }
        //    else
        //    {
        //        Response.Write("<script>alert('This Introducer Id is Invalid')</script>");
        //    }
        //    return View();
        //}

        [HttpGet]
        public ActionResult successfull()
        {
            ViewData["msg"] = TempData["msg"];
            return View();
        }

        //[HttpGet]
        //public ActionResult BulkNewJoining()
        //{
        //    if (!User.Identity.IsAuthenticated)
        //    {
        //        return RedirectToAction("Logout", "Member");
        //    }
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult BulkNewJoining(AgentDetail model, HttpPostedFileBase Photo, string pin, string Introducer1, int noj = 0, int DOB = 0)
        //{
        //    if (!User.Identity.IsAuthenticated)
        //    {
        //        return RedirectToAction("Logout", "Member");
        //    }
        //    else
        //    {
        //        System.Threading.Thread.Sleep(2000);

        //        var introcount = db.AgentDetails.Where(cc => cc.NewAgentId == Introducer1).Count();
        //        var comp = db.CompanyInfos.Single(a => a.Id == 1);
        //        string topnewid = string.Empty;
        //        if (introcount != 0)
        //        {
        //            int i = 1;
        //            while (i <= noj)
        //            {

        //                var uid1 = 0;
        //                string pwd = gid();

        //                // +1 Member Id Increasing

        //                int maxid = (from a in db.AgentDetails select a).Count();

        //                var newmemberid = comp.NewidPrefix + gid();


        //                var newid = string.Empty;

        //                var countnewid = db.AgentDetails.Where(a => a.NewAgentId == newmemberid).Count();
        //                if (countnewid == 0)
        //                {
        //                    newid = newmemberid;
        //                }
        //                else
        //                {
        //                    newid = comp.NewidPrefix + gid();
        //                }

        //                if (i == 1)
        //                {
        //                    topnewid = newmemberid;
        //                }

        //                // ------------------------------ Spild Id -------------------------------------

        //                var userdata = db.AgentDetails.Single(s => s.NewAgentId == Introducer1);

        //                string spildnewid = string.Empty;
        //                string spildnewid2 = string.Empty;

        //                var countt = db.binarys.Where(c => c.Id == userdata.uid).ToList().Count();
        //                if (countt < 1)
        //                {
        //                    ViewBag.msg = "Please Enter Valid Id";
        //                }
        //                else
        //                {

        //                    var count2 = db.binarys.Single(c => c.Id == userdata.uid);

        //                    if (count2.pair == 0)
        //                    {
        //                        spildnewid = userdata.NewAgentId;
        //                    }
        //                    else
        //                    {
        //                        spildnewid = userdata.NewAgentId;
        //                    }

        //                }


        //                var spilr = db.AgentDetails.Single(a => a.NewAgentId == spildnewid);
        //                if (model.position == 0)
        //                {

        //                }
        //                else if (model.position == 1)
        //                {
        //                    var downleft = 0;
        //                    var lperson = 0;
        //                    var id = 0;
        //                    var binary = db.binarys.Single(a => a.Id == spilr.uid);
        //                    lperson = binary.lperson;
        //                    downleft = binary.downleft;
        //                    id = spilr.uid;
        //                    while (lperson != 0)
        //                    {
        //                        var binary1 = db.binarys.Single(a => a.Id == downleft);
        //                        lperson = binary1.lperson;
        //                        downleft = binary1.downleft;
        //                        id = binary1.Id;
        //                    }

        //                    var uy = db.AgentDetails.Single(n => n.uid == id);
        //                    spildnewid2 = uy.NewAgentId;

        //                }
        //                else if (model.position == 2)
        //                {
        //                    var downright = 0;
        //                    var rperson = 0;
        //                    var id = 0;
        //                    var binary = db.binarys.Single(a => a.Id == spilr.uid);
        //                    rperson = binary.rperson;
        //                    downright = binary.downright;
        //                    id = spilr.uid;
        //                    while (rperson != 0)
        //                    {
        //                        var binary1 = db.binarys.Single(a => a.Id == downright);
        //                        rperson = binary1.rperson;
        //                        downright = binary1.downright;
        //                        id = binary1.Id;
        //                    }

        //                    var uy = db.AgentDetails.Single(n => n.uid == id);
        //                    spildnewid2 = uy.NewAgentId;

        //                }
        //                // ------------------------------ Spild Id -------------------------------------

        //                string nxtsun = DateTime.Now.AddDays(7 - (int)DateTime.Now.DayOfWeek).ToShortDateString();
        //                var count = db.AgentDetails.Where(a => a.NewAgentId == Introducer1).Count();
        //                if (count == 1)
        //                {
        //                    var Singleuser = db.AgentDetails.Single(a => a.NewAgentId == spildnewid2);
        //                    var Filluser = new AgentDetail();
        //                    var Fillbinary = new binary();
        //                    var genology = new genology_tab();
        //                    var Updatebinary = db.binarys.Single(a => a.Id == Singleuser.uid);
        //                    var intro = db.AgentDetails.Single(a => a.NewAgentId == Introducer1);
        //                    var FillLogin = new newlogin();
        //                    var Fillspil = new spiltab();
        //                    //-------Fill User Info Table---------------------
        //                    Filluser.NewAgentId = newid;
        //                    if (model.position == 1)
        //                    {
        //                        Filluser.position = 1;
        //                        uid1 = Updatebinary.downleft;
        //                        Updatebinary.lperson = 1;

        //                    }
        //                    else if (model.position == 2)
        //                    {
        //                        Filluser.position = 2;
        //                        uid1 = Updatebinary.downright;
        //                        Updatebinary.rperson = 1;
        //                    }
        //                    Filluser.uid = uid1;
        //                    Filluser.joindate = DateTime.Now.Date;
        //                    Filluser.dob = DateTime.Now.Date;
        //                    Filluser.spillid = Singleuser.NewAgentId;
        //                    Filluser.introducerid = Introducer1;
        //                    Filluser.rank = 0;
        //                    Filluser.Topnewid = topnewid;
        //                    Filluser.activationdate = DateTime.Now.Date;
        //                    if (model.dob == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
        //                    {
        //                        Filluser.dob = DateTime.Now;
        //                    }
        //                    else
        //                    {
        //                        Filluser.dob = model.dob;
        //                    }
        //                    Filluser.name = model.name;
        //                    Filluser.RegistrationType = "Bulk";
        //                    Filluser.mobile = model.mobile;
        //                    Filluser.nominee = model.nominee;
        //                    Filluser.address = model.address;
        //                    Filluser.opid = User.Identity.Name;



        //                    db.AgentDetails.Add(Filluser);
        //                    db.Entry(Updatebinary).State = EntityState.Modified;
        //                    db.SaveChanges();
        //                    //-------End User Info Table---------------------

        //                    //------- Wallettab Entry ------------------------
        //                    var wt1 = new wallettab();
        //                    wt1.amount = 0;
        //                    wt1.UserId = newid;
        //                    db.wallettabs.Add(wt1);
        //                    db.SaveChanges();

        //                    //------------------------------------------------

        //                    //-------Insert Binary Table---------------------

        //                    var max = (from o in db.binarys select o.downright).Max();
        //                    Fillbinary.Id = uid1;
        //                    Fillbinary.intid = Singleuser.uid;
        //                    Fillbinary.lperson = 0;
        //                    Fillbinary.rperson = 0;
        //                    Fillbinary.pair = 0;
        //                    Fillbinary.upline = "upline";
        //                    Fillbinary.downleft = max + 1;
        //                    Fillbinary.downright = max + 2;
        //                    Fillbinary.completelevel = 0;
        //                    db.binarys.Add(Fillbinary);
        //                    db.SaveChanges();

        //                    //-------End insert Binary Table---------------------

        //                    //-----------Fill Login Tab-----------
        //                    FillLogin.userid = newid;
        //                    FillLogin.password = pwd;
        //                    FillLogin.type = "Member";
        //                    FillLogin.status = 1;
        //                    FillLogin.reg_date = DateTime.Now.Date;
        //                    db.NewLogins.Add(FillLogin);
        //                    db.SaveChanges();
        //                    //-----------End Fill Login Tab-----------

        //                    //-------Update Binary Table---------------------
        //                    var Checkbinary = db.binarys.Single(a => a.Id == Singleuser.uid);
        //                    if (Checkbinary.rperson == 1 && Checkbinary.lperson == 1)
        //                    {
        //                        Checkbinary.pair = 1;
        //                    }


        //                    //-------End Update Binary Table---------------------
        //                    //---Insert Into Spiltab -------------------


        //                    Fillspil.custid = uid1;
        //                    Fillspil.spilid = Singleuser.Id;
        //                    Fillspil.intid = intro.Id;
        //                    db.spiltabs.Add(Fillspil);
        //                    //------End spiltab------------------

        //                    //----------Insert Genology Table All Chain----------------
        //                    var introducer = 0;
        //                    var custid = uid1;
        //                    while (introducer != 1)
        //                    {
        //                        var usertab = db.AgentDetails.Single(a => a.uid == custid);

        //                        var introdd = db.AgentDetails.Single(bb => bb.NewAgentId == usertab.spillid);
        //                        introducer = introdd.uid;
        //                        var introdetail = db.AgentDetails.Single(a => a.uid == introducer);
        //                        genology.id = introdd.uid;
        //                        genology.newid = introdetail.NewAgentId;
        //                        genology.position = usertab.position;
        //                        genology.cust_id = uid1;
        //                        genology.rank = 1;
        //                        genology.join_date = DateTime.Now.Date;
        //                        genology.rs = 0.0;
        //                        genology.paid_status = 0;
        //                        genology.paid_status_level = 0;
        //                        db.genology_tabs.Add(genology);
        //                        db.SaveChanges();
        //                        custid = introducer;
        //                    }

        //                    //----------End Genology Table All Chain-------------------

        //                    var user = db.AgentDetails.Single(d => d.NewAgentId == newid);

        //                    var asign = new PackageAssign();

        //                    asign.CapLimit = "0";
        //                    asign.DSI = 0;
        //                    asign.MemberId = user.Id;
        //                    asign.MemberIntroId = intro.NewAgentId;
        //                    asign.MemberIntroName = intro.name;
        //                    asign.MemberNewId = user.NewAgentId;
        //                    asign.MemberRegisDate = user.joindate;
        //                    asign.Package = 0;
        //                    asign.PackageIssueDate = DateTime.Now.Date;
        //                    asign.PV = 0;
        //                    asign.MemberName = user.name;
        //                    asign.PackagePin = pin;
        //                    db.PackageAssigns.Add(asign);
        //                    db.SaveChanges();



        //                    var introcountpool = db.AgentDetails.Where(a => a.introducerid == Introducer1).Count();

        //                    if (introcountpool == 2)
        //                    {
        //                        con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //                        SqlCommand cmd = new SqlCommand();
        //                        cmd.Connection = con;
        //                        cmd.CommandText = "autopoolfill";
        //                        cmd.CommandType = CommandType.StoredProcedure;
        //                        cmd.Parameters.AddWithValue("@Introducer1", Introducer1);

        //                        try
        //                        {
        //                            con.Open();
        //                            cmd.ExecuteNonQuery();
        //                        }
        //                        catch (SqlException ex)
        //                        {
        //                            ViewBag.msg = ex.Message;

        //                        }
        //                        finally
        //                        {
        //                            con.Close();
        //                        }

        //                    }
        //                    Response.Write("<script>alert('Member is Successfully Registered')</script>");
        //                    TempData["msg"] = "Dear " + model.name + ",Your Bulk NewAgentId registered successfully with" + @comp.WebContactNo + "";
        //                    MyClass.Sendmsg(model.mobile, "Dear " + model.name + ",Your NewAgentId is: " + newid + "and Password:" + pwd.ToString() + ". you are successfully registered with " + @comp.WebContactNo + " ");


        //                }
        //                else
        //                {
        //                    Response.Write("<script>alert('This Introducer Id is Invalid')</script>");
        //                    ViewData["msg"] = "This Introducer Id Invalid";
        //                }

        //                i = i + 1;
        //            }

        //            return RedirectToAction("successfull", "Member");
        //        }
        //        else
        //        {
        //            Response.Write("<script>alert('This Introducer Id is Invalid')</script>");
        //        }

        //    }
        //    return View();
        //}

        [HttpGet]
        public ActionResult leftmember(int? page, string memberid)
        {
            ViewData["NewAgentId"] = memberid;
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                if (page != null)
                {
                    genology_tab objStudent = new genology_tab();
                    List<genology_tab> tempbinaryleft = new List<genology_tab>();
                    SqlConnection con = new SqlConnection();
                    DataSet ds = new DataSet();
                    TempData["memb"] = memberid;
                    int pageSize = 50;
                    int pageIndex = 1;
                    pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
                    ViewData["pageno"] = pageIndex;
                    int akhiri = (pageIndex - 1) * 50;
                    ViewData["srno"] = akhiri;
                    IPagedList<genology_tab> stu = null;
                    SqlCommand cmd = new SqlCommand();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "select * from genology_tab where newid='" + memberid + "' and position=1 and rs<>0";
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    try
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow item in ds.Tables[0].Rows)
                            {
                                tempbinaryleft.Add(new genology_tab
                                {
                                    newid = item["newid"].ToString(),
                                    cust_id = Convert.ToInt32(item["cust_id"]),
                                    position = Convert.ToInt32(item["position"]),
                                    join_date = Convert.ToDateTime(item["join_date"])

                                });
                            }

                        }
                    }

                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('" + ex.Message + "')</script>");
                    }
                    finally
                    {
                        con.Close();
                    }
                    int totalleft = tempbinaryleft.Count();
                    TempData["left"] = totalleft;
                    stu = tempbinaryleft.ToPagedList(pageIndex, pageSize);
                    return View(stu);
                }
                else
                {
                    return View();
                }

            }
        }
        [HttpPost]
        public ActionResult leftmember(string memki_id, int? page)
        {
            ViewData["NewAgentId"] = memki_id;
            genology_tab objStudent = new genology_tab();
            List<genology_tab> tempbinaryleft = new List<genology_tab>();
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            TempData["memb"] = memki_id;
            int pageSize = 50;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewData["pageno"] = pageIndex;
            //int akhiri = (pageIndex - 1) * 50;
            //ViewData["srno"] = akhiri;
            IPagedList<genology_tab> stu = null;
            SqlCommand cmd = new SqlCommand();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "select * from genology_tab where newid='" + memki_id + "' and position=1 and rs<>0";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        tempbinaryleft.Add(new genology_tab
                        {
                            newid = item["newid"].ToString(),
                            cust_id = Convert.ToInt32(item["cust_id"]),
                            position = Convert.ToInt32(item["position"]),
                            join_date = Convert.ToDateTime(item["join_date"])

                        });
                    }

                }
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
            finally
            {
                con.Close();
            }

            int totalleft = tempbinaryleft.Count();
            TempData["left"] = totalleft;

            stu = tempbinaryleft.ToPagedList(pageIndex, pageSize);
            return View(stu);
        }

        [HttpGet]
        public ActionResult rightmember(int? page, string NewAgentId)
        {
            ViewData["NewAgentId"] = NewAgentId;
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {

                if (page != null)
                {
                    genology_tab objStudent = new genology_tab();
                    List<genology_tab> tempbinaryright = new List<genology_tab>();
                    SqlConnection con = new SqlConnection();
                    DataSet ds = new DataSet();
                    TempData["memb"] = NewAgentId;
                    int pageSize = 50;
                    int pageIndex = 1;
                    pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
                    ViewData["pageno"] = pageIndex;
                    int akhiri = (pageIndex - 1) * 50;
                    ViewData["srno"] = akhiri;
                    IPagedList<genology_tab> stu = null;
                    SqlCommand cmd = new SqlCommand();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "select * from genology_tab where newid='" + NewAgentId + "' and position=2 and rs<>0";
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    try
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow item in ds.Tables[0].Rows)
                            {
                                tempbinaryright.Add(new genology_tab
                                {
                                    newid = item["newid"].ToString(),
                                    cust_id = Convert.ToInt32(item["cust_id"]),
                                    position = Convert.ToInt32(item["position"]),
                                    join_date = Convert.ToDateTime(item["join_date"])

                                });
                            }

                        }
                    }

                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('" + ex.Message + "')</script>");
                    }
                    finally
                    {
                        con.Close();
                    }
                    int totalright = tempbinaryright.Count();
                    TempData["right"] = totalright;
                    stu = tempbinaryright.ToPagedList(pageIndex, pageSize);
                    return View(stu);
                }
                else
                {
                    return View();
                }
            }


        }
        [HttpPost]
        public ActionResult rightmember(string memki_id, int? page)
        {
            ViewData["NewAgentId"] = memki_id;
            genology_tab objStudent = new genology_tab();
            List<genology_tab> tempbinaryright = new List<genology_tab>();
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            TempData["memb"] = memki_id;
            int pageSize = 50;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewData["pageno"] = pageIndex;
            //int akhiri = (pageIndex - 1) * 50;
            //ViewData["srno"] = akhiri;
            IPagedList<genology_tab> stu = null;
            SqlCommand cmd = new SqlCommand();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "select * from genology_tab where newid='" + memki_id + "' and position=2 and rs<>0";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        tempbinaryright.Add(new genology_tab
                        {
                            newid = item["newid"].ToString(),
                            cust_id = Convert.ToInt32(item["cust_id"]),
                            position = Convert.ToInt32(item["position"]),
                            join_date = Convert.ToDateTime(item["join_date"])

                        });
                    }

                }
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
            finally
            {
                con.Close();
            }

            int totallright = tempbinaryright.Count();
            TempData["right"] = totallright;

            stu = tempbinaryright.ToPagedList(pageIndex, pageSize);
            return View(stu);

        }

        //[HttpGet]
        //public ActionResult BulkTopup()
        //{
        //    if (!User.Identity.IsAuthenticated)
        //    {
        //        return RedirectToAction("Logout", "Member");
        //    }
        //    else
        //    {
        //        ViewData["msg"] = TempData["msg"];
        //    }
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult BulkTopup(string NewAgentId, string package, string comment)
        //{
        //    if (!User.Identity.IsAuthenticated)
        //    {
        //        return RedirectToAction("Logout", "Member");
        //    }
        //    else
        //    {
        //        string[] words = NewAgentId.Split(',');

        //        string remark = string.Empty;
        //        string remark2 = string.Empty;

        //        for (int i = 0; i < words.Length; i++)
        //        {
        //            var userid = Convert.ToString(words[i]).Trim();
        //            var membercount = db.AgentDetails.Where(a => a.NewAgentId == userid && a.Status == 0).ToList().Count();
        //            var pincount = db.pintabs.Where(a => a.assignto == User.Identity.Name && a.Status == 0 && a.pinamount == package).ToList().Count();

        //            if (membercount != 0 && pincount != 0)
        //            {
        //                //-------------------------- Top Up Ids Ends ------------------
        //                con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //                SqlCommand cmd = new SqlCommand();
        //                cmd.Connection = con;
        //                cmd.CommandText = "topupnow";
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@memberid", userid);
        //                cmd.Parameters.AddWithValue("@package", package);
        //                cmd.Parameters.AddWithValue("@comment", comment);
        //                cmd.Parameters.AddWithValue("@opid", User.Identity.Name);
        //                try
        //                {
        //                    con.Open();
        //                    cmd.CommandTimeout = 1000000;
        //                    cmd.ExecuteNonQuery();
        //                }
        //                catch (SqlException ex)
        //                {
        //                    ViewBag.msg = ex.Message;
        //                }
        //                finally
        //                {
        //                    con.Close();
        //                }
        //                //-------------------------- Top Up Starts --------
        //                remark = remark + ',' + userid;
        //            }
        //            else
        //            {
        //                remark2 = remark2 + ',' + userid;
        //            }

        //            TempData["msg"] = "Your Member Id's-:" + remark + " TopUp Successfully, (" + remark2 + ") Not TopUp ...!! ";

        //        }
        //        return RedirectToAction("successfull", "Member");
        //    }
        //}

        [HttpGet]
        public ActionResult Availablepins()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Member");
            }
            else
            {
                return View();
            }
        }
    }
}
