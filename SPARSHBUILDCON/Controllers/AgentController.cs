using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using SPARSHBUILDCON.Models;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.Entity;
using System.Net.NetworkInformation;
using System.Drawing;
using System.Drawing.Imaging;

namespace SPARSHBUILDCON.Controllers
{

    public class AgentController : Controller
    {

        SqlConnection con = new SqlConnection();
        private UsersContext db = new UsersContext();
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
                        if (log.status == 1 && log.type == "Agent")
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
        public static string NewAgentid;
        public static int  vmonth = 0, vvyear = 0;
        public static DateTime stdate = DateTime.Now, enddate = DateTime.Now, pdate = DateTime.Now;
        
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



        public String GenerateImageTag(HttpPostedFileBase up)
        {
            String image = "";
            var imgtemp = Guid.NewGuid().ToString();
            if (up != null)
            {
                var ext = System.IO.Path.GetExtension(up.FileName);
                up.SaveAs(HttpContext.Server.MapPath("~/Images/Temp/" + imgtemp + ".jpg"));
                var path = HttpContext.Server.MapPath("~/Images/Temp/" + imgtemp + ".jpg");
                Image img = Image.FromFile(path);
                Bitmap bmp1 = new Bitmap(img);
                ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 1L);
                myEncoderParameters.Param[0] = myEncoderParameter;
                var imgg = Guid.NewGuid().ToString();
                string outputFileName = Server.MapPath("~/Images/" + imgg + ".jpg");
                using (MemoryStream memory = new MemoryStream())
                {
                    using (FileStream fs = new FileStream(outputFileName, FileMode.Create, FileAccess.ReadWrite))
                    {
                        bmp1.Save(memory, ImageFormat.Jpeg);
                        byte[] bytes = memory.ToArray();
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
                image = "~/Images/" + imgg + ".jpg";

            }
            return image;
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }



        [HttpGet]
        public ActionResult CreateBroker()
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Agent");
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
            if (!IsLoggedIn())
            {
                return RedirectToAction("Logout", "Agent");
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
                        var ds = db.Blockdates.Where(c => c.date == model.Doj && c.branchcode == User.Identity.Name && c.status == 0).Count();
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
                            int bwcount = (from a in db.AgentDetails select a).Count() + 1;
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
                                    db.SaveChanges();

                                    var Checkbinary = db.binarys.Single(a => a.Id == Singleuser.uid);
                                    if (Checkbinary.rperson == 1 && Checkbinary.lperson == 1)
                                    {
                                        Checkbinary.pair = 1;
                                    }
                                    db.SaveChanges();

                                    //------- Wallettab Entry ------------------------
                                    var wt1 = new wallettab();
                                    wt1.amount = 0;
                                    wt1.UserId = newagentid;
                                    db.wallettabs.Add(wt1);
                                    db.SaveChanges();

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
                                    db.SaveChanges();

                                    //-------End insert Binary Table---------------------

                            #endregion

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
                                    ad.Status = 1;
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
        public ActionResult Bond()
        {
            List<appltab> agent = new List<appltab>();
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                agent = (from pl in db.appltabs where pl.newintroducerid == User.Identity.Name select pl).ToList();
            }
            return View(agent);
        }
        public ActionResult PrintOfficialCustomerReport()
        {
            List<appltab> customer = new List<appltab>();
            customer = db.appltabs.Where(s => s.newintroducerid == User.Identity.Name).ToList();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CustomerList.rpt"));
            rd.SetDataSource(customer);

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

        [HttpGet]
        public ActionResult AgentProfile()
        {
            List<AgentDetail> dn = new List<AgentDetail>();
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                dn = db.AgentDetails.Where(c => c.NewAgentId == User.Identity.Name).ToList();
            }
            return View(dn);
        }

        [HttpGet]
        public ActionResult EditAgent(int id = 0)
        {
            if (User.Identity.IsAuthenticated)
            {
                AgentDetail op = db.AgentDetails.Single(d => d.AgencyCode == id);
                if (op == null)
                {
                    return HttpNotFound();
                }
                return View(op);

            }
            return RedirectToAction("Logout");

        }
        [HttpPost]
        public ActionResult EditAgent(AgentDetail model)
        {
            if (User.Identity.IsAuthenticated)
            {                            
                    var agd = db.AgentDetails.Single(d=>d.NewAgentId==model.NewAgentId);
                    agd.OtherMobile = model.OtherMobile;
                    agd.Panno = model.Panno;
                    agd.Passportno = model.Passportno;
                    agd.Drivinglno = model.Drivinglno;
                    agd.BankName = model.BankName;
                    agd.BankBranchName = model.BankBranchName;
                    agd.BankAccountno = model.BankAccountno;
                    agd.IFCCode = model.IFCCode;
                    agd.BankAddress = model.BankAddress;
                    agd.Aadhaar_No = model.Aadhaar_No;
                    if (agd.Aadhaar_No == null || agd.Aadhaar_No == "" || agd.Aadhaar_No == "N/A" || agd.Aadhaar_No == "NA")
                    {
                        agd.Aadhaar_status = 0;
                    }
                    else
                    {
                        agd.Aadhaar_status = 1;
                        agd.Aadhaar_AppDate = DateTime.Now.Date;
                    }
                    if (agd.Panno == null || agd.Panno == "" || agd.Aadhaar_No == "N/A" || agd.Aadhaar_No == "NA")
                    {
                        agd.PanStatus = 0;
                    }
                    else
                    {
                        agd.PanStatus = 1;
                        agd.PAN_AppDate = DateTime.Now.Date;
                    }
                    db.Entry(agd).State = EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.message = "Agent Updated Successfully.";                
                return View(model);
            }
            return RedirectToAction("Logout");

        }

        [HttpGet]
        public ActionResult BTree(string newid, string aa)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Agent");
            }
            else
            {
                List<Downline1> down = new List<Downline1>();
                int lcount = (from n in db.NewLogins where n.UserName == User.Identity.Name select n.UserName).Count();
                if (lcount == 1)
                {
                    var log = db.NewLogins.Single(a => a.UserName == User.Identity.Name);
                    if (log.status == 1 || log.type == "Agent")
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
                        return RedirectToAction("Logout", "Agent");
                    }
                }
                else
                {
                    return RedirectToAction("Logout", "Agent");
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
                return RedirectToAction("Logout", "Agent");
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
                    cmd.CommandText = "binarylastid";
                    cmd.Parameters.AddWithValue("@introid", newid);
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

                    var LastLeftId = "Not Represent";
                    var LastLeftName = "Not Represent";
                    var LastRightId = "Not Represent";
                    var LastRightName = "Not Represent";

                    var LastLeftProfile = string.Empty;
                    var LastRightProfile = string.Empty;


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
                            else if (user.Status == 2)
                            {
                                Mprofile = "~/Images/star/oreng.png";
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
                                    if (user2.Status == 2)
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

                }
                else
                {
                    Response.Write("<script>alert('Please Enter Valid Associate Id')</script>");
                }
                ViewData["cmid"] = newid;
                return View(down);

            }
        }

        [HttpGet]
        public ActionResult BrokerChain()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Agent");
            }
            else
            {

                var cr = db.CompanyInfos.Single(c => c.Id == 1);
                int rcount = 0;
                List<BrokerChain> bclist = new List<BrokerChain>();
                var br = db.AgentDetails.Single(a => a.NewAgentId == User.Identity.Name);
                var bb = db.Branchtabs.Single(o => o.BranchCode == br.BranchCode);
                bclist.Add(new BrokerChain { newagentid = br.NewAgentId, name = br.name, rankcode = br.RankCode, rankname = br.RankName, introducerid = br.NewIntroducerId, introname = br.IntroName, branchname = bb.BranchName, companyname = cr.CompanyName, address = cr.Address, emailid = cr.Emailid, contact = cr.Contact, domainname = cr.HeadOffice });
                List<agents> dalist = new List<agents>();
                var alist = (from al in db.AgentDetails where al.NewIntroducerId == User.Identity.Name select new { al.AgencyCode }).Distinct();
                foreach (var a in alist)
                {
                    rcount = rcount + 1;
                    dalist.Add(new agents { sr = rcount, agentcode = a.AgencyCode });
                }

                var maxsragent = dalist.Count;
                var minsragent = 1;
                while (minsragent <= maxsragent)
                {

                    var da = dalist.Where(a => a.sr == minsragent);
                    foreach (var d in da.ToList())
                    {
                        var aalist = (from al in db.AgentDetails where al.IntroducerCode == d.agentcode select new { al.AgencyCode }).Distinct();
                        foreach (var aa in aalist)
                        {
                            rcount = rcount + 1;
                            dalist.Add(new agents { sr = rcount, agentcode = aa.AgencyCode });

                        }

                    }
                    minsragent = minsragent + 1;
                    maxsragent = dalist.Count;
                }
                foreach (var dd in dalist)
                {
                    var ad = db.AgentDetails.Single(a => a.AgencyCode == dd.agentcode);
                    bclist.Add(new BrokerChain { newagentid = ad.NewAgentId, name = ad.name, rankcode = ad.RankCode, rankname = ad.RankName, introducerid = ad.NewIntroducerId, introname = ad.IntroName, branchname = bb.BranchName, companyname = cr.CompanyName, address = cr.Address, emailid = cr.Emailid, contact = cr.Contact, domainname = cr.HeadOffice });

                }
                NewAgentid = User.Identity.Name;
                return View(bclist);
            }
        }
        public ActionResult PrintBrokerChainReport()
        {

            var cr = db.CompanyInfos.Single(c => c.Id == 1);
            int rcount = 0;
            List<BrokerChain> bclist = new List<BrokerChain>();
            var br = db.AgentDetails.Single(a => a.NewAgentId == NewAgentid);
            var bb = db.Branchtabs.Single(o => o.BranchCode == br.BranchCode);
            bclist.Add(new BrokerChain { newagentid = br.NewAgentId, name = br.name, rankcode = br.RankCode, rankname = br.RankName, introducerid = br.NewIntroducerId, introname = br.IntroName, branchname = bb.BranchName, companyname = cr.CompanyName, address = cr.Address, emailid = cr.Emailid, contact = cr.Contact, domainname = cr.HeadOffice });
            List<agents> dalist = new List<agents>();
            var alist = (from al in db.AgentDetails where al.NewIntroducerId == NewAgentid select new { al.AgencyCode }).Distinct();
            foreach (var a in alist)
            {
                rcount = rcount + 1;
                dalist.Add(new agents { sr = rcount, agentcode = a.AgencyCode });
            }

            var maxsragent = dalist.Count;
            var minsragent = 1;
            while (minsragent <= maxsragent)
            {

                var da = dalist.Where(a => a.sr == minsragent);
                foreach (var d in da.ToList())
                {
                    var aalist = (from al in db.AgentDetails where al.IntroducerCode == d.agentcode select new { al.AgencyCode }).Distinct();
                    foreach (var aa in aalist)
                    {
                        rcount = rcount + 1;
                        dalist.Add(new agents { sr = rcount, agentcode = aa.AgencyCode });
                    }

                }
                minsragent = minsragent + 1;
                maxsragent = dalist.Count;
            }
            foreach (var dd in dalist)
            {
                var ad = db.AgentDetails.Single(a => a.AgencyCode == dd.agentcode);
                bclist.Add(new BrokerChain { newagentid = ad.NewAgentId, name = ad.name, rankcode = ad.RankCode, rankname = ad.RankName, introducerid = ad.NewIntroducerId, introname = ad.IntroName, branchname = bb.BranchName, companyname = cr.CompanyName, address = cr.Address, emailid = cr.Emailid, contact = cr.Contact, domainname = cr.HeadOffice });

            }

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports/Branch"), "AdvBrokerChain.rpt"));
            rd.SetDataSource(bclist);

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
            return View(bclist);
        }

        [HttpGet]
        public ActionResult BrokerAccount()
        {
            List<BrokerAccount> balist = new List<BrokerAccount>();
            if (!User.Identity.IsAuthenticated)
            {

                return RedirectToAction("Logout", "Agent");
            }

            else
            {
                var cr = db.CompanyInfos.Single(c => c.Id == 1);
                var mr = db.Members.Single(c => c.Id == 1);
                var plan4 = db.Plans.Single(p4 => p4.Plancode == 4);
                var ar = db.AgentDetails.Single(n => n.NewAgentId == User.Identity.Name);
                var br = db.Branchtabs.Single(o => o.BranchCode == ar.BranchCode);
                int rcount = 0;
                List<BrokerChain> bclist = new List<BrokerChain>();
                bclist.Add(new BrokerChain { newagentid = ar.NewAgentId, name = ar.name, rankcode = ar.RankCode, rankname = ar.RankName, introducerid = ar.NewIntroducerId, introname = ar.IntroName, branchname = br.BranchName, companyname = cr.CompanyName, address = cr.Address, emailid = cr.Emailid, contact = cr.Contact, domainname = cr.HeadOffice });
                List<agents> dalist = new List<agents>();
                var alist = (from al in db.AgentDetails where al.NewIntroducerId == ar.NewAgentId select new { al.AgencyCode }).Distinct();
                foreach (var a in alist)
                {
                    rcount = rcount + 1;
                    dalist.Add(new agents { sr = rcount, agentcode = a.AgencyCode });
                }
                var maxsragent = dalist.Count;
                var minsragent = 1;
                while (minsragent <= maxsragent)
                {
                    var da = dalist.Where(a => a.sr == minsragent);
                    foreach (var d in da.ToList())
                    {
                        var aalist = (from al in db.AgentDetails where al.IntroducerCode == d.agentcode select new { al.AgencyCode }).Distinct();
                        foreach (var aa in aalist)
                        {
                            rcount = rcount + 1;
                            dalist.Add(new agents { sr = rcount, agentcode = aa.AgencyCode });
                        }

                    }
                    minsragent = minsragent + 1;
                    maxsragent = dalist.Count;
                }
                foreach (var dd in dalist)
                {
                    var ad = db.AgentDetails.Single(a => a.AgencyCode == dd.agentcode);
                    if (ad.Status == 1)
                    {
                        bclist.Add(new BrokerChain { newagentid = ad.NewAgentId, name = ad.name, rankcode = ad.RankCode, rankname = ad.RankName, introducerid = ad.NewIntroducerId, introname = ad.IntroName, branchname = br.BranchName, companyname = cr.CompanyName, address = cr.Address, emailid = cr.Emailid, contact = cr.Contact, domainname = cr.HeadOffice });
                    }
                }
                foreach (var bc in bclist)
                {
                    var blist = (from a in db.appltabs where a.newintroducerid == bc.newagentid orderby a.newbondid select a).ToList();
                    foreach (var b in blist)
                    {
                        var aa = db.AgentDetails.Single(r => r.NewAgentId == b.newintroducerid);
                        if (b.plantype == plan4.shortcutname)
                        {
                            balist.Add(new BrokerAccount { newintroducerid = b.newintroducerid, name = aa.name, newbondid = b.newbondid, cname = b.name, amount = b.totalcon, planname = b.planname, term = b.term, mode = b.mode, expirydate = b.expirydate, formdate = b.formdate, branchname = br.BranchName, companyname = cr.CompanyName, branch = mr.branchname, address = cr.Address, emailid = cr.Emailid, contact = cr.Contact, domainname = cr.HeadOffice });
                        }
                        else
                        {
                            balist.Add(new BrokerAccount { newintroducerid = b.newintroducerid, name = aa.name, newbondid = b.newbondid, cname = b.name, amount = b.payment, planname = b.planname, term = b.term, mode = b.mode, expirydate = b.expirydate, formdate = b.formdate, branchname = br.BranchName, companyname = cr.CompanyName, branch = mr.branchname, address = cr.Address, emailid = cr.Emailid, contact = cr.Contact, domainname = cr.HeadOffice });
                        }
                    }
                }
                NewAgentid = User.Identity.Name;
                return View(balist);
            }
        }
        public ActionResult PrintBrokerAccountReport()
        {
            List<BrokerAccount> balist = new List<BrokerAccount>();
            var cr = db.CompanyInfos.Single(c => c.Id == 1);
            var mr = db.Members.Single(c => c.Id == 1);
            var plan4 = db.Plans.Single(p4 => p4.Plancode == 4);
            var ar = db.AgentDetails.Single(n => n.NewAgentId == NewAgentid);
            var br = db.Branchtabs.Single(o => o.BranchCode == ar.BranchCode);
            int rcount = 0;
            List<BrokerChain> bclist = new List<BrokerChain>();
            bclist.Add(new BrokerChain { newagentid = ar.NewAgentId, name = ar.name, rankcode = ar.RankCode, rankname = ar.RankName, introducerid = ar.NewIntroducerId, introname = ar.IntroName, branchname = br.BranchName, companyname = cr.CompanyName, address = cr.Address, emailid = cr.Emailid, contact = cr.Contact, domainname = cr.HeadOffice });
            List<agents> dalist = new List<agents>();
            var alist = (from al in db.AgentDetails where al.NewIntroducerId == ar.NewAgentId select new { al.AgencyCode }).Distinct();
            foreach (var a in alist)
            {
                rcount = rcount + 1;
                dalist.Add(new agents { sr = rcount, agentcode = a.AgencyCode });
            }
            var maxsragent = dalist.Count;
            var minsragent = 1;
            while (minsragent <= maxsragent)
            {
                var da = dalist.Where(a => a.sr == minsragent);
                foreach (var d in da.ToList())
                {
                    var aalist = (from al in db.AgentDetails where al.IntroducerCode == d.agentcode select new { al.AgencyCode }).Distinct();
                    foreach (var aa in aalist)
                    {
                        rcount = rcount + 1;
                        dalist.Add(new agents { sr = rcount, agentcode = aa.AgencyCode });
                    }

                }
                minsragent = minsragent + 1;
                maxsragent = dalist.Count;
            }
            foreach (var dd in dalist)
            {
                var ad = db.AgentDetails.Single(a => a.AgencyCode == dd.agentcode);
                if (ad.Status == 1)
                {
                    bclist.Add(new BrokerChain { newagentid = ad.NewAgentId, name = ad.name, rankcode = ad.RankCode, rankname = ad.RankName, introducerid = ad.NewIntroducerId, introname = ad.IntroName, branchname = br.BranchName, companyname = cr.CompanyName, address = cr.Address, emailid = cr.Emailid, contact = cr.Contact, domainname = cr.HeadOffice });
                }
            }
            foreach (var bc in bclist)
            {
                var blist = (from a in db.appltabs where a.newintroducerid == bc.newagentid orderby a.newbondid select a).ToList();
                foreach (var b in blist)
                {
                    var aa = db.AgentDetails.Single(r => r.NewAgentId == b.newintroducerid);
                    if (b.plantype == plan4.shortcutname)
                    {
                        balist.Add(new BrokerAccount { newintroducerid = b.newintroducerid, name = aa.name, newbondid = b.newbondid, cname = b.name, amount = b.totalcon, planname = b.planname, term = b.term, mode = b.mode, expirydate = b.expirydate, formdate = b.formdate, branchname = br.BranchName, companyname = cr.CompanyName, branch = mr.branchname, address = cr.Address, emailid = cr.Emailid, contact = cr.Contact, domainname = cr.HeadOffice });
                    }
                    else
                    {
                        balist.Add(new BrokerAccount { newintroducerid = b.newintroducerid, name = aa.name, newbondid = b.newbondid, cname = b.name, amount = b.payment, planname = b.planname, term = b.term, mode = b.mode, expirydate = b.expirydate, formdate = b.formdate, branchname = br.BranchName, companyname = cr.CompanyName, branch = mr.branchname, address = cr.Address, emailid = cr.Emailid, contact = cr.Contact, domainname = cr.HeadOffice });
                    }
                }
            }

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "BrokerAccount.rpt"));
            rd.SetDataSource(balist);

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

        [HttpGet]
        public ActionResult Selfbusiness()
        {
            List<DatewiseDueCollection> dwl = new List<DatewiseDueCollection>();
            var ar = db.AgentDetails.Single(a => a.NewAgentId == User.Identity.Name);
            var bondintro = (from o in db.appltabs where o.newintroducerid == User.Identity.Name select o).ToList();
            var cr = db.CompanyInfos.Single(c => c.Id == 1);
            foreach (var c in bondintro)
            {
                var bookingamount = (from n in db.Installmenttabs where n.newbondid == c.newbondid && n.installmentno == 1 select n.payamount).DefaultIfEmpty(0).Sum();
                var emiamount = (from n in db.Installmenttabs where n.newbondid == c.newbondid && n.payamount != 0 && n.installmentno > 1 select n.payamount).DefaultIfEmpty(0).Sum();
                dwl.Add(new DatewiseDueCollection { newbondid = c.newbondid, name = c.name, newintroducerid = ar.NewAgentId, IntroName = ar.name, formdate = c.formdate, amount = bookingamount, installamount = emiamount, mobileno = c.mobileno, branchname = c.branchcode, companyname = cr.CompanyName });
            }
            return View(dwl);
        }
        public ActionResult PrintSelfbusiness()
        {
            List<DatewiseDueCollection> dwl = new List<DatewiseDueCollection>();
            var ar = db.AgentDetails.Single(a => a.NewAgentId == User.Identity.Name);
            var bondintro = (from o in db.appltabs where o.newintroducerid == User.Identity.Name select o).ToList();
            var cr = db.CompanyInfos.Single(c => c.Id == 1);
            foreach (var c in bondintro)
            {
                var bookingamount = (from n in db.Installmenttabs where n.newbondid == c.newbondid && n.installmentno == 1 select n.payamount).DefaultIfEmpty(0).Sum();
                var emiamount = (from n in db.Installmenttabs where n.newbondid == c.newbondid && n.payamount != 0 && n.installmentno > 1 select n.payamount).DefaultIfEmpty(0).Sum();
                dwl.Add(new DatewiseDueCollection { newbondid = c.newbondid, name = c.name, newintroducerid = ar.NewAgentId, IntroName = ar.name, formdate = c.formdate, amount = bookingamount, installamount = emiamount, mobileno = c.mobileno, branchname = c.branchcode, companyname = cr.CompanyName });
            }

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "Selfbusiness.rpt"));
            rd.SetDataSource(dwl);

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

        [HttpGet]
        public ActionResult BrokerChainCollection()
        {
            List<TempBrokerChainCollection> bcclist = new List<TempBrokerChainCollection>();
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Agent");
            }
            else
            {
                return View(bcclist);
            }
        }
        [HttpPost]
        public ActionResult BrokerChainCollection(string newagentid, DateTime sdate, DateTime edate)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Agent");
            }
            else
            {

                List<TempBrokerChainCollection> bcclist = new List<TempBrokerChainCollection>();
                MonthName mn = new MonthName();
                newagentid = User.Identity.Name;
                var mon = mn.numbertomonthname(sdate.Month);
                var mr = db.Members.Single(m => m.Id == 1);
                var cr = db.CompanyInfos.Single(c => c.Id == 1);
                var ashish = db.BrokerCommLists.Where(a => a.newagentid == newagentid && a.month == mon && a.Year == sdate.Year).Count();
                if (ashish == 1)
                {
                    var ar = db.BrokerCommLists.Single(a => a.newagentid == newagentid && a.month == mon && a.Year == sdate.Year);

                    #region Select Broker Chain Start Here

                    List<BrokerChain> bclist = new List<BrokerChain>();
                    bclist.Add(new BrokerChain { newagentid = ar.newagentid, name = ar.name, rankcode = ar.rankcode, rankname = ar.rankname, introducerid = ar.newintroducerid, introname = ar.Introname, branchname = User.Identity.Name });
                    int rcount = 0;
                    List<agents> dalist = new List<agents>();
                    var alist = (from al in db.BrokerCommLists where al.newintroducerid == newagentid && al.month == mon && al.Year == sdate.Year select new { al.agencycode }).Distinct();
                    foreach (var a in alist)
                    {
                        rcount = rcount + 1;
                        dalist.Add(new agents { sr = rcount, agentcode = a.agencycode });
                    }

                    var maxsragent = dalist.Count;
                    var minsragent = 1;
                    while (minsragent <= maxsragent)
                    {

                        var da = dalist.Where(a => a.sr == minsragent);
                        foreach (var d in da.ToList())
                        {
                            var aalist = (from al in db.BrokerCommLists where al.introducerid == d.agentcode && al.month == mon && al.Year == sdate.Year select new { al.agencycode }).Distinct();
                            foreach (var aa in aalist)
                            {
                                rcount = rcount + 1;
                                dalist.Add(new agents { sr = rcount, agentcode = aa.agencycode });

                            }

                        }
                        minsragent = minsragent + 1;
                        maxsragent = dalist.Count;
                    }
                    foreach (var dd in dalist)
                    {
                        var ad = db.BrokerCommLists.Single(a => a.agencycode == dd.agentcode && a.month == mon && a.Year == sdate.Year);
                        bclist.Add(new BrokerChain { newagentid = ad.newagentid, name = ad.name, rankcode = ad.rankcode, rankname = ad.rankname, introducerid = ad.newintroducerid, introname = ad.Introname, branchname = User.Identity.Name });

                    }

                    #endregion

                    #region Select Broker Collectin Start Here

                    foreach (var bc in bclist)
                    {
                        List<Tempbond> tb = new List<Tempbond>();
                        List<TempSelfCollection> bsclist = new List<TempSelfCollection>();

                        var ag = db.BrokerCommLists.Single(hj => hj.newagentid == bc.newagentid && hj.month == mon && hj.Year == sdate.Year);

                        var tbd = (from ap in db.appltabs where ap.newintroducerid == bc.newagentid && ap.status == 1 select ap.bondid).ToList();
                        var bd = (from yt in db.Installmenttabs where yt.paymentdate >= sdate && yt.paymentdate <= edate && tbd.Contains(yt.bondid) select new { yt.bondid }).Distinct();
                        var count = tbd.Count();
                        if (count > 0)
                        {
                            foreach (var item in bd.ToList())
                            {
                                tb.Add(new Tempbond { bondid = item.bondid });
                            }

                            foreach (var t in tb.ToList())
                            {
                                List<SelfCollection> sf = new List<SelfCollection>();
                                int bondid = t.bondid;
                                var list = (from o in db.Installmenttabs
                                            join u in db.appltabs on o.newbondid equals u.newbondid
                                            where o.bondid == bondid && o.payamount != 0 && o.paymentdate >= sdate && o.paymentdate <= edate
                                            orderby u.newbondid
                                            select new { o.payamount, o.installmentno, o.year, o.planname, u.plantype, u.plancode, u.totalcon }).ToList();

                                foreach (var g in list.ToList())
                                {
                                    string subplan = g.plantype;
                                    if (subplan == "FD")
                                    {
                                        sf.Add(new SelfCollection { sis = g.payamount });
                                    }
                                    if (subplan == "MIS" && g.installmentno == 1 && g.year == 1)
                                    {
                                        sf.Add(new SelfCollection { PPSFresh = g.totalcon });
                                    }
                                    if (subplan == "NFP" && g.installmentno == 1 && g.year == 1)
                                    {
                                        sf.Add(new SelfCollection { NFPFresh = g.payamount });
                                    }
                                    if (subplan == "RD" && g.installmentno == 1 && g.year == 1)
                                    {
                                        sf.Add(new SelfCollection { MISFresh = g.payamount });
                                    }

                                    if (subplan == "RD" && g.installmentno > 1 && g.year == 1)
                                    {
                                        sf.Add(new SelfCollection { MIS1 = g.payamount });
                                    }

                                    if (subplan == "RD" && g.installmentno > 1 && g.year == 2)
                                    {
                                        sf.Add(new SelfCollection { MIS2 = g.payamount });
                                    }

                                    if (subplan == "RD" && g.installmentno > 1 && g.year == 3)
                                    {
                                        sf.Add(new SelfCollection { MIS3 = g.payamount });
                                    }

                                    if (subplan == "RD" && g.installmentno > 1 && g.year == 4)
                                    {
                                        sf.Add(new SelfCollection { MIS4 = g.payamount });
                                    }

                                    if (subplan == "RD" && g.installmentno > 1 && g.year == 5)
                                    {
                                        sf.Add(new SelfCollection { MIS5 = g.payamount });
                                    }

                                    if (subplan == "RD" && g.installmentno > 1 && g.year == 6)
                                    {
                                        sf.Add(new SelfCollection { MIS6 = g.payamount });
                                    }

                                    if (subplan == "RD" && g.installmentno > 1 && g.year >= 7)
                                    {
                                        sf.Add(new SelfCollection { MIS7a = g.payamount });
                                    }
                                }

                                var brow = db.appltabs.Single(bg => bg.bondid == bondid);
                                double sissum = 0, misfsum = 0, mis1sum = 0, mis2sum = 0, mis3sum = 0, mis4sum = 0, mis5sum = 0, mis6sum = 0, mis7sum = 0, pppsum = 0, nfssum = 0;

                                sissum = sf.Sum(tr => tr.sis);
                                misfsum = sf.Sum(tr => tr.MISFresh);
                                mis1sum = sf.Sum(tr => tr.MIS1);
                                mis2sum = sf.Sum(tr => tr.MIS2);
                                mis3sum = sf.Sum(tr => tr.MIS3);
                                mis4sum = sf.Sum(tr => tr.MIS4);
                                mis5sum = sf.Sum(tr => tr.MIS5);
                                mis6sum = sf.Sum(tr => tr.MIS6);
                                mis7sum = sf.Sum(tr => tr.MIS7a);
                                pppsum = sf.Sum(tr => tr.PPSFresh);
                                nfssum = sf.Sum(tr => tr.NFPFresh);
                                bsclist.Add(new TempSelfCollection { Newbondid = brow.newbondid, Customername = brow.name, brokername = ag.name, brokercode = ag.newagentid, tsis = sissum, tMISFresh = misfsum, tPPSFresh = pppsum, tNFPFresh = nfssum, tMIS1 = mis1sum, tMIS2 = mis2sum, tMIS3 = mis3sum, tMIS4 = mis4sum, tMIS5 = mis5sum, tMIS6 = mis6sum, tMIS7a = mis7sum, companyname = cr.CompanyName, branchname = User.Identity.Name, branch = mr.branchname, bond = mr.custname, agent = mr.agentname, plan = mr.planname, sdate = sdate, edate = edate });
                            }


                        }
                        double bsissum = 0, bmisfsum = 0, bppsum = 0, bnfpsum = 0, bmis1sum = 0, bmis2sum = 0, bmis3sum = 0, bmis4sum = 0, bmis5sum = 0, bmis6sum = 0, bmis7sum = 0;
                        bsissum = bsclist.Sum(tr => tr.tsis);
                        bmisfsum = bsclist.Sum(tr => tr.tMISFresh);
                        bmis1sum = bsclist.Sum(tr => tr.tMIS1);
                        bmis2sum = bsclist.Sum(tr => tr.tMIS2);
                        bmis3sum = bsclist.Sum(tr => tr.tMIS3);
                        bmis4sum = bsclist.Sum(tr => tr.tMIS4);
                        bmis5sum = bsclist.Sum(tr => tr.tMIS5);
                        bmis6sum = bsclist.Sum(tr => tr.tMIS6);
                        bmis7sum = bsclist.Sum(tr => tr.tMIS7a);
                        bppsum = bsclist.Sum(tr => tr.tPPSFresh);
                        bnfpsum = bsclist.Sum(tr => tr.tNFPFresh);


                        if (bsissum + bmisfsum + bmis1sum + bmis2sum + bmis3sum + bmis4sum + bmis5sum + bmis6sum + bmis7sum + bppsum + bnfpsum > 0)
                        {
                            bcclist.Add(new TempBrokerChainCollection { brokercode = newagentid, brokername = ar.name, newagentid = bc.newagentid, name = bc.name, tsis = bsissum, tMISFresh = bmisfsum, tppp = bppsum, tMIP = bnfpsum, tMIS1 = bmis1sum, tMIS2 = bmis2sum, tMIS3 = bmis3sum, tMIS4 = bmis4sum, tMIS5 = bmis5sum, tMIS6 = bmis6sum, tMIS7a = bmis7sum, companyname = cr.CompanyName, branchname = User.Identity.Name, branch = ag.mobile, bond = mr.custname, agent = mr.agentname, plan = mr.planname, sdate = sdate, edate = edate, address = cr.Address, emailid = cr.Emailid, contact = cr.Contact, domainname = cr.HeadOffice });
                        }

                    }

                    #endregion
                }
                else
                {
                    ViewBag.msg = "This Month Chain Not Released";
                }

                NewAgentid = newagentid;
                stdate = sdate;
                enddate = edate;

                return View(bcclist);
            }
        }
        public ActionResult PrintBrokerChainCollection()
        {
            MonthName mn = new MonthName();
            var mon = mn.numbertomonthname(stdate.Month);
            var mr = db.Members.Single(m => m.Id == 1);
            var cr = db.CompanyInfos.Single(c => c.Id == 1);
            var ar = db.BrokerCommLists.Single(a => a.newagentid == NewAgentid && a.month == mon && a.Year == stdate.Year);
            List<TempBrokerChainCollection> bcclist = new List<TempBrokerChainCollection>();
            #region Select Broker Chain Start Here

            List<BrokerChain> bclist = new List<BrokerChain>();
            bclist.Add(new BrokerChain { newagentid = ar.newagentid, name = ar.name, rankcode = ar.rankcode, rankname = ar.rankname, introducerid = ar.newintroducerid, introname = ar.Introname, branchname = User.Identity.Name });
            int rcount = 0;
            List<agents> dalist = new List<agents>();
            var alist = (from al in db.BrokerCommLists where al.newintroducerid == NewAgentid && al.month == mon && al.Year == stdate.Year select new { al.agencycode }).Distinct();
            foreach (var a in alist)
            {
                rcount = rcount + 1;
                dalist.Add(new agents { sr = rcount, agentcode = a.agencycode });
            }

            var maxsragent = dalist.Count;
            var minsragent = 1;
            while (minsragent <= maxsragent)
            {

                var da = dalist.Where(a => a.sr == minsragent);
                foreach (var d in da.ToList())
                {
                    var aalist = (from al in db.BrokerCommLists where al.introducerid == d.agentcode && al.month == mon && al.Year == stdate.Year select new { al.agencycode }).Distinct();
                    foreach (var aa in aalist)
                    {
                        rcount = rcount + 1;
                        dalist.Add(new agents { sr = rcount, agentcode = aa.agencycode });

                    }

                }
                minsragent = minsragent + 1;
                maxsragent = dalist.Count;
            }
            foreach (var dd in dalist)
            {
                var ad = db.BrokerCommLists.Single(a => a.agencycode == dd.agentcode && a.month == mon && a.Year == stdate.Year);
                bclist.Add(new BrokerChain { newagentid = ad.newagentid, name = ad.name, rankcode = ad.rankcode, rankname = ad.rankname, introducerid = ad.newintroducerid, introname = ad.Introname, branchname = User.Identity.Name });

            }

            #endregion

            #region Select Broker Collectin Start Here

            foreach (var bc in bclist)
            {
                List<Tempbond> tb = new List<Tempbond>();
                List<TempSelfCollection> bsclist = new List<TempSelfCollection>();

                var ag = db.BrokerCommLists.Single(hj => hj.newagentid == bc.newagentid && hj.month == mon && hj.Year == stdate.Year);


                var tbd = (from ap in db.appltabs where ap.newintroducerid == bc.newagentid && ap.status == 1 select ap.bondid).ToList();
                var bd = (from yt in db.Installmenttabs where yt.paymentdate >= stdate && yt.paymentdate <= enddate && tbd.Contains(yt.bondid) select new { yt.bondid }).Distinct();
                var count = tbd.Count();
                if (count > 0)
                {
                    foreach (var item in bd.ToList())
                    {
                        tb.Add(new Tempbond { bondid = item.bondid });
                    }

                    foreach (var t in tb.ToList())
                    {
                        List<SelfCollection> sf = new List<SelfCollection>();
                        int bondid = t.bondid;
                        var list = (from o in db.Installmenttabs
                                    join u in db.appltabs on o.newbondid equals u.newbondid
                                    where o.bondid == bondid && o.payamount != 0 && o.paymentdate >= stdate && o.paymentdate <= enddate
                                    orderby u.newbondid
                                    select new { o.payamount, o.installmentno, o.year, o.planname, u.plantype, u.plancode, u.totalcon }).ToList();

                        foreach (var g in list.ToList())
                        {
                            string subplan = g.plantype;
                            if (subplan == "FD")
                            {
                                sf.Add(new SelfCollection { sis = g.payamount });
                            }
                            if (subplan == "MIS" && g.installmentno == 1 && g.year == 1)
                            {
                                sf.Add(new SelfCollection { PPSFresh = g.totalcon });
                            }
                            if (subplan == "NFP" && g.installmentno == 1 && g.year == 1)
                            {
                                sf.Add(new SelfCollection { NFPFresh = g.payamount });
                            }
                            if (subplan == "RD" && g.installmentno == 1 && g.year == 1)
                            {
                                sf.Add(new SelfCollection { MISFresh = g.payamount });
                            }

                            if (subplan == "RD" && g.installmentno > 1 && g.year == 1)
                            {
                                sf.Add(new SelfCollection { MIS1 = g.payamount });
                            }

                            if (subplan == "RD" && g.installmentno > 1 && g.year == 2)
                            {
                                sf.Add(new SelfCollection { MIS2 = g.payamount });
                            }

                            if (subplan == "RD" && g.installmentno > 1 && g.year == 3)
                            {
                                sf.Add(new SelfCollection { MIS3 = g.payamount });
                            }

                            if (subplan == "RD" && g.installmentno > 1 && g.year == 4)
                            {
                                sf.Add(new SelfCollection { MIS4 = g.payamount });
                            }

                            if (subplan == "RD" && g.installmentno > 1 && g.year == 5)
                            {
                                sf.Add(new SelfCollection { MIS5 = g.payamount });
                            }

                            if (subplan == "RD" && g.installmentno > 1 && g.year == 6)
                            {
                                sf.Add(new SelfCollection { MIS6 = g.payamount });
                            }

                            if (subplan == "RD" && g.installmentno > 1 && g.year >= 7)
                            {
                                sf.Add(new SelfCollection { MIS7a = g.payamount });
                            }
                        }

                        var brow = db.appltabs.Single(bg => bg.bondid == bondid);
                        double sissum = 0, misfsum = 0, mis1sum = 0, mis2sum = 0, mis3sum = 0, mis4sum = 0, mis5sum = 0, mis6sum = 0, mis7sum = 0, pppsum = 0, nfssum = 0;

                        sissum = sf.Sum(tr => tr.sis);
                        misfsum = sf.Sum(tr => tr.MISFresh);
                        mis1sum = sf.Sum(tr => tr.MIS1);
                        mis2sum = sf.Sum(tr => tr.MIS2);
                        mis3sum = sf.Sum(tr => tr.MIS3);
                        mis4sum = sf.Sum(tr => tr.MIS4);
                        mis5sum = sf.Sum(tr => tr.MIS5);
                        mis6sum = sf.Sum(tr => tr.MIS6);
                        mis7sum = sf.Sum(tr => tr.MIS7a);
                        pppsum = sf.Sum(tr => tr.PPSFresh);
                        nfssum = sf.Sum(tr => tr.NFPFresh);
                        bsclist.Add(new TempSelfCollection { Newbondid = brow.newbondid, Customername = brow.name, brokername = ag.name, brokercode = ag.newagentid, tsis = sissum, tMISFresh = misfsum, tPPSFresh = pppsum, tNFPFresh = nfssum, tMIS1 = mis1sum, tMIS2 = mis2sum, tMIS3 = mis3sum, tMIS4 = mis4sum, tMIS5 = mis5sum, tMIS6 = mis6sum, tMIS7a = mis7sum, companyname = cr.CompanyName, branchname = User.Identity.Name, branch = mr.branchname, bond = mr.custname, agent = mr.agentname, plan = mr.planname, sdate = stdate, edate = enddate });
                    }


                }
                double bsissum = 0, bmisfsum = 0, bppsum = 0, bnfpsum = 0, bmis1sum = 0, bmis2sum = 0, bmis3sum = 0, bmis4sum = 0, bmis5sum = 0, bmis6sum = 0, bmis7sum = 0;
                bsissum = bsclist.Sum(tr => tr.tsis);
                bmisfsum = bsclist.Sum(tr => tr.tMISFresh);
                bmis1sum = bsclist.Sum(tr => tr.tMIS1);
                bmis2sum = bsclist.Sum(tr => tr.tMIS2);
                bmis3sum = bsclist.Sum(tr => tr.tMIS3);
                bmis4sum = bsclist.Sum(tr => tr.tMIS4);
                bmis5sum = bsclist.Sum(tr => tr.tMIS5);
                bmis6sum = bsclist.Sum(tr => tr.tMIS6);
                bmis7sum = bsclist.Sum(tr => tr.tMIS7a);
                bppsum = bsclist.Sum(tr => tr.tPPSFresh);
                bnfpsum = bsclist.Sum(tr => tr.tNFPFresh);


                if (bsissum + bmisfsum + bmis1sum + bmis2sum + bmis3sum + bmis4sum + bmis5sum + bmis6sum + bmis7sum + bppsum + bnfpsum > 0)
                {
                    bcclist.Add(new TempBrokerChainCollection { brokercode = NewAgentid, brokername = ar.name, newagentid = bc.newagentid, name = bc.name, tsis = bsissum, tMISFresh = bmisfsum, tppp = bppsum, tMIP = bnfpsum, tMIS1 = bmis1sum, tMIS2 = bmis2sum, tMIS3 = bmis3sum, tMIS4 = bmis4sum, tMIS5 = bmis5sum, tMIS6 = bmis6sum, tMIS7a = bmis7sum, companyname = cr.CompanyName, branchname = User.Identity.Name, branch = ag.mobile, bond = mr.custname, agent = mr.agentname, plan = mr.planname, sdate = stdate, edate = enddate, address = cr.Address, emailid = cr.Emailid, contact = cr.Contact, domainname = cr.HeadOffice });
                }

            }

            #endregion


            ReportDocument rdp = new ReportDocument();
            rdp.Load(Path.Combine(Server.MapPath("~/Reports"), "BrokerChainCollection.rpt"));
            rdp.SetDataSource(bcclist);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            try
            {
                Stream stream = rdp.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);

                return new FileStreamResult(stream, "application/pdf");
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
            finally
            {
                rdp.Close();
                rdp.Dispose();
            }
            return View();
        }

        [HttpGet]
        public ActionResult RenewalReceipt()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                List<Tempbond> tb = new List<Tempbond>();
                List<SelfdueCollection> sd = new List<SelfdueCollection>();

                var bd = db.appltabs.Where(n => n.newintroducerid == User.Identity.Name);
                var ar = db.AgentDetails.Single(a => a.NewAgentId == User.Identity.Name);
                var br = db.Branchtabs.Single(o => o.BranchCode == ar.BranchCode);
                var mr = db.Members.Single(m => m.Id == 1);
                var cr = db.CompanyInfos.Single(c => c.Id == 1);
                var llr = db.TDSLF_tabs.Single(l => l.Id == 1);
                int count = bd.Count();
                if (count > 0)
                {
                    foreach (var item in bd.ToList())
                    {
                        tb.Add(new Tempbond { bondid = item.bondid });
                    }
                    foreach (var t in tb.ToList())
                    {
                        Double latefine = 0;
                        var duelist = (from i in db.Installmenttabs where i.bondid == t.bondid && i.payamount == 0 && i.expirydate <= DateTime.Now select i).ToList();
                        foreach (var rsl in duelist)
                        {
                            if (rsl.mode == "Monthly")
                            {
                                DateTime pdate = Convert.ToDateTime(rsl.prevexpirydate).AddDays(15);
                                if (DateTime.Now.Date > pdate.Date)
                                {
                                    int diff = Convert.ToInt32(DateTime.Now.Date.Subtract(pdate).TotalDays);
                                    int r = diff / 30;
                                    latefine = Math.Round(((rsl.amount * llr.latefine) / 100) * (r + 1), 2);
                                }
                            }
                            else if (rsl.mode == "Quarterly")
                            {
                                DateTime pdate = Convert.ToDateTime(rsl.prevexpirydate).AddMonths(1);
                                if (DateTime.Now.Date > pdate.Date)
                                {
                                    int diff = Convert.ToInt32(DateTime.Now.Date.Subtract(pdate).TotalDays);
                                    int r = diff / 91;
                                    latefine = Math.Round(((rsl.amount * llr.latefine) / 100) * (r + 1), 2);
                                }
                            }
                            else if (rsl.mode == "Halfyearly")
                            {
                                DateTime pdate = Convert.ToDateTime(rsl.prevexpirydate).AddMonths(1);
                                if (DateTime.Now.Date > pdate.Date)
                                {
                                    int diff = Convert.ToInt32(DateTime.Now.Date.Subtract(pdate).TotalDays);
                                    int r = diff / 182;
                                    latefine = Math.Round(((rsl.amount * llr.latefine) / 100) * (r + 1), 2);

                                }
                            }
                            else if (rsl.mode == "Yearly")
                            {
                                DateTime pdate = Convert.ToDateTime(rsl.prevexpirydate).AddMonths(1);
                                if (DateTime.Now.Date > pdate.Date)
                                {
                                    int diff = Convert.ToInt32(DateTime.Now.Date.Subtract(pdate).TotalDays);
                                    int r = diff / 365;
                                    latefine = Math.Round(((rsl.amount * llr.latefine) / 100) * (r + 1), 2);
                                }
                            }
                        }
                        var dueinst = (from i in db.Installmenttabs where i.bondid == t.bondid && i.payamount == 0 && i.expirydate <= DateTime.Now select i).Count();
                        var dueamount = (from i in db.Installmenttabs where i.bondid == t.bondid && i.payamount == 0 && i.expirydate <= DateTime.Now select i.amount).DefaultIfEmpty(0).Sum();
                        var row = db.appltabs.Single(r => r.bondid == t.bondid);
                        sd.Add(new SelfdueCollection { newagentid = ar.NewAgentId, name = ar.name, newbondid = row.newbondid, cname = row.name, expirydate = row.expirydate, planname = row.planname, term = latefine, mode = row.mode, amount = dueamount, installmentno = dueinst, companyname = cr.CompanyName, branchname = br.BranchName, branch = mr.branchname, bond = mr.custname, agent = mr.agentname, plan = mr.planname, mobileno = row.mobileno, address = cr.Address, emailid = cr.Emailid, contact = cr.Contact, domainname = cr.HeadOffice });
                    }
                }
                else
                {
                    Response.Write("<script>alert('There is No data Related To this agent')</script>");

                }
                NewAgentid = User.Identity.Name;
                return View(sd);

            }
        }
        public ActionResult PrintBrokerSelfDueReport()
        {
            List<Tempbond> tb = new List<Tempbond>();
            List<SelfdueCollection> sd = new List<SelfdueCollection>();
            var bd = db.appltabs.Where(n => n.newintroducerid == User.Identity.Name);
            var ar = db.AgentDetails.Single(a => a.NewAgentId == User.Identity.Name);
            var br = db.Branchtabs.Single(o => o.BranchCode == ar.BranchCode);
            var mr = db.Members.Single(m => m.Id == 1);
            var cr = db.CompanyInfos.Single(c => c.Id == 1);
            var llr = db.TDSLF_tabs.Single(l => l.Id == 1);
            int count = bd.Count();
            if (count > 0)
            {

                foreach (var item in bd.ToList())
                {
                    tb.Add(new Tempbond { bondid = item.bondid });
                }

                foreach (var t in tb.ToList())
                {
                    Double latefine = 0;
                    var duelist = (from i in db.Installmenttabs where i.bondid == t.bondid && i.payamount == 0 && i.expirydate <= DateTime.Now select i).ToList();
                    foreach (var rsl in duelist)
                    {
                        if (rsl.mode == "Monthly")
                        {
                            DateTime pdate = Convert.ToDateTime(rsl.prevexpirydate).AddDays(15);
                            if (DateTime.Now.Date > pdate.Date)
                            {
                                int diff = Convert.ToInt32(DateTime.Now.Date.Subtract(pdate).TotalDays);
                                int r = diff / 30;
                                latefine = Math.Round(((rsl.amount * llr.latefine) / 100) * (r + 1), 2);
                            }
                        }
                        else if (rsl.mode == "Quarterly")
                        {
                            DateTime pdate = Convert.ToDateTime(rsl.prevexpirydate).AddMonths(1);
                            if (DateTime.Now.Date > pdate.Date)
                            {
                                int diff = Convert.ToInt32(DateTime.Now.Date.Subtract(pdate).TotalDays);
                                int r = diff / 91;
                                latefine = Math.Round(((rsl.amount * llr.latefine) / 100) * (r + 1), 2);
                            }
                        }
                        else if (rsl.mode == "Halfyearly")
                        {
                            DateTime pdate = Convert.ToDateTime(rsl.prevexpirydate).AddMonths(1);
                            if (DateTime.Now.Date > pdate.Date)
                            {
                                int diff = Convert.ToInt32(DateTime.Now.Date.Subtract(pdate).TotalDays);
                                int r = diff / 182;
                                latefine = Math.Round(((rsl.amount * llr.latefine) / 100) * (r + 1), 2);

                            }
                        }
                        else if (rsl.mode == "Yearly")
                        {
                            DateTime pdate = Convert.ToDateTime(rsl.prevexpirydate).AddMonths(1);
                            if (DateTime.Now.Date > pdate.Date)
                            {
                                int diff = Convert.ToInt32(DateTime.Now.Date.Subtract(pdate).TotalDays);
                                int r = diff / 365;
                                latefine = Math.Round(((rsl.amount * llr.latefine) / 100) * (r + 1), 2);
                            }
                        }
                    }
                    var dueinst = (from i in db.Installmenttabs where i.bondid == t.bondid && i.payamount == 0 && i.expirydate <= DateTime.Now select i).Count();
                    var dueamount = (from i in db.Installmenttabs where i.bondid == t.bondid && i.payamount == 0 && i.expirydate <= DateTime.Now select i.amount).DefaultIfEmpty(0).Sum();
                    var row = db.appltabs.Single(r => r.bondid == t.bondid);
                    sd.Add(new SelfdueCollection { newagentid = ar.NewAgentId, name = ar.name, newbondid = row.newbondid, cname = row.name, expirydate = row.expirydate, planname = row.planname, term = latefine, mode = row.mode, amount = dueamount, installmentno = dueinst, companyname = cr.CompanyName, branchname = br.BranchName, branch = mr.branchname, bond = mr.custname, agent = mr.agentname, plan = mr.planname, mobileno = row.mobileno, address = cr.Address, emailid = cr.Emailid, contact = cr.Contact, domainname = cr.HeadOffice });
                }

            }

            else
            {
                Response.Write("<script>alert('There is No data Related To this agent')</script>");

            }

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "BrokerSelfDueCollection.rpt"));
            rd.SetDataSource(sd);

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
            return View(sd);
        }

        [HttpGet]
        public ActionResult BrokerChainDueCollection()
        {

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Agent");
            }
            else
            {
                List<ChaindueCollection> bcdclist = new List<ChaindueCollection>();
                var mr = db.Members.Single(m => m.Id == 1);
                var cr = db.CompanyInfos.Single(c => c.Id == 1);
                var ar = db.AgentDetails.Single(a => a.NewAgentId == User.Identity.Name);

                #region Select Broker Chain Start Here

                List<BrokerChain> bclist = new List<BrokerChain>();
                bclist.Add(new BrokerChain { newagentid = ar.NewAgentId, name = ar.name, rankcode = ar.RankCode, rankname = ar.RankName, introducerid = ar.NewIntroducerId, introname = ar.IntroName, branchname = User.Identity.Name });
                int rcount = 0;
                List<agents> dalist = new List<agents>();
                var alist = (from al in db.AgentDetails where al.NewIntroducerId == ar.NewAgentId select new { al.AgencyCode }).Distinct();
                foreach (var a in alist)
                {
                    rcount = rcount + 1;
                    dalist.Add(new agents { sr = rcount, agentcode = a.AgencyCode });
                }

                var maxsragent = dalist.Count;
                var minsragent = 1;
                while (minsragent <= maxsragent)
                {

                    var da = dalist.Where(a => a.sr == minsragent);
                    foreach (var d in da.ToList())
                    {
                        var aalist = (from al in db.AgentDetails where al.IntroducerCode == d.agentcode select new { al.AgencyCode }).Distinct();
                        foreach (var aa in aalist)
                        {
                            rcount = rcount + 1;
                            dalist.Add(new agents { sr = rcount, agentcode = aa.AgencyCode });

                        }

                    }
                    minsragent = minsragent + 1;
                    maxsragent = dalist.Count;
                }
                foreach (var dd in dalist)
                {
                    var ad = db.AgentDetails.Single(a => a.AgencyCode == dd.agentcode);
                    bclist.Add(new BrokerChain { newagentid = ad.NewAgentId, name = ad.name, rankcode = ad.RankCode, rankname = ad.RankName, introducerid = ad.NewIntroducerId, introname = ad.IntroName, branchname = User.Identity.Name });

                }

                #endregion
                #region Select Due Collectin Start Here
                foreach (var bc in bclist)
                {

                    DateTime date = DateTime.Now.Date;
                    var tb = (from n in db.appltabs where n.newintroducerid == bc.newagentid && n.plantype == "RD" && n.status == 1 select n);
                    foreach (var t in tb.ToList())
                    {
                        double amount = 0;
                        List<BondDueCollection> bsdclist = new List<BondDueCollection>();
                        var bwdilist = (from i in db.Installmenttabs where i.bondid == t.bondid && i.payamount == 0 && i.prevexpirydate < date select i).ToList();
                        foreach (var bwdi in bwdilist)
                        {
                            bsdclist.Add(new BondDueCollection { amount = bwdi.amount });
                        }


                        amount = bsdclist.Sum(tr => tr.amount);
                        if (amount > 0)
                        {
                            bcdclist.Add(new ChaindueCollection { brokercode = ar.NewAgentId, brokername = ar.name, newagentid = bc.newagentid, name = bc.name, newbondid = t.newbondid, cname = t.name, expirydate = t.expirydate, planname = t.planname, term = t.term, mode = t.mode, amount = amount, companyname = cr.CompanyName, branchname = User.Identity.Name, branch = mr.branchname, bond = mr.custname, agent = mr.agentname, plan = mr.planname, address = cr.Address, emailid = cr.Emailid, contact = cr.Contact, domainname = cr.HeadOffice, mobileno = t.mobileno });
                        }
                    }

                }
                #endregion

                NewAgentid = ar.NewAgentId;
                return View(bcdclist);
            }
        }
        public ActionResult PrintBrokerChainDueReport()
        {
            List<ChaindueCollection> bcdclist = new List<ChaindueCollection>();
            var mr = db.Members.Single(m => m.Id == 1);
            var cr = db.CompanyInfos.Single(c => c.Id == 1);
            var ar = db.AgentDetails.Single(a => a.NewAgentId == NewAgentid);

            #region Select Broker Chain Start Here

            List<BrokerChain> bclist = new List<BrokerChain>();
            bclist.Add(new BrokerChain { newagentid = ar.NewAgentId, name = ar.name, rankcode = ar.RankCode, rankname = ar.RankName, introducerid = ar.NewIntroducerId, introname = ar.IntroName, branchname = User.Identity.Name });
            int rcount = 0;
            List<agents> dalist = new List<agents>();
            var alist = (from al in db.AgentDetails where al.NewIntroducerId == NewAgentid select new { al.AgencyCode }).Distinct();
            foreach (var a in alist)
            {
                rcount = rcount + 1;
                dalist.Add(new agents { sr = rcount, agentcode = a.AgencyCode });
            }

            var maxsragent = dalist.Count;
            var minsragent = 1;
            while (minsragent <= maxsragent)
            {

                var da = dalist.Where(a => a.sr == minsragent);
                foreach (var d in da.ToList())
                {
                    var aalist = (from al in db.AgentDetails where al.IntroducerCode == d.agentcode select new { al.AgencyCode }).Distinct();
                    foreach (var aa in aalist)
                    {
                        rcount = rcount + 1;
                        dalist.Add(new agents { sr = rcount, agentcode = aa.AgencyCode });

                    }

                }
                minsragent = minsragent + 1;
                maxsragent = dalist.Count;
            }
            foreach (var dd in dalist)
            {
                var ad = db.AgentDetails.Single(a => a.AgencyCode == dd.agentcode);
                bclist.Add(new BrokerChain { newagentid = ad.NewAgentId, name = ad.name, rankcode = ad.RankCode, rankname = ad.RankName, introducerid = ad.NewIntroducerId, introname = ad.IntroName, branchname = User.Identity.Name });

            }

            #endregion
            #region Select Due Collectin Start Here
            foreach (var bc in bclist)
            {

                DateTime date = DateTime.Now.Date;
                var tb = (from n in db.appltabs where n.newintroducerid == bc.newagentid && n.plantype == "RD" && n.status == 1 select n);
                foreach (var t in tb.ToList())
                {
                    double amount = 0;
                    List<BondDueCollection> bsdclist = new List<BondDueCollection>();
                    var bwdilist = (from i in db.Installmenttabs where i.bondid == t.bondid && i.payamount == 0 && i.prevexpirydate < date select i).ToList();
                    foreach (var bwdi in bwdilist)
                    {
                        bsdclist.Add(new BondDueCollection { amount = bwdi.amount });
                    }


                    amount = bsdclist.Sum(tr => tr.amount);
                    if (amount > 0)
                    {
                        bcdclist.Add(new ChaindueCollection { brokercode = NewAgentid, brokername = ar.name, newagentid = bc.newagentid, name = bc.name, newbondid = t.newbondid, cname = t.name, expirydate = t.expirydate, planname = t.planname, term = t.term, mode = t.mode, amount = amount, companyname = cr.CompanyName, branchname = User.Identity.Name, branch = mr.branchname, bond = mr.custname, agent = mr.agentname, plan = mr.planname, address = cr.Address, emailid = cr.Emailid, contact = cr.Contact, domainname = cr.HeadOffice, mobileno = t.mobileno });
                    }
                }

            }
            #endregion

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "BrokerChainDueCollection.rpt"));
            rd.SetDataSource(bcdclist);

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

        [HttpGet]
        public ActionResult QuotaCollection()
        {
            List<QuotaCollectionList> quotalist = new List<QuotaCollectionList>();
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Agent");
            }
            else
            {
                int count = (from n in db.NewLogins where n.UserName == User.Identity.Name select n.UserName).Count();
                if (count == 1)
                {
                    var log = db.NewLogins.Single(a => a.UserName == User.Identity.Name);
                    if (log.status == 1 && log.type == "Agent")
                    {
                        return View(quotalist);
                    }
                    else
                    {
                        return RedirectToAction("Logout", "Agent");
                    }
                }
                else
                {
                    return RedirectToAction("Logout", "Agent");
                }
            }
        }
        [HttpPost]
        public ActionResult QuotaCollection(DateTime sdate, DateTime edate)
        {
            List<QuotaCollectionList> quotalist = new List<QuotaCollectionList>();
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logout", "Agent");
            }
            else
            {
                MonthName mn = new MonthName();
                var mr = db.Members.Single(m => m.Id == 1);
                var cr = db.CompanyInfos.Single(c => c.Id == 1);
                var dalist = db.AgentDetails.Where(a => a.NewAgentId == User.Identity.Name).ToList();

                #region Select Broker Chain Start Here

                List<BrokerChain> bclist = new List<BrokerChain>();
                foreach (var dd in dalist)
                {
                    var ad = db.AgentDetails.Single(a => a.AgencyCode == dd.AgencyCode);
                    bclist.Add(new BrokerChain { newagentid = ad.NewAgentId, name = ad.name, rankcode = ad.RankCode, rankname = ad.RankName, introducerid = ad.NewIntroducerId, introname = ad.IntroName, branchname = ad.BranchCode });
                }

                #endregion

                foreach (var bc in bclist)
                {


                    var bwr = db.AgentDetails.Single(bw => bw.NewAgentId == bc.newagentid);
                    var rr = db.Ranktabs.Single(rw => rw.RankCode == bc.rankcode);

                    var br = db.Branchtabs.Single(b => b.BranchCode == bwr.BranchCode);

                    #region Select Sub Broker Chain Start Here

                    List<BrokerChain> subbclist = new List<BrokerChain>();
                    subbclist.Add(new BrokerChain { newagentid = bwr.NewAgentId, name = bwr.name, rankcode = bwr.RankCode, rankname = bwr.RankName, introducerid = bwr.NewIntroducerId, introname = bwr.IntroName, branchname = User.Identity.Name });
                    int srcount = 0;
                    List<agents> sdalist = new List<agents>();
                    var salist = (from sal in db.AgentDetails where sal.NewIntroducerId == bwr.NewAgentId select new { sal.AgencyCode }).Distinct();
                    foreach (var sa in salist)
                    {
                        srcount = srcount + 1;
                        sdalist.Add(new agents { sr = srcount, agentcode = sa.AgencyCode });
                    }

                    var smaxsragent = sdalist.Count;
                    var sminsragent = 1;
                    while (sminsragent <= smaxsragent)
                    {

                        var sda = sdalist.Where(sa => sa.sr == sminsragent);
                        foreach (var sd in sda.ToList())
                        {
                            var saalist = (from sal in db.AgentDetails where sal.IntroducerCode == sd.agentcode select new { sal.AgencyCode }).Distinct();
                            foreach (var saa in saalist)
                            {
                                srcount = srcount + 1;
                                sdalist.Add(new agents { sr = srcount, agentcode = saa.AgencyCode });

                            }

                        }
                        sminsragent = sminsragent + 1;
                        smaxsragent = sdalist.Count;
                    }

                    foreach (var sdd in sdalist)
                    {
                        var sad = db.AgentDetails.Single(sa => sa.AgencyCode == sdd.agentcode);
                        subbclist.Add(new BrokerChain { newagentid = sad.NewAgentId, name = sad.name, rankcode = sad.RankCode, rankname = sad.RankName, introducerid = sad.NewIntroducerId, introname = sad.IntroName, branchname = User.Identity.Name });
                    }

                    #endregion

                    List<InstallmentList> inslist = new List<InstallmentList>();
                    Double btotalcoll = 0, bquotaamount = 0, bipptotalcoll = 0, bdpptotalcoll = 0, Difference = 0;
                    var status = string.Empty;
                    var prankcount = 0;
                    foreach (var sbc in subbclist)
                    {

                        var tbd = (from ap in db.appltabs where ap.newintroducerid == sbc.newagentid select ap.bondid);
                        var bondlist = (from yt in db.Installmenttabs where yt.paymentdate >= sdate && yt.paymentdate <= edate && tbd.Contains(yt.bondid) select new { yt.newbondid }).Distinct().ToList();
                        foreach (var bond in bondlist)
                        {
                            var planlist = (from pl in db.Installmenttabs where pl.paymentdate >= sdate && pl.paymentdate <= edate && pl.newbondid == bond.newbondid && pl.type != "Adjustment" && pl.year == 1 select pl).ToList();
                            foreach (var plan in planlist)
                            {
                                inslist.Add(new InstallmentList { newbondid = plan.newbondid, installmentno = plan.installmentno, mode = plan.mode, year = plan.year, term = plan.term_plan, planname = plan.planname, amount = plan.payamount });
                            }
                        }
                    }

                    var brocount = db.AgentDetails.Where(sc => sc.NewIntroducerId == bc.newagentid).Count();
                    var pnlist = inslist.Select(i => new { i.planname, i.term }).Distinct();
                    foreach (var pn in pnlist)
                    {
                        var pc = db.Plans.Single(t => t.shortcutname == pn.planname);
                        var p = db.RateTabs.Single(i => i.projectname == pc.Planname && i.term == pn.term);
                        Double totalcoll = 0, quotaamount = 0;
                        totalcoll = inslist.Where(ftr => ftr.planname == pn.planname && ftr.term == pn.term).Sum(r => (Double)r.amount);
                        quotaamount = Math.Round(((totalcoll * p.quotaper) / 100), 2);
                        btotalcoll = btotalcoll + totalcoll;
                        bquotaamount = bquotaamount + quotaamount;
                    }

                    if (rr.TeamQuota > bquotaamount)
                    {
                        Difference = rr.TeamQuota - bquotaamount;
                        status = "NA";
                    }
                    else
                    {
                        Difference = 0;
                        status = "ACHIEVED";
                    }
                    if (btotalcoll > 0)
                    {
                        //quotalist.Add(new QuotaCollectionList { newagentid = bc.newagentid, name = bc.name, rankname = bc.rankname, newintroducerid = bwr.NewIntroducerId, IPPBusiness = bipptotalcoll, DPPBusiness = bdpptotalcoll, business = btotalcoll, quotaamount = bquotaamount, PromotionTarget = rr.TeamQuota, rankcount = brocount, prankcount = prankcount, Difference = Difference, sdate = sdate, edate = edate, companyname = cr.CompanyName, branchname = br.BranchName, branch = mr.branchname, bond = mr.custname, plan = mr.planname, agent = mr.agentname, rankcode = bc.rankcode, status = status });
                    }

                }

                stdate = sdate;
                enddate = edate;
                return View(quotalist.OrderByDescending(q => q.rankcode));
            }
        }
        public ActionResult PrintQuotaCollection()
        {
            List<QuotaCollectionList> quotalist = new List<QuotaCollectionList>();
            MonthName mn = new MonthName();
            var mr = db.Members.Single(m => m.Id == 1);
            var cr = db.CompanyInfos.Single(c => c.Id == 1);
            var dalist = db.AgentDetails.Where(a => a.NewAgentId == User.Identity.Name).ToList();

            #region Select Broker Chain Start Here

            List<BrokerChain> bclist = new List<BrokerChain>();
            foreach (var dd in dalist)
            {
                var ad = db.AgentDetails.Single(a => a.AgencyCode == dd.AgencyCode);
                bclist.Add(new BrokerChain { newagentid = ad.NewAgentId, name = ad.name, rankcode = ad.RankCode, rankname = ad.RankName, introducerid = ad.NewIntroducerId, introname = ad.IntroName, branchname = ad.BranchCode });
            }

            #endregion

            foreach (var bc in bclist)
            {


                var bwr = db.AgentDetails.Single(bw => bw.NewAgentId == bc.newagentid);
                var rr = db.Ranktabs.Single(rw => rw.RankCode == bc.rankcode);
                var br = db.Branchtabs.Single(b => b.BranchCode == bwr.BranchCode);

                #region Select Sub Broker Chain Start Here

                List<BrokerChain> subbclist = new List<BrokerChain>();
                subbclist.Add(new BrokerChain { newagentid = bwr.NewAgentId, name = bwr.name, rankcode = bwr.RankCode, rankname = bwr.RankName, introducerid = bwr.NewIntroducerId, introname = bwr.IntroName, branchname = br.BranchName });
                int srcount = 0;
                List<agents> sdalist = new List<agents>();
                var salist = (from sal in db.AgentDetails where sal.NewIntroducerId == bwr.NewAgentId select new { sal.AgencyCode }).Distinct();
                foreach (var sa in salist)
                {
                    srcount = srcount + 1;
                    sdalist.Add(new agents { sr = srcount, agentcode = sa.AgencyCode });
                }

                var smaxsragent = sdalist.Count;
                var sminsragent = 1;
                while (sminsragent <= smaxsragent)
                {

                    var sda = sdalist.Where(sa => sa.sr == sminsragent);
                    foreach (var sd in sda.ToList())
                    {
                        var saalist = (from sal in db.AgentDetails where sal.IntroducerCode == sd.agentcode select new { sal.AgencyCode }).Distinct();
                        foreach (var saa in saalist)
                        {
                            srcount = srcount + 1;
                            sdalist.Add(new agents { sr = srcount, agentcode = saa.AgencyCode });

                        }

                    }
                    sminsragent = sminsragent + 1;
                    smaxsragent = sdalist.Count;
                }

                foreach (var sdd in sdalist)
                {
                    var sad = db.AgentDetails.Single(sa => sa.AgencyCode == sdd.agentcode);
                    subbclist.Add(new BrokerChain { newagentid = sad.NewAgentId, name = sad.name, rankcode = sad.RankCode, rankname = sad.RankName, introducerid = sad.NewIntroducerId, introname = sad.IntroName, branchname = br.BranchName });
                }

                #endregion

                List<InstallmentList> inslist = new List<InstallmentList>();
                Double btotalcoll = 0, bquotaamount = 0, bipptotalcoll = 0, bdpptotalcoll = 0, Difference = 0;
                var status = string.Empty;
                var prankcount = 0;
                foreach (var sbc in subbclist)
                {

                    var tbd = (from ap in db.appltabs where ap.newintroducerid == sbc.newagentid select ap.bondid);
                    var bondlist = (from yt in db.Installmenttabs where yt.paymentdate >= stdate && yt.paymentdate <= enddate && tbd.Contains(yt.bondid) select new { yt.newbondid }).Distinct().ToList();
                    foreach (var bond in bondlist)
                    {
                        var planlist = (from pl in db.Installmenttabs where pl.paymentdate >= stdate && pl.paymentdate <= enddate && pl.newbondid == bond.newbondid && pl.type != "Adjustment" && pl.year == 1 select pl).ToList();
                        foreach (var plan in planlist)
                        {
                            inslist.Add(new InstallmentList { newbondid = plan.newbondid, installmentno = plan.installmentno, mode = plan.mode, year = plan.year, term = plan.term_plan, planname = plan.planname, amount = plan.payamount });
                        }
                    }
                }

                var brocount = db.AgentDetails.Where(sc => sc.NewIntroducerId == bc.newagentid).Count();
                var pnlist = inslist.Select(i => new { i.planname, i.term }).Distinct();
                foreach (var pn in pnlist)
                {
                    var pc = db.Plans.Single(t => t.shortcutname == pn.planname);
                    var p = db.RateTabs.Single(i => i.projectname == pc.Planname && i.term == pn.term);
                    Double totalcoll = 0, quotaamount = 0;
                    totalcoll = inslist.Where(ftr => ftr.planname == pn.planname && ftr.term == pn.term).Sum(r => (Double)r.amount);
                    quotaamount = Math.Round(((totalcoll * p.quotaper) / 100), 2);
                    btotalcoll = btotalcoll + totalcoll;
                    bquotaamount = bquotaamount + quotaamount;
                }

                if (rr.TeamQuota > bquotaamount)
                {
                    Difference = rr.TeamQuota - bquotaamount;
                    status = "NA";
                }
                else
                {
                    Difference = 0;
                    status = "ACHIEVED";

                }
                if (btotalcoll > 0)
                {
                    quotalist.Add(new QuotaCollectionList { newagentid = bc.newagentid, name = bc.name, rankname = bc.rankname, newintroducerid = bwr.NewIntroducerId, IPPBusiness = bipptotalcoll, DPPBusiness = bdpptotalcoll, business = btotalcoll, quotaamount = bquotaamount, PromotionTarget = rr.TeamQuota, rankcount = brocount, prankcount = prankcount, Difference = Difference, sdate = stdate, edate = enddate, companyname = cr.CompanyName, branchname = br.BranchName, branch = mr.branchname, bond = mr.custname, plan = mr.planname, agent = mr.agentname, rankcode = bc.rankcode, status = status });
                }

            }

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports/Branch"), "QuotaCollection.rpt"));
            rd.SetDataSource(quotalist.OrderByDescending(q => q.rankcode));

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

        [HttpGet]
        public ActionResult VoucherList()
        {
            List<Voucher> tb = new List<Voucher>();
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return View(tb);
            }
        }
        [HttpPost]
        public ActionResult VoucherList(string year,int month = 0)
        {
            List<Voucher> tb = new List<Voucher>();
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                int yr = Convert.ToInt32(year);
                var bb = db.AgentDetails.Single(nb => nb.NewAgentId == User.Identity.Name);
                var dt = (from d in db.commission_tabs
                          where d.newagentid == bb.NewAgentId && d.date.Year==yr && (from m in db.ReleaseTabs where m.month == month && m.year == year select m.month)
                              .Contains(d.date.Month)
                          select d).ToList();
               // var bd = db.commission_tabs.Where(n => n.newagentid == bb.NewAgentId && n.date.Month == month && n.date.Year == year);
                int count = dt.Count();
                if (count > 0)
                {
                    foreach (var item in dt.ToList())
                    {
                        tb.Add(new Voucher { newagentid = User.Identity.Name, planname = item.planname, year = item.year, business = item.amount, tds = item.percentage, commission = item.commission, netamount = 0, branch = item.branchcode, date = item.date, newbondid = item.newbondid, name = item.bondname });
                    }
                }
                else
                {
                    Response.Write("<script>alert('Your Commission of this Month is not release ..')</script>");

                }
                
                return View(tb);

            }
        }
        public ActionResult PrintVoucher()
        {
            List<Voucher> tb = new List<Voucher>();
            var bb = db.AgentDetails.Single(nb => nb.NewAgentId == User.Identity.Name);
            var bd = db.commission_tabs.Where(n => n.newagentid == bb.NewAgentId && n.date.Month == vmonth && n.date.Year == vvyear);
            int count = bd.Count();
            if (count > 0)
            {

                foreach (var item in bd.ToList())
                {
                    tb.Add(new Voucher { newagentid = User.Identity.Name, planname = item.planname, year = item.year, business = item.amount, tds = item.percentage, commission = item.commission, netamount = 0, branch = item.branchcode, date = item.date, newbondid = item.newbondid, name = item.bondname });
                }

            }
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "Voucher.rpt"));
            rd.SetDataSource(tb);

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
      
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }

        #region vishal vehicle request code

        [HttpGet]
        public ActionResult VehicleRequest()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

            }
            return View();
        }
        //vehicle request done by advisor here
        [HttpPost]
        public ActionResult VehicleRequest(VehicleRequestDetail model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var count = db.VehicleRequestDetails.Where(o => o.RequestToken == model.RequestToken).Count();
                if (count == 0)
                {
                    VehicleRequestDetail v = new VehicleRequestDetail();
                    v.RequestToken = model.RequestToken;
                    v.NoOfSeatRequired = model.NoOfSeatRequired;
                    v.AgentId = User.Identity.Name;
                    v.VisitDate = model.VisitDate;
                    v.ReturnDate = model.ReturnDate;
                    v.ApprovedDate = DateTime.Now;
                    v.RequestedDate = DateTime.Now.Date;
                    v.RequestTime = DateTime.Now.ToShortTimeString();
                    v.TravelDistance = model.TravelDistance;

                    v.ApprovTime = DateTime.Now.ToShortTimeString();
                    v.Status = 1;

                    db.VehicleRequestDetails.Add(v);
                    int a = db.SaveChanges();
                    if (a == 1)
                    {
                        ViewBag.msg = "Your Request Has Been Sent To Admin !!";
                    }
                    else
                    {
                        ViewBag.msg = "Aww Request Not Send...Try Again !!";

                    }
                }

            }


            return View();
        }

        public ActionResult businessplan()
        {
            return View();
        }


        [HttpGet]
        public ActionResult bank_detail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult bank_detail(AgentDetail aged)
        {
            if (aged.NewAgentId != null)
            {
                var countid = db.AgentDetails.Where(a => a.NewAgentId == aged.NewAgentId).Count();
                if (countid == 1)
                {
                    var getid = db.AgentDetails.Single(a => a.NewAgentId == aged.NewAgentId);
                    getid.BankName = aged.BankName;
                    getid.BankAccountno = aged.BankAccountno;
                    getid.IFCCode = aged.IFCCode;
                    getid.BankAddress = aged.BankAddress;
                    db.Entry(getid).State = EntityState.Modified;
                    db.SaveChanges();
                    Response.Write("<script>alert('Your Bank Detail Updated Succcessfully...!!!')</script>");
                    return View();
                }
                else
                {
                    Response.Write("<script>alert('Invalid ID...!!!')</script>");
                    return View();
                }
            }
            return View();
        }

        public ActionResult projectdetail()
        {
            return View();
        }

        //vehicle request history
        public ActionResult VehicleRequestHistory(int a = 0)
        {

            return View();
        }



        #endregion

    }
}


