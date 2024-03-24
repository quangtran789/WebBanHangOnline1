namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UP : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Posts", "SepTitle", c => c.String(maxLength: 250));
            DropColumn("dbo.tb_Posts", "SeoTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Posts", "SeoTitle", c => c.String(maxLength: 250));
            DropColumn("dbo.tb_Posts", "SepTitle");
        }
    }
}
