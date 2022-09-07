namespace SPARSHBUILDCON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dfdfdf : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.RecieptTab", "Chequeno", c => c.String());
            //AddColumn("dbo.RecieptTab", "Account", c => c.String());
            //AddColumn("dbo.RecieptTab", "Acholdername", c => c.String());
            //AddColumn("dbo.RecieptTab", "Bankbranch", c => c.String());
            //AddColumn("dbo.RecieptTab", "IFSCcode", c => c.String());
            //AddColumn("dbo.RecieptTab", "ChequeAmount", c => c.Double(nullable: false));
            //AddColumn("dbo.RecieptTab", "ChequeDate", c => c.DateTime(nullable: false));
            //AddColumn("dbo.RecieptTab", "ChequeImage", c => c.Binary());
            //AddColumn("dbo.RecieptTab", "ChequeAppDate", c => c.DateTime(nullable: false));
            //AddColumn("dbo.RecieptTab", "Chequeimg", c => c.String());
            //AddColumn("dbo.RecieptTab", "Transactiontype", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RecieptTab", "Transactiontype");
            DropColumn("dbo.RecieptTab", "Chequeimg");
            DropColumn("dbo.RecieptTab", "ChequeAppDate");
            DropColumn("dbo.RecieptTab", "ChequeImage");
            DropColumn("dbo.RecieptTab", "ChequeDate");
            DropColumn("dbo.RecieptTab", "ChequeAmount");
            DropColumn("dbo.RecieptTab", "IFSCcode");
            DropColumn("dbo.RecieptTab", "Bankbranch");
            DropColumn("dbo.RecieptTab", "Acholdername");
            DropColumn("dbo.RecieptTab", "Account");
            DropColumn("dbo.RecieptTab", "Chequeno");
        }
    }
}
