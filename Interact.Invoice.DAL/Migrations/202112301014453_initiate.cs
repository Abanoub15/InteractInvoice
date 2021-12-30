namespace Interact.Invoice.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initiate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Email = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        PostedOn = c.DateTime(nullable: false),
                        InvoiceDocumentId = c.Guid(),
                        InvoiceNumber = c.String(),
                        DocumentStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Documents");
        }
    }
}
