namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingOffers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        OfferId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Offers", t => t.OfferId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.OfferId);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RoomId = c.Int(nullable: false),
                        StartPeriod = c.DateTime(nullable: false),
                        EndPeriod = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomType = c.Byte(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookingRooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        StartPeriod = c.DateTime(nullable: false),
                        EndPeriod = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.BookingRoomServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookingRoomId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BookingRooms", t => t.BookingRoomId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.BookingRoomId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceType = c.Byte(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoomFeatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomId = c.Int(nullable: false),
                        FeatureId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Features", t => t.FeatureId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId)
                .Index(t => t.FeatureId);
            
            CreateTable(
                "dbo.RoomImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomId = c.Int(nullable: false),
                        Image = c.Binary(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId);
            
            AddColumn("dbo.Users", "Deleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoomImages", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.RoomFeatures", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.RoomFeatures", "FeatureId", "dbo.Features");
            DropForeignKey("dbo.BookingRoomServices", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.BookingRoomServices", "BookingRoomId", "dbo.BookingRooms");
            DropForeignKey("dbo.BookingRooms", "UserId", "dbo.Users");
            DropForeignKey("dbo.BookingRooms", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.BookingOffers", "UserId", "dbo.Users");
            DropForeignKey("dbo.BookingOffers", "OfferId", "dbo.Offers");
            DropForeignKey("dbo.Offers", "RoomId", "dbo.Rooms");
            DropIndex("dbo.RoomImages", new[] { "RoomId" });
            DropIndex("dbo.RoomFeatures", new[] { "FeatureId" });
            DropIndex("dbo.RoomFeatures", new[] { "RoomId" });
            DropIndex("dbo.BookingRoomServices", new[] { "ServiceId" });
            DropIndex("dbo.BookingRoomServices", new[] { "BookingRoomId" });
            DropIndex("dbo.BookingRooms", new[] { "RoomId" });
            DropIndex("dbo.BookingRooms", new[] { "UserId" });
            DropIndex("dbo.Offers", new[] { "RoomId" });
            DropIndex("dbo.BookingOffers", new[] { "OfferId" });
            DropIndex("dbo.BookingOffers", new[] { "UserId" });
            DropColumn("dbo.Users", "Deleted");
            DropTable("dbo.RoomImages");
            DropTable("dbo.RoomFeatures");
            DropTable("dbo.Features");
            DropTable("dbo.Services");
            DropTable("dbo.BookingRoomServices");
            DropTable("dbo.BookingRooms");
            DropTable("dbo.Rooms");
            DropTable("dbo.Offers");
            DropTable("dbo.BookingOffers");
        }
    }
}
