namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingRooms", "NumberOfRooms", c => c.Int(nullable: false));
            AddColumn("dbo.BookingRooms", "NumberOfPersons", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookingRooms", "NumberOfPersons");
            DropColumn("dbo.BookingRooms", "NumberOfRooms");
        }
    }
}
