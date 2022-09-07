namespace SPARSHBUILDCON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adpropertyaddresscol : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.tempappltab", "propertyaddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tempappltab", "propertyaddress");
        }
    }
}
