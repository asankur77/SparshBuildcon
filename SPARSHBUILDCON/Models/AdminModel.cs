using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SPARSHBUILDCON.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<AdvBrokerPaymentTab> AdvBrokerPaymentTabs { get; set; }
        public DbSet<AgentDetail> AgentDetails { get; set; }
        public DbSet<appltab> appltabs { get; set; }
        public DbSet<Bond_report> Bond_reports { get; set; }
        public DbSet<bonus_tab> bonus_tabs { get; set; }
        public DbSet<branchlogindetail> branchlogindetails { get; set; }
        public DbSet<Branchtab> Branchtabs { get; set; }
        public DbSet<calculator> calculators { get; set; }
        public DbSet<Cancel_Receipt> Cancel_Receipts { get; set; }
        public DbSet<CityStateTab> CityStateTabs { get; set; }
        public DbSet<comm_tab> comm_tabs { get; set; }
        public DbSet<commission_tab> commission_tabs { get; set; }
        public DbSet<CompanyInfo> CompanyInfos { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<delete_bond> delete_bonds { get; set; }
        public DbSet<DocumentTab> DocumentTabs { get; set; }
        public DbSet<DuplicateTab> DuplicateTabs { get; set; }
        public DbSet<DupliMacTab> DupliMacTabs { get; set; }
        public DbSet<Emp_atten> Emp_attens { get; set; }
        public DbSet<Emp_leave> Emp_leaves { get; set; }
        public DbSet<Emp_Reg> Emp_Regs { get; set; }
        public DbSet<Emp_Salary> Emp_Salarys { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Fixed_Tab> Fixed_Tabs { get; set; }
        public DbSet<HeadTab> HeadTabs { get; set; }
        public DbSet<HRTab> HRTabs { get; set; }
        public DbSet<hrlogin_detail> hrlogin_details { get; set; }
        public DbSet<ICardTab> ICardTabs { get; set; }
        public DbSet<InOutTime> InOutTimes { get; set; }
        public DbSet<Installmenttab> Installmenttabs { get; set; }
        public DbSet<MISInstallmenttab> MISInstallmenttabs { get; set; }
        public DbSet<MacTab> MacTabs { get; set; }
        public DbSet<MaturityTab> MaturityTabs { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<NewLogin> NewLogins { get; set; }
        public DbSet<NewPlan> NewPlans { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<operatorlogin_detail> operatorlogin_details { get; set; }
        public DbSet<MIPP_tab> MIPP_tabs { get; set; }
        public DbSet<Pension_Tab> Pension_Tabs { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<PlanTab> PlanTabs { get; set; }
        public DbSet<Plan_Tab> Plan_Tabs { get; set; }
        public DbSet<Ranktab> Ranktabs { get; set; }
        public DbSet<RecieptTab> RecieptTabs { get; set; }
        public DbSet<relation> relations { get; set; }
        public DbSet<Salary_em> Salary_ems { get; set; }
        public DbSet<SalaryTab> SalaryTabs { get; set; }
        public DbSet<SchemeTab> SchemeTabs { get; set; }
        public DbSet<SetMacTab> SetMacTabs { get; set; }
        public DbSet<spotcommission_tab> spotcommission_tabs { get; set; }
        public DbSet<SpotCommTab> SpotCommTabs { get; set; }
        public DbSet<TDSLF_tab> TDSLF_tabs { get; set; }
        public DbSet<VFormatTab> VFormatTabs { get; set; }
        public DbSet<Voucher_Report> Voucher_Reports { get; set; }
        public DbSet<SavingAccountInfo> SavingAccountInfos { get; set; }
        public DbSet<Member_tab> Member_tabs { get; set; }
        public DbSet<TransactionTab> TransactionTabs { get; set; }
        public DbSet<ReleaseTab> ReleaseTabs { get; set; }
        public DbSet<BrokerCommList> BrokerCommLists { get; set; }
        public DbSet<Formdate> Formdates { get; set; }
        public DbSet<RPTab> RPTabs { get; set; }
        public DbSet<RevivalTab> RevivalTabs { get; set; }
        public DbSet<MaturityDocument> MaturityDocuments { get; set; }
        public DbSet<MaturityStatus> MaturityStatuss { get; set; }
        public DbSet<ChangeAgentId> ChangeAgentIds { get; set; }
        public DbSet<Blockdate> Blockdates { get; set; }
        public DbSet<AdvDeductionVoucher> AdvDeductionVouchers { get; set; }
        public DbSet<BookingTab> BookingTabs { get; set; }
        public DbSet<ProTerm> ProTerms { get; set; }
        public DbSet<RateTab> RateTabs { get; set; }
        public DbSet<PlotLimit> PlotLimits { get; set; }
        public DbSet<PhaseTab> PhaseTabs { get; set; }
        public DbSet<BlockTab> BlockTabs { get; set; }
        public DbSet<spotcomm_tab> spotcomm_tabs { get; set; }
        public DbSet<HoldingPlot> HoldingPlots { get; set; }
        public DbSet<Plotregistry> Plotregistrys { get; set; }
        public DbSet<Visitortab> Visitortabs { get; set; }
        public DbSet<tempappltab> tempappltabs { get; set; }
        public DbSet<SMSSpotCommTab> SMSSpotCommTabs { get; set; }
        public DbSet<TempInstallmenttab> TempInstallmenttabs { get; set; }
        //USED IN API
        public DbSet<Request_Money> Request_Moneys { get; set; }
        public DbSet<PayU_Payment> PayU_Payments { get; set; }
        public DbSet<Wallet_Transaction> Wallet_Transactions { get; set; }
        public DbSet<PC_Tab> PC_Tabs { get; set; }
        public DbSet<BankDetail_Tab> BankDetail_Tabs { get; set; }
        public DbSet<DailyDepositTab> DailyDepositTabs { get; set; }
        public DbSet<ClosingAmount_Tab> ClosingAmount_Tabs { get; set; }
        public DbSet<ClosingMatchingTab> ClosingMatchingTabs { get; set; }
        public DbSet<TempDailyDepositTab> TempDailyDepositTabs { get; set; }
        //
        public DbSet<DailyVisitor> DailyVisitors { get; set; }
        public DbSet<DailyVisitorDetail> DailyVisitorDetails { get; set; }
        public DbSet<VehicleRequestDetail> VehicleRequestDetails { get; set; }
       
        //Used in Binary
        
        public DbSet<User> Users { get; set; }
        public DbSet<Gallery> Gallerys { get; set; }
        public DbSet<binary> binarys { get; set; }
        public DbSet<spiltab> spiltabs { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<genology_tab> genology_tabs { get; set; }
        public DbSet<userinformation> userinformations { get; set; }
        public DbSet<pintab> pintabs { get; set; }
        public DbSet<wallettab> wallettabs { get; set; }
        public DbSet<Operator_detail> Operator_details { get; set; }
        public DbSet<Introducer_Update> Introducer_Updates { get; set; }
        public DbSet<package_tab> package_tabs { get; set; }
        public DbSet<PayoutSummary> PayoutSummarys { get; set; }
        public DbSet<LevelDetail> LevelDetails { get; set; }
        public DbSet<LevelIncomee> LevelIncomees { get; set; }
        public DbSet<PayoutTab> PayoutTabs { get; set; }
        public DbSet<SetDeduction> SetDeductions { get; set; }
        public DbSet<TeamLeveIncome> TeamLeveIncomes { get; set; }
        public DbSet<Wallet_History> Wallet_Historys { get; set; }
        public DbSet<Newstab> Newstabs { get; set; }
        public DbSet<WithdrawalRequest> WithdrawalRequests { set; get; }
        public DbSet<BussinessPlanImage> BussinessPlanImages { get; set; }
        public DbSet<BinaryIncome> BinaryIncomes { get; set; }
        public DbSet<binarypayment> binarypayments { get; set; }
        public DbSet<Member_Turnover> Member_Turnovers { get; set; }
        public DbSet<Increment_tab> Increment_tabs { get; set; }
        public DbSet<PackageAssign> PackageAssigns { get; set; }
        public DbSet<DSIINCOME> DSIINCOMEs { get; set; }
        public DbSet<Roipackage> Roipackages { get; set; }
        public DbSet<Roiincome> Roiincomes { get; set; }
        public DbSet<slcincome> slcincomes { get; set; }
        public DbSet<payout_date> payout_dates { get; set; }
        public DbSet<Create_Pin> Create_Pins { get; set; }
        public DbSet<Transfer_Pin> Transfer_Pins { get; set; }
        public DbSet<matching_income_detail> matching_income_details { get; set; }
        public DbSet<Userinfo2> Userinfo2s { get; set; }
        public DbSet<TwoIsToOneBinaryCheck> TwoIsToOneBinaryChecks { get; set; }
        public DbSet<Performance_income> Performance_incomes { get; set; }
        public DbSet<binary2> binary2s { get; set; }
        public DbSet<genology_tab2> genology_tab2s { get; set; }
        public DbSet<RoyaltyIncome> RoyaltyIncomes { get; set; }
        public DbSet<AutopoolIncome> AutopoolIncomes { get; set; }
        public DbSet<Achiever> Achievers { get; set; }
        public DbSet<OTP> OTPS { get; set; }
        public DbSet<contactdetail> contactdetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Popupimage> Popupimages { get; set; }
        public DbSet<Product_Detail> Product_Details { get; set; }
        public DbSet<slider> sliders { get; set; }
        public DbSet<payoutfast> payoutfasts { get; set; }
        public DbSet<payout_date2> payout_date2s { get; set; }
        public DbSet<PayoutSummary2> PayoutSummary2s { get; set; }
        public DbSet<payoutfast2> payoutfast2s { get; set; }
        public DbSet<DirectIncome> DirectIncomes { get; set; }
        public DbSet<LeaderIncome> LeaderIncomes { get; set; }
        public DbSet<popup> popups { get; set; }
        public DbSet<Mediagallery> Mediagallerys { get; set; }
        public DbSet<ProgramGallery> ProgramGallerys { get; set; }
        public DbSet<businesstab> businesstabs { get; set; }
    }
    /**/
    [Table("VehicleRequestDetail")]
    public class VehicleRequestDetail
    {
        [Key]
        public int Id { get; set; }
        public string RequestToken { get; set; }
        public DateTime RequestedDate { get; set; }
        public DateTime ApprovedDate { get; set; }
        public string RequestTime { get; set; }
        public string ApprovTime { get; set; }
        public string NoOfSeatRequired { get; set; }
        public string AgentId { get; set; }
        public int TravelDistance { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Remark { get; set; }
        public int Status { get; set; }

    }

    [Table("Mediagallery")]
    public class Mediagallery
    {
        [Key]
        public int Id { get; set; }
        public string Heading { get; set; }
        public string Summary { get; set; }
        public string Image { get; set; }
        [DataType(DataType.Date)]
        public DateTime Cdate { get; set; }
        public int status { get; set; }
    }

    [Table("popup")]
    public class popup
    {
        [Key]
        public int Id { get; set; }
        public string Heading { get; set; }
        public string Summary { get; set; }
        public string Image { get; set; }
        [DataType(DataType.Date)]
        public DateTime Cdate { get; set; }
        public int status { get; set; }
    }


    [Table("ProgramGallery")]
    public class ProgramGallery
    {
        [Key]
        public int Id { get; set; }
        public int programid { get; set; }
        public string Heading { get; set; }
        public string Summary { get; set; }
        public int Type { get; set; } //---- 1 Image or 2 Video -------
        public string Photo { get; set; }
        [AllowHtml]
        public string Video { get; set; }
        public DateTime Cdate { get; set; }
        public string opid { get; set; }
        public int status { get; set; }
    }

    [Table("DailyVisitorDetail")]
    public class DailyVisitorDetail
    {

        [Key]
        public int Id { get; set; }
        public string VisitorId { get; set; }
        public string VisitorName { get; set; }
        public string MeetToWhom { get; set; }
        public string Purpose { get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string ReceptionistId { get; set; }
        public string OfficeCode { get; set; }
        public string Type { get; set; }
        public string Remark { get; set; }
        public string feedback { get; set; }
        public DateTime feedbackDate { get; set; }
        public string feedbackTime { get; set; }
        public DateTime TodaysDate { get; set; }
        public int Status { get; set; }

    }

    [Table("DailyVisitor")]
    public class DailyVisitor
    {
        [Key]
        public int Id { get; set; }
        public string ReceptionistId { get; set; }
        public string ReceptionistName { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        public string CreaderBy { get; set; }
        public string OfficeCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }

    }

    /**/
    [Table("PC_Tab")]
    public class PC_Tab
    {
        [Key]
        public int Id { get; set; }
        public string userid { get; set; }
        public string PCId { get; set; }
        public string PCName { get; set; }
        [DataType(DataType.Date)]
        public DateTime addate { get; set; }
        public int status { get; set; }
    }

    [Table("spotcomm_tab")]
    public class spotcomm_tab
    {
        [Key]
        public int Id { get; set; }
        public int rankcode { get; set; }
        public int plancode { get; set; }
        public int year { get; set; }
        public Double commission { get; set; }
    }

    [Table("PhaseTab")]
    public class PhaseTab
    {
        [Key]
        public int Id { get; set; }
        public int projectid { get; set; }
        public string Phase { get; set; }
        public int status { get; set; }

    }

    [Table("BlockTab")]
    public class BlockTab
    {
        [Key]
        public int Id { get; set; }
        public int phaseid { get; set; }
        public string block { get; set; }
        public int min { get; set; }
        public int max { get; set; }
        public int status { get; set; }
        public int Plancode { get; set; }
        public string Planname { get; set; }
        public DateTime createdate { get; set; }
    }

    [Table("BookingTab")]
    public class BookingTab
    {
        [Key]
        public int Id { get; set; }
        public Double bookingrate { get; set; }
        public Double spotcomm { get; set; }
    }

    [Table("Blockdate")]
    public class Blockdate
    {
        [Key]
        public int Id { get; set; }
        public double Payment { get; set; }
        public double Fresh { get; set; }
        public double Renewal { get; set; }
        public double received { get; set; }
        public double member { get; set; }
        public double bankentry { get; set; }
        public double custfee { get; set; }
        public double agentfee { get; set; }
        public DateTime date { get; set; }
        public string branchcode { get; set; }
        public int status { get; set; }
    }

    [Table("ChangeAgentId")]
    public class ChangeAgentId
    {
        [Key]
        public int Id { get; set; }
        public int agencycode { get; set; }
        public string PreNewagentid { get; set; }
        public string CurrentNewagentid { get; set; }
        public string RankName { get; set; }
        public int RankCode { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }

    }

    [Table("MaturityStatus")]
    public class MaturityStatus
    {
        [Key]
        public int Id { get; set; }
        public int bondid { get; set; }
        public string newbondid { get; set; }
        public string name { get; set; }
        public int matstatus { get; set; }
        public int voucherstatus { get; set; }
        public int status { get; set; }
        public string newstatus { get; set; }
        public Double maturityamount { get; set; }
        [DataType(DataType.Date)]
        public DateTime maturitydate { get; set; }
        public string newintroducerid { get; set; }
        public string plantype { get; set; }
        public int plancode { get; set; }
        public string planname { get; set; }
        public Double term { get; set; }
        public string mode { get; set; }
        public Double totalcon { get; set; }
        public string paymethod { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> pdate { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> chequedate { get; set; }
        public string checkorddno { get; set; }
        public string drawno { get; set; }
        public string branchpay { get; set; }
        [DataType(DataType.Date)]
        public DateTime exptdate { get; set; }
    }

    [Table("MaturityDocument")]
    public class MaturityDocument
    {
        [Key]
        public int Id { get; set; }
        public string NewBondId { get; set; }
        public int BondId { get; set; }
        public string Remark { get; set; }
        public string branchcode { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
    }

    [Table("AdvBrokerPaymentTab")]
    public class AdvBrokerPaymentTab
    {
        [Key]
        public int Id { get; set; }
        public string newagentid { get; set; }
        public Double amount { get; set; }
        public string Remark { get; set; }
        public string branchcode { get; set; }
        public string opid { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public int type { get; set; }
        public Double returnamount { get; set; }
        public Double balanceamount { get; set; }
    }

    [Table("AdvDeductionVoucher")]
    public class AdvDeductionVoucher
    {
        [Key]
        public int Id { get; set; }
        public string newagentid { get; set; }
        public Double amount { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public string Remark { get; set; }

    }

    [Table("AgentDetail")]
    public class AgentDetail
    {
        public string BranchCode { get; set; }
        public string name { get; set; }
        public string Father { get; set; }
        public string Mother { get; set; }
        public string Gender { get; set; }
        public string NewIntroducerId { get; set; }
        public int IntroducerCode { get; set; }
        public string IntroName { get; set; }
        public int RankCode { get; set; }
        public string RankName { get; set; }
        public string Nationality { get; set; }
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }
        public string Age { get; set; }
        public string BloodGroup { get; set; }
        public string Occupation { get; set; }
        public string Qualification { get; set; }
        public string Panno { get; set; }
        public string Passportno { get; set; }
        public string Drivinglno { get; set; }
        public string Icardno { get; set; }
        [DataType(DataType.Date)]
        public DateTime Issueon { get; set; }
        [DataType(DataType.Date)]
        public DateTime Validupto { get; set; }
        public string BankName { get; set; }
        public string BankCode { get; set; }
        public string BankAccountno { get; set; }
        public string IFCCode { get; set; }
        public string BankAddress { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public string Landlineno { get; set; }
        public string Mobileno { get; set; }
        public string Email { get; set; }
        public string NomineeName { get; set; }
        public string NomineeAge { get; set; }
        public string Relationship { get; set; }
        public string NomineeAddress { get; set; }
        public string Organization { get; set; }
        [DataType(DataType.Date)]
        public DateTime Doj { get; set; }
        [DataType(DataType.Date)]
        public DateTime activationdate { get; set; }
        [Key]
        public int AgencyCode { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public string NewAgentId { get; set; }
        public string Company { get; set; }
        public string Mobile { get; set; }
        public int Yoe { get; set; }
        public string Experience { get; set; }
        public int Suffix { get; set; }
        public string UnitCode { get; set; }
        public string Type { get; set; }
        public int Status { get; set; }
        public string areaofoccupation { get; set; }
        public string approximatenoofactive { get; set; }
        public Double formfee { get; set; }
        public string operatorid { get; set; }
        public string cmpnyaddress { get; set; }
        public string Macaddress { get; set; }
        public string Time { get; set; }
        public int memberid { get; set; }
        public string newmemberid { get; set; }

        [DataType(DataType.Date)]
        public DateTime PAN_ReqDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime PAN_AppDate { get; set; }
        public int PanStatus { get; set; }
        [DataType(DataType.Date)]
        public DateTime Aadhaar_ReqDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime Aadhaar_AppDate { get; set; }
        public string Aadhaar_No { get; set; }
        public int Aadhaar_status { get; set; }

        /*-------------------17-07-2018-----------------------*/
        public string BankBranchName { get; set; }
        public Int64 OtherMobile { get; set; }
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string CompanyAddress { get; set; }
        [NotMapped]
        public byte[] CompanyLogo { get; set; }
        public string refno { get; set; }
        public string spilid { get; set; }
        public int position { get; set; }
        public int uid { get; set; }
        public int kyc_status { get; set; }
        public string AccountHolder { get; set; }
        public string AccountType { get; set; }
        public string bank_img { get; set; }
        public string pan_img { get; set; }
        public string aadhaar_img { get; set; }
        public int paidstatus { get; set; }
    }

    [Table("Formdate")]
    public class Formdate
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime formdate { get; set; }
        public string branchcode { get; set; }
        public string opid { get; set; }
        public int status { get; set; }
    }

    [Table("appltab")]
    public class appltab
    {
        [Key]
        public int Id { get; set; }
        public int bondid { get; set; }
        public string branchcode { get; set; }
        public string newbondid { get; set; }
        public string name { get; set; }
        public string RelationOf { get; set; }
        public string fathername { get; set; }
        public string addr { get; set; }
        public string mobileno { get; set; }
        public int introducerid { get; set; }
        public string newintroducerid { get; set; }
        public int intrankcode { get; set; }
        public string intrankname { get; set; }
        [DataType(DataType.Date)]
        public DateTime formdate { get; set; }
        [DataType(DataType.Date)]
        public DateTime dob { get; set; }
        public string age { get; set; }
        public string nationality { get; set; }

        public string guardianname { get; set; }
        public string gurage { get; set; }
        public string gurrel { get; set; }
        public string guraddr { get; set; }
        public string photo { get; set; }

        public string panno { get; set; }
        public string bankname { get; set; }
        public string accountno { get; set; }

        public string plantype { get; set; }
        public int plancode { get; set; }
        public string planname { get; set; }
        public Double term { get; set; }
        public string mode { get; set; }
        public Double payment { get; set; }
        public Double nolandunit { get; set; }
        public Double totalcon { get; set; }
        public Double expectedraisablevalue { get; set; }
        public Double applicationcharge { get; set; }
        public Double bonusper { get; set; }
        [DataType(DataType.Date)]
        public DateTime expirydate { get; set; }

        public string nomineename { get; set; }
        public string nomage { get; set; }
        public string nomrel { get; set; }
        public string nomaddr { get; set; }

        public string paymethod { get; set; }
        [DataType(DataType.Date)]
        public DateTime pdate { get; set; }
        public string checkorddno { get; set; }
        public string drawno { get; set; }
        public string branchpay { get; set; }
        public string amountword { get; set; }
        public string opid { get; set; }
        public int status { get; set; }
        public string type { get; set; }
        public string Macaddress { get; set; }
        public string Time { get; set; }
        public int memberid { get; set; }
        public string newmemberid { get; set; }
        public string IFSC { get; set; }
        public Double discountper { get; set; }
        public Double bookingamount { get; set; }
        public Double downpayment { get; set; }
        public int plotno { get; set; }
        public string PYN { get; set; }
        public int projectid { get; set; }
        public string block { get; set; }
        public int phaseid { get; set; }
        public int printstatus { get; set; }

        public string bank { get; set; }
        public string Account { get; set; }
        public string chequeno { get; set; }
        public string ACholdername { get; set; }
        public string Branch { get; set; }
        public string IFSCCode { get; set; }
        public string ChequeAmount { get; set; }
        [DataType(DataType.Date)]
        public DateTime Chequedate { get; set; }
        public string Chequeimage { get; set; }
        [DataType(DataType.Date)]
        public DateTime chequeappdate { get; set; }
        public string transactiontype { get; set; }

        [DataType(DataType.Date)]
        public DateTime PAN_ReqDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime PAN_AppDate { get; set; }
        public int PanStatus { get; set; }
        [DataType(DataType.Date)]
        public DateTime Aadhaar_ReqDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime Aadhaar_AppDate { get; set; }
        public string Aadhaar_No { get; set; }
        public int Aadhaar_status { get; set; }
        public string paymenttype { get; set; }
        /*-----------------------------------------------------*/
        public string propertyaddress { get; set; }
        public string propertypreference { get; set; }
        public Double plccost { get; set; }
        public string refno { get; set; }
        public int propertyid { get; set; }
        public string loanid { get; set; }
        /*-----------------------------------------------------*/
        public string propertytype { get; set; }
        public string incomegroup { get; set; }
        public string phase { get; set; }
        public string plotdesp { get; set; }
        public string northwest { get; set; }
        public string northeast { get; set; }
        public string southwest { get; set; }
        public string southeast { get; set; }
        /*-----------------------------------------------------*/
        public string sapplicantname { get; set; }
        public string sfathername { get; set; }
        public string smothername { get; set; }
        public string scategory { get; set; }
        public string scorraddress { get; set; }
        public string spermanentaddress { get; set; }
        public string scity { get; set; }
        public string sstate { get; set; }
        public int spincode { get; set; }
        public string snationality { get; set; }
        public string squalification { get; set; }
        public string smobileno { get; set; }
        public string salternatemobileno { get; set; }
        public string semailid { get; set; }
        public string sdob { get; set; }
        public string spanno { get; set; }
        public string saadharno { get; set; }
        public string smaritialstatus { get; set; }
        public string sanniversarydate { get; set; }
        public string soccupation { get; set; }
        public string spassport { get; set; }
        public string sresidentialstatus { get; set; }
        public string sphoto { get; set; }
        public string saadharphoto { get; set; }
        public string spanphoto { get; set; }
        public int uid { get; set; }
        public int paidstatus { get; set; }
    }

    [Table("BrokerCommList")]
    public class BrokerCommList
    {
        public int ID { get; set; }
        public int agencycode { get; set; }
        public string newagentid { get; set; }
        public string name { get; set; }
        public int introducerid { get; set; }
        public string newintroducerid { get; set; }
        public string Introname { get; set; }
        public int rankcode { get; set; }
        public string rankname { get; set; }
        public string mobile { get; set; }
        public string branchcode { get; set; }
        public string panno { get; set; }
        public int status { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public string month { get; set; }
        public int Year { get; set; }
    }

    [Table("Bond_report")]
    public class Bond_report
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string RelationOf { get; set; }
        public string FathersName { get; set; }
        public int introducerid { get; set; }
        public string addr { get; set; }
        public string age { get; set; }
        public int plancode { get; set; }
        public string planname { get; set; }
        public Double landunit { get; set; }
        public Double term { get; set; }
        public Double total_con { get; set; }
        public Double payment { get; set; }
        public string mode { get; set; }
        public Double expected_value { get; set; }
        public string nominee_name { get; set; }
        public string nominee_age { get; set; }
        public string nominee_rel { get; set; }

        public string newbondid { get; set; }
        public string amount_word { get; set; }
        public string formdate { get; set; }
        public string branchcode { get; set; }
        public string expiry { get; set; }
        public string district { get; set; }

        public string nxt_due { get; set; }
        public string newitroducerid { get; set; }
        public string unitid { get; set; }
        public string receipt_no { get; set; }
        public string intro { get; set; }
        public string modeofpay { get; set; }
        public string last_installment { get; set; }
        public int Bondid { get; set; }
        public string branchaddress { get; set; }
        public string agentname { get; set; }
        public string introducername { get; set; }
        public int upintroducerid { get; set; }
        public string upnewintroducerid { get; set; }
        public string upintroducername { get; set; }

        public string branch_name { get; set; }
        public string mobileno { get; set; }
        public int cssno { get; set; }
        public Double bookingamount { get; set; }
        public Double advancepayment { get; set; }

    }

    [Table("bonus_tab")]
    public class bonus_tab
    {
        [Key]
        public int Id { get; set; }
        public string agentcode { get; set; }
        [DataType(DataType.Date)]
        public DateTime formonth { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public string type { get; set; }
        public Double bonusamount { get; set; }
    }

    [Table("branchlogindetail")]
    public class branchlogindetail
    {
        [Key]
        public int Id { get; set; }
        public string iid { get; set; }
        public string password { get; set; }
        [DataType(DataType.Date)]
        public DateTime indatetime { get; set; }
        [DataType(DataType.Date)]
        public DateTime outdatetime { get; set; }
    }

    [Table("Branchtab")]
    public class Branchtab
    {
        [Key]
        public int Id { get; set; }
        public string prefix { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }
        public string BranchDistrict { get; set; }
        public string branchaddress { get; set; }
        public string password { get; set; }
        public string mobile { get; set; }
        public string type { get; set; }
        public int status { get; set; }
        public string companyid { get; set; }


    }

    [Table("calculator")]
    public class calculator
    {
        [Key]
        public int Id { get; set; }
        public Double amount { get; set; }
        [DataType(DataType.Date)]
        public DateTime dateofcollection { get; set; }
        public string opid { get; set; }
        public string dispatch { get; set; }

    }

    [Table("Cancel_Receipt")]
    public class Cancel_Receipt
    {
        [Key]
        public int Id { get; set; }
        public Double amount { get; set; }
        public Double payamount { get; set; }
        public int bondid { get; set; }
        public Double latefine { get; set; }
        public Double reliefrs { get; set; }
        [DataType(DataType.Date)]
        public DateTime expirydate { get; set; }
        [DataType(DataType.Date)]
        public DateTime paymentdate { get; set; }
        [DataType(DataType.Date)]
        public DateTime prevexpirydate { get; set; }
        public int year { get; set; }
        public int cssno { get; set; }
        public int installmentno { get; set; }
        public string receiptno { get; set; }
        public string planname { get; set; }
        public Double term { get; set; }
        public string mode { get; set; }
        public string paymethod { get; set; }
        public string chekddno { get; set; }
        public string drawno { get; set; }
        public string branch { get; set; }
        public string amountinword { get; set; }
        public string newbondid { get; set; }
        public string opid { get; set; }
        public string Macaddress { get; set; }
        public string Time { get; set; }
        public int paymentno { get; set; }
    }

    [Table("CityStateTab")]
    public class CityStateTab
    {
        [Key]
        public int Id { get; set; }
        public string state { get; set; }
        public string city { get; set; }

    }

    [Table("comm_tab")]
    public class comm_tab
    {
        [Key]
        public int Id { get; set; }
        public int rankcode { get; set; }
        public int plancode { get; set; }
        public int year { get; set; }
        public Double commission { get; set; }
    }

    [Table("commission_tab")]
    public class commission_tab
    {
        [Key]
        public int Id { get; set; }
        public int agentid { get; set; }
        public string newagentid { get; set; }
        public string name { get; set; }
        public int rankcode { get; set; }
        public string rankname { get; set; }
        public int introducerid { get; set; }
        public string newintroducerid { get; set; }
        public string branchcode { get; set; }
        public string mobileno { get; set; }
        public string panno { get; set; }
        public string bondname { get; set; }
        [DataType(DataType.Date)]
        public DateTime bonddate { get; set; }
        public Double amount { get; set; }
        public Double commission { get; set; }
        public string planname { get; set; }
        public int plancode { get; set; }
        public int bondid { get; set; }
        public string newbondid { get; set; }
        public string newrenew { get; set; }
        public int type { get; set; }
        public Double year { get; set; }
        public int cssno { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public Double percentage { get; set; }
        public int bondintroducerid { get; set; }
        public string receiptno { get; set; }
        public string comtype { get; set; }
    }

    [Table("CompanyInfo")]
    public class CompanyInfo
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
        public string Companysrtcut { get; set; }
        public string HeadOffice { get; set; }
        public string AdminId { get; set; }
        public string Password { get; set; }
        public string RegistrationNo { get; set; }
        public string Contact { get; set; }
        public string Emailid { get; set; }
        public string Address { get; set; }
        public string IncomeType { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string DirectorName { get; set; }
        [DataType(DataType.Date)]
        public DateTime RegDate { get; set; }
        public string Status { get; set; }
        public double emiamount { get; set; }
        [DataType(DataType.Date)]
        public DateTime duedate { get; set; }
    }

    [Table("Contact")]
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string emailid { get; set; }
        public string mobile { get; set; }
        public string subject { get; set; }
        public string message { get; set; }

    }

    [Table("delete_bond")]
    public class delete_bond
    {
        [Key]
        public int Id { get; set; }
        public int bondid { get; set; }
        public string branchcode { get; set; }
        public string newbondid { get; set; }
        public string name { get; set; }
        public string RelationOf { get; set; }
        public string fathername { get; set; }
        public string addr { get; set; }
        public string mobileno { get; set; }
        public int introducerid { get; set; }
        public string newintroducerid { get; set; }
        public int intrankcode { get; set; }
        public string intrankname { get; set; }
        [DataType(DataType.Date)]
        public DateTime formdate { get; set; }
        [DataType(DataType.Date)]
        public DateTime dob { get; set; }
        public string age { get; set; }
        public string nationality { get; set; }

        public string guardianname { get; set; }
        public int gurage { get; set; }
        public string gurrel { get; set; }
        public string guraddr { get; set; }
        public string photo { get; set; }

        public string panno { get; set; }
        public string bankname { get; set; }
        public string accountno { get; set; }

        public string plantype { get; set; }
        public int plancode { get; set; }
        public string planname { get; set; }
        public Double term { get; set; }
        public string mode { get; set; }
        public Double payment { get; set; }
        public Double nolandunit { get; set; }
        public int totalcon { get; set; }
        public int expectedraisablevalue { get; set; }
        public Double applicationcharge { get; set; }
        public Double bonusper { get; set; }
        [DataType(DataType.Date)]
        public DateTime expirydate { get; set; }

        public string nomineename { get; set; }
        public string nomage { get; set; }
        public string nomrel { get; set; }
        public string nomaddr { get; set; }

        public string paymethod { get; set; }
        [DataType(DataType.Date)]
        public DateTime pdate { get; set; }
        public string checkorddno { get; set; }
        public string drawno { get; set; }
        public string branchpay { get; set; }
        public string amountword { get; set; }
        public string opid { get; set; }
        public int status { get; set; }
        public string type { get; set; }
        public string Macaddress { get; set; }
        public string Time { get; set; }

    }

    [Table("DocumentTab")]
    public class DocumentTab
    {
        [Key]
        public int Id { get; set; }
        public string memberid { get; set; }
        public string document { get; set; }
        public string information { get; set; }
        public string type { get; set; }


    }

    [Table("DuplicateTab")]
    public class DuplicateTab
    {
        [Key]
        public int Id { get; set; }
        public string newbondid { get; set; }
        public Double payamount { get; set; }
        public int paymentno { get; set; }
        public string opid { get; set; }
        public DateTime date { get; set; }
        public string macaddress { get; set; }
        public string type { get; set; }

    }

    [Table("Emp_atten")]
    public class Emp_atten
    {
        [Key]
        public int Id { get; set; }
        public string empid { get; set; }
        public string name { get; set; }
        public string branchcode { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public string atten { get; set; }
    }

    [Table("Emp_leave")]
    public class Emp_leave
    {
        [Key]
        public int Id { get; set; }
        public string empid { get; set; }
        public string branchcode { get; set; }
        [DataType(DataType.Date)]
        public DateTime sdate { get; set; }
        [DataType(DataType.Date)]
        public DateTime edate { get; set; }
        public string reason { get; set; }
        public string leavetype { get; set; }
        public int status { get; set; }
    }

    [Table("Emp_Reg")]
    public class Emp_Reg
    {
        [Key]
        public int Id { get; set; }
        public string empid { get; set; }
        public string name { get; set; }
        public string father { get; set; }
        public string department { get; set; }
        public string designation { get; set; }
        public Double basicsalary { get; set; }
        public string gender { get; set; }
        public string mob { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        [DataType(DataType.Date)]
        public DateTime dob { get; set; }
        [DataType(DataType.Date)]
        public DateTime doj { get; set; }
        public string img { get; set; }
        public string cv { get; set; }
        public string branchcode { get; set; }


    }

    [Table("Emp_Salary")]
    public class Emp_Salary
    {
        [Key]
        public int Id { get; set; }
        public string empid { get; set; }
        public string month { get; set; }
        public int year { get; set; }
        public string branchcode { get; set; }
        public string opid { get; set; }
        [DataType(DataType.Date)]
        public DateTime doj { get; set; }
        public double HRA { get; set; }
        public double DA { get; set; }
        public double CCA { get; set; }
        public double TA { get; set; }
        public double medical { get; set; }
        public double advance_Pay { get; set; }
        public double professionaltax { get; set; }
        public double loan { get; set; }
        public double provisional_fund { get; set; }
    }

    [Table("Expense")]
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        public string head { get; set; }
        public string Remark { get; set; }
        public Double amount { get; set; }
        [DataType(DataType.Date)]
        public DateTime date_time { get; set; }
        public string branchcode { get; set; }
        public string opid { get; set; }
        public int type { get; set; }
        //-------Paymethod
        public string paymethod { get; set; }
        public string bank { get; set; }
        public string Account { get; set; }
        public string chequeno { get; set; }
        public string ACholdername { get; set; }
        public string Branch { get; set; }
        public string IFSCCode { get; set; }
        public string ChequeAmount { get; set; }
        [DataType(DataType.Date)]
        public DateTime Chequedate { get; set; }
        public string Chequeimage { get; set; }
        public string transactiontype { get; set; }
    }

    [Table("Fixed_Tab")]
    public class Fixed_Tab
    {
        [Key]
        public int Id { get; set; }
        public int Plancode { get; set; }
        public string Planname { get; set; }
        public float Term { get; set; }
        public int Plotsize { get; set; }
        public int Amount { get; set; }
        public double EstimatedValue { get; set; }
        public double Accidental { get; set; }
        public string type { get; set; }
    }

    [Table("HeadTab")]
    public class HeadTab
    {
        [Key]
        public int Id { get; set; }
        public string head { get; set; }
    }

    [Table("HRTab")]
    public class HRTab
    {
        [Key]
        public int Id { get; set; }
        public string HRName { get; set; }
        public string HRId { get; set; }
        public string BranchCode { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string emailid { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public string Type { get; set; }
        public int Status { get; set; }
        public string companyid { get; set; }

    }

    [Table("hrlogin_detail")]
    public class hrlogin_detail
    {
        [Key]
        public int Id { get; set; }
        public string iid { get; set; }
        public string password { get; set; }
        [DataType(DataType.Date)]
        public DateTime indatetime { get; set; }
        [DataType(DataType.Date)]
        public DateTime outdatetime { get; set; }
    }

    [Table("ICardTab")]
    public class ICardTab
    {
        [Key]
        public int Id { get; set; }
        public int agentid { get; set; }
        public string name { get; set; }
        public string rankname { get; set; }
        public string intid { get; set; }
        public string intname { get; set; }
        public string intrankname { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string dob { get; set; }
        public string mobno { get; set; }
        [DataType(DataType.Date)]
        public DateTime issuedate { get; set; }
        [DataType(DataType.Date)]
        public DateTime validupto { get; set; }
        public string companylogo { get; set; }
        public string photo { get; set; }
        public Byte logo { get; set; }
        public Byte image { get; set; }

    }

    [Table("InOutTime")]
    public class InOutTime
    {
        [Key]
        public int Id { get; set; }
        public string login { get; set; }
        public string logout { get; set; }
        public int status { get; set; }

    }

    [Table("Installmenttab")]
    public class Installmenttab
    {
        [Key]
        public int Id { get; set; }
        public Double amount { get; set; }
        public Double payamount { get; set; }
        public int bondid { get; set; }
        public Double latefine { get; set; }
        [DataType(DataType.Date)]
        public DateTime expirydate { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> paymentdate { get; set; }
        public Double reliefrs { get; set; }
        [DataType(DataType.Date)]
        public DateTime prevexpirydate { get; set; }
        public int year { get; set; }
        public Nullable<int> cssno { get; set; }
        public int installmentno { get; set; }
        public string receiptno { get; set; }
        public string planname { get; set; }
        public Double term_plan { get; set; }
        public string mode { get; set; }
        public string paymethod { get; set; }
        public string chekddno { get; set; }
        public string drawno { get; set; }
        public string branch { get; set; }
        public string amountinword { get; set; }
        public string newbondid { get; set; }
        public string opid { get; set; }
        public string Macaddress { get; set; }
        public string Time { get; set; }
        public int paymentno { get; set; }
        public string type { get; set; }
        public Double revivalfee { get; set; }
        public string plantype { get; set; }

        public string bank { get; set; }
        public string Account { get; set; }
        public string chequeno { get; set; }
        public string ACholdername { get; set; }
        public string Bbranch { get; set; }
        public string IFSCCode { get; set; }
        public string ChequeAmount { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Chequedate { get; set; }
        public string Chequeimage { get; set; }
        public Double Penality { get; set; }
        [DataType(DataType.Date)]
        public DateTime chequeappdate { get; set; }
        public string transactiontype { get; set; }
        public int uid { get; set; }
        public int paidstatus { get; set; }
    }


    [Table("MISInstallmenttab")]
    public class MISInstallmenttab
    {
        [Key]
        public int Id { get; set; }
        public Double amount { get; set; }
        public Double payamount { get; set; }
        public int bondid { get; set; }
        public Double latefine { get; set; }
        [DataType(DataType.Date)]
        public DateTime expirydate { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> paymentdate { get; set; }
        public Double reliefrs { get; set; }
        [DataType(DataType.Date)]
        public DateTime prevexpirydate { get; set; }
        public int year { get; set; }
        public Nullable<int> cssno { get; set; }
        public int installmentno { get; set; }
        public string receiptno { get; set; }
        public string planname { get; set; }
        public Double term_plan { get; set; }
        public string mode { get; set; }
        public string paymethod { get; set; }
        public string chekddno { get; set; }
        public string drawno { get; set; }
        public string branch { get; set; }
        public string amountinword { get; set; }
        public string newbondid { get; set; }
        public string opid { get; set; }
        public string Macaddress { get; set; }
        public string Time { get; set; }
        public int paymentno { get; set; }
        public string type { get; set; }
        public Double revivalfee { get; set; }
        public string plantype { get; set; }

        public string bank { get; set; }
        public string Account { get; set; }
        public string chequeno { get; set; }
        public string ACholdername { get; set; }
        public string Bbranch { get; set; }
        public string IFSCCode { get; set; }
        public string ChequeAmount { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Chequedate { get; set; }
        public string Chequeimage { get; set; }
        public Double Penality { get; set; }
        [DataType(DataType.Date)]
        public DateTime chequeappdate { get; set; }
        public string transactiontype { get; set; }
        public int uid { get; set; }
    }

    [Table("MacTab")]
    public class MacTab
    {
        [Key]
        public int Id { get; set; }
        public string userid { get; set; }
        public string macaddress { get; set; }
        public string type { get; set; }
        public int status { get; set; }
    }

    [Table("DupliMacTab")]
    public class DupliMacTab
    {
        [Key]
        public int Id { get; set; }
        public string userid { get; set; }
        public string macaddress { get; set; }
        public string type { get; set; }
        public int status { get; set; }
    }

    [Table("MaturityTab")]
    public class MaturityTab
    {
        [Key]
        public int Id { get; set; }
        public int bondid { get; set; }
        public string branchcode { get; set; }
        public string newbondid { get; set; }
        public string name { get; set; }
        public string RelationOf { get; set; }
        public string fathername { get; set; }
        public string addr { get; set; }
        public string mobileno { get; set; }
        public int introducerid { get; set; }
        public string newintroducerid { get; set; }
        public int intrankcode { get; set; }
        public string intrankname { get; set; }
        [DataType(DataType.Date)]
        public DateTime formdate { get; set; }
        [DataType(DataType.Date)]
        public DateTime dob { get; set; }
        public string age { get; set; }
        public string nationality { get; set; }

        public string guardianname { get; set; }
        public string gurage { get; set; }
        public string gurrel { get; set; }
        public string guraddr { get; set; }
        public string photo { get; set; }

        public string panno { get; set; }
        public string bankname { get; set; }
        public string accountno { get; set; }

        public string plantype { get; set; }
        public int plancode { get; set; }
        public string planname { get; set; }
        public Double term { get; set; }
        public string mode { get; set; }
        public Double payment { get; set; }
        public Double nolandunit { get; set; }
        public Double totalcon { get; set; }
        public Double expectedraisablevalue { get; set; }
        public Double applicationcharge { get; set; }
        public Double bonusper { get; set; }
        [DataType(DataType.Date)]
        public DateTime expirydate { get; set; }

        public string nomineename { get; set; }
        public string nomage { get; set; }
        public string nomrel { get; set; }
        public string nomaddr { get; set; }

        public string paymethod { get; set; }
        [DataType(DataType.Date)]
        public DateTime pdate { get; set; }
        public string checkorddno { get; set; }
        public string drawno { get; set; }
        public string branchpay { get; set; }
        public string amountword { get; set; }
        public string opid { get; set; }
        public int status { get; set; }
        public Double maturityamount { get; set; }
        public Double pendingamount { get; set; }
        public Double extraamount { get; set; }
        public Double commamount { get; set; }
        public string maturitytype { get; set; }
        public string type { get; set; }
        public string Macaddress { get; set; }
        public string Time { get; set; }
        [DataType(DataType.Date)]
        public DateTime maturitydate { get; set; }
    }

    [Table("Member")]
    public class Member
    {
        [Key]
        public int Id { get; set; }
        public string branchname { get; set; }
        public string planname { get; set; }
        public string agentname { get; set; }
        public string custname { get; set; }
        public string rankname { get; set; }
        public string type { get; set; }

    }

    [Table("MIPP_tab")]
    public class MIPP_tab
    {
        [Key]
        public int Id { get; set; }
        public int plancode { get; set; }
        public string planname { get; set; }
        public Double term { get; set; }
        public Double plotsize { get; set; }
        public Double amount { get; set; }
        public Double Yearly { get; set; }
        public Double FiveERV { get; set; }
        public Double SevenERV { get; set; }
        public Double TenERV { get; set; }
        public string type { get; set; }
    }

    [Table("NewLogin")]
    public class NewLogin
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "User name")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string type { get; set; }
        public int status { get; set; }

    }

    [Table("NewPlan")]
    public class NewPlan
    {
        [Key]
        public int Plancode { get; set; }
        public string Planname { get; set; }
        public float Term { get; set; }
        public int mlyinstall { get; set; }
        public int qlyinstall { get; set; }
        public int hlyinstall { get; set; }
        public int ylyinstall { get; set; }
        public string Type { get; set; }
        public int revivaltime { get; set; }
        public int status { get; set; }
        public Double bookingrate { get; set; }
    }

    [Table("Operator")]
    public class Operator
    {
        [Key]
        public int Id { get; set; }
        public string OperatorName { get; set; }
        public string OperatorId { get; set; }
        public string BranchCode { get; set; }
        public string OperatorPassword { get; set; }
        public string OperatorMobile { get; set; }
        public string OperatorAddress { get; set; }
        public string Type { get; set; }
        public int Status { get; set; }
        [DataType(DataType.Date)]
        public DateTime Cdate { get; set; }
        public string Operator_Mail { get; set; }
        public string companyid { get; set; }

    }

    [Table("operatorlogin_detail")]
    public class operatorlogin_detail
    {
        [Key]
        public int Id { get; set; }
        public string iid { get; set; }
        public string password { get; set; }
        [DataType(DataType.Date)]
        public DateTime indatetime { get; set; }
        [DataType(DataType.Date)]
        public DateTime outdatetime { get; set; }
    }

    [Table("Plan")]
    public class Plan
    {
        [Key]
        public int Plancode { get; set; }
        public string Planname { get; set; }
        public string shortcutname { get; set; }
        public string type { get; set; }
        public int status { get; set; }
    }

    [Table("ProTerm")]
    public class ProTerm
    {
        [Key]
        public int Id { get; set; }
        public int projectid { get; set; }
        public string projectname { get; set; }
        public Double term { get; set; }
        public int status { get; set; }
    }

    [Table("RateTab")]
    public class RateTab
    {
        [Key]
        public int Id { get; set; }
        public int projectid { get; set; }
        public string projectname { get; set; }
        public Double term { get; set; }
        public Double plotcost { get; set; }
        public Double plotsize { get; set; }
        public int noi { get; set; }
        public int status { get; set; }
        public Double quotaper { get; set; }
        public string shortcutname { get; set; }
    }

    [Table("PlotLimit")]
    public class PlotLimit
    {
        [Key]
        public int Id { get; set; }
        public int projectid { get; set; }
        public string projectname { get; set; }
        public int minvalue { get; set; }
        public int maxvalue { get; set; }
        public int status { get; set; }
    }

    [Table("Pension_Tab")]
    public class Pension_Tab
    {
        [Key]
        public int Id { get; set; }
        public int Plancode { get; set; }
        public string Planname { get; set; }
        public float Term { get; set; }
        public int Plotsize { get; set; }
        public int Amount { get; set; }
        public double Monthly { get; set; }
        public double Quarterly { get; set; }
        public double Halfyearly { get; set; }
        public double Yearly { get; set; }
        public double Profit { get; set; }
        public double EstimatedValue { get; set; }
        public string type { get; set; }

    }

    [Table("PlanTab")]
    public class PlanTab
    {
        [Key]
        public int Plancode { get; set; }
        public string Planname { get; set; }
        public int Plotsize { get; set; }
        public Double Term { get; set; }
        public string mode { get; set; }
        public double Minvalue { get; set; }
        public double Maxvalue { get; set; }
        public double Multiple { get; set; }
        public double MaturityPercent { get; set; }
        public string PercentType { get; set; }
        public double BonusPercent { get; set; }
        public int Installments { get; set; }
        public string Type { get; set; }

    }

    [Table("Plan_Tab")]
    public class Plan_Tab
    {
        [Key]
        public int Id { get; set; }
        public int Plancode { get; set; }
        public string Planname { get; set; }
        public float Term { get; set; }
        public int Plotsize { get; set; }
        public int Amount { get; set; }
        public double Monthly { get; set; }
        public double Quarterly { get; set; }
        public double Halfyearly { get; set; }
        public double Yearly { get; set; }
        public double EstimatedValue { get; set; }
        public double Accidental { get; set; }
        public string type { get; set; }
    }

    [Table("Ranktab")]
    public class Ranktab
    {
        [Key]
        public int RankCode { get; set; }
        public string RankName { get; set; }
        public string Rankshrtcut { get; set; }
        public double TeamQuota { get; set; }
        public double Selfquota { get; set; }

    }

    [Table("RecieptTab")]
    public class RecieptTab
    {
        [Key]
        public int Id { get; set; }
        public string newbondid { get; set; }
        public string branchname { get; set; }
        public string branchaddress { get; set; }
        public string branchcode { get; set; }
        public int cssno { get; set; }
        public int paymentno { get; set; }
        public string ledgerfolio { get; set; }
        public string installmentno { get; set; }
        public string receiptno { get; set; }
        public string date { get; set; }
        public string duedate { get; set; }
        public string nextduedate { get; set; }
        public string expirydate { get; set; }

        public string name { get; set; }
        public string father { get; set; }
        public string relation { get; set; }
        public string age { get; set; }
        public string address { get; set; }

        public string dateofcommencement { get; set; }
        public Double totalconsideration { get; set; }
        public Double maturityamount { get; set; }
        public int yearsubscrib { get; set; }
        public string unitcode { get; set; }

        public string planname { get; set; }
        public Double term { get; set; }
        public Double landunit { get; set; }
        public string mode { get; set; }
        public Double amount { get; set; }
        public string agencycode { get; set; }
        public Double payamount { get; set; }
        public string paymethod { get; set; }
        public Double othercharge { get; set; }
        public string amountinwords { get; set; }
        public string opid { get; set; }
        public string Bank { get; set; }
        public string Chequeno { get; set; }
        public string Account { get; set; }
        public string Acholdername { get; set; }
        public string Bankbranch { get; set; }
        public string IFSCcode { get; set; }
        public Double ChequeAmount { get; set; }
        public DateTime ChequeDate { get; set; }
        public byte[] ChequeImage { get; set; }
        public DateTime ChequeAppDate { get; set; }
        public string Chequeimg { get; set; }
        public string Transactiontype { get; set; }
    }

    [Table("relation")]
    public class relation
    {
        [Key]
        public int Id { get; set; }
        public string relations { get; set; }

    }

    [Table("ReleaseTab")]
    public class ReleaseTab
    {
        [Key]
        public int id { get; set; }
        public DateTime Releasedate { get; set; }
        public string year { get; set; }
        public int month { get; set; }

    }

    [Table("Salary_em")]
    public class Salary_em
    {
        [Key]
        public int Id { get; set; }
        public string empid { get; set; }
        public string month { get; set; }
        public int year { get; set; }

        public string name { get; set; }
        public string designation { get; set; }
        public string department { get; set; }
        public double basicsalary { get; set; }
        [DataType(DataType.Date)]
        public DateTime doj { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }

        public string img { get; set; }
        public double HRA { get; set; }
        public double DA { get; set; }
        public double CCA { get; set; }
        public double TA { get; set; }
        public double medical { get; set; }
        public double advance_Pay { get; set; }
        public double professionaltax { get; set; }
        public double loan { get; set; }
        public double provisional_fund { get; set; }
        public double grossincentive { get; set; }
        public double deductionamount { get; set; }
        public double netsalary { get; set; }
    }

    [Table("SalaryTab")]
    public class SalaryTab
    {
        [Key]
        public int Id { get; set; }
        public int Rank { get; set; }
        public Double Salary { get; set; }
        public Double Insurance { get; set; }
        public Double Bonuspercent { get; set; }
        public int plancode { get; set; }
        public Double planyear { get; set; }

    }

    [Table("SchemeTab")]
    public class SchemeTab
    {
        [Key]
        public int Id { get; set; }
        public string msg { get; set; }
        public string type { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }

    }

    [Table("SetMacTab")]
    public class SetMacTab
    {
        [Key]
        public int Id { get; set; }
        public int status { get; set; }
    }

    [Table("spotcommission_tab")]
    public class spotcommission_tab
    {
        [Key]
        public int Id { get; set; }
        public int agentid { get; set; }
        public string newagentid { get; set; }
        public string name { get; set; }
        public int rankcode { get; set; }
        public string rankname { get; set; }
        public int introducerid { get; set; }
        public string newintroducerid { get; set; }
        public string branchcode { get; set; }
        public string mobileno { get; set; }
        public string bondname { get; set; }
        [DataType(DataType.Date)]
        public DateTime bonddate { get; set; }
        public Double amount { get; set; }
        public Double commissionper { get; set; }
        public Double commission { get; set; }
        public string planname { get; set; }
        public int plancode { get; set; }
        public int bondid { get; set; }
        public string newbondid { get; set; }
        public string newrenew { get; set; }
        public int type { get; set; }
        public int cssno { get; set; }
        public Double year { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public string receiptno { get; set; }
        public int status { get; set; }

    }

    [Table("SpotCommTab")]
    public class SpotCommTab
    {
        [Key]
        public int Id { get; set; }
        public string newagentid { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public Double business { get; set; }
        public Double commission { get; set; }
        public string opid { get; set; }
        public string Newbondid { get; set; }

        //----------Paymethod-----
        public string bank { get; set; }
        public string Account { get; set; }
        public string chequeno { get; set; }
        public string ACholdername { get; set; }
        public string Branch { get; set; }
        public string IFSCCode { get; set; }
        public string ChequeAmount { get; set; }

        [DataType(DataType.Date)]
        public DateTime Chequedate { get; set; }
        public string Chequeimage { get; set; }
        public string transactiontype { get; set; }
        public string paymethod { get; set; }
    }

    [Table("TDSLF_tab")]
    public class TDSLF_tab
    {
        [Key]
        public int Id { get; set; }
        public Double TDS { get; set; }
        public Double NPCTDS { get; set; }
        public Double latefine { get; set; }
        public Double processingfee { get; set; }
        public Double applicationfee { get; set; }
        public Double agencyformfee { get; set; }
        public Double accountformfee { get; set; }
        public Double accountopeningfee { get; set; }
        public Double memberfee { get; set; }
        public Double revivalfee { get; set; }

    }

    [Table("VFormatTab")]
    public class VFormatTab
    {
        [Key]
        public int Id { get; set; }
        public string type { get; set; }
        public int status { get; set; }
    }

    [Table("Voucher_Report")]
    public class Voucher_Report
    {
        [Key]
        public int Id { get; set; }
        public string branchcode { get; set; }
        public string Operatorid { get; set; }
        public int agentid { get; set; }
        public Double bussiness { get; set; }
        public Double commission { get; set; }
        public Double tds { get; set; }
        public Double netamount { get; set; }
        public int month { get; set; }
        public string year { get; set; }
        [DataType(DataType.Date)]
        public DateTime sdate { get; set; }
        [DataType(DataType.Date)]
        public DateTime edate { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }

        public string bank { get; set; }
        public string Account { get; set; }
        public string chequeno { get; set; }
        public string ACholdername { get; set; }
        public string Branch { get; set; }
        public string IFSCCode { get; set; }
        public string ChequeAmount { get; set; }

        [DataType(DataType.Date)]
        public DateTime Chequedate { get; set; }
        public string Chequeimage { get; set; }
        public string transactiontype { get; set; }
        public string paymethod { get; set; }
    }

    [Table("Member_tab")]
    public class Member_tab
    {
        [Key]
        public int Id { get; set; }
        public double Fee { get; set; }
        public string MemberName { get; set; }
        public string NewMemberId { get; set; }
        public int MemberId { get; set; }
        public string BranchCode { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string Pin { get; set; }
        public string state { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public string Nationality { get; set; }
        public int Share { get; set; }
        public string Mother { get; set; }
        public string Father { get; set; }
        public string Relationof { get; set; }
        public string Type { get; set; }
        public int Status { get; set; }
        [DataType(DataType.Date)]
        public DateTime Cdate { get; set; }
        public string Opid { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public string NomineeName { get; set; }
        public string NomineeAge { get; set; }
        public string NomineeRel { get; set; }
        public string Nomineeaddr { get; set; }

        public string panno { get; set; }
        public string bankname { get; set; }
        public string accountno { get; set; }
        public string IFSC { get; set; }
        public string category { get; set; }

    }

    [Table("SavingAccountInfo")]
    public class SavingAccountInfo
    {
        [Key]
        public int Id { get; set; }
        public string newmemberid { get; set; }
        public string actype { get; set; }
        public string accountno { get; set; }
        public string branchcode { get; set; }
        public Double formfee { get; set; }
        public string acholdername { get; set; }
        public string acholdername2 { get; set; }
        public string fathername { get; set; }
        public string fathername2 { get; set; }
        public string address { get; set; }
        public string address2 { get; set; }
        public string mobileno { get; set; }
        public string mobileno2 { get; set; }
        public string emailid { get; set; }
        public string emailid2 { get; set; }
        public string gender { get; set; }
        public string gender2 { get; set; }
        public string occupation { get; set; }
        public string occupation2 { get; set; }
        public string education { get; set; }
        public string education2 { get; set; }
        public string bloodgroup { get; set; }
        public string bloodgroup2 { get; set; }

        public Double annualincome { get; set; }
        public string annualincome2 { get; set; }
        public string panno { get; set; }
        public string panno2 { get; set; }
        public string ifsccode { get; set; }
        public string bankname { get; set; }
        public string bankaddress { get; set; }

        public string guardianname { get; set; }
        public string gurage { get; set; }
        public string gurrel { get; set; }
        public string guraddr { get; set; }

        public string nomineename { get; set; }
        public string nomage { get; set; }
        public string nomrel { get; set; }
        public string nomaddr { get; set; }

        public string photo { get; set; }
        public string photo2 { get; set; }
        public string idproof { get; set; }
        public string idproof2 { get; set; }
        public string sign { get; set; }
        public string sign2 { get; set; }
        [DataType(DataType.Date)]
        public DateTime Doj { get; set; }
        [DataType(DataType.Date)]
        public DateTime dob { get; set; }
        public string dob2 { get; set; }
        public string opid { get; set; }
        public int status { get; set; }
        public string Time { get; set; }

    }

    [Table("TransactionTab")]
    public class TransactionTab
    {
        public int Id { get; set; }
        public string transactionid { get; set; }
        public string actype { get; set; }
        public string accountno { get; set; }
        public string acholdername { get; set; }
        public string branchcode { get; set; }

        public string paymethod { get; set; }
        [DataType(DataType.Date)]
        public DateTime pdate { get; set; }
        public string checkorddno { get; set; }
        public string drawon { get; set; }
        public Double credit { get; set; }
        public Double debit { get; set; }
        public Double balance { get; set; }
        public string remark { get; set; }
        public string opid { get; set; }
        public int status { get; set; }
        public string type { get; set; }
        public string Time { get; set; }
        public string creditaccount { get; set; }
    }

    [Table("RPTab")]
    public class RPTab
    {
        [Key]
        public int Id { get; set; }
        public int status { get; set; }
    }

    [Table("RevivalTab")]
    public class RevivalTab
    {
        [Key]
        public int Id { get; set; }
        public string newbondid { get; set; }
        public int suffix { get; set; }
        public int status { get; set; }
    }

    [Table("HoldingPlot")]
    public class HoldingPlot
    {
        [Key]
        public int Id { get; set; }
        public int holdprojectid { get; set; }
        public int holdphaseid { get; set; }
        public int holdblock { get; set; }
        public int holdplotno { get; set; }

        public int holdstatus { get; set; }
        public string holdby { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> holddate { get; set; }
    }

    [Table("Plotregistry")]
    public class Plotregistry
    {
        [Key]
        public int id { get; set; }
        public string newbondid { get; set; }
        public string name { get; set; }
        public int plotno { get; set; }
        public string block { get; set; }
        public double amount { get; set; }
        public string Reciept { get; set; }
        public string bond { get; set; }
        public string registry { get; set; }
        public DateTime Date { get; set; }
        public double bookingamount { get; set; }
        public double commission { get; set; }
        public double deductionamount { get; set; }
        public double remainingamount { get; set; }
        public string type { get; set; }
        public int status { get; set; }
    }

    [Table("Visitortab")]
    public class Visitortab
    {
        [Key]
        public int ID { get; set; }
        public string name { get; set; }
        public int mobile { get; set; }
        public string purpose { get; set; }
        public string intime { get; set; }
        public string outtime { get; set; }
        public DateTime date { get; set; }
        public int status { get; set; }
        public string opid { get; set; }
        public string branchcode { get; set; }
    }

    [Table("tempappltab")]
    public class tempappltab
    {
        [Key]
        public int Id { get; set; }
        public int bondid { get; set; }
        public string branchcode { get; set; }
        public string newbondid { get; set; }
        public string name { get; set; }
        public string RelationOf { get; set; }
        public string fathername { get; set; }
        public string addr { get; set; }
        public string mobileno { get; set; }
        public int introducerid { get; set; }
        public string newintroducerid { get; set; }
        public int intrankcode { get; set; }
        public string intrankname { get; set; }
        [DataType(DataType.Date)]
        public DateTime formdate { get; set; }
        [DataType(DataType.Date)]
        public DateTime dob { get; set; }
        public string age { get; set; }
        public string nationality { get; set; }

        public string guardianname { get; set; }
        public string gurage { get; set; }
        public string gurrel { get; set; }
        public string guraddr { get; set; }
        public string photo { get; set; }

        public string panno { get; set; }
        public string bankname { get; set; }
        public string accountno { get; set; }

        public string plantype { get; set; }
        public int plancode { get; set; }
        public string planname { get; set; }
        public Double term { get; set; }
        public string mode { get; set; }
        public Double payment { get; set; }
        public Double nolandunit { get; set; }
        public Double totalcon { get; set; }
        public Double expectedraisablevalue { get; set; }
        public Double applicationcharge { get; set; }
        public Double bonusper { get; set; }
        [DataType(DataType.Date)]
        public DateTime expirydate { get; set; }

        public string nomineename { get; set; }
        public string nomage { get; set; }
        public string nomrel { get; set; }
        public string nomaddr { get; set; }

        public string paymethod { get; set; }
        [DataType(DataType.Date)]
        public DateTime pdate { get; set; }
        public string checkorddno { get; set; }
        public string drawno { get; set; }
        public string branchpay { get; set; }
        public string amountword { get; set; }
        public string opid { get; set; }
        public int status { get; set; }
        public string type { get; set; }
        public string Macaddress { get; set; }
        public string Time { get; set; }
        public int memberid { get; set; }
        public string newmemberid { get; set; }
        public string IFSC { get; set; }
        public Double discountper { get; set; }
        public Double bookingamount { get; set; }
        public Double downpayment { get; set; }
        public int plotno { get; set; }
        public int phaseid { get; set; }
        public string phase { get; set; }
        public string PYN { get; set; }
        public int projectid { get; set; }
        public string block { get; set; }
        public int printstatus { get; set; }

        public string bank { get; set; }
        public string Account { get; set; }
        public string chequeno { get; set; }
        public string ACholdername { get; set; }
        public string Branch { get; set; }
        public string IFSCCode { get; set; }
        public string ChequeAmount { get; set; }

        [DataType(DataType.Date)]
        public DateTime Chequedate { get; set; }
        public string Chequeimage { get; set; }
        public string transactiontype { get; set; }

        [DataType(DataType.Date)]
        public DateTime PAN_ReqDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime PAN_AppDate { get; set; }
        public int PanStatus { get; set; }
        [DataType(DataType.Date)]
        public DateTime Aadhaar_ReqDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime Aadhaar_AppDate { get; set; }
        public string Aadhaar_No { get; set; }
        public int Aadhaar_status { get; set; }
        public string paymenttype { get; set; }
        public string propertytype { get; set; }
        public string propertypreference { get; set; }
        public string propertyaddress { get; set; }
        public string incomegroup { get; set; }
        public string plotdesp { get; set; }
        public int uid { get; set; }
    }

    [Table("SMSSpotCommTab")]
    public class SMSSpotCommTab
    {
        [Key]
        public int Id { get; set; }
        public string newagentid { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public Double business { get; set; }
        public Double commission { get; set; }
        public string opid { get; set; }
    }

    [Table("TempInstallmenttab")]
    public class TempInstallmenttab
    {
        [Key]
        public int Id { get; set; }
        public Double amount { get; set; }
        public Double payamount { get; set; }
        public int bondid { get; set; }
        public Double latefine { get; set; }
        [DataType(DataType.Date)]
        public DateTime expirydate { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> paymentdate { get; set; }
        public Double reliefrs { get; set; }
        [DataType(DataType.Date)]
        public DateTime prevexpirydate { get; set; }
        public int year { get; set; }
        public Nullable<int> cssno { get; set; }
        public int installmentno { get; set; }
        public string receiptno { get; set; }
        public string planname { get; set; }
        public Double term_plan { get; set; }
        public string mode { get; set; }
        public string paymethod { get; set; }
        public string chekddno { get; set; }
        public string drawno { get; set; }
        public string branch { get; set; }
        public string amountinword { get; set; }
        public string newbondid { get; set; }
        public string opid { get; set; }
        public string Macaddress { get; set; }
        public string Time { get; set; }
        public int paymentno { get; set; }
        public string type { get; set; }
        public Double revivalfee { get; set; }
        public string plantype { get; set; }

        public string bank { get; set; }
        public string Account { get; set; }
        public string chequeno { get; set; }
        public string ACholdername { get; set; }
        public string Bbranch { get; set; }
        public string IFSCCode { get; set; }
        public string ChequeAmount { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Chequedate { get; set; }
        public string Chequeimage { get; set; }
        public int status { get; set; }
        public string Reason { get; set; }
        public Double Penality { get; set; }
        public string transactiontype { get; set; }
        public int uid { get; set; }
    }

    [Table("Request_Money")]
    public class Request_Money
    {
        [Key]
        public int sr_no { get; set; }
        public string agentid { get; set; }
        public double amount { get; set; }
        public string Type { get; set; }
        public string Remark { get; set; }
        public double debit { get; set; }
        public double credit { get; set; }
        public string Transaction_No { get; set; }
        public string Req_Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime req_date { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> confirm_date { get; set; }
        public string Req_name { get; set; }
        public int status { get; set; }
    }

    [Table("PayU_Payment")]
    public class PayU_Payment
    {
        [Key]
        public int Id { get; set; }
        public string Transactionid { get; set; }
        public string Payeename { get; set; }
        public string Email { get; set; }
        public string Remark { get; set; }
        public string Mobile { get; set; }
        public double Amount { get; set; }
        public DateTime Pdate { get; set; }
        public string Clientid { get; set; }
        public int status { get; set; }
        public string Mode { get; set; }
    }

    [Table("Wallet_Transaction")]
    public class Wallet_Transaction
    {
        [Key]
        public int Sr_No { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public string agentid { get; set; }
        public string Type { get; set; }
        public string Mode { get; set; }
        public string Remark { get; set; }
        public DateTime Date_Time { get; set; }
        public string Transaction_No { get; set; }
        public int status { get; set; }
        public double netamount { get; set; }
        public string Sender_Id { get; set; }
        public string Sender_Name { get; set; }
    }

    [Table("BankDetail_Tab")]
    public class BankDetail_Tab
    {
        [Key]
        public int Id { get; set; }
        public string accountype { get; set; }
        public string accountno { get; set; }
        public string bankname { get; set; }
        public string branchname { get; set; }
        public string ifsccode { get; set; }
        public string companyname { get; set; }
        public string panno1 { get; set; }
        public string panno2 { get; set; }
        public string Authorisedsignatory1 { get; set; }
        public string Authorisedsignatory2 { get; set; }
        public string contact1 { get; set; }
        public string contact2 { get; set; }
        public DateTime acopendate { get; set; }
        public string branchaddress { get; set; }
        public string opid { get; set; }
    }

    [Table("DailyDepositTab")]
    public class DailyDepositTab
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public Double twothousand { get; set; }
        public Double fivehundred { get; set; }
        public Double twohundred { get; set; }
        public Double hundred { get; set; }
        public Double fifty { get; set; }
        public Double twenty { get; set; }
        public Double ten { get; set; }
        public Double five { get; set; }
        public Double two { get; set; }
        public Double one { get; set; }
        //-------Approved
        public Double RecieveCashBookingApp { get; set; }
        public Double RecieveBankBookingApp { get; set; }
        public Double RecieveChequeBookingApp { get; set; }
        public Double RecieveCashRenApp { get; set; }
        public Double RecieveBankRenApp { get; set; }
        public Double RecieveChequeRenApp { get; set; }
        //-------DisApproved
        public Double RecieveBankBookingPending { get; set; }
        public Double RecieveChequeBookingPending { get; set; }
        public Double RecieveBankRenPending { get; set; }
        public Double RecieveChequeRenPending { get; set; }
        //-------Return
        public Double ReturnCashVoucher { get; set; }
        public Double ReturnBanVoucher { get; set; }
        public Double ReturnChequeVoucher { get; set; }
        public Double ReturnCashSpot { get; set; }
        public Double ReturnBankSpot { get; set; }
        public Double ReturnCashExp { get; set; }
        public Double ReturnChequeExp { get; set; }
        public Double ReturnBankExp { get; set; }

        public Double Latefine { get; set; }
        public Double Relief { get; set; }
        public Double total { get; set; }
        public string opid { get; set; }
        public string branchcode { get; set; }
        public int status { get; set; }
        public string RejectionReason { get; set; }
        public Double TotalCashamount { get; set; }
        public Double TotalChequeamount { get; set; }
        public Double TotalBankamount { get; set; }
        public Double Depositedamount { get; set; }
        public string transfertype { get; set; }
        public Double transferamount { get; set; }
        public string Remark { get; set; }
        public string bankname { get; set; }
        public Double remainingamount { get; set; }
        public Double ReturnChequeSpot { get; set; }
        public int bankapp { get; set; }
        public DateTime bankappdate { get; set; }
        public int trid { get; set; }
        public DateTime matchingdate { get; set; }
        public string closingtype { get; set; }
        public Double OpeningBalance { get; set; }
        public Double ClosingBalance { get; set; }
    }

    [Table("ClosingAmount_Tab")]
    public class ClosingAmount_Tab
    {
        [Key]
        public int Id { get; set; }
        public Double Amount { get; set; }
        public Double depositamount { get; set; }
        public Double remaininamount { get; set; }
        public string opid { get; set; }
        public DateTime date { get; set; }
        public int Trid { get; set; }
        public int status { get; set; }
    }

    [Table("ClosingMatchingTab")]
    public class ClosingMatchingTab
    {
        [Key]
        public int id { get; set; }
        public string pagename { get; set; }
        public int status { get; set; }
        public DateTime date { get; set; }
        public string remark { get; set; }
        public string opid { get; set; }
    }

    [Table("TempDailyDepositTab")]
    public class TempDailyDepositTab
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public Double twothousand { get; set; }
        public Double fivehundred { get; set; }
        public Double twohundred { get; set; }
        public Double hundred { get; set; }
        public Double fifty { get; set; }
        public Double twenty { get; set; }
        public Double ten { get; set; }
        public Double five { get; set; }
        public Double two { get; set; }
        public Double one { get; set; }
        //-------Approved
        public Double RecieveCashBookingApp { get; set; }
        public Double RecieveBankBookingApp { get; set; }
        public Double RecieveChequeBookingApp { get; set; }
        public Double RecieveCashRenApp { get; set; }
        public Double RecieveBankRenApp { get; set; }
        public Double RecieveChequeRenApp { get; set; }
        //-------DisApproved
        public Double RecieveBankBookingPending { get; set; }
        public Double RecieveChequeBookingPending { get; set; }
        public Double RecieveBankRenPending { get; set; }
        public Double RecieveChequeRenPending { get; set; }
        //-------Return
        public Double ReturnCashVoucher { get; set; }
        public Double ReturnBanVoucher { get; set; }
        public Double ReturnChequeVoucher { get; set; }
        public Double ReturnCashSpot { get; set; }
        public Double ReturnBankSpot { get; set; }
        public Double ReturnCashExp { get; set; }
        public Double ReturnChequeExp { get; set; }
        public Double ReturnBankExp { get; set; }

        public Double Latefine { get; set; }
        public Double Relief { get; set; }
        public Double total { get; set; }
        public string opid { get; set; }
        public string branchcode { get; set; }
        public int status { get; set; }
        public string RejectionReason { get; set; }
        public Double TotalCashamount { get; set; }
        public Double TotalChequeamount { get; set; }
        public Double TotalBankamount { get; set; }
        public Double Depositedamount { get; set; }
        public string transfertype { get; set; }
        public Double transferamount { get; set; }
        public string Remark { get; set; }
        public string bankname { get; set; }
        public Double remainingamount { get; set; }
        public Double ReturnChequeSpot { get; set; }
        public int bankapp { get; set; }
        public DateTime bankappdate { get; set; }
        public int trid { get; set; }
        public DateTime matchingdate { get; set; }
        public string closingtype { get; set; }
        public Double OpeningBalance { get; set; }
        public Double ClosingBalance { get; set; }
    }

    #region MLM table


    [Table("LeaderIncome")]
    public class LeaderIncome
    {
        [Key]
        public int Srno { get; set; }
        public int introid { get; set; }
        public string intronewid { get; set; }
        public string introname { get; set; }
        public double rs { get; set; }
        public int date { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int status { get; set; }
        public int point { get; set; }
        public int package { get; set; }
        [DataType(DataType.Date)]
        public DateTime nextsunday { get; set; }
        public string members { get; set; }
        public int position { get; set; }
        public int custid { get; set; }
        public string custnewid { get; set; }
        public string custname { get; set; }
        public int paidstatus { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastPaidDate { get; set; }
    }

    [Table("DirectIncome")]
    public class DirectIncome
    {
        [Key]
        public int Srno { get; set; }
        public int introid { get; set; }
        public string intronewid { get; set; }
        public string introname { get; set; }
        public double rs { get; set; }
        public int date { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int status { get; set; }
        public int point { get; set; }
        public int package { get; set; }
        [DataType(DataType.Date)]
        public DateTime nextsunday { get; set; }
        public string members { get; set; }
        public int position { get; set; }
        public int custid { get; set; }
        public string custnewid { get; set; }
        public string custname { get; set; }
        public int paidstatus { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastPaidDate { get; set; }
    }

    [Table("Popupimage")]
    public class Popupimage
    {
        [Key]
        public int Srno { get; set; }
        public string Image { get; set; }
        public int status { get; set; }
        public DateTime fromdate { get; set; }
        public DateTime todate { get; set; }
    }

    [Table("PayoutSummary2")]
    public class PayoutSummary2
    {
        [Key]
        public int id { get; set; }
        public string dayname { get; set; }
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int status { get; set; }
        [DataType(DataType.Date)]
        public DateTime paydate { get; set; }
        [DataType(DataType.Date)]
        public DateTime sdate { get; set; }
        [DataType(DataType.Date)]
        public DateTime edate { get; set; }
        public string opid { get; set; }
        public int introid { get; set; }
        public string Newintroid { get; set; }
        public string IntroName { get; set; }
        public double income1 { get; set; }
        public double income2 { get; set; }
        public double income3 { get; set; }
        public double income4 { get; set; }
        public double income5 { get; set; }
        public int point { get; set; }
        public double totalamount { get; set; }
        public double TDS { get; set; }
        public double AdminFee { get; set; }
        public double netamount { get; set; }
    }

    [Table("payoutfast2")]
    public class payoutfast2
    {
        [Key]
        public int srno { get; set; }
        public int id { get; set; }
        public string memberid { get; set; }
        public string username { get; set; }
        public double income1 { get; set; }
        public double income2 { get; set; }
        public double income3 { get; set; }
        public double income4 { get; set; }
        public double income5 { get; set; }
        public double adminfee { get; set; }
        public double tdsfee { get; set; }
        public double totalamount { get; set; }
        public double netamount { get; set; }
        public int status { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
    }




    [Table("payout_date2")]
    public class payout_date2
    {
        [Key]
        public int srno { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public DateTime date { get; set; }
        public int paid_status { get; set; }
        public int status { get; set; }
    }

    [Table("payoutfast")]
    public class payoutfast
    {
        [Key]
        public int srno { get; set; }
        public int id { get; set; }
        public string memberid { get; set; }
        public string username { get; set; }
        public double directsum { get; set; }
        public double leadershipsum { get; set; }
        public double matchingsum { get; set; }
        public double levelsum { get; set; }
        public double roisum { get; set; }
        public double royalsum { get; set; }
        public double poolsum { get; set; }
        public double adminfee { get; set; }
        public double tdsfee { get; set; }
        public double totalamount { get; set; }
        public double netamount { get; set; }
        public int status { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
    }

    [Table("slider")]
    public class slider
    {
        [Key]
        public int Id { get; set; }
        public string slidername { get; set; }
        [DataType(DataType.Date)]
        public DateTime Cdate { get; set; }
        public int status { get; set; }
        public string other1 { get; set; }
        public string other2 { get; set; }
    }

    [Table("Gallery")]
    public class Gallery
    {
        [Key]
        public int Id { get; set; }
        public string imagename { get; set; }
        [DataType(DataType.Date)]
        public DateTime Cdate { get; set; }
        public int status { get; set; }
        public string other1 { get; set; }
        public string other2 { get; set; }
    }


    [Table("Product_Detail")]
    public class Product_Detail
    {
        [Key]
        public int srno { get; set; }
        public string Product_Id { get; set; }
        public string Product_Code { get; set; }
        public double Amount { get; set; }
        public int BV { get; set; }
        public string Member_Id { get; set; }
        public string Product_Name { get; set; }
        public int Qty { get; set; }
        [DataType(DataType.Date)]
        public DateTime Purchase_date { get; set; }
        public int Payment_Status { get; set; }
        public int status { get; set; }

    }


    [Table("contactdetail")]
    public class contactdetail
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string mobile { get; set; }
        public string remarks { get; set; }
        public string other1 { get; set; }
        public string other2 { get; set; }
        public string other3 { get; set; }
    }
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductNum { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string ProductImage { get; set; }
        public int BrandNum { get; set; }
        public int CategoryNum { get; set; }
        public int UnitNum { get; set; }
        public double PV { get; set; }
        public double BV { get; set; }
        public float MRP { get; set; }
        public float PurchasePrice { get; set; }
        public float SellPrice { get; set; }
        public string ProductDescription { get; set; }
        public string ProductType { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string EmployeeId { get; set; }
        public int Status { get; set; }
        public double CGST { get; set; }
        public double SGST { get; set; }
        public float WithoutGSTMRP { get; set; }
        public float WithoutGSTDP { get; set; }
    }


    //[Table("Gallery")]
    //public class Gallery
    //{
    //    [Key]
    //    public int Id { get; set; }
    //    public string imagename { get; set; }
    //    [DataType(DataType.Date)]
    //    public DateTime Cdate { get; set; }
    //    public int status { get; set; }
    //    public string other1 { get; set; }
    //    public string other2 { get; set; }
    //}

    [Table("OTP")]
    public class OTP
    {
        [Key]
        public int Id { get; set; }
        public string memberid { get; set; }
        public string otp { get; set; }
        public DateTime OTPTime { get; set; }
        public int status { get; set; }
    }

    [Table("Achiever")]
    public class Achiever
    {
        [Key]
        public int Id { get; set; }
        public string achievername { get; set; }
        public string achieverphoto { get; set; }
    }


    [Table("TwoIsToOneBinaryCheck")]
    public class TwoIsToOneBinaryCheck
    {
        [Key]
        public int Srno { get; set; }
        public int LeftRatio { get; set; }
        public int RightRatio { get; set; }
        public int introid { get; set; }
    }

    [Table("Performance_income")]
    public class Performance_income
    {
        [Key]
        public int Srno { get; set; }
        public int introid { get; set; }
        public string intronewid { get; set; }
        public string introname { get; set; }
        public double rs { get; set; }
        public int date { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int status { get; set; }
        public int point { get; set; }
        public int package { get; set; }
        [DataType(DataType.Date)]
        public DateTime nextsunday { get; set; }
        public string members { get; set; }
        public int position { get; set; }
        public int custid { get; set; }
        public string custnewid { get; set; }
        public string custname { get; set; }
        public int paidstatus { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastPaidDate { get; set; }
    }

    [Table("payout_date")]
    public class payout_date
    {
        [Key]
        public int srno { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public DateTime date { get; set; }
        public int status { get; set; }
    }


    [Table("DSIINCOME")]
    public class DSIINCOME
    {
        [Key]
        public int Srno { get; set; }
        public int introid { get; set; }
        public string intronewid { get; set; }
        public string introname { get; set; }
        public string SpilId { get; set; }
        public string SpilName { get; set; }
        public double rs { get; set; }
        public int date { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int status { get; set; }
        public int point { get; set; }
        public int package { get; set; }
        [DataType(DataType.Date)]
        public DateTime nextsunday { get; set; }
        public string members { get; set; }
        public int position { get; set; }
        public int custid { get; set; }
        public string custnewid { get; set; }
        public string custname { get; set; }
        [DataType(DataType.Date)]
        public DateTime pdate { get; set; }
    }

    [Table("PackageAssign")]
    public class PackageAssign
    {
        [Key]
        public int PackageIssueId { get; set; }
        public string MemberNewId { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberIntroId { get; set; }
        public string MemberIntroName { get; set; }
        [DataType(DataType.Date)]
        public DateTime MemberRegisDate { get; set; }
        public int Package { get; set; }
        public int DSI { get; set; }
        public int PV { get; set; }
        public string CapLimit { get; set; }
        [DataType(DataType.Date)]
        public DateTime PackageIssueDate { get; set; }
        public string PackagePin { get; set; }

    }
    [Table("binary")]
    public class binary
    {
        [Key]
        public int Srno { get; set; }
        public int Id { get; set; }
        public int intid { get; set; }
        public int lperson { get; set; }
        public int rperson { get; set; }
        public int pair { get; set; }
        public string upline { get; set; }
        public int downleft { get; set; }
        public int downright { get; set; }
        public int completelevel { get; set; }

    }

    [Table("spiltab")]
    public class spiltab
    {
        [Key]
        public int Srno { get; set; }
        public int intid { get; set; }
        public int spilid { get; set; }
        public int custid { get; set; }
    }

    [Table("Increment_tab")]
    public class Increment_tab
    {
        [Key]
        public int srno { get; set; }
        public Double increment { get; set; }
        public int status { get; set; }
    }

    [Table("Member_Turnover")]
    public class Member_Turnover
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Srno { get; set; }
        public string memberid { get; set; }
        public int companyturnover { get; set; }
        public int teamdownline { get; set; }
        public int level { get; set; }
        public Double illussioncompany { get; set; }
        public Double illussionteam { get; set; }
    }

    [Table("BussinessPlanImage")]
    public class BussinessPlanImage
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Srno { get; set; }
        public string Images { get; set; }
        public int Status { get; set; }
    }

    [Table("WithdrawalRequest")]
    public class WithdrawalRequest
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Srno { get; set; }
        public int introid { get; set; }
        public string intronewid { get; set; }
        public float Amount { get; set; }
        public float NetAmount { get; set; }
        public float tds { get; set; }
        public DateTime Request_Date { get; set; }
        public DateTime Request_Completed_Date { get; set; }
        public int Status { get; set; }
        public string Transactionid { get; set; }
    }

    [Table("Wallet_History")]
    public class Wallet_History
    {
        [Key]
        public int id { get; set; }
        public string transactionid { get; set; }
        public string credit { get; set; }
        public string debit { get; set; }
        public DateTime transactiondate { get; set; }
        public string createdpin { get; set; }
        public string pincreatedby { get; set; }
        public string Remark { get; set; }
    }

    [Table("Newstab")]
    public class Newstab
    {
        public int Id { get; set; }
        public string News_sub { get; set; }
        public string News_Msg { get; set; }
        [DataType(DataType.Date)]
        public DateTime fromdate { get; set; }
        [DataType(DataType.Date)]
        public DateTime todate { get; set; }
        [DataType(DataType.Date)]
        public DateTime nodate { get; set; }
        public string type { get; set; }
        public int status { get; set; }
    }

    [Table("TeamLeveIncome")]
    public class TeamLeveIncome
    {
        [Key]
        public int Srno { get; set; }
        public int introid { get; set; }
        public string intronewid { get; set; }
        public string introname { get; set; }
        public double rs { get; set; }
        public int date { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int status { get; set; }
        public int package { get; set; }
        [DataType(DataType.Date)]
        public DateTime nextsunday { get; set; }
        public int position { get; set; }
        public int custid { get; set; }
        public string custnewid { get; set; }
        public string custname { get; set; }
        public int paidstatus { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastPaidDate { get; set; }
    }

    [Table("SetDeduction")]
    public class SetDeduction
    {
        [Key]
        public int Id { get; set; }
        public double Admincharge { get; set; }
        public double TDScharge { get; set; }
        public double PANTDS { get; set; }
        public int freelook { get; set; }
    }


    [Table("PayoutTab")]
    public class PayoutTab
    {
        [Key]
        public int id { get; set; }
        public string dayname { get; set; }
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int status { get; set; }
        [DataType(DataType.Date)]
        public DateTime paydate { get; set; }
        public string opid { get; set; }
    }

    [Table("LevelIncomee")]
    public class LevelIncomee
    {
        [Key]
        public int Srno { get; set; }
        public int introid { get; set; }
        public string intronewid { get; set; }
        public string introname { get; set; }
        public double rs { get; set; }
        public int date { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int status { get; set; }
        public int point { get; set; }
        public int package { get; set; }
        [DataType(DataType.Date)]
        public DateTime nextsunday { get; set; }
        public string members { get; set; }
        public int position { get; set; }
        public int custid { get; set; }
        public string custnewid { get; set; }
        public string custname { get; set; }
        public int paidstatus { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastPaidDate { get; set; }
    }


    [Table("slcincome")]
    public class slcincome
    {
        [Key]
        public int Srno { get; set; }
        public int introid { get; set; }
        public string intronewid { get; set; }
        public string introname { get; set; }
        public double rs { get; set; }
        public int date { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int status { get; set; }
        public int point { get; set; }
        public int package { get; set; }
        [DataType(DataType.Date)]
        public DateTime nextsunday { get; set; }
        public string members { get; set; }
        public int position { get; set; }
        public int custid { get; set; }
        public string custnewid { get; set; }
        public string custname { get; set; }
        public int paidstatus { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastPaidDate { get; set; }
    }


    [Table("PayoutSummary")]
    public class PayoutSummary
    {
        [Key]
        public int id { get; set; }
        public string dayname { get; set; }
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int status { get; set; }
        [DataType(DataType.Date)]
        public DateTime paydate { get; set; }
        [DataType(DataType.Date)]
        public DateTime sdate { get; set; }
        [DataType(DataType.Date)]
        public DateTime edate { get; set; }
        public string opid { get; set; }
        public int introid { get; set; }
        public string Newintroid { get; set; }
        public string IntroName { get; set; }
        public double LevelIncome { get; set; }
        public double BinaryIncome { get; set; }
        public double DSIIncome { get; set; }
        public double PoolIncome { get; set; }
        public double MagicIncome { get; set; }
        public double Rewards { get; set; }
        public double totalamount { get; set; }
        public double netamount { get; set; }
        public int point { get; set; }
        public double TDS { get; set; }
        public double AdminFee { get; set; }
        public double Roiincome { get; set; }
        public double Slcincome { get; set; }
        public double Royaltyincome { get; set; }
        public double Directincome { get; set; }
        public double Leadershipincome { get; set; }
    }

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    [Table("package_tab")]
    public class package_tab
    {
        [Key]
        public int id { get; set; }
        public string packageid { get; set; }
        public string packagename { get; set; }
        public double packageamount { get; set; }
        public string createby { get; set; }
        [DataType(DataType.Date)]
        public DateTime pakcagedate { get; set; }
        public int status { get; set; }
        public float capping { get; set; }
        public float bv { get; set; }
    }

    [Table("genology_tab")]
    public class genology_tab
    {
        [Key]
        public int srno { get; set; }
        public int id { get; set; }
        public string newid { get; set; }
        [DataType(DataType.Date)]
        public DateTime join_date { get; set; }
        public int position { get; set; }
        public int rank { get; set; }
        public int cust_id { get; set; }
        public int paid_status { get; set; }
        public double rs { get; set; }
        public int paid_status_level { get; set; }
    }

    [Table("businesstab")]
    public class businesstab
    {
        [Key]
        public int srno { get; set; }
        public int Id { get; set; }
        public string newid { get; set; }
        [DataType(DataType.Date)]
        public DateTime join_date { get; set; }
        public int position { get; set; }
        public int rank { get; set; }
        public int cust_id { get; set; }
        public int paid_status { get; set; }
        public double rs { get; set; }
    }

    [Table("userinformation")]
    public class userinformation
    {
        [Key]
        public int Id { get; set; }
        public string opid { get; set; }
        public string memberid { get; set; }
        public string spillid { get; set; }
        public string introducerid { get; set; }
        public string gender { get; set; }
        public string username { get; set; }
        public string Father_Spouse_name { get; set; }
        [DataType(DataType.Date)]
        public DateTime dob { get; set; }
        public string country { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int pincode { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        [DataType(DataType.Date)]
        public DateTime joindate { get; set; }
        public string nominee { get; set; }
        public double Age { get; set; }
        public string relation { get; set; }
        public int status { get; set; }

        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string AccountHolder { get; set; }
        public int AccountNo { get; set; }
        public string AccountType { get; set; }
        public string IFSC { get; set; }
        public string PAN { get; set; }
        public int rank { get; set; }
        public string BankAccountNo { get; set; }
        public string pinused { get; set; }
        public int position { get; set; }
        public string DSIid { get; set; }
        public int uid { get; set; }
        [DataType(DataType.Date)]
        public DateTime activationdate { get; set; }

        public string aadhaar { get; set; }
        public string bank_img { get; set; }
        public string pan_img { get; set; }
        public string aadhaar_img { get; set; }
        public int kyc_status { get; set; }

        public string RegistrationType { get; set; }
        public string Topnewid { get; set; }
        public string Profile_pic { get; set; }
        public double Pin_Amount { get; set; }


        public int poolnumber { get; set; }

        public int uid1 { get; set; }
        public int position1 { get; set; }
        public string spillid1 { get; set; }
    }

    [Table("pintab")]
    public class pintab
    {
        [Key]
        public int Id { get; set; }
        public string pin { get; set; }
        public int status { get; set; }
        public string assignto { get; set; }
        public DateTime timeofgeneration { get; set; }
        public DateTime timeofapproval { get; set; }
        public string usedby { get; set; }
        public double pinamount { get; set; }
        public string Createdby { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }

        [DataType(DataType.Date)]
        public DateTime Assigndate { get; set; }


    }

    [Table("wallettab")]
    public class wallettab
    {
        [Key]
        public int Id { get; set; }
        public string col2 { get; set; }
        public string col3 { get; set; }
        public string col4 { get; set; }
        public string col5 { get; set; }
        public string col6 { get; set; }
        public string col7 { get; set; }
        public string col8 { get; set; }
        public double amount { get; set; }
        public string UserId { get; set; }
    }




    [Table("Operator_detail")]
    public class Operator_detail
    {
        [Key]
        public int Id { get; set; }
        public string opid { get; set; }
        public string gender { get; set; }
        public string optname { get; set; }
        public string optFather_Spouse_name { get; set; }
        public string country { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int pincode { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        [DataType(DataType.Date)]
        public DateTime Regdate { get; set; }
        public double Age { get; set; }
        public int status { get; set; }
    }

    [Table("Introducer_Update")]
    public class Introducer_Update
    {
        [Key]
        public int Id { get; set; }
        public string opid { get; set; }
        public string MemberId { get; set; }
        public string OldIntroducer { get; set; }
        public string NewIntroducer { get; set; }
        public DateTime UpdateDate { get; set; }
    }

    [Table("LevelDetail")]
    public class LevelDetail
    {
        [Key]
        public int Id { get; set; }
        public int TotalMember { get; set; }
        public float Amount { get; set; }
        public int Sponser { get; set; }
        public float Charge { get; set; }
        public decimal Bus_amount { get; set; }
        public float LevelPercent { get; set; }
        public int Status { get; set; }
    }


    [Table("binarypayment")]
    public class binarypayment
    {
        [Key]
        public int id { get; set; }
        public int custid { get; set; }
        public double amount { get; set; }
        public int point { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public int status { get; set; }
        public int memberid { get; set; }
        [DataType(DataType.Date)]
        public DateTime pdate { get; set; }
    }
    [Table("BinaryIncome")]
    public class BinaryIncome
    {
        [Key]
        public int Srno { get; set; }
        public int introid { get; set; }
        public string intronewid { get; set; }
        public string introname { get; set; }
        public double rs { get; set; }
        public int date { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int status { get; set; }
        public int point { get; set; }
        public int package { get; set; }
        [DataType(DataType.Date)]
        public DateTime nextsunday { get; set; }
        public string members { get; set; }
        public int position { get; set; }
        public int custid { get; set; }
        public string custnewid { get; set; }
        public string custname { get; set; }
        public int paidstatus { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastPaidDate { get; set; }
    }

    [Table("Roipackage")]
    public class Roipackage
    {
        [Key]
        public int Id { get; set; }
        public string packid { get; set; }
        public double amount { get; set; }
        public double package_rs { get; set; }
        public int Ntimes { get; set; }
    }

    [Table("Roiincome")]
    public class Roiincome
    {
        [Key]
        public int Srno { get; set; }
        public int introid { get; set; }
        public string intronewid { get; set; }
        public string introname { get; set; }
        public double rs { get; set; }
        public int date { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int status { get; set; }
        public int point { get; set; }
        public int package { get; set; }
        [DataType(DataType.Date)]
        public DateTime nextsunday { get; set; }
        public string members { get; set; }
        public int position { get; set; }
        public int custid { get; set; }
        public string custnewid { get; set; }
        public string custname { get; set; }
        public int paidstatus { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastPaidDate { get; set; }
    }

    [Table("Create_Pin")]
    public class Create_Pin
    {
        [Key]
        public int srno { get; set; }
        public string ID { get; set; }
        public string Total_Pin { get; set; }
        public Double Pin_Amount { get; set; }
        public DateTime Date { get; set; }

    }

    [Table("Transfer_Pin")]
    public class Transfer_Pin
    {
        [Key]
        public int srno { get; set; }
        public string Total_Pin { get; set; }
        public string Transfer_By { get; set; }
        public string Transfer_To { get; set; }
        public string Created_By { get; set; }
        public double Pin_Amount { get; set; }
        public DateTime Date { get; set; }

    }

    [Table("matching_income_detail")]
    public class matching_income_detail
    {
        [Key]
        public int srno { get; set; }
        public int uid { get; set; }
        public string newmemberid { get; set; }
        public int amount { get; set; }
        public int actualamount { get; set; }
        public int leftbusiness { get; set; }
        public int rightbusiness { get; set; }
        public DateTime payout_date { get; set; }
        public int carryleft { get; set; }
        public int carryright { get; set; }
        public int status { get; set; }
    }

    [Table("Userinfo2")]
    public class Userinfo2
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string memberid { get; set; }
        public string password { get; set; }
        public string spilid { get; set; }
        public string introducerid { get; set; }
        public DateTime joindate { get; set; }
    }

    [Table("genology_tab2")]
    public class genology_tab2
    {
        [Key]
        public int srno { get; set; }
        public int id { get; set; }
        public string newid { get; set; }
        public int position { get; set; }
        public int rank { get; set; }
        public int cust_id { get; set; }
        public int paid_status { get; set; }
        public int paid_status_level { get; set; }
        [DataType(DataType.Date)]
        public DateTime join_date { get; set; }
        public double rs { get; set; }

    }

    [Table("binary2")]
    public class binary2
    {
        [Key]
        public int Srno { get; set; }
        public int Id { get; set; }
        public int intid { get; set; }
        public int lperson { get; set; }
        public int rperson { get; set; }
        public int pair { get; set; }
        public string upline { get; set; }
        public int downleft { get; set; }
        public int downright { get; set; }
        public int completelevel { get; set; }

    }

    [Table("RoyaltyIncome")]
    public class RoyaltyIncome
    {
        [Key]
        public int Srno { get; set; }
        public int introid { get; set; }
        public string intronewid { get; set; }
        public string introname { get; set; }
        public double rs { get; set; }
        public int date { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int status { get; set; }
        public int point { get; set; }
        public int package { get; set; }
        [DataType(DataType.Date)]
        public DateTime nextsunday { get; set; }
        public string members { get; set; }
        public int position { get; set; }
        public int custid { get; set; }
        public string custnewid { get; set; }
        public string custname { get; set; }
        public int paidstatus { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastPaidDate { get; set; }
    }

    [Table("AutopoolIncome")]
    public class AutopoolIncome
    {
        [Key]
        public int Srno { get; set; }
        public int introid { get; set; }
        public string intronewid { get; set; }
        public string introname { get; set; }
        public double rs { get; set; }
        public int date { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int status { get; set; }
        public int point { get; set; }
        public int package { get; set; }
        [DataType(DataType.Date)]
        public DateTime nextsunday { get; set; }
        public string members { get; set; }
        public int position { get; set; }
        public int custid { get; set; }
        public string custnewid { get; set; }
        public string custname { get; set; }
        public int paidstatus { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastPaidDate { get; set; }
    }

    [Table("User")]
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }

    }

    #endregion

}