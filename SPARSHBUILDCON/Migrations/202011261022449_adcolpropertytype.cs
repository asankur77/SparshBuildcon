namespace SPARSHBUILDCON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adcolpropertytype : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.tempappltab", "propertytype", c => c.String());
            //AddColumn("dbo.tempappltab", "propertypreference", c => c.String());
            //AddColumn("dbo.tempappltab", "incomegroup", c => c.String());
            //AddColumn("dbo.tempappltab", "plotdesp", c => c.String());
            //AlterColumn("dbo.pintab", "pinamount", c => c.Double(nullable: false));
            //AlterColumn("dbo.package_tab", "packageamount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.package_tab", "packageamount", c => c.Int(nullable: false));
            AlterColumn("dbo.pintab", "pinamount", c => c.String());
            DropColumn("dbo.tempappltab", "plotdesp");
            DropColumn("dbo.tempappltab", "incomegroup");
            DropColumn("dbo.tempappltab", "propertypreference");
            DropColumn("dbo.tempappltab", "propertytype");
        }
    }
}
