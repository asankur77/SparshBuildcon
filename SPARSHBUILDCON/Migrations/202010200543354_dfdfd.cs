namespace SPARSHBUILDCON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dfdfd : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.CompanyInfo", "emiamount", c => c.Double(nullable: false));
            //AddColumn("dbo.CompanyInfo", "duedate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CompanyInfo", "duedate");
            DropColumn("dbo.CompanyInfo", "emiamount");
        }
    }
}
