using DAL;
using DAL.Models;
using DAL.Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace DALTests
{
    public class DummyForTesting
    {
        private readonly ParamilitaryGroupsInsuranceAgencyDbContext context;

        public DummyForTesting(ParamilitaryGroupsInsuranceAgencyDbContext context)
        {
            this.context = context;
        }

        public Conflict GetConflict(int id)
        {
            return context.Conflicts.FirstOrDefault(e => e.Id == id);
        }

        public User GetUser(int id)
        {
            return context.Users.FirstOrDefault(e => e.Id == id);
        }

        public List<User> GetUsersByName(string name)
        {
            return context.Users.Where(x => x.Name == name).ToList();
        }

        public List<User> GetUsersByGender(Gender gender)
        {
            return context.Users.Where(x => x.Gender == gender).ToList();
        }

        public Client GetClient(int id)
        {
            return context.Clients.FirstOrDefault(x => x.Id == id);
        }
    }
}