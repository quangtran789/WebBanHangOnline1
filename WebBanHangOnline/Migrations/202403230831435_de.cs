namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class de : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Order", "Address", c => c.String(nullable: false));
            DropColumn("dbo.tb_Order", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Order", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.tb_Order", "Address", c => c.String());
        }
    }
}
