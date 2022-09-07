namespace SPARSHBUILDCON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dgdfgdfg : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.AdvBrokerPaymentTab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            newagentid = c.String(),
            //            amount = c.Double(nullable: false),
            //            Remark = c.String(),
            //            branchcode = c.String(),
            //            opid = c.String(),
            //            date = c.DateTime(nullable: false),
            //            type = c.Int(nullable: false),
            //            returnamount = c.Double(nullable: false),
            //            balanceamount = c.Double(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.AgentDetail",
            //    c => new
            //        {
            //            AgencyCode = c.Int(nullable: false, identity: true),
            //            BranchCode = c.String(),
            //            name = c.String(),
            //            Father = c.String(),
            //            Mother = c.String(),
            //            Gender = c.String(),
            //            NewIntroducerId = c.String(),
            //            IntroducerCode = c.Int(nullable: false),
            //            IntroName = c.String(),
            //            RankCode = c.Int(nullable: false),
            //            RankName = c.String(),
            //            Nationality = c.String(),
            //            Dob = c.DateTime(nullable: false),
            //            Age = c.String(),
            //            BloodGroup = c.String(),
            //            Occupation = c.String(),
            //            Qualification = c.String(),
            //            Panno = c.String(),
            //            Passportno = c.String(),
            //            Drivinglno = c.String(),
            //            Icardno = c.String(),
            //            Issueon = c.DateTime(nullable: false),
            //            Validupto = c.DateTime(nullable: false),
            //            BankName = c.String(),
            //            BankCode = c.String(),
            //            BankAccountno = c.String(),
            //            IFCCode = c.String(),
            //            BankAddress = c.String(),
            //            Address = c.String(),
            //            District = c.String(),
            //            State = c.String(),
            //            PinCode = c.String(),
            //            Landlineno = c.String(),
            //            Mobileno = c.String(),
            //            Email = c.String(),
            //            NomineeName = c.String(),
            //            NomineeAge = c.String(),
            //            Relationship = c.String(),
            //            NomineeAddress = c.String(),
            //            Organization = c.String(),
            //            Doj = c.DateTime(nullable: false),
            //            activationdate = c.DateTime(nullable: false),
            //            Password = c.String(),
            //            Photo = c.String(),
            //            NewAgentId = c.String(),
            //            Company = c.String(),
            //            Mobile = c.String(),
            //            Yoe = c.Int(nullable: false),
            //            Experience = c.String(),
            //            Suffix = c.Int(nullable: false),
            //            UnitCode = c.String(),
            //            Type = c.String(),
            //            Status = c.Int(nullable: false),
            //            areaofoccupation = c.String(),
            //            approximatenoofactive = c.String(),
            //            formfee = c.Double(nullable: false),
            //            operatorid = c.String(),
            //            cmpnyaddress = c.String(),
            //            Macaddress = c.String(),
            //            Time = c.String(),
            //            memberid = c.Int(nullable: false),
            //            newmemberid = c.String(),
            //            PAN_ReqDate = c.DateTime(nullable: false),
            //            PAN_AppDate = c.DateTime(nullable: false),
            //            PanStatus = c.Int(nullable: false),
            //            Aadhaar_ReqDate = c.DateTime(nullable: false),
            //            Aadhaar_AppDate = c.DateTime(nullable: false),
            //            Aadhaar_No = c.String(),
            //            Aadhaar_status = c.Int(nullable: false),
            //            BankBranchName = c.String(),
            //            OtherMobile = c.Long(nullable: false),
            //            refno = c.String(),
            //            spilid = c.String(),
            //            position = c.Int(nullable: false),
            //            uid = c.Int(nullable: false),
            //            kyc_status = c.Int(nullable: false),
            //            AccountHolder = c.String(),
            //            AccountType = c.String(),
            //            bank_img = c.String(),
            //            pan_img = c.String(),
            //            aadhaar_img = c.String(),
            //        })
            //    .PrimaryKey(t => t.AgencyCode);
            
            //CreateTable(
            //    "dbo.appltab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            bondid = c.Int(nullable: false),
            //            branchcode = c.String(),
            //            newbondid = c.String(),
            //            name = c.String(),
            //            RelationOf = c.String(),
            //            fathername = c.String(),
            //            addr = c.String(),
            //            mobileno = c.String(),
            //            introducerid = c.Int(nullable: false),
            //            newintroducerid = c.String(),
            //            intrankcode = c.Int(nullable: false),
            //            intrankname = c.String(),
            //            formdate = c.DateTime(nullable: false),
            //            dob = c.DateTime(nullable: false),
            //            age = c.String(),
            //            nationality = c.String(),
            //            guardianname = c.String(),
            //            gurage = c.String(),
            //            gurrel = c.String(),
            //            guraddr = c.String(),
            //            photo = c.String(),
            //            panno = c.String(),
            //            bankname = c.String(),
            //            accountno = c.String(),
            //            plantype = c.String(),
            //            plancode = c.Int(nullable: false),
            //            planname = c.String(),
            //            term = c.Double(nullable: false),
            //            mode = c.String(),
            //            payment = c.Double(nullable: false),
            //            nolandunit = c.Double(nullable: false),
            //            totalcon = c.Double(nullable: false),
            //            expectedraisablevalue = c.Double(nullable: false),
            //            applicationcharge = c.Double(nullable: false),
            //            bonusper = c.Double(nullable: false),
            //            expirydate = c.DateTime(nullable: false),
            //            nomineename = c.String(),
            //            nomage = c.String(),
            //            nomrel = c.String(),
            //            nomaddr = c.String(),
            //            paymethod = c.String(),
            //            pdate = c.DateTime(nullable: false),
            //            checkorddno = c.String(),
            //            drawno = c.String(),
            //            branchpay = c.String(),
            //            amountword = c.String(),
            //            opid = c.String(),
            //            status = c.Int(nullable: false),
            //            type = c.String(),
            //            Macaddress = c.String(),
            //            Time = c.String(),
            //            memberid = c.Int(nullable: false),
            //            newmemberid = c.String(),
            //            IFSC = c.String(),
            //            discountper = c.Double(nullable: false),
            //            bookingamount = c.Double(nullable: false),
            //            downpayment = c.Double(nullable: false),
            //            plotno = c.Int(nullable: false),
            //            PYN = c.String(),
            //            projectid = c.Int(nullable: false),
            //            block = c.String(),
            //            phaseid = c.Int(nullable: false),
            //            printstatus = c.Int(nullable: false),
            //            bank = c.String(),
            //            Account = c.String(),
            //            chequeno = c.String(),
            //            ACholdername = c.String(),
            //            Branch = c.String(),
            //            IFSCCode = c.String(),
            //            ChequeAmount = c.String(),
            //            Chequedate = c.DateTime(nullable: false),
            //            Chequeimage = c.String(),
            //            chequeappdate = c.DateTime(nullable: false),
            //            transactiontype = c.String(),
            //            PAN_ReqDate = c.DateTime(nullable: false),
            //            PAN_AppDate = c.DateTime(nullable: false),
            //            PanStatus = c.Int(nullable: false),
            //            Aadhaar_ReqDate = c.DateTime(nullable: false),
            //            Aadhaar_AppDate = c.DateTime(nullable: false),
            //            Aadhaar_No = c.String(),
            //            Aadhaar_status = c.Int(nullable: false),
            //            paymenttype = c.String(),
            //            propertyaddress = c.String(),
            //            propertypreference = c.String(),
            //            plccost = c.Double(nullable: false),
            //            refno = c.String(),
            //            propertyid = c.Int(nullable: false),
            //            loanid = c.String(),
            //            propertytype = c.String(),
            //            incomegroup = c.String(),
            //            phase = c.String(),
            //            plotdesp = c.String(),
            //            northwest = c.String(),
            //            northeast = c.String(),
            //            southwest = c.String(),
            //            southeast = c.String(),
            //            sapplicantname = c.String(),
            //            sfathername = c.String(),
            //            smothername = c.String(),
            //            scategory = c.String(),
            //            scorraddress = c.String(),
            //            spermanentaddress = c.String(),
            //            scity = c.String(),
            //            sstate = c.String(),
            //            spincode = c.Int(nullable: false),
            //            snationality = c.String(),
            //            squalification = c.String(),
            //            smobileno = c.String(),
            //            salternatemobileno = c.String(),
            //            semailid = c.String(),
            //            sdob = c.String(),
            //            spanno = c.String(),
            //            saadharno = c.String(),
            //            smaritialstatus = c.String(),
            //            sanniversarydate = c.String(),
            //            soccupation = c.String(),
            //            spassport = c.String(),
            //            sresidentialstatus = c.String(),
            //            sphoto = c.String(),
            //            saadharphoto = c.String(),
            //            spanphoto = c.String(),
            //            uid = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Bond_report",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            name = c.String(),
            //            RelationOf = c.String(),
            //            FathersName = c.String(),
            //            introducerid = c.Int(nullable: false),
            //            addr = c.String(),
            //            age = c.String(),
            //            plancode = c.Int(nullable: false),
            //            planname = c.String(),
            //            landunit = c.Double(nullable: false),
            //            term = c.Double(nullable: false),
            //            total_con = c.Double(nullable: false),
            //            payment = c.Double(nullable: false),
            //            mode = c.String(),
            //            expected_value = c.Double(nullable: false),
            //            nominee_name = c.String(),
            //            nominee_age = c.String(),
            //            nominee_rel = c.String(),
            //            newbondid = c.String(),
            //            amount_word = c.String(),
            //            formdate = c.String(),
            //            branchcode = c.String(),
            //            expiry = c.String(),
            //            district = c.String(),
            //            nxt_due = c.String(),
            //            newitroducerid = c.String(),
            //            unitid = c.String(),
            //            receipt_no = c.String(),
            //            intro = c.String(),
            //            modeofpay = c.String(),
            //            last_installment = c.String(),
            //            Bondid = c.Int(nullable: false),
            //            branchaddress = c.String(),
            //            agentname = c.String(),
            //            introducername = c.String(),
            //            upintroducerid = c.Int(nullable: false),
            //            upnewintroducerid = c.String(),
            //            upintroducername = c.String(),
            //            branch_name = c.String(),
            //            mobileno = c.String(),
            //            cssno = c.Int(nullable: false),
            //            bookingamount = c.Double(nullable: false),
            //            advancepayment = c.Double(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.bonus_tab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            agentcode = c.String(),
            //            formonth = c.DateTime(nullable: false),
            //            month = c.Int(nullable: false),
            //            year = c.Int(nullable: false),
            //            type = c.String(),
            //            bonusamount = c.Double(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.branchlogindetail",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            iid = c.String(),
            //            password = c.String(),
            //            indatetime = c.DateTime(nullable: false),
            //            outdatetime = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Branchtab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            prefix = c.String(),
            //            BranchName = c.String(),
            //            BranchCode = c.String(),
            //            BranchDistrict = c.String(),
            //            branchaddress = c.String(),
            //            password = c.String(),
            //            mobile = c.String(),
            //            type = c.String(),
            //            status = c.Int(nullable: false),
            //            companyid = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.calculator",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            amount = c.Double(nullable: false),
            //            dateofcollection = c.DateTime(nullable: false),
            //            opid = c.String(),
            //            dispatch = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Cancel_Receipt",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            amount = c.Double(nullable: false),
            //            payamount = c.Double(nullable: false),
            //            bondid = c.Int(nullable: false),
            //            latefine = c.Double(nullable: false),
            //            reliefrs = c.Double(nullable: false),
            //            expirydate = c.DateTime(nullable: false),
            //            paymentdate = c.DateTime(nullable: false),
            //            prevexpirydate = c.DateTime(nullable: false),
            //            year = c.Int(nullable: false),
            //            cssno = c.Int(nullable: false),
            //            installmentno = c.Int(nullable: false),
            //            receiptno = c.String(),
            //            planname = c.String(),
            //            term = c.Double(nullable: false),
            //            mode = c.String(),
            //            paymethod = c.String(),
            //            chekddno = c.String(),
            //            drawno = c.String(),
            //            branch = c.String(),
            //            amountinword = c.String(),
            //            newbondid = c.String(),
            //            opid = c.String(),
            //            Macaddress = c.String(),
            //            Time = c.String(),
            //            paymentno = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.CityStateTab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            state = c.String(),
            //            city = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.comm_tab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            rankcode = c.Int(nullable: false),
            //            plancode = c.Int(nullable: false),
            //            year = c.Int(nullable: false),
            //            commission = c.Double(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.commission_tab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            agentid = c.Int(nullable: false),
            //            newagentid = c.String(),
            //            name = c.String(),
            //            rankcode = c.Int(nullable: false),
            //            rankname = c.String(),
            //            introducerid = c.Int(nullable: false),
            //            newintroducerid = c.String(),
            //            branchcode = c.String(),
            //            mobileno = c.String(),
            //            panno = c.String(),
            //            bondname = c.String(),
            //            bonddate = c.DateTime(nullable: false),
            //            amount = c.Double(nullable: false),
            //            commission = c.Double(nullable: false),
            //            planname = c.String(),
            //            plancode = c.Int(nullable: false),
            //            bondid = c.Int(nullable: false),
            //            newbondid = c.String(),
            //            newrenew = c.String(),
            //            type = c.Int(nullable: false),
            //            year = c.Double(nullable: false),
            //            cssno = c.Int(nullable: false),
            //            date = c.DateTime(nullable: false),
            //            percentage = c.Double(nullable: false),
            //            bondintroducerid = c.Int(nullable: false),
            //            receiptno = c.String(),
            //            comtype = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.CompanyInfo",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            CompanyName = c.String(),
            //            CompanyLogo = c.String(),
            //            Companysrtcut = c.String(),
            //            HeadOffice = c.String(),
            //            AdminId = c.String(),
            //            Password = c.String(),
            //            RegistrationNo = c.String(),
            //            Contact = c.String(),
            //            Emailid = c.String(),
            //            Address = c.String(),
            //            IncomeType = c.String(),
            //            State = c.String(),
            //            Zipcode = c.String(),
            //            DirectorName = c.String(),
            //            RegDate = c.DateTime(nullable: false),
            //            Status = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Contact",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            name = c.String(),
            //            emailid = c.String(),
            //            mobile = c.String(),
            //            subject = c.String(),
            //            message = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.delete_bond",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            bondid = c.Int(nullable: false),
            //            branchcode = c.String(),
            //            newbondid = c.String(),
            //            name = c.String(),
            //            RelationOf = c.String(),
            //            fathername = c.String(),
            //            addr = c.String(),
            //            mobileno = c.String(),
            //            introducerid = c.Int(nullable: false),
            //            newintroducerid = c.String(),
            //            intrankcode = c.Int(nullable: false),
            //            intrankname = c.String(),
            //            formdate = c.DateTime(nullable: false),
            //            dob = c.DateTime(nullable: false),
            //            age = c.String(),
            //            nationality = c.String(),
            //            guardianname = c.String(),
            //            gurage = c.Int(nullable: false),
            //            gurrel = c.String(),
            //            guraddr = c.String(),
            //            photo = c.String(),
            //            panno = c.String(),
            //            bankname = c.String(),
            //            accountno = c.String(),
            //            plantype = c.String(),
            //            plancode = c.Int(nullable: false),
            //            planname = c.String(),
            //            term = c.Double(nullable: false),
            //            mode = c.String(),
            //            payment = c.Double(nullable: false),
            //            nolandunit = c.Double(nullable: false),
            //            totalcon = c.Int(nullable: false),
            //            expectedraisablevalue = c.Int(nullable: false),
            //            applicationcharge = c.Double(nullable: false),
            //            bonusper = c.Double(nullable: false),
            //            expirydate = c.DateTime(nullable: false),
            //            nomineename = c.String(),
            //            nomage = c.String(),
            //            nomrel = c.String(),
            //            nomaddr = c.String(),
            //            paymethod = c.String(),
            //            pdate = c.DateTime(nullable: false),
            //            checkorddno = c.String(),
            //            drawno = c.String(),
            //            branchpay = c.String(),
            //            amountword = c.String(),
            //            opid = c.String(),
            //            status = c.Int(nullable: false),
            //            type = c.String(),
            //            Macaddress = c.String(),
            //            Time = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.DocumentTab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            memberid = c.String(),
            //            document = c.String(),
            //            information = c.String(),
            //            type = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.DuplicateTab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            newbondid = c.String(),
            //            payamount = c.Double(nullable: false),
            //            paymentno = c.Int(nullable: false),
            //            opid = c.String(),
            //            date = c.DateTime(nullable: false),
            //            macaddress = c.String(),
            //            type = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.DupliMacTab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            userid = c.String(),
            //            macaddress = c.String(),
            //            type = c.String(),
            //            status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Emp_atten",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            empid = c.String(),
            //            name = c.String(),
            //            branchcode = c.String(),
            //            date = c.DateTime(nullable: false),
            //            atten = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Emp_leave",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            empid = c.String(),
            //            branchcode = c.String(),
            //            sdate = c.DateTime(nullable: false),
            //            edate = c.DateTime(nullable: false),
            //            reason = c.String(),
            //            leavetype = c.String(),
            //            status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Emp_Reg",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            empid = c.String(),
            //            name = c.String(),
            //            father = c.String(),
            //            department = c.String(),
            //            designation = c.String(),
            //            basicsalary = c.Double(nullable: false),
            //            gender = c.String(),
            //            mob = c.String(),
            //            email = c.String(),
            //            address = c.String(),
            //            dob = c.DateTime(nullable: false),
            //            doj = c.DateTime(nullable: false),
            //            img = c.String(),
            //            cv = c.String(),
            //            branchcode = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Emp_Salary",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            empid = c.String(),
            //            month = c.String(),
            //            year = c.Int(nullable: false),
            //            branchcode = c.String(),
            //            opid = c.String(),
            //            doj = c.DateTime(nullable: false),
            //            HRA = c.Double(nullable: false),
            //            DA = c.Double(nullable: false),
            //            CCA = c.Double(nullable: false),
            //            TA = c.Double(nullable: false),
            //            medical = c.Double(nullable: false),
            //            advance_Pay = c.Double(nullable: false),
            //            professionaltax = c.Double(nullable: false),
            //            loan = c.Double(nullable: false),
            //            provisional_fund = c.Double(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Expense",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            head = c.String(),
            //            Remark = c.String(),
            //            amount = c.Double(nullable: false),
            //            date_time = c.DateTime(nullable: false),
            //            branchcode = c.String(),
            //            opid = c.String(),
            //            type = c.Int(nullable: false),
            //            paymethod = c.String(),
            //            bank = c.String(),
            //            Account = c.String(),
            //            chequeno = c.String(),
            //            ACholdername = c.String(),
            //            Branch = c.String(),
            //            IFSCCode = c.String(),
            //            ChequeAmount = c.String(),
            //            Chequedate = c.DateTime(nullable: false),
            //            Chequeimage = c.String(),
            //            transactiontype = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Fixed_Tab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Plancode = c.Int(nullable: false),
            //            Planname = c.String(),
            //            Term = c.Single(nullable: false),
            //            Plotsize = c.Int(nullable: false),
            //            Amount = c.Int(nullable: false),
            //            EstimatedValue = c.Double(nullable: false),
            //            Accidental = c.Double(nullable: false),
            //            type = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.HeadTab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            head = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.HRTab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            HRName = c.String(),
            //            HRId = c.String(),
            //            BranchCode = c.String(),
            //            Password = c.String(),
            //            Mobile = c.String(),
            //            emailid = c.String(),
            //            Address = c.String(),
            //            date = c.DateTime(nullable: false),
            //            Type = c.String(),
            //            Status = c.Int(nullable: false),
            //            companyid = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.hrlogin_detail",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            iid = c.String(),
            //            password = c.String(),
            //            indatetime = c.DateTime(nullable: false),
            //            outdatetime = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.ICardTab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            agentid = c.Int(nullable: false),
            //            name = c.String(),
            //            rankname = c.String(),
            //            intid = c.String(),
            //            intname = c.String(),
            //            intrankname = c.String(),
            //            address = c.String(),
            //            city = c.String(),
            //            dob = c.String(),
            //            mobno = c.String(),
            //            issuedate = c.DateTime(nullable: false),
            //            validupto = c.DateTime(nullable: false),
            //            companylogo = c.String(),
            //            photo = c.String(),
            //            logo = c.Byte(nullable: false),
            //            image = c.Byte(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.InOutTime",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            login = c.String(),
            //            logout = c.String(),
            //            status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Installmenttab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            amount = c.Double(nullable: false),
            //            payamount = c.Double(nullable: false),
            //            bondid = c.Int(nullable: false),
            //            latefine = c.Double(nullable: false),
            //            expirydate = c.DateTime(nullable: false),
            //            paymentdate = c.DateTime(),
            //            reliefrs = c.Double(nullable: false),
            //            prevexpirydate = c.DateTime(nullable: false),
            //            year = c.Int(nullable: false),
            //            cssno = c.Int(),
            //            installmentno = c.Int(nullable: false),
            //            receiptno = c.String(),
            //            planname = c.String(),
            //            term_plan = c.Double(nullable: false),
            //            mode = c.String(),
            //            paymethod = c.String(),
            //            chekddno = c.String(),
            //            drawno = c.String(),
            //            branch = c.String(),
            //            amountinword = c.String(),
            //            newbondid = c.String(),
            //            opid = c.String(),
            //            Macaddress = c.String(),
            //            Time = c.String(),
            //            paymentno = c.Int(nullable: false),
            //            type = c.String(),
            //            revivalfee = c.Double(nullable: false),
            //            plantype = c.String(),
            //            bank = c.String(),
            //            Account = c.String(),
            //            chequeno = c.String(),
            //            ACholdername = c.String(),
            //            Bbranch = c.String(),
            //            IFSCCode = c.String(),
            //            ChequeAmount = c.String(),
            //            Chequedate = c.DateTime(),
            //            Chequeimage = c.String(),
            //            Penality = c.Double(nullable: false),
            //            chequeappdate = c.DateTime(nullable: false),
            //            transactiontype = c.String(),
            //            uid = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.MISInstallmenttab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            amount = c.Double(nullable: false),
            //            payamount = c.Double(nullable: false),
            //            bondid = c.Int(nullable: false),
            //            latefine = c.Double(nullable: false),
            //            expirydate = c.DateTime(nullable: false),
            //            paymentdate = c.DateTime(),
            //            reliefrs = c.Double(nullable: false),
            //            prevexpirydate = c.DateTime(nullable: false),
            //            year = c.Int(nullable: false),
            //            cssno = c.Int(),
            //            installmentno = c.Int(nullable: false),
            //            receiptno = c.String(),
            //            planname = c.String(),
            //            term_plan = c.Double(nullable: false),
            //            mode = c.String(),
            //            paymethod = c.String(),
            //            chekddno = c.String(),
            //            drawno = c.String(),
            //            branch = c.String(),
            //            amountinword = c.String(),
            //            newbondid = c.String(),
            //            opid = c.String(),
            //            Macaddress = c.String(),
            //            Time = c.String(),
            //            paymentno = c.Int(nullable: false),
            //            type = c.String(),
            //            revivalfee = c.Double(nullable: false),
            //            plantype = c.String(),
            //            bank = c.String(),
            //            Account = c.String(),
            //            chequeno = c.String(),
            //            ACholdername = c.String(),
            //            Bbranch = c.String(),
            //            IFSCCode = c.String(),
            //            ChequeAmount = c.String(),
            //            Chequedate = c.DateTime(),
            //            Chequeimage = c.String(),
            //            Penality = c.Double(nullable: false),
            //            chequeappdate = c.DateTime(nullable: false),
            //            transactiontype = c.String(),
            //            uid = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.MacTab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            userid = c.String(),
            //            macaddress = c.String(),
            //            type = c.String(),
            //            status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.MaturityTab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            bondid = c.Int(nullable: false),
            //            branchcode = c.String(),
            //            newbondid = c.String(),
            //            name = c.String(),
            //            RelationOf = c.String(),
            //            fathername = c.String(),
            //            addr = c.String(),
            //            mobileno = c.String(),
            //            introducerid = c.Int(nullable: false),
            //            newintroducerid = c.String(),
            //            intrankcode = c.Int(nullable: false),
            //            intrankname = c.String(),
            //            formdate = c.DateTime(nullable: false),
            //            dob = c.DateTime(nullable: false),
            //            age = c.String(),
            //            nationality = c.String(),
            //            guardianname = c.String(),
            //            gurage = c.String(),
            //            gurrel = c.String(),
            //            guraddr = c.String(),
            //            photo = c.String(),
            //            panno = c.String(),
            //            bankname = c.String(),
            //            accountno = c.String(),
            //            plantype = c.String(),
            //            plancode = c.Int(nullable: false),
            //            planname = c.String(),
            //            term = c.Double(nullable: false),
            //            mode = c.String(),
            //            payment = c.Double(nullable: false),
            //            nolandunit = c.Double(nullable: false),
            //            totalcon = c.Double(nullable: false),
            //            expectedraisablevalue = c.Double(nullable: false),
            //            applicationcharge = c.Double(nullable: false),
            //            bonusper = c.Double(nullable: false),
            //            expirydate = c.DateTime(nullable: false),
            //            nomineename = c.String(),
            //            nomage = c.String(),
            //            nomrel = c.String(),
            //            nomaddr = c.String(),
            //            paymethod = c.String(),
            //            pdate = c.DateTime(nullable: false),
            //            checkorddno = c.String(),
            //            drawno = c.String(),
            //            branchpay = c.String(),
            //            amountword = c.String(),
            //            opid = c.String(),
            //            status = c.Int(nullable: false),
            //            maturityamount = c.Double(nullable: false),
            //            pendingamount = c.Double(nullable: false),
            //            extraamount = c.Double(nullable: false),
            //            commamount = c.Double(nullable: false),
            //            maturitytype = c.String(),
            //            type = c.String(),
            //            Macaddress = c.String(),
            //            Time = c.String(),
            //            maturitydate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Member",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            branchname = c.String(),
            //            planname = c.String(),
            //            agentname = c.String(),
            //            custname = c.String(),
            //            rankname = c.String(),
            //            type = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.NewLogin",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            UserName = c.String(),
            //            Password = c.String(),
            //            Mobile = c.String(),
            //            type = c.String(),
            //            status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.NewPlan",
            //    c => new
            //        {
            //            Plancode = c.Int(nullable: false, identity: true),
            //            Planname = c.String(),
            //            Term = c.Single(nullable: false),
            //            mlyinstall = c.Int(nullable: false),
            //            qlyinstall = c.Int(nullable: false),
            //            hlyinstall = c.Int(nullable: false),
            //            ylyinstall = c.Int(nullable: false),
            //            Type = c.String(),
            //            revivaltime = c.Int(nullable: false),
            //            status = c.Int(nullable: false),
            //            bookingrate = c.Double(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Plancode);
            
            //CreateTable(
            //    "dbo.Operator",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            OperatorName = c.String(),
            //            OperatorId = c.String(),
            //            BranchCode = c.String(),
            //            OperatorPassword = c.String(),
            //            OperatorMobile = c.String(),
            //            OperatorAddress = c.String(),
            //            Type = c.String(),
            //            Status = c.Int(nullable: false),
            //            Cdate = c.DateTime(nullable: false),
            //            Operator_Mail = c.String(),
            //            companyid = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.operatorlogin_detail",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            iid = c.String(),
            //            password = c.String(),
            //            indatetime = c.DateTime(nullable: false),
            //            outdatetime = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.MIPP_tab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            plancode = c.Int(nullable: false),
            //            planname = c.String(),
            //            term = c.Double(nullable: false),
            //            plotsize = c.Double(nullable: false),
            //            amount = c.Double(nullable: false),
            //            Yearly = c.Double(nullable: false),
            //            FiveERV = c.Double(nullable: false),
            //            SevenERV = c.Double(nullable: false),
            //            TenERV = c.Double(nullable: false),
            //            type = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Pension_Tab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Plancode = c.Int(nullable: false),
            //            Planname = c.String(),
            //            Term = c.Single(nullable: false),
            //            Plotsize = c.Int(nullable: false),
            //            Amount = c.Int(nullable: false),
            //            Monthly = c.Double(nullable: false),
            //            Quarterly = c.Double(nullable: false),
            //            Halfyearly = c.Double(nullable: false),
            //            Yearly = c.Double(nullable: false),
            //            Profit = c.Double(nullable: false),
            //            EstimatedValue = c.Double(nullable: false),
            //            type = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Plan",
            //    c => new
            //        {
            //            Plancode = c.Int(nullable: false, identity: true),
            //            Planname = c.String(),
            //            shortcutname = c.String(),
            //            type = c.String(),
            //            status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Plancode);
            
            //CreateTable(
            //    "dbo.PlanTab",
            //    c => new
            //        {
            //            Plancode = c.Int(nullable: false, identity: true),
            //            Planname = c.String(),
            //            Plotsize = c.Int(nullable: false),
            //            Term = c.Double(nullable: false),
            //            mode = c.String(),
            //            Minvalue = c.Double(nullable: false),
            //            Maxvalue = c.Double(nullable: false),
            //            Multiple = c.Double(nullable: false),
            //            MaturityPercent = c.Double(nullable: false),
            //            PercentType = c.String(),
            //            BonusPercent = c.Double(nullable: false),
            //            Installments = c.Int(nullable: false),
            //            Type = c.String(),
            //        })
            //    .PrimaryKey(t => t.Plancode);
            
            //CreateTable(
            //    "dbo.Plan_Tab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Plancode = c.Int(nullable: false),
            //            Planname = c.String(),
            //            Term = c.Single(nullable: false),
            //            Plotsize = c.Int(nullable: false),
            //            Amount = c.Int(nullable: false),
            //            Monthly = c.Double(nullable: false),
            //            Quarterly = c.Double(nullable: false),
            //            Halfyearly = c.Double(nullable: false),
            //            Yearly = c.Double(nullable: false),
            //            EstimatedValue = c.Double(nullable: false),
            //            Accidental = c.Double(nullable: false),
            //            type = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Ranktab",
            //    c => new
            //        {
            //            RankCode = c.Int(nullable: false, identity: true),
            //            RankName = c.String(),
            //            Rankshrtcut = c.String(),
            //            TeamQuota = c.Double(nullable: false),
            //            Selfquota = c.Double(nullable: false),
            //        })
            //    .PrimaryKey(t => t.RankCode);
            
            //CreateTable(
            //    "dbo.RecieptTab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            newbondid = c.String(),
            //            branchname = c.String(),
            //            branchaddress = c.String(),
            //            branchcode = c.String(),
            //            cssno = c.Int(nullable: false),
            //            paymentno = c.Int(nullable: false),
            //            ledgerfolio = c.String(),
            //            installmentno = c.String(),
            //            receiptno = c.String(),
            //            date = c.String(),
            //            duedate = c.String(),
            //            nextduedate = c.String(),
            //            expirydate = c.String(),
            //            name = c.String(),
            //            father = c.String(),
            //            relation = c.String(),
            //            age = c.String(),
            //            address = c.String(),
            //            dateofcommencement = c.String(),
            //            totalconsideration = c.Double(nullable: false),
            //            maturityamount = c.Double(nullable: false),
            //            yearsubscrib = c.Int(nullable: false),
            //            unitcode = c.String(),
            //            planname = c.String(),
            //            term = c.Double(nullable: false),
            //            landunit = c.Double(nullable: false),
            //            mode = c.String(),
            //            amount = c.Double(nullable: false),
            //            agencycode = c.String(),
            //            payamount = c.Double(nullable: false),
            //            paymethod = c.String(),
            //            othercharge = c.Double(nullable: false),
            //            amountinwords = c.String(),
            //            opid = c.String(),
            //            Bank = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.relation",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            relations = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Salary_em",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            empid = c.String(),
            //            month = c.String(),
            //            year = c.Int(nullable: false),
            //            name = c.String(),
            //            designation = c.String(),
            //            department = c.String(),
            //            basicsalary = c.Double(nullable: false),
            //            doj = c.DateTime(nullable: false),
            //            date = c.DateTime(nullable: false),
            //            img = c.String(),
            //            HRA = c.Double(nullable: false),
            //            DA = c.Double(nullable: false),
            //            CCA = c.Double(nullable: false),
            //            TA = c.Double(nullable: false),
            //            medical = c.Double(nullable: false),
            //            advance_Pay = c.Double(nullable: false),
            //            professionaltax = c.Double(nullable: false),
            //            loan = c.Double(nullable: false),
            //            provisional_fund = c.Double(nullable: false),
            //            grossincentive = c.Double(nullable: false),
            //            deductionamount = c.Double(nullable: false),
            //            netsalary = c.Double(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.SalaryTab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Rank = c.Int(nullable: false),
            //            Salary = c.Double(nullable: false),
            //            Insurance = c.Double(nullable: false),
            //            Bonuspercent = c.Double(nullable: false),
            //            plancode = c.Int(nullable: false),
            //            planyear = c.Double(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.SchemeTab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            msg = c.String(),
            //            type = c.String(),
            //            date = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.SetMacTab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.spotcommission_tab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            agentid = c.Int(nullable: false),
            //            newagentid = c.String(),
            //            name = c.String(),
            //            rankcode = c.Int(nullable: false),
            //            rankname = c.String(),
            //            introducerid = c.Int(nullable: false),
            //            newintroducerid = c.String(),
            //            branchcode = c.String(),
            //            mobileno = c.String(),
            //            bondname = c.String(),
            //            bonddate = c.DateTime(nullable: false),
            //            amount = c.Double(nullable: false),
            //            commissionper = c.Double(nullable: false),
            //            commission = c.Double(nullable: false),
            //            planname = c.String(),
            //            plancode = c.Int(nullable: false),
            //            bondid = c.Int(nullable: false),
            //            newbondid = c.String(),
            //            newrenew = c.String(),
            //            type = c.Int(nullable: false),
            //            cssno = c.Int(nullable: false),
            //            year = c.Double(nullable: false),
            //            date = c.DateTime(nullable: false),
            //            receiptno = c.String(),
            //            status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.SpotCommTab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            newagentid = c.String(),
            //            date = c.DateTime(nullable: false),
            //            business = c.Double(nullable: false),
            //            commission = c.Double(nullable: false),
            //            opid = c.String(),
            //            Newbondid = c.String(),
            //            bank = c.String(),
            //            Account = c.String(),
            //            chequeno = c.String(),
            //            ACholdername = c.String(),
            //            Branch = c.String(),
            //            IFSCCode = c.String(),
            //            ChequeAmount = c.String(),
            //            Chequedate = c.DateTime(nullable: false),
            //            Chequeimage = c.String(),
            //            transactiontype = c.String(),
            //            paymethod = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.TDSLF_tab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            TDS = c.Double(nullable: false),
            //            NPCTDS = c.Double(nullable: false),
            //            latefine = c.Double(nullable: false),
            //            processingfee = c.Double(nullable: false),
            //            applicationfee = c.Double(nullable: false),
            //            agencyformfee = c.Double(nullable: false),
            //            accountformfee = c.Double(nullable: false),
            //            accountopeningfee = c.Double(nullable: false),
            //            memberfee = c.Double(nullable: false),
            //            revivalfee = c.Double(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.VFormatTab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            type = c.String(),
            //            status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Voucher_Report",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            branchcode = c.String(),
            //            Operatorid = c.String(),
            //            agentid = c.Int(nullable: false),
            //            bussiness = c.Double(nullable: false),
            //            commission = c.Double(nullable: false),
            //            tds = c.Double(nullable: false),
            //            netamount = c.Double(nullable: false),
            //            month = c.Int(nullable: false),
            //            year = c.String(),
            //            sdate = c.DateTime(nullable: false),
            //            edate = c.DateTime(nullable: false),
            //            date = c.DateTime(nullable: false),
            //            bank = c.String(),
            //            Account = c.String(),
            //            chequeno = c.String(),
            //            ACholdername = c.String(),
            //            Branch = c.String(),
            //            IFSCCode = c.String(),
            //            ChequeAmount = c.String(),
            //            Chequedate = c.DateTime(nullable: false),
            //            Chequeimage = c.String(),
            //            transactiontype = c.String(),
            //            paymethod = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.SavingAccountInfo",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            newmemberid = c.String(),
            //            actype = c.String(),
            //            accountno = c.String(),
            //            branchcode = c.String(),
            //            formfee = c.Double(nullable: false),
            //            acholdername = c.String(),
            //            acholdername2 = c.String(),
            //            fathername = c.String(),
            //            fathername2 = c.String(),
            //            address = c.String(),
            //            address2 = c.String(),
            //            mobileno = c.String(),
            //            mobileno2 = c.String(),
            //            emailid = c.String(),
            //            emailid2 = c.String(),
            //            gender = c.String(),
            //            gender2 = c.String(),
            //            occupation = c.String(),
            //            occupation2 = c.String(),
            //            education = c.String(),
            //            education2 = c.String(),
            //            bloodgroup = c.String(),
            //            bloodgroup2 = c.String(),
            //            annualincome = c.Double(nullable: false),
            //            annualincome2 = c.String(),
            //            panno = c.String(),
            //            panno2 = c.String(),
            //            ifsccode = c.String(),
            //            bankname = c.String(),
            //            bankaddress = c.String(),
            //            guardianname = c.String(),
            //            gurage = c.String(),
            //            gurrel = c.String(),
            //            guraddr = c.String(),
            //            nomineename = c.String(),
            //            nomage = c.String(),
            //            nomrel = c.String(),
            //            nomaddr = c.String(),
            //            photo = c.String(),
            //            photo2 = c.String(),
            //            idproof = c.String(),
            //            idproof2 = c.String(),
            //            sign = c.String(),
            //            sign2 = c.String(),
            //            Doj = c.DateTime(nullable: false),
            //            dob = c.DateTime(nullable: false),
            //            dob2 = c.String(),
            //            opid = c.String(),
            //            status = c.Int(nullable: false),
            //            Time = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Member_tab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Fee = c.Double(nullable: false),
            //            MemberName = c.String(),
            //            NewMemberId = c.String(),
            //            MemberId = c.Int(nullable: false),
            //            BranchCode = c.String(),
            //            Address = c.String(),
            //            District = c.String(),
            //            Pin = c.String(),
            //            state = c.String(),
            //            Gender = c.String(),
            //            Mobile = c.String(),
            //            Nationality = c.String(),
            //            Share = c.Int(nullable: false),
            //            Mother = c.String(),
            //            Father = c.String(),
            //            Relationof = c.String(),
            //            Type = c.String(),
            //            Status = c.Int(nullable: false),
            //            Cdate = c.DateTime(nullable: false),
            //            Opid = c.String(),
            //            DOB = c.DateTime(nullable: false),
            //            NomineeName = c.String(),
            //            NomineeAge = c.String(),
            //            NomineeRel = c.String(),
            //            Nomineeaddr = c.String(),
            //            panno = c.String(),
            //            bankname = c.String(),
            //            accountno = c.String(),
            //            IFSC = c.String(),
            //            category = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.TransactionTab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            transactionid = c.String(),
            //            actype = c.String(),
            //            accountno = c.String(),
            //            acholdername = c.String(),
            //            branchcode = c.String(),
            //            paymethod = c.String(),
            //            pdate = c.DateTime(nullable: false),
            //            checkorddno = c.String(),
            //            drawon = c.String(),
            //            credit = c.Double(nullable: false),
            //            debit = c.Double(nullable: false),
            //            balance = c.Double(nullable: false),
            //            remark = c.String(),
            //            opid = c.String(),
            //            status = c.Int(nullable: false),
            //            type = c.String(),
            //            Time = c.String(),
            //            creditaccount = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.ReleaseTab",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            Releasedate = c.DateTime(nullable: false),
            //            year = c.String(),
            //            month = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "dbo.BrokerCommList",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            agencycode = c.Int(nullable: false),
            //            newagentid = c.String(),
            //            name = c.String(),
            //            introducerid = c.Int(nullable: false),
            //            newintroducerid = c.String(),
            //            Introname = c.String(),
            //            rankcode = c.Int(nullable: false),
            //            rankname = c.String(),
            //            mobile = c.String(),
            //            branchcode = c.String(),
            //            panno = c.String(),
            //            status = c.Int(nullable: false),
            //            date = c.DateTime(nullable: false),
            //            month = c.String(),
            //            Year = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID);
            
            //CreateTable(
            //    "dbo.Formdate",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            formdate = c.DateTime(nullable: false),
            //            branchcode = c.String(),
            //            opid = c.String(),
            //            status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.RPTab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.RevivalTab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            newbondid = c.String(),
            //            suffix = c.Int(nullable: false),
            //            status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.MaturityDocument",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            NewBondId = c.String(),
            //            BondId = c.Int(nullable: false),
            //            Remark = c.String(),
            //            branchcode = c.String(),
            //            date = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.MaturityStatus",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            bondid = c.Int(nullable: false),
            //            newbondid = c.String(),
            //            name = c.String(),
            //            matstatus = c.Int(nullable: false),
            //            voucherstatus = c.Int(nullable: false),
            //            status = c.Int(nullable: false),
            //            newstatus = c.String(),
            //            maturityamount = c.Double(nullable: false),
            //            maturitydate = c.DateTime(nullable: false),
            //            newintroducerid = c.String(),
            //            plantype = c.String(),
            //            plancode = c.Int(nullable: false),
            //            planname = c.String(),
            //            term = c.Double(nullable: false),
            //            mode = c.String(),
            //            totalcon = c.Double(nullable: false),
            //            paymethod = c.String(),
            //            pdate = c.DateTime(),
            //            chequedate = c.DateTime(),
            //            checkorddno = c.String(),
            //            drawno = c.String(),
            //            branchpay = c.String(),
            //            exptdate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.ChangeAgentId",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            agencycode = c.Int(nullable: false),
            //            PreNewagentid = c.String(),
            //            CurrentNewagentid = c.String(),
            //            RankName = c.String(),
            //            RankCode = c.Int(nullable: false),
            //            date = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Blockdate",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Payment = c.Double(nullable: false),
            //            Fresh = c.Double(nullable: false),
            //            Renewal = c.Double(nullable: false),
            //            received = c.Double(nullable: false),
            //            member = c.Double(nullable: false),
            //            bankentry = c.Double(nullable: false),
            //            custfee = c.Double(nullable: false),
            //            agentfee = c.Double(nullable: false),
            //            date = c.DateTime(nullable: false),
            //            branchcode = c.String(),
            //            status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.AdvDeductionVoucher",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            newagentid = c.String(),
            //            amount = c.Double(nullable: false),
            //            month = c.Int(nullable: false),
            //            year = c.Int(nullable: false),
            //            date = c.DateTime(nullable: false),
            //            Remark = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.BookingTab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            bookingrate = c.Double(nullable: false),
            //            spotcomm = c.Double(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.ProTerm",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            projectid = c.Int(nullable: false),
            //            projectname = c.String(),
            //            term = c.Double(nullable: false),
            //            status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.RateTab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            projectid = c.Int(nullable: false),
            //            projectname = c.String(),
            //            term = c.Double(nullable: false),
            //            plotcost = c.Double(nullable: false),
            //            plotsize = c.Double(nullable: false),
            //            noi = c.Int(nullable: false),
            //            status = c.Int(nullable: false),
            //            quotaper = c.Double(nullable: false),
            //            shortcutname = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.PlotLimit",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            projectid = c.Int(nullable: false),
            //            projectname = c.String(),
            //            minvalue = c.Int(nullable: false),
            //            maxvalue = c.Int(nullable: false),
            //            status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.PhaseTab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            projectid = c.Int(nullable: false),
            //            Phase = c.String(),
            //            status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.BlockTab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            phaseid = c.Int(nullable: false),
            //            block = c.String(),
            //            min = c.Int(nullable: false),
            //            max = c.Int(nullable: false),
            //            status = c.Int(nullable: false),
            //            Plancode = c.Int(nullable: false),
            //            Planname = c.String(),
            //            createdate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.spotcomm_tab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            rankcode = c.Int(nullable: false),
            //            plancode = c.Int(nullable: false),
            //            year = c.Int(nullable: false),
            //            commission = c.Double(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.HoldingPlot",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            holdprojectid = c.Int(nullable: false),
            //            holdphaseid = c.Int(nullable: false),
            //            holdblock = c.Int(nullable: false),
            //            holdplotno = c.Int(nullable: false),
            //            holdstatus = c.Int(nullable: false),
            //            holdby = c.String(),
            //            holddate = c.DateTime(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Plotregistry",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            newbondid = c.String(),
            //            name = c.String(),
            //            plotno = c.Int(nullable: false),
            //            block = c.String(),
            //            amount = c.Double(nullable: false),
            //            Reciept = c.String(),
            //            bond = c.String(),
            //            registry = c.String(),
            //            Date = c.DateTime(nullable: false),
            //            bookingamount = c.Double(nullable: false),
            //            commission = c.Double(nullable: false),
            //            deductionamount = c.Double(nullable: false),
            //            remainingamount = c.Double(nullable: false),
            //            type = c.String(),
            //            status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "dbo.Visitortab",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            name = c.String(),
            //            mobile = c.Int(nullable: false),
            //            purpose = c.String(),
            //            intime = c.String(),
            //            outtime = c.String(),
            //            date = c.DateTime(nullable: false),
            //            status = c.Int(nullable: false),
            //            opid = c.String(),
            //            branchcode = c.String(),
            //        })
            //    .PrimaryKey(t => t.ID);
            
            //CreateTable(
            //    "dbo.tempappltab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            bondid = c.Int(nullable: false),
            //            branchcode = c.String(),
            //            newbondid = c.String(),
            //            name = c.String(),
            //            RelationOf = c.String(),
            //            fathername = c.String(),
            //            addr = c.String(),
            //            mobileno = c.String(),
            //            introducerid = c.Int(nullable: false),
            //            newintroducerid = c.String(),
            //            intrankcode = c.Int(nullable: false),
            //            intrankname = c.String(),
            //            formdate = c.DateTime(nullable: false),
            //            dob = c.DateTime(nullable: false),
            //            age = c.String(),
            //            nationality = c.String(),
            //            guardianname = c.String(),
            //            gurage = c.String(),
            //            gurrel = c.String(),
            //            guraddr = c.String(),
            //            photo = c.String(),
            //            panno = c.String(),
            //            bankname = c.String(),
            //            accountno = c.String(),
            //            plantype = c.String(),
            //            plancode = c.Int(nullable: false),
            //            planname = c.String(),
            //            term = c.Double(nullable: false),
            //            mode = c.String(),
            //            payment = c.Double(nullable: false),
            //            nolandunit = c.Double(nullable: false),
            //            totalcon = c.Double(nullable: false),
            //            expectedraisablevalue = c.Double(nullable: false),
            //            applicationcharge = c.Double(nullable: false),
            //            bonusper = c.Double(nullable: false),
            //            expirydate = c.DateTime(nullable: false),
            //            nomineename = c.String(),
            //            nomage = c.String(),
            //            nomrel = c.String(),
            //            nomaddr = c.String(),
            //            paymethod = c.String(),
            //            pdate = c.DateTime(nullable: false),
            //            checkorddno = c.String(),
            //            drawno = c.String(),
            //            branchpay = c.String(),
            //            amountword = c.String(),
            //            opid = c.String(),
            //            status = c.Int(nullable: false),
            //            type = c.String(),
            //            Macaddress = c.String(),
            //            Time = c.String(),
            //            memberid = c.Int(nullable: false),
            //            newmemberid = c.String(),
            //            IFSC = c.String(),
            //            discountper = c.Double(nullable: false),
            //            bookingamount = c.Double(nullable: false),
            //            downpayment = c.Double(nullable: false),
            //            plotno = c.Int(nullable: false),
            //            phaseid = c.Int(nullable: false),
            //            phase = c.String(),
            //            PYN = c.String(),
            //            projectid = c.Int(nullable: false),
            //            block = c.String(),
            //            printstatus = c.Int(nullable: false),
            //            bank = c.String(),
            //            Account = c.String(),
            //            chequeno = c.String(),
            //            ACholdername = c.String(),
            //            Branch = c.String(),
            //            IFSCCode = c.String(),
            //            ChequeAmount = c.String(),
            //            Chequedate = c.DateTime(nullable: false),
            //            Chequeimage = c.String(),
            //            transactiontype = c.String(),
            //            PAN_ReqDate = c.DateTime(nullable: false),
            //            PAN_AppDate = c.DateTime(nullable: false),
            //            PanStatus = c.Int(nullable: false),
            //            Aadhaar_ReqDate = c.DateTime(nullable: false),
            //            Aadhaar_AppDate = c.DateTime(nullable: false),
            //            Aadhaar_No = c.String(),
            //            Aadhaar_status = c.Int(nullable: false),
            //            paymenttype = c.String(),
            //            uid = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.SMSSpotCommTab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            newagentid = c.String(),
            //            date = c.DateTime(nullable: false),
            //            business = c.Double(nullable: false),
            //            commission = c.Double(nullable: false),
            //            opid = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.TempInstallmenttab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            amount = c.Double(nullable: false),
            //            payamount = c.Double(nullable: false),
            //            bondid = c.Int(nullable: false),
            //            latefine = c.Double(nullable: false),
            //            expirydate = c.DateTime(nullable: false),
            //            paymentdate = c.DateTime(),
            //            reliefrs = c.Double(nullable: false),
            //            prevexpirydate = c.DateTime(nullable: false),
            //            year = c.Int(nullable: false),
            //            cssno = c.Int(),
            //            installmentno = c.Int(nullable: false),
            //            receiptno = c.String(),
            //            planname = c.String(),
            //            term_plan = c.Double(nullable: false),
            //            mode = c.String(),
            //            paymethod = c.String(),
            //            chekddno = c.String(),
            //            drawno = c.String(),
            //            branch = c.String(),
            //            amountinword = c.String(),
            //            newbondid = c.String(),
            //            opid = c.String(),
            //            Macaddress = c.String(),
            //            Time = c.String(),
            //            paymentno = c.Int(nullable: false),
            //            type = c.String(),
            //            revivalfee = c.Double(nullable: false),
            //            plantype = c.String(),
            //            bank = c.String(),
            //            Account = c.String(),
            //            chequeno = c.String(),
            //            ACholdername = c.String(),
            //            Bbranch = c.String(),
            //            IFSCCode = c.String(),
            //            ChequeAmount = c.String(),
            //            Chequedate = c.DateTime(),
            //            Chequeimage = c.String(),
            //            status = c.Int(nullable: false),
            //            Reason = c.String(),
            //            Penality = c.Double(nullable: false),
            //            transactiontype = c.String(),
            //            uid = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Request_Money",
            //    c => new
            //        {
            //            sr_no = c.Int(nullable: false, identity: true),
            //            agentid = c.String(),
            //            amount = c.Double(nullable: false),
            //            Type = c.String(),
            //            Remark = c.String(),
            //            debit = c.Double(nullable: false),
            //            credit = c.Double(nullable: false),
            //            Transaction_No = c.String(),
            //            Req_Id = c.String(),
            //            req_date = c.DateTime(nullable: false),
            //            confirm_date = c.DateTime(),
            //            Req_name = c.String(),
            //            status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.sr_no);
            
            //CreateTable(
            //    "dbo.PayU_Payment",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Transactionid = c.String(),
            //            Payeename = c.String(),
            //            Email = c.String(),
            //            Remark = c.String(),
            //            Mobile = c.String(),
            //            Amount = c.Double(nullable: false),
            //            Pdate = c.DateTime(nullable: false),
            //            Clientid = c.String(),
            //            status = c.Int(nullable: false),
            //            Mode = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Wallet_Transaction",
            //    c => new
            //        {
            //            Sr_No = c.Int(nullable: false, identity: true),
            //            Debit = c.Double(nullable: false),
            //            Credit = c.Double(nullable: false),
            //            agentid = c.String(),
            //            Type = c.String(),
            //            Mode = c.String(),
            //            Remark = c.String(),
            //            Date_Time = c.DateTime(nullable: false),
            //            Transaction_No = c.String(),
            //            status = c.Int(nullable: false),
            //            netamount = c.Double(nullable: false),
            //            Sender_Id = c.String(),
            //            Sender_Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.Sr_No);
            
            //CreateTable(
            //    "dbo.PC_Tab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            userid = c.String(),
            //            PCId = c.String(),
            //            PCName = c.String(),
            //            addate = c.DateTime(nullable: false),
            //            status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.BankDetail_Tab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            accountype = c.String(),
            //            accountno = c.String(),
            //            bankname = c.String(),
            //            branchname = c.String(),
            //            ifsccode = c.String(),
            //            companyname = c.String(),
            //            panno1 = c.String(),
            //            panno2 = c.String(),
            //            Authorisedsignatory1 = c.String(),
            //            Authorisedsignatory2 = c.String(),
            //            contact1 = c.String(),
            //            contact2 = c.String(),
            //            acopendate = c.DateTime(nullable: false),
            //            branchaddress = c.String(),
            //            opid = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.DailyDepositTab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            date = c.DateTime(nullable: false),
            //            twothousand = c.Double(nullable: false),
            //            fivehundred = c.Double(nullable: false),
            //            twohundred = c.Double(nullable: false),
            //            hundred = c.Double(nullable: false),
            //            fifty = c.Double(nullable: false),
            //            twenty = c.Double(nullable: false),
            //            ten = c.Double(nullable: false),
            //            five = c.Double(nullable: false),
            //            two = c.Double(nullable: false),
            //            one = c.Double(nullable: false),
            //            RecieveCashBookingApp = c.Double(nullable: false),
            //            RecieveBankBookingApp = c.Double(nullable: false),
            //            RecieveChequeBookingApp = c.Double(nullable: false),
            //            RecieveCashRenApp = c.Double(nullable: false),
            //            RecieveBankRenApp = c.Double(nullable: false),
            //            RecieveChequeRenApp = c.Double(nullable: false),
            //            RecieveBankBookingPending = c.Double(nullable: false),
            //            RecieveChequeBookingPending = c.Double(nullable: false),
            //            RecieveBankRenPending = c.Double(nullable: false),
            //            RecieveChequeRenPending = c.Double(nullable: false),
            //            ReturnCashVoucher = c.Double(nullable: false),
            //            ReturnBanVoucher = c.Double(nullable: false),
            //            ReturnChequeVoucher = c.Double(nullable: false),
            //            ReturnCashSpot = c.Double(nullable: false),
            //            ReturnBankSpot = c.Double(nullable: false),
            //            ReturnCashExp = c.Double(nullable: false),
            //            ReturnChequeExp = c.Double(nullable: false),
            //            ReturnBankExp = c.Double(nullable: false),
            //            Latefine = c.Double(nullable: false),
            //            Relief = c.Double(nullable: false),
            //            total = c.Double(nullable: false),
            //            opid = c.String(),
            //            branchcode = c.String(),
            //            status = c.Int(nullable: false),
            //            RejectionReason = c.String(),
            //            TotalCashamount = c.Double(nullable: false),
            //            TotalChequeamount = c.Double(nullable: false),
            //            TotalBankamount = c.Double(nullable: false),
            //            Depositedamount = c.Double(nullable: false),
            //            transfertype = c.String(),
            //            transferamount = c.Double(nullable: false),
            //            Remark = c.String(),
            //            bankname = c.String(),
            //            remainingamount = c.Double(nullable: false),
            //            ReturnChequeSpot = c.Double(nullable: false),
            //            bankapp = c.Int(nullable: false),
            //            bankappdate = c.DateTime(nullable: false),
            //            trid = c.Int(nullable: false),
            //            matchingdate = c.DateTime(nullable: false),
            //            closingtype = c.String(),
            //            OpeningBalance = c.Double(nullable: false),
            //            ClosingBalance = c.Double(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.ClosingAmount_Tab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Amount = c.Double(nullable: false),
            //            depositamount = c.Double(nullable: false),
            //            remaininamount = c.Double(nullable: false),
            //            opid = c.String(),
            //            date = c.DateTime(nullable: false),
            //            Trid = c.Int(nullable: false),
            //            status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.ClosingMatchingTab",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            pagename = c.String(),
            //            status = c.Int(nullable: false),
            //            date = c.DateTime(nullable: false),
            //            remark = c.String(),
            //            opid = c.String(),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "dbo.TempDailyDepositTab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            date = c.DateTime(nullable: false),
            //            twothousand = c.Double(nullable: false),
            //            fivehundred = c.Double(nullable: false),
            //            twohundred = c.Double(nullable: false),
            //            hundred = c.Double(nullable: false),
            //            fifty = c.Double(nullable: false),
            //            twenty = c.Double(nullable: false),
            //            ten = c.Double(nullable: false),
            //            five = c.Double(nullable: false),
            //            two = c.Double(nullable: false),
            //            one = c.Double(nullable: false),
            //            RecieveCashBookingApp = c.Double(nullable: false),
            //            RecieveBankBookingApp = c.Double(nullable: false),
            //            RecieveChequeBookingApp = c.Double(nullable: false),
            //            RecieveCashRenApp = c.Double(nullable: false),
            //            RecieveBankRenApp = c.Double(nullable: false),
            //            RecieveChequeRenApp = c.Double(nullable: false),
            //            RecieveBankBookingPending = c.Double(nullable: false),
            //            RecieveChequeBookingPending = c.Double(nullable: false),
            //            RecieveBankRenPending = c.Double(nullable: false),
            //            RecieveChequeRenPending = c.Double(nullable: false),
            //            ReturnCashVoucher = c.Double(nullable: false),
            //            ReturnBanVoucher = c.Double(nullable: false),
            //            ReturnChequeVoucher = c.Double(nullable: false),
            //            ReturnCashSpot = c.Double(nullable: false),
            //            ReturnBankSpot = c.Double(nullable: false),
            //            ReturnCashExp = c.Double(nullable: false),
            //            ReturnChequeExp = c.Double(nullable: false),
            //            ReturnBankExp = c.Double(nullable: false),
            //            Latefine = c.Double(nullable: false),
            //            Relief = c.Double(nullable: false),
            //            total = c.Double(nullable: false),
            //            opid = c.String(),
            //            branchcode = c.String(),
            //            status = c.Int(nullable: false),
            //            RejectionReason = c.String(),
            //            TotalCashamount = c.Double(nullable: false),
            //            TotalChequeamount = c.Double(nullable: false),
            //            TotalBankamount = c.Double(nullable: false),
            //            Depositedamount = c.Double(nullable: false),
            //            transfertype = c.String(),
            //            transferamount = c.Double(nullable: false),
            //            Remark = c.String(),
            //            bankname = c.String(),
            //            remainingamount = c.Double(nullable: false),
            //            ReturnChequeSpot = c.Double(nullable: false),
            //            bankapp = c.Int(nullable: false),
            //            bankappdate = c.DateTime(nullable: false),
            //            trid = c.Int(nullable: false),
            //            matchingdate = c.DateTime(nullable: false),
            //            closingtype = c.String(),
            //            OpeningBalance = c.Double(nullable: false),
            //            ClosingBalance = c.Double(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.DailyVisitor",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            ReceptionistId = c.String(),
            //            ReceptionistName = c.String(),
            //            MobileNo = c.String(),
            //            EmailId = c.String(),
            //            Address = c.String(),
            //            CreatedDate = c.DateTime(nullable: false),
            //            CreaderBy = c.String(),
            //            OfficeCode = c.String(),
            //            UserName = c.String(),
            //            Password = c.String(),
            //            Status = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.DailyVisitorDetail",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            VisitorId = c.String(),
            //            VisitorName = c.String(),
            //            MeetToWhom = c.String(),
            //            Purpose = c.String(),
            //            InTime = c.String(),
            //            OutTime = c.String(),
            //            Address = c.String(),
            //            MobileNo = c.String(),
            //            EmailId = c.String(),
            //            ReceptionistId = c.String(),
            //            OfficeCode = c.String(),
            //            Type = c.String(),
            //            Remark = c.String(),
            //            feedback = c.String(),
            //            feedbackDate = c.DateTime(nullable: false),
            //            feedbackTime = c.String(),
            //            TodaysDate = c.DateTime(nullable: false),
            //            Status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.VehicleRequestDetail",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            RequestToken = c.String(),
            //            RequestedDate = c.DateTime(nullable: false),
            //            ApprovedDate = c.DateTime(nullable: false),
            //            RequestTime = c.String(),
            //            ApprovTime = c.String(),
            //            NoOfSeatRequired = c.String(),
            //            AgentId = c.String(),
            //            TravelDistance = c.Int(nullable: false),
            //            VisitDate = c.DateTime(nullable: false),
            //            ReturnDate = c.DateTime(nullable: false),
            //            Remark = c.String(),
            //            Status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.User",
            //    c => new
            //        {
            //            UserID = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            Address = c.String(),
            //            ContactNo = c.String(),
            //        })
            //    .PrimaryKey(t => t.UserID);
            
            //CreateTable(
            //    "dbo.Gallery",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            imagename = c.String(),
            //            Cdate = c.DateTime(nullable: false),
            //            status = c.Int(nullable: false),
            //            other1 = c.String(),
            //            other2 = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.binary",
            //    c => new
            //        {
            //            Srno = c.Int(nullable: false, identity: true),
            //            Id = c.Int(nullable: false),
            //            intid = c.Int(nullable: false),
            //            lperson = c.Int(nullable: false),
            //            rperson = c.Int(nullable: false),
            //            pair = c.Int(nullable: false),
            //            upline = c.String(),
            //            downleft = c.Int(nullable: false),
            //            downright = c.Int(nullable: false),
            //            completelevel = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Srno);
            
            //CreateTable(
            //    "dbo.spiltab",
            //    c => new
            //        {
            //            Srno = c.Int(nullable: false, identity: true),
            //            intid = c.Int(nullable: false),
            //            spilid = c.Int(nullable: false),
            //            custid = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Srno);
            
            //CreateTable(
            //    "dbo.UserProfile",
            //    c => new
            //        {
            //            UserId = c.Int(nullable: false, identity: true),
            //            UserName = c.String(),
            //        })
            //    .PrimaryKey(t => t.UserId);
            
            //CreateTable(
            //    "dbo.genology_tab",
            //    c => new
            //        {
            //            srno = c.Int(nullable: false, identity: true),
            //            id = c.Int(nullable: false),
            //            newid = c.String(),
            //            join_date = c.DateTime(nullable: false),
            //            position = c.Int(nullable: false),
            //            rank = c.Int(nullable: false),
            //            cust_id = c.Int(nullable: false),
            //            paid_status = c.Int(nullable: false),
            //            rs = c.Double(nullable: false),
            //            paid_status_level = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.srno);
            
            //CreateTable(
            //    "dbo.userinformation",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            opid = c.String(),
            //            memberid = c.String(),
            //            spillid = c.String(),
            //            introducerid = c.String(),
            //            gender = c.String(),
            //            username = c.String(),
            //            Father_Spouse_name = c.String(),
            //            dob = c.DateTime(nullable: false),
            //            country = c.String(),
            //            address = c.String(),
            //            city = c.String(),
            //            state = c.String(),
            //            pincode = c.Int(nullable: false),
            //            mobile = c.String(),
            //            email = c.String(),
            //            joindate = c.DateTime(nullable: false),
            //            nominee = c.String(),
            //            Age = c.Double(nullable: false),
            //            relation = c.String(),
            //            status = c.Int(nullable: false),
            //            BankName = c.String(),
            //            BranchName = c.String(),
            //            AccountHolder = c.String(),
            //            AccountNo = c.Int(nullable: false),
            //            AccountType = c.String(),
            //            IFSC = c.String(),
            //            PAN = c.String(),
            //            rank = c.Int(nullable: false),
            //            BankAccountNo = c.String(),
            //            pinused = c.String(),
            //            position = c.Int(nullable: false),
            //            DSIid = c.String(),
            //            uid = c.Int(nullable: false),
            //            activationdate = c.DateTime(nullable: false),
            //            aadhaar = c.String(),
            //            bank_img = c.String(),
            //            pan_img = c.String(),
            //            aadhaar_img = c.String(),
            //            kyc_status = c.Int(nullable: false),
            //            RegistrationType = c.String(),
            //            Topnewid = c.String(),
            //            Profile_pic = c.String(),
            //            Pin_Amount = c.Double(nullable: false),
            //            poolnumber = c.Int(nullable: false),
            //            uid1 = c.Int(nullable: false),
            //            position1 = c.Int(nullable: false),
            //            spillid1 = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.pintab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            pin = c.String(),
            //            status = c.Int(nullable: false),
            //            assignto = c.String(),
            //            timeofgeneration = c.DateTime(nullable: false),
            //            timeofapproval = c.DateTime(nullable: false),
            //            usedby = c.String(),
            //            pinamount = c.String(),
            //            Createdby = c.String(),
            //            mobile = c.String(),
            //            email = c.String(),
            //            Assigndate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.wallettab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            col2 = c.String(),
            //            col3 = c.String(),
            //            col4 = c.String(),
            //            col5 = c.String(),
            //            col6 = c.String(),
            //            col7 = c.String(),
            //            col8 = c.String(),
            //            amount = c.Double(nullable: false),
            //            UserId = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Operator_detail",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            opid = c.String(),
            //            gender = c.String(),
            //            optname = c.String(),
            //            optFather_Spouse_name = c.String(),
            //            country = c.String(),
            //            address = c.String(),
            //            city = c.String(),
            //            state = c.String(),
            //            pincode = c.Int(nullable: false),
            //            mobile = c.String(),
            //            email = c.String(),
            //            Regdate = c.DateTime(nullable: false),
            //            Age = c.Double(nullable: false),
            //            status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Introducer_Update",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            opid = c.String(),
            //            MemberId = c.String(),
            //            OldIntroducer = c.String(),
            //            NewIntroducer = c.String(),
            //            UpdateDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.package_tab",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            packageid = c.String(),
            //            packagename = c.String(),
            //            packageamount = c.Int(nullable: false),
            //            createby = c.String(),
            //            pakcagedate = c.DateTime(nullable: false),
            //            status = c.Int(nullable: false),
            //            capping = c.Single(nullable: false),
            //            bv = c.Single(nullable: false),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "dbo.PayoutSummary",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            dayname = c.String(),
            //            day = c.Int(nullable: false),
            //            month = c.Int(nullable: false),
            //            year = c.Int(nullable: false),
            //            status = c.Int(nullable: false),
            //            paydate = c.DateTime(nullable: false),
            //            sdate = c.DateTime(nullable: false),
            //            edate = c.DateTime(nullable: false),
            //            opid = c.String(),
            //            introid = c.Int(nullable: false),
            //            Newintroid = c.String(),
            //            IntroName = c.String(),
            //            LevelIncome = c.Double(nullable: false),
            //            BinaryIncome = c.Double(nullable: false),
            //            DSIIncome = c.Double(nullable: false),
            //            PoolIncome = c.Double(nullable: false),
            //            MagicIncome = c.Double(nullable: false),
            //            Rewards = c.Double(nullable: false),
            //            totalamount = c.Double(nullable: false),
            //            netamount = c.Double(nullable: false),
            //            point = c.Int(nullable: false),
            //            TDS = c.Double(nullable: false),
            //            AdminFee = c.Double(nullable: false),
            //            Roiincome = c.Double(nullable: false),
            //            Slcincome = c.Double(nullable: false),
            //            Royaltyincome = c.Double(nullable: false),
            //            Directincome = c.Double(nullable: false),
            //            Leadershipincome = c.Double(nullable: false),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "dbo.LevelDetail",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            TotalMember = c.Int(nullable: false),
            //            Amount = c.Single(nullable: false),
            //            Sponser = c.Int(nullable: false),
            //            Charge = c.Single(nullable: false),
            //            Bus_amount = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            LevelPercent = c.Single(nullable: false),
            //            Status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.LevelIncomee",
            //    c => new
            //        {
            //            Srno = c.Int(nullable: false, identity: true),
            //            introid = c.Int(nullable: false),
            //            intronewid = c.String(),
            //            introname = c.String(),
            //            rs = c.Double(nullable: false),
            //            date = c.Int(nullable: false),
            //            month = c.Int(nullable: false),
            //            year = c.Int(nullable: false),
            //            status = c.Int(nullable: false),
            //            point = c.Int(nullable: false),
            //            package = c.Int(nullable: false),
            //            nextsunday = c.DateTime(nullable: false),
            //            members = c.String(),
            //            position = c.Int(nullable: false),
            //            custid = c.Int(nullable: false),
            //            custnewid = c.String(),
            //            custname = c.String(),
            //            paidstatus = c.Int(nullable: false),
            //            LastPaidDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Srno);
            
            //CreateTable(
            //    "dbo.PayoutTab",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            dayname = c.String(),
            //            day = c.Int(nullable: false),
            //            month = c.Int(nullable: false),
            //            year = c.Int(nullable: false),
            //            status = c.Int(nullable: false),
            //            paydate = c.DateTime(nullable: false),
            //            opid = c.String(),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "dbo.SetDeduction",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Admincharge = c.Double(nullable: false),
            //            TDScharge = c.Double(nullable: false),
            //            PANTDS = c.Double(nullable: false),
            //            freelook = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.TeamLeveIncome",
            //    c => new
            //        {
            //            Srno = c.Int(nullable: false, identity: true),
            //            introid = c.Int(nullable: false),
            //            intronewid = c.String(),
            //            introname = c.String(),
            //            rs = c.Double(nullable: false),
            //            date = c.Int(nullable: false),
            //            month = c.Int(nullable: false),
            //            year = c.Int(nullable: false),
            //            status = c.Int(nullable: false),
            //            package = c.Int(nullable: false),
            //            nextsunday = c.DateTime(nullable: false),
            //            position = c.Int(nullable: false),
            //            custid = c.Int(nullable: false),
            //            custnewid = c.String(),
            //            custname = c.String(),
            //            paidstatus = c.Int(nullable: false),
            //            LastPaidDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Srno);
            
            //CreateTable(
            //    "dbo.Wallet_History",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            transactionid = c.String(),
            //            credit = c.String(),
            //            debit = c.String(),
            //            transactiondate = c.DateTime(nullable: false),
            //            createdpin = c.String(),
            //            pincreatedby = c.String(),
            //            Remark = c.String(),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "dbo.Newstab",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            News_sub = c.String(),
            //            News_Msg = c.String(),
            //            fromdate = c.DateTime(nullable: false),
            //            todate = c.DateTime(nullable: false),
            //            nodate = c.DateTime(nullable: false),
            //            type = c.String(),
            //            status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.WithdrawalRequest",
            //    c => new
            //        {
            //            Srno = c.Int(nullable: false, identity: true),
            //            introid = c.Int(nullable: false),
            //            intronewid = c.String(),
            //            Amount = c.Single(nullable: false),
            //            NetAmount = c.Single(nullable: false),
            //            tds = c.Single(nullable: false),
            //            Request_Date = c.DateTime(nullable: false),
            //            Request_Completed_Date = c.DateTime(nullable: false),
            //            Status = c.Int(nullable: false),
            //            Transactionid = c.String(),
            //        })
            //    .PrimaryKey(t => t.Srno);
            
            //CreateTable(
            //    "dbo.BussinessPlanImage",
            //    c => new
            //        {
            //            Srno = c.Int(nullable: false, identity: true),
            //            Images = c.String(),
            //            Status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Srno);
            
            //CreateTable(
            //    "dbo.BinaryIncome",
            //    c => new
            //        {
            //            Srno = c.Int(nullable: false, identity: true),
            //            introid = c.Int(nullable: false),
            //            intronewid = c.String(),
            //            introname = c.String(),
            //            rs = c.Double(nullable: false),
            //            date = c.Int(nullable: false),
            //            month = c.Int(nullable: false),
            //            year = c.Int(nullable: false),
            //            status = c.Int(nullable: false),
            //            point = c.Int(nullable: false),
            //            package = c.Int(nullable: false),
            //            nextsunday = c.DateTime(nullable: false),
            //            members = c.String(),
            //            position = c.Int(nullable: false),
            //            custid = c.Int(nullable: false),
            //            custnewid = c.String(),
            //            custname = c.String(),
            //            paidstatus = c.Int(nullable: false),
            //            LastPaidDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Srno);
            
            //CreateTable(
            //    "dbo.binarypayment",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            custid = c.Int(nullable: false),
            //            amount = c.Double(nullable: false),
            //            point = c.Int(nullable: false),
            //            date = c.DateTime(nullable: false),
            //            status = c.Int(nullable: false),
            //            memberid = c.Int(nullable: false),
            //            pdate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "dbo.Member_Turnover",
            //    c => new
            //        {
            //            Srno = c.Int(nullable: false, identity: true),
            //            memberid = c.String(),
            //            companyturnover = c.Int(nullable: false),
            //            teamdownline = c.Int(nullable: false),
            //            level = c.Int(nullable: false),
            //            illussioncompany = c.Double(nullable: false),
            //            illussionteam = c.Double(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Srno);
            
            //CreateTable(
            //    "dbo.Increment_tab",
            //    c => new
            //        {
            //            srno = c.Int(nullable: false, identity: true),
            //            increment = c.Double(nullable: false),
            //            status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.srno);
            
            //CreateTable(
            //    "dbo.PackageAssign",
            //    c => new
            //        {
            //            PackageIssueId = c.Int(nullable: false, identity: true),
            //            MemberNewId = c.String(),
            //            MemberId = c.Int(nullable: false),
            //            MemberName = c.String(),
            //            MemberIntroId = c.String(),
            //            MemberIntroName = c.String(),
            //            MemberRegisDate = c.DateTime(nullable: false),
            //            Package = c.Int(nullable: false),
            //            DSI = c.Int(nullable: false),
            //            PV = c.Int(nullable: false),
            //            CapLimit = c.String(),
            //            PackageIssueDate = c.DateTime(nullable: false),
            //            PackagePin = c.String(),
            //        })
            //    .PrimaryKey(t => t.PackageIssueId);
            
            //CreateTable(
            //    "dbo.DSIINCOME",
            //    c => new
            //        {
            //            Srno = c.Int(nullable: false, identity: true),
            //            introid = c.Int(nullable: false),
            //            intronewid = c.String(),
            //            introname = c.String(),
            //            SpilId = c.String(),
            //            SpilName = c.String(),
            //            rs = c.Double(nullable: false),
            //            date = c.Int(nullable: false),
            //            month = c.Int(nullable: false),
            //            year = c.Int(nullable: false),
            //            status = c.Int(nullable: false),
            //            point = c.Int(nullable: false),
            //            package = c.Int(nullable: false),
            //            nextsunday = c.DateTime(nullable: false),
            //            members = c.String(),
            //            position = c.Int(nullable: false),
            //            custid = c.Int(nullable: false),
            //            custnewid = c.String(),
            //            custname = c.String(),
            //            pdate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Srno);
            
            //CreateTable(
            //    "dbo.Roipackage",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            packid = c.String(),
            //            amount = c.Double(nullable: false),
            //            package_rs = c.Double(nullable: false),
            //            Ntimes = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Roiincome",
            //    c => new
            //        {
            //            Srno = c.Int(nullable: false, identity: true),
            //            introid = c.Int(nullable: false),
            //            intronewid = c.String(),
            //            introname = c.String(),
            //            rs = c.Double(nullable: false),
            //            date = c.Int(nullable: false),
            //            month = c.Int(nullable: false),
            //            year = c.Int(nullable: false),
            //            status = c.Int(nullable: false),
            //            point = c.Int(nullable: false),
            //            package = c.Int(nullable: false),
            //            nextsunday = c.DateTime(nullable: false),
            //            members = c.String(),
            //            position = c.Int(nullable: false),
            //            custid = c.Int(nullable: false),
            //            custnewid = c.String(),
            //            custname = c.String(),
            //            paidstatus = c.Int(nullable: false),
            //            LastPaidDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Srno);
            
            //CreateTable(
            //    "dbo.slcincome",
            //    c => new
            //        {
            //            Srno = c.Int(nullable: false, identity: true),
            //            introid = c.Int(nullable: false),
            //            intronewid = c.String(),
            //            introname = c.String(),
            //            rs = c.Double(nullable: false),
            //            date = c.Int(nullable: false),
            //            month = c.Int(nullable: false),
            //            year = c.Int(nullable: false),
            //            status = c.Int(nullable: false),
            //            point = c.Int(nullable: false),
            //            package = c.Int(nullable: false),
            //            nextsunday = c.DateTime(nullable: false),
            //            members = c.String(),
            //            position = c.Int(nullable: false),
            //            custid = c.Int(nullable: false),
            //            custnewid = c.String(),
            //            custname = c.String(),
            //            paidstatus = c.Int(nullable: false),
            //            LastPaidDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Srno);
            
            //CreateTable(
            //    "dbo.payout_date",
            //    c => new
            //        {
            //            srno = c.Int(nullable: false, identity: true),
            //            month = c.Int(nullable: false),
            //            year = c.Int(nullable: false),
            //            date = c.DateTime(nullable: false),
            //            status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.srno);
            
            //CreateTable(
            //    "dbo.Create_Pin",
            //    c => new
            //        {
            //            srno = c.Int(nullable: false, identity: true),
            //            ID = c.String(),
            //            Total_Pin = c.String(),
            //            Pin_Amount = c.Double(nullable: false),
            //            Date = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.srno);
            
            //CreateTable(
            //    "dbo.Transfer_Pin",
            //    c => new
            //        {
            //            srno = c.Int(nullable: false, identity: true),
            //            Total_Pin = c.String(),
            //            Transfer_By = c.String(),
            //            Transfer_To = c.String(),
            //            Created_By = c.String(),
            //            Pin_Amount = c.Double(nullable: false),
            //            Date = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.srno);
            
            //CreateTable(
            //    "dbo.matching_income_detail",
            //    c => new
            //        {
            //            srno = c.Int(nullable: false, identity: true),
            //            uid = c.Int(nullable: false),
            //            newmemberid = c.String(),
            //            amount = c.Int(nullable: false),
            //            actualamount = c.Int(nullable: false),
            //            leftbusiness = c.Int(nullable: false),
            //            rightbusiness = c.Int(nullable: false),
            //            payout_date = c.DateTime(nullable: false),
            //            carryleft = c.Int(nullable: false),
            //            carryright = c.Int(nullable: false),
            //            status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.srno);
            
            //CreateTable(
            //    "dbo.Userinfo2",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            username = c.String(),
            //            memberid = c.String(),
            //            password = c.String(),
            //            spilid = c.String(),
            //            introducerid = c.String(),
            //            joindate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "dbo.TwoIsToOneBinaryCheck",
            //    c => new
            //        {
            //            Srno = c.Int(nullable: false, identity: true),
            //            LeftRatio = c.Int(nullable: false),
            //            RightRatio = c.Int(nullable: false),
            //            introid = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Srno);
            
            //CreateTable(
            //    "dbo.Performance_income",
            //    c => new
            //        {
            //            Srno = c.Int(nullable: false, identity: true),
            //            introid = c.Int(nullable: false),
            //            intronewid = c.String(),
            //            introname = c.String(),
            //            rs = c.Double(nullable: false),
            //            date = c.Int(nullable: false),
            //            month = c.Int(nullable: false),
            //            year = c.Int(nullable: false),
            //            status = c.Int(nullable: false),
            //            point = c.Int(nullable: false),
            //            package = c.Int(nullable: false),
            //            nextsunday = c.DateTime(nullable: false),
            //            members = c.String(),
            //            position = c.Int(nullable: false),
            //            custid = c.Int(nullable: false),
            //            custnewid = c.String(),
            //            custname = c.String(),
            //            paidstatus = c.Int(nullable: false),
            //            LastPaidDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Srno);
            
            //CreateTable(
            //    "dbo.binary2",
            //    c => new
            //        {
            //            Srno = c.Int(nullable: false, identity: true),
            //            Id = c.Int(nullable: false),
            //            intid = c.Int(nullable: false),
            //            lperson = c.Int(nullable: false),
            //            rperson = c.Int(nullable: false),
            //            pair = c.Int(nullable: false),
            //            upline = c.String(),
            //            downleft = c.Int(nullable: false),
            //            downright = c.Int(nullable: false),
            //            completelevel = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Srno);
            
            //CreateTable(
            //    "dbo.genology_tab2",
            //    c => new
            //        {
            //            srno = c.Int(nullable: false, identity: true),
            //            id = c.Int(nullable: false),
            //            newid = c.String(),
            //            position = c.Int(nullable: false),
            //            rank = c.Int(nullable: false),
            //            cust_id = c.Int(nullable: false),
            //            paid_status = c.Int(nullable: false),
            //            paid_status_level = c.Int(nullable: false),
            //            join_date = c.DateTime(nullable: false),
            //            rs = c.Double(nullable: false),
            //        })
            //    .PrimaryKey(t => t.srno);
            
            //CreateTable(
            //    "dbo.RoyaltyIncome",
            //    c => new
            //        {
            //            Srno = c.Int(nullable: false, identity: true),
            //            introid = c.Int(nullable: false),
            //            intronewid = c.String(),
            //            introname = c.String(),
            //            rs = c.Double(nullable: false),
            //            date = c.Int(nullable: false),
            //            month = c.Int(nullable: false),
            //            year = c.Int(nullable: false),
            //            status = c.Int(nullable: false),
            //            point = c.Int(nullable: false),
            //            package = c.Int(nullable: false),
            //            nextsunday = c.DateTime(nullable: false),
            //            members = c.String(),
            //            position = c.Int(nullable: false),
            //            custid = c.Int(nullable: false),
            //            custnewid = c.String(),
            //            custname = c.String(),
            //            paidstatus = c.Int(nullable: false),
            //            LastPaidDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Srno);
            
            //CreateTable(
            //    "dbo.AutopoolIncome",
            //    c => new
            //        {
            //            Srno = c.Int(nullable: false, identity: true),
            //            introid = c.Int(nullable: false),
            //            intronewid = c.String(),
            //            introname = c.String(),
            //            rs = c.Double(nullable: false),
            //            date = c.Int(nullable: false),
            //            month = c.Int(nullable: false),
            //            year = c.Int(nullable: false),
            //            status = c.Int(nullable: false),
            //            point = c.Int(nullable: false),
            //            package = c.Int(nullable: false),
            //            nextsunday = c.DateTime(nullable: false),
            //            members = c.String(),
            //            position = c.Int(nullable: false),
            //            custid = c.Int(nullable: false),
            //            custnewid = c.String(),
            //            custname = c.String(),
            //            paidstatus = c.Int(nullable: false),
            //            LastPaidDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Srno);
            
            //CreateTable(
            //    "dbo.Achiever",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            achievername = c.String(),
            //            achieverphoto = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.OTP",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            memberid = c.String(),
            //            otp = c.String(),
            //            OTPTime = c.DateTime(nullable: false),
            //            status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.contactdetail",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            name = c.String(),
            //            address = c.String(),
            //            mobile = c.String(),
            //            remarks = c.String(),
            //            other1 = c.String(),
            //            other2 = c.String(),
            //            other3 = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Product",
            //    c => new
            //        {
            //            ProductNum = c.Int(nullable: false, identity: true),
            //            ProductName = c.String(),
            //            ProductCode = c.String(),
            //            ProductImage = c.String(),
            //            BrandNum = c.Int(nullable: false),
            //            CategoryNum = c.Int(nullable: false),
            //            UnitNum = c.Int(nullable: false),
            //            PV = c.Double(nullable: false),
            //            BV = c.Double(nullable: false),
            //            MRP = c.Single(nullable: false),
            //            PurchasePrice = c.Single(nullable: false),
            //            SellPrice = c.Single(nullable: false),
            //            ProductDescription = c.String(),
            //            ProductType = c.String(),
            //            CreatedDate = c.String(),
            //            UpdatedDate = c.String(),
            //            EmployeeId = c.String(),
            //            Status = c.Int(nullable: false),
            //            CGST = c.Double(nullable: false),
            //            SGST = c.Double(nullable: false),
            //            WithoutGSTMRP = c.Single(nullable: false),
            //            WithoutGSTDP = c.Single(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ProductNum);
            
            //CreateTable(
            //    "dbo.Popupimage",
            //    c => new
            //        {
            //            Srno = c.Int(nullable: false, identity: true),
            //            Image = c.String(),
            //            status = c.Int(nullable: false),
            //            fromdate = c.DateTime(nullable: false),
            //            todate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Srno);
            
            //CreateTable(
            //    "dbo.Product_Detail",
            //    c => new
            //        {
            //            srno = c.Int(nullable: false, identity: true),
            //            Product_Id = c.String(),
            //            Product_Code = c.String(),
            //            Amount = c.Double(nullable: false),
            //            BV = c.Int(nullable: false),
            //            Member_Id = c.String(),
            //            Product_Name = c.String(),
            //            Qty = c.Int(nullable: false),
            //            Purchase_date = c.DateTime(nullable: false),
            //            Payment_Status = c.Int(nullable: false),
            //            status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.srno);
            
            //CreateTable(
            //    "dbo.slider",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            slidername = c.String(),
            //            Cdate = c.DateTime(nullable: false),
            //            status = c.Int(nullable: false),
            //            other1 = c.String(),
            //            other2 = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.payoutfast",
            //    c => new
            //        {
            //            srno = c.Int(nullable: false, identity: true),
            //            id = c.Int(nullable: false),
            //            memberid = c.String(),
            //            username = c.String(),
            //            directsum = c.Double(nullable: false),
            //            leadershipsum = c.Double(nullable: false),
            //            matchingsum = c.Double(nullable: false),
            //            levelsum = c.Double(nullable: false),
            //            roisum = c.Double(nullable: false),
            //            royalsum = c.Double(nullable: false),
            //            poolsum = c.Double(nullable: false),
            //            adminfee = c.Double(nullable: false),
            //            tdsfee = c.Double(nullable: false),
            //            totalamount = c.Double(nullable: false),
            //            netamount = c.Double(nullable: false),
            //            status = c.Int(nullable: false),
            //            startdate = c.DateTime(nullable: false),
            //            enddate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.srno);
            
            //CreateTable(
            //    "dbo.payout_date2",
            //    c => new
            //        {
            //            srno = c.Int(nullable: false, identity: true),
            //            month = c.Int(nullable: false),
            //            year = c.Int(nullable: false),
            //            date = c.DateTime(nullable: false),
            //            paid_status = c.Int(nullable: false),
            //            status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.srno);
            
            //CreateTable(
            //    "dbo.PayoutSummary2",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            dayname = c.String(),
            //            day = c.Int(nullable: false),
            //            month = c.Int(nullable: false),
            //            year = c.Int(nullable: false),
            //            status = c.Int(nullable: false),
            //            paydate = c.DateTime(nullable: false),
            //            sdate = c.DateTime(nullable: false),
            //            edate = c.DateTime(nullable: false),
            //            opid = c.String(),
            //            introid = c.Int(nullable: false),
            //            Newintroid = c.String(),
            //            IntroName = c.String(),
            //            income1 = c.Double(nullable: false),
            //            income2 = c.Double(nullable: false),
            //            income3 = c.Double(nullable: false),
            //            income4 = c.Double(nullable: false),
            //            income5 = c.Double(nullable: false),
            //            point = c.Int(nullable: false),
            //            totalamount = c.Double(nullable: false),
            //            TDS = c.Double(nullable: false),
            //            AdminFee = c.Double(nullable: false),
            //            netamount = c.Double(nullable: false),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "dbo.payoutfast2",
            //    c => new
            //        {
            //            srno = c.Int(nullable: false, identity: true),
            //            id = c.Int(nullable: false),
            //            memberid = c.String(),
            //            username = c.String(),
            //            income1 = c.Double(nullable: false),
            //            income2 = c.Double(nullable: false),
            //            income3 = c.Double(nullable: false),
            //            income4 = c.Double(nullable: false),
            //            income5 = c.Double(nullable: false),
            //            adminfee = c.Double(nullable: false),
            //            tdsfee = c.Double(nullable: false),
            //            totalamount = c.Double(nullable: false),
            //            netamount = c.Double(nullable: false),
            //            status = c.Int(nullable: false),
            //            startdate = c.DateTime(nullable: false),
            //            enddate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.srno);
            
            //CreateTable(
            //    "dbo.DirectIncome",
            //    c => new
            //        {
            //            Srno = c.Int(nullable: false, identity: true),
            //            introid = c.Int(nullable: false),
            //            intronewid = c.String(),
            //            introname = c.String(),
            //            rs = c.Double(nullable: false),
            //            date = c.Int(nullable: false),
            //            month = c.Int(nullable: false),
            //            year = c.Int(nullable: false),
            //            status = c.Int(nullable: false),
            //            point = c.Int(nullable: false),
            //            package = c.Int(nullable: false),
            //            nextsunday = c.DateTime(nullable: false),
            //            members = c.String(),
            //            position = c.Int(nullable: false),
            //            custid = c.Int(nullable: false),
            //            custnewid = c.String(),
            //            custname = c.String(),
            //            paidstatus = c.Int(nullable: false),
            //            LastPaidDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Srno);
            
            //CreateTable(
            //    "dbo.LeaderIncome",
            //    c => new
            //        {
            //            Srno = c.Int(nullable: false, identity: true),
            //            introid = c.Int(nullable: false),
            //            intronewid = c.String(),
            //            introname = c.String(),
            //            rs = c.Double(nullable: false),
            //            date = c.Int(nullable: false),
            //            month = c.Int(nullable: false),
            //            year = c.Int(nullable: false),
            //            status = c.Int(nullable: false),
            //            point = c.Int(nullable: false),
            //            package = c.Int(nullable: false),
            //            nextsunday = c.DateTime(nullable: false),
            //            members = c.String(),
            //            position = c.Int(nullable: false),
            //            custid = c.Int(nullable: false),
            //            custnewid = c.String(),
            //            custname = c.String(),
            //            paidstatus = c.Int(nullable: false),
            //            LastPaidDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Srno);
            
            //CreateTable(
            //    "dbo.popup",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Heading = c.String(),
            //            Summary = c.String(),
            //            Image = c.String(),
            //            Cdate = c.DateTime(nullable: false),
            //            status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Mediagallery",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Heading = c.String(),
            //            Summary = c.String(),
            //            Image = c.String(),
            //            Cdate = c.DateTime(nullable: false),
            //            status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.ProgramGallery",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            programid = c.Int(nullable: false),
            //            Heading = c.String(),
            //            Summary = c.String(),
            //            Type = c.Int(nullable: false),
            //            Photo = c.String(),
            //            Video = c.String(),
            //            Cdate = c.DateTime(nullable: false),
            //            opid = c.String(),
            //            status = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.businesstab",
            //    c => new
            //        {
            //            srno = c.Int(nullable: false, identity: true),
            //            Id = c.Int(nullable: false),
            //            newid = c.String(),
            //            join_date = c.DateTime(nullable: false),
            //            position = c.Int(nullable: false),
            //            rank = c.Int(nullable: false),
            //            cust_id = c.Int(nullable: false),
            //            paid_status = c.Int(nullable: false),
            //            rs = c.Double(nullable: false),
            //        })
            //    .PrimaryKey(t => t.srno);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.businesstab");
            DropTable("dbo.ProgramGallery");
            DropTable("dbo.Mediagallery");
            DropTable("dbo.popup");
            DropTable("dbo.LeaderIncome");
            DropTable("dbo.DirectIncome");
            DropTable("dbo.payoutfast2");
            DropTable("dbo.PayoutSummary2");
            DropTable("dbo.payout_date2");
            DropTable("dbo.payoutfast");
            DropTable("dbo.slider");
            DropTable("dbo.Product_Detail");
            DropTable("dbo.Popupimage");
            DropTable("dbo.Product");
            DropTable("dbo.contactdetail");
            DropTable("dbo.OTP");
            DropTable("dbo.Achiever");
            DropTable("dbo.AutopoolIncome");
            DropTable("dbo.RoyaltyIncome");
            DropTable("dbo.genology_tab2");
            DropTable("dbo.binary2");
            DropTable("dbo.Performance_income");
            DropTable("dbo.TwoIsToOneBinaryCheck");
            DropTable("dbo.Userinfo2");
            DropTable("dbo.matching_income_detail");
            DropTable("dbo.Transfer_Pin");
            DropTable("dbo.Create_Pin");
            DropTable("dbo.payout_date");
            DropTable("dbo.slcincome");
            DropTable("dbo.Roiincome");
            DropTable("dbo.Roipackage");
            DropTable("dbo.DSIINCOME");
            DropTable("dbo.PackageAssign");
            DropTable("dbo.Increment_tab");
            DropTable("dbo.Member_Turnover");
            DropTable("dbo.binarypayment");
            DropTable("dbo.BinaryIncome");
            DropTable("dbo.BussinessPlanImage");
            DropTable("dbo.WithdrawalRequest");
            DropTable("dbo.Newstab");
            DropTable("dbo.Wallet_History");
            DropTable("dbo.TeamLeveIncome");
            DropTable("dbo.SetDeduction");
            DropTable("dbo.PayoutTab");
            DropTable("dbo.LevelIncomee");
            DropTable("dbo.LevelDetail");
            DropTable("dbo.PayoutSummary");
            DropTable("dbo.package_tab");
            DropTable("dbo.Introducer_Update");
            DropTable("dbo.Operator_detail");
            DropTable("dbo.wallettab");
            DropTable("dbo.pintab");
            DropTable("dbo.userinformation");
            DropTable("dbo.genology_tab");
            DropTable("dbo.UserProfile");
            DropTable("dbo.spiltab");
            DropTable("dbo.binary");
            DropTable("dbo.Gallery");
            DropTable("dbo.User");
            DropTable("dbo.VehicleRequestDetail");
            DropTable("dbo.DailyVisitorDetail");
            DropTable("dbo.DailyVisitor");
            DropTable("dbo.TempDailyDepositTab");
            DropTable("dbo.ClosingMatchingTab");
            DropTable("dbo.ClosingAmount_Tab");
            DropTable("dbo.DailyDepositTab");
            DropTable("dbo.BankDetail_Tab");
            DropTable("dbo.PC_Tab");
            DropTable("dbo.Wallet_Transaction");
            DropTable("dbo.PayU_Payment");
            DropTable("dbo.Request_Money");
            DropTable("dbo.TempInstallmenttab");
            DropTable("dbo.SMSSpotCommTab");
            DropTable("dbo.tempappltab");
            DropTable("dbo.Visitortab");
            DropTable("dbo.Plotregistry");
            DropTable("dbo.HoldingPlot");
            DropTable("dbo.spotcomm_tab");
            DropTable("dbo.BlockTab");
            DropTable("dbo.PhaseTab");
            DropTable("dbo.PlotLimit");
            DropTable("dbo.RateTab");
            DropTable("dbo.ProTerm");
            DropTable("dbo.BookingTab");
            DropTable("dbo.AdvDeductionVoucher");
            DropTable("dbo.Blockdate");
            DropTable("dbo.ChangeAgentId");
            DropTable("dbo.MaturityStatus");
            DropTable("dbo.MaturityDocument");
            DropTable("dbo.RevivalTab");
            DropTable("dbo.RPTab");
            DropTable("dbo.Formdate");
            DropTable("dbo.BrokerCommList");
            DropTable("dbo.ReleaseTab");
            DropTable("dbo.TransactionTab");
            DropTable("dbo.Member_tab");
            DropTable("dbo.SavingAccountInfo");
            DropTable("dbo.Voucher_Report");
            DropTable("dbo.VFormatTab");
            DropTable("dbo.TDSLF_tab");
            DropTable("dbo.SpotCommTab");
            DropTable("dbo.spotcommission_tab");
            DropTable("dbo.SetMacTab");
            DropTable("dbo.SchemeTab");
            DropTable("dbo.SalaryTab");
            DropTable("dbo.Salary_em");
            DropTable("dbo.relation");
            DropTable("dbo.RecieptTab");
            DropTable("dbo.Ranktab");
            DropTable("dbo.Plan_Tab");
            DropTable("dbo.PlanTab");
            DropTable("dbo.Plan");
            DropTable("dbo.Pension_Tab");
            DropTable("dbo.MIPP_tab");
            DropTable("dbo.operatorlogin_detail");
            DropTable("dbo.Operator");
            DropTable("dbo.NewPlan");
            DropTable("dbo.NewLogin");
            DropTable("dbo.Member");
            DropTable("dbo.MaturityTab");
            DropTable("dbo.MacTab");
            DropTable("dbo.MISInstallmenttab");
            DropTable("dbo.Installmenttab");
            DropTable("dbo.InOutTime");
            DropTable("dbo.ICardTab");
            DropTable("dbo.hrlogin_detail");
            DropTable("dbo.HRTab");
            DropTable("dbo.HeadTab");
            DropTable("dbo.Fixed_Tab");
            DropTable("dbo.Expense");
            DropTable("dbo.Emp_Salary");
            DropTable("dbo.Emp_Reg");
            DropTable("dbo.Emp_leave");
            DropTable("dbo.Emp_atten");
            DropTable("dbo.DupliMacTab");
            DropTable("dbo.DuplicateTab");
            DropTable("dbo.DocumentTab");
            DropTable("dbo.delete_bond");
            DropTable("dbo.Contact");
            DropTable("dbo.CompanyInfo");
            DropTable("dbo.commission_tab");
            DropTable("dbo.comm_tab");
            DropTable("dbo.CityStateTab");
            DropTable("dbo.Cancel_Receipt");
            DropTable("dbo.calculator");
            DropTable("dbo.Branchtab");
            DropTable("dbo.branchlogindetail");
            DropTable("dbo.bonus_tab");
            DropTable("dbo.Bond_report");
            DropTable("dbo.appltab");
            DropTable("dbo.AgentDetail");
            DropTable("dbo.AdvBrokerPaymentTab");
        }
    }
}
