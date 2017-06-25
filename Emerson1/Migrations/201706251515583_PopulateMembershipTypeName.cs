namespace Emerson1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypeName : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes Set Name = 'Pay As You Go' Where Id = 1");
            Sql("Update MembershipTypes Set Name = 'Monthly' Where Id = 2");
            Sql("Update MembershipTypes Set Name = 'Quarterly' Where Id = 2");
            Sql("Update MembershipTypes Set Name = 'Annually' Where Id = 3");
        }
        
        public override void Down()
        {
        }
    }
}
