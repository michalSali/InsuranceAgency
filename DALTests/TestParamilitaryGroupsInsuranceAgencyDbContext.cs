using System;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace DALTests
{
    public class TestParamilitaryGroupsInsuranceAgencyDbContext : ParamilitaryGroupsInsuranceAgencyDbContext
    {
        // UseInMemoryDatabase does not work for either Windows or Linux,
        // from Microsoft documentation: "This database [EF Core in-memory database] is in general 
        //                                not suitable for testing applications that use EF Core."
        public TestParamilitaryGroupsInsuranceAgencyDbContext() 
            : base(
                new DbContextOptionsBuilder<ParamilitaryGroupsInsuranceAgencyDbContext>()
                  .UseSqlServer("Server=(localdb)\\mssqllocaldb; Initial Catalog = ParamilitaryDb7")
                  //.UseInMemoryDatabase(databaseName: "Test")
                  .Options
            )
        {
        }
    }
}