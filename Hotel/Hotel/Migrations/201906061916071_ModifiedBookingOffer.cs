namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedBookingOffer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingOffers", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookingOffers", "Status");
        }
    }
}
