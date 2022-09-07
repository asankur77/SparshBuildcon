namespace SPARSHBUILDCON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adcolpaidstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.appltab", "paidstatus", c => c.Int(nullable: false));
            AddColumn("dbo.Installmenttab", "paidstatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Installmenttab", "paidstatus");
            DropColumn("dbo.appltab", "paidstatus");
        }
    }
}
