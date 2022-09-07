using SPARSHBUILDCON.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using System.Web.Security;
using System.Net.NetworkInformation;
using System.Web.SessionState;
using System.Text;
using System.Data.Entity;

namespace SPARSHBUILDCON.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection();
        UsersContext db = new UsersContext();

        #region #Mz API-CALL

        public string Decriptdata(string encript)
        {
            string decript = string.Empty;
            UTF8Encoding encode = new UTF8Encoding();
            Decoder Decode = encode.GetDecoder();
            byte[] Todecoder_byte = Convert.FromBase64String(encript);
            int charcount = Decode.GetCharCount(Todecoder_byte, 0, Todecoder_byte.Length);
            char[] decode_char = new char[charcount];
            Decode.GetChars(Todecoder_byte, 0, Todecoder_byte.Length, decode_char, 0);
            decript = new string(decode_char);
            return decript;
        }

        #endregion

        public void addpc(string uid, string pcid)
        {
            var username = string.Empty;
            var nlr = db.NewLogins.Single(n => n.UserName == uid);
            if (nlr.type == "Admin")
            {
                username = "Admin";
                PC_Tab pc = new PC_Tab();
                pc.PCName = username;
                pc.userid = uid;
                pc.PCId = pcid;
                pc.addate = DateTime.Now;
                db.PC_Tabs.Add(pc);
                db.SaveChanges();
            }
            else if (nlr.type == "Branch")
            {
                username = db.Branchtabs.Single(b => b.BranchCode == uid).BranchName;
                PC_Tab pc = new PC_Tab();
                pc.PCName = username;
                pc.userid = uid;
                pc.PCId = pcid;
                pc.addate = DateTime.Now;
                db.PC_Tabs.Add(pc);
                db.SaveChanges();
            }
            else if (nlr.type == "Operator")
            {
                username = db.Operators.Single(b => b.OperatorId == uid).OperatorName;
                PC_Tab pc = new PC_Tab();
                pc.PCName = username;
                pc.userid = uid;
                pc.PCId = pcid;
                pc.addate = DateTime.Now;
                db.PC_Tabs.Add(pc);
                db.SaveChanges();
            }
            else if (nlr.type == "Receptionist")
            {
                username = db.DailyVisitors.Single(b => b.UserName == uid).ReceptionistName;
                PC_Tab pc = new PC_Tab();
                pc.PCName = username;
                pc.userid = uid;
                pc.PCId = pcid;
                pc.addate = DateTime.Now;
                db.PC_Tabs.Add(pc);
                db.SaveChanges();
            }
        }

        public int ck(string uid)
        {
            var a = 0;
            string host = Request.Url.Host.Replace(".", ""), PCC = host + "PCC", PCCVAL = host + "PCCVAL";
            HttpCookie pcookie = new HttpCookie(PCC);
            if (!string.IsNullOrEmpty(Convert.ToString(Request.Cookies[PCC])))
            {
                HttpCookie pccookie = HttpContext.Request.Cookies.Get(PCC);
                string pcid = Convert.ToString(pccookie.Values[PCCVAL]);
                var count = db.PC_Tabs.Where(c => c.userid == uid && c.PCId == pcid).Count();
                if (count > 0)
                {
                    var i = db.PC_Tabs.Single(p => p.userid == uid && p.PCId == pcid);
                    if (i.status == 1)
                    {
                        a = 1;
                    }
                    else if (i.status == 0)
                    {
                        a = 2;
                    }
                }
                else
                {
                    addpc(uid, pcid);
                }
            }
            else
            {

                HttpCookie pcookie1 = new HttpCookie(PCC);
                var pcid = Guid.NewGuid().ToString();
                pcookie1.Values.Add(PCCVAL, pcid);
                pcookie1.Expires = DateTime.Now.AddDays(365);
                Response.SetCookie(pcookie1);
                Response.Cookies.Add(pcookie1);

                addpc(uid, pcid);
            }
            return a;
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
            return s.Substring(0, 6);


        }

        string gid5()
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
            return s.Substring(0, 5);


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

        public JsonResult forgotpassword(string userid)
        {
            List<birthdaywishes> m = new List<birthdaywishes>();
            var rst = "";
            var countuser = db.NewLogins.Where(x => x.UserName == userid).Count();

            if (countuser > 0)
            {
                var typeuser = db.NewLogins.Single(x => x.UserName == userid);
                var countoprator = db.Operators.Where(x => x.OperatorId == userid && x.OperatorMobile != null).Count();
                var countbranch = db.Branchtabs.Where(x => x.BranchCode == userid && x.mobile != null).Count();
                var countagent = db.AgentDetails.Where(x => x.NewAgentId == userid && x.Mobile != null).Count();
                var countmobile = db.appltabs.Where(x => x.newbondid == userid && x.mobileno != null).Count();
                if (countagent != 0)
                {
                    if (typeuser.type == "Agent")
                    {
                        var detail = db.AgentDetails.Single(x => x.NewAgentId == userid);
                        var mob = detail.Mobile.Substring(6, 4);
                        var logindetails = db.NewLogins.Single(x => x.UserName == userid);
                        MyClass.Sendmsg(detail.Mobile, "Dear Agent Mr." + detail.name + " and your User Id: " + detail.NewAgentId + " and your password is : " + logindetails.Password + " for login visit our website https://sparshbuildcon.org/Home/Login");
                        TempData["messg"] = "Your password will be send on register mobile no." + mob;
                        rst = Convert.ToString(TempData["messg"]);
                    }
                }
                else if (countmobile != 0)
                {
                    if (typeuser.type == "Customer")
                    {
                        var detail = db.appltabs.Single(x => x.newbondid == userid);
                        var mob = detail.mobileno.Substring(6, 4);
                        var logindetails = db.NewLogins.Single(x => x.UserName == userid);
                        MyClass.Sendmsg(detail.mobileno, "Dear Customer Mr." + detail.name + " and your User Id " + detail.newbondid + " and your password is : " + logindetails.Password + " for login visit our website https://sparshbuildcon.org/Home/Login");
                        TempData["messg"] = "Your password will be send on register mobile no." + mob;
                        rst = Convert.ToString(TempData["messg"]);
                    }
                }
                else if (countbranch != 0)
                {
                    if (typeuser.type == "Branch")
                    {
                        var detail = db.Branchtabs.Single(x => x.BranchCode == userid);
                        var mob = detail.mobile.Substring(6, 4);
                        var logindetails = db.NewLogins.Single(x => x.UserName == userid);
                        MyClass.Sendmsg(detail.mobile, "Dear Branch Mr." + detail.BranchName + " and your User Id " + detail.BranchCode + " and your password is : " + logindetails.Password + " for login visit our website https://sparshbuildcon.org/Home/Login");
                        TempData["messg"] = "Your password will be send on register mobile no." + mob;
                        rst = Convert.ToString(TempData["messg"]);
                    }
                }
                else if (countoprator != 0)
                {
                    if (typeuser.type == "Operator")
                    {
                        var detail = db.Operators.Single(x => x.OperatorId == userid);
                        var mob = detail.OperatorMobile.Substring(6, 4);
                        var logindetails = db.NewLogins.Single(x => x.UserName == userid);
                        MyClass.Sendmsg(detail.OperatorMobile, "Dear Operator Mr." + detail.OperatorName + " and your User Id " + detail.OperatorId + " and your password is : " + logindetails.Password + " for login visit our website https://sparshbuildcon.org/Home/Login");
                        TempData["messg"] = "Your password will be send on register mobile no." + mob;
                        rst = Convert.ToString(TempData["messg"]);
                    }
                }
                else
                {
                    TempData["messg"] = "You does not have mobile number";
                    rst = Convert.ToString(TempData["messg"]);
                }
            }
            else
            {
                TempData["messg"] = "Invalid Userid";
                rst = Convert.ToString(TempData["messg"]);
            }

            m.Add(new birthdaywishes
            {
                sms = rst
            });
            return Json(m, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AutoCompleteAgentid(string term)
        {

            var list = (from r in db.AgentDetails where r.NewAgentId.ToLower().Contains(term.ToLower()) || r.name.ToLower().Contains(term.ToLower()) select new { r.NewAgentId, r.name }).Distinct();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult selectblock(int blist = 0)
        {
            var blistss = "";
            if (blist > 0)
            {
                var blists = db.BlockTabs.Where(a => a.Plancode == blist).ToList();
                return Json(blists, JsonRequestBehavior.AllowGet);
            }
            return Json(blistss, JsonRequestBehavior.AllowGet);
        }

        public JsonResult soldplot(int projectid = 0, int phaseid=0, int blockid = 0)
        {
            List<PlotList2> pt = new List<PlotList2>();

            //string str = "";

            var bb = db.BlockTabs.Single(a => a.Plancode == projectid && a.phaseid == phaseid && a.Id == blockid);
            var cc = db.Plans.Single(a => a.Plancode == projectid);


            var list = (from o in db.appltabs where o.projectid == projectid  && o.phaseid==phaseid && o.block == bb.block && o.plotno > 0 select new { o.plotno }).ToList();

            for (int i = bb.min; i <= bb.max; i++)
            {
                var hot = (from o in db.HoldingPlots where o.holdprojectid == projectid && o.holdphaseid == phaseid && o.holdblock == bb.Id && o.holdplotno == i select o).Count();

                if (hot == 0)
                {
                    var count = db.appltabs.Where(p => p.block == bb.block && p.projectid == projectid && p.phaseid == phaseid && p.plotno == i && p.status == 1).Count();

                    if (count == 0)
                    {
                        var pcount = db.appltabs.Where(p => p.block == bb.block && p.projectid == projectid && p.phaseid == phaseid && p.plotno == i && p.status == 1).Count();
                        if (pcount > 0)
                        {
                            pt.Add(new PlotList2 { id = i, availablity = "Available", status = 0, projectid = cc.Plancode, blockid = bb.Id, projectname = cc.Planname, blockname = bb.block });
                        }
                        else
                        {
                            var countplot = (from o in db.appltabs where o.projectid == projectid && o.phaseid == phaseid  && o.block == bb.block && o.plotno == i select o).Count();

                            var tcount = db.tempappltabs.Where(p => p.block == bb.block && p.projectid == projectid && p.phaseid == phaseid && p.plotno == i && p.status == 1).Count();
                            if (tcount == 0 && countplot == 0)
                            {
                                pt.Add(new PlotList2 { id = i, availablity = "Available", status = 0, projectid = cc.Plancode, blockid = bb.Id, projectname = cc.Planname, blockname = bb.block });
                            }
                            else if (tcount != 0 && countplot == 0)
                            {
                                pt.Add(new PlotList2 { id = i, availablity = "Unavailable", status = 1, projectid = cc.Plancode, blockid = bb.Id, projectname = cc.Planname, blockname = bb.block });
                            }
                            else if (tcount == 0 && countplot != 0)
                            {
                                pt.Add(new PlotList2 { id = i, availablity = "Unavailable", status = 1, projectid = cc.Plancode, blockid = bb.Id, projectname = cc.Planname, blockname = bb.block });
                            }
                            else
                            {
                                pt.Add(new PlotList2 { id = i, availablity = "Available", status = 0, projectid = cc.Plancode, blockid = bb.Id, projectname = Convert.ToString(cc.Planname), blockname = Convert.ToString(bb.block), plotno = i });
                            }
                        }
                    }
                    else
                    {

                        pt.Add(new PlotList2 { id = i, availablity = "Registered", status = 4, projectid = cc.Plancode, blockid = bb.Id, projectname = Convert.ToString(cc.Planname), blockname = Convert.ToString(bb.block), plotno = i });
                    }
                }
                else
                {
                    var hot2 = (from o in db.HoldingPlots where o.holdprojectid == projectid && o.holdphaseid == phaseid && o.holdblock == bb.Id && o.holdplotno == i select o).Count();
                    if (hot2 > 0)
                    {
                        pt.Add(new PlotList2 { id = i, availablity = "Unavailable", status = 1, projectid = cc.Plancode, blockid = bb.Id, projectname = Convert.ToString(cc.Planname), blockname = Convert.ToString(bb.block), plotno = i });
                    }
                    else
                    {
                        pt.Add(new PlotList2 { id = i, availablity = "Hold", status = 3, projectid = cc.Plancode, blockid = bb.Id, projectname = Convert.ToString(cc.Planname), blockname = Convert.ToString(bb.block), plotno = i });

                    }
                }
            }


            return Json(pt, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Plotholding(string newagent, int blockid = 0, int sid = 0, int plotid = 0)
        {
            string msg = string.Empty;
            HoldingPlot hold = new HoldingPlot();

            var agentcount = db.AgentDetails.Where(k => k.NewIntroducerId == newagent).Count();

            if (agentcount != 0)
            {

                var count = db.HoldingPlots.Where(b => b.holdstatus == 1).Count();

                int maxid = 0;



                if (count == 0)
                {

                    hold.holdblock = blockid;
                    hold.holdprojectid = plotid;
                    hold.holdstatus = 1;
                    hold.holdby = newagent;
                    hold.holdplotno = sid;
                    hold.holddate = DateTime.Now;

                    db.HoldingPlots.Add(hold);
                    db.SaveChanges();
                    msg = "Successfull !";
                }
                else
                {
                    maxid = db.HoldingPlots.Where(b => b.holdstatus == 1).Max(d => d.Id);
                    hold.holdblock = blockid;
                    hold.holdprojectid = plotid;
                    hold.holdstatus = 1;
                    hold.holdby = newagent;
                    hold.holdplotno = sid;
                    hold.holddate = DateTime.Now;

                    db.HoldingPlots.Add(hold);
                    db.SaveChanges();
                    msg = "Successfull !";
                }
            }
            else
            {
                msg = "Introducer Not Available";
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
       
        public JsonResult Jsonresult(string Project, string Recogniser)
        {
            if (Recogniser == "getPhase")
            {
                //var a = db.Plans.FirstOrDefault(o => o.Planname == Project);
                var id = Convert.ToInt16(Project);
                var list = db.PhaseTabs.Where(o => o.projectid == id).ToList();
                return Json(list, 0);
            }
            else if (Recogniser == "getBlock")
            {
                var id = Convert.ToInt16(Project);
                var a = db.BlockTabs.Where(o => o.phaseid == id).ToList();
                return Json(a, 0);
            }
            //else if (Recogniser == "getPlot")
            //{ 


            //}

            return Json(0, 0);
        }

        public JsonResult introname(string Introducer1)
        {
            var introname = db.AgentDetails.Single(a => a.NewAgentId == Introducer1);
            return Json(introname.name, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getmemberid(string intro)
        {
            var memberintro = db.AgentDetails.Where(x => x.NewAgentId == intro).Count();
            return Json(memberintro, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Legal()
        {


            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
        [HttpPost]
        public ActionResult Contact(Contact ob)
        {
            var cr = db.CompanyInfos.Single(ci => ci.Id == 1);
            if (ModelState.IsValid)
            {
                db.Contacts.Add(ob);
                db.SaveChanges();
                MyClass.Sendmsg(cr.Contact, "Mr. " + ob.name + " wants to contact on Subject: " + ob.subject + " call him on contact no " + ob.mobile);
                Response.Write("<script>alert('Thanks for contact us,we feedback you soon ')</script>");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                int count = (from n in db.NewLogins where n.UserName == User.Identity.Name select n.UserName).Count();
                if (count != 0)
                {
                    var log = db.NewLogins.Single(a => a.UserName == User.Identity.Name);
                    if (log.status == 1)
                    {
                        if (log.type == "Company")
                        {
                            FormsAuthentication.SetAuthCookie(log.UserName, true);
                            return RedirectToAction("Index", "Company");
                        }
                        else if (log.type == "Admin")
                        {
                            FormsAuthentication.SetAuthCookie(log.UserName, true);
                            return RedirectToAction("Index", "Admin");
                        }
                        else if (log.type == "Branch")
                        {
                            FormsAuthentication.SetAuthCookie(log.UserName, true);
                            return RedirectToAction("Index", "Branch");
                        }
                        else if (log.type == "Operator")
                        {
                            FormsAuthentication.SetAuthCookie(log.UserName, true);
                            return RedirectToAction("Index", "Operator");
                        }
                        else if (log.type == "HR")
                        {
                            FormsAuthentication.SetAuthCookie(log.UserName, true);
                            return RedirectToAction("Index", "HR");
                        }
                        else if (log.type == "Agent")
                        {
                            FormsAuthentication.SetAuthCookie(log.UserName, true);
                            return RedirectToAction("Dashboard", "Member");
                        }
                        else if (log.type == "Customer")
                        {
                            FormsAuthentication.SetAuthCookie(log.UserName, true);
                            return RedirectToAction("Index", "Customer");
                        }
                    }
                    else
                    {
                        ViewBag.msg = "You Blocked By Admin Please Contact ";
                    }
                }
                else
                {
                    ViewBag.msg = "Wrong User Id and Password";
                }

            }
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(NewLogin model)
        {
            DateTime duedate = db.CompanyInfos.Single(c => c.Id == 1).duedate;
            //var nlr = db.NewLogins.Single(n => n.UserName == model.UserName);
            //if (ck(model.UserName) == 1 || nlr.type == "Customer" || nlr.type == "Agent" || nlr.type == "Company" ||  nlr.type=="Branch")
            //{
            if (ModelState.IsValid)
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
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandText = "login";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = con;
                Cmd.Parameters.AddWithValue("@userid", model.UserName);
                Cmd.Parameters.AddWithValue("@pwd", model.Password);
                Cmd.Parameters.AddWithValue("@macaddress", localIP);

                SqlParameter p1 = new SqlParameter("@mobile", SqlDbType.NVarChar, 50);
                p1.Direction = ParameterDirection.Output;
                Cmd.Parameters.Add(p1);

                SqlParameter p = new SqlParameter("@Response", SqlDbType.Int);
                p.Direction = ParameterDirection.Output;
                Cmd.Parameters.Add(p);

                try
                {
                    con.Open();
                    Cmd.ExecuteNonQuery();
                    con.Close();

                    string response1 = Cmd.Parameters["@Response"].Value.ToString();
                    string mobile = Cmd.Parameters["@mobile"].Value.ToString();
                    int response = Convert.ToInt32(response1);
                    //var dpcount = (from d in db.DailyDepositTabs where d.status == 0 && d.opid == model.UserName select d).Count();
                    //if (dpcount == 0)
                    //{
                    if (response == 1)
                    {
                        FormsAuthentication.SetAuthCookie(model.UserName, true);
                        return RedirectToAction("Index", "Company");
                    }

                    else if (response == 2)
                    {
                        FormsAuthentication.SetAuthCookie(model.UserName, true);
                        return RedirectToAction("Index", "Admin");
                    }

                    else if (response == 3)
                    {
                        if (DateTime.Now.Date <= duedate)
                        {
                            var ed = db.SetMacTabs.Single(e => e.Id == 1);
                            if (ed.status == 1)
                            {
                                var count = (from mt in db.MacTabs where mt.type == "Branch" && mt.macaddress == localIP select mt).Count();
                                var ccount = (from mt in db.MacTabs where mt.type == "Branch" && mt.userid == model.UserName && mt.macaddress == localIP select mt).Count();
                                MacTab edi = new MacTab();
                                if (ccount != 0)
                                {
                                    edi = db.MacTabs.Single(e => e.userid == model.UserName);
                                }
                                else
                                {
                                    edi.status = 0;
                                }

                                if (edi.status == 1 || ccount == 0)
                                {
                                    var br = db.Members.Single(b => b.Id == 1);

                                    if (count == 0)
                                    {
                                        MacTab mtob = new MacTab();
                                        mtob.userid = model.UserName;
                                        mtob.macaddress = localIP;
                                        mtob.type = "Branch";
                                        mtob.status = 1;
                                        db.MacTabs.Add(mtob);
                                        db.SaveChanges();

                                        FormsAuthentication.SetAuthCookie(model.UserName, true);
                                        return RedirectToAction("Index", "Branch");
                                    }
                                    else if (count == 1)
                                    {
                                        var bcount = (from mt in db.MacTabs where mt.type == "Branch" && mt.userid == model.UserName && mt.macaddress == localIP select mt).Count();
                                        if (bcount == 1)
                                        {
                                            FormsAuthentication.SetAuthCookie(model.UserName, true);
                                            return RedirectToAction("Index", "Branch");
                                        }
                                        else if (bcount == 0)
                                        {
                                            Response.Write("<script>alert('Sorry,This system already assigned to another " + br.branchname + "')</script>");
                                        }
                                    }
                                }
                                else if (edi.status == 0)
                                {
                                    FormsAuthentication.SetAuthCookie(model.UserName, true);
                                    return RedirectToAction("Index", "Branch");
                                }
                            }
                            else if (ed.status == 0)
                            {
                                FormsAuthentication.SetAuthCookie(model.UserName, true);
                                return RedirectToAction("Index", "Branch");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Sorry,Your service have been suspended due to non payment of S/w charges.')</script>");
                        }
                    }

                    else if (response == 4)
                    {
                        if (DateTime.Now.Date <= duedate)
                        {
                            var ed = db.SetMacTabs.Single(e => e.Id == 1);
                            if (ed.status == 1)
                            {
                                var count = (from mt in db.MacTabs where mt.type == "Operator" && mt.macaddress == localIP select mt).Count();
                                var ccount = (from mt in db.MacTabs where mt.type == "Operator" && mt.userid == model.UserName && mt.macaddress == localIP select mt).Count();
                                MacTab edi = new MacTab();
                                if (ccount != 0)
                                {
                                    edi = db.MacTabs.Single(e => e.userid == model.UserName);
                                }
                                else
                                {
                                    edi.status = 0;
                                }
                                if (edi.status == 1 || ccount == 0)
                                {

                                    if (count == 0)
                                    {
                                        MacTab mtob = new MacTab();
                                        mtob.userid = model.UserName;
                                        mtob.macaddress = localIP;
                                        mtob.type = "Operator";
                                        mtob.status = 1;
                                        db.MacTabs.Add(mtob);
                                        db.SaveChanges();

                                        FormsAuthentication.SetAuthCookie(model.UserName, true);
                                        return RedirectToAction("Index", "Operator");
                                    }
                                    else if (count == 1)
                                    {
                                        var bcount = (from mt in db.MacTabs where mt.type == "Operator" && mt.userid == model.UserName && mt.macaddress == localIP select mt).Count();
                                        if (bcount == 1)
                                        {
                                            FormsAuthentication.SetAuthCookie(model.UserName, true);
                                            return RedirectToAction("Index", "Operator");
                                        }
                                        else if (bcount == 0)
                                        {
                                            Response.Write("<script>alert('Sorry,This system already assigned to another Operator')</script>");
                                        }
                                    }
                                }
                                else if (edi.status == 0)
                                {
                                    FormsAuthentication.SetAuthCookie(model.UserName, true);
                                    return RedirectToAction("Index", "Operator");
                                }
                            }
                            else if (ed.status == 0)
                            {
                                FormsAuthentication.SetAuthCookie(model.UserName, true);
                                return RedirectToAction("Index", "Operator");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Sorry,Your service have been suspended due to non payment of S/w charges.')</script>");
                        }
                    }

                    else if (response == 10)
                    {
                        if (DateTime.Now.Date <= duedate)
                        {
                            var ed = db.SetMacTabs.Single(e => e.Id == 1);
                            if (ed.status == 1)
                            {
                                var count = (from mt in db.MacTabs where mt.type == "HR" && mt.macaddress == localIP select mt).Count();
                                var ccount = (from mt in db.MacTabs where mt.type == "HR" && mt.userid == model.UserName && mt.macaddress == localIP select mt).Count();
                                MacTab edi = new MacTab();
                                if (ccount != 0)
                                {
                                    edi = db.MacTabs.Single(e => e.userid == model.UserName);
                                }
                                else
                                {
                                    edi.status = 0;
                                }
                                if (edi.status == 1 || ccount == 0)
                                {

                                    if (count == 0)
                                    {
                                        MacTab mtob = new MacTab();
                                        mtob.userid = model.UserName;
                                        mtob.macaddress = localIP;
                                        mtob.type = "HR";
                                        mtob.status = 1;
                                        db.MacTabs.Add(mtob);
                                        db.SaveChanges();

                                        FormsAuthentication.SetAuthCookie(model.UserName, true);
                                        return RedirectToAction("Index", "HR");
                                    }
                                    else if (count == 1)
                                    {
                                        var bcount = (from mt in db.MacTabs where mt.type == "Operator" && mt.userid == model.UserName && mt.macaddress == localIP select mt).Count();
                                        if (bcount == 1)
                                        {
                                            FormsAuthentication.SetAuthCookie(model.UserName, true);
                                            return RedirectToAction("Index", "HR");
                                        }
                                        else if (bcount == 0)
                                        {
                                            Response.Write("<script>alert('Sorry,This system already assigned to another HR')</script>");
                                        }
                                    }
                                }
                                else if (edi.status == 0)
                                {
                                    FormsAuthentication.SetAuthCookie(model.UserName, true);
                                    return RedirectToAction("Index", "HR");
                                }
                            }
                            else if (ed.status == 0)
                            {
                                FormsAuthentication.SetAuthCookie(model.UserName, true);
                                return RedirectToAction("Index", "HR");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Sorry,Your service have been suspended due to non payment of S/w charges.')</script>");
                        }
                    }

                    else if (response == 5)
                    {
                        FormsAuthentication.SetAuthCookie(model.UserName, true);
                        return RedirectToAction("Dashboard", "Member");
                    }

                    else if (response == 6)
                    {

                        FormsAuthentication.SetAuthCookie(model.UserName, true);
                        return RedirectToAction("Index", "Customer");
                    }
                    else if (response == 15)
                    {
                        if (1 == db.NewLogins.Where(o => o.UserName == model.UserName && o.Password == model.Password && o.type == "Receptionist").Count())
                        {
                            FormsAuthentication.SetAuthCookie(model.UserName, true);
                            return RedirectToAction("DailyVisitorDetail", "Operator");
                        }
                    }
                    if (response == 7)
                    {
                        Response.Write("<script>alert('Sorry,You are blocked by Admin')</script>");
                    }

                    if (response == 8)
                    {
                        Response.Write("<script>alert('Sorry,Your Password wrong')</script>");
                    }
                    if (response == 9)
                    {
                        Response.Write("<script>alert('Sorry,Your User Name Wrong')</script>");
                    }
                    if (response == 11)
                    {
                        Response.Write("<script>alert('Sorry,Login Time Expired')</script>");
                    }
                    if (response == 12)
                    {
                        Response.Write("<script>alert('Sorry,You are not authorised for this System')</script>");
                    }
                    //}
                    //else
                    //{
                    //    TempData["User"] = model.UserName;
                    //    if(nlr.type=="Operator")
                    //    {
                    //    return RedirectToAction("DailyClosing");
                    //    }
                    //    else if (nlr.type == "Branch")
                    //    {
                    //       return RedirectToAction("BranchDailyClosing");
                    //    }
                    //}
                }
                catch (Exception e)
                {
                    ViewBag.msg = e.Message;
                    TempData["Error"] = e;
                }

            }
            //}
            //else { Response.Write("<script>alert('Sorry,You are not authorised for this System')</script>"); }
            return View();
        }

        [HttpGet]
        public ActionResult Project()
        {


            //var count = db.HoldingPlots.Where(ww => ww.holdstatus == 1).Count();

            //if (count != 0)
            //{
            //    var clear = db.HoldingPlots.FirstOrDefault(ww => ww.holdstatus == 1);

            //    DateTime checkdate = Convert.ToDateTime(clear.holddate);
            //    DateTime currentdate = DateTime.Now;

            //    if (checkdate.Date < currentdate.Date)
            //    {

            //        var holdlist = db.HoldingPlots.Where(a => a.holddate < DateTime.Now).ToList();

            //        foreach (var hh in holdlist)
            //        {

            //            var starttime = Convert.ToDateTime(DateTime.Now);
            //            var endtime = Convert.ToDateTime(hh.holddate);


            //            var totaltime = Convert.ToDateTime(starttime).Subtract(Convert.ToDateTime(endtime));
            //            var tt = totaltime.Hours;

            //            if (tt > 24)
            //            {
            //                var removehod = db.HoldingPlots.Single(a => a.Id == hh.Id);
            //                db.HoldingPlots.Remove(removehod);
            //                db.SaveChanges();
            //            }

            //        }


            //    }
            //}
            return View();
        }

        [HttpGet]
        public ActionResult Offer()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Gallery()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Videos()
        {
            return View();
        }

        [HttpGet]
        public ActionResult News()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Terms()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Career()
        {
            return View();
        }    

        [HttpGet]
        public ActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public ActionResult holdplot()
        {
            return View();
        }
        [HttpPost]
        public ActionResult holdplot(int projectid = 0, int blockid = 0, int id = 0)
        {
            appltab hl = new appltab();

            return RedirectToAction("Project", "Home");
        }

        public ActionResult Success(string id)
        {
            var decodeData = Decriptdata(id);
            var data = decodeData.Split('|');
            var CountPayee = db.PayU_Payments.Where(xn => xn.Transactionid == data[0] && xn.Clientid == data[1] && xn.status == 0).ToList().Count;
            if (CountPayee == 1)
            {
                PayU_Payment payee = db.PayU_Payments.Single(xn => xn.Transactionid == data[0] && xn.Clientid == data[1] && xn.status == 0);
                payee.status = 1;
                payee.Remark = "Payment added to wallet.";
                db.Entry(payee).State = EntityState.Modified;
                db.SaveChanges();

                var srno = (from aa in db.Wallet_Transactions where aa.agentid == id select aa.Sr_No).Max();
                var oldBalance = db.Wallet_Transactions.Single(bb => bb.Sr_No == srno).netamount;
                Wallet_Transaction wallet = new Wallet_Transaction();
                wallet.Credit = Convert.ToDouble(data[5]);
                wallet.Debit = 0;
                wallet.Type = "Credit";
                wallet.Remark = "Payment added sucessfuly to self-wallet via online payment on " + DateTime.Now.ToString("dd MMM yy HH:mm");
                wallet.Date_Time = DateTime.Now;
                wallet.Transaction_No = "wM" + gid().Substring(0, 4) + "m" + DateTime.Now.ToString("yyMMddHHmmssff") + "z" + gid().Substring(5, 8);
                wallet.status = 1;
                wallet.netamount = oldBalance + Convert.ToDouble(data[5]);
                wallet.agentid = id;
                wallet.Sender_Id = id;
                wallet.Sender_Name = data[2];
                wallet.Mode = "ONLINE";
                db.Wallet_Transactions.Add(wallet);
                db.SaveChanges();
            }

            return View();
        }

        public ActionResult Failure(string id)
        {
            var decodeData = Decriptdata(id);
            var data = decodeData.Split('|');

            PayU_Payment payee = db.PayU_Payments.Single(xn => xn.Transactionid == data[0] && xn.Clientid == data[1] && xn.status == 0);
            payee.status = 2;
            db.Entry(payee).State = EntityState.Modified;
            db.SaveChanges();
            return View();
        }

        [HttpGet]
        public ActionResult DailyClosing()
        {
            ViewData["username"] = TempData["User"];
            //ViewData["username"] = "AANCHAL";
            return View();
        }
        [HttpPost]
        public ActionResult DailyClosing(DailyDepositTab ddt, string user, string date, string remark1, string remark2, Double transferamount1 = 0, Double transferamount2 = 0, Double Grandtotalcash = 0, Double bal = 0, int id = 0, int trid = 0)
        {
            ViewData["username"] = user;
           
            var msg = "";
            var Udetail = db.NewLogins.Single(a => a.UserName == user);
                DateTime sdate=DateTime.ParseExact(date,"dd/MM/yyyy",null);
                DailyDepositTab dt=db.DailyDepositTabs.Single(a=>a.opid==user && a.Id==id && a.trid==trid && a.date==sdate);
                if(dt.transfertype=="Cash")
                {
                    if (dt.twothousand != ddt.twothousand || dt.fivehundred != ddt.fivehundred || dt.twohundred != ddt.twohundred || dt.hundred != ddt.hundred || dt.fifty != ddt.fifty || dt.twenty != ddt.twenty || dt.ten != ddt.ten || dt.five != ddt.five || dt.two != ddt.two || dt.one != ddt.one)
                {
                    msg = "Fields does not Match with before fields";
                    Response.Write("<script>alert('Fields does not Match with before fields')</script>");
                }
                else
                {
                    dt.status = 1;
                    dt.matchingdate = DateTime.Now.Date;
                    db.SaveChanges();
                    msg = "Fields  Matched successfully with before fields";
                }
                }
                else if (dt.transfertype == "Bank")
                {
                    if (dt.bankapp == 1)
                    {
                        if (dt.twothousand != ddt.twothousand || dt.fivehundred != ddt.fivehundred || dt.twohundred != ddt.twohundred || dt.hundred != ddt.hundred || dt.fifty != ddt.fifty || dt.twenty != ddt.twenty || dt.ten != ddt.ten || dt.five != ddt.five || dt.two != ddt.two || dt.one != ddt.one)
                        {
                            msg = "Fields does not Match with before fields";
                            Response.Write("<script>alert('Fields does not Match with before fields')</script>");
                        }
                        else
                        {
                            dt.status = 1;
                            dt.matchingdate = DateTime.Now.Date;
                            db.SaveChanges();
                            msg = "Fields  Matched successfully with before fields";
                        }
                    }
                    else
                    {

                        dt.status = 1;
                        dt.bankapp = 2;
                        dt.matchingdate = DateTime.Now.Date;
                        db.SaveChanges();

                        #region Insert
                        #region notselect
                        if (ddt.transfertype !="select")
                      {
                          Double remailning = 0;
                        Double chequebookpen = (from a in db.tempappltabs where a.paymethod == "Cheque" && a.opid == user && a.status == 1 && a.formdate == sdate select a.bookingamount).DefaultIfEmpty(0).Sum();
                        Double chequerenpen = (from a in db.TempInstallmenttabs where a.paymethod == "Cheque" && a.opid == user && a.status == 1 && a.paymentdate == sdate select a.payamount).DefaultIfEmpty(0).Sum();
                       if(ddt.transfertype=="Bank")
                       {
                           remailning = bal - transferamount1;
                       }
                      else if(ddt.transfertype=="Cash")
                       {
                          remailning = bal - transferamount2;
                        }
                        int trid1 = (from a in db.DailyDepositTabs where a.opid == user select a.trid).DefaultIfEmpty(0).Max()+1;
                        DailyDepositTab dt1 = new DailyDepositTab();
                        dt1.date = sdate;
                        dt1.twothousand = ddt.twothousand;
                        dt1.fivehundred = ddt.fivehundred;
                        dt1.twohundred = ddt.twohundred;
                        dt1.hundred = ddt.hundred;
                        dt1.fifty = ddt.fifty;
                        dt1.twenty = ddt.twenty;
                        dt1.ten = ddt.ten;
                        dt1.five = ddt.five;
                        dt1.two = ddt.two;
                        dt1.one = ddt.one;

                        //-----Cashrecieved----
                        dt1.RecieveCashBookingApp = ddt.RecieveCashBookingApp;
                        dt1.RecieveBankBookingApp = ddt.RecieveBankBookingApp;
                        dt1.RecieveChequeBookingApp = ddt.RecieveChequeBookingApp;
                        dt1.RecieveCashRenApp = ddt.RecieveCashRenApp;
                        dt1.RecieveBankRenApp = ddt.RecieveBankRenApp;
                        dt1.RecieveChequeRenApp = ddt.RecieveChequeRenApp;
                        //-----Pendingrecieved----
                        dt1.RecieveBankBookingPending = ddt.RecieveBankBookingPending;
                        dt1.RecieveChequeBookingPending = chequebookpen;
                        dt1.RecieveBankRenPending = ddt.RecieveBankRenPending;
                        dt1.RecieveChequeRenPending = chequerenpen;
                        //-------Return-------------
                        dt1.ReturnCashVoucher = ddt.ReturnCashVoucher;
                        dt1.ReturnBanVoucher = ddt.ReturnBanVoucher;
                        dt1.ReturnChequeVoucher = ddt.ReturnChequeVoucher;
                        dt1.ReturnCashSpot = ddt.ReturnCashSpot;
                        dt1.ReturnBankSpot = ddt.ReturnBankSpot;
                        dt1.ReturnCashExp = ddt.ReturnCashExp;
                        dt1.ReturnChequeExp = ddt.ReturnChequeExp;
                        dt1.ReturnBankExp = ddt.ReturnBankExp;
                        //----------Other-----------
                        dt1.Latefine = ddt.Latefine;
                        dt1.Relief = ddt.Relief;
                        dt1.total = ddt.total;
                        dt1.opid = user;
                        dt1.branchcode = user;
                        dt1.status = 0;
                        dt1.bankappdate = DateTime.Now.Date;
                        dt1.RejectionReason = ddt.RejectionReason;
                        dt1.TotalCashamount = Grandtotalcash;
                        dt1.TotalChequeamount = ddt.TotalChequeamount;
                        dt1.TotalBankamount = ddt.TotalBankamount;
                        dt1.Depositedamount = bal;
                        dt1.bankname = ddt.bankname;
                        dt1.remainingamount = bal - ddt.total;
                        dt1.transfertype = ddt.transfertype;
                        dt1.trid = trid1;
                        dt1.matchingdate = DateTime.Now.Date;
                        if (dt1.transfertype == "Bank")
                        {
                            dt1.transferamount = transferamount1;
                            dt1.Remark = remark1;
                            dt1.bankapp = 0;
                        }
                        else if (dt1.transfertype == "Cash")
                        {
                            dt1.transferamount = transferamount2;
                            dt1.Remark = remark2;
                            dt1.bankapp = 1;
                        }
                        dt1.closingtype = "Matching";
                        db.DailyDepositTabs.Add(dt1);
                        db.SaveChanges();
                        var clcount=(from c in db.ClosingAmount_Tabs where c.opid==user && c.status == 0 select c).Count();
                        if(clcount>0)
                        {
                            var cl = db.ClosingAmount_Tabs.Single(c => c.opid == user && c.status == 0 );
                            cl.status = 1;
                            db.SaveChanges();
                        }
                        if (remailning > 0)
                        {
                            var max = (from a in db.ClosingAmount_Tabs where a.opid == user select a.Trid).DefaultIfEmpty().Max() + 1;
                            ClosingAmount_Tab ct = new ClosingAmount_Tab();
                            ct.remaininamount = remailning;
                            ct.Amount = bal;
                            ct.depositamount = ddt.total;
                            ct.Trid = max;
                            ct.status = 0;
                            ct.date = sdate;
                            ct.opid = user;
                            db.ClosingAmount_Tabs.Add(ct);
                            db.SaveChanges();
                        }
                      }
                        #endregion
                        #region other
                        else if (ddt.transfertype == "select")
                    {
                         Double chequebookpen = (from a in db.tempappltabs where a.paymethod == "Cheque" && a.opid == user && a.status == 1 && a.formdate == sdate select a.bookingamount).DefaultIfEmpty(0).Sum();
                        Double chequerenpen = (from a in db.TempInstallmenttabs where a.paymethod == "Cheque" && a.opid == user && a.status == 1 && a.paymentdate == sdate select a.payamount).DefaultIfEmpty(0).Sum();
                        int trid1 = (from a in db.DailyDepositTabs where a.opid == User.Identity.Name select a.trid).DefaultIfEmpty(0).Max() + 1;
                        TempDailyDepositTab tdt = new TempDailyDepositTab();
                        tdt.date = sdate;
                        tdt.twothousand = ddt.twothousand;
                        tdt.fivehundred = ddt.fivehundred;
                        tdt.twohundred = ddt.twohundred;
                        tdt.hundred = ddt.hundred;
                        tdt.fifty = ddt.fifty;
                        tdt.twenty = ddt.twenty;
                        tdt.ten = ddt.ten;
                        tdt.five = ddt.five;
                        tdt.two = ddt.two;
                        tdt.one = ddt.one;

                        //-----Cashrecieved----
                        tdt.RecieveCashBookingApp = ddt.RecieveCashBookingApp;
                        tdt.RecieveBankBookingApp = ddt.RecieveBankBookingApp;
                        tdt.RecieveChequeBookingApp = ddt.RecieveChequeBookingApp;
                        tdt.RecieveCashRenApp = ddt.RecieveCashRenApp;
                        tdt.RecieveBankRenApp = ddt.RecieveBankRenApp;
                        tdt.RecieveChequeRenApp = ddt.RecieveChequeRenApp;
                        //-----Pendingrecieved----
                        tdt.RecieveBankBookingPending = ddt.RecieveBankBookingPending;
                        tdt.RecieveChequeBookingPending = chequebookpen;
                        tdt.RecieveBankRenPending = ddt.RecieveBankRenPending;
                        tdt.RecieveChequeRenPending = chequerenpen;
                        //-------Return-------------
                        tdt.ReturnCashVoucher = ddt.ReturnCashVoucher;
                        tdt.ReturnBanVoucher = ddt.ReturnBanVoucher;
                        tdt.ReturnChequeVoucher = ddt.ReturnChequeVoucher;
                        tdt.ReturnCashSpot = ddt.ReturnCashSpot;
                        tdt.ReturnBankSpot = ddt.ReturnBankSpot;
                        tdt.ReturnCashExp = ddt.ReturnCashExp;
                        tdt.ReturnChequeExp = ddt.ReturnChequeExp;
                        tdt.ReturnBankExp = ddt.ReturnBankExp;
                        //----------Other-----------
                        tdt.Latefine = ddt.Latefine;
                        tdt.Relief = ddt.Relief;
                        tdt.total = ddt.total;
                        tdt.opid = user;
                        tdt.branchcode = user;
                        tdt.status = 0;
                        tdt.bankappdate = DateTime.Now.Date;
                        tdt.RejectionReason = ddt.RejectionReason;
                        tdt.TotalCashamount = Grandtotalcash;
                        tdt.TotalChequeamount = ddt.TotalChequeamount;
                        tdt.TotalBankamount = ddt.TotalBankamount;
                        tdt.Depositedamount = bal;
                        tdt.bankname = ddt.bankname;
                        tdt.transfertype = ddt.transfertype;
                        tdt.trid = trid1;
                        if (ddt.transfertype == "Bank")
                        {
                            tdt.transferamount = transferamount1;
                            tdt.remainingamount = bal - transferamount1;
                            tdt.Remark = remark1;
                            tdt.bankapp = 0;
                        }
                        else if (ddt.transfertype == "Cash")
                        {
                            tdt.transferamount = transferamount2;
                            tdt.remainingamount = bal - transferamount2;
                            tdt.Remark = remark2;
                            tdt.bankapp = 1;
                        }
                        tdt.OpeningBalance = ddt.OpeningBalance;
                        tdt.ClosingBalance = ddt.ClosingBalance;
                        tdt.closingtype = "Matching";
                        tdt.matchingdate = sdate;
                        db.TempDailyDepositTabs.Add(tdt);
                        db.SaveChanges();
                        var clcount = (from c in db.ClosingAmount_Tabs where c.opid == user && c.status == 0 select c).Count();
                        double beforedue = (from c in db.ClosingAmount_Tabs where c.opid == User.Identity.Name && c.status == 0 select c.remaininamount).DefaultIfEmpty().Sum();
                        if (clcount > 0)
                        {
                            var cl = db.ClosingAmount_Tabs.Single(c => c.opid == user && c.status == 0);
                            cl.status = 1;
                            db.SaveChanges();
                        }
                        var max = (from a in db.ClosingAmount_Tabs where a.opid == user select a.Trid).DefaultIfEmpty().Max() + 1;
                        ClosingAmount_Tab ct = new ClosingAmount_Tab();
                        ct.remaininamount = bal;
                        ct.Amount = bal;
                        ct.depositamount = ddt.total;
                        ct.Trid = max;
                        ct.status = 0;
                        ct.date = sdate;
                        ct.opid = User.Identity.Name;
                        db.ClosingAmount_Tabs.Add(ct);
                        db.SaveChanges();

                    }
                    #endregion
                        #endregion
                        msg = "Your New Closing Saved Successfylly";
                    }
                }
                TempData["msg"] = msg;
                FormsAuthentication.SetAuthCookie(user, true);
                if (Udetail.type == "Operator")
                {
                    return RedirectToAction("Index", "Operator");
                }
                else if (Udetail.type == "Branch")
                {
                    return RedirectToAction("Index", "Branch");
                }
               
                return View();
        }
       
        [HttpGet]
        public ActionResult BranchDailyClosing()
        {
            ViewData["username"] = TempData["User"];
            //ViewData["username"] = "AANCHAL";
            return View();
        }
        [HttpPost]
        public ActionResult BranchDailyClosing(DailyDepositTab ddt, string user, string date, string remark1, string remark2, Double transferamount1 = 0, Double transferamount2 = 0, Double Grandtotalcash = 0, Double bal = 0, int id = 0, int trid = 0)
        {
            ViewData["username"] = user;

            var msg = "";
            var Udetail = db.NewLogins.Single(a => a.UserName == user);
            DateTime sdate = DateTime.ParseExact(date, "dd/MM/yyyy", null);
            DailyDepositTab dt = db.DailyDepositTabs.Single(a => a.opid == user && a.Id == id && a.trid == trid && a.date == sdate);
            if (dt.transfertype == "Cash")
            {
                if (dt.twothousand != ddt.twothousand || dt.fivehundred != ddt.fivehundred || dt.twohundred != ddt.twohundred || dt.hundred != ddt.hundred || dt.fifty != ddt.fifty || dt.twenty != ddt.twenty || dt.ten != ddt.ten || dt.five != ddt.five || dt.two != ddt.two || dt.one != ddt.one)
                {
                    msg = "Fields does not Match with before fields";
                    Response.Write("<script>alert('Fields does not Match with before fields')</script>");
                }
                else
                {
                    dt.status = 1;
                    dt.matchingdate = DateTime.Now.Date;
                    db.SaveChanges();
                    msg = "Fields  Matched successfully with before fields";
                }
            }
            else if (dt.transfertype == "Bank")
            {
                if (dt.bankapp == 1)
                {
                    if (dt.twothousand != ddt.twothousand || dt.fivehundred != ddt.fivehundred || dt.twohundred != ddt.twohundred || dt.hundred != ddt.hundred || dt.fifty != ddt.fifty || dt.twenty != ddt.twenty || dt.ten != ddt.ten || dt.five != ddt.five || dt.two != ddt.two || dt.one != ddt.one)
                    {
                        msg = "Fields does not Match with before fields";
                        Response.Write("<script>alert('Fields does not Match with before fields')</script>");
                    }
                    else
                    {
                        dt.status = 1;
                        dt.matchingdate = DateTime.Now.Date;
                        db.SaveChanges();
                        msg = "Fields  Matched successfully with before fields";
                    }
                }
                else
                {

                    dt.status = 1;
                    dt.bankapp = 2;
                    dt.matchingdate = DateTime.Now.Date;
                    db.SaveChanges();

                    #region Insert
                    #region notselect
                    if (ddt.transfertype != "select")
                    {
                        Double remailning = 0;
                        Double chequebookpen = (from a in db.tempappltabs where a.paymethod == "Cheque" && a.branchcode == user && a.status == 1 && a.formdate == sdate select a.bookingamount).DefaultIfEmpty(0).Sum();
                        Double chequerenpen = (from a in db.TempInstallmenttabs where a.paymethod == "Cheque" && a.branch == user && a.status == 1 && a.paymentdate == sdate select a.payamount).DefaultIfEmpty(0).Sum();
                        if (ddt.transfertype == "Bank")
                        {
                            remailning = bal - transferamount1;
                        }
                        else if (ddt.transfertype == "Cash")
                        {
                            remailning = bal - transferamount2;
                        }
                        int trid1 = (from a in db.DailyDepositTabs where a.opid == user select a.trid).DefaultIfEmpty(0).Max() + 1;
                        DailyDepositTab dt1 = new DailyDepositTab();
                        dt1.date = sdate;
                        dt1.twothousand = ddt.twothousand;
                        dt1.fivehundred = ddt.fivehundred;
                        dt1.twohundred = ddt.twohundred;
                        dt1.hundred = ddt.hundred;
                        dt1.fifty = ddt.fifty;
                        dt1.twenty = ddt.twenty;
                        dt1.ten = ddt.ten;
                        dt1.five = ddt.five;
                        dt1.two = ddt.two;
                        dt1.one = ddt.one;

                        //-----Cashrecieved----
                        dt1.RecieveCashBookingApp = ddt.RecieveCashBookingApp;
                        dt1.RecieveBankBookingApp = ddt.RecieveBankBookingApp;
                        dt1.RecieveChequeBookingApp = ddt.RecieveChequeBookingApp;
                        dt1.RecieveCashRenApp = ddt.RecieveCashRenApp;
                        dt1.RecieveBankRenApp = ddt.RecieveBankRenApp;
                        dt1.RecieveChequeRenApp = ddt.RecieveChequeRenApp;
                        //-----Pendingrecieved----
                        dt1.RecieveBankBookingPending = ddt.RecieveBankBookingPending;
                        dt1.RecieveChequeBookingPending = chequebookpen;
                        dt1.RecieveBankRenPending = ddt.RecieveBankRenPending;
                        dt1.RecieveChequeRenPending = chequerenpen;
                        //-------Return-------------
                        dt1.ReturnCashVoucher = ddt.ReturnCashVoucher;
                        dt1.ReturnBanVoucher = ddt.ReturnBanVoucher;
                        dt1.ReturnChequeVoucher = ddt.ReturnChequeVoucher;
                        dt1.ReturnCashSpot = ddt.ReturnCashSpot;
                        dt1.ReturnBankSpot = ddt.ReturnBankSpot;
                        dt1.ReturnCashExp = ddt.ReturnCashExp;
                        dt1.ReturnChequeExp = ddt.ReturnChequeExp;
                        dt1.ReturnBankExp = ddt.ReturnBankExp;
                        //----------Other-----------
                        dt1.Latefine = ddt.Latefine;
                        dt1.Relief = ddt.Relief;
                        dt1.total = ddt.total;
                        dt1.opid = user;
                        dt1.branchcode = user;
                        dt1.status = 0;
                        dt1.bankappdate = DateTime.Now.Date;
                        dt1.RejectionReason = ddt.RejectionReason;
                        dt1.TotalCashamount = Grandtotalcash;
                        dt1.TotalChequeamount = ddt.TotalChequeamount;
                        dt1.TotalBankamount = ddt.TotalBankamount;
                        dt1.Depositedamount = bal;
                        dt1.bankname = ddt.bankname;
                        dt1.remainingamount = bal - ddt.total;
                        dt1.transfertype = ddt.transfertype;
                        dt1.trid = trid1;
                        dt1.matchingdate = DateTime.Now.Date;
                        if (dt1.transfertype == "Bank")
                        {
                            dt1.transferamount = transferamount1;
                            dt1.Remark = remark1;
                            dt1.bankapp = 0;
                        }
                        else if (dt1.transfertype == "Cash")
                        {
                            dt1.transferamount = transferamount2;
                            dt1.Remark = remark2;
                            dt1.bankapp = 1;
                        }
                        dt1.closingtype = "Matching";
                        db.DailyDepositTabs.Add(dt1);
                        db.SaveChanges();
                        var clcount = (from c in db.ClosingAmount_Tabs where c.opid == user && c.status == 0 select c).Count();
                        if (clcount > 0)
                        {
                            var cl = db.ClosingAmount_Tabs.Single(c => c.opid == user && c.status == 0);
                            cl.status = 1;
                            db.SaveChanges();
                        }
                        if (remailning > 0)
                        {
                            var max = (from a in db.ClosingAmount_Tabs where a.opid == user select a.Trid).DefaultIfEmpty().Max() + 1;
                            ClosingAmount_Tab ct = new ClosingAmount_Tab();
                            ct.remaininamount = remailning;
                            ct.Amount = bal;
                            ct.depositamount = ddt.total;
                            ct.Trid = max;
                            ct.status = 0;
                            ct.date = sdate;
                            ct.opid = user;
                            db.ClosingAmount_Tabs.Add(ct);
                            db.SaveChanges();
                        }
                    }
                    #endregion
                    #region other
                    else if (ddt.transfertype == "select")
                    {
                        Double chequebookpen = (from a in db.tempappltabs where a.paymethod == "Cheque" && a.branchcode == user && a.status == 1 && a.formdate == sdate select a.bookingamount).DefaultIfEmpty(0).Sum();
                        Double chequerenpen = (from a in db.TempInstallmenttabs where a.paymethod == "Cheque" && a.branch == user && a.status == 1 && a.paymentdate == sdate select a.payamount).DefaultIfEmpty(0).Sum();
                        int trid1 = (from a in db.DailyDepositTabs where a.opid == User.Identity.Name select a.trid).DefaultIfEmpty(0).Max() + 1;
                        TempDailyDepositTab tdt = new TempDailyDepositTab();
                        tdt.date = sdate;
                        tdt.twothousand = ddt.twothousand;
                        tdt.fivehundred = ddt.fivehundred;
                        tdt.twohundred = ddt.twohundred;
                        tdt.hundred = ddt.hundred;
                        tdt.fifty = ddt.fifty;
                        tdt.twenty = ddt.twenty;
                        tdt.ten = ddt.ten;
                        tdt.five = ddt.five;
                        tdt.two = ddt.two;
                        tdt.one = ddt.one;

                        //-----Cashrecieved----
                        tdt.RecieveCashBookingApp = ddt.RecieveCashBookingApp;
                        tdt.RecieveBankBookingApp = ddt.RecieveBankBookingApp;
                        tdt.RecieveChequeBookingApp = ddt.RecieveChequeBookingApp;
                        tdt.RecieveCashRenApp = ddt.RecieveCashRenApp;
                        tdt.RecieveBankRenApp = ddt.RecieveBankRenApp;
                        tdt.RecieveChequeRenApp = ddt.RecieveChequeRenApp;
                        //-----Pendingrecieved----
                        tdt.RecieveBankBookingPending = ddt.RecieveBankBookingPending;
                        tdt.RecieveChequeBookingPending = chequebookpen;
                        tdt.RecieveBankRenPending = ddt.RecieveBankRenPending;
                        tdt.RecieveChequeRenPending = chequerenpen;
                        //-------Return-------------
                        tdt.ReturnCashVoucher = ddt.ReturnCashVoucher;
                        tdt.ReturnBanVoucher = ddt.ReturnBanVoucher;
                        tdt.ReturnChequeVoucher = ddt.ReturnChequeVoucher;
                        tdt.ReturnCashSpot = ddt.ReturnCashSpot;
                        tdt.ReturnBankSpot = ddt.ReturnBankSpot;
                        tdt.ReturnCashExp = ddt.ReturnCashExp;
                        tdt.ReturnChequeExp = ddt.ReturnChequeExp;
                        tdt.ReturnBankExp = ddt.ReturnBankExp;
                        //----------Other-----------
                        tdt.Latefine = ddt.Latefine;
                        tdt.Relief = ddt.Relief;
                        tdt.total = ddt.total;
                        tdt.opid = user;
                        tdt.branchcode = user;
                        tdt.status = 0;
                        tdt.bankappdate = DateTime.Now.Date;
                        tdt.RejectionReason = ddt.RejectionReason;
                        tdt.TotalCashamount = Grandtotalcash;
                        tdt.TotalChequeamount = ddt.TotalChequeamount;
                        tdt.TotalBankamount = ddt.TotalBankamount;
                        tdt.Depositedamount = bal;
                        tdt.bankname = ddt.bankname;
                        tdt.transfertype = ddt.transfertype;
                        tdt.trid = trid1;
                        if (ddt.transfertype == "Bank")
                        {
                            tdt.transferamount = transferamount1;
                            tdt.remainingamount = bal - transferamount1;
                            tdt.Remark = remark1;
                            tdt.bankapp = 0;
                        }
                        else if (ddt.transfertype == "Cash")
                        {
                            tdt.transferamount = transferamount2;
                            tdt.remainingamount = bal - transferamount2;
                            tdt.Remark = remark2;
                            tdt.bankapp = 1;
                        }
                        tdt.OpeningBalance = ddt.OpeningBalance;
                        tdt.ClosingBalance = ddt.ClosingBalance;
                        tdt.closingtype = "Matching";
                        tdt.matchingdate = sdate;
                        db.TempDailyDepositTabs.Add(tdt);
                        db.SaveChanges();
                        var clcount = (from c in db.ClosingAmount_Tabs where c.opid == user && c.status == 0 select c).Count();
                        double beforedue = (from c in db.ClosingAmount_Tabs where c.opid == User.Identity.Name && c.status == 0 select c.remaininamount).DefaultIfEmpty().Sum();
                        if (clcount > 0)
                        {
                            var cl = db.ClosingAmount_Tabs.Single(c => c.opid == user && c.status == 0);
                            cl.status = 1;
                            db.SaveChanges();
                        }
                        var max = (from a in db.ClosingAmount_Tabs where a.opid == user select a.Trid).DefaultIfEmpty().Max() + 1;
                        ClosingAmount_Tab ct = new ClosingAmount_Tab();
                        ct.remaininamount = bal;
                        ct.Amount = bal;
                        ct.depositamount = ddt.total;
                        ct.Trid = max;
                        ct.status = 0;
                        ct.date = sdate;
                        ct.opid = User.Identity.Name;
                        db.ClosingAmount_Tabs.Add(ct);
                        db.SaveChanges();

                    }
                    #endregion
                    #endregion
                    msg = "Your New Closing Saved Successfylly";
                }
            }
            TempData["msg"] = msg;
            FormsAuthentication.SetAuthCookie(user, true);
            if (Udetail.type == "Operator")
            {
                return RedirectToAction("Index", "Operator");
            }
            else if (Udetail.type == "Branch")
            {
                return RedirectToAction("Index", "Branch");
            }

            return View();
        }

        [HttpGet]
        public ActionResult CreateBroker()
        {
            return View();

        }
        [HttpPost]
        public ActionResult CreateBroker(AgentDetail model, HttpPostedFileBase Photo, string command, string memberid)
        {
            List<Member_tab> mt = new List<Member_tab>();

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
                        string passw = gid5();
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
                                ad.operatorid = model.BranchCode;
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

            return View();
        }

        public ActionResult vissionandmission()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult companyprofile()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult management()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult team()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult values()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult homes()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Service()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Banker()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



    }
}
