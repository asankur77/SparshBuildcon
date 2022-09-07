namespace SPARSHBUILDCON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adcolpaidstatusinagdetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AgentDetail", "paidstatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AgentDetail", "paidstatus");
        }
    }
}
