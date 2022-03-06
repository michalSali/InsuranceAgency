using DAL;
using DAL.Models;
using DAL.Models.Enums;
using System;
using System.Collections.Generic;
using Xunit;

namespace DALTests
{
    public class DummyTestsInMemory
    {
        
        private readonly Func<ParamilitaryGroupsInsuranceAgencyDbContext> CreateContext = () =>
        {
            var ctx = new TestParamilitaryGroupsInsuranceAgencyDbContext();
            ctx.Database.EnsureCreated();
            return ctx;
        };


        [Fact]
        public void GetReturnsCorrectConflict()
        {
            var expectedName = "conflict_1";
            string actualName;
            using (var ctx = CreateContext())
            {
                var id = 1;
                var testClass = new DummyForTesting(ctx);
                actualName = testClass.GetConflict(id).Name;
            }
            Assert.Equal(expectedName, actualName);
        }

        [Fact]
        public void GetReturnsCorrectUser()
        {
            var expectedName = "Terry Fisher";
            string actualName;
            using (var ctx = CreateContext())
            {
                var id = 1;
                var testClass = new DummyForTesting(ctx);
                actualName = testClass.GetUser(id).Name;
            }
            Assert.Equal(expectedName, actualName);
        }

        [Fact]
        public void GetReturnsCorrectUsersByName()
        {
            int expectedId = 1;
            int actualId;
            List<User> users;
            using (var ctx = CreateContext())
            {
                var name = "Terry Fisher";
                var testClass = new DummyForTesting(ctx);
                users = testClass.GetUsersByName(name);                
            }

            Assert.NotNull(users);
            Assert.True(users.Count == 1);
            actualId = users[0].Id;
            Assert.Equal(expectedId, actualId);
        }

        [Fact]
        public void GetReturnsCorrectUserCount()
        {
            int expectedCount = 2;
            int actualCount;
            List<User> users;
            using (var ctx = CreateContext())
            {
                var gender = Gender.Female;
                var testClass = new DummyForTesting(ctx);
                users = testClass.GetUsersByGender(gender);                
            }

            Assert.NotNull(users);
            actualCount = users.Count;
            Assert.Equal(expectedCount, actualCount);
        }

        [Fact]
        public void GetReturnsNull()
        {
            Client expectedResult = null;
            Client actualResult;
            using (var ctx = CreateContext())
            {
                var id = 100;
                var testClass = new DummyForTesting(ctx);
                actualResult = testClass.GetClient(id);
            }
            Assert.Equal(expectedResult, actualResult);
        }


    }
}